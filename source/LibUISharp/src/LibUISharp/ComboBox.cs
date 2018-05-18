using System;
using System.Runtime.InteropServices;
using LibUISharp.Internal;
using LibUISharp.SafeHandles;

// uiComboBox
// uiEditableCombobox
namespace LibUISharp
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
                    LibuiLibrary.uiComboboxAppend(Handle.DangerousGetHandle(), IntPtr.Zero);
                else if (this is EditableComboBox)
                    LibuiLibrary.uiEditableComboboxAppend(Handle.DangerousGetHandle(), IntPtr.Zero);
            }
            else
            {
                IntPtr strPtr = item.ToLibuiString();
                if (this is ComboBox)
                    LibuiLibrary.uiComboboxAppend(Handle.DangerousGetHandle(), strPtr);
                else if (this is EditableComboBox)
                    LibuiLibrary.uiEditableComboboxAppend(Handle.DangerousGetHandle(), strPtr);
                Marshal.FreeHGlobal(strPtr);
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

    public class ComboBox : ComboBoxBase
    {
        private int index = -1;

        public ComboBox() : base() => InitializeEvents();

        public event EventHandler Selected;

        public int SelectedIndex
        {
            get
            {
                index = LibuiLibrary.uiComboboxSelected(Handle.DangerousGetHandle());
                return index;
            }
            set
            {
                if (index != value)
                {
                    LibuiLibrary.uiComboboxSetSelected(Handle.DangerousGetHandle(), value);
                    index = value;
                }
            }
        }

        protected virtual void OnSelected(EventArgs e) => Selected?.Invoke(this, e);

        protected sealed override void InitializeEvents() => LibuiLibrary.uiComboboxOnSelected(Handle.DangerousGetHandle(), (c, data) => { OnSelected(EventArgs.Empty); }, IntPtr.Zero);
    }

    public class EditableComboBox : ComboBoxBase
    {
        public EditableComboBox() : base() => InitializeEvents();

        public event EventHandler<TextChangedEventArgs> TextChanged;

        private string text;
        public virtual string Text
        {
            get
            {
                text = LibuiLibrary.uiEditableComboboxText(Handle.DangerousGetHandle()).ToStringEx();
                return text;
            }
            set
            {
                if (text != value)
                {
                    IntPtr strPtr = value.ToLibuiString();
                    LibuiLibrary.uiEditableComboboxSetText(Handle.DangerousGetHandle(), strPtr);
                    Marshal.FreeHGlobal(strPtr);
                    text = value;
                }
            }
        }

        protected virtual void OnTextChanged(EventArgs e) => TextChanged?.Invoke(this, new TextChangedEventArgs(Text));

        protected sealed override void InitializeEvents() => LibuiLibrary.uiEditableComboboxOnChanged(Handle.DangerousGetHandle(), (box, data) => { OnTextChanged(EventArgs.Empty); }, IntPtr.Zero);
    }
}