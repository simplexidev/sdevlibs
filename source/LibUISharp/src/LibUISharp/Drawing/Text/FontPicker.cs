using System;
using static LibUISharp.Internal.LibUI;

namespace LibUISharp.Drawing
{
    public class FontPicker : Control
    {
        public FontPicker()
        {
            Handle = uiNewFontButton();
            InitializeEvents();
        }

        public event EventHandler FontChanged;

        private Font font;
        public Font Font
        {
            get
            {
                if (Font.IsEmpty(font))
                    font = Font.Empty;
                else
                {
                    uiFreeFontButtonFont((uiFontDescriptor)font);
                    font = Font.Empty;
                }
                uiFontButtonFont(Handle, out uiFontDescriptor f);
                font = (Font)f;
                return (Font)f;
            }
        }

        protected override void Destroy()
        {
            if (Font.IsEmpty(font))
            {
                Font f = font;
                font = Font.Empty;
                uiFreeFontButtonFont((uiFontDescriptor)f);
            }
            base.Destroy();
        }

        protected sealed override void InitializeEvents() => uiFontButtonOnChanged(Handle, (button, data) => { OnFontChanged(EventArgs.Empty); });

        protected virtual void OnFontChanged(EventArgs e) => FontChanged?.Invoke(this, e);
    }
}