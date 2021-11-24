using System;
using System.Runtime.InteropServices;

namespace LibUISharp.Native
{
    internal static partial class NativeMethods
    {
        internal static partial class Libui
        {
            // _UI_EXTERN uiSeparator *uiNewHorizontalSeparator(void);
            [UnmanagedFunctionPointer(Convention)]
            private delegate IntPtr uiNewHorizontalSeparator_t();
            public static IntPtr uiNewHorizontalSeparator() => FunctionLoader.LoadLibuiFunc<uiNewHorizontalSeparator_t>("uiNewHorizontalSeparator")();

            // _UI_EXTERN uiSeparator *uiNewVerticalSeparator(void);
            [UnmanagedFunctionPointer(Convention)]
            private delegate IntPtr uiNewVerticalSeparator_t();
            public static IntPtr uiNewVerticalSeparator() => FunctionLoader.LoadLibuiFunc<uiNewVerticalSeparator_t>("uiNewVerticalSeparator")();
        }
    }
}