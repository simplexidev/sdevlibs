using LibUISharp.Drawing;
using System.Runtime.InteropServices;

namespace LibUISharp.Native
{
    internal static partial class NativeMethods
    {
        internal static partial class Libui
        {
            [StructLayout(Layout)]
            internal struct uiAreaMouseEvent
            {
                public double X;
                public double Y;

                public double AreaWidth;
                public double AreaHeight;

                public bool Down;
                public bool Up;

                public int Count;

                public ModifierKey Modifiers;

                public long Held1To64;
            }
        }
    }
}