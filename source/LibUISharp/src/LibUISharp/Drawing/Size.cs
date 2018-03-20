using System;
using System.Runtime.InteropServices;
using LibUISharp.Internal;

namespace LibUISharp.Drawing
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Size
    {
        private int width, height;

        public Size(int w, int h)
        {
            if (w < 0 || h < 0) throw new ArgumentException("A Size cannot have a negative value.");
            width = w;
            height = h;
        }

        public static readonly Size Empty = new Size();

        public int Width
        {
            get => width;
            set
            {
                if (value < 0) throw new ArgumentException("A Size cannot have a negative value.");
                if (width == value) return;
                width = value;
            }
        }

        public int Height
        {
            get => height;
            set
            {
                if (value < 0) throw new ArgumentException("A Size cannot have a negative value.");
                if (height == value) return;
                height = value;
            }
        }

        public bool IsEmpty => this == Empty;

        public override bool Equals(object obj)
        {
            if (!(obj is Size))
                return false;
            return Equals((Size)obj);
        }

        public bool Equals(Size size) => Width == size.Width && Height == size.Height;
        public override int GetHashCode() => unchecked(this.GetHashCode(Width, Height));

        public static bool operator ==(Size size1, Size size2) => size1.Equals(size2);
        public static bool operator !=(Size size1, Size size2) => !(size1 == size2);
        public static explicit operator Point(Size size) => new Point(size.Width, size.Height);
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SizeD
    {
        private double width, height;

        public SizeD(double w, double h)
        {
            if (w < 0 || h < 0) throw new ArgumentException("A SizeD cannot have a negative value.");
            width = w;
            height = h;
        }

        public static readonly SizeD Empty = new SizeD();

        public double Width
        {
            get => width;
            set
            {
                if (value < 0) throw new ArgumentException("A SizeD cannot have a negative value.");
                if (width == value) return;
                width = value;
            }
        }

        public double Height
        {
            get => height;
            set
            {
                if (value < 0) throw new ArgumentException("A SizeD cannot have a negative value.");
                if (height == value) return;
                height = value;
            }
        }

        public bool IsEmpty => this == Empty;

        public override bool Equals(object obj)
        {
            if (!(obj is SizeD))
                return false;
            return Equals((SizeD)obj);
        }

        public bool Equals(SizeD size) => Width == size.Width && Height == size.Height;
        public override int GetHashCode() => unchecked(this.GetHashCode(Width, Height));

        public static bool operator ==(SizeD size1, SizeD size2) => size1.Equals(size2);
        public static bool operator !=(SizeD size1, SizeD size2) => !(size1 == size2);
        public static explicit operator PointD(SizeD size) => new PointD(size.Width, size.Height);
    }
}