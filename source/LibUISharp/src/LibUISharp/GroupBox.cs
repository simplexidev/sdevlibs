using System;
using System.Runtime.InteropServices;
using LibUISharp.Internal;
using LibUISharp.SafeHandles;

// uiGroup
namespace LibUISharp
{
    public class GroupBox : Control
    {
        private string title;
        private bool margins;
        private Control child;

        public GroupBox(string title)
        {
            IntPtr strPtr = title.ToLibuiString();
            Handle = new SafeControlHandle(LibuiLibrary.uiNewGroup(strPtr));
            Marshal.FreeHGlobal(strPtr);
        }

        public string Title
        {
            get
            {
                title = LibuiLibrary.uiGroupTitle(Handle.DangerousGetHandle()).ToStringEx();
                return title;
            }
            set
            {
                if (title != value)
                {
                    IntPtr strPtr = value.ToLibuiString();
                    LibuiLibrary.uiGroupSetTitle(Handle.DangerousGetHandle(), strPtr);
                    Marshal.FreeHGlobal(strPtr);
                    title = value;
                }
            }
        }

        public bool Margins
        {
            get
            {
                margins = LibuiLibrary.uiGroupMargined(Handle.DangerousGetHandle());
                return margins;
            }
            set
            {
                if (margins != value)
                {
                    LibuiLibrary.uiGroupSetMargined(Handle.DangerousGetHandle(), value);
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
                    IntPtr ptr;
                    if (value.Handle.IsInvalid)
                        ptr = IntPtr.Zero;
                    else
                        ptr = value.Handle.DangerousGetHandle();

                    LibuiLibrary.uiGroupSetChild(Handle.DangerousGetHandle(), ptr);
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