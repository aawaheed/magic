/*
 * Magic Cloud, copyright (c) 2023 Thomas Hansen. See the attached LICENSE file for details. For license inquiries you can send an email to thomas@ainiro.io
 */

using System.Collections.Generic;
using magic.signals.contracts;

namespace magic.lambda.slots.signatures
{
    /// <summary>
    /// Signature helpers for dynamic slot slots.
    /// </summary>
    public abstract class SlotSignature : ISlotSignature
    {
        /// <inheritdoc />
        public virtual IEnumerable<SlotChild> Children => new SlotChild[0];

        /// <inheritdoc />
        public virtual IEnumerable<SlotConstraint> Constraints => new SlotConstraint[0];

        /// <inheritdoc />
        public virtual IEnumerable<SlotChild> OutputChildren => new SlotChild[0];

        internal static SlotChild ArgumentBag(string description, SlotChildPreprocess preprocess = SlotChildPreprocess.None)
        {
            return new SlotChild
            {
                Name = "*",
                Type = "object",
                Description = description,
                Required = false,
                Mode = SlotChildMode.Arguments,
                Cardinality = SlotChildCardinality.ZeroOrMore,
                Role = SlotChildRole.Arguments,
                Projection = SlotChildProjection.ArgumentBag,
                Preprocess = preprocess,
            };
        }

        internal static SlotChild LambdaBlock()
        {
            return new SlotChild
            {
                Name = ".lambda",
                Type = "lambda",
                Description = "Executable dynamic slot body",
                Required = true,
                Mode = SlotChildMode.ExecutableLambda,
                Cardinality = SlotChildCardinality.ExactlyOne,
                Role = SlotChildRole.LambdaBlock,
                Evaluation = SlotChildEvaluation.SerializeLambda,
                Projection = SlotChildProjection.Children,
            };
        }

        internal static SlotChild ResultNode(string kind, string description)
        {
            return new SlotChild
            {
                Name = "*",
                Type = "lambda",
                Kind = kind,
                Description = description,
                Required = false,
                Mode = SlotChildMode.Value,
                Cardinality = SlotChildCardinality.ZeroOrMore,
                Role = SlotChildRole.Payload,
                Projection = SlotChildProjection.Self,
            };
        }
    }

    /// <summary>
    /// Signature for [signal] and [try-signal].
    /// </summary>
    public class SignalSignature : SlotSignature
    {
        /// <inheritdoc />
        public override IEnumerable<SlotChild> Children => new[]
        {
            ArgumentBag("Named argument passed to the dynamic slot as a child of [.arguments]"),
        };

        /// <inheritdoc />
        public override IEnumerable<SlotChild> OutputChildren => new[]
        {
            ResultNode("dynamic-slot-result-node", "Returned child node produced by the invoked dynamic slot"),
        };
    }

    /// <summary>
    /// Signature for [execute].
    /// </summary>
    public class ExecuteSignature : SlotSignature
    {
        /// <inheritdoc />
        public override IEnumerable<SlotChild> Children => new[]
        {
            ArgumentBag("Named argument passed to the dynamic slot as a child of [.arguments]", SlotChildPreprocess.UnwrapExpressions),
        };

        /// <inheritdoc />
        public override IEnumerable<SlotChild> OutputChildren => new[]
        {
            ResultNode("dynamic-slot-result-node", "Returned child node produced by the invoked dynamic slot after descendant expressions are unwrapped"),
        };
    }

    /// <summary>
    /// Signature for [function] and [slots.create].
    /// </summary>
    public class CreateSlotSignature : SlotSignature
    {
        /// <inheritdoc />
        public override IEnumerable<SlotChild> Children => new[]
        {
            new SlotChild
            {
                Name = "*",
                Type = "lambda",
                Description = "Executable child slot stored as the dynamic slot body",
                Required = false,
                Mode = SlotChildMode.ExecutableLambda,
                Cardinality = SlotChildCardinality.ZeroOrMore,
                Role = SlotChildRole.ExecutableBody,
                Projection = SlotChildProjection.Self,
            },
        };
    }

    /// <summary>
    /// Signature for [return].
    /// </summary>
    public class ReturnSignature : SlotSignature
    {
        /// <inheritdoc />
        public override IEnumerable<SlotChild> Children => new[]
        {
            new SlotChild
            {
                Name = "*",
                Type = "object",
                Description = "Child node forwarded to the nearest caller without evaluation; when children exist, all children are returned as-is",
                Required = false,
                Mode = SlotChildMode.SourceLambda,
                Cardinality = SlotChildCardinality.ZeroOrMore,
                Role = SlotChildRole.Payload,
                Projection = SlotChildProjection.Self,
            },
        };
    }

    /// <summary>
    /// Signature for [return-nodes].
    /// </summary>
    public class ReturnNodesSignature : SlotSignature
    {
        /// <inheritdoc />
        public override IEnumerable<SlotChild> Children => new[]
        {
            new SlotChild
            {
                Name = "*",
                Type = "lambda",
                Description = "Returned child node",
                Required = false,
                Mode = SlotChildMode.SourceLambda,
                Cardinality = SlotChildCardinality.ZeroOrMore,
                Role = SlotChildRole.Payload,
                Projection = SlotChildProjection.Self,
            },
        };
    }

    /// <summary>
    /// Signature for [yield].
    /// </summary>
    public class YieldSignature : SlotSignature
    {
        /// <inheritdoc />
        public override IEnumerable<SlotChild> Children => new[]
        {
            new SlotChild
            {
                Name = "*",
                Type = "lambda",
                Description = "Returned child node after descendant expressions are unwrapped",
                Required = false,
                Mode = SlotChildMode.SourceLambda,
                Cardinality = SlotChildCardinality.ZeroOrMore,
                Role = SlotChildRole.Payload,
                Evaluation = SlotChildEvaluation.UnwrapDescendants,
                Projection = SlotChildProjection.Self,
            },
        };
    }
}
