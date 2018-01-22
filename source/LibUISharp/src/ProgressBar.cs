using LibUISharp.Internal;
using static LibUISharp.Internal.UI;

namespace LibUISharp
{
    public class ProgressBar : Control
    {
        public ProgressBar() => Handle = new UIControlHandle(uiNewProgressBar());

        private int value;
        public int Value
        {
            get => value = uiProgressBarValue(Handle.DangerousGetHandle());
            set
            {
                if (this.value != value)
                {
                    uiProgressBarSetValue(Handle.DangerousGetHandle(), value);
                    this.value = value;
                }
            }
        }
    }
}