using System;
using LibUISharp.Internal;

namespace LibUISharp.Controls
{
    public class SpinBox : Control
    {
        private int _value;

        public SpinBox(int min, int max)
        {
            Handle = LibUIAPI.NewSpinBox(min, max);
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
                _value = LibUIAPI.SpinBoxGetValue(Handle);
                return _value;
            }
            set
            {
                if (_value != value)
                {
                    LibUIAPI.SpinBoxSetValue(Handle, value);
                    _value = value;
                }
            }
        }

        protected virtual void OnValueChanged(EventArgs e) => ValueChanged?.Invoke(this, e);

        protected sealed override void InitializeEvents() => LibUIAPI.SpinBoxOnValueChanged(Handle, (spinbox, data) => { OnValueChanged(EventArgs.Empty); });
    }
}