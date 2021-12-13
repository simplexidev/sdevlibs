using System;

namespace LibUISharp.CodeAnalysis
{
    /// <summary>
    /// Indicates that the attributed method is exposed by an unmanaged dynamic-link library (DLL) as a static entry point.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public sealed class NativeCallAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NativeCallAttribute"/> class, inheriting the name of the decorated method.
        /// </summary>
        public NativeCallAttribute() : this(string.Empty) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="NativeCallAttribute"/> class with the name of the method to import.
        /// </summary>
        public NativeCallAttribute(string entryPoint) => EntryPoint = entryPoint;

        /// <summary>
        /// Indicates the name or ordinal of the native entry point to be called.
        /// </summary>
        public string EntryPoint { get; }

        /// <summary>
        /// Indicates the calling convention of an entry point.
        /// </summary>
        public NativeCallConvention CallConvention { get; init; } = NativeCallConvention.Cdecl;
    }
}