using System;

namespace LibUISharp.Drawing
{
    /// <summary>
    /// Provides key data for an event.
    /// </summary>
    public class KeyEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="KeyEventArgs"/> class.
        /// </summary>
        /// <param name="key">The key that was pressed.</param>
        /// <param name="ext">The extension key that was pressed.</param>
        /// <param name="modifier">The single modifier that was pressed</param>
        /// <param name="modifiers">The modifier keys that were pressed.</param>
        /// <param name="up">Whether the key was released or not.</param>
        public KeyEventArgs(string key, ExtensionKey ext, ModifierKey modifier, ModifierKey modifiers, bool up)
        {
            Key = key;
            Extension = ext;
            Modifier = modifier;
            Modifiers = modifiers;
            Up = up;
        }

        /// <summary>
        /// Gets the key that was presseed as a string.
        /// </summary>
        public string Key { get; }

        /// <summary>
        /// Gets the pressed extension key.
        /// </summary>
        public ExtensionKey Extension { get; }

        /// <summary>
        /// Gets a single modifier key-press.
        /// </summary>
        public ModifierKey Modifier { get; }

        /// <summary>
        /// Gets the modifier keys that were pressed.
        /// </summary>
        public ModifierKey Modifiers { get; }

        /// <summary>
        /// Gets a value indicating if the key was released.
        /// </summary>
        public bool Up { get; }
    }
}