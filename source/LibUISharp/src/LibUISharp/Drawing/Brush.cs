using LibUISharp.Internal;
using System;
using System.Runtime.InteropServices;

// uiDrawBrush
namespace LibUISharp.Drawing
{
    public abstract class Brush
    {
        internal LibuiLibrary.uiDrawBrush Internal = new LibuiLibrary.uiDrawBrush();

        internal LibuiLibrary.uiDrawBrushType BrushType
        {
            get => Internal.Type;
            protected private set => Internal.Type = value;
        }
    }

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

        public GradientStop[] Stops
        {
            set
            {
                if (value != null && value.Length != 0)
                {
                    LibuiLibrary.uiDrawBrushGradientStop[] stops = new LibuiLibrary.uiDrawBrushGradientStop[value.Length];
                    for (int i = 0; i < value.Length; i++)
                    {
                        stops[i] = value[i].ToLibuiDrawBrushGradientStop();
                    }
                    Internal.NumStops = (UIntPtr)value.Length;
                    Internal.Stops = Marshal.UnsafeAddrOfPinnedArrayElement(stops, 0);
                }
            }
        }
    }

    public sealed class LinearGradientBrush : GradientBrush
    {
        private PointD start = new PointD();
        private PointD end = new PointD(1.0, 1.0);

        public LinearGradientBrush() => Internal.Type = LibuiLibrary.uiDrawBrushType.uiDrawBrushTypeLinearGradient;

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

    public sealed class RadialGradientBrush : GradientBrush
    {
        private PointD origin, center = new PointD(0.5, 0.5);

        public RadialGradientBrush() => Internal.Type = LibuiLibrary.uiDrawBrushType.uiDrawBrushTypeRadialGradient;

        public PointD Origin
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

        public double OuterRadius
        {
            get => Internal.OuterRadius;
            set => Internal.OuterRadius = value;
        }
    }

    /// <summary>
    /// Defines objects used to fill the interiors of graphical shapes such as rectangles, ellipses, pies, polygons, and paths.
    /// </summary>
    public sealed class SolidBrush : Brush
    {
        private Color color;

        public SolidBrush() => Internal.Type = LibuiLibrary.uiDrawBrushType.uiDrawBrushTypeSolid;

        public SolidBrush(Color color) : this() => Color = color;

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