using LibUISharp.Internal;
using static LibUISharp.Internal.Libraries;

namespace LibUISharp
{
    /// <summary>
    /// Represents a standard label, which contains and shows text.
    /// </summary>
    [LibuiType("uiLabel")]
    public class Label : Control
    {
        private string text;

        /// <summary>
        /// Initializes a new instance of the <see cref="Label"/> class with the specified text.
        /// </summary>
        /// <param name="text">The specified text for this <see cref="Label"/>.</param>
        public Label(string text)
        {
            Handle = Libui.Call<Libui.uiNewLabel>()(text);
            this.text = text;
        }

        /// <summary>
        /// Gets or sets this <see cref="Label"/>'s text.
        /// </summary>
        public string Text
        {
            get
            {
                text = Libui.Call<Libui.uiLabelText>()(this);
                return text;
            }
            set
            {
                if (text != value)
                {
                    Libui.Call<Libui.uiLabelSetText>()(this, value);
                    text = value;
                }
            }
        }
    }
}