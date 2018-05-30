using LibUISharp.Internal;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace LibUISharp.Drawing
{
    /// <summary>
    /// Defines objects used to paint graphical objects. Classes that derive from <see cref="Brush"/> describe how the area is painted.
    /// </summary>
    public abstract class Brush
    {
        internal LibuiLibrary.uiDrawBrush Internal = new LibuiLibrary.uiDrawBrush();

        internal LibuiLibrary.uiDrawBrushType BrushType
        {
            get => Internal.Type;
            protected private set => Internal.Type = value;
        }
    }

    /// <summary>
    /// An abstract class that describes a gradient, composed of gradient stops. Classes that inherit from <see cref="GradientBrush"/> describe different ways of interpreting gradient stops.
    /// </summary>
    public abstract class GradientBrush : Brush
    {
        // linear: start X
        // radial: start X
        private protected double X0
        {
            get => Internal.X0;
            set => Internal.X0 = value;
        }

        // linear: start Y
        // radial: start Y
        private protected double Y0
        {
            get => Internal.Y0;
            set => Internal.Y0 = value;
        }

        // linear: end X
        // radial: outer circle center X
        private protected double X1
        {
            get => Internal.X1;
            set => Internal.X1 = value;
        }

        // linear: end Y
        // radial: outer circle center Y
        private protected double Y1
        {
            get => Internal.Y1;
            set => Internal.Y1 = value;
        }

        /// <summary>
        /// Gets or sets the brush's gradient stops.
        /// </summary>
        public IList<GradientStop> GradientStops
        {
            set
            {
                if (value != null && value.Count != 0)
                {
                    LibuiLibrary.uiDrawBrushGradientStop[] stops = new LibuiLibrary.uiDrawBrushGradientStop[value.Count];
                    for (int i = 0; i < value.Count - 1; i++)
                    {
                        stops[i] = value[i].ToLibuiDrawBrushGradientStop();
                    }
                    Internal.NumStops = (UIntPtr)value.Count;
                    Internal.Stops = Marshal.UnsafeAddrOfPinnedArrayElement(stops, 0);
                }
            }
        }
    }

    /// <summary>
    /// Paints an area with a linear gradient.
    /// </summary>
    public sealed class LinearGradientBrush : GradientBrush
    {
        private PointD start = new PointD();
        private PointD end = new PointD(1.0, 1.0);

        /// <summary>
        /// Initializes a new instance of the <see cref="LinearGradientBrush"/> class.
        /// </summary>
        public LinearGradientBrush() => Internal.Type = LibuiLibrary.uiDrawBrushType.uiDrawBrushTypeLinearGradient;

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
    public sealed class RadialGradientBrush : GradientBrush
    {
        private PointD origin, center = new PointD(0.5, 0.5);

        /// <summary>
        /// Initializes a new instance of the <see cref="RadialGradientBrush"/> class.
        /// </summary>
        public RadialGradientBrush() => Internal.Type = LibuiLibrary.uiDrawBrushType.uiDrawBrushTypeRadialGradient;

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
            get => Internal.OuterRadius;
            set => Internal.OuterRadius = value;
        }
    }

    /// <summary>
    /// Paints an area with a solid color.
    /// </summary>
    public sealed class SolidBrush : Brush
    {
        private Color color;

        /// <summary>
        /// Initializes a new instance of the <see cref="SolidBrush"/> class.
        /// </summary>
        public SolidBrush() => Internal.Type = LibuiLibrary.uiDrawBrushType.uiDrawBrushTypeSolid;

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
                color = new Color(Internal.R, Internal.G, Internal.B, Internal.A);
                return color;
            }
            set
            {
                if (color != value)
                {
                    Internal.R = value.R;
                    Internal.G = value.G;
                    Internal.B = value.B;
                    Internal.A = value.A;
                    color = value;
                }
            }
        }
    }
}