using System;
using System.Runtime.InteropServices;

namespace LibUISharp.Native
{
    internal static partial class NativeMethods
    {
        internal static partial class Libui
        {
            // _UI_EXTERN char *uiGroupTitle(uiGroup *g);
            [UnmanagedFunctionPointer(Convention)]
            private delegate string uiGroupTitle_t(IntPtr g);
            public static string uiGroupTitle(IntPtr g) => FunctionLoader.LoadLibuiFunc<uiGroupTitle_t>("uiGroupTitle")(g);

            // _UI_EXTERN void uiGroupSetTitle(uiGroup *g, const char *title);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiGroupSetTitle_t(IntPtr g, string title);
            public static void uiGroupSetTitle(IntPtr g, string title) => FunctionLoader.LoadLibuiFunc<uiGroupSetTitle_t>("uiGroupSetTitle")(g, title);

            // _UI_EXTERN void uiGroupSetChild(uiGroup *g, uiControl *c);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiGroupSetChild_t(IntPtr g, IntPtr child);
            public static void uiGroupSetChild(IntPtr g, IntPtr child) => FunctionLoader.LoadLibuiFunc<uiGroupSetChild_t>("uiGroupSetChild")(g, child);

            // _UI_EXTERN int uiGroupMargined(uiGroup *g);
            [UnmanagedFunctionPointer(Convention)]
            private delegate bool uiGroupMargined_t(IntPtr g);
            public static bool uiGroupMargined(IntPtr g) => FunctionLoader.LoadLibuiFunc<uiGroupMargined_t>("uiGroupMargined")(g);

            // _UI_EXTERN void uiGroupSetMargined(uiGroup *g, int margined);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiGroupSetMargined_t(IntPtr g, bool margined);
            public static void uiGroupSetMargined(IntPtr g, bool margined) => FunctionLoader.LoadLibuiFunc<uiGroupSetMargined_t>("uiGroupSetMargined")(g, margined);

            // _UI_EXTERN uiGroup *uiNewGroup(const char *title);
            [UnmanagedFunctionPointer(Convention)]
            private delegate IntPtr uiNewGroup_t(string title);
            public static IntPtr uiNewGroup(string title) => FunctionLoader.LoadLibuiFunc<uiNewGroup_t>("uiNewGroup")(title);
        }
    }
}