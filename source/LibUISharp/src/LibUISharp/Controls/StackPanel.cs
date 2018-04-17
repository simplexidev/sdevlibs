using System;
using LibUISharp.Native.Libraries;
using LibUISharp.Native.SafeHandles;

// uiBox
namespace LibUISharp.Controls
{
    /// <summary>
    /// Arranges child elements into a single line that can be oriented horizontally or vertically.
    /// </summary>
    public class StackPanel : ContainerControl<StackPanel, StackPanelItemCollection>
    {
        private bool padding;

        /// <summary>
        /// Initializes a new instance of the <see cref="StackPanel"/> class with the specified orientation.
        /// </summary>
        /// <param name="orientation">The orientation controls are placed in the <see cref="StackPanel"/>.</param>
        public StackPanel(Orientation orientation)
        {
            switch (orientation)
            {
                case Orientation.Horizontal:
                    Handle = new SafeControlHandle(LibuiLibrary.uiNewHorizontalBox());
                    break;
                case Orientation.Vertical:
                    Handle = new SafeControlHandle(LibuiLibrary.uiNewVerticalBox());
                    break;
                default:
                    throw new ArgumentOutOfRangeException("orientation");
            }
            Orientation = orientation;
        }

        /// <summary>
        /// Gets the dimension be which child controls are placed.
        /// </summary>
        public Orientation Orientation { get; }

        /// <summary>
        /// Gets or sets a value indiating whether this <see cref="StackPanel"/> is padded or not.
        /// </summary>
        public bool Padding
        {
            get
            {
                padding = LibuiLibrary.uiBoxPadded(Handle.DangerousGetHandle());
                return padding;
            }
            set
            {
                if (padding != value)
                {
                    LibuiLibrary.uiBoxSetPadded(Handle.DangerousGetHandle(), value);
                    padding = value;
                }
            }
        }
    }
}