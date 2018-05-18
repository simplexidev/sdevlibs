using LibUISharp.Internal;
using System;
using System.Runtime.InteropServices;

// uiDrawStrokeParams
namespace LibUISharp.Drawing
{
    public class StrokeOptions
    {
        public const double DefaultMiterLimit = 10.0;

        public StrokeOptions() => MiterLimit = DefaultMiterLimit;

        internal LibuiLibrary.uiDrawStrokeParams Internal = new LibuiLibrary.uiDrawStrokeParams();

        public LineCap Cap
        {
            get => (LineCap)Internal.Cap;
            set => Internal.Cap = (LibuiLibrary.uiDrawLineCap)value;
        }

        public LineJoin Join
        {
            get => (LineJoin)Internal.Join;
            set => Internal.Join = (LibuiLibrary.uiDrawLineJoin)value;
        }

        public double Thickness
        {
            get => Internal.Thickness;
            set => Internal.Thickness = value;
        }

        public double MiterLimit
        {
            get => Internal.MiterLimit;
            set => Internal.MiterLimit = value;
        }

        public double[] Dashes
        {
            set
            {
                if (value != null && value.Length != 0)
                {
                    int length = value.Length;
                    Internal.Dashes = Marshal.UnsafeAddrOfPinnedArrayElement(value, 0);
                    Internal.NumDashes = (UIntPtr)length;
                }
            }
        }

        public double DashPhase
        {
            get => Internal.DashPhase;
            set => Internal.DashPhase = value;
        }
    }
}