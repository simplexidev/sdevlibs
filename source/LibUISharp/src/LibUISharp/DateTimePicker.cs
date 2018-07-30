using System;
using System.Runtime.InteropServices;
using LibUISharp.Internal;
using static LibUISharp.Internal.Libraries;

namespace LibUISharp
{
    /// <summary>
    /// Implements the basic functonality required by a date-time picker.
    /// </summary>
    [NativeType("uiDateTimePicker")]
    public abstract class DateTimePickerBase : Control
    {
        private DateTime dateTime;

        /// <summary>
        /// Initializes a new instance of the <see cref="DateTimePickerBase"/> class.
        /// </summary>
        protected DateTimePickerBase() { }

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
                Libui.Call<Libui.uiDateTimePickerTime>()(this, out UIDateTime time);
                dateTime = UIDateTime.ToDateTime(time);
                return dateTime;
            }
            set
            {
                if (dateTime != value)
                {
                    Libui.Call<Libui.uiDateTimePickerSetTime>()(this, UIDateTime.FromDateTime(value));
                    dateTime = value;
                }
            }
        }

        /// <summary>
        /// Initializes this UI component's events.
        /// </summary>
        protected sealed override void InitializeEvents() => Libui.Call<Libui.uiDateTimePickerOnChanged>()(this, (d, data) => { OnDateTimeChanged(EventArgs.Empty); }, IntPtr.Zero);

        /// <summary>
        /// Called when the <see cref="DateTimeChanged"/> event is raised.
        /// </summary>
        protected virtual void OnDateTimeChanged(EventArgs e) => DateTimeChanged?.Invoke(this, e);
    }

    /// <summary>
    /// Represents a control that allows the user to select and display a date.
    /// </summary>
    public class DatePicker : DateTimePickerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DatePicker"/> class.
        /// </summary>
        public DatePicker() : base()
        {
            Handle = Libui.Call<Libui.uiNewDatePicker>()();
            InitializeEvents();
        }

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
    }

    /// <summary>
    /// Represents a control that allows the user to select and display a time.
    /// </summary>
    public class TimePicker : DateTimePickerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TimePicker"/> class.
        /// </summary>
        public TimePicker() : base()
        {
            Handle = Libui.Call<Libui.uiNewTimePicker>()();
            InitializeEvents();
        }

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
    }

    /// <summary>
    /// Represents a control that allows the user to select and display a date and time.
    /// </summary>
    public class DateTimePicker : DateTimePickerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DateTimePicker"/> class.
        /// </summary>
        public DateTimePicker() : base()
        {
            Handle = Libui.Call<Libui.uiNewDateTimePicker>()();
            InitializeEvents();
        }

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
    }

    [NativeType("tm")]
    [Serializable]
    [StructLayout(Libui.StructLayout)]
    internal class UIDateTime
    {
#pragma warning disable IDE0032 // Use auto property
#pragma warning disable IDE0044 // Add readonly modifier
        private int sec, min, hour, day, mon, year;
        private readonly int wday, yday; // Must be uninitialized.
        private readonly int isdst = -1; //Must be -1.
#pragma warning restore IDE0032 // Use auto property
#pragma warning restore IDE0044 // Add readonly modifier

        public UIDateTime(int year, int month, int day, int hour, int minute, int second)
        {
            sec = second;
            min = minute;
            this.hour = hour;
            this.day = day;
            mon = month;
            this.year = year;
        }

        public int Second
        {
            get => sec;
            set => sec = value;
        }

        public int Minute
        {
            get => min;
            set => min = value;
        }

        public int Hour
        {
            get => hour;
            set => hour = value;
        }

        public int Day
        {
            get => day;
            set => day = value;
        }

        public int Month
        {
            get => mon;
            set => mon = value;
        }

        public int Year
        {
            get => year;
            set => year = value;
        }

        public static DateTime ToDateTime(UIDateTime dt) => new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second);
        public static UIDateTime FromDateTime(DateTime dt) => new UIDateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second);
    }
}