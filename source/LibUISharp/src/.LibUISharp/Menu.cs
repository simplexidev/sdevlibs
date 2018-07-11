using LibUISharp.Internal;
using System;
using System.Collections.Generic;
using static LibUISharp.Internal.Libraries;

namespace LibUISharp
{
    public enum MenuItemType
    {
        Basic,
        Checkable,
        Preferences,
        About,
        Quit,
        Separator
    }

    /// <summary>
    /// Represents a menu control that enables you to hierarchically organize elements associated with commands and event handlers.
    /// </summary>
    [LibuiType("uiMenu")]
    public class Menu : MultiContainer<Menu, Menu.ControlCollection, MenuItemBase>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Menu"/> class with the specified name.
        /// </summary>
        /// <param name="name">The specified name.</param>
        public Menu(string name)
        {
            Handle = Libui.Call<Libui.uiNewMenu>()(name);
            Name = name;
        }

        /// <summary>
        /// Gets the name of this <see cref="Menu"/>.
        /// </summary>
        public string Name { get; }
        
        /// <summary>
        /// Represents a collection of child <see cref="Control"/>s inside of a <see cref="StackContainer"/>.
        /// </summary>
        public new class ControlCollection : MultiContainer<Menu, ControlCollection, MenuItemBase>.ControlCollection
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="ControlCollection"/> class with the specified parent.
            /// </summary>
            /// <param name="owner">The parent <see cref="StackContainer"/> of this <see cref="ControlCollection"/>.</param>
            public ControlCollection(Menu owner) : base(owner) { }

            /// <summary>
            /// Adds a <see cref="Control"/> to the end of the <see cref="ControlCollection"/>.
            /// </summary>
            /// <param name="child">The <see cref="Control"/> to be added to the end of the <see cref="ControlCollection"/>.</param>
            public override void Add(MenuItemBase child)
            {
                if (Contains(child)) throw new InvalidOperationException("Cannot add the same control more than once.");
                if (child == null) return;

                if (child is MenuItem)
                {
                    MenuItem c = child as MenuItem;
                    Libui.Call<Libui.uiMenuAppendItem>()(Owner, c.Name);
                }
                else if (child is CheckMenuItem)
                {
                    CheckMenuItem c = child as CheckMenuItem;
                    Libui.Call<Libui.uiMenuAppendCheckItem>()(Owner, c.Name);
                }
                else if (child is PreferencesMenuItem)
                {
                    PreferencesMenuItem c = child as PreferencesMenuItem;
                    Libui.Call<Libui.uiMenuAppendPreferencesItem>()(Owner);
                }
                else if (child is AboutMenuItem)
                {
                    AboutMenuItem c = child as AboutMenuItem;
                    Libui.Call<Libui.uiMenuAppendAboutItem>()(Owner);
                }
                else if (child is QuitMenuItem)
                {
                    QuitMenuItem c = child as QuitMenuItem;
                    Libui.Call<Libui.uiMenuAppendQuitItem>()(Owner);
                }
                base.Add(child);
            }

            /// <summary>
            /// <see cref="ControlCollection"/> does not support this method, and will throw a <see cref="NotSupportedException"/>.
            /// </summary>
            /// <param name="index">The zero-based index at which child should be inserted.</param>
            /// <param name="child">The <see cref="Control"/> to insert into the <see cref="ControlCollection"/>.</param>
            public override void AddAt(int index, MenuItemBase child) => throw new NotSupportedException();

