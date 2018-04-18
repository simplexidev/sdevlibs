using System;
using LibUISharp.Drawing;
using LibUISharp.Native.Libraries;
using LibUISharp.Native.SafeHandles;

// uiColorButton
namespace LibUISharp.Controls
{
    /// <summary>
    /// Represents a common button that allows a user to choose a <see cref="Drawing.Color"/>.
    /// </summary>
    public class ColorPicker : Control
    {
        private Color color;

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorPicker"/> class.
        /// </summary>
        public ColorPicker()
        {
            Handle = new SafeControlHandle(LibuiLibrary.uiNewColorButton());
            color = Color.Empty;
            InitializeEvents();
        }

        /// <summary>
        /// Occurs when the <see cref="Color"/> property is changed.
        /// </summary>
        public event EventHandler ColorChanged;

        /// <summary>
        /// Gets or sets the color selected by the user.
        /// </summary>
        public Color Color
        {
            get
            {
                color = LibuiLibrary.uiColorButtonColor(Handle.DangerousGetHandle());
                return color;
            }
            set
            {
                if (color != value)
                {
                    LibuiLibrary.uiColorButtonSetColor(Handle.DangerousGetHandle(), value);
                    color = value;
                }
            }
        }

        /// <inheritdoc/>
        protected sealed override void InitializeEvents() => LibuiLibrary.uiColorButtonOnChanged(Handle.DangerousGetHandle(), (button, data) => { OnColorChanged(EventArgs.Empty); }, IntPtr.Zero);

        /// <summary>
        /// Raises the <see cref="ColorChanged"/> event.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnColorChanged(EventArgs e) => ColorChanged?.Invoke(this, e);
    }
}