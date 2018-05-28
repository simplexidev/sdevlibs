using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using LibUISharp.Internal;
using LibUISharp.SafeHandles;

namespace LibUISharp
{
    /// <summary>
    /// Represents a menu control that enables you to hierarchically organize elements associated with commands and event handlers.
    /// </summary>
    public class Menu : Control
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Menu"/> class with the specified name.
        /// </summary>
        /// <param name="name">The specified name.</param>
        public Menu(string name)
        {
            IntPtr strPtr = name.ToLibuiString();
            Handle = new SafeControlHandle(LibuiLibrary.uiNewMenu(strPtr));
            Marshal.FreeHGlobal(strPtr);
            Name = name;
            Items = new List<MenuItemBase>();
        }

        /// <summary>
        /// Gets the list of menu items contained in this <see cref="Menu"/>.
        /// </summary>
        public List<MenuItemBase> Items { get; }

        /// <summary>
        /// Gets the name of this <see cref="Menu"/>.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Adds a new <see cref="MenuItem"/> to the list.
        /// </summary>
        /// <param name="name">The name of the item.</param>
        /// <param name="click">The action invoked when the item is clicked.</param>
        public void AddItem(string name, Action<IntPtr> click = null)
        {
            IntPtr strPtr = name.ToLibuiString();
            MenuItem item = new MenuItem(LibuiLibrary.uiMenuAppendItem(Handle.DangerousGetHandle(), strPtr), name);
            Marshal.FreeHGlobal(strPtr);

            if (click != null)
            {
                item.Clicked += (sender, args) =>
                {
                    if (args != null)
                        click(args.Data);
                };
            }
            Items.Add(item);
        }

        /// <summary>
        /// Adds a new <see cref="CheckMenuItem"/> to the list.
        /// </summary>
        /// <param name="name">The name of the item.</param>
        /// <param name="click">The action invoked when the item is clicked.</param>
        public void AddCheckItem(string name, Action<IntPtr> click = null)
        {
            IntPtr strPtr = name.ToLibuiString();
            CheckMenuItem item = new CheckMenuItem(LibuiLibrary.uiMenuAppendCheckItem(Handle.DangerousGetHandle(), strPtr), name);
            Marshal.FreeHGlobal(strPtr);

            if (click != null)
            {
                item.Clicked += (sender, args) =>
                {
                    if (args != null)
                        click(args.Data);
                };
            }
            Items.Add(item);
        }

        /// <summary>
        /// Adds a new <see cref="PreferencesMenuItem"/> to the list.
        /// </summary>
        /// <param name="click">The action invoked when the item is clicked.</param>
        public void AddPreferencesItem(Action<IntPtr> click = null)
        {
            PreferencesMenuItem item = new PreferencesMenuItem(LibuiLibrary.uiMenuAppendPreferencesItem(Handle.DangerousGetHandle()));

            if (click != null)
            {
                item.Clicked += (sender, args) =>
                {
                    if (args != null)
                        click(args.Data);
                };
            }
            Items.Add(item);
        }

        /// <summary>
        /// Adds a new <see cref="AboutMenuItem"/> to the list.
        /// </summary>
        /// <param name="click">The action invoked when the item is clicked.</param>
        public void AddAboutItem(Action<IntPtr> click = null)
        {
            AboutMenuItem item = new AboutMenuItem(LibuiLibrary.uiMenuAppendAboutItem(Handle.DangerousGetHandle()));

            if (click != null)
            {
                item.Clicked += (sender, args) =>
                {
                    if (args != null)
                        click(args.Data);
                };
            }
            Items.Add(item);
        }

        /// <summary>
        /// Adds a new <see cref="QuitMenuItem"/> to the list.
        /// </summary>
        public void AddQuitItem()
        {
            QuitMenuItem item = new QuitMenuItem(LibuiLibrary.uiMenuAppendQuitItem(Handle.DangerousGetHandle()));
            Items.Add(item);
        }

        /// <summary>
        /// Adds a new separator item to the list.
        /// </summary>
        public void AddSeparator() => LibuiLibrary.uiMenuAppendSeparator(Handle.DangerousGetHandle());
    }

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
            Handle = new SafeControlHandle(handle);
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
                if (value)
                    LibuiLibrary.uiMenuItemEnable(Handle.DangerousGetHandle());
                else
                    LibuiLibrary.uiMenuItemDisable(Handle.DangerousGetHandle());
                enabled = value;
            }
        }

        /// <summary>
        /// Initializes this UI component's events.
        /// </summary>
        protected override void InitializeEvents() => LibuiLibrary.uiMenuItemOnClicked(Handle.DangerousGetHandle(), (item, window, data) => { OnClicked(new DataEventArgs(window)); }, IntPtr.Zero);

        /// <summary>
        /// Called when the <see cref="Clicked"/> event is raised.
        /// </summary>
        /// <param name="e">A <see cref="DataEventArgs"/> that contains the event data.</param>
        protected virtual void OnClicked(DataEventArgs e) => Clicked?.Invoke(this, e);
    }

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
            get => @checked = LibuiLibrary.uiMenuItemChecked(Handle.DangerousGetHandle());
            set
            {
                if (@checked != value)
                {
                    LibuiLibrary.uiMenuItemSetChecked(Handle.DangerousGetHandle(), value);
                    @checked = value;
                }
            }
        }

        /// <summary>
        /// Gets this menu item's name.
        /// </summary>
        public string Name { get; }
    }

    /// <summary>
    /// Represents a preferences menu item in a <see cref="Menu"/>.
    /// </summary>
    public sealed class PreferencesMenuItem : MenuItemBase
    {
        /// <summary>
        /// Initializes a new instance of a <see cref="PreferencesMenuItem"/> class from the specified handle.
        /// </summary>
        /// <param name="handle">The specified handle.</param>
        internal PreferencesMenuItem(IntPtr handle) : base(handle) { }
    }

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