using System;
using System.Runtime.InteropServices;

namespace LibUISharp.Native
{
    internal static partial class NativeMethods
    {
        internal static partial class Libui
        {
            // _UI_EXTERN void uiColorButtonColor(uiColorButton* b, double* r, double* g, double* bl, double* a);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiColorButtonColor_t(IntPtr b, out double red, out double green, out double blue, out double alpha);
            public static void uiColorButtonColor(IntPtr b, out double red, out double green, out double blue, out double alpha) => FunctionLoader.LoadLibuiFunc<uiColorButtonColor_t>("uiColorButtonColor")(b, out red, out blue, out green, out alpha);

            // _UI_EXTERN void uiColorButtonSetColor(uiColorButton* b, double r, double g, double bl, double a);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiColorButtonSetColor_t(IntPtr b, double red, double green, double blue, double alpha);
            public static void uiColorButtonSetColor(IntPtr b, double red, double green, double blue, double alpha) => FunctionLoader.LoadLibuiFunc<uiColorButtonSetColor_t>("uiColorButtonSetColor")(b, red, blue, green, alpha);

            // _UI_EXTERN void uiColorButtonOnChanged(uiColorButton* b, void (* f)(uiColorButton*, void*), void* data);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiColorButtonOnChanged_t(IntPtr b, uiColorButtonOnChanged_tf f, IntPtr data);
            [UnmanagedFunctionPointer(Convention)]
            public delegate void uiColorButtonOnChanged_tf(IntPtr b, IntPtr data);
            public static void uiColorButtonOnChanged(IntPtr b, uiColorButtonOnChanged_tf f, IntPtr data) => FunctionLoader.LoadLibuiFunc<uiColorButtonOnChanged_t>("uiColorButtonOnChanged")(b, f, data);

            // _UI_EXTERN uiColorButton *uiNewColorButton(void);
            [UnmanagedFunctionPointer(Convention)]
            private delegate IntPtr uiNewColorButton_t();
            public static IntPtr uiNewColorButton() => FunctionLoader.LoadLibuiFunc<uiNewColorButton_t>("uiNewColorButton")();
        }
    }
}