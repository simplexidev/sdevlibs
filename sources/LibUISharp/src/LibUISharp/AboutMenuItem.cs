using System;

namespace LibUISharp
{
    /// <summary>
    /// Represents a about menu item in a <see cref="Menu"/>.
    /// </summary>
    public sealed class AboutMenuItem : MenuItemBase
    {
        /// <summary>
        /// Initializes a new instance of a <see cref="AboutMenuItem"/> class from the specified handle.
        /// </summary>
        /// <param name="handle">The specified handle.</param>
        internal AboutMenuItem(IntPtr handle) : base(handle) { }
    }
}