/*
 * Magic Cloud, copyright (c) 2023 Thomas Hansen. See the attached LICENSE file for details. For license inquiries you can send an email to thomas@ainiro.io
 */

using System.Collections.Generic;
using magic.signals.contracts;

namespace magic.lambda.strings.signatures
{
    /// <summary>
    /// Child signatures for string slots.
    /// </summary>
    public abstract class StringSignature : ISlotSignature
    {
        /// <inheritdoc />
        public virtual IEnumerable<SlotChild> Children => new SlotChild[0];

        /// <inheritdoc />
        public virtual IEnumerable<SlotConstraint> Constraints => new SlotConstraint[0];

        protected static SlotChild Arg(
            string name,
            string type,
            string description,
            bool required = true,
            SlotChildCardinality cardinality = SlotChildCardinality.ExactlyOne)
        {
            return new SlotChild
            {
                Name = name,
                Type = type,
                Description = description,
                Required = required,
                Mode = SlotChildMode.ExecutableLambda,
                Cardinality = cardinality,
                Role = SlotChildRole.SourceExpression,
                Evaluation = SlotChildEvaluation.EvalSelf,
                Projection = SlotChildProjection.Value,
            };
        }
    }

    /// <summary>
    /// Signature for replace slots taking a search value and replacement value.
    /// </summary>
    public class ReplaceSignature : StringSignature
    {
        /// <inheritdoc />
        public override IEnumerable<SlotChild> Children => new[]
        {
            Arg(".", "string", "Text or pattern to find"),
            Arg(".", "string", "Replacement text", false, SlotChildCardinality.ZeroOrOne),
        };
    }

    /// <summary>
    /// Signature for replace slots requiring exactly two arguments.
    /// </summary>
    public class ReplaceTwoArgsSignature : StringSignature
    {
        /// <inheritdoc />
        public override IEnumerable<SlotChild> Children => new[]
        {
            Arg(".", "string", "Text or pattern to find"),
            Arg(".", "string", "Replacement text"),
        };
    }

    /// <summary>
    /// Signature for [strings.substring].
    /// </summary>
    public class SubstringSignature : StringSignature
    {
        /// <inheritdoc />
        public override IEnumerable<SlotChild> Children => new[]
        {
            Arg(".", "int", "Start index"),
            Arg(".", "int", "Optional length", false, SlotChildCardinality.ZeroOrOne),
        };
    }

    /// <summary>
    /// Signature for [strings.split].
    /// </summary>
    public class SplitSignature : StringSignature
    {
        /// <inheritdoc />
        public override IEnumerable<SlotChild> Children => new[]
        {
            Arg(".", "string", "Separator to split on", true, SlotChildCardinality.OneOrMore),
        };
    }

    /// <summary>
    /// Signature for [strings.join].
    /// </summary>
    public class JoinSignature : StringSignature
    {
        /// <inheritdoc />
        public override IEnumerable<SlotChild> Children => new[]
        {
            Arg(".", "string", "Separator to place between joined values", false, SlotChildCardinality.ZeroOrOne),
        };
    }

    /// <summary>
    /// Signature for string predicates taking a single evaluated argument.
    /// </summary>
    public class SingleStringArgumentSignature : StringSignature
    {
        /// <inheritdoc />
        public override IEnumerable<SlotChild> Children => new[]
        {
            Arg(".", "string", "String argument"),
        };
    }

    /// <summary>
    /// Signature for string slots taking an optional character set argument.
    /// </summary>
    public class OptionalStringArgumentSignature : StringSignature
    {
        /// <inheritdoc />
        public override IEnumerable<SlotChild> Children => new[]
        {
            Arg(".", "string", "Optional string argument", false, SlotChildCardinality.ZeroOrOne),
        };
    }

    /// <summary>
    /// Signature for [strings.concat].
    /// </summary>
    public class ConcatSignature : StringSignature
    {
        /// <inheritdoc />
        public override IEnumerable<SlotChild> Children => new[]
        {
            Arg(".", "string", "Text segment to concatenate", false, SlotChildCardinality.ZeroOrMore),
        };

        /// <inheritdoc />
        public override IEnumerable<SlotConstraint> Constraints => new[]
        {
            new SlotConstraint
            {
                Kind = SlotConstraintKind.ExactlyOneOf,
                Description = "Provide either expression input or child text segments",
                Values = { "input", "." },
            },
        };
    }

    /// <summary>
    /// Signature for [strings.mixin].
    /// </summary>
    public class StringMixinSignature : StringSignature
    {
        /// <inheritdoc />
        public override IEnumerable<SlotChild> Children => new[]
        {
            new SlotChild
            {
                Name = "strip",
                Type = "bool",
                Description = "Whether to strip embedded Hyperlambda instead of executing it",
                Required = false,
                DefaultValue = "false",
                Mode = SlotChildMode.ValueOrExpression,
                Cardinality = SlotChildCardinality.ZeroOrOne,
                Role = SlotChildRole.Option,
                Projection = SlotChildProjection.Value,
            },
            new SlotChild
            {
                Name = "*",
                Type = "object",
                Description = "Argument passed to embedded Hyperlambda snippets invoked from the template",
                Required = false,
                Mode = SlotChildMode.ValueOrExpression,
                Cardinality = SlotChildCardinality.ZeroOrMore,
                Role = SlotChildRole.Arguments,
                Projection = SlotChildProjection.ArgumentBag,
            },
        };
    }

    /// <summary>
    /// Signature for [strings.builder].
    /// </summary>
    public class StringBuilderSignature : StringSignature
    {
        /// <inheritdoc />
        public override IEnumerable<SlotChild> Children => new[]
        {
            new SlotChild
            {
                Name = "*",
                Type = "lambda",
                Description = "Executable child slot evaluated while the StringBuilder is scoped; use [strings.builder.append] to append text",
                Required = false,
                Mode = SlotChildMode.ExecutableLambda,
                Cardinality = SlotChildCardinality.ZeroOrMore,
                Role = SlotChildRole.ExecutableBody,
                Evaluation = SlotChildEvaluation.EvalSelf,
                Projection = SlotChildProjection.Self,
            },
        };
    }
}
