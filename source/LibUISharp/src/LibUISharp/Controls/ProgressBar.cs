using LibUISharp.Internal;

namespace LibUISharp.Controls
{
    public class ProgressBar : Control
    {
        private int _value;

        public ProgressBar() => Handle = LibUI.NewProgressBar();
        
        public int Value
        {
            get
            {
                _value = LibUI.ProgressBarGetValue(Handle);
                return _value;
            }
            set
            {
                if (_value != value)
                {
                    LibUI.ProgressBarSetValue(Handle, value);
                    _value = value;
                }
            }
        }
    }
}