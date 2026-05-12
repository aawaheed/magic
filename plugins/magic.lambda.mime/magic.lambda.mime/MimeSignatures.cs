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
}
