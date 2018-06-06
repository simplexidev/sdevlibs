using LibUISharp.Drawing;
using System;
using System.Runtime.InteropServices;

namespace LibUISharp.Native
{
    internal static partial class NativeMethods
    {
        internal static partial class Libui
        {
            // _UI_EXTERN uiDrawPath *uiDrawNewPath(uiDrawFillMode fillMode);
            [UnmanagedFunctionPointer(Convention)]
            private delegate IntPtr uiDrawNewPath_t(FillMode fillMode);
            public static IntPtr uiDrawNewPath(FillMode fillMode) => FunctionLoader.LoadLibuiFunc<uiDrawNewPath_t>("uiDrawNewPath")(fillMode);

            // _UI_EXTERN void uiDrawFreePath(uiDrawPath *p);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiDrawFreePath_t(IntPtr p);
            public static void uiDrawFreePath(IntPtr p) => FunctionLoader.LoadLibuiFunc<uiDrawFreePath_t>("uiDrawFreePath")(p);

            // _UI_EXTERN void uiDrawPathNewFigure(uiDrawPath *p, double x, double y);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiDrawPathNewFigure_t(IntPtr p, double x, double y);
            public static void uiDrawPathNewFigure(IntPtr p, double x, double y) => FunctionLoader.LoadLibuiFunc<uiDrawPathNewFigure_t>("uiDrawPathNewFigure")(p, x, y);

            // _UI_EXTERN void uiDrawPathNewFigureWithArc(uiDrawPath *p, double xCenter, double yCenter, double radius, double startAngle, double sweep, int negative);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiDrawPathNewFigureWithArc_t(IntPtr p, double xCenter, double yCenter, double radius, double startAngle, double sweep, bool negative);
            public static void uiDrawPathNewFigureWithArc(IntPtr p, double xCenter, double yCenter, double radius, double startAngle, double sweep, bool negative) => FunctionLoader.LoadLibuiFunc<uiDrawPathNewFigureWithArc_t>("uiDrawPathNewFigureWithArc")(p, xCenter, yCenter, radius, startAngle, sweep, negative);

            // _UI_EXTERN void uiDrawPathLineTo(uiDrawPath *p, double x, double y);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiDrawPathLineTo_t(IntPtr p, double x, double y);
            public static void uiDrawPathLineTo(IntPtr p, double x, double y) => FunctionLoader.LoadLibuiFunc<uiDrawPathLineTo_t>("uiDrawPathLineTo")(p, x, y);

            // _UI_EXTERN void uiDrawPathArcTo(uiDrawPath *p, double xCenter, double yCenter, double radius, double startAngle, double sweep, int negative);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiDrawPathArcTo_t(IntPtr p, double xCenter, double yCenter, double radius, double startAngle, double sweep, bool negative);
            public static void uiDrawPathArcTo(IntPtr p, double xCenter, double yCenter, double radius, double startAngle, double sweep, bool negative) => FunctionLoader.LoadLibuiFunc<uiDrawPathArcTo_t>("uiDrawPathArcTo")(p, xCenter, yCenter, radius, startAngle, sweep, negative);

            // _UI_EXTERN void uiDrawPathBezierTo(uiDrawPath *p, double c1x, double c1y, double c2x, double c2y, double endX, double endY);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiDrawPathBezierTo_t(IntPtr p, double c1x, double c1y, double c2x, double c2y, double endX, double endY);
            public static void uiDrawPathBezierTo(IntPtr p, double c1x, double c1y, double c2x, double c2y, double endX, double endY) => FunctionLoader.LoadLibuiFunc<uiDrawPathBezierTo_t>("uiDrawPathBezierTo")(p, c1x, c1y, c2x, c2y, endX, endY);

            // _UI_EXTERN void uiDrawPathCloseFigure(uiDrawPath *p);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiDrawPathCloseFigure_t(IntPtr p);
            public static void uiDrawPathCloseFigure(IntPtr p) => FunctionLoader.LoadLibuiFunc<uiDrawPathCloseFigure_t>("uiDrawPathCloseFigure")(p);

            // _UI_EXTERN void uiDrawPathAddRectangle(uiDrawPath *p, double x, double y, double width, double height);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiDrawPathAddRectangle_t(IntPtr p, double x, double y, double width, double height);
            public static void uiDrawPathAddRectangle(IntPtr p, double x, double y, double width, double height) => FunctionLoader.LoadLibuiFunc<uiDrawPathAddRectangle_t>("uiDrawPathAddRectangle")(p, x, y, width, height);

            // _UI_EXTERN void uiDrawPathEnd(uiDrawPath *p);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiDrawPathEnd_t(IntPtr p);
            public static void uiDrawPathEnd(IntPtr p) => FunctionLoader.LoadLibuiFunc<uiDrawPathEnd_t>("uiDrawPathEnd")(p);
        }
    }
}