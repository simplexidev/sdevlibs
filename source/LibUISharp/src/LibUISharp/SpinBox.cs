using System;
using static LibUISharp.Internal.LibUI;

namespace LibUISharp
{
    public class SpinBox : Control
    {
        private int value;

        public SpinBox(int min, int max)
        {
            Handle = uiNewSpinbox(min, max);
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
                value = uiSpinboxValue(Handle);
                return value;
            }
            set
            {
                if (this.value != value)
                {
                    uiSpinboxSetValue(Handle, value);
                    this.value = value;
                }
            }
        }

        protected virtual void OnValueChanged(EventArgs e) => ValueChanged?.Invoke(this, e);

        protected sealed override void InitializeEvents() => uiSpinboxOnChanged(Handle, (spinbox, data) => { OnValueChanged(EventArgs.Empty); });
    }
}