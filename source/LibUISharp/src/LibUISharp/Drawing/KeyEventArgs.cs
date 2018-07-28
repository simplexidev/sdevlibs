using System;
using System.Runtime.InteropServices;
using LibUISharp.Internal;

namespace LibUISharp.Drawing
{
    /// <summary>
    /// Provides key data for an event.
    /// </summary>
    [LibuiType("uiAreaKeyEvent")]
    [Serializable]
    [StructLayout(Libraries.Libui.StructLayout)]
    public struct KeyEventArgs
    {
        /// <summary>
        /// Gets the key that was presseed as a string.
        /// </summary>
        public readonly char Key;

        /// <summary>
        /// Gets the pressed extension key.
        /// </summary>
        public readonly ExtensionKey Extension;

        /// <summary>
        /// Gets a single modifier key-press.
        /// </summary>
        public readonly ModifierKey Modifier;

        /// <summary>
        /// Gets the modifier keys that were pressed.
        /// </summary>
        public readonly ModifierKey Modifiers;

        /// <summary>
        /// Gets a value indicating if the key was released.
        /// </summary>
        public readonly bool Up;

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyEventArgs"/> class.
        /// </summary>
        /// <param name="key">The key that was pressed.</param>
        /// <param name="ext">The extension key that was pressed.</param>
        /// <param name="modifier">The single modifier that was pressed</param>
        /// <param name="modifiers">The multiple modifier keys that were pressed.</param>
        /// <param name="up">Whether the key was released or not.</param>
        public KeyEventArgs(char key, ExtensionKey ext, ModifierKey modifier, ModifierKey modifiers, bool up)
        {
            Key = key;
            Extension = ext;
            Modifier = modifier;
            Modifiers = modifiers;
            Up = up;
        }
    }
}