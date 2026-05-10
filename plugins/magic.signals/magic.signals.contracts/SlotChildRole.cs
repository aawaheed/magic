/*
 * Magic Cloud, copyright (c) 2023 Thomas Hansen. See the attached LICENSE file for details. For license inquiries you can send an email to thomas@ainiro.io
 */

namespace magic.signals.contracts
{
    /// <summary>
    /// Semantic role a documented child node plays in a slot invocation.
    /// </summary>
    public enum SlotChildRole
    {
        None,
        Option,
        Condition,
        Operand,
        ExecutableBody,
        LambdaBlock,
        SourceExpression,
        SourceContainer,
        Arguments,
        Payload,
        StructuredObject,
        DynamicMap,
        Callback,
        Branch,
    }
}
