using System;

namespace LibUISharp
{
    // uiEditableCombobox
    public class EditableComboBox : ComboBoxBase
    {
        public EditableComboBox() : base() => InitializeEvents();

        public event EventHandler<TextChangedEventArgs> TextChanged;

        private string text;
        public virtual string Text
        {
            get
            {
                text = uiEditableComboboxText(Handle);
                return text;
            }
            set
            {
                if (text != value)
                {
                    uiEditableComboboxSetText(Handle, value);
                    text = value;
                }
            }
        }

        protected virtual void OnTextChanged(EventArgs e) => TextChanged?.Invoke(this, new TextChangedEventArgs(Text));

        protected sealed override void InitializeEvents() => uiEditableComboboxOnChanged(Handle, (box, data) => { OnTextChanged(EventArgs.Empty); });
    }
}