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

        protected static SlotChild Option(string name, string type, string description, bool required = false, string kind = null)
        {
            return new SlotChild
            {
                Name = name,
                Type = type,
                Kind = kind,
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
                Kind = "http-response-header-value",
                Description = "Response header name and value",
                Required = true,
                Mode = SlotChildMode.ValueOrExpression,
                Cardinality = SlotChildCardinality.OneOrMore,
                Role = SlotChildRole.DynamicMap,
                Projection = SlotChildProjection.Value,
                // Dispatch the value catalog off the header NAME — same
                // pattern HttpSignatures.cs uses for request `[headers]/*`.
                // Without this, the header NAME comes from
                // `http-response-header-value-names` (which exists) but
                // the VALUE picker looks for `http-response-header-value`
                // (which doesn't exist as a top-level catalog) and falls
                // back to `sample-XXXX` placeholders — producing nonsense
                // like `Expires:sample-d440`. Dispatch routes Date / ETag /
                // Cache-Control / auth headers / correlation IDs to typed
                // catalogs; everything else falls through to the generic
                // `http-header-value` pool (the merged request-header
                // catalog — fine for response use too).
                ValueTemplate =
                    "{catalog-by-name:" +
                    "^Content-Type$=content-type|" +
                    "^Expires$=date|" +
                    "^Last-Modified$=date|" +
                    "^Date$=date|" +
                    "^If-Modified-Since$=date|" +
                    "^If-Unmodified-Since$=date|" +
                    "^X-Request-ID$=guid|" +
                    "^X-Correlation-ID$=guid|" +
                    "^X-Trace-ID$=guid|" +
                    "^WWW-Authenticate$=bearer-token|" +
                    "^Proxy-Authenticate$=bearer-token|" +
                    "*=http-header-value}",
            },
        };
    }

    public class ResponseCookieSetSignature : EndpointSignature
    {
        public override IEnumerable<SlotChild> Children => new[]
        {
            // 'text' added: a cookie [value] is arbitrary text content (session ids, user tokens, serialized state, free-form strings) — any `text` producer should be wirable. `cookie-value` stays first for catalog selection.
            Option("value", "string", "Cookie value", true, "cookie-value,text"),
            Option("expires", "DateTime", "Cookie expiration"),
            Option("http-only", "bool", "Whether the cookie is HTTP-only"),
            Option("secure", "bool", "Whether the cookie is secure"),
            Option("domain", "string", "Cookie domain", kind: "cookie-domain"),
            Option("path", "string", "Cookie path", kind: "cookie-path"),
            Option("same-site", "string", "Cookie SameSite mode: Strict, Lax, None, or Unspecified", kind: "cookie-same-site"),
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
                Kind = "mime-type",
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
            Option("version", "string", "IP version to return, either ipv4 or ipv6", kind: "ip-version"),
        };
    }
}
