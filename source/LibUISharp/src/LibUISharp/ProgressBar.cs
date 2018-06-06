using static LibUISharp.Native.NativeMethods;

namespace LibUISharp
{
    /// <summary>
    /// Represents a control that indicates the progress of an operation.
    /// </summary>
    public class ProgressBar : Control
    {
        private int value;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProgressBar"/> class.
        /// </summary>
        public ProgressBar() => Handle = Libui.uiNewProgressBar();

        /// <summary>
        /// Gets or sets the current value of this <see cref="ProgressBar"/>.
        /// </summary>
        public int Value
        {
            get
            {
                value = Libui.uiProgressBarValue(this);
                return value;
            }
            set
            {
                if (this.value != value)
                {
                    Libui.uiProgressBarSetValue(this, value);
                    this.value = value;
                }
            }
        }
    }
}