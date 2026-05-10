/*
 * Magic Cloud, copyright (c) 2023 Thomas Hansen. See the attached LICENSE file for details. For license inquiries you can send an email to thomas@ainiro.io
 */

using System.Collections.Generic;
using magic.signals.contracts;

namespace magic.endpoint.services.signatures
{
    public abstract class EndpointSignature : ISlotSignature
    {
        public virtual IEnumerable<SlotChild> Children => new SlotChild[0];

        protected static SlotChild Option(string name, string type, string description, bool required = false)
        {
            return new SlotChild
            {
                Name = name,
                Type = type,
                Description = description,
                Required = required,
                Mode = SlotChildMode.ValueOrExpression,
                Cardinality = required ? SlotChildCardinality.ExactlyOne : SlotChildCardinality.ZeroOrOne,
                Role = SlotChildRole.Option,
                Projection = SlotChildProjection.Value,
            };
        }
    }

    public class ResponseHeadersSetSignature : EndpointSignature
    {
        public override IEnumerable<SlotChild> Children => new[]
        {
            new SlotChild
            {
                Name = "*",
                Type = "string",
                Description = "Response header name and value",
                Required = true,
                Mode = SlotChildMode.ValueOrExpression,
                Cardinality = SlotChildCardinality.OneOrMore,
                Role = SlotChildRole.DynamicMap,
                Projection = SlotChildProjection.Value,
            },
        };
    }

    public class ResponseCookieSetSignature : EndpointSignature
    {
        public override IEnumerable<SlotChild> Children => new[]
        {
            Option("value", "string", "Cookie value", true),
            Option("expires", "DateTime", "Cookie expiration"),
            Option("http-only", "bool", "Whether the cookie is HTTP-only"),
            Option("secure", "bool", "Whether the cookie is secure"),
            Option("domain", "string", "Cookie domain"),
            Option("path", "string", "Cookie path"),
            Option("same-site", "string", "Cookie SameSite mode"),
        };
    }

    public class MimeAddSignature : EndpointSignature
    {
        public override IEnumerable<SlotChild> Children => new[]
        {
            new SlotChild
            {
                Name = ".",
                Type = "string",
                Description = "MIME type value for the extension/key",
                Required = true,
                Mode = SlotChildMode.ExecutableLambda,
                Cardinality = SlotChildCardinality.ExactlyOne,
                Role = SlotChildRole.SourceExpression,
                Evaluation = SlotChildEvaluation.EvalSelf,
                Projection = SlotChildProjection.Value,
            },
        };
    }

    public class IpVersionSignature : EndpointSignature
    {
        public override IEnumerable<SlotChild> Children => new[]
        {
            Option("version", "string", "IP version to return, either ipv4 or ipv6"),
        };
    }
}
