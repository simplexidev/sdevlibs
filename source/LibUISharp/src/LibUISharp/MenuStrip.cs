using System;
using System.Collections.Generic;
using LibUISharp.Internal;
using static LibUISharp.Internal.LibUI;

namespace LibUISharp
{
    // uiMenu
    public class MenuStrip : Control
    {
        public MenuStrip(string name)
        {
            Handle = uiNewMenu(name);
            Name = name;
            Items = new List<MenuStripItem>();
        }

        public List<MenuStripItem> Items { get; }
        public string Name { get; }

        public void AddItem(string name, Action<IntPtr> click = null)
        {
            MenuStripItem item = new MenuStripItem(uiMenuAppendItem(Handle, name));

            if (click != null)
            {
                item.Click += (sender, args) =>
                {
                    if (args != null)
                        click(args.Data);
                };
            }
            Items.Add(item);
        }

        public void AddCheckItem(string name, Action<IntPtr> click = null)
        {
            MenuStripCheckItem item = new MenuStripCheckItem(uiMenuAppendCheckItem(Handle, name));

            if (click != null)
            {
                item.Click += (sender, args) =>
                {
                    if (args != null)
                        click(args.Data);
                };
            }
            Items.Add(item);
        }

        public void AddPreferencesItem(Action<IntPtr> click = null)
        {
            MenuStripPreferencesItem item = new MenuStripPreferencesItem(uiMenuAppendPreferencesItem(Handle));

            if (click != null)
            {
                item.Click += (sender, args) =>
                {
                    if (args != null)
                        click(args.Data);
                };
            }
            Items.Add(item);
        }

        public void AddAboutItem(Action<IntPtr> click = null)
        {
            MenuStripAboutItem item = new MenuStripAboutItem(uiMenuAppendAboutItem(Handle));

            if (click != null)
            {
                item.Click += (sender, args) =>
                {
                    if (args != null)
                        click(args.Data);
                };
            }
            Items.Add(item);
        }

        public void AddQuitItem(Action<IntPtr> click = null)
        {
            MenuStripQuitItem item = new MenuStripQuitItem(uiMenuAppendQuitItem(Handle));
            Items.Add(item);
        }

        public void AddSeparator() => uiMenuAppendSeparator(Handle);
    }

    // uiMenuItem
    public class MenuStripItem : Control
    {
        private bool enabled;

        internal MenuStripItem(ControlSafeHandle handle)
        {
            Handle = handle;
            InitializeEvents();
        }

        public virtual event EventHandler<DataEventArgs> Click;

        public override bool Enabled
        {
            get => enabled;
            set
            {
                if (enabled == value) return;
                if (value)
                    uiMenuItemEnable(Handle);
                else
                    uiMenuItemDisable(Handle);
                enabled = value;
            }
        }

        protected override void InitializeEvents() => uiMenuItemOnClicked(Handle, (item, window, data) => { OnClick(new DataEventArgs(window)); });

        protected virtual void OnClick(DataEventArgs e) => Click?.Invoke(this, e);
    }

    public class MenuStripCheckItem : MenuStripItem
    {
        private bool isChecked;

        internal MenuStripCheckItem(ControlSafeHandle handle) : base(handle) { }

        public bool IsChecked
        {
            get => isChecked = uiMenuItemChecked(Handle);
            set
            {
                if (isChecked != value)
                {
                    uiMenuItemSetChecked(Handle, value);
                    isChecked = value;
                }
            }
        }
    }

    public class MenuStripPreferencesItem : MenuStripItem
    {
        internal MenuStripPreferencesItem(ControlSafeHandle handle) : base(handle) { }
    }

    public class MenuStripAboutItem : MenuStripItem
    {
        internal MenuStripAboutItem(ControlSafeHandle handle) : base(handle) { }
    }

    public class MenuStripQuitItem : MenuStripItem
    {
        internal MenuStripQuitItem(ControlSafeHandle handle) : base(handle) { }

        protected override void InitializeEvents() { }

        protected override void OnClick(DataEventArgs e) { }
    }
}