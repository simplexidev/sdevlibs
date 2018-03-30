using System;
using static LibUISharp.Internal.LibUI;

namespace LibUISharp.Collections
{
    public class GridItemCollection : ControlCollection<Grid>
    {
        public GridItemCollection(Grid uiParent) : base(uiParent) { }

        public override void Add(Control item) => Add(item, 0, 0, 0, 0, 0, Alignment.Fill, 0, Alignment.Fill);

        public virtual void Add(Control item, int left, int top, int xspan, int yspan, int hexpand,
            Alignment halign, int vexpand, Alignment valign)
        {
            if (Contains(item))
                throw new InvalidOperationException("cannot add the same control.");
            if (item == null) return;
            uiGridAppend(Owner.Handle, item.Handle, left, top, xspan, yspan, hexpand, halign, vexpand, valign);
            base.Add(item);
        }

        public virtual void Insert(Control item, Control exists, RelativeAlignment at, int xspan, int yspan, int hexpand, Alignment halign, int vexpand, Alignment valign)
        {
            uiGridInsertAt(Owner.Handle, item.Handle, exists.Handle, at, xspan, yspan, hexpand, halign, vexpand, valign);
            base.Insert(exists.Index, item);
        }
    }
}