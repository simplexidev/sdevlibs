using System;
using NativeLibraryLoader;

namespace LibUISharp.Native
{
    internal static class FunctionLoader
    {
        private static NativeLibrary LibuiLibrary
        {
            get
            {
                if (PlatformHelper.IsWinNT) return new NativeLibrary(@"lib\libui.dll");
                else if (PlatformHelper.IsLinux) return new NativeLibrary(@"lib/libui.so");
                else if (PlatformHelper.IsMacOS) return new NativeLibrary(@"lib/libui.dylib");
                else throw new PlatformNotSupportedException();
            }
        }

        private static NativeLibrary User32Library
        {
            get
            {
                if (PlatformHelper.IsWinNT) return new NativeLibrary("user32.dll");
                else throw new PlatformNotSupportedException();
            }
        }

        private static NativeLibrary Kernel32Library
        {
            get
            {
                if (PlatformHelper.IsWinNT) return new NativeLibrary("kernel32.dll");
                else throw new PlatformNotSupportedException();
            }
        }

        public static T LoadLibuiFunc<T>(string name) => LibuiLibrary.LoadFunction<T>(name);
        public static T LoadUser32Func<T>(string name) => User32Library.LoadFunction<T>(name);
        public static T LoadKernel32Func<T>(string name) => Kernel32Library.LoadFunction<T>(name);
    }
}