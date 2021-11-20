using System;
using static LibUISharp.Native.NativeMethods;

namespace LibUISharp
{
    /// <summary>
    /// Represents a checkable menu item in a <see cref="Menu"/>.
    /// </summary>
    public sealed class CheckMenuItem : MenuItemBase
    {
        private bool @checked;

        /// <summary>
        /// Initializes a new instance of a <see cref="CheckMenuItem"/> class from the specified handle with the specified name.
        /// </summary>
        /// <param name="handle">The specified handle.</param>
        /// <param name="name">The menu item's name.</param>
        internal CheckMenuItem(IntPtr handle, string name) : base(handle) => Name = name;

        /// <summary>
        /// Gets or sets the state of this <see cref="CheckMenuItem"/>.
        /// </summary>
        public bool Checked
        {
            get => @checked = Libui.uiMenuItemChecked(this);
            set
            {
                if (@checked != value)
                {
                    Libui.uiMenuItemSetChecked(this, value);
                    @checked = value;
                }
            }
        }

        /// <summary>
        /// Gets this menu item's name.
        /// </summary>
        public string Name { get; }
    }
}