using LibUISharp.Native.Libraries;
using LibUISharp.Native.SafeHandles;

// uiDateTimePicker
namespace LibUISharp
{
    public class DateTimePicker : Control
    {
        public DateTimePicker()
        {
            if (this is DatePicker)
                Handle = new SafeControlHandle(LibuiLibrary.uiNewDatePicker());
            else if (this is TimePicker)
                Handle = new SafeControlHandle(LibuiLibrary.uiNewTimePicker());
            else
                Handle = new SafeControlHandle(LibuiLibrary.uiNewDateTimePicker());
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