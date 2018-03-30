using LibUISharp.Collections;
using static LibUISharp.Internal.LibUI;

namespace LibUISharp
{
    public class Grid : ContainerControl<GridItemCollection, Grid>
    {
        private bool padded;

        public Grid() => Handle = uiNewGrid();

        public bool Padded
        {
            get
            {
                padded = uiGridPadded(Handle);
                return padded;
            }
            set
            {
                if (padded != value)
                {
                    uiGridSetPadded(Handle, value);
                    padded = value;
                }
            }
        }
    }
}