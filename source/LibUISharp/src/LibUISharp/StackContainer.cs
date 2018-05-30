using LibUISharp.Internal;
using LibUISharp.SafeHandles;
using System;

namespace LibUISharp
{
    /// <summary>
    /// Arranges child elements into a single line that can be oriented horizontally or vertically.
    /// </summary>
    public class StackContainer : ContainerControl<Control, StackContainerItemCollection>
    {
        private bool padding;

        /// <summary>
        /// Initializes a new instance of the <see cref="StackContainer"/> class with the specified orientation.
        /// </summary>
        /// <param name="orientation">The orientation controls are placed in the <see cref="StackContainer"/>.</param>
        public StackContainer(Orientation orientation)
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
                    throw new ArgumentOutOfRangeException(nameof(orientation));
            }
            Orientation = orientation;
        }

        /// <summary>
        /// Gets the dimension be which child controls are placed.
        /// </summary>
        public Orientation Orientation { get; }

        /// <summary>
        /// Gets or sets a value indiating whether this <see cref="StackContainer"/> has interior padding or not.
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