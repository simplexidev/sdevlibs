using System;
using System.Runtime.InteropServices;
using LibUISharp.Internal;

namespace LibUISharp.Drawing
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Size : IEquatable<Size>, IComparable, IComparable<Size>
    {
        public static readonly Size Empty = new Size(0, 0);

        public Size(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public Size(Point point) : this(point.X, point.Y) { }

        public int Width { get; set; }
        public int Height { get; set; }

        public bool IsEmpty => this == Empty;

        public static Size Add(Size left, Size right) => new Size(unchecked(left.Width + right.Width), unchecked(left.Height + right.Height));
        public static Size Subtract(Size left, Size right) => new Size(unchecked(left.Width - right.Width), unchecked(left.Height - right.Height));
        public static Size Multiply(Size size, int factor) => new Size(unchecked(size.Width * factor), unchecked(size.Height * factor));
        public static SizeD Multiply(Size size, double factor) => new SizeD(size.Width * factor, size.Height * factor);
        public static Size Divide(Size size, int divisor) => new Size(unchecked(size.Width / divisor), unchecked(size.Height / divisor));
        public static SizeD Divide(Size size, double divisor) => new SizeD(size.Width / divisor, size.Height / divisor);

        public static Size Ceiling(SizeD value) => new Size(unchecked((int)Math.Ceiling(value.Width)), unchecked((int)Math.Ceiling(value.Height)));
        public static Size Truncate(SizeD value) => new Size(unchecked((int)value.Width), unchecked((int)value.Height));
        public static Size Round(SizeD value) => new Size(unchecked((int)Math.Round(value.Width)), unchecked((int)Math.Round(value.Height)));
        
        public override bool Equals(object obj) => (obj is Size) && (Equals((Size)obj));
        public override string ToString() => $"[{Width}, {Height}]";
        public override int GetHashCode() => unchecked(HashHelpers.Combine(Width, Height));

        public static Size operator +(Size left, Size right) => Add(left, right);
        public static Size operator -(Size left, Size right) => Subtract(left, right);
        public static Size operator *(Size left, int right) => Multiply(left, right);
        public static Size operator *(int left, Size right) => Multiply(right, left);
        public static SizeD operator *(Size left, float right) => Multiply(left, right);
        public static SizeD operator *(float left, Size right) => Multiply(right, left);
        public static Size operator /(Size left, int right) => Divide(left, right);
        public static SizeD operator /(Size left, float right) => Divide(left, right);
        public static bool operator ==(Size left, Size right) => (left.Width == right.Width) && (left.Height == right.Height);
        public static bool operator !=(Size left, Size right) => !(left == right);
        public static implicit operator SizeD(Size size) => new SizeD(size.Width, size.Height);
        public static explicit operator Point(Size size) => new Point(size.Width, size.Height);

        #region IEquatable<Size>
        public bool Equals(Size other) => this == other;
        #endregion
        #region IComparable, IComparable<Size>
        public int CompareTo(object obj)
        {
            if (obj is Size)
                return CompareTo((Size)obj);
            else return -1;
        }

        public int CompareTo(Size other)
        {
            int result = Width.CompareTo(other.Width);
            if (result == 0)
                result = Height.CompareTo(other.Height);
            return result;
        }
        #endregion
    }
}