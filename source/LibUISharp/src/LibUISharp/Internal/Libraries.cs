﻿using NativeLibraryLoader;
using System;

namespace LibUISharp.Internal
{
    internal static partial class Libraries
    {
        private static T NativeCall<T>(NativeLibrary library, string name)
        {
            if (library == null) throw new ArgumentNullException(nameof(library));
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
#if DEBUG
            Console.WriteLine($"[NativeCall] Calling native method: '{name}'");
#endif
            return library.LoadFunction<T>(name);
        }
    }
}