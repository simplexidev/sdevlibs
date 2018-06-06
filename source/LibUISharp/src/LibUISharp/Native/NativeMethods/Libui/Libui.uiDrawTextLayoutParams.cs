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
            public struct uiDrawTextLayoutParams
            {
                public IntPtr String;
                public uiFontDescriptor DefaultFont;
                public double Width;
                public TextAlignment Align;
            }
        }
    }
}