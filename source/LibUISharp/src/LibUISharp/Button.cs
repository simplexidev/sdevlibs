using System;
using static LibUISharp.Internal.LibUI;

namespace LibUISharp
{
    public class Button : Control
    {
        private string text;

        public Button(string text)
        {
            Handle = uiNewButton(text);
            this.text = text;
            InitializeEvents();
        }

        public event EventHandler Click;

        public string Text
        {
            get
            {
                text = uiButtonText(Handle);
                return text;
            }
            set
            {
                if (text != value)
                {
                    uiButtonSetText(Handle, text);
                    text = value;
                }
            }
        }

        protected sealed override void InitializeEvents() =>
            uiButtonOnClicked(Handle, (button, data) => { OnClick(EventArgs.Empty); });

        protected virtual void OnClick(EventArgs e) => Click?.Invoke(this, e);
    }
}