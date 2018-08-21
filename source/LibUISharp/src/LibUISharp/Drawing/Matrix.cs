using System;
using System.Runtime.InteropServices;
using LibUISharp.Internal;

namespace LibUISharp.Drawing
{
    //TODO: ToString() overrides.
    /// <summary>
    /// Defines a transformation, such as a rotation or translation.
    /// </summary>
    [NativeType("uiDrawMatrix")]
    [StructLayout(LayoutKind.Sequential)]
    public sealed class Matrix : IEquatable<Matrix>
    {
#pragma warning disable IDE0032 // Use auto property
#pragma warning disable IDE0044 // Add readonly modifier
        private double m11 = 1;
        private double m12 = 0;
        private double m21 = 0;
        private double m22 = 1;
        private double m31 = 0;
        private double m32 = 0;
#pragma warning restore IDE0044 // Add readonly modifier
#pragma warning restore IDE0032 // Use auto property

        /// <summary>
        /// Represents a specific value in this <see cref="Matrix"/>.
        /// </summary>
        public double M11
        {
            get => m11;
            set => m11 = value;
        }

        /// <summary>
        /// Represents a specific value in this <see cref="Matrix"/>.
        /// </summary>
        public double M12
        {
            get => m12;
            set => m12 = value;
        }

        /// <summary>
        /// Represents a specific value in this <see cref="Matrix"/>.
        /// </summary>
        public double M21
        {
            get => m21;
            set => m21 = value;
        }

        /// <summary>
        /// Represents a specific value in this <see cref="Matrix"/>.
        /// </summary>
        public double M22
        {
            get => m22;
            set => m22 = value;
        }

        /// <summary>
        /// Represents a specific value in this <see cref="Matrix"/>.
        /// </summary>
        public double M31
        {
            get => m31;
            set => m31 = value;
        }

        /// <summary>
        /// Represents a specific value in this <see cref="Matrix"/>.
        /// </summary>
        public double M32
        {
            get => m32;
            set => m32 = value;
        }

        /// <summary>
        /// Sets this <see cref="Matrix"/> structure's identity. After calling this, applying the matrix has no visual sequence. This must be called before any transformations are performed on this <see cref="Matrix"/>.
        /// </summary>
        public void SetIdentity() => NativeCalls.DrawMatrixSetIdentity(this);

        /// <summary>
        /// Moves paths by the specified amount.
        /// </summary>
        /// <param name="x">The amount to move the path horizontally.</param>
        /// <param name="y">The amount to move the path vertically.</param>
        public void Translate(double x, double y) => NativeCalls.DrawMatrixTranslate(this, x, y);

        /// <summary>
        /// Scales paths by the specified factors, with a specified scale center.
        /// </summary>
        /// <param name="xCenter">The x-coordinate of the scale center.</param>
        /// <param name="yCenter">The y-coordinate of the scale center.</param>
        /// <param name="x">The x-coordinate of the scale factor.</param>
        /// <param name="y">The y-coordinate of the scale factor.</param>
        public void Scale(double xCenter, double yCenter, double x, double y) => NativeCalls.DrawMatrixScale(this, xCenter, yCenter, x, y);

        /// <summary>
        /// Rotates paths by the specified radians around the specified points.
        /// </summary>
        /// <param name="x">The x-coordinate of the point.</param>
        /// <param name="y">The y-coordinate of the point.</param>
        /// <param name="amount">The amount to rotate the paths.</param>
        public void Rotate(double x, double y, double amount) => NativeCalls.DrawMatrixRotate(this, x, y, amount);

        /// <summary>
        /// Skews a path by a specified amount in radians around the specified point.
        /// </summary>
        /// <param name="x">The x-coordinate of the point.</param>
        /// <param name="y">The y-coordinate of the point.</param>
        /// <param name="xamount">The amount to skew the paths horizontally.</param>
        /// <param name="yamount">The amount to skew the paths vertically.</param>
        public void Skew(double x, double y, double xamount, double yamount) => NativeCalls.DrawMatrixSkew(this, x, y, xamount, yamount);

        /// <summary>
        /// Sets this matrix to the product of itself and the specified matrix.
        /// </summary>
        /// <param name="src">The specified source matrix.</param>
        public void Multiply([In] ref Matrix src) => Multiply(this, src);

        /// <summary>
        /// Sets a matrix to the product of itself and the specified matrix.
        /// </summary>
        /// <param name="dest">The specified destination matrix.</param>
        /// <param name="src">The specified source matrix.</param>
        public static void Multiply([Out]  Matrix dest, [In]  Matrix src) => NativeCalls.DrawMatrixMultiply(dest, src);

        /// <summary>
        /// Gets a value indicating whether this matrix can be inverted.
        /// </summary>
        /// <returns><see langword="true"/> if the matrix is invertable; else <see langword="false"/>.</returns>
        public bool Invertible() => NativeCalls.DrawMatrixInvertible(this);

        /// <summary>
        /// Inverts this matrix.
        /// </summary>
        public void Invert() => NativeCalls.DrawMatrixInvert(this);

        /// <summary>
        /// Gets the transformed point.
        /// </summary>
        /// <returns>The transformed point.</returns>
        public PointD TransformToPoint()
        {
            NativeCalls.DrawMatrixTransformPoint(this, out double x, out double y);
            return new PointD(x, y);
        }

        /// <summary>
        /// Gets the transformed size.
        /// </summary>
        /// <returns>The transformed size.</returns>
        public SizeD TransformToSize()
        {
            NativeCalls.DrawMatrixTransformSize(this, out double width, out double height);
            return new SizeD(width, height);
        }

        /// <summary>
        /// Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <param name="obj">The object to compare with the current instance.</param>
        /// <returns>true if obj and this instance are the same type and represent the same value; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is Matrix))
                return false;
            return Equals((Matrix)obj);
        }

        /// <summary>
        /// Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <param name="matrix">The font to compare with the current instance.</param>
        /// <returns>true if obj and this instance are the same type and represent the same value; otherwise, false.</returns>
        public bool Equals(Matrix matrix) => this == matrix;

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode() => unchecked(HashHelper.GenerateHash(m11, m12, m21, m22, m31, m32));

        /// <summary>
        /// Tests whether two specified <see cref="Matrix"/> structures are equivalent.
        /// </summary>
        /// <param name="left">The <see cref="Matrix"/> that is to the left of the equality operator.</param>
        /// <param name="right">The <see cref="Matrix"/> that is to the right of the equality operator.</param>
        /// <returns><see langword="true"/> if the two <see cref="Matrix"/> structures are equal; otherwise, <see langword="false"/>.</returns>
        public static bool operator ==(Matrix left, Matrix right) => left.m11 == right.m11 && left.m12 == right.m12 && left.m21 == right.m21 && left.m22 == right.m22 && left.m31 == right.m31 && left.m32 == right.m32;

        /// <summary>
        /// Tests whether two specified <see cref="Matrix"/> structures are different.
        /// </summary>
        /// <param name="left">The <see cref="Matrix"/> that is to the left of the inequality operator.</param>
        /// <param name="right">The <see cref="Matrix"/> that is to the right of the inequality operator.</param>
        /// <returns><see langword="true"/> if the two <see cref="Matrix"/> structures are different; otherwise, <see langword="false"/>.</returns>
        public static bool operator !=(Matrix left, Matrix right) => !(left == right);
    }
}