using System;

namespace LibUISharp
{
    /// <summary>
    /// Represents a basic item in a <see cref="Menu"/>.
    /// </summary>
    public sealed class MenuItem : MenuItemBase
    {
        /// <summary>
        /// Initializes a new instance of a <see cref="MenuItem"/> class from the specified handle with the specified name.
        /// </summary>
        /// <param name="handle">The specified handle.</param>
        /// <param name="name">The menu item's name.</param>
        internal MenuItem(IntPtr handle, string name) : base(handle) => Name = name;

        /// <summary>
        /// Gets this menu item's name.
        /// </summary>
        public string Name { get; }
    }
}