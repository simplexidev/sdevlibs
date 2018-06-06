using LibUISharp.Drawing;
using System;
using System.Runtime.InteropServices;

namespace LibUISharp.Native
{
    internal static partial class NativeMethods
    {
        internal static partial class Libui
        {
            // _UI_EXTERN void uiFreeAttribute(uiAttribute *a);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiFreeAttribute_t(IntPtr a);
            public static void uiFreeAttribute(IntPtr a) => FunctionLoader.LoadLibuiFunc<uiFreeAttribute_t>("uiFreeAttribute")(a);

            // _UI_EXTERN uiAttributeType uiAttributeGetType(const uiAttribute *a);
            [UnmanagedFunctionPointer(Convention)]
            private delegate uiAttributeType uiAttributeGetType_t(IntPtr a);
            public static uiAttributeType uiAttributeGetType(IntPtr a) => FunctionLoader.LoadLibuiFunc<uiAttributeGetType_t>("uiAttributeGetType")(a);

            // _UI_EXTERN uiAttribute *uiNewFamilyAttribute(const char *family);
            [UnmanagedFunctionPointer(Convention)]
            private delegate IntPtr uiNewFamilyAttribute_t(string family);
            public static IntPtr uiNewFamilyAttribute(string family) => FunctionLoader.LoadLibuiFunc<uiNewFamilyAttribute_t>("uiNewFamilyAttribute")(family);

            // _UI_EXTERN const char *uiAttributeFamily(const uiAttribute *a);
            [UnmanagedFunctionPointer(Convention)]
            private delegate string uiAttributeFamily_t(IntPtr a);
            public static string uiAttributeFamily(IntPtr a) => FunctionLoader.LoadLibuiFunc<uiAttributeFamily_t>("uiAttributeFamily")(a);

            // _UI_EXTERN uiAttribute *uiNewSizeAttribute(double size);
            [UnmanagedFunctionPointer(Convention)]
            private delegate IntPtr uiNewSizeAttribute_t(double size);
            public static IntPtr uiNewSizeAttribute(double size) => FunctionLoader.LoadLibuiFunc<uiNewSizeAttribute_t>("uiNewSizeAttribute")(size);

            // _UI_EXTERN double uiAttributeSize(const uiAttribute *a);
            [UnmanagedFunctionPointer(Convention)]
            private delegate double uiAttributeSize_t(IntPtr a);
            public static double uiAttributeSize(IntPtr a) => FunctionLoader.LoadLibuiFunc<uiAttributeSize_t>("uiAttributeSize")(a);

            // _UI_EXTERN uiAttribute *uiNewWeightAttribute(uiTextWeight weight);
            [UnmanagedFunctionPointer(Convention)]
            private delegate IntPtr uiNewWeightAttribute_t(FontWeight weight);
            public static IntPtr uiNewWeightAttribute(FontWeight weight) => FunctionLoader.LoadLibuiFunc<uiNewWeightAttribute_t>("uiNewWeightAttribute")(weight);

            // _UI_EXTERN uiTextWeight uiAttributeWeight(const uiAttribute *a);
            [UnmanagedFunctionPointer(Convention)]
            private delegate FontWeight uiAttributeWeight_t(IntPtr a);
            public static FontWeight uiAttributeWeight(IntPtr a) => FunctionLoader.LoadLibuiFunc<uiAttributeWeight_t>("uiAttributeWeight")(a);

            // _UI_EXTERN uiAttribute *uiNewItalicAttribute(uiTextItalic italic);
            [UnmanagedFunctionPointer(Convention)]
            private delegate IntPtr uiNewItalicAttribute_t(FontStyle italic);
            public static IntPtr uiNewItalicAttribute(FontStyle italic) => FunctionLoader.LoadLibuiFunc<uiNewItalicAttribute_t>("uiNewItalicAttribute")(italic);

            // _UI_EXTERN uiTextItalic uiAttributeItalic(const uiAttribute *a);
            [UnmanagedFunctionPointer(Convention)]
            private delegate FontStyle uiAttributeItalic_t(IntPtr a);
            public static FontStyle uiAttributeItalic(IntPtr a) => FunctionLoader.LoadLibuiFunc<uiAttributeItalic_t>("uiAttributeItalic")(a);

            // _UI_EXTERN uiAttribute *uiNewStretchAttribute(uiTextStretch stretch);
            [UnmanagedFunctionPointer(Convention)]
            private delegate IntPtr uiNewStretchAttribute_t(FontStretch stretch);
            public static IntPtr uiNewStretchAttribute(FontStretch stretch) => FunctionLoader.LoadLibuiFunc<uiNewStretchAttribute_t>("uiNewStretchAttribute")(stretch);

