using LibUISharp.Internal;
using LibUISharp.SafeHandles;

namespace LibUISharp
{
    /// <summary>
    /// Represents a control that indicates the progress of an operation.
    /// </summary>
    [NativeType("uiProgressBar")]
    public class ProgressBar : Control
    {
        private int value;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProgressBar"/> class.
        /// </summary>
        public ProgressBar() => Handle = new SafeControlHandle(NativeCalls.NewProgressBar());

        /// <summary>
        /// Gets or sets the current value of this <see cref="ProgressBar"/>.
        /// </summary>
        public int Value
        {
            get
            {
                value = NativeCalls.ProgressBarValue(Handle);
                return value;
            }
            set
            {
                if (this.value != value)
                {
                    NativeCalls.ProgressBarSetValue(Handle, value);
                    this.value = value;
                }
            }
        }
    }
}