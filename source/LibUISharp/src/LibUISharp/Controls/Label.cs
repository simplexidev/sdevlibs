using static LibUISharp.Internal.LibUI;

namespace LibUISharp
{
    // uiLabel
    public class Label : Control
    {
        private string text;

        public Label(string text)
        {
            Handle = uiNewLabel(text);
            this.text = text;
        }

        public string Text
        {
            get
            {
                text = uiLabelText(Handle);
                return text;
            }
            set
            {
                if (text != value)
                {
                    uiLabelSetText(Handle, value);
                    text = value;
                }
            }
        }
    }
}