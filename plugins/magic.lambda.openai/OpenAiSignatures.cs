/*
 * Magic Cloud, copyright (c) 2023 Thomas Hansen. See the attached LICENSE file for details. For license inquiries you can send an email to thomas@ainiro.io
 */

using System.Collections.Generic;
using magic.signals.contracts;

namespace magic.lambda.openai.signatures
{
    public class WhisperSignature : ISlotSignature
    {
        public IEnumerable<SlotChild> Children => new[]
        {
            Option("key", "string", "OpenAI API key", true),
            Option("content", "byte[]", "Audio content bytes", true),
            Option("type", "string", "Audio MIME type", true),
            Option("language", "string", "Optional language hint"),
        };

        static SlotChild Option(string name, string type, string description, bool required = false)
        {
            return new SlotChild
            {
                Name = name,
                Type = type,
                Description = description,
                Required = required,
                Mode = SlotChildMode.ValueOrExpression,
                Cardinality = required ? SlotChildCardinality.ExactlyOne : SlotChildCardinality.ZeroOrOne,
                Role = SlotChildRole.Option,
                Projection = SlotChildProjection.Value,
            };
        }
    }
}
