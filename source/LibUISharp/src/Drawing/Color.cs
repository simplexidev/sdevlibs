using System;
using System.Runtime.InteropServices;
using LibUISharp.Internal;

namespace LibUISharp.Drawing
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct Color : IEquatable<Color>, IComparable, IComparable<Color>
    {
        public static readonly Color Empty = new Color(0.0, 0.0, 0.0, 0.0);

        public Color(double red, double green, double blue, double alpha = 1.0) : this()
        {
            R = red;
            G = green;
            B = blue;
            A = alpha;
        }

        public Color(int red, int green, int blue, int alpha = 255) : this((red / 255f), (green / 255), (blue / 255), (alpha / 255)) { }

        public Color(uint argb)
        {
            A = SRgbToScRgb((byte)((argb & 0xff000000) >> 24));
            R = SRgbToScRgb((byte)((argb & 0x00ff0000) >> 16));
            G = SRgbToScRgb((byte)((argb & 0x0000ff00) >> 8));
            B = SRgbToScRgb((byte)(argb & 0x000000ff));
        }

        public double R { get; }
        public double G { get; }
        public double B { get; }
        public double A { get; }

        //TODO: public int Rb { get; }
        //TODO: public int Gb { get; }
        //TODO: public int Bb { get; }
        //TODO: public int Ab { get; }

        public bool IsEmpty => (R == 0.0) && (G == 0.0) && (B == 0.0) && (A == 0.0);

        public Color GetInverted(Color color) => new Color((1.0 - R), (1.0 - G), (1.0 - B));

        private static float SRgbToScRgb(byte bval)
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

        public bool Equals(Color other) => R.Equals(other.R) && G.Equals(other.G) && B.Equals(other.B) && A.Equals(other.A);
        
        public int CompareTo(object obj)
        {
            if (obj is Color)
                return CompareTo((Color)obj);
            else return 0;
        }
    
        public int CompareTo(Color other)
        {
            int result = A.CompareTo(other.A);
            if (result == 0)
            {
                result = R.CompareTo(other.R);
                if (result == 0)
                {
                    result = G.CompareTo(other.G);
                    if (result == 0)
                    {
                        result = B.CompareTo(other.B);
                    }
                }
            }

            return result;
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            return obj is Color && Equals((Color)obj);
        }

        public override string ToString() => $"[{R}, {G}, {B}, {A}]";

        public override int GetHashCode() => unchecked(HashHelpers.Combine(R.GetHashCode(), G.GetHashCode(), B.GetHashCode(), A.GetHashCode()));

        public static bool operator ==(Color left, Color right) => left.Equals(right);

        public static bool operator !=(Color left, Color right) => !(left == right);

        //TODO: public static explicit operator SolidBrush(Color color) => SolidBrush(color);
    }
}