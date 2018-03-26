using System;
using static LibUISharp.Internal.LibUI;

namespace LibUISharp.Controls
{
    public class Slider : Control
    {
        private int _value;

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
                _value = uiSliderValue(Handle);
                return _value;
            }
            set
            {
                if (_value != value)
                {
                    uiSliderSetValue(Handle, value);
                    _value = value;
                }
            }
        }

        protected virtual void OnValueChanged(EventArgs e) => ValueChanged?.Invoke(this, e);

        protected sealed override void InitializeEvents() => uiSliderOnChanged(Handle, (slider, data) => { OnValueChanged(EventArgs.Empty); });
    }
}