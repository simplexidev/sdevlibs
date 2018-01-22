using System;
using LibUISharp.Internal;
using static LibUISharp.Internal.UI;

namespace LibUISharp
{
    public class SpinBox : Control
    {
        public event EventHandler ValueChanged;

        public SpinBox(int min, int max)
        {
            Maximum = max;
            Minimum = min;
            Handle = new UIControlHandle(uiNewSpinbox(min, max));
            Initialize();
        }

        public int Maximum { get; private set; }
        public int Minimum { get; private set; }

        private int value;
        public int Value
        {
            get => value = uiSpinboxValue(Handle.DangerousGetHandle());
            set
            {
                if (this.value != value)
                {
                    uiSpinboxSetValue(Handle.DangerousGetHandle(), value);
                    this.value = value;
                }
            }
        }

        protected virtual void OnValueChanged(EventArgs e) => ValueChanged?.Invoke(this, e);

        protected sealed override void Initialize() =>
            uiSpinboxOnChanged(Handle.DangerousGetHandle(), (box, data) => { OnValueChanged(EventArgs.Empty); }, IntPtr.Zero);
    }
}