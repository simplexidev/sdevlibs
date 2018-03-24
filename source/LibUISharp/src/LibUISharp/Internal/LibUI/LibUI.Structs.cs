using System;
using System.Runtime.InteropServices;

namespace LibUISharp.Internal
{
    internal static partial class LibUI
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct uiInitOptions
        {
            public uiInitOptions(UIntPtr size) => Size = size;
            public UIntPtr Size;
        }
        [StructLayout(LayoutKind.Sequential)]
        internal class uiAreaHandler
        {
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public uiDrawHandler Draw;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public uiMouseEventHandler MouseEvent;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public uiMouseCrossedHandler MouseCrossed;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public uiDragBrokenHandler DragBroken;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public uiKeyEventHandler KeyEvent;
        }

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

        public struct uiFontDescriptor
        {
            IntPtr Family;
            double Size;
            uiTextWeight Weight;
            uiTextItalic Italic;
            uiTextStretch Stretch;
        }

        public struct uiDrawTextLayoutParams
        {
            IntPtr String;
            uiFontDescriptor DefaultFont;
            double Width;
            uiDrawTextAlign Align;
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

        [StructLayout(LayoutKind.Sequential)]
        internal struct uiAreaKeyEvent
        {
            public byte Key;
            public uiExtKey ExtKey;
            public uiModifiers Modifier;
            public uiModifiers Modifiers;
            public bool Up;
        }
    }
}