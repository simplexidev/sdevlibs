using System;
using System.Runtime.InteropServices;

namespace LibUISharp.Native
{
    internal static partial class NativeMethods
    {
        internal static partial class Libui
        {
            // _UI_EXTERN char *uiCheckboxText(uiCheckbox *c);
            [UnmanagedFunctionPointer(Convention)]
            private delegate string uiCheckboxText_t(IntPtr c);
            public static string uiCheckboxText(IntPtr c) => FunctionLoader.LoadLibuiFunc<uiCheckboxText_t>("uiCheckboxText")(c);

            // _UI_EXTERN void uiCheckboxSetText(uiCheckbox *c, const char *text);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiCheckboxSetText_t(IntPtr c, string text);
            public static void uiCheckboxSetText(IntPtr c, string text) => FunctionLoader.LoadLibuiFunc<uiCheckboxSetText_t>("uiCheckboxSetText")(c, text);

            // _UI_EXTERN void uiCheckboxOnToggled(uiCheckbox *c, void (*f)(uiCheckbox *c, void *data), void *data);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiCheckboxOnToggled_t(IntPtr c, uiCheckboxOnToggled_tf f, IntPtr data);
            [UnmanagedFunctionPointer(Convention)]
            public delegate void uiCheckboxOnToggled_tf(IntPtr c, IntPtr data);
            public static void uiCheckboxOnToggled(IntPtr c, uiCheckboxOnToggled_tf f, IntPtr data) => FunctionLoader.LoadLibuiFunc<uiCheckboxOnToggled_t>("uiCheckboxOnToggled")(c, f, data);

            // _UI_EXTERN int uiCheckboxChecked(uiCheckbox *c);
            [UnmanagedFunctionPointer(Convention)]
            private delegate bool uiCheckboxChecked_t(IntPtr c);
            public static bool uiCheckboxChecked(IntPtr c) => FunctionLoader.LoadLibuiFunc<uiCheckboxChecked_t>("uiCheckboxChecked")(c);

            // _UI_EXTERN void uiCheckboxSetChecked(uiCheckbox *c, int checked);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiCheckboxSetChecked_t(IntPtr c, bool @checked);
            public static void uiCheckboxSetChecked(IntPtr c, bool @checked) => FunctionLoader.LoadLibuiFunc<uiCheckboxSetChecked_t>("uiCheckboxSetChecked")(c, @checked);

            // _UI_EXTERN uiCheckbox *uiNewCheckbox(const char *text);
            [UnmanagedFunctionPointer(Convention)]
            private delegate IntPtr uiNewCheckbox_t(string text);
            public static IntPtr uiNewCheckbox(string text) => FunctionLoader.LoadLibuiFunc<uiNewCheckbox_t>("uiNewCheckbox")(text);
        }
    }
}