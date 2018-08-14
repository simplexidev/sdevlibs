using System;
using LibUISharp.Internal;

namespace LibUISharp
{
    /// <summary>
    /// Represents a base implementation of controls that can be used to display and edit one line of text.
    /// </summary>
    [NativeType("uiEntry")]
    public abstract class TextBoxBase : Control
    {
        private string text;
        private bool isReadOnly;

        /// <summary>
        /// Initializes a new instance of the <see cref="TextBoxBase"/> class.
        /// </summary>
        protected TextBoxBase() { }

        /// <summary>
        /// Occurs when the <see cref="Text"/> property is changed.
        /// </summary>
        public event Action TextChanged;

        /// <summary>
        /// Gets or sets the displayed text.
        /// </summary>
        public virtual string Text
        {
            get
            {
                text = NativeCalls.EntryText(this);
                return text;
            }
            set
            {
                if (text != value)
                {
                    NativeCalls.EntrySetText(this, value);
                    text = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets whether the text is read-only or not.
        /// </summary>
        public virtual bool IsReadOnly
        {
            get
            {
                isReadOnly = NativeCalls.EntryReadOnly(this);
                return isReadOnly;
            }
            set
            {
                if (isReadOnly != value)
                {
                    NativeCalls.EntrySetReadOnly(this, value);
                    isReadOnly = value;
                }
            }
        }

        /// <summary>
        /// Called when the <see cref="TextChanged"/> event is raised.
        /// </summary>
        protected virtual void OnTextChanged() => TextChanged?.Invoke();

        /// <summary>
        /// Initializes this UI component's events.
        /// </summary>
        protected override void InitializeEvents() => NativeCalls.EntryOnChanged(this, (entry, data) => { OnTextChanged(); }, IntPtr.Zero);
    }

    /// <summary>
    /// Represents a control that can be used to display or edit text.
    /// </summary>
    public class TextBox : TextBoxBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TextBox"/> class.
        /// </summary>
        public TextBox() : base()
        {
            Handle = NativeCalls.NewEntry();
            InitializeEvents();
        }
    }

    /// <summary>
    /// Represents a <see cref="TextBox"/> that displays it's text as password characters.
    /// </summary>
    public class PasswordBox : TextBoxBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PasswordBox"/> class.
        /// </summary>
        public PasswordBox() : base()
        {
            Handle = NativeCalls.NewPasswordEntry();
            InitializeEvents();
        }
    }

    /// <summary>
    /// Represents a <see cref="TextBox"/> that displays a search icon.
    /// </summary>
    public class SearchBox : TextBoxBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchBox"/> class.
        /// </summary>
        public SearchBox() : base()
        {
            Handle = NativeCalls.NewSearchEntry();
            InitializeEvents();
        }
    }
}