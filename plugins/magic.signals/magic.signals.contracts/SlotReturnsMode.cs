/*
 * Magic Cloud, copyright (c) 2023 Thomas Hansen. See the attached LICENSE file for details. For license inquiries you can send an email to thomas@ainiro.io
 */

namespace magic.signals.contracts
{
    /// <summary>
    /// Indicates the primary documented return shape of a slot.
    /// </summary>
    public enum SlotReturnsMode
    {
        None,
        Value,
        Lambda,
        Both,
    }
}
