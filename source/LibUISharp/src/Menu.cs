using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using LibUISharp.Internal;
using static LibUISharp.Internal.UI;

namespace LibUISharp
{
    public class Menu : Control
    {
        public Menu(string name)
        {
            IntPtr strPtr = MarshalHelper.StringToUTF8(name);
            Handle = new UIControlHandle(uiNewMenu(strPtr));
            Items = new List<MenuItem>();
            Marshal.FreeHGlobal(strPtr);
        }

        public List<MenuItem> Items { get; }

        private void Add(MenuItem menuItem, Action<IntPtr> click = null)
        {
            if (click != null)
            {
                menuItem.Click += (sender, args) =>
                {
                    if (args != null)
                        click(args.Data);
                };
            }
            Items.Add(menuItem);
        }

        public void AddItem(string name, Action<IntPtr> click = null)
        {
            MenuItem item = new MenuItem(name);
            Add(item, click);
        }

        public void AddCheckableItem(string name, Action<IntPtr> click = null)
        {
            CheckableMenuItem item = new CheckableMenuItem(name);
            Add(item, click);
        }

        public void AddQuitItem(Action<IntPtr> click = null)
        {
            QuitMenuItem item = new QuitMenuItem();
            Add(item, click);
        }

        public void AddPreferencesItem(Action<IntPtr> click = null)
        {
            PreferencesMenuItem item = new PreferencesMenuItem();
            Add(item, click);
        }

        public void AddAboutItem(Action<IntPtr> click = null)
        {
            AboutMenuItem item = new AboutMenuItem();
            Add(item, click);
        }

        public void AddSeparator() => uiMenuAppendSeparator(Handle.DangerousGetHandle());
    }
}