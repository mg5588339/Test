using System;
using System.Security.Cryptography;
using Test.Application.Common.Interfaces;
using Test.Infrastructure.Services.InternalClasses;

namespace Test.Infrastructure.Services
{
    public class SecurityService: ISecurityService
    {
        /* =======================
         * HASHED PASSWORD FORMATS
         * =======================
         * 
         * Version 0:
         * PBKDF2 with HMAC-SHA1, 128-bit salt, 256-bit subkey, 1000 iterations.
         * (See also: SDL crypto guidelines v5.1, Part III)
         * Format: { 0x00, salt, subkey }
         */
        public string HashPassword(string password)
        {
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }

            // Produce a version 0 (see comment above) text hash.
            byte[] salt;
            byte[] subkey;
            using (var deriveBytes = new Rfc2898DeriveBytes(password, Crypto.SaltSize, Crypto.PBKDF2IterCount))
            {
                salt = deriveBytes.Salt;
                subkey = deriveBytes.GetBytes(Crypto.PBKDF2SubkeyLength);
            }

            var outputBytes = new byte[1 + Crypto.SaltSize + Crypto.PBKDF2SubkeyLength];
            Buffer.BlockCopy(salt, 0, outputBytes, 1, Crypto.SaltSize);
            Buffer.BlockCopy(subkey, 0, outputBytes, 1 + Crypto.SaltSize, Crypto.PBKDF2SubkeyLength);
            return Convert.ToBase64String(outputBytes);
        }

        // hashedPassword must be of the format of HashWithPassword (salt + Hash(salt+input)
        public bool VerifyHashedPassword(string hashedPassword, string password)
        {
            if (hashedPassword == null)
            {
                return false;
            }
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }

            var hashedPasswordBytes = Convert.FromBase64String(hashedPassword);

            // Verify a version 0 (see comment above) text hash.

            if (hashedPasswordBytes.Length != (1 + Crypto.SaltSize + Crypto.PBKDF2SubkeyLength) || hashedPasswordBytes[0] != 0x00)
            {
                // Wrong length or version header.
                return false;
            }

            var salt = new byte[Crypto.SaltSize];
            Buffer.BlockCopy(hashedPasswordBytes, 1, salt, 0, Crypto.SaltSize);
            var storedSubkey = new byte[Crypto.PBKDF2SubkeyLength];
            Buffer.BlockCopy(hashedPasswordBytes, 1 + Crypto.SaltSize, storedSubkey, 0, Crypto.PBKDF2SubkeyLength);

            byte[] generatedSubkey;
            using (var deriveBytes = new Rfc2898DeriveBytes(password, salt, Crypto.PBKDF2IterCount))
            {
                generatedSubkey = deriveBytes.GetBytes(Crypto.PBKDF2SubkeyLength);
            }
            return Crypto.ByteArraysEqual(storedSubkey, generatedSubkey);
        }
    }
}
