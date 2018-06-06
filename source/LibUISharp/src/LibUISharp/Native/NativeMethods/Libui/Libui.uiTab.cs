using System;
using System.Runtime.InteropServices;

namespace LibUISharp.Native
{
    internal static partial class NativeMethods
    {
        internal static partial class Libui
        {
            // _UI_EXTERN void uiTabAppend(uiTab *t, const char *name, uiControl *c);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiTabAppend_t(IntPtr t, string name, IntPtr c);
            public static void uiTabAppend(IntPtr t, string name, IntPtr c) => FunctionLoader.LoadLibuiFunc<uiTabAppend_t>("uiTabAppend")(t, name, c);

            // _UI_EXTERN void uiTabInsertAt(uiTab *t, const char *name, int before, uiControl *c);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiTabInsertAt_t(IntPtr t, string name, int before, IntPtr c);
            public static void uiTabInsertAt(IntPtr t, string name, int before, IntPtr c) => FunctionLoader.LoadLibuiFunc<uiTabInsertAt_t>("uiTabInsertAt")(t, name, before, c);

            // _UI_EXTERN void uiTabDelete(uiTab *t, int index);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiTabDelete_t(IntPtr t, int index);
            public static void uiTabDelete(IntPtr t, int index) => FunctionLoader.LoadLibuiFunc<uiTabDelete_t>("uiTabDelete")(t, index);

            // _UI_EXTERN int uiTabNumPages(uiTab *t);
            [UnmanagedFunctionPointer(Convention)]
            private delegate int uiTabNumPages_t(IntPtr t);
            public static int uiTabNumPages(IntPtr t) => FunctionLoader.LoadLibuiFunc<uiTabNumPages_t>("uiTabNumPages")(t);

            // _UI_EXTERN int uiTabMargined(uiTab *t, int page);
            [UnmanagedFunctionPointer(Convention)]
            private delegate bool uiTabMargined_t(IntPtr t, int page);
            public static bool uiTabMargined(IntPtr t, int page) => FunctionLoader.LoadLibuiFunc<uiTabMargined_t>("uiTabMargined")(t, page);

            // _UI_EXTERN void uiTabSetMargined(uiTab *t, int page, int margined);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiTabSetMargined_t(IntPtr t, int page, bool margined);
            public static void uiTabSetMargined(IntPtr t, int page, bool margined) => FunctionLoader.LoadLibuiFunc<uiTabSetMargined_t>("uiTabSetMargined")(t, page, margined);

            // _UI_EXTERN uiTab *uiNewTab(void);
            [UnmanagedFunctionPointer(Convention)]
            private delegate IntPtr uiNewTab_t();
            public static IntPtr uiNewTab() => FunctionLoader.LoadLibuiFunc<uiNewTab_t>("uiNewTab")();
        }
    }
}