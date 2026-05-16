/*
 * Magic Cloud, copyright (c) 2023 Thomas Hansen. See the attached LICENSE file for details. For license inquiries you can send an email to thomas@ainiro.io
 */

using System.Collections.Generic;
using magic.signals.contracts;

namespace magic.lambda.signatures
{
    /// <summary>
    /// Child signatures for core Hyperlambda slots.
    /// </summary>
    public abstract class LambdaSignature : ISlotSignature
    {
        /// <inheritdoc />
        public virtual IEnumerable<SlotChild> Children => new SlotChild[0];

        /// <inheritdoc />
        public virtual IEnumerable<SlotConstraint> Constraints => new SlotConstraint[0];

        internal static SlotChild ExecutableBody(
            string description,
            SlotChildCardinality cardinality = SlotChildCardinality.ZeroOrMore)
        {
            return new SlotChild
            {
                Name = "*",
                Type = "lambda",
                Description = description,
                Required = cardinality == SlotChildCardinality.ExactlyOne || cardinality == SlotChildCardinality.OneOrMore,
                Mode = SlotChildMode.ExecutableLambda,
                Cardinality = cardinality,
                Role = SlotChildRole.ExecutableBody,
                Evaluation = SlotChildEvaluation.EvalSelf,
                Projection = SlotChildProjection.Self,
            };
        }

        internal static SlotChild LambdaBlock(
            bool required = true,
            string description = "Executable lambda block")
        {
            return new SlotChild
            {
                Name = ".lambda",
                Type = "lambda",
                Description = description,
                Required = required,
                Mode = SlotChildMode.ExecutableLambda,
                Cardinality = required ? SlotChildCardinality.ExactlyOne : SlotChildCardinality.ZeroOrOne,
                Role = SlotChildRole.LambdaBlock,
                Evaluation = SlotChildEvaluation.EvalBlock,
                Projection = SlotChildProjection.Self,
            };
        }

        internal static SlotChild Condition()
        {
            return new SlotChild
            {
                Name = "*",
                Type = "lambda",
                Description = "Condition node evaluated for truthiness",
                Required = true,
                Mode = SlotChildMode.ExecutableLambda,
                Cardinality = SlotChildCardinality.ExactlyOne,
                Role = SlotChildRole.Condition,
                Evaluation = SlotChildEvaluation.EvalSelf,
                Projection = SlotChildProjection.Value,
            };
        }

        internal static SlotConstraint PreviousSibling(params string[] names)
        {
            var result = new SlotConstraint
            {
                Kind = SlotConstraintKind.PreviousSiblingMustBeOneOf,
                Description = "Previous sibling must be one of the listed slot names",
            };
            result.Values.AddRange(names);
            return result;
        }

        internal static SlotConstraint Parent(string name)
        {
            return new SlotConstraint
            {
                Kind = SlotConstraintKind.ParentMustBe,
                Description = "Parent node must have the listed slot name",
                Values = { name },
            };
        }

        internal static SlotConstraint OnlyChildren(params string[] names)
        {
            var result = new SlotConstraint
            {
                Kind = SlotConstraintKind.OnlyChildren,
                Description = "Only the listed child names are accepted",
            };
            result.Values.AddRange(names);
            return result;
        }
    }

    /// <summary>
    /// Signature for slots requiring a condition and explicit [.lambda] block.
    /// </summary>
    public class ConditionalBlockSignature : LambdaSignature
    {
        /// <inheritdoc />
        public override IEnumerable<SlotChild> Children => new[]
        {
            Condition(),
            LambdaBlock(),
        };
    }

    /// <summary>
    /// Signature for [else-if].
    /// </summary>
    public class ElseIfSignature : ConditionalBlockSignature
    {
        /// <inheritdoc />
        public override IEnumerable<SlotConstraint> Constraints => new[]
        {
            PreviousSibling("if", "else-if"),
        };
    }

