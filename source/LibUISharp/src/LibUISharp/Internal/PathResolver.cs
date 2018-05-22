using Microsoft.DotNet.PlatformAbstractions;
using Microsoft.Extensions.DependencyModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace LibUISharp.Internal
{
    internal abstract class PathResolver
    {
        public abstract IEnumerable<string> EnumeratePossibleLibraryLoadTargets(string name);
        public static PathResolver Default => new DefaultPathResolver();
        public static PathResolver Embedded => new EmbeddedPathResolver();
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
            if (PlatformHelper.IsWinNT)
                return Environment.GetEnvironmentVariable("USERPROFILE");
            else
                return Environment.GetEnvironmentVariable("HOME");
        }
    }

    internal class EmbeddedPathResolver : PathResolver
    {
        private readonly string TempLibPath = Path.Combine(GetTempDirectory(), Assembly.GetExecutingAssembly().FullName, "res");

        public override IEnumerable<string> EnumeratePossibleLibraryLoadTargets(string name)
        {
            yield return TempLibPath;
            yield return name;

            if (TryGetNativeAssetFromAssembly(name, out string resolvedPath))
            {
                if (resolvedPath != TempLibPath)
                    yield return resolvedPath;
            }
        }

        private bool TryGetNativeAssetFromAssembly(string name, out string resolvedPath)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            MemoryStream ms = new MemoryStream();
            assembly.GetManifestResourceStream(name).CopyTo(ms);

            if (ms == null)
            {
                resolvedPath = null;
                return false;
            }

            if (File.Exists(TempLibPath + name))
                File.Delete(TempLibPath + name);

            try
            {
                File.WriteAllBytes(TempLibPath + name, ms.ToArray());
                ms.Close();
                resolvedPath = TempLibPath;
                return true;
            }
            catch
            {
                resolvedPath = null;
                return false;
            }
        }

        private static string GetTempDirectory()
        {
            if (PlatformHelper.IsWinNT)
                return Environment.GetEnvironmentVariable("TMP");
            else
                return Environment.GetEnvironmentVariable("TMPDIR");
        }
    }
}