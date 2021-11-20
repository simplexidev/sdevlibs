using System;
using System.Collections.Generic;
using static LibUISharp.Native.NativeMethods;

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
            Handle = Libui.uiNewMenu(name);
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
            MenuItem item = new MenuItem(Libui.uiMenuAppendItem(this, name), name);

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
            CheckMenuItem item = new CheckMenuItem(Libui.uiMenuAppendCheckItem(this, name), name);

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
            PreferencesMenuItem item = new PreferencesMenuItem(Libui.uiMenuAppendPreferencesItem(this));

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
            AboutMenuItem item = new AboutMenuItem(Libui.uiMenuAppendAboutItem(this));

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
            QuitMenuItem item = new QuitMenuItem(Libui.uiMenuAppendQuitItem(this));
            Items.Add(item);
        }

        /// <summary>
        /// Adds a new separator item to the list.
        /// </summary>
        public void AddSeparator() => Libui.uiMenuAppendSeparator(this);
    }
}