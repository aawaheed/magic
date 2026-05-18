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
        // `string-list,node-list` — runtime calls `.GetEx<string>()` on
        // each evaluated node, which REQUIRES the nodes to carry STRING
        // VALUES at their .Value position. A flat list of string-valued
        // nodes satisfies that; a generic `lambda-tree` (json-tree /
        // yaml-tree / html-tree / etc.) has heterogeneous nested values
        // and would produce garbage when ToString'd. Dropped the over-
        // expanded `lambda-tree` parent (added by the type-aware
        // expander; should have been excluded by careful audit).
        ValueKind = "string-list,node-list",
        ValueDescription = "Expression yielding the text segments to concatenate when not supplied as child nodes",
        ValueRequired = false,
        ValueMode = SlotValueMode.Expression,
        ReturnsMode = SlotReturnsMode.Value,
        ReturnsType = "string",
        ReturnsKind = "text",
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
