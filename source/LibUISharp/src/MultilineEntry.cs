using System;
using System.Runtime.InteropServices;
using LibUISharp.Internal;
using static LibUISharp.Internal.UI;

namespace LibUISharp
{
    public class MultiLineEntry : Control
    {
        public MultiLineEntry(bool wrapsWords = true)
        {
            WrapsWords = wrapsWords;
            if (wrapsWords)
                Handle = new UIControlHandle(uiNewMultilineEntry());
            else Handle = new UIControlHandle(uiNewNonWrappingMultilineEntry());
        }

        public bool WrapsWords { get; }

        private string text;
        public virtual string Text
        {
            get => text = MarshalHelper.StringFromUTF8(uiMultilineEntryText(Handle.DangerousGetHandle()));
            set
            {
                if (text != value)
                {
                    IntPtr strPtr = MarshalHelper.StringToUTF8(value);
                    uiMultilineEntrySetText(Handle.DangerousGetHandle(), strPtr);
                    text = value;
                    Marshal.FreeHGlobal(strPtr);
                }
            }
        }

        private bool isReadOnly;
        public bool IsReadOnly
        {
            get => isReadOnly = uiMultilineEntryReadOnly(Handle.DangerousGetHandle());
            set
            {
                if (isReadOnly != value)
                {
                    uiMultilineEntrySetReadOnly(Handle.DangerousGetHandle(), value);
                    isReadOnly = value;
                }
            }
        }

        public void Append(string append)
        {
            if (!string.IsNullOrEmpty(append))
            {
                IntPtr strPtr = MarshalHelper.StringToUTF8(append);
                uiMultilineEntryAppend(Handle.DangerousGetHandle(), strPtr);
                Marshal.FreeHGlobal(strPtr);
            }
        }

        protected sealed override void Initialize() =>
            uiMultilineEntryOnChanged(Handle.DangerousGetHandle(), (entry, data) => { OnTextChanged(EventArgs.Empty); }, IntPtr.Zero);

        public event EventHandler<TextChangedEventArgs> TextChanged;
        protected virtual void OnTextChanged(EventArgs e) => TextChanged?.Invoke(this, new TextChangedEventArgs(Text));
    }
}