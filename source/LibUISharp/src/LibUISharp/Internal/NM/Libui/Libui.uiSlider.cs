using System;
using System.Runtime.InteropServices;

namespace LibUISharp.Native
{
    internal static partial class NativeMethods
    {
        internal static partial class Libui
        {
            // _UI_EXTERN int uiSliderValue(uiSlider *s);
            [UnmanagedFunctionPointer(Convention)]
            private delegate int uiSliderValue_t(IntPtr s);
            public static int uiSliderValue(IntPtr s) => FunctionLoader.LoadLibuiFunc<uiSliderValue_t>("uiSliderValue")(s);

            // _UI_EXTERN void uiSliderSetValue(uiSlider *s, int value);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiSliderSetValue_t(IntPtr s, int value);
            public static void uiSliderSetValue(IntPtr s, int value) => FunctionLoader.LoadLibuiFunc<uiSliderSetValue_t>("uiSliderSetValue")(s, value);

            // _UI_EXTERN void uiSliderOnChanged(uiSlider *s, void (*f)(uiSlider *s, void *data), void *data);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiSliderOnChanged_t(IntPtr s, uiSliderOnChanged_tf f, IntPtr data);
            [UnmanagedFunctionPointer(Convention)]
            public delegate void uiSliderOnChanged_tf(IntPtr s, IntPtr data);
            public static void uiSliderOnChanged(IntPtr s, uiSliderOnChanged_tf f, IntPtr data) => FunctionLoader.LoadLibuiFunc<uiSliderOnChanged_t>("uiSliderOnChanged")(s, f, data);

            // _UI_EXTERN uiSlider *uiNewSlider(int min, int max);
            [UnmanagedFunctionPointer(Convention)]
            private delegate IntPtr uiNewSlider_t(int min, int max);
            public static IntPtr uiNewSlider(int min, int max) => FunctionLoader.LoadLibuiFunc<uiNewSlider_t>("uiNewSlider")(min, max);
        }
    }
}