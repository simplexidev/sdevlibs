using System;
using System.Runtime.InteropServices;

namespace LibUISharp.Drawing.Text
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct Font : IEquatable<Font>
    {
        public static readonly Font Empty = new Font();

        public string Family { get; }
        public double Size { get; }
        public FontWeight Weight { get; }
        public FontStyle Style { get; }
        public FontStretch Stretch { get; }
        
        public Font(string family, double size = default, FontWeight weight = FontWeight.Thin, FontStyle style = FontStyle.Normal, FontStretch stretch = FontStretch.UltraCondensed)
        {
            Family = family;
            Size = size;
            Weight = weight;
            Style = style;
            Stretch = stretch;
        }

        public bool Equals(Font other) => ((Family == other.Family) && (Size == other.Size) && (Weight == other.Weight) && (Style == other.Style) && (Stretch == other.Stretch));
    }
}