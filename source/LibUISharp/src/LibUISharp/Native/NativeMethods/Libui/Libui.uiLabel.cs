using System;
using System.Runtime.InteropServices;

namespace LibUISharp.Native
{
    internal static partial class NativeMethods
    {
        internal static partial class Libui
        {
            // _UI_EXTERN char *uiLabelText(uiLabel *l);
            [UnmanagedFunctionPointer(Convention)]
            private delegate string uiLabelText_t(IntPtr l);
            public static string uiLabelText(IntPtr l) => FunctionLoader.LoadLibuiFunc<uiLabelText_t>("uiLabelText")(l);

            // _UI_EXTERN void uiLabelSetText(uiLabel *l, const char *text);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiLabelSetText_t(IntPtr l, string text);
            public static void uiLabelSetText(IntPtr l, string text) => FunctionLoader.LoadLibuiFunc<uiLabelSetText_t>("uiLabelSetText")(l, text);

            // _UI_EXTERN uiLabel *uiNewLabel(const char* text);
            [UnmanagedFunctionPointer(Convention)]
            private delegate IntPtr uiNewLabel_t(string text);
            public static IntPtr uiNewLabel(string text) => FunctionLoader.LoadLibuiFunc<uiNewLabel_t>("uiNewLabel")(text);
        }
    }
}