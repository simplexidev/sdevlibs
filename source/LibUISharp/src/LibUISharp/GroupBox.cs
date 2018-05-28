using System;
using System.Runtime.InteropServices;
using LibUISharp.Internal;
using LibUISharp.SafeHandles;

namespace LibUISharp
{
    /// <summary>
    /// Represents a control that creates a container that has a border and a title for user-interface (UI) content.
    /// </summary>
    public class GroupBox : Control
    {
        private string title;
        private bool margins;
        private Control child;

        /// <summary>
        /// Initializes a new instance of the <see cref="GroupBox"/> class with the specified title.
        /// </summary>
        /// <param name="title"></param>
        public GroupBox(string title)
        {
            IntPtr strPtr = title.ToLibuiString();
            Handle = new SafeControlHandle(LibuiLibrary.uiNewGroup(strPtr));
            Marshal.FreeHGlobal(strPtr);
        }

        /// <summary>
        /// Gets or sets the title for this <see cref="GroupBox"/> control.
        /// </summary>
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

        /// <summary>
        /// Gets or sets a value indicating whether or not this <see cref="TabPage"/> has outer margins.
        /// </summary>
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

        /// <summary>
        /// Gets or sets this <see cref="GroupBox"/> object's child <see cref="Control"/>.
        /// </summary>
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

        /// <summary>
        /// Runs cleanup operations and destroys the control.
        /// </summary>
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