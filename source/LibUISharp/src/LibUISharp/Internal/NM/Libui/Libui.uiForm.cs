using System;
using System.Runtime.InteropServices;

namespace LibUISharp.Native
{
    internal static partial class NativeMethods
    {
        internal static partial class Libui
        {
            // _UI_EXTERN void uiFormAppend(uiForm* f, const char* label, uiControl *c, int stretchy);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiFormAppend_t(IntPtr f, string label, IntPtr c, bool stretchy);
            public static void uiFormAppend(IntPtr f, string label, IntPtr c, bool stretchy) => FunctionLoader.LoadLibuiFunc<uiFormAppend_t>("uiFormAppend")(f, label, c, stretchy);

            // _UI_EXTERN void uiFormDelete(uiForm* f, int index);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiFormDelete_t(IntPtr f, int index);
            public static void uiFormDelete(IntPtr f, int index) => FunctionLoader.LoadLibuiFunc<uiFormDelete_t>("uiFormDelete")(f, index);

            // _UI_EXTERN int uiFormPadded(uiForm* f);
            [UnmanagedFunctionPointer(Convention)]
            private delegate bool uiFormPadded_t(IntPtr f);
            public static bool uiFormPadded(IntPtr f) => FunctionLoader.LoadLibuiFunc<uiFormPadded_t>("uiFormPadded")(f);

            // _UI_EXTERN void uiFormSetPadded(uiForm* f, int padded);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiFormSetPadded_t(IntPtr f, bool padded);
            public static void uiFormSetPadded(IntPtr f, bool padded) => FunctionLoader.LoadLibuiFunc<uiFormSetPadded_t>("uiFormSetPadded")(f, padded);

            // _UI_EXTERN uiForm *uiNewForm(void);
            [UnmanagedFunctionPointer(Convention)]
            private delegate IntPtr uiNewForm_t();
            public static IntPtr uiNewForm() => FunctionLoader.LoadLibuiFunc<uiNewForm_t>("uiNewForm")();
        }
    }
}