using System;
using System.Runtime.InteropServices;

namespace LibUISharp.Native
{
    internal static partial class NativeMethods
    {
        internal static partial class Libui
        {
            [StructLayout(Layout)]
            internal struct uiInitOptions
            {
                public UIntPtr Size;
            }
        }
    }
}