/*
 * Magic Cloud, copyright (c) 2023 Thomas Hansen. See the attached LICENSE file for details. For license inquiries you can send an email to thomas@ainiro.io
 */

using System.Collections.Generic;
using magic.signals.contracts;

namespace magic.lambda.crypto.signatures
{
    public abstract class CryptoSignature : ISlotSignature
    {
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

        protected static SlotChild Raw() => Option("raw", "bool", "Whether to return raw bytes instead of encoded text", defaultValue: "false");
    }

    public class RawSignature : CryptoSignature
    {
        public override IEnumerable<SlotChild> Children => new[] { Raw() };
    }

    public class AesSignature : CryptoSignature
    {
        public override IEnumerable<SlotChild> Children => new[]
        {
            Option("password", "string|byte[]", "Password or raw AES key", true),
            Raw(),
        };
    }

    public class RsaPublicKeySignature : CryptoSignature
    {
        public override IEnumerable<SlotChild> Children => new[]
        {
            Option("public-key", "string|byte[]", "Public key for the RSA operation", true),
            Raw(),
        };
    }

    public class RsaPrivateKeySignature : CryptoSignature
    {
        public override IEnumerable<SlotChild> Children => new[]
        {
            Option("private-key", "string|byte[]", "Private key for the RSA operation", true),
            Raw(),
        };
    }

    public class RsaCreateKeySignature : CryptoSignature
    {
        public override IEnumerable<SlotChild> Children => new[]
        {
            Option("strength", "int", "RSA key strength in bits", defaultValue: "2048"),
            Option("seed", "string|byte[]", "Optional deterministic seed"),
            Raw(),
        };
    }

    public class RsaVerifySignature : CryptoSignature
    {
        public override IEnumerable<SlotChild> Children => new[]
        {
            Option("signature", "string|byte[]", "Signature to verify", true),
            Option("public-key", "string|byte[]", "Public key used to verify the signature", true),
            Raw(),
        };
    }

    public class HashSignature : CryptoSignature
    {
        public override IEnumerable<SlotChild> Children => new[]
        {
            Option("filename", "string", "File to hash when no input content is supplied"),
        };
    }

    public class VerifyPasswordSignature : CryptoSignature
    {
        public override IEnumerable<SlotChild> Children => new[]
        {
            Option("hash", "string", "Password hash to verify against", true),
        };
    }

    public class CryptoRandomSignature : CryptoSignature
    {
        public override IEnumerable<SlotChild> Children => new[]
        {
            Option("min", "int", "Minimum random length", defaultValue: "10"),
            Option("max", "int", "Maximum random length"),
            Raw(),
            Option("seed", "string", "Optional deterministic seed"),
        };
    }

    public class CryptoRandomIntegerSignature : CryptoSignature
    {
        public override IEnumerable<SlotChild> Children => new[]
        {
            Option("max", "int", "Exclusive maximum integer", defaultValue: "int.MaxValue"),
            Option("seed", "string", "Optional deterministic seed"),
        };
    }

    public class GetKeySignature : CryptoSignature
    {
        public override IEnumerable<SlotChild> Children => new[] { Raw() };
    }

    public class CombinationSignSignature : CryptoSignature
    {
        public override IEnumerable<SlotChild> Children => new[]
        {
            Option("signing-key", "string|byte[]", "Private signing key", true),
            Option("signing-key-fingerprint", "string|byte[]", "Fingerprint for the signing key", true),
            Raw(),
        };
    }

    public class CombinationEncryptSignature : CryptoSignature
    {
        public override IEnumerable<SlotChild> Children => new[]
        {
            Option("signing-key", "string|byte[]", "Private signing key", true),
            Option("encryption-key", "string|byte[]", "Public encryption key", true),
            Option("signing-key-fingerprint", "string|byte[]", "Fingerprint for the signing key", true),
            Raw(),
            Option("seed", "string|byte[]", "Optional encryption seed"),
        };
    }

    public class CombinationVerifySignature : CryptoSignature
    {
        public override IEnumerable<SlotChild> Children => new[]
        {
            Option("verification-key", "string|byte[]", "Public key used to verify the signature", true),
            Raw(),
        };
    }

    public class CombinationDecryptSignature : CryptoSignature
    {
        public override IEnumerable<SlotChild> Children => new[]
        {
            Option("decryption-key", "string|byte[]", "Private decryption key", true),
            Option("verification-key", "string|byte[]", "Public key used to verify the signature", true),
            Raw(),
        };
    }
}
