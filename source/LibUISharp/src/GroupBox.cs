using System;
using System.Runtime.InteropServices;
using LibUISharp.Internal;
using static LibUISharp.Internal.UI;

namespace LibUISharp
{
    public class GroupBox : Control
    {
        public GroupBox(string title)
        {
            IntPtr strPtr = MarshalHelper.StringToUTF8(title);
            Handle = new UIControlHandle(uiNewGroup(strPtr));
            Marshal.FreeHGlobal(strPtr);
        }
        
        public string Title
        {
            get => MarshalHelper.StringFromUTF8(uiGroupTitle(Handle.DangerousGetHandle()));
            set => uiGroupSetTitle(Handle.DangerousGetHandle(), MarshalHelper.StringToUTF8(value));
        }

        public bool AllowMargins
        {
            get => uiGroupMargined(Handle.DangerousGetHandle()); 
            set => uiGroupSetMargined(Handle.DangerousGetHandle(), value);
        }

        private Control child;
        public Control Child
        {
            get => child;
            set
            {
                if (child != value)
                {
                    if (child != null)
                        uiGroupSetChild(Handle.DangerousGetHandle(), value.Handle.DangerousGetHandle());
                    else
                        uiGroupSetChild(Handle.DangerousGetHandle(), IntPtr.Zero);
                    child = value;
                }
            }
        }

        protected new void Dispose()
        {
            if (Child != null)
            {
                Control _child = Child;
                Child = null;
                _child.Dispose(true);
            }
            base.Dispose();
        }
    }
}