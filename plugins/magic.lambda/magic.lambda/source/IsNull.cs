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
    /// [null] slot returning true if whatever expression it's given actually yields a result.
    /// </summary>
    [Slot(
        Name = "null",
        Description = "Returns true if the specified node or expression is null",
        ValueType = "expression",
        // Multi-tag — `[null]`/`[not-null]` scan via `FirstOrDefault(x =>
        // x.Value != null)`, which works on ANY cardinality. Both a single-
        // node source ("is this one null?") and a multi-node source ("are
        // any of these non-null?") are valid. `node-list` alone lied —
        // single-object sources never matched. Same pattern as `[exists]`/
        // `[not-exists]`/`[get-count]`.
        ValueKind = "node-list,single-object",
        ValueDescription = "Expression selecting the value to test for null",
        ValueRequired = true,
        ValueMode = SlotValueMode.Expression,
        ReturnsMode = SlotReturnsMode.Value,
        ReturnsType = "bool",
        ReturnsKind = "boolean,formattable-value",
        ReturnsDescription = "Returns true if the expression resolves to a null value")]
    [Slot(
        Name = "not-null",
        Description = "Returns true if the specified node or expression is not null",
        ValueType = "expression",
        // Multi-tag — `[null]`/`[not-null]` scan via `FirstOrDefault(x =>
        // x.Value != null)`, which works on ANY cardinality. Both a single-
        // node source ("is this one null?") and a multi-node source ("are
        // any of these non-null?") are valid. `node-list` alone lied —
        // single-object sources never matched. Same pattern as `[exists]`/
        // `[not-exists]`/`[get-count]`.
        ValueKind = "node-list,single-object",
        ValueDescription = "Expression selecting the value to test for null",
        ValueRequired = true,
        ValueMode = SlotValueMode.Expression,
        ReturnsMode = SlotReturnsMode.Value,
        ReturnsType = "bool",
        ReturnsKind = "boolean,formattable-value",
        ReturnsDescription = "Returns true if the expression resolves to a non-null value")]
    public class IsNull : ISlot
    {
        /// <summary>
        /// Implementation of signal
        /// </summary>
        /// <param name="signaler">Signaler used to signal</param>
        /// <param name="input">Parameters passed from signaler</param>
        public void Signal(ISignaler signaler, Node input)
        {
            var result = input.Evaluate().FirstOrDefault(x => x.Value != null);
            input.Value = input.Name == "null" ? result == null : result != null;
        }
    }
}
