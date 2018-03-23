using System;
using LibUISharp.Internal;

namespace LibUISharp.Controls
{
    public class CheckBox : Control
    {
        private string text;
        private bool _checked;

        public CheckBox(string text)
        {
            Handle = LibUIAPI.NewCheckBox(text);
            this.text = text;
            InitializeEvents();
        }

        public event EventHandler CheckedChanged;
        
        public string Text
        {
            get
            {
                text = LibUIAPI.CheckBoxGetText(Handle);
                return text;
            }
            set
            {
                if (text != value)
                {
                    LibUIAPI.CheckBoxSetText(Handle, text);
                    text = value;
                }
            }
        }

        public bool Checked
        {
            get
            {
                _checked = LibUIAPI.CheckBoxGetChecked(Handle);
                return _checked;
            }
            set
            {
                if (_checked != value)
                {
                    LibUIAPI.CheckBoxSetChecked(Handle, value);
                    _checked = value;
                }
            }
        }

        protected sealed override void InitializeEvents() => LibUIAPI.CheckBoxOnCheckedChanged(Handle, (checkbox, data) => { OnCheckedChanged(EventArgs.Empty); });

        protected virtual void OnCheckedChanged(EventArgs e) => CheckedChanged?.Invoke(this, e);
    }
}