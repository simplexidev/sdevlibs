using System;

namespace LibUISharp.Drawing
{
    [Flags]
    public enum ModifierKeyFlags
    {
        Control = 1 << 0,
        Alt = 1 << 1,
        Shift = 1 << 2,
        Super = 1 << 3
    }
}