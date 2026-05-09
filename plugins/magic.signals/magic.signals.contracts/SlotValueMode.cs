/*
 * Magic Cloud, copyright (c) 2023 Thomas Hansen. See the attached LICENSE file for details. For license inquiries you can send an email to thomas@ainiro.io
 */

namespace magic.signals.contracts
{
    /// <summary>
    /// Describes how a slot's RHS value argument should be interpreted.
    /// </summary>
    public enum SlotValueMode
    {
        /// <summary>
        /// Slot does not document any RHS value argument.
        /// </summary>
        None,

        /// <summary>
        /// RHS should be interpreted as a literal value.
        /// </summary>
        Value,

        /// <summary>
        /// RHS should be interpreted as an expression.
        /// </summary>
        Expression,

        /// <summary>
        /// RHS may be either a literal value or an expression.
        /// </summary>
        ValueOrExpression,
    }
}
