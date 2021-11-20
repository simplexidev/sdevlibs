using LibUISharp.Drawing;
using System;
using System.Runtime.InteropServices;

namespace LibUISharp.Native
{
    internal static partial class NativeMethods
    {
        internal static partial class Libui
        {
            [StructLayout(Layout)]
            internal struct uiDrawStrokeParams
            {
                public LineCap Cap;
                public LineJoin Join;
                public double Thickness;
                public double MiterLimit;
                public IntPtr Dashes;
                public UIntPtr NumDashes;
                public double DashPhase;
            }
        }
    }
}