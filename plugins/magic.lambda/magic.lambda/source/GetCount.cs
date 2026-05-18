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
    /// [get-count] slot that will return the count of nodes found for an expression.
    /// </summary>
    [Slot(
        Name = "get-count",
        Description = "Returns the number of matching nodes",
        ValueType = "expression",
        // `node-list` ONLY — runtime accepts any cardinality, BUT counting
        // a single-object expression always yields 1, which carries no
        // information for training data. The slot's semantic purpose is
        // multi-match counting; single-object inputs produce trivially
        // useless snippets like `get-count:x:@.someScalar` → 1. Different
        // from `[exists]` / `[null]` / `[not-null]` which DO carry meaning
        // on single-node inputs (existence/null checks of a single value
        // are common idioms). The attribute reflects semantic intent, not
        // runtime tolerance.
        ValueKind = "node-list",
        ValueDescription = "Expression selecting the nodes to count",
        ValueRequired = true,
        ValueMode = SlotValueMode.Expression,
        ReturnsMode = SlotReturnsMode.Value,
        ReturnsType = "int",
        ReturnsKind = "number",
        ReturnsDescription = "Resolves to the number of nodes matched by the expression")]
    public class GetCount : ISlot
    {
        /// <summary>
        /// Implementation of signal
        /// </summary>
        /// <param name="signaler">Signaler used to signal</param>
        /// <param name="input">Parameters passed from signaler</param>
        public void Signal(ISignaler signaler, Node input)
        {
            if (input.Value == null)
                throw new HyperlambdaException("No expression source provided for [count]");

            var src = input.Evaluate();
            input.Value = src.Count();
        }
    }
}
