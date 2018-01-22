using System;
using System.Runtime.InteropServices;
using LibUISharp.Internal;

namespace LibUISharp.Drawing
{
    [StructLayout(LayoutKind.Sequential)]
    public struct PointD : IEquatable<PointD>, IComparable, IComparable<PointD>
    {
        public static readonly PointD Empty = new PointD(0.0, 0.0);

        public PointD(double x, double y)
        {
            X = x;
            Y = y;
        }

        public PointD(Size size) : this(size.Width, size.Height) { }
        public PointD(SizeD size) : this(size.Width, size.Height) { }

        public double X { get; set; }
        public double Y { get; set; }

        public bool IsEmpty => this == Empty;

        public static PointD Add(PointD point, Size size) => new PointD(point.X + size.Width, point.Y + size.Height);
        public static PointD Add(PointD point, SizeD size) => new PointD(point.X + size.Width, point.Y + size.Height);
        public static PointD Subtract(PointD point, Size size) => new PointD(point.X - size.Width, point.Y - size.Height);
        public static PointD Subtract(PointD point, SizeD size) => new PointD(point.X - size.Width, point.Y - size.Height);

        public void Offset(PointD point) => Offset(point.X, point.Y);
        public void Offset(double dx, double dy)
        {
                X += dx;
                Y += dy;
        }

        public override bool Equals(object obj) => (obj is PointD) && (Equals((PointD)obj));
        public override string ToString() => $"[{X}, {Y}]";
        public override int GetHashCode() => unchecked(HashHelpers.Combine((int)X, (int)Y));

        public static PointD operator +(PointD point, Size size) => Add(point, size);
        public static PointD operator +(PointD point, SizeD size) => Add(point, size);
        public static PointD operator -(PointD point, Size size) => Subtract(point, size);
        public static PointD operator -(PointD point, SizeD size) => Subtract(point, size);
        public static bool operator ==(PointD left, PointD right) => (left.X == right.X) && (left.Y == right.Y);
        public static bool operator !=(PointD left, PointD right) => !(left == right);
        public static explicit operator SizeD(PointD point) => new SizeD(point.X, point.Y);

        #region IEquatable<PointD>
        public bool Equals(PointD other) => this == other;
        #endregion
        #region IComparable, IComparable<PointD>
        public int CompareTo(object obj)
        {
            if (obj is PointD)
                return CompareTo((PointD)obj);
            else return -1;
        }

        public int CompareTo(PointD other)
        {
            int result = X.CompareTo(other.X);
            if (result == 0)
                result = Y.CompareTo(other.Y);
            return result;
        }
        #endregion
    }
}