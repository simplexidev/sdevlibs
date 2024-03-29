﻿/***********************************************************************************************************************
 * FileName:            NativeAssemblyResolver.cs
 * Copyright/License:   https://github.com/simplexidev/sdfx/blob/main/LICENSE.md
***********************************************************************************************************************/

using System.Collections.Generic;

namespace SimplexiDev.Runtime.InteropServices
{
    /// <summary>
    /// Provides an enumeration of potential native assembly load targets.
    /// </summary>
    public abstract class NativeAssemblyResolver
    {
        /// <summary>
        /// Gets the default native assembly resolver.
        /// </summary>
        public static NativeAssemblyResolver Default => new DefaultNativeAssemblyResolver();

        /// <summary>
        /// Returns an enumerator yielding potential native assembly load targets, in priority order.
        /// </summary>
        /// <param name="name">The filename (without the file extension) of the native assembly to load.<param>
        /// <returns> An enumerator yielding potential native assembly load targets, in priority order.</returns>
        public abstract IEnumerable<string> EnumeratePotentialLoadTargets(string name);
    }
}