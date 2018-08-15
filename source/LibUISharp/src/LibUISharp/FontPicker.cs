using System;
using LibUISharp.Drawing;
using LibUISharp.Internal;
using LibUISharp.SafeHandles;

namespace LibUISharp
{
    /// <summary>
    /// A button that allows a user to select a font.
    /// </summary>
    [NativeType("uiFontButton")]
    public class FontPicker : Control
    {
        private Font font;
        private bool disposed = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="FontPicker"/> class.
        /// </summary>
        public FontPicker()
        {
            Handle = new SafeControlHandle(NativeCalls.NewFontButton());
            InitializeEvents();
        }

        /// <summary>
        /// Occurs when the <see cref="Font"/> property is changed.
        /// </summary>
        public event Action FontChanged;

        /// <summary>
        /// Gets the currently selected font.
        /// </summary>
        public Font Font
        {
            get
            {
                NativeCalls.FontButtonFont(Handle, out font);
                return font;
            }
        }

        /// <summary>
        /// Initializes this UI component's events.
        /// </summary>
        protected sealed override void InitializeEvents() => NativeCalls.FontButtonOnChanged(Handle, (button, data) => { OnFontChanged(); }, IntPtr.Zero);

        /// <summary>
        /// Raises the <see cref="FontChanged"/> event.
        /// </summary>
        protected virtual void OnFontChanged() => FontChanged?.Invoke();

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <param name="disposing">Whether or not this control is disposing.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing)
            {
                if (font != null)
                {
                    NativeCalls.FreeFontButtonFont(font);
                    font = null;
                }
            }
            disposed = true;
            base.Dispose(disposing);
        }
    }
}