using System;
using System.Runtime.InteropServices;

namespace LibUISharp.Native
{
    internal static partial class NativeMethods
    {
        internal static partial class Libui
        {
            // _UI_EXTERN void uiEditableComboboxAppend(uiEditableCombobox *c, const char *text);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiEditableComboboxAppend_t(IntPtr c, string text);
            public static void uiEditableComboboxAppend(IntPtr c, string text) => FunctionLoader.LoadLibuiFunc<uiEditableComboboxAppend_t>("uiEditableComboboxAppend")(c, text);

            // _UI_EXTERN char *uiEditableComboboxText(uiEditableCombobox *c);
            [UnmanagedFunctionPointer(Convention)]
            private delegate string uiEditableComboboxText_t(IntPtr c);
            public static string uiEditableComboboxText(IntPtr c) => FunctionLoader.LoadLibuiFunc<uiEditableComboboxText_t>("uiEditableComboboxText")(c);

            // _UI_EXTERN void uiEditableComboboxSetText(uiEditableCombobox *c, const char *text);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiEditableComboboxSetText_t(IntPtr c, string text);
            public static void uiEditableComboboxSetText(IntPtr c, string text) => FunctionLoader.LoadLibuiFunc<uiEditableComboboxSetText_t>("uiEditableComboboxSetText")(c, text);

            // _UI_EXTERN void uiEditableComboboxOnChanged(uiEditableCombobox *c, void (*f)(uiEditableCombobox *c, void *data), void *data);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiEditableComboboxOnChanged_t(IntPtr c, uiEditableComboboxOnChanged_tf f, IntPtr data);
            [UnmanagedFunctionPointer(Convention)]
            public delegate void uiEditableComboboxOnChanged_tf(IntPtr c, IntPtr data);
            public static void uiEditableComboboxOnChanged(IntPtr c, uiEditableComboboxOnChanged_tf f, IntPtr data) => FunctionLoader.LoadLibuiFunc<uiEditableComboboxOnChanged_t>("uiEditableComboboxOnChanged")(c, f, data);

            // _UI_EXTERN uiEditableCombobox *uiNewEditableCombobox(void);
            [UnmanagedFunctionPointer(Convention)]
            private delegate IntPtr uiNewEditableCombobox_t();
            public static IntPtr uiNewEditableCombobox() => FunctionLoader.LoadLibuiFunc<uiNewEditableCombobox_t>("uiNewEditableCombobox")();
        }
    }
}