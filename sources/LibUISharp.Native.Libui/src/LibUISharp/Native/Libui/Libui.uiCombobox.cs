using System;
using System.Runtime.InteropServices;

namespace LibUISharp.Native
{
    internal static partial class NativeMethods
    {
        internal static partial class Libui
        {
            // _UI_EXTERN void uiComboboxAppend(uiCombobox *c, const char *text);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiComboboxAppend_t(IntPtr c, string text);
            public static void uiComboboxAppend(IntPtr c, string text) => FunctionLoader.LoadLibuiFunc<uiComboboxAppend_t>("uiComboboxAppend")(c, text);

            // _UI_EXTERN int uiComboboxSelected(uiCombobox *c);
            [UnmanagedFunctionPointer(Convention)]
            private delegate int uiComboboxSelected_t(IntPtr c);
            public static int uiComboboxSelected(IntPtr c) => FunctionLoader.LoadLibuiFunc<uiComboboxSelected_t>("uiComboboxSelected")(c);

            // _UI_EXTERN void uiComboboxSetSelected(uiCombobox *c, int n);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiComboboxSetSelected_t(IntPtr c, int n);
            public static void uiComboboxSetSelected(IntPtr c, int n) => FunctionLoader.LoadLibuiFunc<uiComboboxSetSelected_t>("uiComboboxSetSelected")(c, n);

            // _UI_EXTERN void uiComboboxOnSelected(uiCombobox *c, void (*f)(uiCombobox *c, void *data), void *data);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiComboboxOnSelected_t(IntPtr c, uiComboboxOnSelected_tf f, IntPtr data);
            [UnmanagedFunctionPointer(Convention)]
            public delegate void uiComboboxOnSelected_tf(IntPtr c, IntPtr data);
            public static void uiComboboxOnSelected(IntPtr c, uiComboboxOnSelected_tf f, IntPtr data) => FunctionLoader.LoadLibuiFunc<uiComboboxOnSelected_t>("uiComboboxOnSelected")(c, f, data);

            // _UI_EXTERN uiCombobox *uiNewCombobox(void);
            [UnmanagedFunctionPointer(Convention)]
            private delegate IntPtr uiNewCombobox_t();
            public static IntPtr uiNewCombobox() => FunctionLoader.LoadLibuiFunc<uiNewCombobox_t>("uiNewCombobox")();
        }
    }
}