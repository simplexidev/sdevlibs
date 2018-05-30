using System;

namespace LibUISharp.Drawing
{
    // uiModifier
    [Flags]
    public enum KeyModifierFlags : long
    {
        Ctrl = 1 << 0,
        Alt = 1 << 1,
        Shift = 1 << 2,
        Super = 1 << 3
    }
}