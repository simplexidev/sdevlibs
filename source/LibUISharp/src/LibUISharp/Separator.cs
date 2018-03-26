using System;
using static LibUISharp.Internal.LibUI;

namespace LibUISharp.Controls
{
    public abstract class Separator : Control
    {
        protected Separator(Orientation orientation)
        {
            switch (orientation)
            {
                case Orientation.Horizontal:
                    Handle = uiNewHorizontalSeparator();
                    break;
                case Orientation.Vertical:
                    Handle = uiNewVerticalSeparator();
                    break;
                default:
                    throw new ArgumentOutOfRangeException("orientation");
            }
            Orientation = orientation;
        }

        public Orientation Orientation { get; }
    }

    public class HSeparator : Separator
    {
        public HSeparator() : base(Orientation.Horizontal) { }
    }

    public class VSeparator : Separator
    {
        public VSeparator() : base(Orientation.Vertical) { }
    }

}