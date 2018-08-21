using System;
using System.Threading;
using LibUISharp.Internal;

namespace LibUISharp
{
    /// <summary>
    /// Represents a control that inputs a linear value.
    /// </summary>
    [NativeType("uiSlider")]
    public class Slider : Control
    {
        private int value = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="Slider"/> class with the specified minimum and maximum values.
        /// </summary>
        /// <param name="min">The minimum this <see cref="Slider"/> object's value can be.</param>
        /// <param name="max">The maximum this <see cref="Slider"/> object's value can be.</param>
        public Slider(int min = 0, int max = 100, int startValue = 0)
        {
            Handle = NativeCalls.NewSlider(min, max);
            Thread.Sleep(100);
            MinimumValue = min;
            MaximumValue = max;
            if (value != startValue)
                Value = startValue;
            InitializeEvents();
        }

        /// <summary>
        /// Occurs when the <see cref="Value"/> property is changed.
        /// </summary>
        public event Action ValueChanged;

        /// <summary>
        /// Gets this <see cref="Slider"/> object's minimum value.
        /// </summary>
        public int MinimumValue { get; }

        /// <summary>
        /// Gets this <see cref="Slider"/> object's maximum value.
        /// </summary>
        public int MaximumValue { get; }

        /// <summary>
        /// Gets or sets the current value of this <see cref="Slider"/>.
        /// </summary>
        public int Value
        {
            get
            {
                value = NativeCalls.SliderValue(Handle);
                return value;
            }
            set
            {
                if (this.value != value)
                {
                    NativeCalls.SliderSetValue(Handle, value);
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
        protected sealed override void InitializeEvents() => NativeCalls.SliderOnChanged(Handle, (slider, data) => { OnValueChanged(); }, IntPtr.Zero);
    }
}