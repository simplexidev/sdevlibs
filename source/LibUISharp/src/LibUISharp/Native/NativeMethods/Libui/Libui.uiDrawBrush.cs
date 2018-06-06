using System;
using System.Runtime.InteropServices;

namespace LibUISharp.Native
{
    internal static partial class NativeMethods
    {
        internal static partial class Libui
        {
            [StructLayout(Layout)]
            internal struct uiDrawBrush
            {
                [MarshalAs(UnmanagedType.I4)]
                public uiDrawBrushType Type;

                // Solid Brushes
                public double R;
                public double G;
                public double B;
                public double A;

                // Gradient Brushes
                public double X0; // linear: start X, radial: start X
                public double Y0; // linear: start Y, radial: start Y
                public double X1; // linear: end X,   radial: outer circle center X
                public double Y1; // linear: end Y,   radial: outer circle center Y
                public double OuterRadius; // radial gradients only
                public IntPtr Stops;
                public UIntPtr NumStops;
            }
        }
    }
}