using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using LibUISharp.Internal;

namespace LibUISharp.Drawing
{
    /// <summary>
    /// Defines objects used to paint graphical objects. Classes that derive from <see cref="Brush"/> describe how the area is painted.
    /// </summary>
    [NativeType("uiDrawBrush")]
    [Serializable]
    [StructLayout(Libraries.Libui.StructLayout)]
    public abstract class Brush
    {
        [MarshalAs(UnmanagedType.I4)]
        internal BrushType type;

        // Solid Brushes
        internal double r, g, b, a;

        // Gradient Brushes
        // X0          - Linear: StartX, Radial: StartX
        // Y0          - Linear: StartY, Radial: StartY
        // X1          - Linear: EndX,   Radial: CenterX (of outer circle)
        // Y1          - Linear: EndY,   Radial: CenterY (of outer circle)
        // outerRadius - Linear: Unused, Radial: Used
        internal double x0, y0, x1, y1, outerRadius;
        internal IntPtr stops;
        internal UIntPtr numStops;
    }

    /// <summary>
    /// Paints an area with a solid color.
    /// </summary>
    [Serializable]
    [StructLayout(Libraries.Libui.StructLayout)]
    public sealed class SolidBrush : Brush
    {
        private Color color;

        /// <summary>
        /// Initializes a new instance of the <see cref="SolidBrush"/> class.
        /// </summary>
        public SolidBrush() => type = BrushType.Solid;

        /// <summary>
        /// Initializes a new instance of the <see cref="SolidBrush"/> class of the specified color..
        /// </summary>
        /// <param name="color">The specified color.</param>
        public SolidBrush(Color color) : this() => Color = color;

        /// <summary>
        /// Gets or sets the <see cref="Drawing.Color"/> of this <see cref="SolidBrush"/>.
        /// </summary>
        public Color Color
        {
            get
            {
                color = new Color(r, g, b, a);
                return color;
            }
            set
            {
                if (color != value)
                {
                    r = value.R;
                    g = value.G;
                    b = value.B;
                    a = value.A;
                    color = value;
                }
            }
        }
    }

    /// <summary>
    /// An abstract class that describes a gradient, composed of gradient stops. Classes that inherit from <see cref="GradientBrush"/> describe different ways of interpreting gradient stops.
    /// </summary>
    [Serializable]
    [StructLayout(Libraries.Libui.StructLayout)]
    public abstract class GradientBrush : Brush
    {
        // linear: start X
        // radial: start X
        private protected double X0
        {
            get => x0;
            set => x0 = value;
        }

        // linear: start Y
        // radial: start Y
        private protected double Y0
        {
            get => y0;
            set => y0 = value;
        }

        // linear: end X
        // radial: outer circle center X
        private protected double X1
        {
            get => x1;
            set => x1 = value;
        }

        // linear: end Y
        // radial: outer circle center Y
        private protected double Y1
        {
            get => y1;
            set => y1 = value;
        }

        /// <summary>
        /// Gets or sets the brush's gradient stops.
        /// </summary>
        public List<GradientStop> GradientStops
        {
            set
            {
                if (value != null && value.Count != 0)
                {
                    numStops = (UIntPtr)value.Count;
                    stops = Marshal.UnsafeAddrOfPinnedArrayElement(value.ToArray(), 0);
                }
            }
        }
    }

    /// <summary>
    /// Paints an area with a linear gradient.
    /// </summary>
    [Serializable]
    [StructLayout(Libraries.Libui.StructLayout)]
    public sealed class LinearGradientBrush : GradientBrush
    {
        private PointD start = new PointD();
        private PointD end = new PointD(1.0, 1.0);

        /// <summary>
        /// Initializes a new instance of the <see cref="LinearGradientBrush"/> class.
        /// </summary>
        public LinearGradientBrush() => type = BrushType.LinearGradient;

        /// <summary>
        /// Gets or sets the starting two-dimensional coordinates of the linear gradient.
        /// </summary>
        public PointD StartPoint
        {
            get
            {
                start = new PointD(X0, Y0);
                return start;
            }
            set
            {
                if (start != value)
                {
                    X0 = value.X;
                    Y0 = value.Y;
                    start = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the ending two-dimensional coordinates of the linear gradient.
        /// </summary>
        public PointD EndPoint
        {
            get
            {
                end = new PointD(X1, Y1);
                return end;
            }
            set
            {
                if (end != value)
                {
                    X1 = value.X;
                    Y1 = value.Y;
                    end = value;
                }
            }
        }
    }

    /// <summary>
    /// Paints an area with a radial gradient. A focal point defines the beginning of the gradient, and a circle defines the end point of the gradient.
    /// </summary>
    [Serializable]
    [StructLayout(Libraries.Libui.StructLayout)]
    public sealed class RadialGradientBrush : GradientBrush
    {
        private PointD origin, center = new PointD(0.5, 0.5);

        /// <summary>
        /// Initializes a new instance of the <see cref="RadialGradientBrush"/> class.
        /// </summary>
        public RadialGradientBrush() => type = BrushType.RadialGradient;

        /// <summary>
        /// Gets or sets the location of the two-dimensional focal point that defines the beginning of the gradient.
        /// </summary>
        public PointD GradientOrigin
        {
            get
            {
                origin = new PointD(X0, Y0);
                return origin;
            }
            set
            {
                if (origin != value)
                {
                    X0 = value.X;
                    Y0 = value.Y;
                    origin = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the center of the outermost circle of the radial gradient.
        /// </summary>
        public PointD Center
        {
            get
            {
                center = new PointD(X0, Y0);
                return center;
            }
            set
            {
                if (center != value)
                {
                    X0 = value.X;
                    Y0 = value.Y;
                    center = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the radius of the outermost circle of a radial gradient.
        /// </summary>
        public double OuterRadius
        {
            get => outerRadius;
            set => outerRadius = value;
        }
    }

    /// <summary>
    /// Represents a color inside of a gradient.
    /// </summary>
    [NativeType("uiDrawBrushGradientStop")]
    [Serializable]
    [StructLayout(Libraries.Libui.StructLayout)]
    public struct GradientStop
    {
#pragma warning disable IDE0044 // Add readonly modifier
#pragma warning disable IDE0032 // Use auto property
        private double pos, r, g, b, a;
#pragma warning restore IDE0032 // Use auto property
#pragma warning restore IDE0044 // Add readonly modifier

        /// <summary>
        /// Initializes a new instance of the <see cref="GradientStop"/> structure.
        /// </summary>
        /// <param name="pos">The specified position.</param>
        /// <param name="color">The specified color.</param>
        public GradientStop(double pos, Color color)
        {
            this.pos = pos;
            r = color.R;
            g = color.G;
            b = color.B;
            a = color.A;
        }

        /// <summary>
        /// For most <see cref="GradientBrush"/> objects, this defines where the color stop will start or end. (0 = start, 1 = end). For <see cref="RadialGradientBrush"/> objects, 0 is the center at the start point and 1 is the circle with the outer radius and the end center.
        /// </summary>
        public double Position { get => pos; set => pos = value; }

        /// <summary>
        /// the color of the color stop.
        /// </summary>
        public Color Color
        {
            get => new Color(r, g, b, a);
            set
            {
                r = value.R;
                g = value.G;
                b = value.B;
                a = value.A;
            }
        }
    }

    [NativeType("uiDrawBrushType")]
    [Serializable]
    internal enum BrushType : uint
    {
        Solid,
        LinearGradient,
        RadialGradient,
        Image
    }
}