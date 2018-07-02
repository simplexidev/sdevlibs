using LibUISharp.Drawing;
using System.Runtime.InteropServices;

namespace LibUISharp.Native
{
    internal static partial class NativeMethods
    {
        internal static partial class Libui
        {
            // _UI_EXTERN void uiDrawMatrixSetIdentity(uiDrawMatrix* m);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiDrawMatrixSetIdentity_t(Matrix matrix);
            public static void uiDrawMatrixSetIdentity(Matrix matrix) => FunctionLoader.LoadLibuiFunc<uiDrawMatrixSetIdentity_t>("uiDrawMatrixSetIdentity")(matrix);

            // _UI_EXTERN void uiDrawMatrixTranslate(uiDrawMatrix* m, double x, double y);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiDrawMatrixTranslate_t(Matrix matrix, double x, double y);
            public static void uiDrawMatrixTranslate(Matrix matrix, double x, double y) => FunctionLoader.LoadLibuiFunc<uiDrawMatrixTranslate_t>("uiDrawMatrixTranslate")(matrix, x, y);

            // _UI_EXTERN void uiDrawMatrixScale(uiDrawMatrix* m, double xCenter, double yCenter, double x, double y);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiDrawMatrixScale_t(Matrix matrix, double xCenter, double yCenter, double x, double y);
            public static void uiDrawMatrixScale(Matrix matrix, double xCenter, double yCenter, double x, double y) => FunctionLoader.LoadLibuiFunc<uiDrawMatrixScale_t>("uiDrawMatrixScale")(matrix, xCenter, yCenter, x, y);

            // _UI_EXTERN void uiDrawMatrixRotate(uiDrawMatrix* m, double x, double y, double amount);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiDrawMatrixRotate_t(Matrix matrix, double x, double y, double amount);
            public static void uiDrawMatrixRotate(Matrix matrix, double x, double y, double amount) => FunctionLoader.LoadLibuiFunc<uiDrawMatrixRotate_t>("uiDrawMatrixRotate")(matrix, x, y, amount);

            // _UI_EXTERN void uiDrawMatrixSkew(uiDrawMatrix* m, double x, double y, double xamount, double yamount);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiDrawMatrixSkew_t(Matrix matrix, double x, double y, double xamount, double yamount);
            public static void uiDrawMatrixSkew(Matrix matrix, double x, double y, double xamount, double yamount) => FunctionLoader.LoadLibuiFunc<uiDrawMatrixSkew_t>("uiDrawMatrixSkew")(matrix, x, y, xamount, yamount);

            // _UI_EXTERN void uiDrawMatrixMultiply(uiDrawMatrix* dest, uiDrawMatrix* src);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiDrawMatrixMultiply_t(Matrix dest, Matrix src);
            public static void uiDrawMatrixMultiply(Matrix dest, Matrix src) => FunctionLoader.LoadLibuiFunc<uiDrawMatrixMultiply_t>("uiDrawMatrixMultiply")(dest, src);

            // _UI_EXTERN int uiDrawMatrixInvertible(uiDrawMatrix* m);
            [UnmanagedFunctionPointer(Convention)]
            private delegate bool uiDrawMatrixInvertible_t(Matrix matrix);
            public static bool uiDrawMatrixInvertible(Matrix matrix) => FunctionLoader.LoadLibuiFunc<uiDrawMatrixInvertible_t>("uiDrawMatrixInvertible")(matrix);

            // _UI_EXTERN int uiDrawMatrixInvert(uiDrawMatrix* m);
            [UnmanagedFunctionPointer(Convention)]
            private delegate int uiDrawMatrixInvert_t(Matrix matrix);
            public static int uiDrawMatrixInvert(Matrix matrix) => FunctionLoader.LoadLibuiFunc<uiDrawMatrixInvert_t>("uiDrawMatrixInvert")(matrix);

            // _UI_EXTERN void uiDrawMatrixTransformPoint(uiDrawMatrix* m, double* x, double* y);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiDrawMatrixTransformPoint_t(Matrix matrix, out double x, out double y);
            public static void uiDrawMatrixTransformPoint(Matrix matrix, out double x, out double y) => FunctionLoader.LoadLibuiFunc<uiDrawMatrixTransformPoint_t>("uiDrawMatrixTransformPoint")(matrix, out x, out y);

            // _UI_EXTERN void uiDrawMatrixTransformSize(uiDrawMatrix* m, double* x, double* y);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiDrawMatrixTransformSize_t(Matrix matrix, out double x, out double y);
            public static void uiDrawMatrixTransformSize(Matrix matrix, out double x, out double y) => FunctionLoader.LoadLibuiFunc<uiDrawMatrixTransformSize_t>("uiDrawMatrixTransformSize")(matrix, out x, out y);
        }
    }
}