using LibUISharp.Native.Libraries;
using LibUISharp.Native.SafeHandles;

// uiDateTimePicker
namespace LibUISharp
{
    public class DateTimePicker : Control
    {
        public DateTimePicker()
        {
            if (!(this is DatePicker || this is TimePicker))
                Handle = new SafeControlHandle(LibuiLibrary.uiNewDateTimePicker());
        }
    }

    public class DatePicker : DateTimePicker
    {
        public DatePicker() : base() => Handle = new SafeControlHandle(LibuiLibrary.uiNewDatePicker());
    }

    public class TimePicker : DateTimePicker
    {
        public TimePicker() : base() => Handle = new SafeControlHandle(LibuiLibrary.uiNewTimePicker());
    }
}