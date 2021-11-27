/***********************************************************************************************************************
 * FileName:            DefaultNativeAssemblyResolver.cs
 * Copyright/License:   https://github.com/tom-corwin/libuisharp/blob/master/LICENSE.md
***********************************************************************************************************************/

using Microsoft.Extensions.DependencyModel;

using System;
using System.Collections.Generic;
using System.IO;

namespace LibUISharp.Runtime.InteropServices
{
    /// <summary>
    /// Represents the default <see cref="NativeAssemblyResolver"/>.
    /// </summary>
    internal sealed class DefaultNativeAssemblyResolver : NativeAssemblyResolver
    {
        /// <inheritdoc/>
        public override IEnumerable<string> EnumeratePotentialLoadTargets(string name)
        {
            if (!string.IsNullOrEmpty(AppContext.BaseDirectory))
                yield return Path.Combine(AppContext.BaseDirectory, name);
            yield return name;
            if (TryGetNativeAssetFromDeps(name, out string appLocalNativePath, out string depsResolvedPath))
            {
                yield return appLocalNativePath;
                yield return depsResolvedPath;
            }
        }

        private static bool TryGetNativeAssetFromDeps(string name, out string appLocalNativePath, out string depsResolvedPath)
        {
            DependencyContext defaultContext = DependencyContext.Default;

            if (defaultContext != null)
            {
                List<string> allRIDs = new() { Platform.RuntimeID };
                _ = AddFallbacks(ref allRIDs, Platform.RuntimeID, defaultContext.RuntimeGraph);

                foreach (string rid in allRIDs)
                {
                    foreach (var runtimeLib in defaultContext.RuntimeLibraries)
                    {
                        foreach (var nativeAsset in runtimeLib.GetRuntimeNativeAssets(defaultContext, rid))
                        {
                            if (Path.GetFileName(nativeAsset) == name || Path.GetFileNameWithoutExtension(nativeAsset) == name)
                            {
                                appLocalNativePath = Path.Combine(AppContext.BaseDirectory, nativeAsset);
                                appLocalNativePath = Path.GetFullPath(appLocalNativePath);
                                depsResolvedPath = Path.Combine(GetNugetPackagesRootDirectory(), runtimeLib.Name.ToLowerInvariant(), runtimeLib.Version, nativeAsset);
                                depsResolvedPath = Path.GetFullPath(depsResolvedPath);

                                return true;
                            }
                        }
                    }
                }
            }

            appLocalNativePath = null;
            depsResolvedPath = null;
            return false;
        }

        private static bool AddFallbacks(ref List<string> fallbacks, string rid, IReadOnlyList<RuntimeFallbacks> allFallbacks)
        {
            foreach (RuntimeFallbacks fb in allFallbacks)
            {
                if (fb.Runtime == rid)
                {
                    fallbacks.AddRange(fb.Fallbacks);
                    return true;
                }
            }

            return false;
        }

        //TODO: Handle alternative package directories, if they are configured.
        private static string GetNugetPackagesRootDirectory() => Path.Combine(GetUserDirectory(), ".nuget", "packages");

        //TODO: Verify `HOME` is correct for macOS and FreeBSD.
        private static string GetUserDirectory() => Platform.IsWindows ? Environment.GetEnvironmentVariable("USERPROFILE") : Environment.GetEnvironmentVariable("HOME");
    }
}