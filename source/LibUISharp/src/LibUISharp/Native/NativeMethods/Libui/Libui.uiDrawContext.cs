using LibUISharp.Drawing;
using System;
using System.Runtime.InteropServices;

namespace LibUISharp.Native
{
    internal static partial class NativeMethods
    {
        internal static partial class Libui
        {
            // _UI_EXTERN void uiDrawStroke(uiDrawContext* c, uiDrawPath* path, uiDrawBrush* b, uiDrawStrokeParams* p);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiDrawStroke_t(IntPtr context, IntPtr path, ref uiDrawBrush brush, ref uiDrawStrokeParams strokeParam);
            public static void uiDrawStroke(IntPtr context, IntPtr path, ref uiDrawBrush brush, ref uiDrawStrokeParams strokeParam) => FunctionLoader.LoadLibuiFunc<uiDrawStroke_t>("uiDrawStroke")(context, path, ref brush, ref strokeParam);

            // _UI_EXTERN void uiDrawFill(uiDrawContext* c, uiDrawPath* path, uiDrawBrush* b);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiDrawFill_t(IntPtr context, IntPtr path, ref uiDrawBrush brush);
            public static void uiDrawFill(IntPtr context, IntPtr path, ref uiDrawBrush brush) => FunctionLoader.LoadLibuiFunc<uiDrawFill_t>("uiDrawFill")(context, path, ref brush);

            // _UI_EXTERN void uiDrawTransform(uiDrawContext* c, uiDrawMatrix* m);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiDrawTransform_t(IntPtr context, Matrix matrix);
            public static void uiDrawTransform(IntPtr context, Matrix matrix) => FunctionLoader.LoadLibuiFunc<uiDrawTransform_t>("uiDrawTransform")(context, matrix);

            // _UI_EXTERN void uiDrawClip(uiDrawContext* c, uiDrawPath* path);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiDrawClip_t(IntPtr context, IntPtr path);
            public static void uiDrawClip(IntPtr context, IntPtr path) => FunctionLoader.LoadLibuiFunc<uiDrawClip_t>("uiDrawClip")(context, path);

            // _UI_EXTERN void uiDrawSave(uiDrawContext* c);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiDrawSave_t(IntPtr context);
            public static void uiDrawSave(IntPtr context) => FunctionLoader.LoadLibuiFunc<uiDrawSave_t>("uiDrawSave")(context);

            // _UI_EXTERN void uiDrawRestore(uiDrawContext* c);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiDrawRestore_t(IntPtr context);
            public static void uiDrawRestore(IntPtr context) => FunctionLoader.LoadLibuiFunc<uiDrawRestore_t>("uiDrawRestore")(context);

            // _UI_EXTERN void uiDrawText(uiDrawContext *c, uiDrawTextLayout *tl, double x, double y);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiDrawText_t(IntPtr c, IntPtr tl, double x, double y);
            public static void uiDrawText(IntPtr c, IntPtr tl, double x, double y) => FunctionLoader.LoadLibuiFunc<uiDrawText_t>("uiDrawText")(c, tl, x, y);
        }
    }
}