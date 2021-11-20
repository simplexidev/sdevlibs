using System;
using static LibUISharp.Native.NativeMethods;

namespace LibUISharp
{
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
            Handle = Libui.uiNewDateTimePicker();
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
}