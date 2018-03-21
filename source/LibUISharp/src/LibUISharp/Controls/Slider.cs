using System;
using LibUISharp.Internal;

namespace LibUISharp.Controls
{
    public class Slider : Control
    {
        private int _value;

        public Slider(int min, int max)
        {
            Handle = LibUI.NewSlider(min, max);
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
                _value = LibUI.SliderGetValue(Handle);
                return _value;
            }
            set
            {
                if (_value != value)
                {
                    LibUI.SliderSetValue(Handle, value);
                    _value = value;
                }
            }
        }

        protected virtual void OnValueChanged(EventArgs e) => ValueChanged?.Invoke(this, e);

        protected sealed override void InitializeEvents() => LibUI.SliderOnValueChanged(Handle, (slider, data) => { OnValueChanged(EventArgs.Empty); });
    }
}