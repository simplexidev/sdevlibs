using System;
using LibUISharp.Drawing;
using LibUISharp.Internal;

namespace LibUISharp
{
    /// <summary>
    /// Represents a common button that allows a user to choose a <see cref="Drawing.Color"/>.
    /// </summary>
    [NativeType("uiColorButton")]
    public class ColorPicker : Control
    {
        private Color color;

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorPicker"/> class.
        /// </summary>
        public ColorPicker()
        {
            Handle = NativeCalls.NewColorButton();
            color = Color.Empty;
            InitializeEvents();
        }

        /// <summary>
        /// Occurs when the <see cref="Color"/> property is changed.
        /// </summary>
        public event Action ColorChanged;

        /// <summary>
        /// Gets or sets the color selected by the user.
        /// </summary>
        public Color Color
        {
            get
            {
                NativeCalls.ColorButtonColor(this, out double red, out double green, out double blue, out double alpha);
                color = new Color(red, green, blue, alpha);
                return color;
            }
            set
            {
                if (color != value)
                {
                    NativeCalls.ColorButtonSetColor(this, value.R, value.G, value.B, value.A);
                    color = value;
                }
            }
        }

        /// <summary>
        /// Initializes this UI component's events.
        /// </summary>
        protected sealed override void InitializeEvents() => NativeCalls.ColorButtonOnChanged(this, (button, data) => { OnColorChanged(); }, IntPtr.Zero);

        /// <summary>
        /// Raises the <see cref="ColorChanged"/> event.
        /// </summary>
        protected virtual void OnColorChanged() => ColorChanged?.Invoke();
    }
}