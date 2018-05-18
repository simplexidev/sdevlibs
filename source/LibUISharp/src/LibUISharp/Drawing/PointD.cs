using LibUISharp.Internal;
using System.Runtime.InteropServices;

namespace LibUISharp.Drawing
{
    /// <summary>
    /// Represents an ordered pair of double-precision floating-point x- and y-coordinates that defines a point in a two-dimensional plane.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct PointD
    {
        /// <summary>
        /// Represents a <see cref="PointD"/> that has <see cref="X"/> and <see cref="Y"/> values set to zero.
        /// </summary>
        public static readonly PointD Empty = new PointD(0.0, 0.0);

        /// <summary>
        /// Initializes a new instance of the <see cref="PointD"/> class with the specified coordinates.
        /// </summary>
        /// <param name="x">The horizontal position of the point.</param>
        /// <param name="y">The vertical position of the point.</param>
        public PointD(double x, double y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PointD"/> structure from a <see cref="Size"/>.
        /// </summary>
        /// <param name="sz">A <see cref="Size"/> that specifies the coordinates for the new <see cref="PointD"/>.</param>
        public PointD(SizeD sz) : this(sz.Width, sz.Height) { }

        /// <summary>
        /// Gets or sets the x-coordinate of this <see cref="PointD"/>.
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// Gets or sets the y-coordinate of this <see cref="PointD"/>.
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="PointD"/> is empty.
        /// </summary>
        public bool IsEmpty => this == Empty;

        /// <summary>
        /// Adds the specified <see cref="Size"/> to the specified <see cref="PointD"/>.
        /// </summary>
        /// <param name="pt">The <see cref="PointD"/> to add.</param>
        /// <param name="sz">The <see cref="Size"/> to add.</param>
        /// <returns>The <see cref="PointD"/> that is the result of the addition operation.</returns>
        public static PointD Add(PointD pt, Size sz) => new PointD(pt.X + sz.Width, pt.Y + sz.Height);

        /// <summary>
        /// Adds the specified <see cref="SizeD"/> to the specified <see cref="PointD"/>.
        /// </summary>
        /// <param name="pt">The <see cref="PointD"/> to add.</param>
        /// <param name="sz">The <see cref="SizeD"/> to add.</param>
        /// <returns>The <see cref="PointD"/> that is the result of the addition operation.</returns>
        public static PointD Add(PointD pt, SizeD sz) => new PointD(pt.X + sz.Width, pt.Y + sz.Height);

        /// <summary>
        /// Returns the result of subtracting the specified <see cref="Size"/> from the specified <see cref="PointD"/>.
        /// </summary>
        /// <param name="pt">The <see cref="PointD"/> to be subtracted from.</param>
        /// <param name="sz">The <see cref="Size"/> to subtract from <paramref name="pt"/>.</param>
        /// <returns>The <see cref="PointD"/> that is the result of the addition operation.</returns>
        public static PointD Subtract(PointD pt, Size sz) => new PointD(pt.X - sz.Width, pt.Y - sz.Height);

        /// <summary>
        /// Returns the result of subtracting the specified <see cref="SizeD"/> from the specified <see cref="PointD"/>.
        /// </summary>
        /// <param name="pt">The <see cref="PointD"/> to be subtracted from.</param>
        /// <param name="sz">The <see cref="SizeD"/> to subtract from <paramref name="pt"/>.</param>
        public static PointD Subtract(PointD pt, SizeD sz) => new PointD(pt.X - sz.Width, pt.Y - sz.Height);

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (!(obj is PointD))
                return false;
            return Equals((PointD)obj);
        }

        /// <inheritdoc cref="Equals(object)"/>
        public bool Equals(PointD point) => X == point.X && Y == point.Y;

        /// <inheritdoc/>  
        public override int GetHashCode() => unchecked(this.GetHashCode(X, Y));

        /// <summary>
        /// Translates a <see cref="PointD"/> by a given <see cref="Size"/>.
        /// </summary>
        /// <param name="pt">The <see cref="PointD"/> to translate.</param>
        /// <param name="sz">A <see cref="Size"/> that specifies the pair of numbers to add to the coordinates of <paramref name="pt"/>.</param>
        /// <returns>A <see cref="PointD"/> structure that is translated by a given <see cref="Size"/> structure.</returns>
        public static PointD operator +(PointD pt, Size sz) => new PointD(pt.X + sz.Width, pt.Y + sz.Height);

        /// <summary>
        /// Translates a <see cref="PointD"/> by a given <see cref="SizeD"/>.
        /// </summary>
        /// <param name="pt">The <see cref="PointD"/> to translate.</param>
        /// <param name="sz">A <see cref="SizeD"/> that specifies the pair of numbers to add to the coordinates of <paramref name="pt"/>.</param>
        /// <returns>A <see cref="PointD"/> structure that is translated by a given <see cref="SizeD"/> structure.</returns>
        public static PointD operator +(PointD pt, SizeD sz) => new PointD(pt.X + sz.Width, pt.Y + sz.Height);

        /// <summary>
        /// Translates a <see cref="PointD"/> by the negative of a given <see cref="Size"/>.
        /// </summary>
        /// <param name="pt">The <see cref="PointD"/> to translate.</param>
        /// <param name="sz">A <see cref="Size"/> that specifies the pair of numbers to subtract from the coordinates of <paramref name="pt"/>.</param>
        /// <returns>A <see cref="PointD"/> structure that is translated by the negative of a given <see cref="Size"/> structure.</returns>
        public static PointD operator -(PointD pt, Size sz) => new PointD(pt.X - sz.Width, pt.Y - sz.Height);

        /// <summary>
        /// Translates a <see cref="PointD"/> by the negative of a given <see cref="SizeD"/>.
        /// </summary>
        /// <param name="pt">The <see cref="PointD"/> to translate.</param>
        /// <param name="sz">A <see cref="SizeD"/> that specifies the pair of numbers to subtract from the coordinates of <paramref name="pt"/>.</param>
        /// <returns>A <see cref="PointD"/> structure that is translated by the negative of a given <see cref="SizeD"/> structure.</returns>
        public static PointD operator -(PointD pt, SizeD sz) => new PointD(pt.X - sz.Width, pt.Y - sz.Height);

        /// <summary>
        /// Tests whether two specified <see cref="PointD"/> structures are equivalent.
        /// </summary>
        /// <param name="left">The <see cref="PointD"/> that is to the left of the equality operator.</param>
        /// <param name="right">The <see cref="PointD"/> that is to the right of the equality operator.</param>
        /// <returns><see langword="true"/> if the two <see cref="PointD"/> structures are equal; otherwise, <see langword="false"/>.</returns>
        public static bool operator ==(PointD left, PointD right) => left.Equals(right);

        /// <summary>
        /// Tests whether two specified <see cref="PointD"/> structures are different.
        /// </summary>
        /// <param name="left">The <see cref="PointD"/> that is to the left of the inequality operator.</param>
        /// <param name="right">The <see cref="PointD"/> that is to the right of the inequality operator.</param>
        /// <returns><see langword="true"/> if the two <see cref="PointD"/> structures are different; otherwise, <see langword="false"/>.</returns>
        public static bool operator !=(PointD left, PointD right) => !(left == right);

        /// <summary>
        /// Converts the specified <see cref="PointD"/> structure to a <see cref="SizeD"/> structure.
        /// </summary>
        /// <param name="pt">The <see cref="PointD"/> to be converted.</param>
        /// <returns>The <see cref="SizeD"/> that results from the conversion.</returns>
        public static explicit operator SizeD(PointD pt) => new SizeD(pt);
    }
}