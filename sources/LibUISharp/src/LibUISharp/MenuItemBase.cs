using System;
using static LibUISharp.Native.NativeMethods;

namespace LibUISharp
{
    /// <summary>
    /// Represents a base implementation for a menu item contained in a <see cref="Menu"/>.
    /// </summary>
    public abstract class MenuItemBase : Control
    {
        private bool enabled;

        /// <summary>
        /// Initializes a new instance of a <see cref="MenuItemBase"/> class from the specified handle.
        /// </summary>
        /// <param name="handle">The specified handle.</param>
        internal MenuItemBase(IntPtr handle)
        {
            Handle = handle;
            InitializeEvents();
        }

        /// <summary>
        /// Occurs when the menu item is clicked.
        /// </summary>
        public virtual event EventHandler<DataEventArgs> Clicked;
        
        /// <summary>
        /// Gets or sets a value indicating whether the control can respond to interaction.
        /// </summary>
        public override bool Enabled
        {
            get => enabled;
            set
            {
                if (enabled == value) return;
                if (value) Enable();
                else Disable();
                enabled = value;
            }
        }

        /// <summary>
        /// Enables this control to accept user-interaction.
        /// </summary>
        public override void Enable()
        {
            if (!enabled)
            {
                Libui.uiMenuItemEnable(this);
                enabled = true;
            }
        }

        /// <summary>
        /// Disables the control from accepting user-interaction.
        /// </summary>
        public override void Disable()
        {
            if (enabled)
            {
                Libui.uiMenuItemDisable(this);
                enabled = false;
            }
        }

        /// <summary>
        /// Initializes this UI component's events.
        /// </summary>
        protected override void InitializeEvents() => Libui.uiMenuItemOnClicked(this, (item, window, data) => { OnClicked(new DataEventArgs(window)); }, IntPtr.Zero);

        /// <summary>
        /// Called when the <see cref="Clicked"/> event is raised.
        /// </summary>
        /// <param name="e">A <see cref="DataEventArgs"/> that contains the event data.</param>
        protected virtual void OnClicked(DataEventArgs e) => Clicked?.Invoke(this, e);
    }
}