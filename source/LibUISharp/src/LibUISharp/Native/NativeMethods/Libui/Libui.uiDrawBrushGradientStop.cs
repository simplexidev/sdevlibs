using System.Runtime.InteropServices;

namespace LibUISharp.Native
{
    internal static partial class NativeMethods
    {
        internal static partial class Libui
        {
            [StructLayout(Layout)]
            internal struct uiDrawBrushGradientStop
            {
                public double Pos;
                public double R;
                public double G;
                public double B;
                public double A;
            }
        }
    }
}