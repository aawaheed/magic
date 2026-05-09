/*
 * Magic Cloud, copyright (c) 2023 Thomas Hansen. See the attached LICENSE file for details. For license inquiries you can send an email to thomas@ainiro.io
 */

using magic.node;
using magic.node.extensions;
using magic.signals.contracts;

namespace magic.lambda.strings.misc
{
    /// <summary>
    /// [strings.length] slot that returns the length of its specified string argument.
    /// </summary>
    [Slot(
        Name = "strings.length",
        Description = "Returns the length of a string",
        ValueType = "string",
        ValueDescription = "Text to measure",
        ValueRequired = true,
        ValueMode = SlotValueMode.ValueOrExpression,
        ReturnsMode = SlotReturnsMode.Value,
        ReturnsType = "int",
        ReturnsDescription = "Resolves to the number of characters in the string")]
    public class Length : ISlot
    {
        /// <summary>
        /// Implementation of slot.
        /// </summary>
        /// <param name="signaler">Signaler used to raise signal.</param>
        /// <param name="input">Arguments to your slot.</param>
        public void Signal(ISignaler signaler, Node input)
        {
            input.Value = input.GetEx<string>().Length;
        }
    }
}
