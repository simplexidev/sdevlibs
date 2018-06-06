using System;
using System.Runtime.InteropServices;

namespace LibUISharp.Native
{
    internal static partial class NativeMethods
    {
        internal static partial class Libui
        {
            // _UI_EXTERN void uiBoxAppend(uiBox *b, uiControl *child, int stretchy);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiBoxAppend_t(IntPtr b, IntPtr child, bool stretchy);
            public static void uiBoxAppend(IntPtr b, IntPtr child, bool stretchy) => FunctionLoader.LoadLibuiFunc<uiBoxAppend_t>("uiBoxAppend")(b, child, stretchy);

            // _UI_EXTERN void uiBoxDelete(uiBox *b, int index);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiBoxDelete_t(IntPtr b, int index);
            public static void uiBoxDelete(IntPtr b, int index) => FunctionLoader.LoadLibuiFunc<uiBoxDelete_t>("uiBoxDelete")(b, index);

            // _UI_EXTERN int uiBoxPadded(uiBox *b);
            [UnmanagedFunctionPointer(Convention)]
            private delegate bool uiBoxPadded_t(IntPtr b);
            public static bool uiBoxPadded(IntPtr b) => FunctionLoader.LoadLibuiFunc<uiBoxPadded_t>("uiBoxPadded")(b);

            // _UI_EXTERN void uiBoxSetPadded(uiBox *b, int padded);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiBoxSetPadded_t(IntPtr b, bool padded);
            public static void uiBoxSetPadded(IntPtr b, bool padded) => FunctionLoader.LoadLibuiFunc<uiBoxSetPadded_t>("uiBoxSetPadded")(b, padded);

            // _UI_EXTERN uiBox *uiNewHorizontalBox(void);
            [UnmanagedFunctionPointer(Convention)]
            private delegate IntPtr uiNewHorizontalBox_t();
            public static IntPtr uiNewHorizontalBox() => FunctionLoader.LoadLibuiFunc<uiNewHorizontalBox_t>("uiNewHorizontalBox")();

            // _UI_EXTERN uiBox *uiNewVerticalBox(void);
            [UnmanagedFunctionPointer(Convention)]
            private delegate IntPtr uiNewVerticalBox_t();
            public static IntPtr uiNewVerticalBox() => FunctionLoader.LoadLibuiFunc<uiNewVerticalBox_t>("uiNewVerticalBox")();
        }
    }
}