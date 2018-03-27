using System;
using static LibUISharp.Internal.LibUI;

namespace LibUISharp
{
    public class Slider : Control
    {
        private int value;

        public Slider(int min, int max)
        {
            Handle = uiNewSlider(min, max);
            MinimumValue = min;
            MaximumValue = max;
            InitializeEvents();
        }

        public event EventHandler ValueChanged;
        
        public int MinimumValue { get; }
        public int MaximumValue { get; }

        public int Value
        {
            get
            {
                value = uiSliderValue(Handle);
                return value;
            }
            set
            {
                if (this.value != value)
                {
                    uiSliderSetValue(Handle, value);
                    this.value = value;
                }
            }
        }

        protected virtual void OnValueChanged(EventArgs e) => ValueChanged?.Invoke(this, e);

        protected sealed override void InitializeEvents() => uiSliderOnChanged(Handle, (slider, data) => { OnValueChanged(EventArgs.Empty); });
    }
}