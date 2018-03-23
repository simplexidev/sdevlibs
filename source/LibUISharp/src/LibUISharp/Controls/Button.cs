using System;
using LibUISharp.Internal;

namespace LibUISharp.Controls
{
    public class Button : Control
    {
        private string text;

        public Button(string text)
        {
            Handle = LibUIAPI.NewButton(text);
            this.text = text;
            InitializeEvents();
        }

        public event EventHandler Click;

        public string Text
        {
            get
            {
                text = LibUIAPI.ButtonGetText(Handle);
                return text;
            }
            set
            {
                if (text != value)
                {
                    LibUIAPI.WindowSetTitle(Handle, text);
                    text = value;
                }
            }
        }

        protected sealed override void InitializeEvents() =>
            LibUIAPI.ButtonOnClick(Handle, (button, data) => { OnClick(EventArgs.Empty); });

        protected virtual void OnClick(EventArgs e) => Click?.Invoke(this, e);
    }
}