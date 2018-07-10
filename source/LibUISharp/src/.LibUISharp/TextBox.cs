using LibUISharp.Internal;
using System;
using static LibUISharp.Internal.Libraries;

namespace LibUISharp
{
    /// <summary>
    /// Represents a base implementation of controls that can be used to display and edit one line of text.
    /// </summary>
    [LibuiType("uiEntry")]
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
        public event EventHandler<TextChangedEventArgs> TextChanged;

        /// <summary>
        /// Gets or sets the displayed text.
        /// </summary>
        public virtual string Text
        {
            get
            {
                text = Libui.Call<Libui.uiEntryText>()(this);
                return text;
            }
            set
            {
                if (text != value)
                {
                    Libui.Call<Libui.uiEntrySetText>()(this, value);
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
                isReadOnly = Libui.Call<Libui.uiEntryReadOnly>()(this);
                return isReadOnly;
            }
            set
            {
                if (isReadOnly != value)
                {
                    Libui.Call<Libui.uiEntrySetReadOnly>()(this, value);
                    isReadOnly = value;
                }
            }
        }

        /// <summary>
        /// Initializes this UI component's events.
        /// </summary>
        protected override void InitializeEvents() => Libui.Call<Libui.uiEntryOnChanged>()(this, (entry, data) => { OnTextChanged(EventArgs.Empty); }, IntPtr.Zero);

        /// <summary>
        /// Called when the <see cref="TextChanged"/> event is raised.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> containing the event data.</param>
        protected virtual void OnTextChanged(EventArgs e) => TextChanged?.Invoke(this, new TextChangedEventArgs(Text));
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
            Handle = Libui.Call<Libui.uiNewEntry>()();
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
            Handle = Libui.Call<Libui.uiNewPasswordEntry>()();
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
            Handle = Libui.Call<Libui.uiNewSearchEntry>()();
            InitializeEvents();
        }
    }
}