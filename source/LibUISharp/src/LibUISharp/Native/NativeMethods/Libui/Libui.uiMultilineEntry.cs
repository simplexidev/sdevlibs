using System;
using System.Runtime.InteropServices;

namespace LibUISharp.Native
{
    internal static partial class NativeMethods
    {
        internal static partial class Libui
        {
            // _UI_EXTERN char *uiMultilineEntryText(uiMultilineEntry *e);
            [UnmanagedFunctionPointer(Convention)]
            private delegate string uiMultilineEntryText_t(IntPtr e);
            public static string uiMultilineEntryText(IntPtr e) => FunctionLoader.LoadLibuiFunc<uiMultilineEntryText_t>("uiMultilineEntryText")(e);

            // _UI_EXTERN void uiMultilineEntrySetText(uiMultilineEntry *e, const char *text);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiMultilineEntrySetText_t(IntPtr e, string text);
            public static void uiMultilineEntrySetText(IntPtr e, string text) => FunctionLoader.LoadLibuiFunc<uiMultilineEntrySetText_t>("uiMultilineEntrySetText")(e, text);

            // _UI_EXTERN void uiMultilineEntryAppend(uiMultilineEntry *e, const char *text);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiMultilineEntryAppend_t(IntPtr e, string text);
            public static void uiMultilineEntryAppend(IntPtr e, string text) => FunctionLoader.LoadLibuiFunc<uiMultilineEntryAppend_t>("uiMultilineEntryAppend")(e, text);

            // _UI_EXTERN void uiMultilineEntryOnChanged(uiMultilineEntry *e, void (*f)(uiMultilineEntry *e, void *data), void *data);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiMultilineEntryOnChanged_t(IntPtr e, uiMultilineEntryOnChanged_tf f, IntPtr data);
            [UnmanagedFunctionPointer(Convention)]
            public delegate void uiMultilineEntryOnChanged_tf(IntPtr e, IntPtr data);
            public static void uiMultilineEntryOnChanged(IntPtr e, uiMultilineEntryOnChanged_tf f, IntPtr data) => FunctionLoader.LoadLibuiFunc<uiMultilineEntryOnChanged_t>("uiMultilineEntryOnChanged")(e, f, data);

            // _UI_EXTERN int uiMultilineEntryReadOnly(uiMultilineEntry *e);
            [UnmanagedFunctionPointer(Convention)]
            private delegate bool uiMultilineEntryReadOnly_t(IntPtr e);
            public static bool uiMultilineEntryReadOnly(IntPtr e) => FunctionLoader.LoadLibuiFunc<uiMultilineEntryReadOnly_t>("uiMultilineEntryReadOnly")(e);

            // _UI_EXTERN void uiMultilineEntrySetReadOnly(uiMultilineEntry *e, int readonly);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiMultilineEntrySetReadOnly_t(IntPtr e, bool @readonly);
            public static void uiMultilineEntrySetReadOnly(IntPtr e, bool @readonly) => FunctionLoader.LoadLibuiFunc<uiMultilineEntrySetReadOnly_t>("uiMultilineEntrySetReadOnly")(e, @readonly);

            // _UI_EXTERN uiMultilineEntry *uiNewMultilineEntry(void);
            [UnmanagedFunctionPointer(Convention)]
            private delegate IntPtr uiNewMultilineEntry_t();
            public static IntPtr uiNewMultilineEntry() => FunctionLoader.LoadLibuiFunc<uiNewMultilineEntry_t>("uiNewMultilineEntry")();

            // _UI_EXTERN uiMultilineEntry *uiNewNonWrappingMultilineEntry(void);
            [UnmanagedFunctionPointer(Convention)]
            private delegate IntPtr uiNewNonWrappingMultilineEntry_t();
            public static IntPtr uiNewNonWrappingMultilineEntry() => FunctionLoader.LoadLibuiFunc<uiNewNonWrappingMultilineEntry_t>("uiNewNonWrappingMultilineEntry")();
        }
    }
}