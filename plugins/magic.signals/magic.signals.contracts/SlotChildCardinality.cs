/*
 * Magic Cloud, copyright (c) 2023 Thomas Hansen. See the attached LICENSE file for details. For license inquiries you can send an email to thomas@ainiro.io
 */

namespace magic.signals.contracts
{
    /// <summary>
    /// Describes how many times a documented child node may occur.
    /// </summary>
    public enum SlotChildCardinality
    {
        ZeroOrOne,
        ExactlyOne,
        ExactlyTwo,
        TwoOrMore,
        ZeroOrMore,
        OneOrMore,
    }
}
