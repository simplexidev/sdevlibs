using System;
using System.Runtime.InteropServices;
using NativeLibraryLoader;

namespace LibUISharp.Internal
{
    internal static class User32Library
    {
        private const CallingConvention Convention = CallingConvention.StdCall;

        private static class FunctionLoader
        {
            private static NativeLibrary User32NativeLibrary
            {
                get
                {
                    if (PlatformHelper.IsWinNT) return new NativeLibrary("user32.dll");
                    else throw new PlatformNotSupportedException();
                }
            }

            public static T Load<T>(string name) => User32NativeLibrary.LoadFunction<T>(name);
        }

        [UnmanagedFunctionPointer(Convention)]
        private delegate void ShowWindow_t(IntPtr hWnd, int nCmdShow);
        public static void ShowWindow(IntPtr hWnd, int nCmdShow) => FunctionLoader.Load<ShowWindow_t>("ShowWindow")(hWnd, nCmdShow);
    }
}