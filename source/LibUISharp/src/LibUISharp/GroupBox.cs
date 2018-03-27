using System;
using LibUISharp.Internal;

using static LibUISharp.Internal.LibUI;

namespace LibUISharp
{
    public class GroupBox : Control
    {
        public GroupBox(string title) => Handle = uiNewGroup(title);

        public string Title
        {
            get => uiGroupTitle(Handle);
            set => uiGroupSetTitle(Handle, value);
        }

        public bool AllowMargins
        {
            get => uiGroupMargined(Handle);
            set => uiGroupSetMargined(Handle, value);
        }

        private Control _child;
        public Control Child
        {
            get => _child;
            set
            {
                if (_child != value)
                {
                    uiGroupSetChild(Handle, value?.Handle ?? new ControlSafeHandle(IntPtr.Zero));
                    _child = value;
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