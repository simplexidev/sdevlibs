using LibUISharp.Internal;
using static LibUISharp.Internal.Libraries;

namespace LibUISharp
{
    /// <summary>
    /// Represents a control that indicates the progress of an operation.
    /// </summary>
    [LibuiType("uiProgressBar")]
    public class ProgressBar : Control
    {
        private int value;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProgressBar"/> class.
        /// </summary>
        public ProgressBar() => Handle = Libui.Call<Libui.uiNewProgressBar>()();

        /// <summary>
        /// Gets or sets the current value of this <see cref="ProgressBar"/>.
        /// </summary>
        public int Value
        {
            get
            {
                value = Libui.Call<Libui.uiProgressBarValue>()(this);
                return value;
            }
            set
            {
                if (this.value != value)
                {
                    Libui.Call<Libui.uiProgressBarSetValue>()(this, value);
                    this.value = value;
                }
            }
        }
    }
}