using System;
using System.Runtime.InteropServices;

namespace LibUISharp.Native
{
    internal static partial class NativeMethods
    {
        internal static partial class Libui
        {
            // _UI_EXTERN char *uiEntryText(uiEntry *e);
            [UnmanagedFunctionPointer(Convention)]
            private delegate string uiEntryText_t(IntPtr e);
            public static string uiEntryText(IntPtr e) => FunctionLoader.LoadLibuiFunc<uiEntryText_t>("uiEntryText")(e);

            // _UI_EXTERN void uiEntrySetText(uiEntry *e, const char *text);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiEntrySetText_t(IntPtr e, string text);
            public static void uiEntrySetText(IntPtr e, string text) => FunctionLoader.LoadLibuiFunc<uiEntrySetText_t>("uiEntrySetText")(e, text);

            // _UI_EXTERN void uiEntryOnChanged(uiEntry *e, void (*f)(uiEntry *e, void *data), void *data);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiEntryOnChanged_t(IntPtr e, uiEntryOnChanged_tf f, IntPtr data);
            [UnmanagedFunctionPointer(Convention)]
            public delegate void uiEntryOnChanged_tf(IntPtr e, IntPtr data);
            public static void uiEntryOnChanged(IntPtr e, uiEntryOnChanged_tf f, IntPtr data) => FunctionLoader.LoadLibuiFunc<uiEntryOnChanged_t>("uiEntryOnChanged")(e, f, data);

            // _UI_EXTERN int uiEntryReadOnly(uiEntry *e);
            [UnmanagedFunctionPointer(Convention)]
            private delegate bool uiEntryReadOnly_t(IntPtr e);
            public static bool uiEntryReadOnly(IntPtr e) => FunctionLoader.LoadLibuiFunc<uiEntryReadOnly_t>("uiEntryReadOnly")(e);

            // _UI_EXTERN void uiEntrySetReadOnly(uiEntry *e, int readonly);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiEntrySetReadOnly_t(IntPtr e, bool @readonly);
            public static void uiEntrySetReadOnly(IntPtr e, bool @readonly) => FunctionLoader.LoadLibuiFunc<uiEntrySetReadOnly_t>("uiEntrySetReadOnly")(e, @readonly);

            // _UI_EXTERN uiEntry *uiNewEntry(void);
            [UnmanagedFunctionPointer(Convention)]
            private delegate IntPtr uiNewEntry_t();
            public static IntPtr uiNewEntry() => FunctionLoader.LoadLibuiFunc<uiNewEntry_t>("uiNewEntry")();

            // _UI_EXTERN uiEntry *uiNewPasswordEntry(void);
            [UnmanagedFunctionPointer(Convention)]
            private delegate IntPtr uiNewPasswordEntry_t();
            public static IntPtr uiNewPasswordEntry() => FunctionLoader.LoadLibuiFunc<uiNewPasswordEntry_t>("uiNewPasswordEntry")();

            // _UI_EXTERN uiEntry *uiNewSearchEntry(void);
            [UnmanagedFunctionPointer(Convention)]
            private delegate IntPtr uiNewSearchEntry_t();
            public static IntPtr uiNewSearchEntry() => FunctionLoader.LoadLibuiFunc<uiNewSearchEntry_t>("uiNewSearchEntry")();
        }
    }
}