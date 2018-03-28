using System;
using static LibUISharp.Internal.LibUI;

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
                if (this is PasswordTextBox)
                    Handle = uiNewPasswordEntry();
                else if (this is SearchTextBox)
                    Handle = uiNewSearchEntry();
                else
                    Handle = uiNewEntry();
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
                    readOnly = uiMultilineEntryReadOnly(Handle);
                else
                    readOnly = uiEntryReadOnly(Handle);
                return readOnly;
            }
            set
            {
                if (readOnly != value)
                {
                    if (this is MultilineTextBox)
                        uiMultilineEntrySetReadOnly(Handle, value);
                    else
                        uiEntrySetReadOnly(Handle, value);
                    readOnly = value;
                }
            }
        }

        protected override void InitializeEvents()
        {
            if (this is MultilineTextBox)
                uiMultilineEntryOnChanged(Handle, (entry, data) => { OnTextChanged(EventArgs.Empty); });
            else
                uiEntryOnChanged(Handle, (entry, data) => { OnTextChanged(EventArgs.Empty); });
        }

        protected virtual void OnTextChanged(EventArgs e) => TextChanged?.Invoke(this, new TextChangedEventArgs(Text));
    }

    public class PasswordTextBox : TextBox
    {
        public PasswordTextBox() : base() { }
    }

    public class SearchTextBox : TextBox
    {
        public SearchTextBox() : base() { }
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

        public void Append(params string[] lines) => uiMultilineEntryAppend(Handle, lines);
    }
}