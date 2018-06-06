using LibUISharp.Drawing;
using System;
using System.Runtime.InteropServices;

namespace LibUISharp.Native
{
    internal static partial class NativeMethods
    {
        internal static partial class Libui
        {
            // _UI_EXTERN void uiAreaSetSize(uiArea *a, int width, int height);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiAreaSetSize_t(IntPtr a, int width, int height);
            public static void uiAreaSetSize(IntPtr a, int width, int height) => FunctionLoader.LoadLibuiFunc<uiAreaSetSize_t>("uiAreaSetSize")(a, width, height);

            // _UI_EXTERN void uiAreaQueueRedrawAll(uiArea *a);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiAreaQueueRedrawAll_t(IntPtr a);
            public static void uiAreaQueueRedrawAll(IntPtr a) => FunctionLoader.LoadLibuiFunc<uiAreaQueueRedrawAll_t>("uiAreaQueueRedrawAll")(a);

            // _UI_EXTERN void uiAreaScrollTo(uiArea *a, double x, double y, double width, double height);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiAreaScrollTo_t(IntPtr a, double x, double y, double width, double height);
            public static void uiAreaScrollTo(IntPtr a, double x, double y, double width, double height) => FunctionLoader.LoadLibuiFunc<uiAreaScrollTo_t>("uiAreaScrollTo")(a, x, y, width, height);

            // _UI_EXTERN void uiAreaBeginUserWindowMove(uiArea *a);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiAreaBeginUserWindowMove_t(IntPtr a);
            public static void uiAreaBeginUserWindowMove(IntPtr a) => FunctionLoader.LoadLibuiFunc<uiAreaBeginUserWindowMove_t>("uiAreaBeginUserWindowMove")(a);

            // _UI_EXTERN void uiAreaBeginUserWindowResize(uiArea *a, uiWindowResizeEdge edge);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiAreaBeginUserWindowResize_t(IntPtr a, WindowEdge edge);
            public static void uiAreaBeginUserWindowResize(IntPtr a, WindowEdge edge) => FunctionLoader.LoadLibuiFunc<uiAreaBeginUserWindowResize_t>("uiAreaBeginUserWindowResize")(a, edge);

            // _UI_EXTERN uiArea *uiNewArea(uiAreaHandler *ah);
            [UnmanagedFunctionPointer(Convention)]
            private delegate IntPtr uiNewArea_t(uiAreaHandler ah);
            public static IntPtr uiNewArea(uiAreaHandler ah) => FunctionLoader.LoadLibuiFunc<uiNewArea_t>("uiNewArea")(ah);

            // _UI_EXTERN uiArea *uiNewScrollingArea(uiAreaHandler *ah, int width, int height);
            [UnmanagedFunctionPointer(Convention)]
            private delegate IntPtr uiNewScrollingArea_t(uiAreaHandler ah, int width, int height);
            public static IntPtr uiNewScrollingArea(uiAreaHandler ah, int width, int height) => FunctionLoader.LoadLibuiFunc<uiNewScrollingArea_t>("uiNewScrollingArea")(ah, width, height);
        }
    }
}