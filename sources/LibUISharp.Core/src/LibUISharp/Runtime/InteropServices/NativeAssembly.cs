/***********************************************************************************************************************
 * FileName:            NativeAssembly.cs
 * Copyright/License:   https://github.com/tom-corwin/libuisharp/blob/master/LICENSE.md
***********************************************************************************************************************/

using System;
using System.Runtime.InteropServices;

using LibUISharp.Runtime;

namespace LibUISharp.Runtime.InteropServices
{
    //NOTE:https://rdrr.io/rforge/rdyncall/man/dynload.html
    //NOTE:https://github.com/mellinoe/nativelibraryloader/pull/11
    /// <summary>
    /// Represents a native shared library opened by the operating system.
    /// This type can be used to load native function pointers by name.
    /// </summary>
    public sealed unsafe class NativeAssembly : DisposableBase, IDisposable, IDisposableEx
    {
        private readonly NativeAssemblyLoader _loader;

        /// <summary>
        /// The operating system handle of the loaded library.
        /// </summary>
        public void* Handle { get; }

        /// <summary>
        /// Constructs a new NativeLibrary using the platform's default library loader.
        /// </summary>
        /// <param name="name">The name of the library to load.</param>
        public NativeAssembly(string name) : this(name, NativeAssemblyLoader.Default, NativeAssemblyResolver.Default) { }

        /// <summary>
        /// Constructs a new NativeLibrary using the platform's default library loader.
        /// </summary>
        /// <param name="names">An ordered list of names to attempt to load.</param>
        public NativeAssembly(string[] names) : this(names, NativeAssemblyLoader.Default, NativeAssemblyResolver.Default) { }

        /// <summary>
        /// Constructs a new NativeLibrary using the specified library loader.
        /// </summary>
        /// <param name="name">The name of the library to load.</param>
        /// <param name="loader">The loader used to open and close the library, and to load function pointers.</param>
        public NativeAssembly(string name, NativeAssemblyLoader loader) : this(name, loader, NativeAssemblyResolver.Default) { }

        /// <summary>
        /// Constructs a new NativeLibrary using the specified library loader.
        /// </summary>
        /// <param name="names">An ordered list of names to attempt to load.</param>
        /// <param name="loader">The loader used to open and close the library, and to load function pointers.</param>
        public NativeAssembly(string[] names, NativeAssemblyLoader loader) : this(names, loader, NativeAssemblyResolver.Default) { }

        /// <summary>
        /// Constructs a new NativeLibrary using the specified library loader.
        /// </summary>
        /// <param name="name">The name of the library to load.</param>
        /// <param name="loader">The loader used to open and close the library, and to load function pointers.</param>
        /// <param name="pathResolver">The path resolver, used to identify possible load targets for the library.</param>
        public NativeAssembly(string name, NativeAssemblyLoader loader, NativeAssemblyResolver pathResolver)
        {
            _loader = loader;
            Handle = _loader.LoadAssembly(name, pathResolver);
        }

        /// <summary>
        /// Constructs a new NativeLibrary using the specified library loader.
        /// </summary>
        /// <param name="names">An ordered list of names to attempt to load.</param>
        /// <param name="loader">The loader used to open and close the library, and to load function pointers.</param>
        /// <param name="pathResolver">The path resolver, used to identify possible load targets for the library.</param>
        public NativeAssembly(string[] names, NativeAssemblyLoader loader, NativeAssemblyResolver pathResolver)
        {
            _loader = loader;
            Handle = _loader.LoadAssembly(names, pathResolver);
        }

        /// <summary>
        /// Loads a function whose signature matches the given delegate type's signature.
        /// </summary>
        /// <typeparam name="T">The type of delegate to return.</typeparam>
        /// <param name="name">The name of the native export.</param>
        /// <returns>A delegate wrapping the native function.</returns>
        /// <exception cref="InvalidOperationException">Thrown when no function with the given name
        /// is exported from the native library.</exception>
        public T LoadFuncPtr<T>(string name)
        {
            IntPtr functionPtr = (IntPtr)_loader.LoadFunctionPointer(Handle, name);
            if (functionPtr == IntPtr.Zero)
                throw new InvalidOperationException($"No function was found with the name {name}.");
            return Marshal.GetDelegateForFunctionPointer<T>(functionPtr);
        }

        /// <summary>
        /// Loads a function pointer with the given name.
        /// </summary>
        /// <param name="name">The name of the native export.</param>
        /// <returns>A function pointer for the given name, or 0 if no function with that name exists.</returns>
        public IntPtr LoadFuncPtr(string name) => (IntPtr)(_loader.LoadFunctionPointer(Handle, name));

        /// <summary>
        /// Loads a function pointer with the given name.
        /// </summary>
        /// <param name="name">The name of the native export.</param>
        /// <returns>A function pointer for the given name, or 0 if no function with that name exists.</returns>
        public void* LoadUnsafeFuncPtr(string name) => _loader.LoadFunctionPointer(Handle, name);

        /// <inheritdoc/>
        protected override void ReleaseUnmanagedResources() => _loader.FreeNativeLibrary(Handle);
    }
}