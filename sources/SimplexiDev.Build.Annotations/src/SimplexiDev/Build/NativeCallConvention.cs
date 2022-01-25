/***********************************************************************************************************************
 * FileName:            NativeCallConvention.cs
 * Copyright/License:   https://github.com/simplexidev/sdfx/blob/main/LICENSE.md
***********************************************************************************************************************/

namespace SimplexiDev.Build
{
    /// <summary>
    /// Specifies the calling convention required to call methods implemented in unmanaged code.
    /// </summary>
    public enum NativeCallConvention
    {
        /// <summary>
        /// The caller cleans the stack.
        /// </summary>
        Cdecl = 2,

        /// <summary>
        /// The callee cleans the stack.
        /// </summary>
        StdCall = 3,

        /// <summary>
        /// The first parameter is the this pointer and is stored in register ECX. Other parameters are pushed on the stack.
        /// </summary>
        ThisCall = 4,
    }
}