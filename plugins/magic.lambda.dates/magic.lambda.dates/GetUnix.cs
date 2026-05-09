/*
 * Magic Cloud, copyright (c) 2023 Thomas Hansen. See the attached LICENSE file for details. For license inquiries you can send an email to thomas@ainiro.io
 */

using System;
using magic.node;
using magic.signals.contracts;

namespace magic.lambda.dates
{
    /// <summary>
    /// [date.unix] slot, allowing you to retrieve server time in UTC timezone.
    /// </summary>
    [Slot(
        Name = "date.unix",
        Description = "Converts a DateTime value into a Unix timestamp",
        ValueType = "DateTime",
        ValueDescription = "Date value to convert",
        ValueRequired = true,
        ValueMode = SlotValueMode.ValueOrExpression)]
    public class Unix : ISlot
    {
        /// <summary>
        /// Implementation of signal
        /// </summary>
        /// <param name="signaler">Signaler used to signal</param>
        /// <param name="input">Parameters passed from signaler</param>
        public void Signal(ISignaler signaler, Node input)
        {
            input.Value = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        }
    }
}
