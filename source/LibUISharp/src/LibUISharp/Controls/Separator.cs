using LibUISharp.Internal;

namespace LibUISharp.Controls
{
    public abstract class Separator : Control
    {
        protected Separator(Orientation orientation)
        {
            Handle = LibUIAPI.NewSeparator(orientation);
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