    /// <summary>
    /// Signature for comparison slots.
    /// </summary>
    public class ComparisonSignature : LambdaSignature
    {
        /// <inheritdoc />
        public override IEnumerable<SlotChild> Children => new[]
        {
            new SlotChild
            {
                Name = "*",
                Type = "object",
                Description = "Operand evaluated before comparison",
                Required = true,
                Mode = SlotChildMode.ExecutableLambda,
                Cardinality = SlotChildCardinality.ExactlyTwo,
                Role = SlotChildRole.Operand,
                Evaluation = SlotChildEvaluation.EvalSelf,
                Projection = SlotChildProjection.Value,
            },
        };
    }

    /// <summary>
    /// Signature for [else].
    /// </summary>
    public class ElseSignature : LambdaSignature
    {
        /// <inheritdoc />
        public override IEnumerable<SlotChild> Children => new[]
        {
            ExecutableBody("Fallback branch body evaluated when previous conditions fail"),
        };

        /// <inheritdoc />
        public override IEnumerable<SlotConstraint> Constraints => new[]
        {
            PreviousSibling("if", "else-if"),
        };
    }

    /// <summary>
    /// Signature for [switch].
    /// </summary>
    public class SwitchSignature : LambdaSignature
    {
        /// <inheritdoc />
        public override IEnumerable<SlotChild> Children => new[]
        {
            new SlotChild
            {
                Name = "case",
                Type = "object",
                Kind = "switch-value",
                Description = "Case branch matching the switch value",
                Required = true,
                Mode = SlotChildMode.ValueOrExpression,
                Cardinality = SlotChildCardinality.OneOrMore,
                Role = SlotChildRole.Branch,
                Evaluation = SlotChildEvaluation.EvalSelf,
                Projection = SlotChildProjection.Self,
                Children =
                {
                    ExecutableBody("Branch body executed when the case matches", SlotChildCardinality.OneOrMore),
                },
            },
            new SlotChild
            {
                Name = "default",
                Type = "lambda",
                Description = "Fallback branch when no case matches",
                Required = false,
                Mode = SlotChildMode.ExecutableLambda,
                Cardinality = SlotChildCardinality.ZeroOrOne,
                Role = SlotChildRole.Branch,
                Evaluation = SlotChildEvaluation.EvalSelf,
                Projection = SlotChildProjection.Self,
                Children =
                {
                    ExecutableBody("Fallback branch body", SlotChildCardinality.OneOrMore),
                },
            },
        };

        /// <inheritdoc />
        public override IEnumerable<SlotConstraint> Constraints => new[]
        {
            OnlyChildren("case", "default"),
        };
    }

    /// <summary>
    /// Signature for [case].
    /// </summary>
    public class CaseSignature : LambdaSignature
    {
        /// <inheritdoc />
        public override IEnumerable<SlotChild> Children => new[]
        {
            ExecutableBody("Case branch body executed by the parent [switch]", SlotChildCardinality.OneOrMore),
        };

        /// <inheritdoc />
        public override IEnumerable<SlotConstraint> Constraints => new[]
        {
            Parent("switch"),
        };
    }

    /// <summary>
    /// Signature for [default].
    /// </summary>
    public class DefaultSignature : LambdaSignature
    {
        /// <inheritdoc />
        public override IEnumerable<SlotChild> Children => new[]
        {
            ExecutableBody("Default branch body executed by the parent [switch]", SlotChildCardinality.OneOrMore),
        };

        /// <inheritdoc />
        public override IEnumerable<SlotConstraint> Constraints => new[]
        {
            Parent("switch"),
        };
    }

    /// <summary>
    /// Signature for [eval].
    /// </summary>
    public class EvalSignature : LambdaSignature
    {
        /// <inheritdoc />
        public override IEnumerable<SlotChild> Children => new[]
        {
            ExecutableBody("Executable child slot evaluated in order"),
        };
    }

    /// <summary>
    /// Signature for slots taking one executable boolean operand.
    /// </summary>
    public class SingleLogicalOperandSignature : LambdaSignature
    {
        /// <inheritdoc />
        public override IEnumerable<SlotChild> Children => new[]
        {
            ExecutableBody("Executable operand returning a boolean value", SlotChildCardinality.ExactlyOne),
        };
    }

    /// <summary>
    /// Signature for slots taking multiple executable boolean operands.
    /// </summary>
    public class MultipleLogicalOperandsSignature : LambdaSignature
    {
        /// <inheritdoc />
        public override IEnumerable<SlotChild> Children => new[]
        {
            ExecutableBody("Executable operand returning a boolean value", SlotChildCardinality.TwoOrMore),
        };
    }

