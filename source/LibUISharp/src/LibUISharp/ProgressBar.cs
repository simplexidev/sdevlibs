using LibUISharp.Internal;
using LibUISharp.SafeHandles;

// uiProgressBar
namespace LibUISharp
{
    public class ProgressBar : Control
    {
        private int value;

        public ProgressBar() => Handle = new SafeControlHandle(LibuiLibrary.uiNewProgressBar());

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