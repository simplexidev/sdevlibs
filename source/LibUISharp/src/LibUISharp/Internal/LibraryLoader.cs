using System;
using System.IO;
using System.Runtime.InteropServices;

namespace LibUISharp.Internal
{
    internal abstract class LibraryLoader
    {
        public IntPtr LoadNativeLibrary(params string[] names) => LoadNativeLibrary(PathResolver.Default, names);

        public IntPtr LoadNativeLibrary(PathResolver pathResolver, params string[] names)
        {
            if (names == null || names.Length == 0)
                throw new ArgumentException("Parameter must not be null or empty.", nameof(names));

            IntPtr ret = IntPtr.Zero;
            foreach (string name in names)
            {
                ret = LoadWithResolver(name, pathResolver);
                if (ret != IntPtr.Zero)
                    break;
            }

            if (ret == IntPtr.Zero)
                throw new FileNotFoundException($"Could not find or load the native library from any name: [ {string.Join(", ", names)} ]");

            return ret;
        }

        public IntPtr LoadFunctionPointer(IntPtr handle, string functionName)
        {
            if (string.IsNullOrEmpty(functionName))
                throw new ArgumentException("Parameter must not be null or empty.", nameof(functionName));
            return CoreLoadFunctionPointer(handle, functionName);
        }

        public void FreeNativeLibrary(IntPtr handle)
        {
            if (handle == IntPtr.Zero)
                throw new ArgumentException("Parameter must not be zero.", nameof(handle));
            CoreFreeNativeLibrary(handle);
        }

        public static LibraryLoader GetPlatformDefaultLoader()
        {
            if (PlatformHelper.IsWinNT)
                return new Win32LibraryLoader();
            else if (PlatformHelper.IsUnix)
                return new UnixLibraryLoader();
            throw new PlatformNotSupportedException("This platform cannot load native libraries.");
        }

        protected abstract IntPtr CoreLoadNativeLibrary(string name);

        protected abstract void CoreFreeNativeLibrary(IntPtr handle);

        protected abstract IntPtr CoreLoadFunctionPointer(IntPtr handle, string functionName);

        private IntPtr LoadWithResolver(string name, PathResolver pathResolver)
        {
            if (Path.IsPathRooted(name))
                return CoreLoadNativeLibrary(name);
            else
            {
                foreach (string loadTarget in pathResolver.EnumeratePossibleLibraryLoadTargets(name))
                {
                    if (!Path.IsPathRooted(loadTarget) || File.Exists(loadTarget))
                    {
                        IntPtr ret = CoreLoadNativeLibrary(loadTarget);
                        if (ret != IntPtr.Zero)
                            return ret;
                    }
                }
                return IntPtr.Zero;
            }
        }

        private class Win32LibraryLoader : LibraryLoader
        {
            protected override void CoreFreeNativeLibrary(IntPtr handle) => FreeLibrary(handle);
            protected override IntPtr CoreLoadFunctionPointer(IntPtr handle, string functionName) => GetProcAddress(handle, functionName);
            protected override IntPtr CoreLoadNativeLibrary(string name) => LoadLibrary(name);

            [DllImport("kernel32")]
            private static extern IntPtr LoadLibrary(string fileName);

            [DllImport("kernel32")]
            private static extern IntPtr GetProcAddress(IntPtr module, string procName);

            [DllImport("kernel32")]
            private static extern int FreeLibrary(IntPtr module);
        }

        private class UnixLibraryLoader : LibraryLoader
        {
            protected override void CoreFreeNativeLibrary(IntPtr handle) => dlclose(handle);
            protected override IntPtr CoreLoadFunctionPointer(IntPtr handle, string functionName) => dlsym(handle, functionName);
            protected override IntPtr CoreLoadNativeLibrary(string name) => dlopen(name, 0x002); // RTLD_NOW = 0x002

            [DllImport("libdl")]
            public static extern IntPtr dlopen(string fileName, int flags);

            [DllImport("libdl")]
            public static extern IntPtr dlsym(IntPtr handle, string name);

            [DllImport("libdl")]
            public static extern int dlclose(IntPtr handle);
        }
    }
}
