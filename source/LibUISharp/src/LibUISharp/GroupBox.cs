using System;
using LibUISharp.Internal;
using static LibUISharp.Internal.LibUI;

namespace LibUISharp
{
    // uiGroup
    public class GroupBox : Control
    {
        private string title;
        private bool margins;
        private Control child;

        public GroupBox(string title) => Handle = uiNewGroup(title);

        public string Title
        {
            get
            {
                title = uiGroupTitle(Handle);
                return title;
            }
            set
            {
                if (title != value)
                {
                    uiGroupSetTitle(Handle, value);
                    title = value;
                }
            }
        }

        public bool Margins
        {
            get
            {
                margins = uiGroupMargined(Handle);
                return margins;
            }
            set
            {
                if (margins != value)
                {
                    uiGroupSetMargined(Handle, value);
                    margins = value;
                }
            }
        }
        
        public Control Child
        {
            get => child;
            set
            {
                if (child != value)
                {
                    uiGroupSetChild(Handle, value?.Handle ?? new ControlSafeHandle(IntPtr.Zero));
                    child = value;
                }
            }
        }

        protected override void Destroy()
        {
            if (Child != null)
            {
                Control child = Child;
                Child = null;
                child.Dispose();
            }
            base.Destroy();
        }
    }
}