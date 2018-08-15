using System;
using LibUISharp.Internal;

namespace LibUISharp.Drawing
{
    /// <summary>
    /// Represents a modifier key on a keyboard.
    /// </summary>
    [Flags]
    [NativeType("uiModifier")]
    public enum ModifierKey : long
    {
        /// <summary>
        /// The control key.
        /// </summary>
        Ctrl = 1 << 0,

        /// <summary>
        /// The alternate key.
        /// </summary>
        Alt = 1 << 1,

        /// <summary>
        /// The shift key.
        /// </summary>
        Shift = 1 << 2,

        /// <summary>
        /// The super key.
        /// </summary>
        Super = 1 << 3
    }
}