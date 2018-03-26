using System;

using static LibUISharp.Internal.LibUI;

namespace LibUISharp
{
    public abstract class Panel : ContainerControl<PanelItemCollection, Panel>
    {
        protected Panel(Orientation orientation = Orientation.Horizontal)
        {
            switch (orientation)
            {
                case Orientation.Horizontal:
                    Handle = uiNewHorizontalBox();
                    break;
                case Orientation.Vertical:
                    Handle = uiNewVerticalBox();
                    break;
                default:
                    throw new ArgumentOutOfRangeException("orientation");
            }
            Orientation = orientation;
        }

        public Orientation Orientation { get; }

        public bool Padding
        {
            get => uiBoxPadded(Handle);
            set => uiBoxSetPadded(Handle, value);
        }
    }

    public sealed class HPanel : Panel
    {
        public HPanel() : base(Orientation.Horizontal) { }
    }

    public sealed class VPanel : Panel
    {
        public VPanel() : base(Orientation.Vertical) { }
    }
    
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