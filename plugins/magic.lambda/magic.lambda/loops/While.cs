/*
 * Magic Cloud, copyright (c) 2023 Thomas Hansen. See the attached LICENSE file for details. For license inquiries you can send an email to thomas@ainiro.io
 */

using System.Linq;
using magic.node;
using magic.node.extensions;
using magic.lambda.branching;
using magic.lambda.contracts;
using magic.signals.contracts;

namespace magic.lambda.loops
{
    /// <summary>
    /// [while] slot that will evaluate its lambda object as long as its condition is true.
    /// </summary>
    // [while] returns NOTHING to its caller. The runtime does set
    // `input.Value = false` at the end (line 77) — but that's the same
    // internal `if`/`else-if` chaining protocol used by [if]/[else]/
    // [else-if]; it isn't a real value-output. [while] DOES NOT create
    // a `slots.result` scope — it only PEEKS at one set by an outer
    // caller (`[signal]`, `[invoke]`, …) to detect termination via
    // [return]. So result-Value / result-Children are never populated
    // by [while] itself. Previously declared `ReturnsMode=Both` with
    // `ReturnsKind="lambda-result"` — flat overclaim.
    [Slot(
        Name = "while",
        Description = "Repeats execution while a condition is true",
        ReturnsMode = SlotReturnsMode.None,
        ProvidesScope = "while",
        SignatureType = typeof(global::magic.lambda.signatures.ConditionalBlockSignature))]
    public class While : ISlot
    {
        readonly LambdaSettings _settings;

        /// <summary>
        /// Creates an instance of your slot.
        /// </summary>
        /// <param name="settings">Configuration settings.</param>
        public While(LambdaSettings settings)
        {
            _settings = settings;
        }

        /// <summary>
        /// Implementation of signal
        /// </summary>
        /// <param name="signaler">Signaler used to signal</param>
        /// <param name="input">Parameters passed from signaler</param>
        /// <returns>An awaitable task.</returns>
        public void Signal(ISignaler signaler, Node input)
        {
            // Storing termination node, to check if we should terminate early for some reasons.
            var terminate = signaler.Peek<Node>("slots.result");

            // Making sure we don't enter an infinite loop.
            int iterations = 0;
            int maxIterations = _settings.MaxWhileIterations;

            // Cloning entire node such that we can reset it after execution.
            var clone = input.Clone();

            // Looping while condition is true.
            while (Common.ConditionIsTrue(signaler, input))
            {
                // Making sure we don't exceed maximum number of iterations.
                if (iterations++ >= maxIterations)
                    throw new HyperlambdaException($"Your [while] loop exceeded the maximum number of iterations, which is {maxIterations}. Refactor your Hyperlambda, or increase your configuration setting.");

                // Executing lambda object associated with [while].
                signaler.Signal("eval", Common.GetLambda(input));

                // Checking if execution for some reasons was terminated.
                if (terminate != null && (terminate.Value != null || terminate.Children.Any()))
                    return;

                // Resetting lambda object back to its original state for our next iteration.
                input.Clear();
                input.AddRange(clone.Children.Select(x => x.Clone()));
            }

            // To make sure we're compatible with [if] and [else-if] as much as possible.
            input.Value = false;
        }
    }
}
