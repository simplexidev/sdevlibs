using System;
using LibUISharp.Collections;
using static LibUISharp.Internal.LibUI;

namespace LibUISharp
{
    // uiBox
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
}