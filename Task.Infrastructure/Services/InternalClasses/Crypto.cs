using System.Runtime.CompilerServices;

namespace Test.Infrastructure.Services.InternalClasses
{
    internal class Crypto
    {
        public const int PBKDF2IterCount = 1000; // default for Rfc2898DeriveBytes
        public const int PBKDF2SubkeyLength = 256 / 8; // 256 bits
        public const int SaltSize = 128 / 8; // 128 bits

        // Compares two byte arrays for equality. The method is specifically written so that the loop is not optimized.
        [MethodImpl(MethodImplOptions.NoOptimization)]
        public static bool ByteArraysEqual(byte[] a, byte[] b)
        {
            if (ReferenceEquals(a, b))
            {
                return true;
            }

            if (a == null || b == null || a.Length != b.Length)
            {
                return false;
            }

            var areSame = true;
            for (var i = 0; i < a.Length; i++)
            {
                areSame &= (a[i] == b[i]);
            }
            return areSame;
        }
    }
}
