using NativeLibraryLoader;
using System;
using System.Runtime.InteropServices;

namespace LibUISharp.Internal
{
    internal static partial class Libraries
    {
        internal static class Kernel32
        {
            private const CallingConvention Convention = CallingConvention.StdCall;

            private static NativeLibrary Library
            {
                get
                {
                    if (PlatformHelper.IsWinNT) return new NativeLibrary("kernel32.dll");
                    else throw new PlatformNotSupportedException();
                }
            }

            public static T Call<T>() => Call<T>(typeof(T).Name);
            public static T Call<T>(string name) => LoadCall<T>(Library, name);

            // HWND WINAPI GetConsoleWindow(void);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate IntPtr GetConsoleWindow();
        }
    }
}