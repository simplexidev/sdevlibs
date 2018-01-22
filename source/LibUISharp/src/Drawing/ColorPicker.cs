using System;
using LibUISharp.Internal;
using static LibUISharp.Internal.UI;

namespace LibUISharp.Drawing
{
    public class ColorPicker : Control
    {
        public event EventHandler ColorChanged;

        public ColorPicker()
        {
            Handle = new UIControlHandle(uiNewColorButton());
            color = Color.Empty;
            Initialize();
        }

        private Color color;
        public Color Color
        {
            get
            {
                uiColorButtonColor(Handle.DangerousGetHandle(), out double r, out double g, out double b, out double a);
                return new Color(r, g, b, a);
            }
            set
            {
                if (color != value)
                {
                    uiColorButtonSetColor(Handle.DangerousGetHandle(), value.R, value.G, value.B, value.A);
                    color = value;
                }
            }
        }

        protected sealed override void Initialize() =>
            uiColorButtonOnChanged(Handle.DangerousGetHandle(), (button, data) => { OnColorChanged(EventArgs.Empty); }, IntPtr.Zero);

        protected virtual void OnColorChanged(EventArgs e) => ColorChanged?.Invoke(this, e);
    }
}