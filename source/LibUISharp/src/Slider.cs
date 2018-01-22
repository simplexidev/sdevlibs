using System;
using LibUISharp.Internal;
using static LibUISharp.Internal.UI;

namespace LibUISharp
{
    public class Slider : Control
    {
        public event EventHandler ValueChanged;

        public Slider(int min, int max)
        {
            Maximum = max;
            Minimum = min;
            Handle = new UIControlHandle(uiNewSlider(min, max));
            Initialize();
        }

        public int Maximum { get; private set; }
        public int Minimum { get; private set; }

        private int value;
        public int Value
        {
            get => value = uiSliderValue(Handle.DangerousGetHandle());
            set
            {
                if (this.value != value)
                {
                    uiSliderSetValue(Handle.DangerousGetHandle(), value);
                    this.value = value;
                }
            }
        }

        protected virtual void OnValueChanged(EventArgs e) => ValueChanged?.Invoke(this, e);

        protected sealed override void Initialize() =>
            uiSliderOnChanged(Handle.DangerousGetHandle(), (box, data) => { OnValueChanged(EventArgs.Empty); }, IntPtr.Zero);
    }
}