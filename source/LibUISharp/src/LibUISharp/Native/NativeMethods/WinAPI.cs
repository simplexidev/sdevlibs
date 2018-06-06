using System;
using System.Runtime.InteropServices;

namespace LibUISharp.Native
{
    internal static partial class NativeMethods
    {
        public static class WinAPI
        {
            private const CallingConvention Convention = CallingConvention.StdCall;

            // BOOL WINAPI ShowWindow(_In_ HWND hWnd, _In_ int nCmdShow);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void ShowWindow_t(IntPtr hWnd, int nCmdShow);
            public static void ShowWindow(IntPtr hWnd, int nCmdShow) => FunctionLoader.LoadUser32Func<ShowWindow_t>("ShowWindow")(hWnd, nCmdShow);

            // HWND WINAPI GetConsoleWindow(void);
            [UnmanagedFunctionPointer(Convention)]
            private delegate IntPtr GetConsoleWindow_t();
            public static IntPtr GetConsoleWindow() => FunctionLoader.LoadKernel32Func<GetConsoleWindow_t>("GetConsoleWindow")();
        }
    }
}