using LibUISharp.Drawing;
using LibUISharp.Native;
using LibUISharp.Native.Libraries;
using LibUISharp.Native.SafeHandles;
using System;

namespace LibUISharp
{
    public class Grid : ContainerControl<Grid, GridControlCollection>
    {
        private bool padding;

        public Grid() => Handle = new SafeControlHandle(LibuiLibrary.uiNewGrid());

        public bool Padding
        {
            get
            {
                padding = LibuiLibrary.uiGridPadded(Handle.DangerousGetHandle());
                return padding;
            }
            set
            {
                if (padding != value)
                {
                    LibuiLibrary.uiGridSetPadded(Handle.DangerousGetHandle(), value);
                    padding = value;
                }
            }
        }
    }

    public class GridControlCollection : ControlCollection<Grid>
    {
        public GridControlCollection(Grid uiParent) : base(uiParent) { }

        public override void Add(Control control) => Add(control, 0, 0, 0, 0, 0, 0, Alignment.Fill);
        public virtual void Add(Control control, Rectangle rect, Size expand, Alignment alignment) => Add(control, rect.Location, rect.Size, expand, alignment);
        public virtual void Add(Control control, Point location, Size span, Size expand, Alignment alignment) => Add(control, location.X, location.Y, span.Width, span.Height, expand.Width, expand.Height, alignment);

        public virtual void Add(Control control, int left, int top, int xspan, int yspan, int hexpand, int vexpand, Alignment alignment)
        {
            if (control == null)
                throw new ArgumentNullException("control");
            if (Contains(control))
                throw new InvalidOperationException("Cannot add a Control that is already contained in this GridItemCollection.");
            LibuiConvert.ToLibuiAligns(alignment, out LibuiLibrary.uiAlign halign, out LibuiLibrary.uiAlign valign);
            LibuiLibrary.uiGridAppend(Parent.Handle.DangerousGetHandle(), control.Handle.DangerousGetHandle(), left, top, xspan, yspan, hexpand, halign, vexpand, valign);
            base.Add(control);
        }

        public virtual void Insert(Control control, Control existingControl, RelativeAlignment relativeAlignment, Size span, Size expand, Alignment alignment) => Insert(control, existingControl, relativeAlignment, span.Width, span.Height, expand.Width, expand.Height, alignment);

        public virtual void Insert(Control control, Control existingControl, RelativeAlignment relativeAlignment, int xspan, int yspan, int hexpand, int vexpand, Alignment alignment)
        {
            if (control == null)
                throw new ArgumentNullException("control");
            if (Contains(control))
                throw new InvalidOperationException("Cannot add a Control that is already contained in this GridItemCollection.");
            LibuiConvert.ToLibuiAligns(alignment, out LibuiLibrary.uiAlign halign, out LibuiLibrary.uiAlign valign);
            LibuiLibrary.uiGridInsertAt(Parent.Handle.DangerousGetHandle(), control.Handle.DangerousGetHandle(), existingControl.Handle.DangerousGetHandle(), (LibuiLibrary.uiAt)relativeAlignment, xspan, yspan, hexpand, halign, vexpand, valign);
            base.Insert(existingControl.Index, control);
        }
    }
}