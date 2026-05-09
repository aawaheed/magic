/*
 * Magic Cloud, copyright (c) 2023 Thomas Hansen. See the attached LICENSE file for details. For license inquiries you can send an email to thomas@ainiro.io
 */

using magic.node;
using magic.signals.contracts;

namespace magic.lambda.branching
{
    /// <summary>
    /// [if] slot, allowing you to branch in your code execution according to some condition.
    /// </summary>
    [Slot(
        Name = "if",
        Description = "Evaluates a conditional branch",
        ValueType = "expression",
        ValueDescription = "Condition expression when using RHS form",
        ValueRequired = false,
        ValueMode = SlotValueMode.Expression,
        ReturnsMode = SlotReturnsMode.Value,
        ReturnsType = "bool",
        ReturnsDescription = "Resolves to true if the if condition matched and its branch was evaluated")]
    public class If : ISlot
    {
        /// <summary>
        /// Implementation of signal
        /// </summary>
        /// <param name="signaler">Signaler used to signal</param>
        /// <param name="input">Parameters passed from signaler</param>
        /// <returns>An awaitable task.</returns>
        public void Signal(ISignaler signaler, Node input)
        {
            // Checking if we should evaluate lambda object.
            if (!Common.ConditionIsTrue(signaler, input))
            {
                // Result of condition yields false.
                input.Value = false;
                return;
            }

            // Result of condition yields true. ORDER COUNTS!
            signaler.Signal("eval", Common.GetLambda(input));
            input.Value = true;
        }
    }
}
