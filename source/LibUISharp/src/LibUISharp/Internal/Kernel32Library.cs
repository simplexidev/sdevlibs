using System;
using System.Runtime.InteropServices;

namespace LibUISharp.Internal
{
    internal static class Kernel32Library
    {
        private const CallingConvention Convention = CallingConvention.StdCall;

        private static class FunctionLoader
        {
            private static readonly string[] WinNTLibNames = new[] { "kernel32.dll" };

            private static NativeLibrary Kernel32NativeLibrary
            {
                get
                {
                    if (PlatformHelper.IsWinNT) return new NativeLibrary(WinNTLibNames);
                    else throw new PlatformNotSupportedException();
                }
            }

            public static T Load<T>(string name) => Kernel32NativeLibrary.LoadFunction<T>(name);
        }

        [UnmanagedFunctionPointer(Convention)]
        private delegate IntPtr GetConsoleWindow_t();
        public static IntPtr GetConsoleWindow() => FunctionLoader.Load<GetConsoleWindow_t>("GetConsoleWindow")();
    }
}