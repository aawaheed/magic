# INFO; Hyperlambda Cryptography Generator Examples Prompt

Hyperlambda has good support for cryptography. It supports AES and RSA cryptography, in addition to allowing for cryptographically signing payloads. Below are some example prompts related to cryptography.

- "Create a new RSA keypair and store the public key in /etc/public.txt, and the private key /etc/private.txt."
- "Use AES cryptography to encrypt the file '/README.md' witgh the password 'xyz' and return the resulting cipher text to caller."
- "Executable Hyperlambda file that decrypts the specified 'cipher' argument using the private key found at '/etc/private.txt', and returns the resulting plain text content."

Etc ...

Basically, you can encrypt, decrypt, and cryptographically sign, using AES, RSA, and combination cryptography slots, arguments, filenames, result from HTTP invocations, database records, etc, etc, etc. Magic also has support for hashing, and can hash files, and/or content.