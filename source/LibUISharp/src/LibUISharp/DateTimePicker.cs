using LibUISharp.Internal;
using LibUISharp.SafeHandles;
using System;

// uiDateTimePicker
namespace LibUISharp
{
    public class DateTimePicker : Control
    {
        private DateTime dateTime;

        public DateTimePicker()
        {
            if (!(this is DatePicker || this is TimePicker))
                Handle = new SafeControlHandle(LibuiLibrary.uiNewDateTimePicker());
            InitializeEvents();
        }

        public event EventHandler TimeChanged;

        public DateTime DateTime
        {
            get
            {
                LibuiLibrary.uiDateTimePickerTime(Handle.DangerousGetHandle(), out LibuiLibrary.tm time);
                dateTime = time.ToDateTime();
                return dateTime;
            }
            set
            {
                if (dateTime != value)
                {
                    LibuiLibrary.uiDateTimePickerSetTime(Handle.DangerousGetHandle(), value.ToLibuiDateTime());
                    dateTime = value;
                }
            }
        }

        public int Hour => DateTime.Hour;
        public int Minute => DateTime.Minute;
        public int Second => DateTime.Second;
        public int Day => DateTime.Day;
        public int Month => DateTime.Month;
        public int Year => DateTime.Year;

        protected sealed override void InitializeEvents() => LibuiLibrary.uiDateTimePickerOnChanged(Handle.DangerousGetHandle(), (d, data) => { OnTimeChanged(EventArgs.Empty); }, IntPtr.Zero);

        protected virtual void OnTimeChanged(EventArgs e) => TimeChanged?.Invoke(this, e);
    }

    public class DatePicker : DateTimePicker
    {
        public DatePicker() : base() => Handle = new SafeControlHandle(LibuiLibrary.uiNewDatePicker());

        private new int Hour => throw new NotSupportedException();
        private new int Minute => throw new NotSupportedException();
        private new int Second => throw new NotSupportedException();
    }

    public class TimePicker : DateTimePicker
    {
        public TimePicker() : base() => Handle = new SafeControlHandle(LibuiLibrary.uiNewTimePicker());

        private new int Day => throw new NotSupportedException();
        private new int Month => throw new NotSupportedException();
        private new int Year => throw new NotSupportedException();
    }
}