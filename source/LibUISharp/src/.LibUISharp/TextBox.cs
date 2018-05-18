using System;
using System.Runtime.InteropServices;
using LibUISharp.Internal;
using LibUISharp.SafeHandles;

namespace LibUISharp
{
    // uiEntry
    public class TextBox : Control
    {
        private string text;
        private bool readOnly;

        public TextBox()
        {
            if (!(this is MultilineTextBox))
            {
                if (this is PasswordBox)
                    Handle = new SafeControlHandle(LibuiLibrary.uiNewPasswordEntry());
                else if (this is SearchBox)
                    Handle = new SafeControlHandle(LibuiLibrary.uiNewSearchEntry());
                else
                    Handle = new SafeControlHandle(LibuiLibrary.uiNewEntry());
                InitializeEvents();
            }
            else
                throw new TypeInitializationException("LibUISharp.Controls.MultilineTextBox", new InvalidOperationException());
        }

        public event EventHandler<TextChangedEventArgs> TextChanged;

        public virtual string Text
        {
            get
            {
                if (this is MultilineTextBox)
                    text = uiMultilineEntryText(Handle);
                else
                    text = uiEntryText(Handle);
                return text;
            }
            set
            {
                if (text != value)
                {
                    if (this is MultilineTextBox)
                        uiMultilineEntrySetText(Handle, value);
                    else
                        uiEntrySetText(Handle, value);
                    text = value;
                }
            }
        }

        public virtual bool ReadOnly
        {
            get
            {
                if (this is MultilineTextBox)
                    readOnly = LibuiLibrary.uiMultilineEntryReadOnly(Handle);
                else
                    readOnly = LibuiLibrary.uiEntryReadOnly(Handle);
                return readOnly;
            }
            set
            {
                if (readOnly != value)
                {
                    if (this is MultilineTextBox)
                        LibuiLibrary.uiMultilineEntrySetReadOnly(Handle, value);
                    else
                        LibuiLibrary.uiEntrySetReadOnly(Handle, value);
                    readOnly = value;
                }
            }
        }

        protected override void InitializeEvents()
        {
            if (this is MultilineTextBox)
                LibuiLibrary.uiMultilineEntryOnChanged(Handle, (entry, data) => { OnTextChanged(EventArgs.Empty); }, IntPtr.Zero);
            else
                LibuiLibrary.uiEntryOnChanged(Handle, (entry, data) => { OnTextChanged(EventArgs.Empty); }, IntPtr.Zero);
        }

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

    // uiMultilineEntry
    public class MultilineTextBox : TextBox
    {
        private MultilineTextBox() { }

        public MultilineTextBox(bool wordWrap = true)
        {
            if (wordWrap)
                Handle = uiNewMultilineEntry();
            else
                Handle = uiNewNonWrappingMultilineEntry();
            WordWrap = wordWrap;
            InitializeEvents();
        }

        public bool WordWrap { get; }

        public void Append(params string[] lines)
        {
            if (lines == null || lines.Length < 1) throw new ArgumentNullException("lines");

            foreach (string line in lines)
            {
                IntPtr strPtr = line.ToLibuiString();
                LibuiLibrary.uiMultilineEntryAppend(Handle.DangrousGetHandle(), strPtr);
                Marshal.FreeHGlobal(strPtr);
            }
        }
    }
}