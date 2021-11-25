/***********************************************************************************************************************
 * FileName:            WindowsNativeAssemblyLoader.cs
 * Copyright/License:   https://github.com/tom-corwin/libuisharp/blob/master/LICENSE.md
***********************************************************************************************************************/

using System.Runtime.InteropServices;
using System.Security;

namespace LibUISharp.Runtime.InteropServices
{
    [SuppressUnmanagedCodeSecurity]
    internal unsafe class WindowsNativeAssemblyLoader : NativeAssemblyLoader
    {
        protected override void* CoreLoadNativeLibrary(string assemblyName) => LoadLibrary(assemblyName);
        protected override void* CoreLoadFunctionPointer(void* assembly, string funcName) => GetProcAddress(assembly, funcName);
        protected override bool CoreFreeNativeLibrary(void* assembly) => FreeLibrary(assembly);

        [DllImport("kernel32")] private static unsafe extern void* LoadLibrary(string name);
        [DllImport("kernel32")] private static unsafe extern void* GetProcAddress(void* handle, string procName);
        [DllImport("kernel32")] [return: MarshalAs(UnmanagedType.Bool)] private static unsafe extern bool FreeLibrary(void* handle);
    }
}