using System;

namespace LibUISharp.Build
{
    /// <summary>
    /// Identifies the file formats of a native assembly.
    /// </summary>
    [Flags]
    public enum NativeAssemblyFormats
    {
        /// <summary>
        /// Specifies the assembly may be in a Windows format.
        /// </summary>
        Windows = 1,

        /// <summary>
        /// Specifies the assembly may be in a MacOS format.
        /// </summary>
        MacOS = 2,

        /// <summary>
        /// Specifies the assembly may be in a Linux format.
        /// </summary>
        Linux = 4,

        /// <summary>
        /// Specifies the assembly may be in any supported format.
        /// </summary>
        All = 128
    }
}