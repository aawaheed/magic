/*
 * Magic Cloud, copyright (c) 2023 Thomas Hansen. See the attached LICENSE file for details. For license inquiries you can send an email to thomas@ainiro.io
 */

using System.Collections.Generic;
using magic.signals.contracts;

namespace magic.lambda.math.signatures
{
    public class ArithmeticSignature : ISlotSignature
    {
        public IEnumerable<SlotChild> Children => new[]
        {
            new SlotChild
            {
                Name = "*",
                Type = "number",
                Description = "Numeric operand evaluated before calculating the result",
                Required = true,
                Mode = SlotChildMode.ExecutableLambda,
                Cardinality = SlotChildCardinality.TwoOrMore,
                Role = SlotChildRole.Operand,
                Evaluation = SlotChildEvaluation.EvalSelf,
                Projection = SlotChildProjection.Value,
            },
        };
    }

    public class DotProductSignature : ISlotSignature
    {
        public IEnumerable<SlotChild> Children => new[]
        {
            new SlotChild
            {
                Name = "*",
                Type = "lambda",
                Description = "Vector operand evaluated before calculating the dot product",
                Required = true,
                Mode = SlotChildMode.ExecutableLambda,
                Cardinality = SlotChildCardinality.ExactlyTwo,
                Role = SlotChildRole.Operand,
                Evaluation = SlotChildEvaluation.EvalSelf,
                Projection = SlotChildProjection.Children,
            },
        };
    }

    public class IncrementDecrementSignature : ISlotSignature
    {
        public IEnumerable<SlotChild> Children => new[]
        {
            new SlotChild
            {
                Name = "step",
                Type = "number",
                Description = "Amount to add to or subtract from each selected node",
                Required = false,
                Mode = SlotChildMode.ValueOrExpression,
                Cardinality = SlotChildCardinality.ZeroOrOne,
                DefaultValue = "1",
                Role = SlotChildRole.Option,
                Projection = SlotChildProjection.Value,
            },
        };
    }

    public class RandomSignature : ISlotSignature
    {
        public IEnumerable<SlotChild> Children => new[]
        {
            new SlotChild
            {
                Name = "min",
                Type = "int",
                Description = "Inclusive lower bound; requires [max] and must appear before it",
                Required = false,
                Mode = SlotChildMode.ValueOrExpression,
                Cardinality = SlotChildCardinality.ZeroOrOne,
                Role = SlotChildRole.Option,
                Projection = SlotChildProjection.Value,
            },
            new SlotChild
            {
                Name = "max",
                Type = "int",
                Description = "Exclusive upper bound; when supplied without [min], the lower bound is 0",
                Required = false,
                Mode = SlotChildMode.ValueOrExpression,
                Cardinality = SlotChildCardinality.ZeroOrOne,
                Role = SlotChildRole.Option,
                Projection = SlotChildProjection.Value,
            },
        };

        public IEnumerable<SlotConstraint> Constraints
        {
            get
            {
                var result = new SlotConstraint
                {
                    Kind = SlotConstraintKind.Requires,
                    Target = "min",
                    Description = "[min] requires [max]",
                };
                result.Values.Add("max");
                return new[] { result };
            }
        }
    }
}
