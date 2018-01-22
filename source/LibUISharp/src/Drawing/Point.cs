using System;
using System.Runtime.InteropServices;
using LibUISharp.Internal;

namespace LibUISharp.Drawing
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Point : IEquatable<Point>, IComparable, IComparable<Point>
    {
        public static readonly Point Empty = new Point(0, 0);

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Point(Size size) : this(size.Width, size.Height) { }

        public int X { get; set; }
        public int Y { get; set; }

        public bool IsEmpty => this == Empty;

        public static Point Add(Point point, Size size) => new Point(unchecked(point.X + size.Width), unchecked(point.Y + size.Height));
        public static Point Subtract(Point point, Size size) => new Point(unchecked(point.X - size.Width), unchecked(point.Y - size.Height));

        public static Point Ceiling(PointD value) => new Point(unchecked((int)Math.Ceiling(value.X)), unchecked((int)Math.Ceiling(value.Y)));
        public static Point Truncate(PointD value) => new Point(unchecked((int)value.X), unchecked((int)value.Y));
        public static Point Round(PointD value) => new Point(unchecked((int)Math.Round(value.X)), unchecked((int)Math.Round(value.Y)));
        
        public void Offset(Point point) => Offset(point.X, point.Y);
        public void Offset(int dx, int dy)
        {
            unchecked
            {
                X += dx;
                Y += dy;
            }
        }

        public override bool Equals(object obj) => (obj is Point) && (Equals((Point)obj));
        public override string ToString() => $"[{X}, {Y}]";
        public override int GetHashCode() => unchecked(HashHelpers.Combine(X, Y));

        public static Point operator +(Point point, Size size) => Add(point, size);
        public static Point operator -(Point point, Size size) => Subtract(point, size);
        public static bool operator ==(Point left, Point right) => (left.X == right.X) && (left.Y == right.Y);
        public static bool operator !=(Point left, Point right) => !(left == right);
        public static implicit operator PointD(Point point) => new PointD(point.X, point.Y);
        public static explicit operator Size(Point point) => new Size(point.X, point.Y);

        #region IEquatable<Point>
        public bool Equals(Point other) => this == other;
        #endregion
        #region IComparable, IComparable<Point>
        public int CompareTo(object obj)
        {
            if (obj is Point)
                return CompareTo((Point)obj);
            else return -1;
        }

        public int CompareTo(Point other)
        {
            int result = X.CompareTo(other.X);
            if (result == 0)
                result = Y.CompareTo(other.Y);
            return result;
        }
        #endregion
    }
}