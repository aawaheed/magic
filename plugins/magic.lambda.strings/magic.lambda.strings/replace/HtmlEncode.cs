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
    /// [strings.html-encode] slot that HTML encodes the specified string.
    /// </summary>
    [Slot(
        Name = "strings.html-encode",
        Description = "HTML encodes the specified string",
        ValueKind = "html-unencoded,text",
        ValueDescription = "Non-encoded HTML text to encode",
        ValueRequired = true,
        ValueMode = SlotValueMode.ValueOrExpression,
        ValueExpressionResolution = SlotValueExpressionResolution.SingleNode,
        ReturnsMode = SlotReturnsMode.Value,
        // Entity-encoded HTML is still text under the hood — the trailing
        // `text` tag lets text-consumers (log.info, strings.*) wire to
        // the output directly, without depending on a separate supertype
        // declaration in rules.yaml. Self-documenting on the slot.
        ReturnsKind = "html-encoded,text",
        ReturnsDescription = "Resolves to the HTML-encoded string")]
    public class HtmlEncode : ISlot
    {
        /// <summary>
        /// Implementation of slot.
        /// </summary>
        /// <param name="signaler">Signaler used to raise signal.</param>
        /// <param name="input">Arguments to your slot.</param>
        public void Signal(ISignaler signaler, Node input)
        {
            input.Value = WebUtility.HtmlEncode(input.GetEx<string>());
        }
    }
}
