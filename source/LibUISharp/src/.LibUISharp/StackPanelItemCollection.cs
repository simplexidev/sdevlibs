using System;
using LibUISharp.Native.Libraries;

// uiBox
namespace LibUISharp
{
    public class StackPanelItemCollection : ControlCollection<StackPanel>
    {
        public StackPanelItemCollection(StackPanel uiParent) : base(uiParent) { }

        public override bool Remove(Control item)
        {
            LibuiLibrary.uiBoxDelete(Parent.Handle.DangerousGetHandle(), item.Index);
            return base.Remove(item);
        }

        public override void Add(Control child) => Add(child, false);

        public virtual void Add(Control child, bool stretches)
        {
            if (Contains(child))
                throw new InvalidOperationException("cannot add the same control.");
            if (child == null) return;
            LibuiLibrary.uiBoxAppend(Parent.Handle.DangerousGetHandle(), child.Handle.DangerousGetHandle(), stretches);
            base.Add(child);
        }
    }
}