    /// <summary>
    /// Signature for [invoke].
    /// </summary>
    public class InvokeSignature : LambdaSignature
    {
        /// <inheritdoc />
        public override IEnumerable<SlotChild> Children => new[]
        {
            new SlotChild
            {
                Name = "*",
                Type = "object",
                Description = "Argument passed to the invoked lambda through its [.arguments] node",
                Required = false,
                Mode = SlotChildMode.ValueOrExpression,
                Cardinality = SlotChildCardinality.ZeroOrMore,
                Role = SlotChildRole.Arguments,
                Projection = SlotChildProjection.ArgumentBag,
            },
        };
    }

    /// <summary>
    /// Signature for [whitelist].
    /// </summary>
    public class WhitelistSignature : LambdaSignature
    {
        /// <inheritdoc />
        public override IEnumerable<SlotChild> Children => new[]
        {
            new SlotChild
            {
                Name = "vocabulary",
                Type = "lambda",
                Description = "Allowed slot names for the restricted evaluation scope",
                Required = true,
                Mode = SlotChildMode.Value,
                Cardinality = SlotChildCardinality.ExactlyOne,
                Role = SlotChildRole.StructuredObject,
                Projection = SlotChildProjection.Children,
                Children =
                {
                    new SlotChild
                    {
                        Name = "*",
                        Type = "string",
                        Kind = "dynamic-slot-name",
                        Description = "Allowed slot name",
                        Required = true,
                        Mode = SlotChildMode.Value,
                        Cardinality = SlotChildCardinality.OneOrMore,
                        Role = SlotChildRole.DynamicMap,
                        Projection = SlotChildProjection.Value,
                    },
                },
            },
            LambdaBlock(),
        };
    }

    /// <summary>
    /// Signature for [context].
    /// </summary>
    public class ContextSignature : LambdaSignature
    {
        /// <inheritdoc />
        public override IEnumerable<SlotChild> Children => new[]
        {
            new SlotChild
            {
                Name = "value",
                Type = "object",
                Description = "Value stored in the named stack context",
                Required = true,
                Mode = SlotChildMode.ValueOrExpression,
                Cardinality = SlotChildCardinality.ExactlyOne,
                Role = SlotChildRole.Option,
                Projection = SlotChildProjection.Value,
            },
            LambdaBlock(description: "Body evaluated while the context value is scoped"),
        };
    }

    /// <summary>
    /// Signature for [apply].
    /// </summary>
    public class ApplySignature : LambdaSignature
    {
        /// <inheritdoc />
        public override IEnumerable<SlotChild> Children => new[]
        {
            new SlotChild
            {
                Name = "*",
                Type = "object",
                Description = "Template replacement node matched by name; its value and children replace placeholders named {name}",
                Required = false,
                Mode = SlotChildMode.Value,
                Cardinality = SlotChildCardinality.ZeroOrMore,
                Role = SlotChildRole.Arguments,
                Projection = SlotChildProjection.ArgumentBag,
            },
        };
    }

    /// <summary>
    /// Signature for [sort].
    /// </summary>
    public class SortSignature : LambdaSignature
    {
        /// <inheritdoc />
        public override IEnumerable<SlotChild> Children => new[]
        {
            ExecutableBody("Comparer body evaluated with [.lhs], [.rhs], and [.result] injected"),
        };
    }

    /// <summary>
    /// Signature for [compose].
    /// </summary>
    public class ComposeSignature : LambdaSignature
    {
        /// <inheritdoc />
        public override IEnumerable<SlotChild> Children => new[]
        {
            new SlotChild
            {
                Name = "*",
                Type = "string",
                Kind = "expression-segment",
                Description = "Expression segment evaluated and joined into the resulting expression",
                Required = true,
                Mode = SlotChildMode.ExecutableLambda,
                Cardinality = SlotChildCardinality.OneOrMore,
                Role = SlotChildRole.SourceExpression,
                Evaluation = SlotChildEvaluation.EvalSelf,
                Projection = SlotChildProjection.Value,
            },
        };
    }

