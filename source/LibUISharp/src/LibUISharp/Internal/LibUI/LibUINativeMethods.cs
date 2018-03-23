// C Header(s): external\libui\ui.h

using System;
using System.Runtime.InteropServices;

namespace LibUISharp.Internal
{
    internal static class LibUINativeMethods
    {
        [StructLayout(LayoutKind.Sequential)]
        internal class uiAreaHandler
        {
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public uiAreaHandlerDrawDelegate Draw;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public uiAreaHandlerMouseEventDelegate MouseEvent;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public uiAreaHandlerMouseCrossedDelegate MouseCrossed;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public uiAreaHandlerDragBrokenDelegate DragBroken;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public uiAreaHandlerKeyEventDelegate KeyEvent;
        }
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void uiAreaHandlerDrawDelegate(IntPtr handler, IntPtr area, [In, Out]ref uiAreaDrawParams param);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void uiAreaHandlerMouseEventDelegate(IntPtr handler, IntPtr area, [In, Out]ref uiAreaMouseEvent mouseEvent);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void uiAreaHandlerMouseCrossedDelegate(IntPtr handler, IntPtr area, bool left);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void uiAreaHandlerDragBrokenDelegate(IntPtr handler, IntPtr area);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool uiAreaHandlerKeyEventDelegate(IntPtr handler, IntPtr area, [In, Out]ref uiAreaKeyEvent keyEvent);

        public enum uiWindowResizeEdge : uint
        {
            uiWindowResizeEdgeLeft,
            uiWindowResizeEdgeTop,
            uiWindowResizeEdgeRight,
            uiWindowResizeEdgeBottom,
            uiWindowResizeEdgeTopLeft,
            uiWindowResizeEdgeTopRight,
            uiWindowResizeEdgeBottomLeft,
            uiWindowResizeEdgeBottomRight
        }

        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern void uiAreaSetSize(IntPtr area, int width, int height);
        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern void uiAreaQueueReDrawAll(IntPtr area);
        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern void uiAreaScrollTo(IntPtr area, double x, double y, double width, double height);
        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern void uiAreaBeginUserWindowMove(IntPtr area);
        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern void uiAreaBeginUserWindowResize(IntPtr area, uiWindowResizeEdge edge);
        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewArea(uiAreaHandler ah);
        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewScrollingArea(uiAreaHandler ah, int width, int height);

        [StructLayout(LayoutKind.Sequential)]
        internal struct uiAreaDrawParams
        {
            public IntPtr Context;

            //! Only defined for non-scrolling areas.
            public double AreaWidth;
            public double AreaHeight;

            public double ClipX;
            public double ClipY;
            public double ClipWidth;
            public double ClipHeight;
        }

        public enum uiDrawBrushType : uint
        {
            uiDrawBrushTypeSolid,
            uiDrawBrushTypeLinearGradient,
            uiDrawBrushTypeRadialGradient,
            uiDrawBrushTypeImage
        }

        public enum uiDrawLineCap : int
        {
            uiDrawLineCapFlat,
            uiDrawLineCapRound,
            uiDrawLineCapSquare,
        }

        public enum uiDrawLineJoin : int
        {
            uiDrawLineJoinMiter,
            uiDrawLineJoinRound,
            uiDrawLineJoinBevel
        }

        public const double uiDrawDefaultMiterLimit = 10.0;

