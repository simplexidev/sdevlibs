using static LibUISharp.Internal.LibUI;

namespace LibUISharp.Controls
{
    public class DateTimePicker : Control
    {
        public DateTimePicker()
        {
            if (this is DatePicker)
                Handle = uiNewDatePicker();
            else if (this is TimePicker)
                Handle = uiNewTimePicker();
            else
                Handle = uiNewDateTimePicker();
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