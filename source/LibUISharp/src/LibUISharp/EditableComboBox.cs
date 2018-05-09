using LibUISharp.Native;
using LibUISharp.Native.Libraries;
using System;
using System.Runtime.InteropServices;

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
                text = LibuiConvert.ToString(LibuiLibrary.uiEditableComboboxText(Handle.DangerousGetHandle()));
                return text;
            }
            set
            {
                if (text != value)
                {
                    IntPtr strPtr = LibuiConvert.ToLibuiString(value);
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