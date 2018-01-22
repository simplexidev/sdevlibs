using System.Runtime.InteropServices;
using static LibUISharp.Internal.UI;

namespace LibUISharp.Drawing
{
    public class Matrix
    {
        public double M11
        {
            get => Internal.M11;
            set => Internal.M11 = value;
        }

        public double M12
        {
            get => Internal.M12;
            set => Internal.M12 = value;
        }

        public double M21
        {
            get => Internal.M21;
            set => Internal.M21 = value;
        }

        public double M22
        {
            get => Internal.M22;
            set => Internal.M22 = value;
        }

        public double M31
        {
            get => Internal.M31;
            set => Internal.M31 = value;
        }

        public double M32
        {
            get => Internal.M32;
            set => Internal.M32 = value;
        }

        internal uiDrawMatrix Internal = new uiDrawMatrix();

        public static Matrix SetIdentity()
        {
            Matrix matrix = new Matrix();
            uiDrawMatrixSetIdentity(matrix.Internal);
            return matrix;
        }

        public static void Multiply([Out]Matrix dest, [In]Matrix src) => uiDrawMatrixMultiply(dest.Internal, src.Internal);

        public void Translate(double x, double y) => uiDrawMatrixTranslate(Internal, x, y);

        public void Scale(double xCenter, double yCenter, double x, double y) => uiDrawMatrixScale(Internal, xCenter, yCenter, x, y);

        public void Rotate(double x, double y, double amount) => uiDrawMatrixRotate(Internal, x, y, amount);

        public void Skew(double x, double y, double xamount, double yamount) => uiDrawMatrixSkew(Internal, x, y, xamount, yamount);

        public void Multiply([In] ref Matrix src) => Multiply(this, src);

        public bool Invertible() => uiDrawMatrixInvertible(Internal);

        public int Invert() => uiDrawMatrixInvert(Internal);

        public PointD TransformToPoint()
        {
            uiDrawMatrixTransformPoint(Internal, out double x, out double y);
            PointD point = new PointD(x, y);
            return point;
        }

        public SizeD TransformtoSize()
        {
            uiDrawMatrixTransformSize(Internal, out double width, out double height);
            SizeD size = new SizeD(width, height);
            return size;
        }
    }
}