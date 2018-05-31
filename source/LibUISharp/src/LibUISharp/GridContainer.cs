using LibUISharp.Internal;
using LibUISharp.SafeHandles;

namespace LibUISharp
{
    /// <summary>
    /// Represents a container control that allows for specific sizes and positions for each child control.
    /// </summary>
    public class GridContainer : ContainerControl<Control, GridContainerItemCollection>
    {
        private bool padding;

        /// <summary>
        /// Initializes a new instance of the <see cref="GridContainer"/> class.
        /// </summary>
        public GridContainer() => Handle = new SafeControlHandle(LibuiLibrary.uiNewGrid());
        
        /// <summary>
        /// Gets or sets a value indiating whether this <see cref="FormContainer"/> has interior padding or not.
        /// </summary>
        public bool Padding
        {
            get
            {
                padding = LibuiLibrary.uiGridPadded(Handle.DangerousGetHandle());
                return padding;
            }
            set
            {
                if (padding != value)
                {
                    LibuiLibrary.uiGridSetPadded(Handle.DangerousGetHandle(), value);
                    padding = value;
                }
            }
        }
    }
}