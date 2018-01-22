using LibUISharp.Internal;
using static LibUISharp.Internal.UI;

namespace LibUISharp
{
    public partial class Separator : Control
    {
        public Separator(Orientation orientation = Orientation.Horizontal)
        {
            if (orientation == Orientation.Horizontal)
                Handle = new UIControlHandle(uiNewHorizontalSeparator());
            else Handle = new UIControlHandle(uiNewVerticalSeparator());
        }
    }
}