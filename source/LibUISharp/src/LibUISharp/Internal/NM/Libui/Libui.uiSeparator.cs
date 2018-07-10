using System;
using System.Runtime.InteropServices;

namespace LibUISharp.Internal
{
    internal static partial class NM
    {
        // _UI_EXTERN uiSeparator *uiNewHorizontalSeparator(void);
        [UnmanagedFunctionPointer(Convention)]
        internal delegate IntPtr uiNewHorizontalSeparator();

        // _UI_EXTERN uiSeparator *uiNewVerticalSeparator(void);
        [UnmanagedFunctionPointer(Convention)]
        internal delegate IntPtr uiNewVerticalSeparator();
    }
}