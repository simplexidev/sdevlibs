using System;
using LibUISharp.Internal;

namespace LibUISharp.Drawing
{
    // uiFontDescriptor
    public readonly struct Font : IEquatable<Font>
    {
        public Font(string family, double size, FontWeight weight = FontWeight.Normal, FontStyle style = FontStyle.Normal, FontStretch stretch = FontStretch.Normal)
        {
            Family = family;
            Size = size;
            Weight = weight;
            Style = style;
            Stretch = stretch;
        }

        public static readonly Font Empty = new Font();

        public string Family { get; }
        public double Size { get; }
        public FontWeight Weight { get; }
        public FontStyle Style { get; }
        public FontStretch Stretch { get; }

        public static bool IsEmpty(Font f) => f == Empty;

        public override bool Equals(object obj)
        {
            if (!(obj is Font))
                return false;
            return Equals((Font)obj);
        }
        public bool Equals(Font other) => this == other;

        public override int GetHashCode() => unchecked(this.GetHashCode(Family, Size, Weight, Style, Stretch));

        public static bool operator ==(Font font1, Font font2) => font1.Family == font2.Family && font1.Size == font2.Size && font1.Stretch == font2.Stretch && font1.Style == font2.Style && font1.Weight == font2.Weight;
        public static bool operator !=(Font font1, Font font2) => !(font1 == font2);
    }
}