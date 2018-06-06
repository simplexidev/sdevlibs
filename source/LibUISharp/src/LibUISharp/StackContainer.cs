using System;
using static LibUISharp.Native.NativeMethods;

namespace LibUISharp
{
    /// <summary>
    /// Arranges child elements into a single line that can be oriented horizontally or vertically.
    /// </summary>
    public class StackContainer : ContainerControl<Control, StackContainerItemCollection>
    {
        private bool isPadded;

        /// <summary>
        /// Initializes a new instance of the <see cref="StackContainer"/> class with the specified orientation.
        /// </summary>
        /// <param name="orientation">The orientation controls are placed in the <see cref="StackContainer"/>.</param>
        public StackContainer(Orientation orientation)
        {
            switch (orientation)
            {
                case Orientation.Horizontal:
                    Handle = Libui.uiNewHorizontalBox();
                    break;
                case Orientation.Vertical:
                    Handle = Libui.uiNewVerticalBox();
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
        /// Gets or sets a value indiating whether this <see cref="StackContainer"/> has interior isPadded or not.
        /// </summary>
        public bool IsPadded
        {
            get
            {
                isPadded = Libui.uiBoxPadded(this);
                return isPadded;
            }
            set
            {
                if (isPadded != value)
                {
                    Libui.uiBoxSetPadded(this, value);
                    isPadded = value;
                }
            }
        }
    }
}