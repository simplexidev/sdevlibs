using LibUISharp.Internal;
using LibUISharp.SafeHandles;
using System;

namespace LibUISharp
{
    /// Represents a control that is used to separate items.
    public class Separator : Control
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Separator"/> class with the specified orientation.
        /// </summary>
        /// <param name="orientation">The specified orientation.</param>
        public Separator(Orientation orientation)
        {
            switch (orientation)
            {
                case Orientation.Horizontal:
                    Handle = new SafeControlHandle(LibuiLibrary.uiNewHorizontalSeparator());
                    break;
                case Orientation.Vertical:
                    Handle = new SafeControlHandle(LibuiLibrary.uiNewVerticalSeparator());
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(orientation));
            }
            Orientation = orientation;
        }

        /// <summary>
        /// Gets this <see cref="Separator"/> object's orientation.
        /// </summary>
        public Orientation Orientation { get; }
    }
}