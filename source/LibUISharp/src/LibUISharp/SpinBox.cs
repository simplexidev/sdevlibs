using System;
using LibUISharp.Internal;

namespace LibUISharp
{
    /// <summary>
    /// Represents a spin box (also known as an up-down control) that displays numeric values.
    /// </summary>
    [NativeType("uiSpinbox")]
    public class SpinBox : Control
    {
        private int value;

        /// <summary>
        /// Initializes a new instance of the <see cref="SpinBox"/> class with the specified minimum and maximum values.
        /// </summary>
        /// <param name="min">The minimum this <see cref="SpinBox"/> object's value can be.</param>
        /// <param name="max">The maximum this <see cref="SpinBox"/> object's value can be.</param>
        public SpinBox(int min = 0, int max = 100)
        {
            Handle = NativeCalls.NewSpinbox(min, max);
            MinimumValue = min;
            MaximumValue = max;
            InitializeEvents();
        }

        /// <summary>
        /// Occurs when the <see cref="Value"/> property is changed.
        /// </summary>
        public event Action ValueChanged;

        /// <summary>
        /// Gets this <see cref="SpinBox"/> object's minimum value.
        /// </summary>
        public int MinimumValue { get; }

        /// <summary>
        /// Gets this <see cref="SpinBox"/> object's maximum value.
        /// </summary>
        public int MaximumValue { get; }

        /// <summary>
        /// Gets or sets the current value of this <see cref="SpinBox"/>.
        /// </summary>
        public int Value
        {
            get
            {
                value = NativeCalls.SpinboxValue(Handle);
                return value;
            }
            set
            {
                if (this.value != value)
                {
                    NativeCalls.SpinboxSetValue(Handle, value);
                    this.value = value;
                }
            }
        }

        /// <summary>
        /// Called when the <see cref="ValueChanged"/> event is raised.
        /// </summary>
        protected virtual void OnValueChanged() => ValueChanged?.Invoke();

        /// <summary>
        /// Initializes this UI component.
        /// </summary>
        protected sealed override void InitializeEvents() => NativeCalls.SpinboxOnChanged(Handle, (slider, data) => { OnValueChanged(); }, IntPtr.Zero);
    }
}