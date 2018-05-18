using System;
using LibUISharp.Internal;
using LibUISharp.SafeHandles;

// uiSpinbox
namespace LibUISharp
{
    public class SpinBox : Control
    {
        private int value;

        public SpinBox(int min, int max)
        {
            Handle = new SafeControlHandle(LibuiLibrary.uiNewSpinbox(min, max));
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
                value = LibuiLibrary.uiSpinboxValue(Handle.DangerousGetHandle());
                return value;
            }
            set
            {
                if (this.value != value)
                {
                    LibuiLibrary.uiSpinboxSetValue(Handle.DangerousGetHandle(), value);
                    this.value = value;
                }
            }
        }

        protected virtual void OnValueChanged(EventArgs e) => ValueChanged?.Invoke(this, e);

        protected sealed override void InitializeEvents() => LibuiLibrary.uiSpinboxOnChanged(Handle.DangerousGetHandle(), (spinbox, data) => { OnValueChanged(EventArgs.Empty); }, IntPtr.Zero);
    }
}