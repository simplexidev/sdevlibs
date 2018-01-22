using System;
using System.Runtime.InteropServices;
using static LibUISharp.Internal.UI;

namespace LibUISharp.Drawing
{

    public class Brush
    {
        internal uiDrawBrush Internal = new uiDrawBrush();

        protected Brush()
        {
            if (this is GradientBrush)
            {
                if (this is LinearGradientBrush)
                    BrushType = BrushType.LinearGradient;
                else if (this is RadialGradientBrush)
                    BrushType = BrushType.RadialGradient;
            } else if (this is SolidBrush)
                BrushType = BrushType.Solid;
        }

        public BrushType BrushType
        {
            get => Internal.BrushType;
            set => Internal.BrushType = value;
        }
    }

    public enum BrushType
    {
        Solid,
        LinearGradient,
        RadialGradient,
        Image
    }

    public abstract class GradientBrush : Brush
    {
        protected double X0 // Start X
        {
            get => Internal.X0;
            set => Internal.X0 = value;
        }

        protected double Y0 // Start Y
        {
            get => Internal.Y0;
            set => Internal.Y0 = value;
        }

        protected double X1 // End X
        {
            get => Internal.X0;
            set => Internal.X0 = value;
        }

        protected double Y1 // End Y
        {
            get => Internal.Y0;
            set => Internal.Y0 = value;
        }

        public GradientStop[] Stops_
        {
            set
            {
                if (value != null && value.Length != 0)
                {
                    uiDrawBrushGradientStop[] result = new uiDrawBrushGradientStop[value.Length];
                    for (int i = 0; i < value.Length; i++)
                        result[i] = new uiDrawBrushGradientStop()
                        {
                            Position = value[i].Position,
                            R = value[i].Color.R,
                            G = value[i].Color.G,
                            B = value[i].Color.B,
                            A = value[i].Color.A,
                        };
                    Internal.Stops = Marshal.UnsafeAddrOfPinnedArrayElement(result, 0);
                    Internal.NumStops = (UIntPtr)value.Length;
                }
            }
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct GradientStop
    {
        public double Position;
        public Color Color;
    }

    public sealed class LinearGradientBrush : GradientBrush
    {
        private PointD start = new PointD();
        public PointD StartPoint
        {
            get
            {
                start.X = X0;
                start.Y = Y0;
                return start;
            }
            set
            {
                if (start != value)
                {
                    start = value;
                    X0 = value.X;
                    Y0 = value.Y;
                }
            }
        }

        private PointD end = new PointD(1, 1);
        public PointD EndPoint
        {
            get
            {
                end.X = X1;
                end.Y = Y1;
                return end;
            }
            set
            {
                if (end != value)
                {
                    end = value;
                    X1 = value.X;
                    Y1 = value.Y;
                }
            }
        }
    }

    public sealed class RadialGradientBrush : GradientBrush
    {
        private PointD origin = new PointD(0.5, 0.5);

        public PointD GradientOrigin
        {
            get
            {
                origin.X = X0;
                origin.Y = Y0;
                return origin;
            }
            set
            {
                if (origin != value)
                {
                    origin = value;
                    X0 = value.X;
                    Y0 = value.Y;
                }
            }
        }

        private PointD center = new PointD(0.5, 0.5);
        public PointD Center
        {
            get
            {
                center.X = X1;
                center.Y = Y1;
                return center;
            }
            set
            {
                if (center != value)
                {
                    center = value;
                    X1 = value.X;
                    Y1 = value.Y;
                }
            }
        }

        public double OuterRadius { get => Internal.OuterRadius; set => Internal.OuterRadius = value; }		// radial gradients only
    }

    public sealed class SolidBrush : Brush
    {
        internal SolidBrush(Color color) : base()
        {
            R = color.R;
            G = color.G;
            B = color.B;
            A = color.A;
        }

        public double R
        {
            get => Internal.R;
            set => Internal.R = value;
        }

        public double G
        {
            get => Internal.G;
            set => Internal.G = value;
        }

        public double B
        {
            get => Internal.B;
            set => Internal.B = value;
        }

        public double A
        {
            get => Internal.A;
            set => Internal.A = value;
        }

        public static explicit operator Color(SolidBrush brush)
        {
            Color color = new Color(brush.R, brush.G, brush.B, brush.A);
            return color;
        }
    }
}