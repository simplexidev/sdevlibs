/***********************************************************************************************************************
 * FileName:            Platform.cs
 * Copyright/License:   https://github.com/tom-corwin/libuisharp/blob/master/LICENSE.md
***********************************************************************************************************************/

using Microsoft.Extensions.DependencyModel;

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace LibUISharp.Runtime
{
    /// <summary>
    /// Provides static members providing information about the current running platform.
    /// </summary>
    public static class Platform
    {
        /// <summary>
        /// Gets a value determining if the current architecture 32-bit.
        /// </summary>
        public static bool Is32Bit => RuntimeInformation.OSArchitecture == Architecture.X86;

        /// <summary>
        /// Gets a value determining if the current architecture 64-bit.
        /// </summary>
        public static bool Is64Bit => RuntimeInformation.OSArchitecture == Architecture.X64;

        /// <summary>
        /// Gets a value determining if the current architecture 32-bit ARM.
        /// </summary>
        public static bool IsARM32Bit => RuntimeInformation.OSArchitecture == Architecture.Arm;

        /// <summary>
        /// Gets a value determining if the current architecture 64-bit ARM.
        /// </summary>
        public static bool IsARM64Bit => RuntimeInformation.OSArchitecture == Architecture.Arm64;

        /// <summary>
        /// Gets a value determining if the current architecture WASM.
        /// </summary>
        public static bool IsWASM => RuntimeInformation.OSArchitecture == Architecture.Wasm;

        /// <summary>
        /// Gets a value determining if the current operating system is Windows-based.
        /// </summary>
        public static bool IsWindows => OperatingSystem.IsWindows();

        /// <summary>
        /// Gets a value determining if the current operating system is Linux-based.
        /// </summary>
        public static bool IsLinux => OperatingSystem.IsLinux();

        /// <summary>
        /// Gets a value determining if the current operating system is macOS-based.
        /// </summary>
        public static bool IsMacOS => OperatingSystem.IsMacOS();

        /// <summary>
        /// Gets a value determining if the current operating system is FreeBSD-based.
        /// </summary>
        public static bool IsFreeBSD => OperatingSystem.IsFreeBSD();

        /// <summary>
        /// Gets a value determining if the current operating system is Browser-based.
        /// </summary>
        public static bool IsBrowser => OperatingSystem.IsBrowser();

        /// <summary>
        /// Gets a value determining if the current operating system is Android-based.
        /// </summary>
        public static bool IsAndroid => OperatingSystem.IsAndroid();

        /// <summary>
        /// Gets a value determining if the current operating system is iOS-based.
        /// </summary>
        public static bool IsIOS => OperatingSystem.IsIOS();

        /// <summary>
        /// Gets a value determining if the current platform is a desktop operating system.
        /// </summary>
        public static bool IsDesktop => IsWindows || IsMacOS || IsLinux || IsFreeBSD;

        /// <summary>
        /// Gets a value determining if the current platform is a browser.
        /// </summary>
        public static bool IsWeb => IsBrowser;

        /// <summary>
        /// Gets a value determining if the current platform is a mobile operating system.
        /// </summary>
        public static bool IsMobile => IsAndroid || IsIOS;

        /// <summary>
        /// Gets the runtime identifier for the current platform.
        /// </summary>
        public static string RuntimeID => RuntimeInformation.RuntimeIdentifier;

        /// <summary>
        /// Gets the fallback runtime identifiers for this platform.
        /// </summary>
        public static IList<string> FallbackRuntimeIDs
        {
            get
            {
                List<string> retVal = new();
                foreach (RuntimeFallbacks fallbacks in DependencyContext.Default.RuntimeGraph)
                    if (fallbacks.Runtime == RuntimeID)
                        retVal.AddRange(fallbacks.Fallbacks);
                return retVal;
            }
        }
    }
}