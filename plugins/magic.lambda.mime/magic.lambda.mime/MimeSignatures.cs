/*
 * Magic Cloud, copyright (c) 2023 Thomas Hansen. See the attached LICENSE file for details. For license inquiries you can send an email to thomas@ainiro.io
 */

using System.Collections.Generic;
using magic.signals.contracts;

namespace magic.lambda.mime.signatures
{
    /// <summary>
    /// Signature for MIME entity declarations.
    /// </summary>
    public class MimeCreateSignature : ISlotSignature
    {
        /// <inheritdoc />
        public IEnumerable<SlotChild> Children => new[]
        {
            Option("structured", "bool", "When true returns the MIME tree as [headers] and [content] children; when false (default) returns the serialized MIME message text in the slot value", "false"),
            Headers(),
            Content(),
            Filename(),
            Entity(),
        };

        /// <inheritdoc />
        public IEnumerable<SlotConstraint> Constraints => EntityShapeConstraints();

        /// <inheritdoc />
        public IEnumerable<SlotChild> OutputChildren => MimeParseSignature.ParsedEntityChildren(2);

        public static SlotChild Option(string name, string type, string description, string defaultValue = null, string kind = null)
        {
            return new SlotChild
            {
                Name = name,
                Type = type,
                Kind = kind,
                Description = description,
                Required = false,
                DefaultValue = defaultValue,
                Mode = SlotChildMode.ValueOrExpression,
                Cardinality = SlotChildCardinality.ZeroOrOne,
                Role = SlotChildRole.Option,
                Projection = SlotChildProjection.Value,
            };
        }

        public static SlotChild Headers()
        {
            return new SlotChild
            {
                Name = "headers",
                Type = "lambda",
                Kind = "mime-header-list",
                Description = "MIME headers",
                Required = false,
                Mode = SlotChildMode.DynamicNamedValues,
                Cardinality = SlotChildCardinality.ZeroOrOne,
                Role = SlotChildRole.DynamicMap,
                Projection = SlotChildProjection.StructuredTree,
                Children =
                {
                    new SlotChild
                    {
                        Name = "*",
                        Type = "string",
                        Kind = "mime-header-value",
                        Description = "Header name and value",
                        Required = false,
                        Mode = SlotChildMode.ValueOrExpression,
                        Cardinality = SlotChildCardinality.ZeroOrMore,
                        Role = SlotChildRole.Option,
                        Projection = SlotChildProjection.Value,
                    },
                },
            };
        }

        public static SlotChild Content()
        {
            return Option("content", "string", "Inline MIME part content", kind: "mime-content,mime-entity-source");
        }

        public static SlotChild Filename()
        {
            return Option("filename", "string", "File path to use as MIME part content", kind: "file-path,mime-entity-source,mime-entity-filename-source");
        }

        public static SlotChild Entity()
        {
            return Entity(2);
        }

        // Depth-limited recursion so the schema can describe nested multiparts while staying finite.
        // At the innermost level (depth==0) the schema has no nested [entity] child, so the value
        // must be a leaf MIME type — a different description routes the value picker to a leaf-only catalog.
        //
        // Cardinality intentionally = TwoOrMore on the entity SlotChild itself. This expresses the
        // runtime invariant "multipart needs ≥ 2 parts" at the contract level — BuildChildren's
        // CountFor reads it as 2-3 for non-excluded values, and the leaf-vs-multipart EXCLUDES
        // constraint below zeros it out for leaf MIME types (which must not nest entities at all).
        // Keeping the lower bound on the SlotChild means the pipeline path overlay can re-enforce
        // it generically via member.Cardinality without needing slot-name knowledge.
        static SlotChild Entity(int depth)
        {
            var result = new SlotChild
            {
                Name = "entity",
                Type = "string",
                Kind = "content-type",
                Description = depth > 0 ?
                    "Nested MIME entity content type; same leaf-vs-multipart shape as the parent [mime.create] value" :
                    "Innermost MIME leaf entity content type; must be a leaf type because no further [entity] nesting is permitted here",
                Required = true,
                Mode = SlotChildMode.ValueOrExpression,
                Cardinality = SlotChildCardinality.TwoOrMore,
                Role = SlotChildRole.StructuredObject,
                Projection = SlotChildProjection.StructuredTree,
                Children =
                {
                    Headers(),
                    Content(),
                    Filename(),
                },
            };
            if (depth > 0)
                result.Children.Add(Entity(depth - 1));
            foreach (var c in EntityShapeConstraints())
                result.Constraints.Add(c);
            return result;
        }

