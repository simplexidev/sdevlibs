using System.Runtime.InteropServices;

namespace LibUISharp.Internal
{
    internal static class PlatformHelper
    {
        public static bool IsWinNT = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
        public static bool IsMacOS = RuntimeInformation.IsOSPlatform(OSPlatform.OSX);
        public static bool IsLinux = RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
        public static bool IsUnix = (IsMacOS || IsLinux);
    }
}