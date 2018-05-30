using LibUISharp.Internal;
using LibUISharp.SafeHandles;

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
        public ProgressBar() => Handle = new SafeControlHandle(LibuiLibrary.uiNewProgressBar());

        /// <summary>
        /// Gets or sets the current value of this <see cref="ProgressBar"/>.
        /// </summary>
        public int Value
        {
            get
            {
                value = LibuiLibrary.uiProgressBarValue(Handle.DangerousGetHandle());
                return value;
            }
            set
            {
                if (this.value != value)
                {
                    LibuiLibrary.uiProgressBarSetValue(Handle.DangerousGetHandle(), value);
                    this.value = value;
                }
            }
        }
    }
}