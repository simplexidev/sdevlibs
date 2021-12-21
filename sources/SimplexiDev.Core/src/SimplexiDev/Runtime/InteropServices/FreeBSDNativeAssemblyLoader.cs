/***********************************************************************************************************************
 * FileName:            FreeBSDNativeAssemblyLoader.cs
 * Copyright/License:   https://github.com/simplexidev/sdfx/blob/main/LICENSE.md
***********************************************************************************************************************/

using System.Runtime.InteropServices;
using System.Security;

namespace SimplexiDev.Runtime.InteropServices
{
    [SuppressUnmanagedCodeSecurity]
    internal unsafe class FreeBSDNativeAssemblyLoader : NativeAssemblyLoader
    {
        protected override void* CoreLoadNativeLibrary(string assemblyName) => dlopen(assemblyName, 0x002);
        protected override void* CoreLoadFunctionPointer(void* assembly, string funcName) => dlsym(assembly, funcName);
        protected override bool CoreFreeNativeLibrary(void* assembly) => dlclose(assembly);

        [DllImport("libdl.so.2")] internal static extern unsafe void* dlopen(string fileName, int flags);
        [DllImport("libdl.so.2")] internal static extern unsafe void* dlsym(void* handle, string name);
        [DllImport("libdl.so.2")] [return: MarshalAs(UnmanagedType.I1)] internal static extern unsafe bool dlclose(void* handle);
    }
}