        // Same leaf-vs-multipart shape constraints as the top-level slot, evaluated against the
        // entity node's value (its MIME content type). Reusable so [mail.smtp.send] can attach
        // them to its own [message/entity] child.
        public static IEnumerable<SlotConstraint> EntityShapeConstraints()
        {
            var leaf = new SlotConstraint
            {
                Kind = SlotConstraintKind.ExactlyOneOf,
                Description = "Leaf MIME parts require either [content] or [filename]",
                ValuePattern = @"^(?!multipart/).+/.+$",
            };
            leaf.Values.AddRange(new[] { "content", "filename" });

            var leafExcludesEntity = new SlotConstraint
            {
                Kind = SlotConstraintKind.Excludes,
                Description = "Leaf MIME parts must not contain nested [entity] children",
                ValuePattern = @"^(?!multipart/).+/.+$",
            };
            leafExcludesEntity.Values.Add("entity");

            var multipart = new SlotConstraint
            {
                Kind = SlotConstraintKind.AtLeastOneOf,
                Description = "Multipart MIME parts require one or more [entity] children",
                ValuePattern = @"^multipart/.+$",
            };
            multipart.Values.Add("entity");

            var multipartExcludesLeaf = new SlotConstraint
            {
                Kind = SlotConstraintKind.Excludes,
                Description = "Multipart MIME parts must not contain [content] or [filename]",
                ValuePattern = @"^multipart/.+$",
            };
            multipartExcludesLeaf.Values.AddRange(new[] { "content", "filename" });

            return new[] { leaf, leafExcludesEntity, multipart, multipartExcludesLeaf };
        }
    }

    /// <summary>
    /// Signature for parsed MIME entity trees.
    /// </summary>
    public class MimeParseSignature : ISlotSignature
    {
        /// <inheritdoc />
        public IEnumerable<SlotChild> Children => new SlotChild[0];

        /// <inheritdoc />
        public IEnumerable<SlotChild> OutputChildren => ParsedEntityChildren(2);

        internal static IEnumerable<SlotChild> ParsedEntityChildren(int depth)
        {
            var result = new List<SlotChild>
            {
                ParsedHeaders(),
                ParsedContent(),
            };
            if (depth > 0)
                result.Add(ParsedEntity(depth - 1));
            return result;
        }

        static SlotChild ParsedHeaders()
        {
            return new SlotChild
            {
                Name = "headers",
                Type = "lambda",
                Kind = "mime-header-list",
                Description = "MIME headers from the parsed entity, excluding Content-Type because the entity content type is returned as the node value",
                Required = false,
                Mode = SlotChildMode.Value,
                Cardinality = SlotChildCardinality.ZeroOrOne,
                Role = SlotChildRole.StructuredObject,
                Projection = SlotChildProjection.StructuredTree,
                Children =
                {
                    new SlotChild
                    {
                        Name = "*",
                        Type = "string",
                        Kind = "mime-header-value",
                        Description = "Parsed MIME header value; child name is the header name",
                        Required = false,
                        Mode = SlotChildMode.Value,
                        Cardinality = SlotChildCardinality.ZeroOrMore,
                        Role = SlotChildRole.Option,
                        Projection = SlotChildProjection.Value,
                    },
                },
            };
        }

        static SlotChild ParsedContent()
        {
            return new SlotChild
            {
                Name = "content",
                Type = "string|byte[]",
                Kind = "mime-content,binary-content",
                Description = "Decoded MIME part content; text parts return string content and binary parts return byte[] content",
                Required = false,
                Mode = SlotChildMode.Value,
                Cardinality = SlotChildCardinality.ZeroOrOne,
                Role = SlotChildRole.Payload,
                Projection = SlotChildProjection.Value,
            };
        }

        static SlotChild ParsedEntity(int depth)
        {
            var result = new SlotChild
            {
                Name = "entity",
                Type = "string",
                Kind = "content-type",
                Description = "Nested parsed MIME entity; node value is the nested entity content type, and children carry headers, content, and any deeper entities",
                Required = false,
                Mode = SlotChildMode.Value,
                Cardinality = SlotChildCardinality.ZeroOrMore,
                Role = SlotChildRole.StructuredObject,
                Projection = SlotChildProjection.StructuredTree,
            };
            result.Children.AddRange(ParsedEntityChildren(depth));
            return result;
        }
    }
}
