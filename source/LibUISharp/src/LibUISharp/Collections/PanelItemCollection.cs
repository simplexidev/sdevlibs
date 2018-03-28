using System;
using static LibUISharp.Internal.LibUI;

namespace LibUISharp.Collections
{
    public class PanelItemCollection : ControlCollection<Panel>
    {
        public PanelItemCollection(Panel uiParent) : base(uiParent) { }

        public override bool Remove(Control item)
        {
            uiBoxDelete(Owner.Handle, item.Index);
            return base.Remove(item);
        }

        public override void Add(Control child) => Add(child, false);

        public virtual void Add(Control child, bool stretches)
        {
            if (Contains(child))
                throw new InvalidOperationException("cannot add the same control.");
            if(child == null) return;
            uiBoxAppend(Owner.Handle, child.Handle, stretches);
            base.Add(child);
        }
    }
}