        public enum uiDrawFillMode : int
        {
            uiDrawFillModeWinding,
            uiDrawFillModeAlternate
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct uiDrawMatrix
        {
            public double M11;
            public double M12;
            public double M21;
            public double M22;
            public double M31;
            public double M32;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct uiDrawBrush
        {
            [MarshalAs(UnmanagedType.I4)]
            public uiDrawBrushType Type;

            // Solid Brushes
            public double R;
            public double G;
            public double B;
            public double A;

            // Gradient Brushes
            public double X0; // linear: start X, radial: start X
            public double Y0; // linear: start Y, radial: start Y
            public double X1; // linear: end X,   radial: outer circle center X
            public double Y1; // linear: end Y,   radial: outer circle center Y
            public double OuterRadius; // radial gradients only
            public IntPtr Stops;
            public UIntPtr NumStops;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct uiDrawBrushGradientStop
        {
            public double Pos;
            public double R;
            public double G;
            public double B;
            public double A;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct uiDrawStrokeParams
        {
            public uiDrawLineCap Cap;
            public uiDrawLineJoin Join;
            public double Thickness;
            public double MiterLimit;
            public IntPtr Dashes;
            public UIntPtr NumDashes;
            public double DashPhase;
        }

        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern IntPtr uiDrawNewPath(uiDrawFillMode fillMode);
        [DllImport(LibUI, CallingConvention = Cdecl,
            SetLastError = true)]
        public static extern void uiDrawFreePath(IntPtr path);

        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern void uiDrawPathNewFigure(IntPtr path, double x, double y);
        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern void uiDrawPathNewFigureWithArc(IntPtr path, double xCenter, double yCenter, double radius, double startAngle, double sweep, bool negative);
        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern void uiDrawPathLineTo(IntPtr path, double x, double y);
        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern void uiDrawPathArcTo(IntPtr path, double xCenter, double yCenter, double radius, double startAngle, double sweep, bool negative);
        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern void uiDrawPathBezierTo(IntPtr path, double c1x, double c1y, double c2x, double c2y, double endX, double endY);
        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern void uiDrawPathCloseFigure(IntPtr path);

        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern void uiDrawPathAddRectangle(IntPtr path, double x, double y, double width, double height);

        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern void uiDrawPathEnd(IntPtr path);

        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern void uiDrawStroke(IntPtr context, IntPtr path, ref uiDrawBrush brush, ref uiDrawStrokeParams strokeParam);
        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern void uiDrawFill(IntPtr context, IntPtr path, ref uiDrawBrush brush);

        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern void uiDrawMatrixSetIdentity(uiDrawMatrix matrix);
        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern void uiDrawMatrixTranslate(uiDrawMatrix matrix, double x, double y);
        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern void uiDrawMatrixScale(uiDrawMatrix matrix, double xCenter, double yCenter, double x, double y);
        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern void uiDrawMatrixRotate(uiDrawMatrix matrix, double x, double y, double amount);
        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern void uiDrawMatrixSkew(uiDrawMatrix matrix, double x, double y, double xamount, double yamount);
        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern void uiDrawMatrixMultiply(uiDrawMatrix dest, uiDrawMatrix src);
        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern bool uiDrawMatrixInvertible(uiDrawMatrix matrix);
        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern int uiDrawMatrixInvert(uiDrawMatrix matrix);
        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern void uiDrawMatrixTransformPoint(uiDrawMatrix matrix, out double x, out double y);
        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern void uiDrawMatrixTransformSize(uiDrawMatrix matrix, out double x, out double y);

        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern void uiDrawTransform(IntPtr context, uiDrawMatrix matrix);

        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern void uiDrawClip(IntPtr context, IntPtr path);

        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern void uiDrawSave(IntPtr context);
        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern void uiDrawRestore(IntPtr context);

        #region ui_attrstr.h
        //TODO: public class uiAttribute

        [DllImport(LibUI, CallingConvention = Cdecl,
            SetLastError = true)]
        public static extern void uiFreeAttribute(IntPtr a);

        public enum uiAttributeType : uint
        {
            uiAttributeTypeFamily,
            uiAttributeTypeSize,
            uiAttributeTypeWeight,
            uiAttributeTypeItalic,
            uiAttributeTypeStretch,
            uiAttributeTypeColor,
            uiAttributeTypeBackground,
            uiAttributeTypeUnderline,
            uiAttributeTypeUnderlineColor,
            uiAttributeTypeFeatures
        }

        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern uiAttributeType uiAttributeGetType(IntPtr a);
        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewFamilyAttribute(IntPtr family);
        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern IntPtr uiAttributeFamily(IntPtr a);
        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewSizeAttribute(double size);
        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern double uiAttributeSize(IntPtr a);

        public enum uiTextWeight : uint
        {
            uiTextWeightMinimum = 0,
            uiTextWeightThin = 100,
            uiTextWeightUltraLight = 200,
            uiTextWeightLight = 300,
            uiTextWeightBook = 350,
            uiTextWeightNormal = 400,
            uiTextWeightMedium = 500,
            uiTextWeightSemiBold = 600,
            uiTextWeightBold = 700,
            uiTextWeightUltraBold = 800,
            uiTextWeightHeavy = 900,
            uiTextWeightUltraHeavy = 950,
            uiTextWeightMaximum = 1000
        }

        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewWeightAttribute(uiTextWeight weight);
        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern uiTextWeight uiAttributeWeight(IntPtr a);

        public enum uiTextItalic : uint
        {
            uiTextItalicNormal,
            uiTextItalicOblique,
            uiTextItalicItalic
        }

        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewItalicAttribute(uiTextItalic italic);
        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern uiTextItalic uiAttributeItalic(IntPtr a);

        public enum uiTextStretch : uint
        {
            uiTextStretchUltraCondensed,
            uiTextStretchExtraCondensed,
            uiTextStretchCondensed,
            uiTextStretchSemiCondensed,
            uiTextStretchNormal,
            uiTextStretchSemiExpanded,
            uiTextStretchExpanded,
            uiTextStretchExtraExpanded,
            uiTextStretchUltraExpanded
        }

        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewStretchAttribute(uiTextStretch stretch);
        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern uiTextStretch uiAttributeStretch(IntPtr a);
        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewColorAttribute(double r, double g, double b, double a);
        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern void uiAttributeColor(IntPtr a, out double r, out double g, out double b, out double alpha);
        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewBackgroundAttribute(double r, double g, double b, double a);

        public enum uiUnderline : uint
        {
            uiUnderlineNone,
            uiUnderlineSingle,
            uiUnderlineDouble,
            uiUnderlineSuggestion, // wavy or dotted underlines used for spelling/grammar checkers
        }

        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewUnderlineAttribute(uiUnderline u);
        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern uiUnderline uiAttributeUnderline(IntPtr a);

        public enum uiUnderlineColor : uint
        {
            uiUnderlineColorCustom,
            uiUnderlineColorSpelling,
            uiUnderlineColorGrammar,
            uiUnderlineColorAuxiliary, // for instance, the color used by smart replacements on macOS or in Microsoft Office
        }

        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewUnderlineColorAttribute(uiUnderlineColor u, double r, double g, double b, double a);
        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern void uiAttributeUnderline(IntPtr a, out uiUnderlineColor u, out double r, out double g, out double b, out double alpha);

        //TODO: public class uiOpenTypeFeatures

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uiForEach uiOpenTypeFeaturesForEachFunc(IntPtr otf, byte a, byte b, byte c, byte d, uint value, IntPtr data);
        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewOpenTypeFeatures();
        [DllImport(LibUI, CallingConvention = Cdecl,
            SetLastError = true)]
        public static extern void uiFreeOpenTypeFeatures(IntPtr otf);
        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern IntPtr uiOpenTypeFeaturesClone(IntPtr otf);
        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern void uiOpenTypeFeaturesAdd(IntPtr otf, byte a, byte b, byte c, byte d, uint value);
        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern void uiOpenTypeFeaturesRemove(IntPtr otf, byte a, byte b, byte c, byte d);
        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern int uiOpenTypeFeaturesGet(IntPtr otf, byte a, byte b, byte c, byte d, out uint value);
        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern void uiOpenTypeFeaturesForEach(IntPtr otf, uiOpenTypeFeaturesForEachFunc f, IntPtr data);
        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewFeaturesAttribute(IntPtr otf);
        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern IntPtr uiAttributeFeatures(IntPtr a);

        //TODO: public class uiAttributedString

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uiForEach uiAttributedStringForEachAttributeFunc(IntPtr s, IntPtr a, UIntPtr start, UIntPtr end, IntPtr data);

        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewAttributedString(IntPtr initialString);
        [DllImport(LibUI, CallingConvention = Cdecl,
            SetLastError = true)]
        public static extern void uiFreeAttributedString(IntPtr s);
        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern IntPtr uiAttributedStringString(IntPtr s);
        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern UIntPtr uiAttributedStringLen(IntPtr s);
        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern void uiAttributedStringAppendUnattributed(IntPtr s, IntPtr str);
        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern void uiAttributedStringInsertAtUnattributed(IntPtr s, IntPtr str, UIntPtr at);
        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern void uiAttributedStringDelete(IntPtr s, UIntPtr start, UIntPtr end);
        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern void uiAttributedStringSetAttribute(IntPtr s, IntPtr a, UIntPtr start, UIntPtr end);
        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern void uiAttributedStringForEachAttribute(IntPtr s, uiAttributedStringForEachAttributeFunc f, IntPtr data);
        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern UIntPtr uiAttributedStringNumGraphemes(IntPtr s);
        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern UIntPtr uiAttributedStringByteIndexToGrapheme(IntPtr s, UIntPtr pos);
        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern UIntPtr uiAttributedStringGraphemeToByteIndex(IntPtr s, UIntPtr pos);

        //TODO: public class uiFontDescriptor

        public struct uiDrawFontDescriptor
        {
            IntPtr Family;
            double Size;
            uiTextWeight Weight;
            uiTextItalic Italic;
            uiTextStretch Stretch;
        }

        //TODO: public class uiDrawTextLayout

        public enum uiDrawTextAlign : uint
        {
            uiDrawTextAlignLeft,
            uiDrawTextAlignCenter,
            uiDrawTextAlignRight
        }

        public struct uiDrawTextLayoutParams
        {
            IntPtr String;
            uiDrawFontDescriptor DefaultFont;
            double Width;
            uiDrawTextAlign Align;
        }

        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern IntPtr uiDrawNewTextLayout(uiDrawTextLayoutParams param);
        [DllImport(LibUI, CallingConvention = Cdecl,
            SetLastError = true)]
        public static extern void uiDrawFreeTextLayout(IntPtr tl);
        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern void uiDrawText(IntPtr c, IntPtr tl, double x, double y);
        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern void uiDrawTextLayoutExtents(IntPtr tl, out double width, out double height);
        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern int uiDrawTextLayoutNumLines(IntPtr tl);
        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern void UIDrawTextLayoutLineByteRange(IntPtr tl, int line, out IntPtr start, out IntPtr end);
        #endregion

        [Flags]
        public enum uiModifiers : uint
        {
            uiModifierCtrl = 1 << 0,
            uiModifierAlt = 1 << 1,
            uiModifierShift = 1 << 2,
            uiModifierSuper = 1 << 3
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct uiAreaMouseEvent
        {
            public double X;
            public double Y;

            public double AreaWidth;
            public double AreaHeight;

            public bool Down;
            public bool Up;

            public int Count;

            public uiModifiers Modifiers;

            public ulong Held1To64;
        }

        // uiExtKey => LibUISharp.Drawing.ExtensionKey
        public enum uiExtKey : uint
        {
            uiExtKeyEscape = 1,
            uiExtKeyInsert, // equivalent to "Help" on Apple keyboards
            uiExtKeyDelete,
            uiExtKeyHome,
            uiExtKeyEnd,
            uiExtKeyPageUp,
            uiExtKeyPageDown,
            uiExtKeyUp,
            uiExtKeyDown,
            uiExtKeyLeft,
            uiExtKeyRight,
            uiExtKeyF1, // F1..F12 are guaranteed to be consecutive
            uiExtKeyF2,
            uiExtKeyF3,
            uiExtKeyF4,
            uiExtKeyF5,
            uiExtKeyF6,
            uiExtKeyF7,
            uiExtKeyF8,
            uiExtKeyF9,
            uiExtKeyF10,
            uiExtKeyF11,
            uiExtKeyF12,
            uiExtKeyN0, // numpad keys; independent of Num Lock state
            uiExtKeyN1, // N0..N9 are guaranteed to be consecutive
            uiExtKeyN2,
            uiExtKeyN3,
            uiExtKeyN4,
            uiExtKeyN5,
            uiExtKeyN6,
            uiExtKeyN7,
            uiExtKeyN8,
            uiExtKeyN9,
            uiExtKeyNDot,
            uiExtKeyNEnter,
            uiExtKeyNAdd,
            uiExtKeyNSubtract,
            uiExtKeyNMultiply,
            uiExtKeyNDivide
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct uiAreaKeyEvent
        {
            public byte Key;
            public uiExtKey ExtKey;
            public uiModifiers Modifier;
            public uiModifiers Modifiers;
            public bool Up;
        }

        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern void uiColorButtonColor(IntPtr button, out double red, out double green, out double blue, out double alpha);
        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern void uiColorButtonSetColor(IntPtr button, double red, double green, double blue, double alpha);
        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern void uiColorButtonOnChanged(IntPtr button, uiColorButtonOnChangedDelegate colorButtonOnChanged, IntPtr data);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void uiColorButtonOnChangedDelegate(IntPtr button, IntPtr data);
        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewColorButton();

        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern void uiFormAppend(IntPtr form, IntPtr label, IntPtr child, bool stretchy);
        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern void uiFormDelete(IntPtr form, int index);
        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern bool uiFormPadded(IntPtr form);
        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern void uiFormSetPadded(IntPtr form, bool padded);
        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewForm();

        public enum uiAlign : uint
        {
            uiAlignFill,
            uiAlignStart,
            uiAlignCenter,
            uiAlignEnd
        }

        public enum uiAt : uint
        {
            uiAtLeading,
            uiAtTop,
            uiAtTrailing,
            uiAtBottom
        }

        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern void uiGridAppend(IntPtr grid, IntPtr child, int left, int top, int xspan, int yspan, int hexpand, uiAlign halign, int vexpand, uiAlign valign);
        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern void uiGridInsertAt(IntPtr grid, IntPtr child, IntPtr existing, uiAt at, int xspan, int yspan, int hexpand, uiAlign halign, int vexpand, uiAlign valign);
        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern bool uiGridPadded(IntPtr grid);
        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern void uiGridSetPadded(IntPtr grid, bool padded);
        [DllImport(LibUI, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewGrid();
    }
}