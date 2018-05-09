using static LibUISharp.Internal.LibUI;

namespace LibUISharp
{
    // uiProgressBar
    public class ProgressBar : Control
    {
        private int value;

        public ProgressBar() => Handle = uiNewProgressBar();
        
        public int Value
        {
            get
            {
                value = uiProgressBarValue(Handle);
                return value;
            }
            set
            {
                if (this.value != value)
                {
                    uiProgressBarSetValue(Handle, value);
                    this.value = value;
                }
            }
        }
    }
}