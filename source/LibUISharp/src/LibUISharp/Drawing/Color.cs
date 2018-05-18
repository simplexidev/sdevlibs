using LibUISharp.Internal;
using System;
using System.Runtime.InteropServices;

namespace LibUISharp.Drawing
{
    /// <summary>
    /// Represents an ARGB (alpha, red, green, blue) color.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct Color
    {
        /// <summary>
        /// Represents a color that is <see langword="null"/>.
        /// </summary>
        public static readonly Color Empty = new Color();
        /// <summary>
        /// Initializes a new <see cref="Color"/> structure from an argb value.
        /// </summary>
        /// <param name="argb">An argb value.</param>
        public Color(uint argb)
        {
            A = sRgbToScRgb((byte)((argb & 0xFF000000) >> 24));
            R = sRgbToScRgb((byte)((argb & 0x00FF0000) >> 16));
            G = sRgbToScRgb((byte)((argb & 0x0000FF00) >> 8));
            B = sRgbToScRgb((byte)(argb & 0x000000FF));
        }

        /// <summary>
        /// Initializes a new <see cref="Color"/> structure from red, green, blue, and optionally alpha component values.
        /// </summary>
        /// <param name="r">The red value.</param>
        /// <param name="g">The green value.</param>
        /// <param name="b">The blue value.</param>
        /// <param name="a">The alpha value.</param>
        public Color(double r, double g, double b, double a = 1.0)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }

        /// <summary>
        /// Gets the red component for this <see cref="Color"/> structure.
        /// </summary>
        public double R { get; }

        /// <summary>
        /// Gets the green component for this <see cref="Color"/> structure.
        /// </summary>
        public double G { get; }

        /// <summary>
        /// Gets the blue component for this <see cref="Color"/> structure.
        /// </summary>
        public double B { get; }

        /// <summary>
        /// Gets the alpha component for this <see cref="Color"/> structure.
        /// </summary>
        public double A { get; }

        /// <summary>
        /// Specifies whether this <see cref="Color"/> structure is uninitialized.
        /// </summary>
        public bool IsEmpty => this == Empty;

        /// <inheritdoc cref="Equals(object)"/>
        public bool Equals(Color color) => R == color.R && G == color.G && B == color.B && A == color.A;

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (!(obj is Color))
                return false;
            return Equals((Color)obj);
        }

        /// <inheritdoc/>
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

        /// <summary>
        /// Tests whether two specified <see cref="Color"/> structures are equivalent.
        /// </summary>
        /// <param name="left">The <see cref="Color"/> that is to the left of the equality operator.</param>
        /// <param name="right">The <see cref="Color"/> that is to the right of the equality operator.</param>
        /// <returns><see langword="true"/> if the two <see cref="Color"/> structures are equal; otherwise, <see langword="false"/>.</returns>
        public static bool operator ==(Color left, Color right) => left.Equals(right);

        /// <summary>
        /// Tests whether two specified <see cref="Color"/> structures are different.
        /// </summary>
        /// <param name="left">The <see cref="Color"/> that is to the left of the inequality operator.</param>
        /// <param name="right">The <see cref="Color"/> that is to the right of the inequality operator.</param>
        /// <returns><see langword="true"/> if the two <see cref="Color"/> structures are different; otherwise, <see langword="false"/>.</returns>
        public static bool operator !=(Color left, Color right) => !(left == right);

        //TODO: public static explicit operator SolidBrush(Color color) => new SolidBrush(color);
    }
}