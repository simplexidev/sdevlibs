using LibUISharp.Internal;
using static LibUISharp.Internal.UI;

namespace LibUISharp
{
    public class DateTimePicker : Control
    {
        protected DateTimePicker()
        {
            if (this is DatePicker)
                Handle = new UIControlHandle(uiNewDatePicker());
            else if (this is TimePicker)
                Handle = new UIControlHandle(uiNewTimePicker());
            else
                Handle = new UIControlHandle(uiNewDateTimePicker());
        }
    }

    public class DatePicker : DateTimePicker
    {
        public DatePicker() : base() { }
    }

    public class TimePicker : DateTimePicker
    {
        public TimePicker() : base() { }
    }
}