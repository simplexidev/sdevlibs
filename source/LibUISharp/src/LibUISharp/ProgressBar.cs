using LibUISharp.Internal;

namespace LibUISharp.Controls
{
    public class ProgressBar : Control
    {
        private int _value;

        public ProgressBar() => Handle = LibUIAPI.NewProgressBar();
        
        public int Value
        {
            get
            {
                _value = LibUIAPI.ProgressBarGetValue(Handle);
                return _value;
            }
            set
            {
                if (_value != value)
                {
                    LibUIAPI.ProgressBarSetValue(Handle, value);
                    _value = value;
                }
            }
        }
    }
}