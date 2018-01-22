using System;
using System.Runtime.InteropServices;
using LibUISharp.Internal;
using static LibUISharp.Internal.UI;

namespace LibUISharp
{
    public class EditableComboBox : Control
    {
        public EditableComboBox()
        {
            Handle = new UIControlHandle(uiNewEditableCombobox());
            Initialize();
        }

        private string text;
        public string Text
        {
            get => text = MarshalHelper.StringFromUTF8(uiEditableComboboxText(Handle.DangerousGetHandle()));
            set
            {
                if (text != value)
                {
                    IntPtr strPtr = MarshalHelper.StringToUTF8(value);
                    uiEditableComboboxSetText(Handle.DangerousGetHandle(), strPtr);
                    Marshal.FreeHGlobal(strPtr);
                    text = value;
                }
            }
        }

        public void Add(params string[] text)
        {
            IntPtr strPtr;
            if (text == null)
            {
                strPtr = MarshalHelper.StringToUTF8(null);
                uiEditableComboboxAppend(Handle.DangerousGetHandle(), strPtr);
                Marshal.FreeHGlobal(strPtr);
            } else
            {
                foreach (string s in text)
                {
                    strPtr = MarshalHelper.StringToUTF8(s);
                    uiEditableComboboxAppend(Handle.DangerousGetHandle(), strPtr);
                    Marshal.FreeHGlobal(strPtr);
                }
            }
        }

        protected sealed override void Initialize() =>
            uiEditableComboboxOnChanged(Handle.DangerousGetHandle(), (box, data) => { OnTextChanged(EventArgs.Empty); }, IntPtr.Zero);

        public event EventHandler<TextChangedEventArgs> TextChanged;
        protected virtual void OnTextChanged(EventArgs e) => TextChanged?.Invoke(this, new TextChangedEventArgs(text));
    }
}