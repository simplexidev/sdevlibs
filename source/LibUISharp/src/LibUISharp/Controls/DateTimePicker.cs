using LibUISharp.Internal;

namespace LibUISharp.Controls
{
    public class DateTimePicker : Control
    {
        public DateTimePicker()
        {
            if (this is DatePicker)
                Handle = LibUI.NewDatePicker();
            else if (this is TimePicker)
                Handle = LibUI.NewTimePicker();
            else
                Handle = LibUI.NewDateTimePicker();
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