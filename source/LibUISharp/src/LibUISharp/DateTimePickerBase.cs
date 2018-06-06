using System;
using static LibUISharp.Native.NativeMethods;

namespace LibUISharp
{
    /// <summary>
    /// Implements the basic functonality required by a date-time picker.
    /// </summary>
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
                Libui.uiDateTimePickerTime(this, out Libui.tm time);
                dateTime = ToDateTime(time);
                return dateTime;
            }
            set
            {
                if (dateTime != value)
                {
                    Libui.uiDateTimePickerSetTime(this, ToTmStruct(value));
                    dateTime = value;
                }
            }
        }

        /// <summary>
        /// Initializes this UI component's events.
        /// </summary>
        protected sealed override void InitializeEvents() => Libui.uiDateTimePickerOnChanged(this, (d, data) => { OnDateTimeChanged(EventArgs.Empty); }, IntPtr.Zero);

        /// <summary>
        /// Called when the <see cref="DateTimeChanged"/> event is raised.
        /// </summary>
        protected virtual void OnDateTimeChanged(EventArgs e) => DateTimeChanged?.Invoke(this, e);

        private static Libui.tm ToTmStruct(DateTime dt) => new Libui.tm()
        {
            tm_isdst = -1,
            tm_hour = dt.Hour,
            tm_min = dt.Minute,
            tm_sec = dt.Second,
            tm_mday = dt.Day,
            tm_mon = dt.Month,
            tm_year = dt.Year
        };

        internal static DateTime ToDateTime(Libui.tm dt) => new DateTime(dt.tm_year, dt.tm_mon, dt.tm_mday, dt.tm_hour, dt.tm_min, dt.tm_sec);
    }
}