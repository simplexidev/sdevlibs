using LibUISharp.Internal;
using LibUISharp.SafeHandles;
using System;

namespace LibUISharp.Drawing
{
    //TODO: I don't know if this works either.
    public class FontPicker : Control
    {
        public FontPicker()
        {
            Handle = new SafeControlHandle(LibuiLibrary.uiNewFontButton());
            InitializeEvents();
        }

        public event EventHandler FontChanged;

        private Font font;
        private LibuiLibrary.uiFontDescriptor uifont;
        public Font Font
        {
            get
            {
                if (font == Font.Empty)
                    font = Font.Empty;
                else
                {
                    LibuiLibrary.uiFreeFontButtonFont(uifont);
                    font = Font.Empty;
                }
                LibuiLibrary.uiFontButtonFont(Handle.DangerousGetHandle(), out LibuiLibrary.uiFontDescriptor f);
                uifont = f;
                font = uifont.ToFont();
                return font;
            }
        }

        protected override void Destroy()
        {
            if (Font.IsEmpty(font))
            {
                Font f = font;
                font = Font.Empty;
                LibuiLibrary.uiFreeFontButtonFont(uifont);
            }
            base.Destroy();
        }

        protected sealed override void InitializeEvents() => LibuiLibrary.uiFontButtonOnChanged(Handle.DangerousGetHandle(), (button, data) => { OnFontChanged(EventArgs.Empty); }, IntPtr.Zero);

        protected virtual void OnFontChanged(EventArgs e) => FontChanged?.Invoke(this, e);
    }
}