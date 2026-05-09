/*
 * Magic Cloud, copyright (c) 2023 Thomas Hansen. See the attached LICENSE file for details. For license inquiries you can send an email to thomas@ainiro.io
 */

using System;
using magic.node;
using magic.node.extensions;
using magic.signals.contracts;

namespace magic.lambda.dates
{
    /// <summary>
    /// [time.total-milliseconds] slot, returning how many milliseconds time object represents.
    /// </summary>
    [Slot(
        Name = "time.total-milliseconds",
        Description = "Returns the total milliseconds for a TimeSpan value",
        ValueType = "TimeSpan",
        ValueDescription = "Time span to measure",
        ValueRequired = true,
        ValueMode = SlotValueMode.ValueOrExpression,
        ReturnsMode = SlotReturnsMode.Value,
        ReturnsType = "double",
        ReturnsDescription = "Returns the total number of milliseconds in the supplied time span")]
    public class TimeTotalMilliseconds : ISlot
    {
        /// <summary>
        /// Implementation of signal
        /// </summary>
        /// <param name="signaler">Signaler used to signal</param>
        /// <param name="input">Parameters passed from signaler</param>
        public void Signal(ISignaler signaler, Node input)
        {
            input.Value = input.GetEx<TimeSpan>().TotalMilliseconds;
        }
    }
}
