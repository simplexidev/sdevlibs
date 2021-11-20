using System;
using System.Runtime.InteropServices;

namespace LibUISharp.Native
{
    internal static partial class NativeMethods
    {
        internal static partial class Libui
        {
            // _UI_EXTERN void uiMenuItemEnable(uiMenuItem *m);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiMenuItemEnable_t(IntPtr m);
            public static void uiMenuItemEnable(IntPtr m) => FunctionLoader.LoadLibuiFunc<uiMenuItemEnable_t>("uiMenuItemEnable")(m);

            // _UI_EXTERN void uiMenuItemDisable(uiMenuItem *m);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiMenuItemDisable_t(IntPtr m);
            public static void uiMenuItemDisable(IntPtr m) => FunctionLoader.LoadLibuiFunc<uiMenuItemDisable_t>("uiMenuItemDisable")(m);

            // _UI_EXTERN void uiMenuItemOnClicked(uiMenuItem *m, void (*f)(uiMenuItem *sender, uiWindow *window, void *data), void *data);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiMenuItemOnClicked_t(IntPtr m, uiMenuItemOnClicked_tf f, IntPtr data);
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void uiMenuItemOnClicked_tf(IntPtr menuItem, IntPtr window, IntPtr data);
            public static void uiMenuItemOnClicked(IntPtr m, uiMenuItemOnClicked_tf f, IntPtr data) => FunctionLoader.LoadLibuiFunc<uiMenuItemOnClicked_t>("uiMenuItemOnClicked")(m, f, data);

            // _UI_EXTERN int uiMenuItemChecked(uiMenuItem *m);
            [UnmanagedFunctionPointer(Convention)]
            private delegate bool uiMenuItemChecked_t(IntPtr m);
            public static bool uiMenuItemChecked(IntPtr m) => FunctionLoader.LoadLibuiFunc<uiMenuItemChecked_t>("uiMenuItemChecked")(m);

            // _UI_EXTERN void uiMenuItemSetChecked(uiMenuItem *m, int checked);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiMenuItemSetChecked_t(IntPtr m, bool @checked);
            public static void uiMenuItemSetChecked(IntPtr m, bool @checked) => FunctionLoader.LoadLibuiFunc<uiMenuItemSetChecked_t>("uiMenuItemSetChecked")(m, @checked);

            // _UI_EXTERN uiMenuItem *uiMenuAppendItem(uiMenu *m, const char *name);
            [UnmanagedFunctionPointer(Convention)]
            private delegate IntPtr uiMenuAppendItem_t(IntPtr m, string name);
            public static IntPtr uiMenuAppendItem(IntPtr m, string name) => FunctionLoader.LoadLibuiFunc<uiMenuAppendItem_t>("uiMenuAppendItem")(m, name);

            // _UI_EXTERN uiMenuItem *uiMenuAppendCheckItem(uiMenu *m, const char *name);
            [UnmanagedFunctionPointer(Convention)]
            private delegate IntPtr uiMenuAppendCheckItem_t(IntPtr m, string name);
            public static IntPtr uiMenuAppendCheckItem(IntPtr m, string name) => FunctionLoader.LoadLibuiFunc<uiMenuAppendCheckItem_t>("uiMenuAppendCheckItem")(m, name);

            // _UI_EXTERN uiMenuItem *uiMenuAppendQuitItem(uiMenu *m);
            [UnmanagedFunctionPointer(Convention)]
            private delegate IntPtr uiMenuAppendQuitItem_t(IntPtr m);
            public static IntPtr uiMenuAppendQuitItem(IntPtr m) => FunctionLoader.LoadLibuiFunc<uiMenuAppendQuitItem_t>("uiMenuAppendQuitItem")(m);

            // _UI_EXTERN uiMenuItem *uiMenuAppendPreferencesItem(uiMenu *m);
            [UnmanagedFunctionPointer(Convention)]
            private delegate IntPtr uiMenuAppendPreferencesItem_t(IntPtr m);
            public static IntPtr uiMenuAppendPreferencesItem(IntPtr m) => FunctionLoader.LoadLibuiFunc<uiMenuAppendPreferencesItem_t>("uiMenuAppendPreferencesItem")(m);

            // _UI_EXTERN uiMenuItem *uiMenuAppendAboutItem(uiMenu *m);
            [UnmanagedFunctionPointer(Convention)]
            private delegate IntPtr uiMenuAppendAboutItem_t(IntPtr m);
            public static IntPtr uiMenuAppendAboutItem(IntPtr m) => FunctionLoader.LoadLibuiFunc<uiMenuAppendAboutItem_t>("uiMenuAppendAboutItem")(m);

            // _UI_EXTERN void uiMenuAppendSeparator(uiMenu *m);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiMenuAppendSeparator_t(IntPtr m);
            public static void uiMenuAppendSeparator(IntPtr m) => FunctionLoader.LoadLibuiFunc<uiMenuAppendSeparator_t>("uiMenuAppendSeparator")(m);

            // _UI_EXTERN uiMenu *uiNewMenu(const char *name);
            [UnmanagedFunctionPointer(Convention)]
            private delegate IntPtr uiNewMenu_t(string name);
            public static IntPtr uiNewMenu(string name) => FunctionLoader.LoadLibuiFunc<uiNewMenu_t>("uiNewMenu")(name);
        }
    }
}