using System;

namespace LibUISharp.Drawing
{
    // uiAreaKeyEvent
    public class KeyEventArgs : EventArgs
    {
        public KeyEventArgs(byte key, KeyExtension ext, KeyModifierFlags keyModifier, bool up)
        {
            Key = key;
            Extension = ext;
            Modifiers = keyModifier;
            Up = up;
        }

        public byte Key { get; }
        public KeyExtension Extension { get; }
        public KeyModifierFlags Modifiers { get; }
        public bool Up { get; }
    }
}