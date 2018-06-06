using System.Runtime.InteropServices;

namespace LibUISharp.Native
{
    internal static partial class NativeMethods
    {
        internal static partial class Libui
        {
            [StructLayout(Layout)]
            internal struct uiDrawMatrix
            {
                public double M11;
                public double M12;
                public double M21;
                public double M22;
                public double M31;
                public double M32;
            }

            // _UI_EXTERN void uiDrawMatrixSetIdentity(uiDrawMatrix* m);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiDrawMatrixSetIdentity_t(uiDrawMatrix matrix);
            public static void uiDrawMatrixSetIdentity(uiDrawMatrix matrix) => FunctionLoader.LoadLibuiFunc<uiDrawMatrixSetIdentity_t>("uiDrawMatrixSetIdentity")(matrix);

            // _UI_EXTERN void uiDrawMatrixTranslate(uiDrawMatrix* m, double x, double y);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiDrawMatrixTranslate_t(uiDrawMatrix matrix, double x, double y);
            public static void uiDrawMatrixTranslate(uiDrawMatrix matrix, double x, double y) => FunctionLoader.LoadLibuiFunc<uiDrawMatrixTranslate_t>("uiDrawMatrixTranslate")(matrix, x, y);

            // _UI_EXTERN void uiDrawMatrixScale(uiDrawMatrix* m, double xCenter, double yCenter, double x, double y);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiDrawMatrixScale_t(uiDrawMatrix matrix, double xCenter, double yCenter, double x, double y);
            public static void uiDrawMatrixScale(uiDrawMatrix matrix, double xCenter, double yCenter, double x, double y) => FunctionLoader.LoadLibuiFunc<uiDrawMatrixScale_t>("uiDrawMatrixScale")(matrix, xCenter, yCenter, x, y);

            // _UI_EXTERN void uiDrawMatrixRotate(uiDrawMatrix* m, double x, double y, double amount);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiDrawMatrixRotate_t(uiDrawMatrix matrix, double x, double y, double amount);
            public static void uiDrawMatrixRotate(uiDrawMatrix matrix, double x, double y, double amount) => FunctionLoader.LoadLibuiFunc<uiDrawMatrixRotate_t>("uiDrawMatrixRotate")(matrix, x, y, amount);

            // _UI_EXTERN void uiDrawMatrixSkew(uiDrawMatrix* m, double x, double y, double xamount, double yamount);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiDrawMatrixSkew_t(uiDrawMatrix matrix, double x, double y, double xamount, double yamount);
            public static void uiDrawMatrixSkew(uiDrawMatrix matrix, double x, double y, double xamount, double yamount) => FunctionLoader.LoadLibuiFunc<uiDrawMatrixSkew_t>("uiDrawMatrixSkew")(matrix, x, y, xamount, yamount);

            // _UI_EXTERN void uiDrawMatrixMultiply(uiDrawMatrix* dest, uiDrawMatrix* src);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiDrawMatrixMultiply_t(uiDrawMatrix dest, uiDrawMatrix src);
            public static void uiDrawMatrixMultiply(uiDrawMatrix dest, uiDrawMatrix src) => FunctionLoader.LoadLibuiFunc<uiDrawMatrixMultiply_t>("uiDrawMatrixMultiply")(dest, src);

            // _UI_EXTERN int uiDrawMatrixInvertible(uiDrawMatrix* m);
            [UnmanagedFunctionPointer(Convention)]
            private delegate bool uiDrawMatrixInvertible_t(uiDrawMatrix matrix);
            public static bool uiDrawMatrixInvertible(uiDrawMatrix matrix) => FunctionLoader.LoadLibuiFunc<uiDrawMatrixInvertible_t>("uiDrawMatrixInvertible")(matrix);

            // _UI_EXTERN int uiDrawMatrixInvert(uiDrawMatrix* m);
            [UnmanagedFunctionPointer(Convention)]
            private delegate int uiDrawMatrixInvert_t(uiDrawMatrix matrix);
            public static int uiDrawMatrixInvert(uiDrawMatrix matrix) => FunctionLoader.LoadLibuiFunc<uiDrawMatrixInvert_t>("uiDrawMatrixInvert")(matrix);

            // _UI_EXTERN void uiDrawMatrixTransformPoint(uiDrawMatrix* m, double* x, double* y);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiDrawMatrixTransformPoint_t(uiDrawMatrix matrix, out double x, out double y);
            public static void uiDrawMatrixTransformPoint(uiDrawMatrix matrix, out double x, out double y) => FunctionLoader.LoadLibuiFunc<uiDrawMatrixTransformPoint_t>("uiDrawMatrixTransformPoint")(matrix, out x, out y);

            // _UI_EXTERN void uiDrawMatrixTransformSize(uiDrawMatrix* m, double* x, double* y);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiDrawMatrixTransformSize_t(uiDrawMatrix matrix, out double x, out double y);
            public static void uiDrawMatrixTransformSize(uiDrawMatrix matrix, out double x, out double y) => FunctionLoader.LoadLibuiFunc<uiDrawMatrixTransformSize_t>("uiDrawMatrixTransformSize")(matrix, out x, out y);
        }
    }
}