            // _UI_EXTERN uiTextStretch uiAttributeStretch(const uiAttribute *a);
            [UnmanagedFunctionPointer(Convention)]
            private delegate FontStretch uiAttributeStretch_t(IntPtr a);
            public static FontStretch uiAttributeStretch(IntPtr a) => FunctionLoader.LoadLibuiFunc<uiAttributeStretch_t>("uiAttributeStretch")(a);

            // _UI_EXTERN uiAttribute *uiNewColorAttribute(double r, double g, double b, double a);
            [UnmanagedFunctionPointer(Convention)]
            private delegate IntPtr uiNewColorAttribute_t(double r, double g, double b, double a);
            public static IntPtr uiNewColorAttribute(double r, double g, double b, double a) => FunctionLoader.LoadLibuiFunc<uiNewColorAttribute_t>("uiNewColorAttribute")(r, g, b, a);

            // _UI_EXTERN void uiAttributeColor(const uiAttribute *a, double *r, double *g, double *b, double *alpha);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiAttributeColor_t(IntPtr a, out double r, out double g, out double b, out double alpha);
            public static void uiAttributeColor(IntPtr a, out double r, out double g, out double b, out double alpha) => FunctionLoader.LoadLibuiFunc<uiAttributeColor_t>("uiAttributeColor")(a, out r, out g, out b, out alpha);

            // _UI_EXTERN uiAttribute *uiNewBackgroundAttribute(double r, double g, double b, double a);
            [UnmanagedFunctionPointer(Convention)]
            private delegate IntPtr uiNewBackgroundAttribute_t(double r, double g, double b, double a);
            public static IntPtr uiNewBackgroundAttribute(double r, double g, double b, double a) => FunctionLoader.LoadLibuiFunc<uiNewBackgroundAttribute_t>("uiNewBackgroundAttribute")(r, g, b, a);

            // _UI_EXTERN uiAttribute *uiNewUnderlineAttribute(uiUnderline u);
            [UnmanagedFunctionPointer(Convention)]
            private delegate IntPtr uiNewUnderlineAttribute_t(UnderlineStyle u);
            public static IntPtr uiNewUnderlineAttribute(UnderlineStyle u) => FunctionLoader.LoadLibuiFunc<uiNewUnderlineAttribute_t>("uiNewUnderlineAttribute")(u);

            // _UI_EXTERN uiUnderline uiAttributeUnderline(const uiAttribute *a);
            [UnmanagedFunctionPointer(Convention)]
            private delegate UnderlineStyle uiAttributeUnderline_t(IntPtr a);
            public static UnderlineStyle uiAttributeUnderline(IntPtr a) => FunctionLoader.LoadLibuiFunc<uiAttributeUnderline_t>("uiAttributeUnderline")(a);

            // _UI_EXTERN uiAttribute *uiNewUnderlineColorAttribute(uiUnderlineColor u, double r, double g, double b, double a);
            [UnmanagedFunctionPointer(Convention)]
            private delegate IntPtr uiNewUnderlineColorAttribute_t(UnderlineColor u, double r, double g, double b, double a);
            public static IntPtr uiNewUnderlineColorAttribute(UnderlineColor u, double r, double g, double b, double a) => FunctionLoader.LoadLibuiFunc<uiNewUnderlineColorAttribute_t>("uiNewUnderlineColorAttribute")(u, r, g, b, a);

            // _UI_EXTERN void uiAttributeUnderlineColor(const uiAttribute *a, uiUnderlineColor *u, double *r, double *g, double *b, double *alpha);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiAttributeUnderlineColor_t(IntPtr a, out UnderlineColor u, out double r, out double g, out double b, out double alpha);
            public static void uiAttributeUnderlineColor(IntPtr a, out UnderlineColor u, out double r, out double g, out double b, out double alpha) => FunctionLoader.LoadLibuiFunc<uiAttributeUnderlineColor_t>("uiAttributeUnderlineColor")(a, out u, out r, out g, out b, out alpha);

            // _UI_EXTERN uiAttribute *uiNewFeaturesAttribute(const uiOpenTypeFeatures *otf);
            [UnmanagedFunctionPointer(Convention)]
            private delegate IntPtr uiNewFeaturesAttribute_t(IntPtr otf);
            public static IntPtr uiNewFeaturesAttribute(IntPtr otf) => FunctionLoader.LoadLibuiFunc<uiNewFeaturesAttribute_t>("uiNewFeaturesAttribute")(otf);

            // _UI_EXTERN const uiOpenTypeFeatures *uiAttributeFeatures(const uiAttribute *a);
            [UnmanagedFunctionPointer(Convention)]
            private delegate IntPtr uiAttributeFeatures_t(IntPtr a);
            public static IntPtr uiAttributeFeatures(IntPtr a) => FunctionLoader.LoadLibuiFunc<uiAttributeFeatures_t>("uiAttributeFeatures")(a);
        }
    }
}