using System;
using System.Runtime.InteropServices;

namespace LibUISharp.Native
{
    internal static partial class NativeMethods
    {
        internal static partial class Libui
        {
            // _UI_EXTERN int uiSpinboxValue(uiSpinbox *s);
            [UnmanagedFunctionPointer(Convention)]
            private delegate int uiSpinboxValue_t(IntPtr s);
            public static int uiSpinboxValue(IntPtr s) => FunctionLoader.LoadLibuiFunc<uiSpinboxValue_t>("uiSpinboxValue")(s);

            // _UI_EXTERN void uiSpinboxSetValue(uiSpinbox *s, int value);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiSpinboxSetValue_t(IntPtr s, int value);
            public static void uiSpinboxSetValue(IntPtr s, int value) => FunctionLoader.LoadLibuiFunc<uiSpinboxSetValue_t>("uiSpinboxSetValue")(s, value);

            // _UI_EXTERN void uiSpinboxOnChanged(uiSpinbox *s, void (*f)(uiSpinbox *s, void *data), void *data);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiSpinboxOnChanged_t(IntPtr s, uiSpinboxOnChanged_tf f, IntPtr data);
            [UnmanagedFunctionPointer(Convention)]
            public delegate void uiSpinboxOnChanged_tf(IntPtr s, IntPtr data);
            public static void uiSpinboxOnChanged(IntPtr s, uiSpinboxOnChanged_tf f, IntPtr data) => FunctionLoader.LoadLibuiFunc<uiSpinboxOnChanged_t>("uiSpinboxOnChanged")(s, f, data);

            // _UI_EXTERN uiSpinbox *uiNewSpinbox(int min, int max);
            [UnmanagedFunctionPointer(Convention)]
            private delegate IntPtr uiNewSpinbox_t(int min, int max);
            public static IntPtr uiNewSpinbox(int min, int max) => FunctionLoader.LoadLibuiFunc<uiNewSpinbox_t>("uiNewSpinbox")(min, max);
        }
    }
}