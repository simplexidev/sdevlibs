using System;
using LibUISharp.Drawing;
using LibUISharp.Internal;
using static LibUISharp.Internal.UI;

namespace LibUISharp
{
    public class Grid : ContainerControl<GridItemCollection, Grid>
    {
        public Grid() => Handle = new UIControlHandle(uiNewGrid());

        private bool hasPadding;
        public bool HasPadding
        {
            get => hasPadding = uiGridPadded(Handle.DangerousGetHandle());
            set
            {
                if (hasPadding != value)
                {
                    uiGridSetPadded(Handle.DangerousGetHandle(), value);
                    hasPadding = value;
                }
            }
        }
    }

    public class GridItemCollection : ControlCollection<Grid>
    {
        public GridItemCollection(Grid uiParent) : base(uiParent) { }

        public override void Add(Control item) => Add(item, 0, 0, 0, 0, 0, Alignment.Fill, 0, Alignment.Fill);

        public virtual void Add(Control item, int left, int top, int xspan, int yspan, int hexpand, Alignment halign, int vexpand, Alignment valign)
        {
            if (Contains(item)) throw new InvalidOperationException("cannot add the same control.");
            if (item == null) return;
            uiGridAppend(Owner.Handle.DangerousGetHandle(), item.Handle.DangerousGetHandle(), left, top, xspan, yspan, hexpand, halign, vexpand, valign);
            base.Add(item);
        }

        public virtual void Add(Control item, Point location, Size span, int hExpand, Alignment hAlign, int vExpand, Alignment vAlign) => Add(item, location.X, location.Y, span.Width, span.Height, hExpand, hAlign, vExpand, vAlign);

        public virtual void Insert(Control item, Control existing, RelativeAlignment at, int xspan, int yspan, int hexpand, Alignment halign, int vexpand, Alignment valign)
        {
            uiGridInsertAt(Owner.Handle.DangerousGetHandle(), item.Handle.DangerousGetHandle(), existing.Handle.DangerousGetHandle(), at, xspan, yspan, hexpand, halign, vexpand, valign);
            base.Insert(existing.Index, item);
        }

        public virtual void Insert(Control item, Control existing, RelativeAlignment edge, Size span, int hExpand, Alignment hAlign, int vExpand, Alignment vAlign) =>
            Insert(item, existing, edge, span.Width, span.Height, hExpand, hAlign, vExpand, vAlign);
    }
}