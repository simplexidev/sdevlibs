using LibUISharp.Drawing;
using System.Runtime.InteropServices;

namespace LibUISharp.Native
{
    internal static partial class NativeMethods
    {
        internal static partial class Libui
        {
            [StructLayout(Layout)]
            internal struct uiAreaKeyEvent
            {
                public string Key;
                public ExtensionKey ExtKey;
                public ModifierKey Modifier;
                public ModifierKey Modifiers;
                public bool Up;
            }
        }
    }
}