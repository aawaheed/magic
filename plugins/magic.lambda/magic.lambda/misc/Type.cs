/*
 * Magic Cloud, copyright (c) 2023 Thomas Hansen. See the attached LICENSE file for details. For license inquiries you can send an email to thomas@ainiro.io
 */

using System.Linq;
using magic.node;
using magic.node.extensions;
using magic.signals.contracts;

namespace magic.lambda.misc
{
    /// <summary>
    /// [type] slot allowing you to retrieve Hyperlambda type information for some specified value.
    /// </summary>
    [Slot(
        Name = "type",
        Description = "Returns the CLR type name of a value",
        ValueType = "expression",
        // `single-object` is the structural-kind dual of `node-list`: one
        // value-bearing node, any value type. The runtime contract here is
        // `.Single().Value` — exactly one node, read its value — which is
        // semantically incompatible with `node-list` (a container kind).
        // Combined with `ValueExpressionResolution.SingleNode`, the static
        // input shape (kind) and the runtime arity contract reinforce each
        // other without overlapping. Same pattern as `[invoke]`'s
        // `lambda-object` + SingleNode.
        ValueKind = "single-object",
        ValueDescription = "Expression selecting the value whose CLR type should be inspected",
        ValueRequired = true,
        ValueMode = SlotValueMode.Expression,
        ReturnsMode = SlotReturnsMode.Value,
        ReturnsType = "string",
        ReturnsKind = "type-name,text",
        ReturnsDescription = "Resolves to the runtime type name of the first matching value",
        ValueExpressionResolution = SlotValueExpressionResolution.SingleNode)]
    public class Type : ISlot
    {
        /// <summary>
        /// Implementation of signal
        /// </summary>
        /// <param name="signaler">Signaler used to signal</param>
        /// <param name="input">Parameters passed from signaler</param>
        public void Signal(ISignaler signaler, Node input)
        {
            var ex = input.Value as Expression ?? throw new HyperlambdaException("No expression given to [type]");
            var value = ex.Evaluate(input).Single().Value;
            var result = Converter.ToString(value);
            input.Value = result.Item1;
        }
    }
}
