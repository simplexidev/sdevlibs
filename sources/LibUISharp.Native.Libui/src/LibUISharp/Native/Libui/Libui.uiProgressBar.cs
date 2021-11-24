using System;
using System.Runtime.InteropServices;

namespace LibUISharp.Native
{
    internal static partial class NativeMethods
    {
        internal static partial class Libui
        {
            // _UI_EXTERN int uiProgressBarValue(uiProgressBar* p);
            [UnmanagedFunctionPointer(Convention)]
            private delegate int uiProgressBarValue_t(IntPtr p);
            public static int uiProgressBarValue(IntPtr p) => FunctionLoader.LoadLibuiFunc<uiProgressBarValue_t>("uiProgressBarValue")(p);

            // _UI_EXTERN void uiProgressBarSetValue(uiProgressBar* p, int n);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiProgressBarSetValue_t(IntPtr p, int n);
            public static void uiProgressBarSetValue(IntPtr p, int n) => FunctionLoader.LoadLibuiFunc<uiProgressBarSetValue_t>("uiProgressBarSetValue")(p, n);

            // _UI_EXTERN uiProgressBar * uiNewProgressBar(void);
            [UnmanagedFunctionPointer(Convention)]
            private delegate IntPtr uiNewProgressBar_t();
            public static IntPtr uiNewProgressBar() => FunctionLoader.LoadLibuiFunc<uiNewProgressBar_t>("uiNewProgressBar")();
        }
    }
}