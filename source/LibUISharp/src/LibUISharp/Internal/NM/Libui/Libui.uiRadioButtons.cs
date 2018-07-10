using System;
using System.Runtime.InteropServices;

namespace LibUISharp.Native
{
    internal static partial class NativeMethods
    {
        internal static partial class Libui
        {
            // _UI_EXTERN void uiRadioButtonsAppend(uiRadioButtons *r, const char *text);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiRadioButtonsAppend_t(IntPtr r, string text);
            public static void uiRadioButtonsAppend(IntPtr r, string text) => FunctionLoader.LoadLibuiFunc<uiRadioButtonsAppend_t>("uiRadioButtonsAppend")(r, text);

            // _UI_EXTERN int uiRadioButtonsSelected(uiRadioButtons *r);
            [UnmanagedFunctionPointer(Convention)]
            private delegate int uiRadioButtonsSelected_t(IntPtr r);
            public static int uiRadioButtonsSelected(IntPtr r) => FunctionLoader.LoadLibuiFunc<uiRadioButtonsSelected_t>("uiRadioButtonsSelected")(r);

            // _UI_EXTERN void uiRadioButtonsSetSelected(uiRadioButtons *r, int n);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiRadioButtonsSetSelected_t(IntPtr r, int n);
            public static void uiRadioButtonsSetSelected(IntPtr r, int n) => FunctionLoader.LoadLibuiFunc<uiRadioButtonsSetSelected_t>("uiRadioButtonsSetSelected")(r, n);

            // _UI_EXTERN void uiRadioButtonsOnSelected(uiRadioButtons *r, void (*f)(uiRadioButtons *, void *), void *data);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiRadioButtonsOnSelected_t(IntPtr r, uiRadioButtonsOnSelected_tf f, IntPtr data);
            [UnmanagedFunctionPointer(Convention)]
            public delegate void uiRadioButtonsOnSelected_tf(IntPtr r, IntPtr data);
            public static void uiRadioButtonsOnSelected(IntPtr r, uiRadioButtonsOnSelected_tf f, IntPtr data) => FunctionLoader.LoadLibuiFunc<uiRadioButtonsOnSelected_t>("uiRadioButtonsOnSelected")(r, f, data);

            // _UI_EXTERN uiRadioButtons *uiNewRadioButtons(void);
            [UnmanagedFunctionPointer(Convention)]
            private delegate IntPtr uiNewRadioButtons_t();
            public static IntPtr uiNewRadioButtons() => FunctionLoader.LoadLibuiFunc<uiNewRadioButtons_t>("uiNewRadioButtons")();
        }
    }
}