/*
 * Magic Cloud, copyright (c) 2023 Thomas Hansen. See the attached LICENSE file for details. For license inquiries you can send an email to thomas@ainiro.io
 */

namespace magic.signals.contracts
{
    /// <summary>
    /// Describes if and how a documented child node is evaluated before use.
    /// </summary>
    public enum SlotChildEvaluation
    {
        None,
        EvalSelf,
        EvalBlock,
        UnwrapDescendants,
        SerializeLambda,
    }
}
