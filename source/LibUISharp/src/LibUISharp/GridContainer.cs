using LibUISharp.Internal;
using LibUISharp.SafeHandles;

namespace LibUISharp
{
    public class GridContainer : ContainerControl<Control, GridContainerItemCollection>
    {
        private bool padding;

        public GridContainer() => Handle = new SafeControlHandle(LibuiLibrary.uiNewGrid());

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