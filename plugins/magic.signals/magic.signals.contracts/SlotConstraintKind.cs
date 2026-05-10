/*
 * Magic Cloud, copyright (c) 2023 Thomas Hansen. See the attached LICENSE file for details. For license inquiries you can send an email to thomas@ainiro.io
 */

namespace magic.signals.contracts
{
    /// <summary>
    /// Kind of structural constraint applying to a slot or child signature.
    /// </summary>
    public enum SlotConstraintKind
    {
        None,
        ParentMustBe,
        PreviousSiblingMustBeOneOf,
        NextSiblingMayBeOneOf,
        OnlyChildren,
        ExactlyOneOf,
        AtLeastOneOf,
        AtMostOneOf,
        Requires,
        Excludes,
    }
}
