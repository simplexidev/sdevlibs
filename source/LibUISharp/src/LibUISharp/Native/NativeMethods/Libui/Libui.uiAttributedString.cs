using System;
using System.Runtime.InteropServices;

namespace LibUISharp.Native
{
    internal static partial class NativeMethods
    {
        internal static partial class Libui
        {
            // typedef uiForEach(*uiAttributedStringForEachAttributeFunc)(const uiAttributedString* s, const uiAttribute* a, size_t start, size_t end, void* data);
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate uiForEach uiAttributedStringForEachAttributeFunc(IntPtr s, IntPtr a, UIntPtr start, UIntPtr end, IntPtr data);

            // _UI_EXTERN uiAttributedString *uiNewAttributedString(const char* initialString);
            [UnmanagedFunctionPointer(Convention)]
            private delegate IntPtr uiNewAttributedString_t(string initialString);
            public static IntPtr uiNewAttributedString(string initialString) => FunctionLoader.LoadLibuiFunc<uiNewAttributedString_t>("uiNewAttributedString")(initialString);

            // _UI_EXTERN void uiFreeAttributedString(uiAttributedString* s);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiFreeAttributedString_t(IntPtr s);
            public static void uiFreeAttributedString(IntPtr s) => FunctionLoader.LoadLibuiFunc<uiFreeAttributedString_t>("uiFreeAttributedString")(s);

            // _UI_EXTERN const char* uiAttributedStringString(const uiAttributedString* s);
            [UnmanagedFunctionPointer(Convention)]
            private delegate string uiAttributedStringString_t(IntPtr s);
            public static string uiAttributedStringString(IntPtr s) => FunctionLoader.LoadLibuiFunc<uiAttributedStringString_t>("uiAttributedStringString")(s);

            // _UI_EXTERN size_t uiAttributedStringLen(const uiAttributedString* s);
            [UnmanagedFunctionPointer(Convention)]
            private delegate UIntPtr uiAttributedStringLen_t(IntPtr s);
            public static UIntPtr uiAttributedStringLen(IntPtr s) => FunctionLoader.LoadLibuiFunc<uiAttributedStringLen_t>("uiAttributedStringLen")(s);

            // _UI_EXTERN void uiAttributedStringAppendUnattributed(uiAttributedString* s, const char* str);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiAttributedStringAppendUnattributed_t(IntPtr s, IntPtr str);
            public static void uiAttributedStringAppendUnattributed(IntPtr s, IntPtr str) => FunctionLoader.LoadLibuiFunc<uiAttributedStringAppendUnattributed_t>("uiAttributedStringAppendUnattributed")(s, str);

            // _UI_EXTERN void uiAttributedStringInsertAtUnattributed(uiAttributedString* s, const char* str, size_t at);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiAttributedStringInsertAtUnattributed_t(IntPtr s, IntPtr str, UIntPtr at);
            public static void uiAttributedStringInsertAtUnattributed(IntPtr s, IntPtr str, UIntPtr at) => FunctionLoader.LoadLibuiFunc<uiAttributedStringInsertAtUnattributed_t>("uiAttributedStringInsertAtUnattributed")(s, str, at);

            // _UI_EXTERN void uiAttributedStringDelete(uiAttributedString* s, size_t start, size_t end);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiAttributedStringDelete_t(IntPtr s, UIntPtr start, UIntPtr end);
            public static void uiAttributedStringDelete(IntPtr s, UIntPtr start, UIntPtr end) => FunctionLoader.LoadLibuiFunc<uiAttributedStringDelete_t>("uiAttributedStringDelete")(s, start, end);

            // _UI_EXTERN void uiAttributedStringSetAttribute(uiAttributedString* s, uiAttribute* a, size_t start, size_t end);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiAttributedStringSetAttribute_t(IntPtr s, IntPtr a, UIntPtr start, UIntPtr end);
            public static void uiAttributedStringSetAttribute(IntPtr s, IntPtr a, UIntPtr start, UIntPtr end) => FunctionLoader.LoadLibuiFunc<uiAttributedStringSetAttribute_t>("uiAttributedStringSetAttribute")(s, a, start, end);

            // _UI_EXTERN void uiAttributedStringForEachAttribute(const uiAttributedString* s, uiAttributedStringForEachAttributeFunc f, void* data);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiAttributedStringForEachAttribute_t(IntPtr s, uiAttributedStringForEachAttributeFunc f, IntPtr data);
            public static void uiAttributedStringForEachAttribute(IntPtr s, uiAttributedStringForEachAttributeFunc f, IntPtr data) => FunctionLoader.LoadLibuiFunc<uiAttributedStringForEachAttribute_t>("uiAttributedStringForEachAttribute")(s, f, data);

            // _UI_EXTERN size_t uiAttributedStringNumGraphemes(uiAttributedString* s);
            [UnmanagedFunctionPointer(Convention)]
            private delegate UIntPtr uiAttributedStringNumGraphemes_t(IntPtr s);
            public static UIntPtr uiAttributedStringNumGraphemes(IntPtr s) => FunctionLoader.LoadLibuiFunc<uiAttributedStringNumGraphemes_t>("uiAttributedStringNumGraphemes")(s);

            // _UI_EXTERN size_t uiAttributedStringByteIndexToGrapheme(uiAttributedString* s, size_t pos);
            [UnmanagedFunctionPointer(Convention)]
            private delegate UIntPtr uiAttributedStringByteIndexToGrapheme_t(IntPtr s, UIntPtr pos);
            public static UIntPtr uiAttributedStringByteIndexToGrapheme(IntPtr s, UIntPtr pos) => FunctionLoader.LoadLibuiFunc<uiAttributedStringByteIndexToGrapheme_t>("uiAttributedStringByteIndexToGrapheme")(s, pos);

            // _UI_EXTERN size_t uiAttributedStringGraphemeToByteIndex(uiAttributedString* s, size_t pos);
            [UnmanagedFunctionPointer(Convention)]
            private delegate UIntPtr uiAttributedStringGraphemeToByteIndex_t(IntPtr s, UIntPtr pos);
            public static UIntPtr uiAttributedStringGraphemeToByteIndex(IntPtr s, UIntPtr pos) => FunctionLoader.LoadLibuiFunc<uiAttributedStringGraphemeToByteIndex_t>("uiAttributedStringGraphemeToByteIndex")(s, pos);
        }
    }
}