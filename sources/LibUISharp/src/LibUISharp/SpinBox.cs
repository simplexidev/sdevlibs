using System;
using static LibUISharp.Native.NativeMethods;

namespace LibUISharp
{
    /// <summary>
    /// Represents a spin box (also known as an up-down control) that displays numeric values.
    /// </summary>
    public class SpinBox : Control
    {
        private int value;

        /// <summary>
        /// Initializes a new instance of the <see cref="SpinBox"/> class with the specified minimum and maximum values.
        /// </summary>
        /// <param name="min">The minimum this <see cref="SpinBox"/> object's value can be.</param>
        /// <param name="max">The maximum this <see cref="SpinBox"/> object's value can be.</param>
        public SpinBox(int min, int max)
        {
            Handle = Libui.uiNewSpinbox(min, max);
            MinimumValue = min;
            MaximumValue = max;
            InitializeEvents();
        }

        /// <summary>
        /// Occurs when the <see cref="Value"/> property is changed.
        /// </summary>
        public event EventHandler ValueChanged;

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
                value = Libui.uiSpinboxValue(this);
                return value;
            }
            set
            {
                if (this.value != value)
                {
                    Libui.uiSpinboxSetValue(this, value);
                    this.value = value;
                }
            }
        }

        /// <summary>
        /// Called when the <see cref="ValueChanged"/> event is raised.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> containing the event data.</param>
        protected virtual void OnValueChanged(EventArgs e) => ValueChanged?.Invoke(this, e);

        /// <summary>
        /// Initializes this UI component.
        /// </summary>
        protected sealed override void InitializeEvents() => Libui.uiSpinboxOnChanged(this, (spinbox, data) => { OnValueChanged(EventArgs.Empty); }, IntPtr.Zero);
    }
}