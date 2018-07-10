using NativeLibraryLoader;
using System;

namespace LibUISharp.Internal
{
    internal static partial class Libraries
    {
        private static T LoadCall<T>(NativeLibrary library, string name)
        {
#if DEBUG
            Console.WriteLine($"[LoadCall] Calling native method: '{name}'");
#endif
            return library.LoadFunction<T>(name);
        }
    }
}