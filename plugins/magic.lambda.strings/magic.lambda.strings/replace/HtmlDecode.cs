/*
 * Magic Cloud, copyright (c) 2023 Thomas Hansen. See the attached LICENSE file for details. For license inquiries you can send an email to thomas@ainiro.io
 */

using System.Net;
using magic.node;
using magic.node.extensions;
using magic.signals.contracts;

namespace magic.lambda.strings.replace
{
    /// <summary>
    /// [strings.url-decode] slot that URL decodes the specified string.
    /// </summary>
    [Slot(
        Name = "strings.html-decode",
        Description = "HTML decodes the specified string",
        ValueKind = "html-encoded,text",
        ValueDescription = "HTML encoded text to decode",
        ValueRequired = true,
        ValueMode = SlotValueMode.ValueOrExpression,
        ValueExpressionResolution = SlotValueExpressionResolution.SingleNode,
        ReturnsMode = SlotReturnsMode.Value,
        // Decoded HTML markup, not bare text — `&lt;p&gt;` becomes `<p>`,
        // and what comes out is raw HTML. Multi-tag the kind to declare
        // the slot's full contract directly on the attribute: the primary
        // kind is `html-unencoded` (the inverse of html-encode's input)
        // so kind-strict consumers wire correctly, and the trailing `text`
        // tag self-declares that the output is also text-compatible —
        // text-consuming slots (log.info, strings.*, etc.) can pick it up
        // without needing a separate supertype rule in rules.yaml. The
        // slot is the source of truth for its own kinds.
        ReturnsKind = "html-unencoded,text",
        ReturnsDescription = "Resolves to the decoded HTML markup")]
    public class HtmlDecode : ISlot
    {
        /// <summary>
        /// Implementation of slot.
        /// </summary>
        /// <param name="signaler">Signaler used to raise signal.</param>
        /// <param name="input">Arguments to your slot.</param>
        public void Signal(ISignaler signaler, Node input)
        {
            input.Value = WebUtility.HtmlDecode(input.GetEx<string>());
        }
    }
}
