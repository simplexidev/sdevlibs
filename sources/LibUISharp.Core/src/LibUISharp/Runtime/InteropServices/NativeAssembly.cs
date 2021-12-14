/***********************************************************************************************************************
 * FileName:            NativeAssembly.cs
 * Copyright/License:   https://github.com/tom-corwin/libuisharp/blob/master/LICENSE.md
***********************************************************************************************************************/

using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace LibUISharp.Runtime.InteropServices
{
    //NOTE:https://rdrr.io/rforge/rdyncall/man/dynload.html
    //NOTE:https://github.com/mellinoe/nativelibraryloader/pull/11
    /// <summary>
    /// Represents a native (shared) assembly.
    /// </summary>
    public sealed unsafe class NativeAssembly : NativeComponent
    {
        private NativeAssemblyLoader asmLoader;

        /// <summary>
        /// Initializes a new instance of the <see cref="NativeLibrary"/> class with the current platform's default <see cref="NativeAssemblyLoader"/>.
        /// </summary>
        /// <param name="name">The name of the assembly to load.</param>
        public NativeAssembly(string name) : this(name, NativeAssemblyLoader.Default, NativeAssemblyResolver.Default) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="NativeLibrary"/> class with the current platform's default <see cref="NativeAssemblyLoader"/>.
        /// </summary>
        /// <param name="names">An ordered list of assembly names to attempt to load.</param>
        public NativeAssembly(string[] names) : this(names, NativeAssemblyLoader.Default, NativeAssemblyResolver.Default) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="NativeLibrary"/> class with the specified <see cref="NativeAssemblyLoader"/>.
        /// </summary>
        /// <param name="name">The name of the assembly to load.</param>
        /// <param name="loader">The loader used to open and close the assembly, and to load function pointers.</param>
        public NativeAssembly(string name, NativeAssemblyLoader loader) : this(name, loader, NativeAssemblyResolver.Default) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="NativeLibrary"/> class with the specified <see cref="NativeAssemblyLoader"/>.
        /// </summary>
        /// <param name="names">An ordered list of assembly names to attempt to load.</param>
        /// <param name="loader">The loader used to open and close the assembly, and to load function pointers.</param>
        public NativeAssembly(string[] names, NativeAssemblyLoader loader) : this(names, loader, NativeAssemblyResolver.Default) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="NativeLibrary"/> class with the specified <see cref="NativeAssemblyLoader"/>.
        /// </summary>
        /// <param name="name">The name of the assembly to load.</param>
        /// <param name="loader">The loader used to open and close the assembly, and to load function pointers.</param>
        /// <param name="pathResolver">The path resolver, used to identify possible load targets for the assembly.</param>
        public NativeAssembly(string name, NativeAssemblyLoader loader, NativeAssemblyResolver pathResolver) : base(name, loader, pathResolver) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="NativeLibrary"/> class with the specified <see cref="NativeAssemblyLoader"/>.
        /// </summary>
        /// <param name="names">An ordered list of assembly names to attempt to load.</param>
        /// <param name="loader">The loader used to open and close the assembly, and to load function pointers.</param>
        /// <param name="pathResolver">The path resolver, used to identify possible load targets for the assembly.</param>
        public NativeAssembly(string[] names, NativeAssemblyLoader loader, NativeAssemblyResolver pathResolver) : base(names, loader, pathResolver) { }

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
            IntPtr functionPtr = (IntPtr)asmLoader.LoadFunctionPointer(Handle.ToPointer(), name);
            return functionPtr != IntPtr.Zero
                ? Marshal.GetDelegateForFunctionPointer<T>(functionPtr)
                : throw new InvalidOperationException($"No function was found with the name {name}.");
        }

        /// <summary>
        /// Loads a function pointer with the given name.
        /// </summary>
        /// <param name="name">The name of the native export.</param>
        /// <returns>A function pointer for the given name, or 0 if no function with that name exists.</returns>
        public IntPtr LoadFuncPtr(string name) => (IntPtr)asmLoader.LoadFunctionPointer(Handle.ToPointer(), name);

        /// <summary>
        /// Loads a function pointer with the given name.
        /// </summary>
        /// <param name="name">The name of the native export.</param>
        /// <returns>A function pointer for the given name, or 0 if no function with that name exists.</returns>
        public void* LoadUnsafeFuncPtr(string name) => asmLoader.LoadFunctionPointer(Handle.ToPointer(), name);

        /// <inheritdoc/>
        protected override void StartInitialization(params object[] args)
        {
            base.StartInitialization(args);
            asmLoader = args.Length == 3
                ? (NativeAssemblyLoader)args[1]
                : (NativeAssemblyLoader)args.SkipLast(1).ToArray()[args.Length - 2];
        }

        /// <inheritdoc/>
        protected override void CreateHandle(params object[] args)
        {
            Handle = (IntPtr)(args.Length == 3
                ? asmLoader.LoadAssembly((string)args[0], (NativeAssemblyResolver)args[2])
                : asmLoader.LoadAssembly((string[])args.SkipLast(2).ToArray(), (NativeAssemblyResolver)args[^1]));
            base.CreateHandle(args);
        }

        /// <inheritdoc/>
        protected override void DestroyHandle()
        {
            _ = asmLoader.FreeNativeLibrary((void*)Handle);
            base.DestroyHandle();
        }
    }
}