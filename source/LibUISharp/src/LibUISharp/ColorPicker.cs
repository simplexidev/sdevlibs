using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibUISharp.Drawing;

using static LibUISharp.Internal.LibUI;

namespace LibUISharp
{
    public class ColorPicker : Control
    {
        private Color color;

        public ColorPicker()
        {
            Handle = uiNewColorButton();
            color = new Color();
            InitializeEvents();
        }

        public event EventHandler ColorChanged;

        public Color Color
        {
            get
            {
                color = uiColorButtonColor(Handle);
                return color;
            }
            set
            {
                if (color != value)
                {
                    uiColorButtonSetColor(Handle, value);
                    color = value;
                }
            }
        }

        protected  sealed override void InitializeEvents() => uiColorButtonOnChanged(Handle, (button, data) => { OnColorChanged(EventArgs.Empty); });

        protected virtual void OnColorChanged(EventArgs e) => ColorChanged?.Invoke(this, e);
    }
}