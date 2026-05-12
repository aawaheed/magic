/*
 * Magic Cloud, copyright (c) 2023 Thomas Hansen. See the attached LICENSE file for details. For license inquiries you can send an email to thomas@ainiro.io
 */

using System.Collections.Generic;
using magic.signals.contracts;

namespace magic.lambda.http.signatures
{
    /// <summary>
    /// Child signature for HTTP slots.
    /// </summary>
    public abstract class HttpSignature : ISlotSignature
    {
        /// <inheritdoc />
        public abstract IEnumerable<SlotChild> Children { get; }

        /// <inheritdoc />
        public virtual IEnumerable<SlotChild> OutputChildren => new[]
        {
            new SlotChild
            {
                Name = "headers",
                Type = "lambda",
                Kind = "http-header-list",
                Description = "HTTP response headers returned by the server",
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
                        Kind = "http-header-value",
                        Description = "HTTP response header value; child name is the header name",
                        Required = false,
                        Mode = SlotChildMode.Value,
                        Cardinality = SlotChildCardinality.ZeroOrMore,
                        Role = SlotChildRole.Option,
                        Projection = SlotChildProjection.Value,
                    },
                },
            },
            new SlotChild
            {
                Name = "content",
                Type = "string|byte[]|lambda",
                Kind = "http-response-content",
                Description = "HTTP response body; text responses are returned as string, binary responses as byte[], and converted known content types as child nodes when [convert] is true",
                Required = false,
                Mode = SlotChildMode.Value,
                Cardinality = SlotChildCardinality.ZeroOrOne,
                Role = SlotChildRole.Payload,
                Projection = SlotChildProjection.Self,
            },
        };

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

        internal static SlotChild DynamicMap(string name, string description)
        {
            var childDescription = name switch
            {
                "query" => "Query parameter value",
                "url-params" => "URL placeholder replacement value",
                "headers" => "HTTP header value",
                _ => "Named value",
            };
            var childKind = name switch
            {
                "query" => "query-parameter-value",
                "url-params" => "url-parameter-value",
                "headers" => "http-header-value",
                _ => null,
            };
            return new SlotChild
            {
                Name = name,
                Type = "lambda",
                Kind = name == "headers" ? "http-header-list" : null,
                Description = description,
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
                        Kind = childKind,
                        Description = childDescription,
                        Required = false,
                        Mode = SlotChildMode.ValueOrExpression,
                        Cardinality = SlotChildCardinality.ZeroOrMore,
                        Role = SlotChildRole.Option,
                        Projection = SlotChildProjection.Value,
                    },
                },
            };
        }

        internal static SlotChild Sse()
        {
            return new SlotChild
            {
                Name = ".sse",
                Type = "lambda",
                Description = "Callback executed once per server-sent event line with [.arguments/message]",
                Required = false,
                Mode = SlotChildMode.ExecutableLambda,
                Cardinality = SlotChildCardinality.ZeroOrOne,
                Role = SlotChildRole.Callback,
                Evaluation = SlotChildEvaluation.EvalBlock,
                Projection = SlotChildProjection.Self,
            };
        }

        internal static IEnumerable<SlotChild> Common()
        {
            return new[]
            {
                DynamicMap("query", "Query string parameters"),
                DynamicMap("url-params", "Named replacements for {placeholders} in the URL"),
                DynamicMap("headers", "HTTP request headers"),
                Option("token", "string", "Bearer token to add as Authorization header", kind: "bearer-token"),
                Option("timeout", "int", "Request timeout in seconds"),
                Option("convert", "bool", "Whether to convert known response content types to lambda", "false"),
                Sse(),
            };
        }
    }

    /// <summary>
    /// Child signature for HTTP GET and DELETE slots.
    /// </summary>
    public class HttpEmptyRequestSignature : HttpSignature
    {
        /// <inheritdoc />
        public override IEnumerable<SlotChild> Children => Common();
    }

    /// <summary>
    /// Child signature for HTTP POST, PUT, and PATCH slots.
    /// </summary>
    public class HttpPayloadRequestSignature : HttpSignature
    {
        /// <inheritdoc />
        public override IEnumerable<SlotChild> Children
        {
            get
            {
                var result = new List<SlotChild>(Common())
                {
                    new SlotChild
                    {
                        Name = "payload",
                        Type = "object|lambda",
                        Description = "Request payload value or structured payload transformed according to Content-Type",
                        Required = false,
                        Mode = SlotChildMode.SourceLambda,
                        Cardinality = SlotChildCardinality.ZeroOrOne,
                        Role = SlotChildRole.Payload,
                        Evaluation = SlotChildEvaluation.UnwrapDescendants,
                        Projection = SlotChildProjection.StructuredTree,
                    },
                    Option("filename", "string", "File path to stream as the request payload", kind: "file-path"),
                };
                return result;
            }
        }
    }
}
