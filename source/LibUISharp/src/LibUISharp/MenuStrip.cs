using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using LibUISharp.Internal;
using LibUISharp.SafeHandles;

namespace LibUISharp
{
    // uiMenu
    public class MenuStrip : Control
    {
        public MenuStrip(string name)
        {
            IntPtr strPtr = name.ToLibuiString();
            Handle = new SafeControlHandle(LibuiLibrary.uiNewMenu(strPtr));
            Marshal.FreeHGlobal(strPtr);
            Name = name;
            Items = new List<MenuStripItem>();
        }

        public List<MenuStripItem> Items { get; }
        public string Name { get; }

        public void AddItem(string name, Action<IntPtr> click = null)
        {
            IntPtr strPtr = name.ToLibuiString();
            MenuStripItem item = new MenuStripItem(LibuiLibrary.uiMenuAppendItem(Handle.DangerousGetHandle(), strPtr));
            Marshal.FreeHGlobal(strPtr);

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
            IntPtr strPtr = name.ToLibuiString();
            MenuStripCheckItem item = new MenuStripCheckItem(LibuiLibrary.uiMenuAppendCheckItem(Handle.DangerousGetHandle(), strPtr));
            Marshal.FreeHGlobal(strPtr);

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
            MenuStripPreferencesItem item = new MenuStripPreferencesItem(LibuiLibrary.uiMenuAppendPreferencesItem(Handle.DangerousGetHandle()));

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
            MenuStripAboutItem item = new MenuStripAboutItem(LibuiLibrary.uiMenuAppendAboutItem(Handle.DangerousGetHandle()));

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
            MenuStripQuitItem item = new MenuStripQuitItem(LibuiLibrary.uiMenuAppendQuitItem(Handle.DangerousGetHandle()));
            Items.Add(item);
        }

        public void AddSeparator() => LibuiLibrary.uiMenuAppendSeparator(Handle.DangerousGetHandle());
    }

    // uiMenuItem
    public class MenuStripItem : Control
    {
        private bool enabled;

        internal MenuStripItem(IntPtr handle)
        {
            Handle = new SafeControlHandle(handle);
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
                    LibuiLibrary.uiMenuItemEnable(Handle.DangerousGetHandle());
                else
                    LibuiLibrary.uiMenuItemDisable(Handle.DangerousGetHandle());
                enabled = value;
            }
        }

        protected override void InitializeEvents() => LibuiLibrary.uiMenuItemOnClicked(Handle.DangerousGetHandle(), (item, window, data) => { OnClick(new DataEventArgs(window)); }, IntPtr.Zero);

        protected virtual void OnClick(DataEventArgs e) => Click?.Invoke(this, e);
    }

    public class MenuStripCheckItem : MenuStripItem
    {
        private bool isChecked;

        internal MenuStripCheckItem(IntPtr handle) : base(handle) { }

        public bool IsChecked
        {
            get => isChecked = LibuiLibrary.uiMenuItemChecked(Handle.DangerousGetHandle());
            set
            {
                if (isChecked != value)
                {
                    LibuiLibrary.uiMenuItemSetChecked(Handle.DangerousGetHandle(), value);
                    isChecked = value;
                }
            }
        }
    }

    public class MenuStripPreferencesItem : MenuStripItem
    {
        internal MenuStripPreferencesItem(IntPtr handle) : base(handle) { }
    }

    public class MenuStripAboutItem : MenuStripItem
    {
        internal MenuStripAboutItem(IntPtr handle) : base(handle) { }
    }

    public class MenuStripQuitItem : MenuStripItem
    {
        internal MenuStripQuitItem(IntPtr handle) : base(handle) { }

        protected override void InitializeEvents() { }

        protected override sealed void OnClick(DataEventArgs e) { }
    }
}