/*
 * Magic Cloud, copyright (c) 2023 Thomas Hansen. See the attached LICENSE file for details. For license inquiries you can send an email to thomas@ainiro.io
 */

using System.Linq;
using System.Threading.Tasks;
using magic.node;
using magic.node.extensions;
using magic.signals.contracts;

namespace magic.lambda.strings.concat
{
    /// <summary>
    /// [strings.concat] slot for concatenating two or more strings together to become one.
    /// </summary>
    [Slot(
        Name = "strings.concat",
        Description = "Concatenates strings",
        ValueType = "lambda",
        // `node-list` added — structural truth: the input is a list of
        // nodes whose values are strings. Symmetric with the producer-side
        // tagging on `strings.split`/`vocabulary`/etc. — consumers and
        // producers use the same kind labels (set intersection decides
        // matches).
        ValueKind = "string-list,node-list",
        ValueDescription = "Expression yielding the text segments to concatenate when not supplied as child nodes",
        ValueRequired = false,
        ValueMode = SlotValueMode.Expression,
        ReturnsMode = SlotReturnsMode.Value,
        ReturnsType = "string",
        ReturnsKind = "text,formattable-value",
        ReturnsDescription = "Resolves to the concatenated string",
        SignatureType = typeof(global::magic.lambda.strings.signatures.ConcatSignature))]
    public class Concat : ISlotAsync
    {
        /// <summary>
        /// Implementation of slot.
        /// </summary>
        /// <param name="signaler">Signaler used to raise the signal.</param>
        /// <param name="input">Arguments to slot.</param>
        /// <returns>An awaitable task.</returns>
        public async Task SignalAsync(ISignaler signaler, Node input)
        {
            if (input.Children.Any())
            {
                await signaler.SignalAsync("eval", input);
                input.Value = string.Join("", input.Children.Select(x => x.GetEx<string>()));
            }
            else
            {
                var values = input.Evaluate();
                input.Value = string.Join("", values.Select(x => x.GetEx<string>()));
            }
            input.Clear();
        }
    }
}
