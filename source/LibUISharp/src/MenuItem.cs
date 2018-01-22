using System;
using System.Runtime.InteropServices;
using LibUISharp.Internal;
using static LibUISharp.Internal.UI;

namespace LibUISharp
{
    public class MenuItem : Control
    {

        public MenuItem(string name)
        {
            IntPtr strPtr = MarshalHelper.StringToUTF8(name);
            if (!(Parent is Menu)) throw new InvalidOperationException("MenuItems can only be created by a Menu.");
            if (this is QuitMenuItem)
                Handle = new UIControlHandle(uiMenuAppendQuitItem(Parent.Handle.DangerousGetHandle()));
            else if (this is PreferencesMenuItem)
                Handle = new UIControlHandle(uiMenuAppendPreferencesItem(Parent.Handle.DangerousGetHandle()));
            else if (this is AboutMenuItem)
                Handle = new UIControlHandle(uiMenuAppendAboutItem(Parent.Handle.DangerousGetHandle()));
            else if (this is CheckableMenuItem)
            {
                Name = name ?? throw new ArgumentNullException("name");
                Handle = new UIControlHandle(uiMenuAppendCheckItem(Parent.Handle.DangerousGetHandle(), strPtr));
            } else
            {
                Name = name ?? throw new ArgumentNullException("name");
                Handle = new UIControlHandle(uiMenuAppendItem(Parent.Handle.DangerousGetHandle(), strPtr));
            }
            Marshal.FreeHGlobal(strPtr);
            Initialize();
        }

        public string Name { get; private set; }

        private bool enabled = true;
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

        private bool isChecked;
        public bool IsChecked
        {
            get
            {
                if (this is CheckableMenuItem)
                    isChecked = uiMenuItemChecked(Handle.DangerousGetHandle());
                return isChecked;
            }
            set
            {
                if (isChecked != value && this is CheckableMenuItem)
                {
                    uiMenuItemSetChecked(Handle.DangerousGetHandle(), value);
                    isChecked = value;
                }
            }
        }

        protected sealed override void Initialize()
        {
            if (!(this is QuitMenuItem))
                uiMenuItemOnClicked(Handle.DangerousGetHandle(), (item, window, data) => { OnClick(new DataEventArgs(window)); }, IntPtr.Zero);
        }

        public override void Enable() => uiMenuItemEnable(Handle.DangerousGetHandle());
        public override void Disable() => uiMenuItemDisable(Handle.DangerousGetHandle());

        public event EventHandler<DataEventArgs> Click;
        protected virtual void OnClick(DataEventArgs e) => Click?.Invoke(this, e);
    }

    public class CheckableMenuItem : MenuItem
    {
        public CheckableMenuItem(string name) : base(name) { }
    }

    public class QuitMenuItem : MenuItem
    {
        public QuitMenuItem() : base(null) { }
    }

    public class PreferencesMenuItem : MenuItem
    {
        public PreferencesMenuItem() : base(null) { }
    }
    
    public class AboutMenuItem : MenuItem
    {
        public AboutMenuItem() : base(null) { }
    }
}