using System;
using static LibUISharp.Internal.LibUI;

namespace LibUISharp
{
    // uiCheckbox
    public class CheckBox : Control
    {
        private string text;
        private bool _checked;

        public CheckBox(string text)
        {
            Handle = uiNewCheckbox(text);
            this.text = text;
            InitializeEvents();
        }

        public event EventHandler Toggled;
        
        public string Text
        {
            get
            {
                text = uiCheckboxText(Handle);
                return text;
            }
            set
            {
                if (text != value)
                {
                    uiCheckboxSetText(Handle, text);
                    text = value;
                }
            }
        }

        public bool Checked
        {
            get
            {
                _checked = uiCheckboxChecked(Handle);
                return _checked;
            }
            set
            {
                if (_checked != value)
                {
                    uiCheckboxSetChecked(Handle, value);
                    _checked = value;
                }
            }
        }

        protected sealed override void InitializeEvents() => uiCheckboxOnToggled(Handle, (checkbox, data) => { OnToggled(EventArgs.Empty); });

        protected virtual void OnToggled(EventArgs e) => Toggled?.Invoke(this, e);
    }
}