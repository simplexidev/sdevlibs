using System;
using System.Runtime.InteropServices;
using LibUISharp.Internal;

using static LibUISharp.Internal.UI;

namespace LibUISharp
{
    public class TextBox : Control
    {
        protected TextBox()
        {
            if (this is PasswordBox)
                Handle = new UIControlHandle(uiNewPasswordEntry());
            else if (this is SearchBox)
                Handle = new UIControlHandle(uiNewSearchEntry());
            else
                Handle = new UIControlHandle(uiNewEntry());

            Initialize();
        }

        public virtual string Text
        {
            get => MarshalHelper.StringFromUTF8(uiEntryText(Handle.DangerousGetHandle()));
            set
            {
                IntPtr strPtr = MarshalHelper.StringToUTF8(value);
                uiEntrySetText(Handle.DangerousGetHandle(), strPtr);
                Marshal.FreeHGlobal(strPtr);
            }
        }

        private bool isReadOnly;
        public bool IsReadOnly
        {
            get => isReadOnly = uiEntryReadOnly(Handle.DangerousGetHandle());
            set
            {
                if (isReadOnly != value)
                    uiEntrySetReadOnly(Handle.DangerousGetHandle(), value);
            }
        }

        protected sealed override void Initialize() =>
            uiEntryOnChanged(Handle.DangerousGetHandle(), (entry, data) => { OnTextChanged(EventArgs.Empty); }, IntPtr.Zero);

        public event EventHandler<TextChangedEventArgs> TextChanged;
        protected virtual void OnTextChanged(EventArgs e) => TextChanged?.Invoke(this, new TextChangedEventArgs(Text));
    }

    public class PasswordBox : TextBox
    {
        public PasswordBox() : base() { }
    }

    public class SearchBox : TextBox
    {
        public SearchBox() : base() { }
    }
}