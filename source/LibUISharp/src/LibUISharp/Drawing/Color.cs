using System;
using System.Runtime.InteropServices;
using LibUISharp.Internal;

namespace LibUISharp.Drawing
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct Color
    {
        public Color(uint argb)
        {
            A = sRgbToScRgb((byte)((argb & 0xFF000000) >> 24));
            R = sRgbToScRgb((byte)((argb & 0x00FF0000) >> 16));
            G = sRgbToScRgb((byte)((argb & 0x0000FF00) >> 8));
            B = sRgbToScRgb((byte)(argb & 0x000000FF));
        }

        public Color(double r, double g, double b, double a = 1.0)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }

        public double R { get; }
        public double G { get; }
        public double B { get; }
        public double A { get; }
        
        public bool Equals(Color color) => R == color.R && G == color.G && B == color.B && A == color.A;

        public override bool Equals(object obj)
        {
            if (!(obj is Color))
                return false;
            return Equals((Color)obj);
        }

        public override int GetHashCode() => unchecked(this.GetHashCode(R, G, B, A));

        private static float sRgbToScRgb(byte bval)
        {
            float num = bval / 255f;
            if (num <= 0.0)
                return 0f;
            if (num <= 0.04045)
                return num / 12.92f;
            if (num < 1f)
                return (float)Math.Pow((num + 0.055) / 1.055, 2.4);
            return 1f;
        }

        public static bool operator ==(Color left, Color right) => left.Equals(right);
        public static bool operator !=(Color left, Color right) => !(left == right);
        //TODO: public static explicit operator SolidBrush(Color color) => new SolidBrush(color);
    }
}