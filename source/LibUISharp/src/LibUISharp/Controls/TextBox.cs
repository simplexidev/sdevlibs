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
                    Handle = LibUIAPI.NewPasswordBox();
                else if (this is SearchBox)
                    Handle = LibUIAPI.NewSearchBox();
                else
                    Handle = LibUIAPI.NewTextBox();
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
                    text = LibUIAPI.MultilineTextBoxGetText(Handle);
                else
                    text = LibUIAPI.TextBoxGetText(Handle);
                return text;
            }
            set
            {
                if (text != value)
                {
                    if (this is MultilineTextBox)
                        LibUIAPI.MultilineTextBoxSetText(Handle, value);
                    else
                        LibUIAPI.TextBoxSetText(Handle, value);
                    text = value;
                }
            }
        }

        public virtual bool ReadOnly
        {
            get
            {
                if (this is MultilineTextBox)
                    readOnly = LibUIAPI.MultilineTextBoxGetReadOnly(Handle);
                else
                    readOnly = LibUIAPI.TextBoxGetReadOnly(Handle);
                return readOnly;
            }
            set
            {
                if (readOnly != value)
                {
                    if (this is MultilineTextBox)
                        LibUIAPI.MultilineTextBoxSetReadOnly(Handle, value);
                    else
                        LibUIAPI.TextBoxSetReadOnly(Handle, value);
                    readOnly = value;
                }
            }
        }

        protected override void InitializeEvents()
        {
            if (this is MultilineTextBox)
                LibUIAPI.MultilineTextBoxOnTextChanged(Handle, (entry, data) => { OnTextChanged(EventArgs.Empty); });
            else
                LibUIAPI.TextBoxOnTextChanged(Handle, (entry, data) => { OnTextChanged(EventArgs.Empty); });
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
                Handle = LibUIAPI.NewMultilineTextBox();
            else
                Handle = LibUIAPI.NewNonWrappingMultilineTextBox();
            WordWrap = wordWrap;
            InitializeEvents();
        }

        public bool WordWrap { get; }

        public void Append(params string[] lines) => LibUIAPI.MultilineTextBoxAppend(Handle, lines);
    }
}