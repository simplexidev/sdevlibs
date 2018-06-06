using System;
using System.Runtime.InteropServices;

namespace LibUISharp.Native
{
    internal static partial class NativeMethods
    {
        internal static partial class Libui
        {
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiFontButtonFont_t(IntPtr b, out uiFontDescriptor desc);
            public static void uiFontButtonFont(IntPtr b, out uiFontDescriptor desc) => FunctionLoader.LoadLibuiFunc<uiFontButtonFont_t>("uiFontButtonFont")(b, out desc);

            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiFontButtonOnChanged_t(IntPtr b, uiFontButtonOnChanged_tf f, IntPtr data);
            [UnmanagedFunctionPointer(Convention)]
            public delegate void uiFontButtonOnChanged_tf(IntPtr b, IntPtr data);
            public static void uiFontButtonOnChanged(IntPtr b, uiFontButtonOnChanged_tf f, IntPtr data) => FunctionLoader.LoadLibuiFunc<uiFontButtonOnChanged_t>("uiFontButtonOnChanged")(b, f, data);

            [UnmanagedFunctionPointer(Convention)]
            private delegate IntPtr uiNewFontButton_t();
            public static IntPtr uiNewFontButton() => FunctionLoader.LoadLibuiFunc<uiNewFontButton_t>("uiNewFontButton")();

            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiFreeFontButtonFont_t(uiFontDescriptor desc);
            public static void uiFreeFontButtonFont(uiFontDescriptor desc) => FunctionLoader.LoadLibuiFunc<uiFreeFontButtonFont_t>("uiFreeFontButtonFont")(desc);
        }
    }
}