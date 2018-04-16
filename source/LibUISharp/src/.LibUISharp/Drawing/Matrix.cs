using System.Runtime.InteropServices;
using static LibUISharp.Internal.LibUI;

namespace LibUISharp.Drawing
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Matrix
    {
        public Matrix(double m11, double m12, double m21, double m22, double m31, double m32)
        {
            M11 = m11;
            M12 = m12;
            M21 = m21;
            M22 = m22;
            M31 = m31;
            M32 = m32;
        }

        public double M11 { get; set; }
        public double M12 { get; set; }
        public double M21 { get; set; }
        public double M22 { get; set; }
        public double M31 { get; set; }
        public double M32 { get; set; }

        public static Matrix SetIdentity()
        {
            Matrix matrix = new Matrix();
            uiDrawMatrixSetIdentity((uiDrawMatrix)matrix);
            return matrix;
        }
        
        public void Translate(double x, double y) => uiDrawMatrixTranslate((uiDrawMatrix)this, x, y);

        public void Scale(double xCenter, double yCenter, double x, double y) => uiDrawMatrixScale((uiDrawMatrix)this, xCenter, yCenter, x, y);

        public void Rotate(double x, double y, double amount) => uiDrawMatrixRotate((uiDrawMatrix)this, x, y, amount);

        public void Skew(double x, double y, double xamount, double yamount) => uiDrawMatrixSkew((uiDrawMatrix)this, x, y, xamount, yamount);

        public void Multiply([In] ref Matrix src) => Multiply(this, src);
        public static void Multiply([Out]  Matrix dest, [In]  Matrix src) => uiDrawMatrixMultiply((uiDrawMatrix)dest, (uiDrawMatrix)src);

        public void Invertible() => uiDrawMatrixInvertible((uiDrawMatrix)this);

        public void Invert() => uiDrawMatrixInvert((uiDrawMatrix)this);

        public PointD TransformToPoint()
        {
            uiDrawMatrixTransformPoint((uiDrawMatrix)this, out double x, out double y);
            return new PointD(x, y);
        }

        public SizeD TransformToSize()
        {
            uiDrawMatrixTransformSize((uiDrawMatrix)this, out double width, out double height);
            return new SizeD(width, height);
        }
    }
}