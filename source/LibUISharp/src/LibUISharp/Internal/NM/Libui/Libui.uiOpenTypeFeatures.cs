using System;
using System.Runtime.InteropServices;

namespace LibUISharp.Native
{
    internal static partial class NativeMethods
    {
        internal static partial class Libui
        {
            // typedef uiForEach (*uiOpenTypeFeaturesForEachFunc)(const uiOpenTypeFeatures *otf, char a, char b, char c, char d, uint32_t value, void *data);
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate uiForEach uiOpenTypeFeaturesForEachFunc(IntPtr otf, char a, char b, char c, char d, uint value, IntPtr data);

            // _UI_EXTERN uiOpenTypeFeatures *uiNewOpenTypeFeatures(void);
            [UnmanagedFunctionPointer(Convention)]
            private delegate IntPtr uiNewOpenTypeFeatures_t();
            public static IntPtr uiNewOpenTypeFeatures() => FunctionLoader.LoadLibuiFunc<uiNewOpenTypeFeatures_t>("uiNewOpenTypeFeatures")();

            // _UI_EXTERN void uiFreeOpenTypeFeatures(uiOpenTypeFeatures *otf);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiFreeOpenTypeFeatures_t(IntPtr otf);
            public static void uiFreeOpenTypeFeatures(IntPtr otf) => FunctionLoader.LoadLibuiFunc<uiFreeOpenTypeFeatures_t>("uiFreeOpenTypeFeatures")(otf);

            // _UI_EXTERN uiOpenTypeFeatures *uiOpenTypeFeaturesClone(const uiOpenTypeFeatures *otf);
            [UnmanagedFunctionPointer(Convention)]
            private delegate IntPtr uiOpenTypeFeaturesClone_t(IntPtr otf);
            public static IntPtr uiOpenTypeFeaturesClone(IntPtr otf) => FunctionLoader.LoadLibuiFunc<uiOpenTypeFeaturesClone_t>("uiOpenTypeFeaturesClone")(otf);

            // _UI_EXTERN void uiOpenTypeFeaturesAdd(uiOpenTypeFeatures *otf, char a, char b, char c, char d, uint32_t value);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiOpenTypeFeaturesAdd_t(IntPtr otf, char a, char b, char c, char d, uint value);
            public static void uiOpenTypeFeaturesAdd(IntPtr otf, char a, char b, char c, char d, uint value) => FunctionLoader.LoadLibuiFunc<uiOpenTypeFeaturesAdd_t>("uiOpenTypeFeaturesAdd")(otf, a, b, c, d, value);

            // _UI_EXTERN void uiOpenTypeFeaturesRemove(uiOpenTypeFeatures *otf, char a, char b, char c, char d);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiOpenTypeFeaturesRemove_t(IntPtr otf, char a, char b, char c, char d);
            public static void uiOpenTypeFeaturesRemove(IntPtr otf, char a, char b, char c, char d) => FunctionLoader.LoadLibuiFunc<uiOpenTypeFeaturesRemove_t>("uiOpenTypeFeaturesRemove")(otf, a, b, c, d);

            // _UI_EXTERN int uiOpenTypeFeaturesGet(const uiOpenTypeFeatures *otf, char a, char b, char c, char d, uint32_t *value);
            [UnmanagedFunctionPointer(Convention)]
            private delegate int uiOpenTypeFeaturesGet_t(IntPtr otf, char a, char b, char c, char d, out uint value);
            public static int uiOpenTypeFeaturesGet(IntPtr otf, char a, char b, char c, char d, out uint value) => FunctionLoader.LoadLibuiFunc<uiOpenTypeFeaturesGet_t>("uiOpenTypeFeaturesGet")(otf, a, b, c, d, out value);

            // _UI_EXTERN void uiOpenTypeFeaturesForEach(const uiOpenTypeFeatures *otf, uiOpenTypeFeaturesForEachFunc f, void *data);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiOpenTypeFeaturesForEach_t(IntPtr otf, uiOpenTypeFeaturesForEachFunc f, IntPtr data);
            public static void uiOpenTypeFeaturesForEach(IntPtr otf, uiOpenTypeFeaturesForEachFunc f, IntPtr data) => FunctionLoader.LoadLibuiFunc<uiOpenTypeFeaturesForEach_t>("uiOpenTypeFeaturesForEach")(otf, f, data);
        }
    }
}