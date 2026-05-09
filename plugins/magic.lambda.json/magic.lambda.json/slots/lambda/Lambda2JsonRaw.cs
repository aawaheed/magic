/*
 * Magic Cloud, copyright (c) 2023 Thomas Hansen. See the attached LICENSE file for details. For license inquiries you can send an email to thomas@ainiro.io
 */

using magic.node;
using magic.signals.contracts;
using magic.lambda.json.utilities;

namespace magic.lambda.json.slots.lambda
{
    /// <summary>
    /// [.to-json-raw] slot for transforming to a raw Newtonsoft JSON JContainer object, without
    /// ever transforming to a string.
    /// </summary>
    [Slot(
        Name = ".lambda2json-raw",
        Description = "Transforms a lambda hierarchy into a raw JSON container without serializing it to a string",
        ValueType = "lambda",
        ValueDescription = "Lambda hierarchy to transform",
        ValueRequired = true,
        ValueMode = SlotValueMode.Expression,
        ReturnsMode = SlotReturnsMode.Value,
        ReturnsType = "JContainer",
        ReturnsDescription = "Resolves to the generated raw JSON container")]
    public class Lambda2JsonRaw : ISlot
    {
        /// <summary>
        /// Slot implementation.
        /// </summary>
        /// <param name="signaler">Signaler that raised signal.</param>
        /// <param name="input">Arguments to slot.</param>
        public void Signal(ISignaler signaler, Node input)
        {
            input.Value = Lambda2JsonTransformer.ToJson(input);
            input.Clear();
        }
    }
}
