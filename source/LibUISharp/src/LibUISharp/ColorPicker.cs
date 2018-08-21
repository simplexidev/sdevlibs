using System;
using LibUISharp.Drawing;
using LibUISharp.Internal;
using LibUISharp.SafeHandles;

namespace LibUISharp
{
    /// <summary>
    /// Represents a common button that allows a user to choose a <see cref="Drawing.Color"/>.
    /// </summary>
    [NativeType("uiColorButton")]
    public class ColorPicker : Control
    {
        private Color? color = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorPicker"/> class.
        /// </summary>
        /// <param name="color">The color of the <see cref="ColorPicker"/>.</param>
        public ColorPicker(Color? color = null)
        {
            Handle = NativeCalls.NewColorButton();
            if (color != null)
                Color = (Color)color;
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
                if (IsInvalid) throw new UIComponentInvalidHandleException<SafeControlHandle>(this);
                NativeCalls.ColorButtonColor(Handle, out double red, out double green, out double blue, out double alpha);
                return new Color(red, green, blue, alpha);
            }
            set
            {
                if (color == value) return;
                if (IsInvalid) throw new UIComponentInvalidHandleException<SafeControlHandle>(this);
                NativeCalls.ColorButtonSetColor(Handle, value.R, value.G, value.B, value.A);
                color = value;
            }
        }

        /// <summary>
        /// Raises the <see cref="ColorChanged"/> event.
        /// </summary>
        protected virtual void OnColorChanged() => ColorChanged?.Invoke();

        /// <summary>
        /// Initializes this UI component's events.
        /// </summary>
        protected sealed override void InitializeEvents()
        {
            if (IsInvalid) throw new UIComponentInvalidHandleException<SafeControlHandle>(this);
            NativeCalls.ColorButtonOnChanged(Handle, (button, data) => { OnColorChanged(); }, IntPtr.Zero);
        }
    }
}