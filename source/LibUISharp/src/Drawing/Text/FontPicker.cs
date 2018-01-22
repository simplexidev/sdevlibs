using System;
using LibUISharp.Internal;
using static LibUISharp.Internal.UI;

namespace LibUISharp.Drawing.Text
{
    public class FontPicker : Control
    {
        public FontPicker()
        {
            Handle = new UIControlHandle(uiNewFontButton());
            Initialize();
        }

        public event EventHandler FontChanged;

        private Font font = Font.Empty;
        public Font Font
        {
            get
            {
                uiFontButtonFont(Handle.DangerousGetHandle(), out uiDrawFontDescriptor f);
                return new Font(MarshalHelper.StringFromUTF8(f.Family), f.Size, f.Weight, f.Style, f.Stretch);
            }
        }

        protected sealed override void Initialize() => uiFontButtonOnChanged(Handle.DangerousGetHandle(), (button, data) => { OnFontChanged(EventArgs.Empty); }, IntPtr.Zero);

        protected virtual void OnFontChanged(EventArgs e) => FontChanged?.Invoke(this, e);
    }
}