    /// <summary>
    /// Signature for [convert].
    /// </summary>
    public class ConvertSignature : LambdaSignature
    {
        /// <inheritdoc />
        public override IEnumerable<SlotChild> Children => new[]
        {
            new SlotChild
            {
                Name = "type",
                Type = "string",
                Kind = "type-name",
                Description = "Target Hyperlambda type name",
                Required = true,
                Mode = SlotChildMode.ValueOrExpression,
                Cardinality = SlotChildCardinality.ExactlyOne,
                Role = SlotChildRole.Option,
                Projection = SlotChildProjection.Value,
            },
        };
    }

    /// <summary>
    /// Signature for [get-first-value].
    /// </summary>
    public class GetFirstValueSignature : LambdaSignature
    {
        /// <inheritdoc />
        public override IEnumerable<SlotChild> Children => new[]
        {
            new SlotChild
            {
                Name = "*",
                Type = "lambda",
                Description = "Candidate value source evaluated until the first non-null value is produced",
                Required = true,
                Mode = SlotChildMode.ExecutableLambda,
                Cardinality = SlotChildCardinality.OneOrMore,
                Role = SlotChildRole.Operand,
                Evaluation = SlotChildEvaluation.EvalSelf,
                Projection = SlotChildProjection.Value,
            },
        };
    }

    /// <summary>
    /// Signature for source containers such as [add] and insert slots.
    /// </summary>
    public class SourceContainerSignature : LambdaSignature
    {
        /// <inheritdoc />
        public override IEnumerable<SlotChild> Children => new[]
        {
            new SlotChild
            {
                Name = "*",
                Type = "lambda",
                Description = "Source container or node-producing slot evaluated before its child nodes are applied to the selected target location",
                Required = true,
                Mode = SlotChildMode.ExecutableLambda,
                Cardinality = SlotChildCardinality.OneOrMore,
                Role = SlotChildRole.SourceContainer,
                Evaluation = SlotChildEvaluation.EvalSelf,
                Projection = SlotChildProjection.ChildrenOfChildren,
            },
        };
    }

    /// <summary>
    /// Signature for slots taking one evaluated source child value.
    /// </summary>
    public class SourceExpressionSignature : LambdaSignature
    {
        /// <inheritdoc />
        public override IEnumerable<SlotChild> Children => new[]
        {
            new SlotChild
            {
                Name = "*",
                Type = "object",
                Description = "Single source child evaluated before its value is consumed; omit to set the destination to null",
                Required = false,
                Mode = SlotChildMode.ExecutableLambda,
                Cardinality = SlotChildCardinality.ZeroOrOne,
                Role = SlotChildRole.SourceExpression,
                Evaluation = SlotChildEvaluation.EvalSelf,
                Projection = SlotChildProjection.Value,
            },
        };
    }

    /// <summary>
    /// Signature for loop slots whose children are evaluated once per selected node.
    /// </summary>
    public class IteratorBodySignature : LambdaSignature
    {
        /// <inheritdoc />
        public override IEnumerable<SlotChild> Children => new[]
        {
            ExecutableBody("Loop body evaluated once per selected node"),
        };
    }

    /// <summary>
    /// Signature for [map].
    /// </summary>
    public class MapSignature : LambdaSignature
    {
        /// <inheritdoc />
        public override IEnumerable<SlotChild> Children => new[]
        {
            new SlotChild
            {
                Name = "*",
                Type = "lambda",
                Description = "Mapper body evaluated once per selected node; each returned value becomes a [.] node and returned child nodes are added to the mapped result",
                Required = true,
                Mode = SlotChildMode.ExecutableLambda,
                Cardinality = SlotChildCardinality.OneOrMore,
                Role = SlotChildRole.ExecutableBody,
                Evaluation = SlotChildEvaluation.EvalSelf,
                Projection = SlotChildProjection.ReturnedResult,
            },
        };
    }

