using LibUISharp.Internal;

namespace LibUISharp.Controls
{
    public class DateTimePicker : Control
    {
        public DateTimePicker()
        {
            if (this is DatePicker)
                Handle = LibUIAPI.NewDatePicker();
            else if (this is TimePicker)
                Handle = LibUIAPI.NewTimePicker();
            else
                Handle = LibUIAPI.NewDateTimePicker();
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