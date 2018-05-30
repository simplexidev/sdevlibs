using System;
using LibUISharp.Internal;
using LibUISharp.SafeHandles;

namespace LibUISharp
{
    /// <summary>
    /// Represents a control that inputs a linear value.
    /// </summary>
    public class Slider : Control
    {
        private int value;

        /// <summary>
        /// Initializes a new instance of the <see cref="Slider"/> class with the specified minimum and maximum values.
        /// </summary>
        /// <param name="min">The minimum this <see cref="Slider"/> object's value can be.</param>
        /// <param name="max">The maximum this <see cref="Slider"/> object's value can be.</param>
        public Slider(int min, int max)
        {
            Handle = new SafeControlHandle(LibuiLibrary.uiNewSlider(min, max));
            MinimumValue = min;
            MaximumValue = max;
            InitializeEvents();
        }

        /// <summary>
        /// Occurs when the <see cref="Value"/> property is changed.
        /// </summary>
        public event EventHandler ValueChanged;

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

        /// <summary>
        /// Called when the <see cref="ValueChanged"/> event is raised.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> containing the event data.</param>
        protected virtual void OnValueChanged(EventArgs e) => ValueChanged?.Invoke(this, e);

        /// <summary>
        /// Initializes this UI component.
        /// </summary>
        protected sealed override void InitializeEvents() => LibuiLibrary.uiSliderOnChanged(Handle.DangerousGetHandle(), (slider, data) => { OnValueChanged(EventArgs.Empty); }, IntPtr.Zero);
    }
}