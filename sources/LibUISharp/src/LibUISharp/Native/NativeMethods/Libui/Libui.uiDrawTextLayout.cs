using System;
using System.Runtime.InteropServices;

namespace LibUISharp.Native
{
    internal static partial class NativeMethods
    {
        internal static partial class Libui
        {
            // _UI_EXTERN uiDrawTextLayout *uiDrawNewTextLayout(uiDrawTextLayoutParams *params);
            [UnmanagedFunctionPointer(Convention)]
            private delegate IntPtr uiDrawNewTextLayout_t(uiDrawTextLayoutParams param);
            public static IntPtr uiDrawNewTextLayout(uiDrawTextLayoutParams param) => FunctionLoader.LoadLibuiFunc<uiDrawNewTextLayout_t>("uiDrawNewTextLayout")(param);

            // _UI_EXTERN void uiDrawFreeTextLayout(uiDrawTextLayout *tl);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiDrawFreeTextLayout_t(IntPtr tl);
            public static void uiDrawFreeTextLayout(IntPtr tl) => FunctionLoader.LoadLibuiFunc<uiDrawFreeTextLayout_t>("uiDrawFreeTextLayout")(tl);

            // _UI_EXTERN void uiDrawTextLayoutExtents(uiDrawTextLayout *tl, double *width, double *height);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiDrawTextLayoutExtents_t(IntPtr tl, out double width, out double height);
            public static void uiDrawTextLayoutExtents(IntPtr tl, out double width, out double height) => FunctionLoader.LoadLibuiFunc<uiDrawTextLayoutExtents_t>("uiDrawTextLayoutExtents")(tl, out width, out height);
        }
    }
}