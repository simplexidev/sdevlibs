using System;

namespace LibUISharp.Build
{
    /// <summary>
    /// Indicates that the attributed class contains methods marked with the <see cref="NativeCallAttribute"/>.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class NativeAssemblyAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NativeAssemblyAttribute"/> with the specified assembly name.
        /// </summary>
        /// <param name="name">The assembly name to load, without the file extension.</param>
        public NativeAssemblyAttribute(string name) : this(name, NativeAssemblyFormats.All) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="NativeAssemblyAttribute"/> with the specified assembly name and file extensions.
        /// </summary>
        /// <param name="name">The assembly name to load, without the file extension.</param>
        /// <param name="formats">The format(s) of native assemblies to load.</param>
        public NativeAssemblyAttribute(string name, NativeAssemblyFormats formats)
        {
            Name = name;
            Formats = formats;
        }
        
        /// <summary>
        /// The name of the assembly to load, without the file extension.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// indeicates the formats the native assembly may be.
        /// </summary>
        public NativeAssemblyFormats Formats { get; }

        /// <summary>
        /// Indicates the calling convention of an entry point.
        /// </summary>
        public NativeCallConvention CallConvention { get; init; } = NativeCallConvention.Cdecl;
    }
}