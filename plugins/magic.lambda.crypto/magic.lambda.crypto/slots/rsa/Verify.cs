/*
 * Magic Cloud, copyright (c) 2023 Thomas Hansen. See the attached LICENSE file for details. For license inquiries you can send an email to thomas@ainiro.io
 */

using System;
using System.Linq;
using magic.node;
using magic.node.extensions;
using magic.signals.contracts;
using magic.lambda.crypto.lib.rsa;

namespace magic.lambda.crypto.slots.rsa
{
    /// <summary>
    /// [crypto.rsa.verify] slot to verify that some piece of text was cryptographically
    /// signed with a specific private key.
    /// </summary>
    // 'text' REMOVED: verify needs the EXACT bytes that were signed; wiring it
    // to an arbitrary text producer (lambda2hyper output, lambda2html, log
    // entries, formatted strings, free-form prose preludes) is structurally
    // wrong — the content was never signed, so verification would always fail
    // at runtime. The corpus was showing snippets like:
    //   .invoiceBody:<p>Hello <strong>world</strong></p>
    //   crypto.rsa.verify:x:@.invoiceBody
    // teaching the model that random HTML is a valid verify input. Keep only
    // `content,binary-content` — opaque byte/string content that carries the
    // signed payload as-is (e.g. paired with [signature]). The sign side
    // (crypto.rsa.sign) keeps `text` because signing arbitrary text IS a
    // legitimate use case — verify is the asymmetric half.
    [Slot(
        Name = "crypto.rsa.verify",
        Description = "Verifies an RSA signature",
        ValueKind = "content,binary-content",
        ValueDescription = "Content to verify against the supplied signature",
        ValueRequired = true,
        ValueMode = SlotValueMode.ValueOrExpression,
        ReturnsMode = SlotReturnsMode.None,
        SignatureType = typeof(global::magic.lambda.crypto.signatures.RsaVerifySignature))]
    public class Verify : ISlot
    {
        /// <summary>
        /// Implementation of slot.
        /// </summary>
        /// <param name="signaler">Signaler invoking slot.</param>
        /// <param name="input">Arguments to slot.</param>
        public void Signal(ISignaler signaler, Node input)
        {
            // Retrieving signature, and converting if necessary
            var rawSignature = input.Children.FirstOrDefault(x => x.Name == "signature")?.GetEx<object>();
            var signature = rawSignature is string strSign ?
                Convert.FromBase64String(strSign) :
                rawSignature as byte[];

            // Retrieving common arguments.
            var arguments = Utilities.GetArguments(input, false, "public-key");
            input.Value = null;

            // Verifying signature of message.
            var verifier = new Verifier(arguments.Key);
            verifier.Verify(arguments.Message, signature);
        }
    }
}
