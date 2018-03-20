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
            Handle = LibUI.NewCheckBox(text);
            this.text = text;
            InitializeEvents();
        }

        public event EventHandler CheckedChanged;
        
        public string Text
        {
            get
            {
                text = LibUI.CheckBoxGetText(Handle);
                return text;
            }
            set
            {
                if (text != value)
                {
                    LibUI.CheckBoxSetText(Handle, text);
                    text = value;
                }
            }
        }

        public bool Checked
        {
            get
            {
                _checked = LibUI.CheckBoxGetChecked(Handle);
                return _checked;
            }
            set
            {
                if (_checked != value)
                {
                    LibUI.CheckBoxSetChecked(Handle, value);
                    _checked = value;
                }
            }
        }

        protected sealed override void InitializeEvents() => LibUI.CheckBoxOnCheckedChanged(Handle, (checkbox, data) => { OnCheckedChanged(EventArgs.Empty); });

        protected virtual void OnCheckedChanged(EventArgs e) => CheckedChanged?.Invoke(this, e);
    }
}