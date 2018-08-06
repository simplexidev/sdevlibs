using System;
using System.Runtime.InteropServices;
using NativeLibraryLoader;

namespace LibUISharp.Internal
{
    internal static partial class NativeCalls
    {
        private static NativeLibrary Kernel32
        {
            get
            {
                if (PlatformHelper.IsWinNT) return new NativeLibrary("kernel32.dll");
                else throw new PlatformNotSupportedException();
            }
        }

        [UnmanagedFunctionPointer(StdCall)]
        private delegate IntPtr GetConsoleWindow();
        internal static IntPtr winGetConsoleWindow() => Call<GetConsoleWindow>(Kernel32)();
    }
}