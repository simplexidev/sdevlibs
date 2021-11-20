using System;
using System.Runtime.InteropServices;

namespace LibUISharp.Native
{
    internal static partial class NativeMethods
    {
        internal static partial class Libui
        {
            [StructLayout(Layout)]
            public class uiAreaHandler
            {
                public IntPtr Draw;
                public IntPtr MouseEvent;
                public IntPtr MouseCrossed;
                public IntPtr DragBroken;
                public IntPtr KeyEvent;
            }
        }
    }
}