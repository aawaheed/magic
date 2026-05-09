/*
 * Magic Cloud, copyright (c) 2023 Thomas Hansen. See the attached LICENSE file for details. For license inquiries you can send an email to thomas@ainiro.io
 */

using System.Linq;
using System.Collections.Generic;
using magic.node;
using magic.node.extensions;
using magic.signals.contracts;

namespace magic.lambda.misc
{
    /// <summary>
    /// [slot.signature] slot allowing you to retrieve the documented
    /// input and output contract of a single compiled slot.
    /// </summary>
    [Slot(
        Name = "slot.signature",
        Description = "Returns the documented input and output contract for a single compiled slot",
        ValueType = "string",
        ValueDescription = "Name of the compiled slot to inspect",
        ValueRequired = true,
        ValueMode = SlotValueMode.ValueOrExpression,
        ReturnsMode = SlotReturnsMode.Lambda,
        ReturnsType = "lambda",
        ReturnsDescription = "Resolves to input and output contract metadata for the requested slot")]
    public class SlotSignature : ISlot
    {
        readonly ISignalsProvider _signalProvider;

        /// <summary>
        /// Constructor creating an object requiring a signals provider to be able to fetch slot types.
        /// </summary>
        /// <param name="signalProvider">Slot provider, providing all slots that exists in the system.</param>
        public SlotSignature(ISignalsProvider signalProvider)
        {
            _signalProvider = signalProvider;
        }

        /// <summary>
        /// Implementation of signal.
        /// </summary>
        /// <param name="signaler">Signaler used to signal.</param>
        /// <param name="input">Parameters passed from signaler.</param>
        public void Signal(ISignaler signaler, Node input)
        {
            var name = input.GetEx<string>();
            if (string.IsNullOrWhiteSpace(name))
                throw new HyperlambdaException("No slot name supplied to [slot.signature]");

            var whitelist = signaler.Peek<List<Node>>("whitelist");
            if (whitelist != null && !whitelist.Any(x => x.Name == name))
                throw new HyperlambdaException($"[{name}] slot does not exist");

            var type = _signalProvider.GetSlot(name) ??
                throw new HyperlambdaException($"[{name}] slot does not exist");

            var signature = type
                .GetCustomAttributes(true)
                .OfType<SlotAttribute>()
                .FirstOrDefault(x => x.Name == name) ??
                    throw new HyperlambdaException($"[{name}] slot does not exist");

            input.Clear();
            input.Value = null;
            if (HasInput(signature))
                input.Add(CreateInputNode(signature));
            if (HasOutput(signature))
                input.Add(CreateOutputNode(signature));
        }

        #region [ -- Private helper methods -- ]

        /*
         * Returns true if the slot documents any RHS value input contract.
         */
        static bool HasInput(SlotAttribute signature)
        {
            return
                !string.IsNullOrEmpty(signature.ValueType) ||
                !string.IsNullOrEmpty(signature.ValueDescription) ||
                signature.ValueRequired ||
                signature.ValueMode != SlotValueMode.None;
        }

        /*
         * Returns true if the slot documents any output contract.
         */
        static bool HasOutput(SlotAttribute signature)
        {
            return
                signature.ReturnsMode != SlotReturnsMode.None ||
                !string.IsNullOrEmpty(signature.ReturnsType) ||
                !string.IsNullOrEmpty(signature.ReturnsDescription);
        }

        /*
         * Creates the [input] node describing the slot's RHS value contract.
         */
        static Node CreateInputNode(SlotAttribute signature)
        {
            var result = new Node("input");
            result.Add(new Node("type", signature.ValueType));
            result.Add(new Node("description", signature.ValueDescription));
            result.Add(new Node("required", signature.ValueRequired));
            result.Add(new Node("mode", signature.ValueMode.ToString()));
            return result;
        }

        /*
         * Creates the [output] node describing the slot's documented return contract.
         */
        static Node CreateOutputNode(SlotAttribute signature)
        {
            var result = new Node("output");
            result.Add(new Node("mode", signature.ReturnsMode.ToString()));
            result.Add(new Node("type", signature.ReturnsType));
            result.Add(new Node("description", signature.ReturnsDescription));
            return result;
        }

        #endregion
    }
}
