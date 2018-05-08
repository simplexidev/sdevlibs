using System;
using System.Runtime.InteropServices;

namespace LibUISharp.Native
{
    internal class NativeLibrary : IDisposable
    {
        private static readonly LibraryLoader s_platformDefaultLoader = LibraryLoader.GetPlatformDefaultLoader();
        private readonly LibraryLoader _loader;
        
        public NativeLibrary(params string[] names) : this(s_platformDefaultLoader, PathResolver.Default, names) { }
        
        public NativeLibrary(LibraryLoader loader, params string[] names) : this(loader, PathResolver.Default, names) { }
        
        public NativeLibrary(LibraryLoader loader, PathResolver pathResolver, params string[] names)
        {
            _loader = loader;
            Handle = _loader.LoadNativeLibrary(pathResolver, names);
        }
        
        public IntPtr Handle { get; }
        
        public T LoadFunction<T>(string name)
        {
            IntPtr functionPtr = _loader.LoadFunctionPointer(Handle, name);
            if (functionPtr == IntPtr.Zero)
                throw new InvalidOperationException($"No function was found with the name {name}.");
            return Marshal.GetDelegateForFunctionPointer<T>(functionPtr);
        }
        
        public IntPtr LoadFunction(string name) => _loader.LoadFunctionPointer(Handle, name);

        public void Dispose() => _loader.FreeNativeLibrary(Handle);
    }
}