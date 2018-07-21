using NativeLibraryLoader;
using System;
using System.Runtime.InteropServices;

namespace LibUISharp.Internal
{
    internal static partial class Libraries
    {
        internal static class User32
        {
            private const CallingConvention Convention = CallingConvention.StdCall;

            private static NativeLibrary Library
            {
                get
                {
                    if (PlatformHelper.IsWinNT) return new NativeLibrary("user32.dll");
                    else throw new PlatformNotSupportedException();
                }
            }

            public static T Call<T>() => Call<T>(typeof(T).Name);
            public static T Call<T>(string name) => NativeCall<T>(Library, name);

            // BOOL WINAPI ShowWindow(_In_ HWND hWnd, _In_ int nCmdShow);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void ShowWindow(IntPtr hWnd, int nCmdShow);
        }
    }
}