/*
 * Magic Cloud, copyright (c) 2023 Thomas Hansen. See the attached LICENSE file for details. For license inquiries you can send an email to thomas@ainiro.io
 */

using System.Linq;
using System.Globalization;
using magic.node;
using magic.node.extensions;
using magic.signals.contracts;

namespace magic.lambda.change
{
    /// <summary>
    /// [format] slot allowing you to format some value according to some pattern.
    /// </summary>
    [Slot(
        Name = "format",
        Description = "Formats a value using a .NET format string and optional culture; useful for currencies, dates, and number rendering",
        // `scalar` — the runtime calls `string.Format(culture, pattern,
        // value)` which accepts ANY object as the format target (bool /
        // int / DateTime / double / string / Guid / TimeSpan / …). The
        // previous tag was `formattable-value`, a universal noise label
        // every scalar producer used to self-declare; the synthesizer
        // matcher (`SelectKindMatches`/`IsScalarTipType`) instead does
        // a structural check: a producer with non-`lambda` / non-`Node[]`
        // / non-`node-list` tip type IS a scalar source. Renamed from
        // `formattable-value` to `scalar` so the consumer-side intent is
        // legible ("I want a scalar") rather than semantically empty.
        ValueKind = "scalar",
        ValueDescription = "Value to format",
        ValueRequired = true,
        ValueMode = SlotValueMode.ValueOrExpression,
        ReturnsMode = SlotReturnsMode.Value,
        // `text` only — the runtime returns `string.Format(...)`, which IS
        // text. The previous `formatted-text` narrowing existed as a
        // catalog tag but no consumer asks for it specifically, so it
        // adds no wiring signal. Dropping per user audit feedback. The
        // `formatted-text:` catalog in values.yaml becomes orphaned but
        // harmless — no code path consults it after this change.
        ReturnsKind = "text",
        ReturnsDescription = "Resolves to the formatted string",
        SignatureType = typeof(global::magic.lambda.signatures.FormatSignature))]
    public class Format : ISlot
    {
        /// <summary>
        /// Implementation of signal
        /// </summary>
        /// <param name="signaler">Signaler used to signal</param>
        /// <param name="input">Parameters passed from signaler</param>
        public void Signal(ISignaler signaler, Node input)
        {
            var value = input.GetEx<object>();
            var pattern = input.Children.First(x => x.Name == "pattern").GetEx<string>();
            var culture = CultureInfo.InvariantCulture;
            var cultureNode = input.Children.FirstOrDefault(x => x.Name == "culture");
            if (cultureNode != null)
                culture = new CultureInfo(cultureNode.GetEx<string>());
            input.Clear();
            input.Value = string.Format(culture, pattern, value);
        }
    }
}
