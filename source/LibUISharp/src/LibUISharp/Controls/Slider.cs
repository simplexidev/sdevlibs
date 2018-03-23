using System;
using LibUISharp.Internal;

namespace LibUISharp.Controls
{
    public class Slider : Control
    {
        private int _value;

        public Slider(int min, int max)
        {
            Handle = LibUIAPI.NewSlider(min, max);
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
                _value = LibUIAPI.SliderGetValue(Handle);
                return _value;
            }
            set
            {
                if (_value != value)
                {
                    LibUIAPI.SliderSetValue(Handle, value);
                    _value = value;
                }
            }
        }

        protected virtual void OnValueChanged(EventArgs e) => ValueChanged?.Invoke(this, e);

        protected sealed override void InitializeEvents() => LibUIAPI.SliderOnValueChanged(Handle, (slider, data) => { OnValueChanged(EventArgs.Empty); });
    }
}