            /// <summary>
            /// <see cref="ControlCollection"/> does not support this method, and will throw a <see cref="NotSupportedException"/>.
            /// </summary>
            /// <param name="child">The <see cref="Control"/> to remove from the <see cref="ControlCollection"/>.</param>
            /// <returns>true if child is successfully removed; otherwise, false. This method also returns false if child was not found in the <see cref="ControlCollection"/>.</returns>
            public override bool Remove(MenuItemBase child) => throw new NotSupportedException();
        }

        /// <summary>
        /// Adds a new <see cref="PreferencesMenuItem"/> to the list.
        /// </summary>
        /// <param name="click">The action invoked when the child is clicked.</param>
        public void AddPreferencesItem(Action<IntPtr> click = null)
        {
            PreferencesMenuItem child = new PreferencesMenuItem(Libui.Call<Libui.uiMenuAppendPreferencesItem>()(this));

            if (click != null)
            {
                child.Clicked += (sender, args) =>
                {
                    if (args != null)
                        click(args.Data);
                };
            }
            Items.Add(child);
        }

        /// <summary>
        /// Adds a new <see cref="AboutMenuItem"/> to the list.
        /// </summary>
        /// <param name="click">The action invoked when the child is clicked.</param>
        public void AddAboutItem(Action<IntPtr> click = null)
        {
            AboutMenuItem child = new AboutMenuItem(Libui.Call<Libui.uiMenuAppendAboutItem>()(this));

            if (click != null)
            {
                child.Clicked += (sender, args) =>
                {
                    if (args != null)
                        click(args.Data);
                };
            }
            Items.Add(child);
        }

        /// <summary>
        /// Adds a new <see cref="QuitMenuItem"/> to the list.
        /// </summary>
        public void AddQuitItem()
        {
            QuitMenuItem child = new QuitMenuItem(Libui.Call<Libui.uiMenuAppendQuitItem>()(this));
            Items.Add(child);
        }

        /// <summary>
        /// Adds a new separator child to the list.
        /// </summary>
        public void AddSeparator() => Libui.Call<Libui.uiMenuAppendSeparator>()(this);
    }

    /// <summary>
    /// Represents a base implementation for a menu child contained in a <see cref="Menu"/>.
    /// </summary>
    [LibuiType("uiMenuItem")]
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
        /// Occurs when the menu child is clicked.
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
                Libui.Call<Libui.uiMenuItemEnable>()(this);
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
                Libui.Call<Libui.uiMenuItemDisable>()(this);
                enabled = false;
            }
        }

        /// <summary>
        /// Initializes this UI component's events.
        /// </summary>
        protected override void InitializeEvents() => Libui.Call<Libui.uiMenuItemOnClicked>()(this, (child, window, data) => { OnClicked(new DataEventArgs(window)); }, IntPtr.Zero);

        /// <summary>
        /// Called when the <see cref="Clicked"/> event is raised.
        /// </summary>
        /// <param name="e">A <see cref="DataEventArgs"/> that contains the event data.</param>
        protected virtual void OnClicked(DataEventArgs e) => Clicked?.Invoke(this, e);
    }

    /// <summary>
    /// Represents a basic child in a <see cref="Menu"/>.
    /// </summary>
    public sealed class MenuItem : MenuItemBase
    {
        /// <summary>
        /// Initializes a new instance of a <see cref="MenuItem"/> class from the specified handle with the specified name.
        /// </summary>
        /// <param name="handle">The specified handle.</param>
        /// <param name="name">The menu child's name.</param>
        internal MenuItem(IntPtr handle, string name) : base(handle) => Name = name;

        /// <summary>
        /// Gets this menu child's name.
        /// </summary>
        public string Name { get; }
    }

    /// <summary>
    /// Represents a checkable menu child in a <see cref="Menu"/>.
    /// </summary>
    public sealed class CheckMenuItem : MenuItemBase
    {
        private bool @checked;

        /// <summary>
        /// Initializes a new instance of a <see cref="CheckMenuItem"/> class from the specified handle with the specified name.
        /// </summary>
        /// <param name="handle">The specified handle.</param>
        /// <param name="name">The menu child's name.</param>
        internal CheckMenuItem(IntPtr handle, string name) : base(handle) => Name = name;

        /// <summary>
        /// Gets or sets the state of this <see cref="CheckMenuItem"/>.
        /// </summary>
        public bool Checked
        {
            get => @checked = Libui.Call<Libui.uiMenuItemChecked>()(this);
            set
            {
                if (@checked != value)
                {
                    Libui.Call<Libui.uiMenuItemSetChecked>()(this, value);
                    @checked = value;
                }
            }
        }

        /// <summary>
        /// Gets this menu child's name.
        /// </summary>
        public string Name { get; }
    }

    /// <summary>
    /// Represents a about menu child in a <see cref="Menu"/>.
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

    /// <summary>
    /// Represents a preferences menu child in a <see cref="Menu"/>.
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
    /// Represents a about menu child in a <see cref="Menu"/>.
    /// </summary>
    public sealed class AboutMenuItem : MenuItemBase
    {
        internal AboutMenuItem(IntPtr handle) : base(handle) { }
    }
}