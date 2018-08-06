using System;
using System.Runtime.InteropServices;
using NativeLibraryLoader;

namespace LibUISharp.Internal
{
    internal static partial class NativeCalls
    {
        private const CallingConvention StdCall = CallingConvention.StdCall;
        private const CallingConvention Cdecl = CallingConvention.Cdecl;

        private static T Call<T>(NativeLibrary library) => Call<T>(library, typeof(T).Name);

        private static T Call<T>(NativeLibrary library, string name)
        {
            if (library == null) throw new ArgumentNullException(nameof(library));
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
#if DEBUG_NATIVECALL
            Debug.Write($"[NativeCall] Calling native method '{name}'.");
#endif
            return library.LoadFunction<T>(name);
        }
    }
}