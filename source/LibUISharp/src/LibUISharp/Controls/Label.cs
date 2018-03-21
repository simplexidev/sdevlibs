using LibUISharp.Internal;

namespace LibUISharp.Controls
{
    public class Label : Control
    {
        private string text;

        public Label(string text)
        {
            Handle = LibUI.NewLabel(text);
            this.text = text;
        }

        public string Text
        {
            get
            {
                text = LibUI.LabelGetText(Handle);
                return text;
            }
            set
            {
                if (text != value)
                {
                    LibUI.LabelSetText(Handle, value);
                    text = value;
                }
            }
        }
    }
}