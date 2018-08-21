using LibUISharp.Internal;

namespace LibUISharp
{
    /// <summary>
    /// Represents a standard label, which contains and shows text.
    /// </summary>
    [NativeType("uiLabel")]
    public class Label : Control
    {
        private string text;

        /// <summary>
        /// Initializes a new instance of the <see cref="Label"/> class with the specified text.
        /// </summary>
        /// <param name="text">The specified text for this <see cref="Label"/>.</param>
        public Label(string text)
        {
            Handle = NativeCalls.NewLabel(text);
            this.text = text;
        }

        /// <summary>
        /// Gets or sets this <see cref="Label"/>'s text.
        /// </summary>
        public string Text
        {
            get
            {
                text = NativeCalls.LabelText(Handle);
                return text;
            }
            set
            {
                if (text != value)
                {
                    NativeCalls.LabelSetText(Handle, value);
                    text = value;
                }
            }
        }
    }
}