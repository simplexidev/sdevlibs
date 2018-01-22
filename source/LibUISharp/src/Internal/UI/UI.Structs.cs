using System;
using System.Runtime.InteropServices;
using LibUISharp.Drawing;
using LibUISharp.Drawing.Text;

namespace LibUISharp.Internal
{
    internal static partial class UI
    {
        [StructLayout(LayoutKind.Sequential)]
        internal struct uiInitOptions
        {
            public UIntPtr Size;
        }
        // struct uiInitOptions {
        //     size_t Size;
        // };

        //! Only needed if wanting to use actual C# pointers (ex. uiControl*).
        // struct uiControl {
        //     uint32_t Signature;
        //     uint32_t OSSignature;
        //     uint32_t TypeSignature;
        //     void (*Destroy)(uiControl *);
        //     uintptr_t (*Handle)(uiControl *);
        //     uiControl *(*Parent)(uiControl *);
        //     void (*SetParent)(uiControl *, uiControl *);
        //     int (*Toplevel)(uiControl *);
        //     int (*Visible)(uiControl *);
        //     void (*Show)(uiControl *);
        //     void (*Hide)(uiControl *);
        //     int (*Enabled)(uiControl *);
        //     void (*Enable)(uiControl *);
        //     void (*Disable)(uiControl *);
        // };

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
        // struct uiAreaHandler {
        //     void (*Draw)(uiAreaHandler *, uiArea *, uiAreaDrawParams *);
        //     void (*MouseEvent)(uiAreaHandler *, uiArea *, uiAreaMouseEvent *);
        //     void (*MouseCrossed)(uiAreaHandler *, uiArea *, int left);
        //     void (*DragBroken)(uiAreaHandler *, uiArea *);
        //     int (*KeyEvent)(uiAreaHandler *, uiArea *, uiAreaKeyEvent *);
        // };

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
        // struct uiAreaDrawParams
        //     uiDrawContext *Context;

        //     double AreaWidth;
        //     double AreaHeight;

        //     double ClipX;
        //     double ClipY
        //     double ClipWidth;
        //     double ClipWidth;
        // };

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
        // struct uiDrawMatrix {
        //     double M11;
        //     double M12;
        //     double M21;
        //     double M22;
        //     double M31;
        //     double M32;
        // };

        [StructLayout(LayoutKind.Sequential)]
        internal struct uiDrawBrush
        {
            [MarshalAs(UnmanagedType.I4)]
            public BrushType BrushType;

            // Solid Brushes
            public double R;
            public double G;
            public double B;
            public double A;

            // Gradient Brushes
            public double X0;      // linear: start X, radial: start X
            public double Y0;      // linear: start Y, radial: start Y
            public double X1;      // linear: end X, radial: outer circle center X
            public double Y1;      // linear: end Y, radial: outer circle center Y
            public double OuterRadius;      // radial gradients only

            public IntPtr Stops;
            public UIntPtr NumStops;
        }
        // struct uiDrawBrush {
        //     uiDrawBrushType Type;
        //
        //     double R;
        //     double G;
        //     double B;
        //     double A;
        //
        //     double X0;
        //     double Y0;
        //     double X1;
        //     double Y1;
        //     double OuterRadius;
        //     uiDrawBrushGradientStop *Stops;
        //     size_t NumStops;
        // };

        [StructLayout(LayoutKind.Sequential)]
        internal struct uiDrawBrushGradientStop
        {
            public double Position;
            public double R;
            public double G;
            public double B;
            public double A;
        }
        // struct uiDrawBrushGradientStop {
        //     double Pos;
        //     double R;
        //     double G;
        //     double B;
        //     double A;
        // };

        [StructLayout(LayoutKind.Sequential)]
        internal struct uiDrawStrokeParams
        {
            public LineCap LineCap;
            public LineJoin LineJoin;
            public double Thickness;
            public double MiterLimit;
            public IntPtr Dashes;
            public UIntPtr NumDashes;
            public double DashPhase;
        }
        // struct uiDrawStrokeParams {
        //     uiDrawLineCap Cap;
        //     uiDrawLineJoin Join;
        //     double Thickness;
        //     double MiterLimit;
        //     double *Dashes;
        //     size_t NumDashes;
        //     double DashPhase;
        // };

        [StructLayout(LayoutKind.Sequential)]
        internal struct uiAttributeSpec
        {
            public TextAttribute Type;
            public IntPtr Family;
            public UIntPtr Value;
            public double Double;
            public double R;
            public double G;
            public double B;
            public double A;
            public IntPtr Features;
        }
        // struct uiAttributeSpec {
        //     uiAttribute Type;
        //     const char *Family;
        //     uintptr_t Value;
        //     double Double;
        //     double R;
        //     double G;
        //     double B;
        //     double A;
        //     const uiOpenTypeFeatures *Features;
        //};

        [StructLayout(LayoutKind.Sequential)]
        internal struct uiDrawFontDescriptor
        {
            public IntPtr Family;
            public double Size;
            public FontWeight Weight;
            public FontStyle Style;
            public FontStretch Stretch;
        }
        // struct uiDrawFontDescriptor {
        //     char *Family;
        //     double Size;
        //     uiDrawTextWeight Weight;
        //     uiDrawTextItalic Italic;
        //     uiDrawTextStretch Stretch;
        // };

        [StructLayout(LayoutKind.Sequential)]
        internal struct uiDrawTextLayoutParams
        {
            public IntPtr Text;
            public uiDrawFontDescriptor DefaultFont;
            public double Width;
            public TextAlignment Align;
        }
        // struct uiDrawTextLayoutParams {
        //     uiAttributedString *String;
        //     uiDrawFontDescriptor *DefaultFont;
        //     double Width;
        //     uiDrawTextAlign Align;
        // };

        [StructLayout(LayoutKind.Sequential)]
        internal struct uiDrawTextLayoutLineMetrics
        {
            // Overall box bounds
            public double X;
            public double Y;
            public double Width;
            public double Height;

            // Typographic bounds
            public double BaselineY;
            public double Ascent;
            public double Descent;
            public double Leading;

            // This describes any additional whitespace.
            public double ParagraphSpacingBefore;
            public double LineHeightSpace;
            public double LineSpacing;
            public double ParagraphSpacing;
        }
        // struct uiDrawTextLayoutLineMetrics {
        //     double X;
        //     double Y;
        //     double Width;
        //     double Height;
        //
        //     double BaselineY;
        //     double Ascent;
        //     double Descent;
        //     double Leading;
        //
        //     double ParagraphSpacingBefore;
        //     double LineHeightSpace;
        //     double LineSpacing;
        //     double ParagraphSpacing;
        // };

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

            public ModifierKeyFlags Modifiers;

            public ulong Held1To64;
        }
        // struct uiAreaMouseEvent {
        //     double X;
        //     double Y;
        //
        //     double AreaWidth;
        //     double AreaHeight;
        //
        //     int Down;
        //     int Up;
        //
        //     int Count;
        //
        //     uiModifiers Modifiers;
        //
        //     uint64_t Held1To64;
        // };

        [StructLayout(LayoutKind.Sequential)]
        internal struct uiAreaKeyEvent
        {
            public byte Key;
            public ExtensionKey ExtKey;
            public ModifierKeyFlags Modifier;
            public ModifierKeyFlags Modifiers;
            public bool Up;
        }
        // struct uiAreaKeyEvent {
        //     char Key;
        //     uiExtKey ExtKey;
        //     uiModifiers Modifier;
        //
        //     uiModifiers Modifiers;
        //
        //     int Up;
        // };
        //
    }
}