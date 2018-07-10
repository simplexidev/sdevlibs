using LibUISharp.Drawing;
using System.Runtime.InteropServices;

namespace LibUISharp.Native
{
    internal static partial class NativeMethods
    {
        internal static partial class Libui
        {
            [StructLayout(Layout)]
            internal struct uiFontDescriptor
            {
                public string Family;
                public double Size;
                public FontWeight Weight;
                public FontStyle Style;
                public FontStretch Stretch;
            }
        }
    }
}