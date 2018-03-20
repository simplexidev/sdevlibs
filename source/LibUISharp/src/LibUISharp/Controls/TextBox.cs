using System;
using LibUISharp.Internal;

namespace LibUISharp.Controls
{
    public class TextBox : Control
    {
        private string text;
        private bool readOnly;

        public TextBox()
        {
            if (!(this is MultilineTextBox))
            {
                if (this is PasswordBox)
                    Handle = LibUI.NewPasswordBox();
                else if (this is SearchBox)
                    Handle = LibUI.NewSearchBox();
                else
                    Handle = LibUI.NewTextBox();
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
                    text = LibUI.MultilineTextBoxGetText(Handle);
                else
                    text = LibUI.TextBoxGetText(Handle);
                return text;
            }
            set
            {
                if (text != value)
                {
                    if (this is MultilineTextBox)
                        LibUI.MultilineTextBoxSetText(Handle, value);
                    else
                        LibUI.TextBoxSetText(Handle, value);
                    text = value;
                }
            }
        }

        public virtual bool ReadOnly
        {
            get
            {
                if (this is MultilineTextBox)
                    readOnly = LibUI.MultilineTextBoxGetReadOnly(Handle);
                else
                    readOnly = LibUI.TextBoxGetReadOnly(Handle);
                return readOnly;
            }
            set
            {
                if (readOnly != value)
                {
                    if (this is MultilineTextBox)
                        LibUI.MultilineTextBoxSetReadOnly(Handle, value);
                    else
                        LibUI.TextBoxSetReadOnly(Handle, value);
                    readOnly = value;
                }
            }
        }

        protected override void InitializeEvents()
        {
            if (this is MultilineTextBox)
                LibUI.MultilineTextBoxOnTextChanged(Handle, (entry, data) => { OnTextChanged(EventArgs.Empty); });
            else
                LibUI.TextBoxOnTextChanged(Handle, (entry, data) => { OnTextChanged(EventArgs.Empty); });
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

    public class MultilineTextBox : TextBox
    {
        private MultilineTextBox() { }

        public MultilineTextBox(bool wordWrap = true)
        {
            if (wordWrap)
                Handle = LibUI.NewMultilineTextBox();
            else
                Handle = LibUI.NewNonWrappingMultilineTextBox();
            WordWrap = wordWrap;
            InitializeEvents();
        }

        public bool WordWrap { get; }

        public void Append(params string[] lines) => LibUI.MultilineTextBoxAppend(Handle, lines);
    }
}