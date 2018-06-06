using static LibUISharp.Native.NativeMethods;

namespace LibUISharp
{
    /// <summary>
    /// Represents a container control that allows for specific sizes and positions for each child control.
    /// </summary>
    public class GridContainer : ContainerControl<Control, GridContainerItemCollection>
    {
        private bool isPadded;

        /// <summary>
        /// Initializes a new instance of the <see cref="GridContainer"/> class.
        /// </summary>
        public GridContainer() => Handle = Libui.uiNewGrid();
        
        /// <summary>
        /// Gets or sets a value indiating whether this <see cref="FormContainer"/> has interior padding or not.
        /// </summary>
        public bool IsPadded
        {
            get
            {
                isPadded = Libui.uiGridPadded(this);
                return isPadded;
            }
            set
            {
                if (isPadded != value)
                {
                    Libui.uiGridSetPadded(this, value);
                    isPadded = value;
                }
            }
        }
    }
}