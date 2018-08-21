using System;
using System.Security.Cryptography;

namespace LibUISharp.Internal
{
    internal static class HashHelper
    {
        // https://stackify.com/csharp-random-numbers/
        public static int GenerateSeed()
        {
            Random rnd = new Random();
            byte[] array = new byte[4];
            rnd.NextBytes(array);

            return unchecked((int)BitConverter.ToUInt32(array, 0));
        }

        public static int GenerateSecureSeed()
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            byte[] array = new byte[4];
            provider.GetBytes(array);

            return unchecked((int)BitConverter.ToUInt32(array, 0));
        }

        // https://github.com/dotnet/corefx/blob/master/src/Common/src/System/Numerics/Hashing/HashHelpers.cs
        public static int GenerateHash(params object[] objs)
        {
            unchecked
            {
                int hash = objs.Length;
                for (int i = 0; i < objs.Length; i++)
                {
                    uint rol5 = ((uint)hash << 5) | ((uint)hash >> 27);
                    hash = ((int)rol5 + hash) ^ i;
                }
                return hash;
            }
        }
    }
}