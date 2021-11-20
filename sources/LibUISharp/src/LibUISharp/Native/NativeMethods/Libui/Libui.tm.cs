using System.Runtime.InteropServices;

namespace LibUISharp.Native
{
    internal static partial class NativeMethods
    {
        internal static partial class Libui
        {
            [StructLayout(Layout)]
            public struct tm
            {
                public int tm_sec;
                public int tm_min;
                public int tm_hour;
                public int tm_mday;
                public int tm_mon;
                public int tm_year;
                public int tm_wday; // undefined
                public int tm_yday; // undefined
                public int tm_isdst; // -1
            }
        }
    }
}