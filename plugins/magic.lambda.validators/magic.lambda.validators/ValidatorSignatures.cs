/*
 * Magic Cloud, copyright (c) 2023 Thomas Hansen. See the attached LICENSE file for details. For license inquiries you can send an email to thomas@ainiro.io
 */

using System.Collections.Generic;
using magic.signals.contracts;

namespace magic.lambda.validators.signatures
{
    /// <summary>
    /// Child signatures for validator slots.
    /// </summary>
    public abstract class ValidatorSignature : ISlotSignature
    {
        /// <inheritdoc />
        public virtual IEnumerable<SlotChild> Children => new SlotChild[0];

        protected static SlotChild Option(string name, string type, string description, bool required = false, string defaultValue = null)
        {
            return new SlotChild
            {
                Name = name,
                Type = type,
                Description = description,
                Required = required,
                DefaultValue = defaultValue,
                Mode = SlotChildMode.ValueOrExpression,
                Cardinality = required ? SlotChildCardinality.ExactlyOne : SlotChildCardinality.ZeroOrOne,
                Role = SlotChildRole.Option,
                Projection = SlotChildProjection.Value,
            };
        }
    }

    public class MinMaxIntSignature : ValidatorSignature
    {
        public override IEnumerable<SlotChild> Children => new[]
        {
            Option("min", "long", "Minimum accepted value"),
            Option("max", "long", "Maximum accepted value"),
        };
    }

    public class MinMaxStringSignature : ValidatorSignature
    {
        public override IEnumerable<SlotChild> Children => new[]
        {
            Option("min", "int", "Minimum accepted length", defaultValue: "0"),
            Option("max", "int", "Maximum accepted length", defaultValue: "int.MaxValue"),
        };
    }

    public class MinMaxDateSignature : ValidatorSignature
    {
        public override IEnumerable<SlotChild> Children => new[]
        {
            Option("min", "date", "Earliest accepted date"),
            Option("max", "date", "Latest accepted date"),
        };
    }

    public class RegexValidatorSignature : ValidatorSignature
    {
        public override IEnumerable<SlotChild> Children => new[]
        {
            Option("regex", "string", "Regular expression pattern the value must match", true),
        };
    }

    public class EnumValidatorSignature : ValidatorSignature
    {
        public override IEnumerable<SlotChild> Children => new[]
        {
            new SlotChild
            {
                Name = ".",
                Type = "string",
                Description = "Accepted enum value",
                Required = true,
                Mode = SlotChildMode.ValueOrExpression,
                Cardinality = SlotChildCardinality.OneOrMore,
                Role = SlotChildRole.Option,
                Projection = SlotChildProjection.Value,
            },
        };
    }

    public class DefaultValidatorSignature : ValidatorSignature
    {
        public override IEnumerable<SlotChild> Children => new[]
        {
            new SlotChild
            {
                Name = "*",
                Type = "object",
                Description = "Default child node cloned into each selected node when missing",
                Required = true,
                Mode = SlotChildMode.ValueOrExpression,
                Cardinality = SlotChildCardinality.OneOrMore,
                Role = SlotChildRole.DynamicMap,
                Projection = SlotChildProjection.StructuredTree,
            },
        };
    }

    public class RecaptchaValidatorSignature : ValidatorSignature
    {
        public override IEnumerable<SlotChild> Children => new[]
        {
            Option("site-key", "string", "reCAPTCHA site key", true),
            Option("secret", "string", "reCAPTCHA secret key", true),
            Option("min", "decimal", "Minimum acceptable reCAPTCHA score", true),
        };
    }
}
