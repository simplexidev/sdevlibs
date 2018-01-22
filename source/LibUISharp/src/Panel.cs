using System;
using LibUISharp.Internal;

using static LibUISharp.Internal.UI;

namespace LibUISharp
{
    //TODO: Update layout when setting Orientation.
    public abstract class Panel : ContainerControl<PanelItemCollection, Panel>
    {
        private Orientation orientation = Orientation.Vertical;
        public Orientation Orientation
        {
            get => orientation;
            set
            {
                if (orientation != value)
                    orientation = value;
            }
        }

        public bool HasPadding
        {
            get  => uiBoxPadded(Handle.DangerousGetHandle());
            set  => uiBoxSetPadded(Handle.DangerousGetHandle(), value);
        }
    }

    public class VerticalPanel : Panel
    {
        public VerticalPanel()
        {
            Handle = new UIControlHandle(uiNewVerticalBox());
            Orientation = Orientation.Vertical;
        }
    }

    public class HorizontalPanel : Panel
    {
        public HorizontalPanel()
        {
            Handle = new UIControlHandle(uiNewHorizontalBox());
            Orientation = Orientation.Horizontal;
        }
    }

    public class PanelItemCollection : ControlCollection<Panel>
    {
        public PanelItemCollection(Panel uiParent) : base(uiParent) { }

        public override bool Remove(Control item)
        {
            uiBoxDelete(Owner.Handle.DangerousGetHandle(), item.Index);
            return base.Remove(item);
        }

        public override void Add(Control child) => Add(child, false);

        public virtual void Add(Control child, bool stretchy)
        {
            if (Contains(child)) throw new InvalidOperationException("Cannot add the same control more than once.");
            if (child == null) return;
            uiBoxAppend(Owner.Handle.DangerousGetHandle(), child.Handle.DangerousGetHandle(), stretchy);
            base.Add(child);
        }
    }
}