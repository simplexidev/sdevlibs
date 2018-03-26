using System;
using static LibUISharp.Internal.LibUI;

namespace LibUISharp.Controls
{
    public class Entry : Control
    {
        private string text;
        private bool readOnly;

        public Entry()
        {
            if (!(this is MultilineEntry))
            {
                if (this is PasswordEntry)
                    Handle = uiNewPasswordEntry();
                else if (this is SearchEntry)
                    Handle = uiNewSearchEntry();
                else
                    Handle = uiNewEntry();
                InitializeEvents();
            }
            else
                throw new TypeInitializationException("LibUISharp.Controls.MultilineEntry", new InvalidOperationException());
        }

        public event EventHandler<TextChangedEventArgs> TextChanged;

        public virtual string Text
        {
            get
            {
                if (this is MultilineEntry)
                    text = uiMultilineEntryText(Handle);
                else
                    text = uiEntryText(Handle);
                return text;
            }
            set
            {
                if (text != value)
                {
                    if (this is MultilineEntry)
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
                if (this is MultilineEntry)
                    readOnly = uiMultilineEntryReadOnly(Handle);
                else
                    readOnly = uiEntryReadOnly(Handle);
                return readOnly;
            }
            set
            {
                if (readOnly != value)
                {
                    if (this is MultilineEntry)
                        uiMultilineEntrySetReadOnly(Handle, value);
                    else
                        uiEntrySetReadOnly(Handle, value);
                    readOnly = value;
                }
            }
        }

        protected override void InitializeEvents()
        {
            if (this is MultilineEntry)
                uiMultilineEntryOnChanged(Handle, (entry, data) => { OnTextChanged(EventArgs.Empty); });
            else
                uiEntryOnChanged(Handle, (entry, data) => { OnTextChanged(EventArgs.Empty); });
        }

        protected virtual void OnTextChanged(EventArgs e) => TextChanged?.Invoke(this, new TextChangedEventArgs(Text));
    }

    public class PasswordEntry : Entry
    {
        public PasswordEntry() : base() { }
    }

    public class SearchEntry : Entry
    {
        public SearchEntry() : base() { }
    }

    public class MultilineEntry : Entry
    {
        private MultilineEntry() { }

        public MultilineEntry(bool wordWrap = true)
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