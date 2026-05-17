/*
 * Magic Cloud, copyright (c) 2023 Thomas Hansen. See the attached LICENSE file for details. For license inquiries you can send an email to thomas@ainiro.io
 */

using System.Linq;
using magic.node;
using magic.node.extensions;
using magic.signals.contracts;

namespace magic.lambda.source
{
    /// <summary>
    /// [get-value] slot that will return the value of the node found by evaluating an expression.
    /// </summary>
    [Slot(
        Name = "get-value",
        Description = "Returns the value of the first matching node",
        ValueType = "expression",
        // `single-object` — reads the .Value of exactly one node via
        // GetEx<object>(), which does single-node resolution. `node-list`
        // would advertise a container shape the slot can't actually consume;
        // `single-object` is the structural dual matching the runtime
        // contract. Reinforced by `ValueExpressionResolution.SingleNode`.
        ValueKind = "single-object",
        ValueDescription = "Expression selecting the node whose value should be retrieved",
        ValueRequired = true,
        ValueMode = SlotValueMode.Expression,
        ReturnsMode = SlotReturnsMode.Value,
        ReturnsType = "object",
        ReturnsKind = "value",
        ReturnsDescription = "Resolves to the value of the first matching node",
        ValueExpressionResolution = SlotValueExpressionResolution.SingleNode)]
    public class GetValue : ISlot
    {
        /// <summary>
        /// Implementation of signal
        /// </summary>
        /// <param name="signaler">Signaler used to signal</param>
        /// <param name="input">Parameters passed from signaler</param>
        public void Signal(ISignaler signaler, Node input)
        {
            input.Value = input.GetEx<object>();
        }
    }
}
