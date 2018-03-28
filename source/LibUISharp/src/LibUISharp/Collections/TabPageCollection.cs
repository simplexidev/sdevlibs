using System;
using static LibUISharp.Internal.LibUI;

namespace LibUISharp.Collections
{
    public class TabPageCollection : ControlCollection<TabControl>
    {
        public TabPageCollection(TabControl parent) : base(parent) { }

        public override void Add(Control child)
        {
            if (!(child is TabPage))
                throw new ArgumentException("You can only add a TabPage to a TabControl.");
            TabPage c = child as TabPage;
            if (child == null)
                throw new ArgumentException("You cannot add a null TabPage to a TabControl.");
            base.Add(c);
            uiTabAppend(Owner.Handle, c.Name, c.Handle);
            c.DelayRender();
        }

        public override void Insert(int i, Control child)
        {
            if (!(child is TabPage))
                throw new ArgumentException("You can only add a TabPage to a TabControl.");
            TabPage c = child as TabPage;
            if (child == null)
                throw new ArgumentException("You cannot add a null TabPage to a TabControl.");
            base.Insert(i, child);
            uiTabInsertAt(Owner.Handle, c.Name, i, c.Handle);
            c.DelayRender();
        }

        public override bool Remove(Control item)
        {
            uiTabDelete(Owner.Handle, item.Index);
            return base.Remove(item);
        }
    }
}