    /// <summary>
    /// Signature for [filter].
    /// </summary>
    public class FilterSignature : LambdaSignature
    {
        /// <inheritdoc />
        public override IEnumerable<SlotChild> Children => new[]
        {
            new SlotChild
            {
                Name = "*",
                Type = "lambda",
                Description = "Predicate body evaluated once per selected node; the selected node is kept when the body returns true",
                Required = true,
                Mode = SlotChildMode.ExecutableLambda,
                Cardinality = SlotChildCardinality.OneOrMore,
                Role = SlotChildRole.Condition,
                Evaluation = SlotChildEvaluation.EvalSelf,
                Projection = SlotChildProjection.ReturnedResult,
            },
        };
    }

    /// <summary>
    /// Signature for [include]. Body's slots.result drives what gets added
    /// to each iterated destination node — declared via
    /// Projection=ReturnedResult so the synthesizer knows the body must
    /// call [yield]/[return]/[return-nodes] rather than side-effect-only
    /// slots that would leave result.Children empty.
    /// </summary>
    public class IncludeSignature : LambdaSignature
    {
        /// <inheritdoc />
        public override IEnumerable<SlotChild> Children => new[]
        {
            new SlotChild
            {
                Name = "*",
                Type = "lambda",
                Description = "Executable body evaluated once per selected node; all returned child nodes are included into that selected node",
                Required = true,
                Mode = SlotChildMode.ExecutableLambda,
                Cardinality = SlotChildCardinality.OneOrMore,
                Role = SlotChildRole.ExecutableBody,
                Evaluation = SlotChildEvaluation.EvalSelf,
                Projection = SlotChildProjection.ReturnedResult,
            },
        };
    }

    /// <summary>
    /// Signature for [try].
    /// </summary>
    public class TrySignature : LambdaSignature
    {
        /// <inheritdoc />
        public override IEnumerable<SlotChild> Children => new[]
        {
            ExecutableBody("Protected body evaluated by [try]"),
        };

        /// <inheritdoc />
        public override IEnumerable<SlotConstraint> Constraints => new[]
        {
            new SlotConstraint
            {
                Kind = SlotConstraintKind.NextSiblingMustBeOneOf,
                Description = "Must be followed by [.catch] and/or [.finally]; a bare [try] is a no-op because uncaught exceptions re-throw and [.finally] alone would run regardless",
                Values = { ".catch", ".finally" },
            },
        };
    }

    /// <summary>
    /// Signature for [throw].
    /// </summary>
    public class ThrowSignature : LambdaSignature
    {
        /// <inheritdoc />
        public override IEnumerable<SlotChild> Children => new[]
        {
            Option("public", "bool", "Whether the exception message may be returned to clients", "false"),
            Option("status", "int", "HTTP status code associated with the exception", "500"),
            Option("field", "string", "Optional form field or control ID associated with the exception", kind: "form-field-id"),
        };

        internal static SlotChild Option(string name, string type, string description, string defaultValue = null, string kind = null)
        {
            return new SlotChild
            {
                Name = name,
                Type = type,
                Kind = kind,
                Description = description,
                Required = false,
                DefaultValue = defaultValue,
                Mode = SlotChildMode.ValueOrExpression,
                Cardinality = SlotChildCardinality.ZeroOrOne,
                Role = SlotChildRole.Option,
                Projection = SlotChildProjection.Value,
            };
        }
    }

    /// <summary>
    /// Signature for [format].
    /// </summary>
    public class FormatSignature : LambdaSignature
    {
        /// <inheritdoc />
        public override IEnumerable<SlotChild> Children => new[]
        {
            new SlotChild
            {
                Name = "pattern",
                Type = "string",
                Kind = "format-pattern",
                Description = "Composite format string",
                Required = true,
                Mode = SlotChildMode.ValueOrExpression,
                Cardinality = SlotChildCardinality.ExactlyOne,
                Role = SlotChildRole.Option,
                Projection = SlotChildProjection.Value,
            },
            ThrowSignature.Option("culture", "string", "Optional culture name used when formatting", kind: "culture-name"),
        };
    }

    /// <summary>
    /// Signature for [unwrap].
    /// </summary>
    public class UnwrapSignature : LambdaSignature
    {
        /// <inheritdoc />
        public override IEnumerable<SlotChild> Children => new[]
        {
            ThrowSignature.Option("apply-lists", "bool", "Whether list results should be applied while unwrapping", "false"),
        };
    }
}
