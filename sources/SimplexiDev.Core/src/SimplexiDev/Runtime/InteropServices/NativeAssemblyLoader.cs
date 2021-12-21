/***********************************************************************************************************************
 * FileName:            NativeAssemblyLoader.cs
 * Copyright/License:   https://github.com/simplexidev/sdfx/blob/main/LICENSE.md
***********************************************************************************************************************/

using System;
using System.IO;

using SimplexiDev.Runtime;

namespace SimplexiDev.Runtime.InteropServices
{
    /// <summary>
    /// Exposes functionality for loading native libraries and function pointers.
    /// </summary>
    public abstract unsafe class NativeAssemblyLoader
    {
        /// <summary>
        /// Loads a native library by name and returns an operating system handle to it.
        /// </summary>
        /// <param name="name">The name of the library to open.</param>
        /// <returns>The operating system handle for the shared library.</returns>
        public void* LoadAssembly(string name) => LoadAssembly(name, NativeAssemblyResolver.Default);

        /// <summary>
        /// Loads a native library by name and returns an operating system handle to it.
        /// </summary>
        /// <param name="names">An ordered list of names. Each name is tried in turn, until the library is successfully loaded.
        /// </param>
        /// <returns>The operating system handle for the shared library.</returns>
        public void* LoadAssembly(string[] names) => LoadAssembly(names, NativeAssemblyResolver.Default);

        /// <summary>
        /// Loads a native library by name and returns an operating system handle to it.
        /// </summary>
        /// <param name="name">The name of the library to open.</param>
        /// <param name="pathResolver">The path resolver to use.</param>
        /// <returns>The operating system handle for the shared library.</returns>
        public void* LoadAssembly(string name, NativeAssemblyResolver pathResolver)
        {
            ArgumentNullException.ThrowIfNull(name, nameof(name));
            ArgumentNullException.ThrowIfNull(pathResolver, nameof(pathResolver));

            void* ret = null;

            if (Path.IsPathRooted(name))
                ret = CoreLoadNativeLibrary(name);
            else
            {
                foreach (string loadTarget in pathResolver.EnumeratePotentialLoadTargets(name))
                {
                    if (!Path.IsPathRooted(loadTarget) || File.Exists(loadTarget))
                        ret = CoreLoadNativeLibrary(loadTarget);
                    if (ret is not null)
                        break;
                }
            }

            return ret is not null ? ret : throw new FileNotFoundException("Could not find or load the native library: " + name);
        }

        /// <summary>
        /// Loads a native library by name and returns an operating system handle to it.
        /// </summary>
        /// <param name="names">An ordered list of names. Each name is tried in turn, until the library is successfully loaded.
        /// </param>
        /// <param name="pathResolver">The path resolver to use.</param>
        /// <returns>The operating system handle for the shared library.</returns>
        public void* LoadAssembly(string[] names, NativeAssemblyResolver pathResolver)
        {
            if (names == null || names.Length == 0)
                throw new ArgumentException("Parameter must not be null or empty.", nameof(names));

            void* ret = null;
            foreach (string name in names)
            {
                ret = LoadAssembly(name, pathResolver);
                if (ret is not null)
                    break;
            }

            return ret is not null ? ret : throw new FileNotFoundException($"Could not find or load the native library from any name: [ {string.Join(", ", names)} ]");
        }

        /// <summary>
        /// Loads a function pointer out of the given library by name.
        /// </summary>
        /// <param name="handle">The operating system handle of the opened shared library.</param>
        /// <param name="functionName">The name of the exported function to load.</param>
        /// <returns>A pointer to the loaded function.</returns>
        public void* LoadFunctionPointer(void* handle, string functionName)
        {
            return !string.IsNullOrEmpty(functionName)
                ? CoreLoadFunctionPointer(handle, functionName)
                : throw new ArgumentException("Parameter must not be null or empty.", nameof(functionName));
        }

        /// <summary>
        /// Frees the library represented by the given operating system handle.
        /// </summary>
        /// <param name="handle">The handle of the open shared library.</param>
        public bool FreeNativeLibrary(void* handle)
        {
            return handle is not null
                ? CoreFreeNativeLibrary(handle)
                : throw new ArgumentException("Parameter must not be zero.", nameof(handle));
        }

        /// <summary>
        /// Loads a native library by name and returns an operating system handle to it.
        /// </summary>
        /// <param name="name">The name of the library to open. This parameter must not be null or empty.</param>
        /// <returns>The operating system handle for the shared library.
        /// If the library cannot be loaded, IntPtr.Zero should be returned.</returns>
        protected abstract void* CoreLoadNativeLibrary(string name);

        /// <summary>
        /// Frees the library represented by the given operating system handle.
        /// </summary>
        /// <param name="handle">The handle of the open shared library. This must not be zero.</param>
        protected abstract bool CoreFreeNativeLibrary(void* handle);

        /// <summary>
        /// Loads a function pointer out of the given library by name.
        /// </summary>
        /// <param name="handle">The operating system handle of the opened shared library. This must not be zero.</param>
        /// <param name="functionName">The name of the exported function to load. This must not be null or empty.</param>
        /// <returns>A pointer to the loaded function.</returns>
        protected abstract void* CoreLoadFunctionPointer(void* handle, string functionName);

        /// <summary>
        /// Returns a default library loader for the running operating system.
        /// </summary>
        /// <returns>A NativeAssemblyLoader suitable for loading libraries.</returns>
        public static NativeAssemblyLoader Default =>
            Platform.IsWindows ? new WindowsNativeAssemblyLoader() :
                Platform.IsLinux ? new LinuxNativeAssemblyLoader() :
                Platform.IsMacOS ? new MacOSNativeAssemblyLoader() :
                Platform.IsFreeBSD ? new FreeBSDNativeAssemblyLoader() :
                throw new PlatformNotSupportedException("This platform cannot load native libraries.");
    }
}