using Microsoft.DotNet.PlatformAbstractions;
using Microsoft.Extensions.DependencyModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace LibUISharp.Native
{
    internal abstract class PathResolver
    {
        public abstract IEnumerable<string> EnumeratePossibleLibraryLoadTargets(string name);
        public static PathResolver Default { get; } = new DefaultPathResolver();
    }
    
    internal class DefaultPathResolver : PathResolver
    {
        public override IEnumerable<string> EnumeratePossibleLibraryLoadTargets(string name)
        {
            yield return Path.Combine(AppContext.BaseDirectory, name);
            yield return name;
            if (TryLocateNativeAssetFromDeps(name, out string depsResolvedPath))
                yield return depsResolvedPath;
        }

        private bool TryLocateNativeAssetFromDeps(string name, out string depsResolvedPath)
        {
            DependencyContext defaultContext = DependencyContext.Default;
            if (defaultContext == null)
            {
                depsResolvedPath = null;
                return false;
            }

            string currentRID = RuntimeEnvironment.GetRuntimeIdentifier();
            List<string> allRIDs = new List<string> { currentRID };
            if (!AddFallbacks(allRIDs, currentRID, defaultContext.RuntimeGraph))
            {
                string guessedFallbackRID = GuessFallbackRID(currentRID);
                if (guessedFallbackRID != null)
                {
                    allRIDs.Add(guessedFallbackRID);
                    AddFallbacks(allRIDs, guessedFallbackRID, defaultContext.RuntimeGraph);
                }
            }

            foreach (string rid in allRIDs)
            {
                foreach (RuntimeLibrary runtimeLib in defaultContext.RuntimeLibraries)
                {
                    foreach (string nativeAsset in runtimeLib.GetRuntimeNativeAssets(defaultContext, rid))
                    {
                        if (Path.GetFileName(nativeAsset) == name || Path.GetFileNameWithoutExtension(nativeAsset) == name)
                        {
                            string fullPath = Path.Combine(GetNugetPackagesRootDirectory(), runtimeLib.Name.ToLowerInvariant(), runtimeLib.Version, nativeAsset);
                            fullPath = Path.GetFullPath(fullPath);
                            depsResolvedPath = fullPath;
                            return true;
                        }
                    }
                }
            }

            depsResolvedPath = null;
            return false;
        }

        private string GuessFallbackRID(string actualRuntimeIdentifier)
        {
            if (actualRuntimeIdentifier == "osx.10.13-x64")
                return "osx.10.12-x64";
            else if (actualRuntimeIdentifier.StartsWith("osx"))
                return "osx-x64";
            return null;
        }

        private bool AddFallbacks(List<string> fallbacks, string rid, IReadOnlyList<RuntimeFallbacks> allFallbacks)
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

        // TODO: Handle alternative package directories, if they are configured.
        private string GetNugetPackagesRootDirectory() => Path.Combine(GetUserDirectory(), ".nuget", "packages");

        private string GetUserDirectory()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return Environment.GetEnvironmentVariable("USERPROFILE");
            else
                return Environment.GetEnvironmentVariable("HOME");
        }
    }
}