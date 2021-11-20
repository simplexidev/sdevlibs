using System;
using System.Runtime.InteropServices;

namespace LibUISharp.Native
{
    internal static partial class NativeMethods
    {
        internal static partial class Libui
        {
            // _UI_EXTERN void uiGridAppend(uiGrid* g, uiControl* c, int left, int top, int xspan, int yspan, int hexpand, uiAlign halign, int vexpand, uiAlign valign);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiGridAppend_t(IntPtr g, IntPtr c, int left, int top, int xspan, int yspan, int hexpand, uiAlign halign, int vexpand, uiAlign valign);
            public static void uiGridAppend(IntPtr g, IntPtr c, int left, int top, int xspan, int yspan, int hexpand, uiAlign halign, int vexpand, uiAlign valign) => FunctionLoader.LoadLibuiFunc<uiGridAppend_t>("uiGridAppend")(g, c, left, top, xspan, yspan, hexpand, halign, vexpand, valign);

            // _UI_EXTERN void uiGridInsertAt(uiGrid* g, uiControl* c, uiControl* existing, uiAt at, int xspan, int yspan, int hexpand, uiAlign halign, int vexpand, uiAlign valign);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiGridInsertAt_t(IntPtr g, IntPtr c, IntPtr existing, RelativeAlignment at, int xspan, int yspan, int hexpand, uiAlign halign, int vexpand, uiAlign valign);
            public static void uiGridInsertAt(IntPtr g, IntPtr c, IntPtr existing, RelativeAlignment at, int xspan, int yspan, int hexpand, uiAlign halign, int vexpand, uiAlign valign) => FunctionLoader.LoadLibuiFunc<uiGridInsertAt_t>("uiGridInsertAt")(g, c, existing, at, xspan, yspan, hexpand, halign, vexpand, valign);

            // _UI_EXTERN int uiGridPadded(uiGrid* g);
            [UnmanagedFunctionPointer(Convention)]
            private delegate bool uiGridPadded_t(IntPtr g);
            public static bool uiGridPadded(IntPtr g) => FunctionLoader.LoadLibuiFunc<uiGridPadded_t>("uiGridPadded")(g);

            // _UI_EXTERN void uiGridSetPadded(uiGrid* g, int padded);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiGridSetPadded_t(IntPtr g, bool padded);
            public static void uiGridSetPadded(IntPtr g, bool padded) => FunctionLoader.LoadLibuiFunc<uiGridSetPadded_t>("uiGridSetPadded")(g, padded);

            // _UI_EXTERN uiGrid *uiNewGrid(void);
            [UnmanagedFunctionPointer(Convention)]
            private delegate IntPtr uiNewGrid_t();
            public static IntPtr uiNewGrid() => FunctionLoader.LoadLibuiFunc<uiNewGrid_t>("uiNewGrid")();
        }
    }
}