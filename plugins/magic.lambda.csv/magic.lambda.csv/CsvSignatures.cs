/*
 * Magic Cloud, copyright (c) 2023 Thomas Hansen. See the attached LICENSE file for details. For license inquiries you can send an email to thomas@ainiro.io
 */

using System.Collections.Generic;
using magic.signals.contracts;

namespace magic.lambda.csv.signatures
{
    public abstract class CsvSignature : ISlotSignature
    {
        public virtual IEnumerable<SlotChild> Children => new SlotChild[0];

        protected static SlotChild NullValue()
        {
            return new SlotChild
            {
                Name = "null-value",
                Type = "string",
                Description = "String used to represent null values",
                Required = false,
                DefaultValue = "[NULL]",
                Mode = SlotChildMode.ValueOrExpression,
                Cardinality = SlotChildCardinality.ZeroOrOne,
                Role = SlotChildRole.Option,
                Projection = SlotChildProjection.Value,
            };
        }
    }

    public class Csv2LambdaSignature : CsvSignature
    {
        public override IEnumerable<SlotChild> Children => new[]
        {
            new SlotChild
            {
                Name = "types",
                Type = "lambda",
                Description = "Column type conversions keyed by column name",
                Required = false,
                Mode = SlotChildMode.ValueOrExpression,
                Cardinality = SlotChildCardinality.ZeroOrOne,
                Role = SlotChildRole.DynamicMap,
                Projection = SlotChildProjection.StructuredTree,
                Children =
                {
                    new SlotChild
                    {
                        Name = "*",
                        Type = "string",
                        Description = "Type name for the column",
                        Required = true,
                        Mode = SlotChildMode.ValueOrExpression,
                        Cardinality = SlotChildCardinality.OneOrMore,
                        Role = SlotChildRole.DynamicMap,
                        Projection = SlotChildProjection.Value,
                    },
                },
            },
            NullValue(),
        };
    }

    public class Lambda2CsvSignature : CsvSignature
    {
        public override IEnumerable<SlotChild> Children => new[]
        {
            NullValue(),
        };
    }
}
