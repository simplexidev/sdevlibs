using LibUISharp.Native.Libraries;
using System;

namespace LibUISharp.Controls
{
    // uiSeparator
    public class Separator : Control
    {
        protected Separator(Orientation orientation)
        {
            switch (orientation)
            {
                case Orientation.Horizontal:
                    Handle = LibuiLibrary.uiNewHorizontalSeparator();
                    break;
                case Orientation.Vertical:
                    Handle = LibuiLibrary.uiNewVerticalSeparator();
                    break;
                default:
                    throw new ArgumentOutOfRangeException("orientation");
            }
            Orientation = orientation;
        }

        public Orientation Orientation { get; }
    }
}