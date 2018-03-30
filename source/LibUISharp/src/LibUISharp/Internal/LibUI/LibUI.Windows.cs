using System;
using System.Runtime.InteropServices;

namespace LibUISharp.Internal
{
    internal static partial class LibUI
    {
        public static class WindowsNT
        {
            private const string Kernel32Ref = "kernel32.dll";
            private const string User32Ref = "user32.dll";

            [DllImport(Kernel32Ref, SetLastError = true)]
            public static extern IntPtr GetConsoleWindow();
            [DllImport(User32Ref, SetLastError = true)]
            public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

            public static void ConsoleWindowVisible(bool visible)
            {
                IntPtr ptr = GetConsoleWindow();
                if (visible)
                    ShowWindow(ptr, 4); // 4 = SW_SHOWNOACTIVATE
                else
                    ShowWindow(ptr, 0); // 0 = SW_HIDE
            }
        }
    }
}