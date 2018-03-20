using System;
using System.Runtime.InteropServices;
using LibUISharp.Internal;

namespace LibUISharp.Drawing
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static readonly Point Empty = new Point();

        public int X { get; set; }
        public int Y { get; set; }

        public bool IsEmpty => this == Empty;

        public override bool Equals(object obj)
        {
            if (!(obj is Point))
                return false;
            return Equals((Point)obj);
        }

        public bool Equals(Point point) => X == point.X && Y == point.Y;
        public override int GetHashCode() => unchecked(this.GetHashCode(X, Y));

        public static bool operator ==(Point point1, Point point2) => point1.Equals(point2);
        public static bool operator !=(Point point1, Point point2) => !(point1 == point2);
        public static explicit operator Size(Point point) => new Size(point.X, point.Y);
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct PointD
    {
        public PointD(double x, double y)
        {
            X = x;
            Y = y;
        }

        public static readonly PointD Empty = new PointD();

        public double X { get; set; }
        public double Y { get; set; }

        public bool IsEmpty => this == Empty;

        public override bool Equals(object obj)
        {
            if (!(obj is PointD))
                return false;
            return Equals((PointD)obj);
        }

        public bool Equals(PointD point) => X == point.X && Y == point.Y;
        public override int GetHashCode() => unchecked(this.GetHashCode(X, Y));

        public static bool operator ==(PointD point1, PointD point2) => point1.Equals(point2);
        public static bool operator !=(PointD point1, PointD point2) => !(point1 == point2);
        public static explicit operator SizeD(PointD point) => new SizeD(Math.Abs(point.X), Math.Abs(point.Y));
    }
}