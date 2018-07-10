using LibUISharp.Internal;
using System;
using static LibUISharp.Internal.Libraries;

namespace LibUISharp
{
    /// <summary>
    /// Represents a control that is used to separate user-interface (UI) content.
    /// </summary>
    [LibuiType("uiSeparator")]
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
                    Handle = Libui.Call<Libui.uiNewHorizontalSeparator>()();
                    break;
                case Orientation.Vertical:
                    Handle = Libui.Call<Libui.uiNewVerticalSeparator>()();
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