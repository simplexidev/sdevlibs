using System;
using LibUISharp.Native;
using LibUISharp.Native.Libraries;
using LibUISharp.Native.SafeHandles;

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
}