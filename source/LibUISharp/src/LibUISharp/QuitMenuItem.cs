using System;

namespace LibUISharp
{
    /// <summary>
    /// Represents a about menu item in a <see cref="Menu"/>.
    /// </summary>
    public sealed class QuitMenuItem : MenuItemBase
    {
        /// <summary>
        /// Initializes a new instance of a <see cref="QuitMenuItem"/> class from the specified handle.
        /// </summary>
        /// <param name="handle">The specified handle.</param>
        internal QuitMenuItem(IntPtr handle) : base(handle) { }

        /// <summary>
        /// Initializes this UI component's events.
        /// </summary>
        protected override void InitializeEvents() { }

        /// <summary>
        /// This mehod does not do anything, and will throw a <see cref="NotSupportedException"/>.
        /// </summary>
        /// <param name="e">A <see cref="DataEventArgs"/> that contains the event data.</param>
        protected override sealed void OnClicked(DataEventArgs e) => throw new NotSupportedException();
    }
}