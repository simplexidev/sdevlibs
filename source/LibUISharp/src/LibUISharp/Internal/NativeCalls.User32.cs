using System;
using System.Runtime.InteropServices;
using NativeLibraryLoader;

namespace LibUISharp.Internal
{
    internal static partial class NativeCalls
    {
        private static NativeLibrary User32
        {
            get
            {
                if (PlatformHelper.IsWinNT) return new NativeLibrary("user32.dll");
                else throw new PlatformNotSupportedException();
            }
        }

        [UnmanagedFunctionPointer(StdCall)]
        private delegate void ShowWindow(IntPtr hWnd, int nCmdShow);
        internal static void winShowWindow(IntPtr hWnd, int nCmdShow) => Call<ShowWindow>(User32)(hWnd, nCmdShow);
    }
}