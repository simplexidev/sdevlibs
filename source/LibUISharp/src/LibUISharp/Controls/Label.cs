using LibUISharp.Internal;

namespace LibUISharp.Controls
{
    public class Label : Control
    {
        private string text;

        public Label(string text)
        {
            Handle = LibUIAPI.NewLabel(text);
            this.text = text;
        }

        public string Text
        {
            get
            {
                text = LibUIAPI.LabelGetText(Handle);
                return text;
            }
            set
            {
                if (text != value)
                {
                    LibUIAPI.LabelSetText(Handle, value);
                    text = value;
                }
            }
        }
    }
}