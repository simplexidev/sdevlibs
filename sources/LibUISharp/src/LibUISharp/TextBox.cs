using static LibUISharp.Native.NativeMethods;

namespace LibUISharp
{
    /// <summary>
    /// Represents a control that can be used to display or edit text.
    /// </summary>
    public class TextBox : TextBoxBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TextBox"/> class.
        /// </summary>
        public TextBox() : base()
        {
            Handle = Libui.uiNewEntry();
            InitializeEvents();
        }
    }
}