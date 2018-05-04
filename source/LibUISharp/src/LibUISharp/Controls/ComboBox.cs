using System;
using LibUISharp.Native;
using LibUISharp.Native.Libraries;
using LibUISharp.Native.SafeHandles;

namespace LibUISharp.Controls
{
    public abstract class ComboBoxBase : Control
    {
        protected ComboBoxBase()
        {
            if (this is ComboBox)
                Handle = new SafeControlHandle(LibuiLibrary.uiNewCombobox());
            else if (this is EditableComboBox)
                Handle = new SafeControlHandle(LibuiLibrary.uiNewEditableCombobox());
        }

        public void Add(string item)
        {
            if (string.IsNullOrEmpty(item))
            {
                if (this is ComboBox)
                    LibuiLibrary.uiComboboxAppend(Handle.DangerousGetHandle(), null);
                else if (this is EditableComboBox)
                    LibuiLibrary.uiEditableComboboxAppend(Handle.DangerousGetHandle(), null);
            }
            else
            {
                if (this is ComboBox)
                    LibuiLibrary.uiComboboxAppend(Handle.DangerousGetHandle(), LibuiConvert.ToLibuiString(item));
                else if (this is EditableComboBox)
                    LibuiLibrary.uiEditableComboboxAppend(Handle.DangerousGetHandle(), LibuiConvert.ToLibuiString(item));
            }
        }

        public void Add(params string[] items)
        {
            foreach (string s in items)
            {
                Add(s);
            }
        }
    }

    // uiCombobox
    public class ComboBox : ComboBoxBase
    {
        public ComboBox() : base() => InitializeEvents();

        public event EventHandler Selected;

        private int index = -1;
        public int SelectedIndex
        {
            get
            {
                index = uiComboboxSelected(Handle);
                return index;
            }
            set
            {
                if (index != value)
                {
                    uiComboboxSetSelected(Handle, value);
                    index = value;
                }
            }
        }

        protected virtual void OnSelected(EventArgs e) => Selected?.Invoke(this, e);

        protected sealed override void InitializeEvents() => uiComboboxOnSelected(Handle, (c, data) => { OnSelected(EventArgs.Empty); });
    }

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