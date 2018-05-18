using System;
using LibUISharp.Internal;
using LibUISharp.SafeHandles;

// uiSlider
namespace LibUISharp
{
    public class Slider : Control
    {
        private int value;

        public Slider(int min, int max)
        {
            Handle = new SafeControlHandle(LibuiLibrary.uiNewSlider(min, max));
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
                value = LibuiLibrary.uiSliderValue(Handle.DangerousGetHandle());
                return value;
            }
            set
            {
                if (this.value != value)
                {
                    LibuiLibrary.uiSliderSetValue(Handle.DangerousGetHandle(), value);
                    this.value = value;
                }
            }
        }

        protected virtual void OnValueChanged(EventArgs e) => ValueChanged?.Invoke(this, e);

        protected sealed override void InitializeEvents() => LibuiLibrary.uiSliderOnChanged(Handle.DangerousGetHandle(), (slider, data) => { OnValueChanged(EventArgs.Empty); }, IntPtr.Zero);
    }
}