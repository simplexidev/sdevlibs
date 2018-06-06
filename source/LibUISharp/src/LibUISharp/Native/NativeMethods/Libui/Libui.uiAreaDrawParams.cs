using System;
using System.Runtime.InteropServices;

namespace LibUISharp.Native
{
    internal static partial class NativeMethods
    {
        internal static partial class Libui
        {
            [StructLayout(Layout)]
            internal struct uiAreaDrawParams
            {
                public IntPtr Context;

                //! Only defined for non-scrolling areas.
                public double AreaWidth;
                public double AreaHeight;

                public double ClipX;
                public double ClipY;
                public double ClipWidth;
                public double ClipHeight;
            }
        }
    }
}