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
    // 'text' pruned: this slot needs already-URL-encoded text, not arbitrary text.
    [Slot(
        Name = "strings.url-decode",
        Description = "URL decodes the specified string",
        ValueKind = "url-encoded",
        ValueDescription = "Text to decode",
        ValueRequired = true,
        ValueMode = SlotValueMode.ValueOrExpression,
        ValueExpressionResolution = SlotValueExpressionResolution.SingleNode,
        ReturnsMode = SlotReturnsMode.Value,
        // Multi-tag chain, specific → structural: `text,formattable-value`
        // were missing — the decoded URL component IS text under the hood,
        // and every text-consuming slot (log.info, strings.*, etc.) must be
        // able to kind-match the output. Matches the html-decode/html-encode
        // chains: `<specific>,text,formattable-value`.
        ReturnsKind = "url-component,text",
        ReturnsDescription = "Resolves to the URL-decoded string")]
    public class UrlDecode : ISlot
    {
        /// <summary>
        /// Implementation of slot.
        /// </summary>
        /// <param name="signaler">Signaler used to raise signal.</param>
        /// <param name="input">Arguments to your slot.</param>
        public void Signal(ISignaler signaler, Node input)
        {
            input.Value = WebUtility.UrlDecode(input.GetEx<string>());
        }
    }
}
