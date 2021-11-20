using static LibUISharp.Native.NativeMethods;

namespace LibUISharp
{
    /// <summary>
    /// Represents a <see cref="TextBox"/> that displays a search icon.
    /// </summary>
    public class SearchBox : TextBox
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchBox"/> class.
        /// </summary>
        public SearchBox() : base()
        {
            Handle = Libui.uiNewSearchEntry();
            InitializeEvents();
        }
    }
}