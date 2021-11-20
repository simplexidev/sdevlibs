using System;
using System.Runtime.InteropServices;

namespace LibUISharp.Native
{
    internal static partial class NativeMethods
    {
        internal static partial class Libui
        {
            // _UI_EXTERN char *uiButtonText(uiButton *b);
            [UnmanagedFunctionPointer(Convention)]
            private delegate string uiButtonText_t(IntPtr b);
            public static string uiButtonText(IntPtr b) => FunctionLoader.LoadLibuiFunc<uiButtonText_t>("uiButtonText")(b);

            // _UI_EXTERN void uiButtonSetText(uiButton *b, const char *text);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiButtonSetText_t(IntPtr b, string text);
            public static void uiButtonSetText(IntPtr b, string text) => FunctionLoader.LoadLibuiFunc<uiButtonSetText_t>("uiButtonSetText")(b, text);

            // _UI_EXTERN void uiButtonOnClicked(uiButton *b, void (*f)(uiButton *b, void *data), void *data);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiButtonOnClicked_t(IntPtr b, uiButtonOnClicked_tf f, IntPtr data);
            [UnmanagedFunctionPointer(Convention)]
            public delegate void uiButtonOnClicked_tf(IntPtr b, IntPtr data);
            public static void uiButtonOnClicked(IntPtr b, uiButtonOnClicked_tf f, IntPtr data) => FunctionLoader.LoadLibuiFunc<uiButtonOnClicked_t>("uiButtonOnClicked")(b, f, data);

            // _UI_EXTERN uiButton *uiNewButton(const char *text);
            [UnmanagedFunctionPointer(Convention)]
            private delegate IntPtr uiNewButton_t(string text);
            public static IntPtr uiNewButton(string text) => FunctionLoader.LoadLibuiFunc<uiNewButton_t>("uiNewButton")(text);
        }
    }
}