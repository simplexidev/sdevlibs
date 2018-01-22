using System;

namespace LibUISharp.Internal
{
    internal static class HashHelpers
    {
        public static readonly int RandomSeed = Guid.NewGuid().GetHashCode();

        public static int Combine(int h1, int h2) => unchecked(((h1 << 5) + h1) ^ h2);

        public static int Combine(int h1, int h2, int h3) => unchecked(Combine(h1, Combine(h2, h3)));

        public static int Combine(int h1, int h2, int h3, int h4) => unchecked(Combine(h1, h2, Combine(h3, h4)));
    }
}