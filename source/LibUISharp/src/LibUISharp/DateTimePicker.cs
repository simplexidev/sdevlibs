using LibUISharp.Internal;
using LibUISharp.SafeHandles;

namespace LibUISharp
{
    /// <summary>
    /// Implements the basic functonality required by a date-time picker.
    /// </summary>
    public abstract class DateTimePickerBase : Control
    {
#if LIBUI_4_0
        private DateTime dateTime;
#endif

        /// <summary>
        /// Initializes a new instance of the <see cref="DateTimePickerBase"/> class.
        /// </summary>
        protected DateTimePickerBase()
        {
            if (this is DatePicker)
                Handle = new SafeControlHandle(LibuiLibrary.uiNewDatePicker());
            else if (this is TimePicker)
                Handle = new SafeControlHandle(LibuiLibrary.uiNewTimePicker());
            else
                Handle = new SafeControlHandle(LibuiLibrary.uiNewDateTimePicker());
#if LIBUI_4_0
            InitializeEvents();
#endif
        }

#if LIBUI_4_0
        /// <summary>
        /// Occurs when the <see cref="DateTime"/> property is changed.
        /// </summary>
        public event EventHandler DateTimeChanged;

        /// <summary>
        /// Gets or sets the selected date and time.
        /// </summary>
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
        
        /// <summary>
        /// Initializes this UI component's events.
        /// </summary>
        protected sealed override void InitializeEvents() => LibuiLibrary.uiDateTimePickerOnChanged(Handle.DangerousGetHandle(), (d, data) => { OnDateTimeChanged(EventArgs.Empty); }, IntPtr.Zero);

        /// <summary>
        /// Called when the <see cref="DateTimeChanged"/> event is raised.
        /// </summary>
        protected virtual void OnDateTimeChanged(EventArgs e) => TimeChanged?.Invoke(this, e);
#endif
    }

    /// <summary>
    /// Represents a control that allows the user to select and display a date and time.
    /// </summary>
    public class DateTimePicker : DateTimePickerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DateTimePicker"/> class.
        /// </summary>
        public DateTimePicker() : base() { }

#if LIBUI_4_0
        /// <summary>
        /// Gets the day component from <see cref="DateTime"/>.
        /// </summary>
        public int Day => DateTime.Day;
        
        /// <summary>
        /// Gets the month component from <see cref="DateTime"/>.
        /// </summary>
        public int Month => DateTime.Month;
        
        /// <summary>
        /// Gets the year component from <see cref="DateTime"/>.
        /// </summary>
        public int Year => DateTime.Year;
        
        /// <summary>
        /// Gets the hour component from <see cref="DateTime"/>.
        /// </summary>
        public int Hour => DateTime.Hour;
        
        /// <summary>
        /// Gets the minute component from <see cref="DateTime"/>.
        /// </summary>
        public int Minute => DateTime.Minute;
        
        /// <summary>
        /// Gets the second component from <see cref="DateTime"/>.
        /// </summary>
        public int Second => DateTime.Second;
#endif
    }

    /// <summary>
    /// Represents a control that allows the user to select and display a date.
    /// </summary>
    public class DatePicker : DateTimePickerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DatePicker"/> class.
        /// </summary>
        public DatePicker() : base() { }

#if LIBUI_4_0
        /// <summary>
        /// Gets the day component from <see cref="DateTime"/>.
        /// </summary>
        public int Day => DateTime.Day;
        
        /// <summary>
        /// Gets the month component from <see cref="DateTime"/>.
        /// </summary>
        public int Month => DateTime.Month;
        
        /// <summary>
        /// Gets the year component from <see cref="DateTime"/>.
        /// </summary>
        public int Year => DateTime.Year;
#endif
    }

    /// <summary>
    /// Represents a control that allows the user to select and display a time.
    /// </summary>
    public class TimePicker : DateTimePickerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TimePicker"/> class.
        /// </summary>
        public TimePicker() : base() { }

#if LIBUI_4_0
        /// <summary>
        /// Gets the hour component from <see cref="DateTime"/>.
        /// </summary>
        public int Hour => DateTime.Hour;
        
        /// <summary>
        /// Gets the minute component from <see cref="DateTime"/>.
        /// </summary>
        public int Minute => DateTime.Minute;
        
        /// <summary>
        /// Gets the second component from <see cref="DateTime"/>.
        /// </summary>
        public int Second => DateTime.Second;
#endif
    }
}