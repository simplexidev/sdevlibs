using System.Runtime.InteropServices;
using static LibUISharp.Native.NativeMethods;

namespace LibUISharp.Drawing
{
    /// <summary>
    /// Defines a transformation, such as a rotation or translation.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public class Matrix
    {
        internal Libui.uiDrawMatrix Native = new Libui.uiDrawMatrix();

        /// <summary>
        /// Gets or set the M11 value.
        /// </summary>
        public double M11
        {
            get => Native.M11;
            set => Native.M11 = value;
        }

        /// <summary>
        /// Gets or set the M12 value.
        /// </summary>
        public double M12
        {
            get => Native.M11;
            set => Native.M11 = value;
        }

        /// <summary>
        /// Gets or set the M21 value.
        /// </summary>
        public double M21
        {
            get => Native.M11;
            set => Native.M11 = value;
        }

        /// <summary>
        /// Gets or set the M22 value.
        /// </summary>
        public double M22
        {
            get => Native.M11;
            set => Native.M11 = value;
        }

        /// <summary>
        /// Gets or set the M31 value.
        /// </summary>
        public double M31
        {
            get => Native.M11;
            set => Native.M11 = value;
        }

        /// <summary>
        /// Gets or set the M32 value.
        /// </summary>
        public double M32
        {
            get => Native.M11;
            set => Native.M11 = value;
        }

        /// <summary>
        /// Sets this <see cref="Matrix"/> struture's identity. After calling this, applying the matrix has no visual sequence. This must be called be fore any transformations are performed on this <see cref="Matrix"/>.
        /// </summary>
        public void SetIdentity() => Libui.uiDrawMatrixSetIdentity(Native);

        /// <summary>
        /// Moves paths by the specified amount.
        /// </summary>
        /// <param name="x">The amount to move the path horizontally.</param>
        /// <param name="y">The amount to move the path vertically.</param>
        public void Translate(double x, double y) => Libui.uiDrawMatrixTranslate(Native, x, y);

        /// <summary>
        /// Scales paths by the specified factors, with a specified scale center.
        /// </summary>
        /// <param name="xCenter">The x-coordinate of the scale center.</param>
        /// <param name="yCenter">The y-coordinate of the scale center.</param>
        /// <param name="x">The x-coordinate of the scale factor.</param>
        /// <param name="y">The y-coordinate of the scale factor.</param>
        public void Scale(double xCenter, double yCenter, double x, double y) => Libui.uiDrawMatrixScale(Native, xCenter, yCenter, x, y);

        /// <summary>
        /// Rotates paths by the specified radians around the specified points.
        /// </summary>
        /// <param name="x">The x-coordinate of the point.</param>
        /// <param name="y">The y-coordinate of the point.</param>
        /// <param name="amount">The amount to rotate the paths.</param>
        public void Rotate(double x, double y, double amount) => Libui.uiDrawMatrixRotate(Native, x, y, amount);

        /// <summary>
        /// Skews a path by a specified amount in radians around the specified point.
        /// </summary>
        /// <param name="x">The x-coordinate of the point.</param>
        /// <param name="y">The y-coordinate of the point.</param>
        /// <param name="xamount">The amount to skew the paths horizontally.</param>
        /// <param name="yamount">The amount to skew the paths vertically.</param>
        public void Skew(double x, double y, double xamount, double yamount) => Libui.uiDrawMatrixSkew(Native, x, y, xamount, yamount);

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
        public static void Multiply([Out]  Matrix dest, [In]  Matrix src) => Libui.uiDrawMatrixMultiply(dest.Native, src.Native);
        
        /// <summary>
        /// Gets a value indicating whether this matrix can be inverted.
        /// </summary>
        /// <returns><see langword="true"/> if the matrix is invertable; else <see langword="false"/>.</returns>
        public bool Invertible() => Libui.uiDrawMatrixInvertible(Native);

        /// <summary>
        /// Inverts this matrix.
        /// </summary>
        public void Invert() => Libui.uiDrawMatrixInvert(Native);

        /// <summary>
        /// Gets the transformed point.
        /// </summary>
        /// <returns>The transformed point.</returns>
        public PointD TransformToPoint()
        {
            Libui.uiDrawMatrixTransformPoint(Native, out double x, out double y);
            return new PointD(x, y);
        }

        /// <summary>
        /// Gets the transformed size.
        /// </summary>
        /// <returns>The transformed size.</returns>
        public SizeD TransformToSize()
        {
            Libui.uiDrawMatrixTransformSize(Native, out double width, out double height);
            return new SizeD(width, height);
        }
    }
}