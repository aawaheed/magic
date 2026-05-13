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
            Option("structured", "bool", "Whether to return structured headers and content nodes", "false"),
            Headers(),
            Content(),
            Filename(),
            Entity(),
        };

        /// <inheritdoc />
        public IEnumerable<SlotConstraint> Constraints
        {
            get
            {
                var leaf = new SlotConstraint
                {
                    Kind = SlotConstraintKind.ExactlyOneOf,
                    Description = "Leaf MIME parts require either [content] or [filename]",
                };
                leaf.Values.AddRange(new[] { "content", "filename" });
                return new[] { leaf };
            }
        }

        internal static SlotChild Option(string name, string type, string description, string defaultValue = null, string kind = null)
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

        internal static SlotChild Headers()
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

        internal static SlotChild Content()
        {
            var result = Option("content", "string", "Inline MIME part content", kind: "mime-content");
            result.Children.Add(Option("Content-Encoding", "string", "Optional MIME content transfer encoding", kind: "mime-transfer-encoding"));
            return result;
        }

        internal static SlotChild Filename()
        {
            var result = Option("filename", "string", "File path to use as MIME part content", kind: "file-path");
            result.Children.Add(Option("Content-Encoding", "string", "Optional MIME content transfer encoding", kind: "mime-transfer-encoding"));
            return result;
        }

        internal static SlotChild Entity()
        {
            return new SlotChild
            {
                Name = "entity",
                Type = "lambda",
                Description = "Nested MIME entity used by multipart content",
                Required = false,
                Mode = SlotChildMode.StructuredArguments,
                Cardinality = SlotChildCardinality.ZeroOrMore,
                Role = SlotChildRole.StructuredObject,
                Projection = SlotChildProjection.StructuredTree,
                Children =
                {
                    Headers(),
                    Content(),
                    Filename(),
                },
            };
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

        static IEnumerable<SlotChild> ParsedEntityChildren(int depth)
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
                Type = "lambda",
                Kind = "mime-tree",
                ElementType = "object",
                ElementKind = "mime-tree-node",
                Description = "Nested parsed MIME entity; node value is the nested entity content type",
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
