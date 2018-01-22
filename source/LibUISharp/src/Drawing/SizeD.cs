using System;
using System.Runtime.InteropServices;
using LibUISharp.Internal;

namespace LibUISharp.Drawing
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SizeD : IEquatable<SizeD>, IComparable, IComparable<SizeD>
    {
        public static readonly SizeD Empty = new SizeD(0, 0);

        public SizeD(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public SizeD(PointD point) : this(point.X, point.Y) { }

        public double Width { get; set; }
        public double Height { get; set; }

        public bool IsEmpty => this == Empty;

        public static SizeD Add(SizeD left, SizeD right) => new SizeD(left.Width + right.Width, left.Height + right.Height);
        public static SizeD Subtract(SizeD left, SizeD right) => new SizeD(left.Width - right.Width, left.Height - right.Height);
        public static SizeD Multiply(SizeD size, double factor) => new SizeD(size.Width * factor, size.Height * factor);
        public static SizeD Divide(SizeD size, double divisor) => new SizeD(size.Width / divisor, size.Height / divisor);
        
        public override bool Equals(object obj) => (obj is SizeD) && (Equals((SizeD)obj));
        public override string ToString() => $"[{Width}, {Height}]";
        public override int GetHashCode() => unchecked(HashHelpers.Combine((int)Width, (int)Height));

        public static SizeD operator +(SizeD left, SizeD right) => Add(left, right);
        public static SizeD operator -(SizeD left, SizeD right) => Subtract(left, right);
        public static SizeD operator *(SizeD left, float right) => Multiply(left, right);
        public static SizeD operator *(float left, SizeD right) => Multiply(right, left);
        public static SizeD operator /(SizeD left, float right) => Divide(left, right);
        public static bool operator ==(SizeD left, SizeD right) => (left.Width == right.Width) && (left.Height == right.Height);
        public static bool operator !=(SizeD left, SizeD right) => !(left == right);
        public static explicit operator PointD(SizeD size) => new PointD(size.Width, size.Height);

        #region IEquatable<SizeD>
        public bool Equals(SizeD other) => this == other;
        #endregion
        #region IComparable, Icomparable<SizeD>
        public int CompareTo(object obj)
        {
            if (obj is SizeD)
                return CompareTo((SizeD)obj);
            else return -1;
        }

        public int CompareTo(SizeD other)
        {
            int result = Width.CompareTo(other.Width);
            if (result == 0)
                result = Height.CompareTo(other.Height);
            return result;
        }
        #endregion
    }
}