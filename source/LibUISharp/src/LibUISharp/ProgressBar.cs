using static LibUISharp.Internal.LibUI;

namespace LibUISharp.Controls
{
    public class ProgressBar : Control
    {
        private int _value;

        public ProgressBar() => Handle = uiNewProgressBar();
        
        public int Value
        {
            get
            {
                _value = uiProgressBarValue(Handle);
                return _value;
            }
            set
            {
                if (_value != value)
                {
                    uiProgressBarSetValue(Handle, value);
                    _value = value;
                }
            }
        }
    }
}