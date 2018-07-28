using System;
using LibUISharp.Drawing;
using LibUISharp.Internal;
using static LibUISharp.Internal.Libraries;

namespace LibUISharp
{
    /// <summary>
    /// A button that allows a user to select a font.
    /// </summary>
    [LibuiType("uiFontButton")]
    public class FontPicker : Control
    {
        private Font font;
        private bool disposed = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="FontPicker"/> class.
        /// </summary>
        public FontPicker()
        {
            Handle = Libui.Call<Libui.uiNewFontButton>()();
            InitializeEvents();
        }

        /// <summary>
        /// Occurs when the <see cref="Font"/> property is changed.
        /// </summary>
        public event EventHandler FontChanged;

        /// <summary>
        /// Gets the currently selected font.
        /// </summary>
        public Font Font
        {
            get
            {
                Libui.Call<Libui.uiFontButtonFont>()(this, out font.Native);
                return font;
            }
        }

        /// <summary>
        /// Initializes this UI component's events.
        /// </summary>
        protected sealed override void InitializeEvents() => Libui.Call<Libui.uiFontButtonOnChanged>()(this, (button, data) => { OnFontChanged(EventArgs.Empty); }, IntPtr.Zero);

        /// <summary>
        /// Raises the <see cref="FontChanged"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        protected virtual void OnFontChanged(EventArgs e) => FontChanged?.Invoke(this, e);

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <param name="disposing">Whether or not this control is disposing.</param>
        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing && Handle != IntPtr.Zero)
                {
                    if (Font != null)
                    {
                        Libui.Call<Libui.uiFreeFontButtonFont>()(font.Native);
                        font = null;
                    }
                }
                disposed = true;
                base.Dispose(disposing);
            }
        }
    }
}