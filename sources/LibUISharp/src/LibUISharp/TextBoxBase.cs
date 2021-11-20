using System;
using static LibUISharp.Native.NativeMethods;

namespace LibUISharp
{
    /// <summary>
    /// Represents a base implementation of controls that can be used to display and edit text.
    /// </summary>
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
                text = Libui.uiEntryText(this);
                return text;
            }
            set
            {
                if (text != value)
                {
                    Libui.uiEntrySetText(this, value);
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
                isReadOnly = Libui.uiEntryReadOnly(this);
                return isReadOnly;
            }
            set
            {
                if (isReadOnly != value)
                {
                    Libui.uiEntrySetReadOnly(this, value);
                    isReadOnly = value;
                }
            }
        }

        /// <summary>
        /// Initializes this UI component's events.
        /// </summary>
        protected override void InitializeEvents() => Libui.uiEntryOnChanged(this, (entry, data) => { OnTextChanged(EventArgs.Empty); }, IntPtr.Zero);

        /// <summary>
        /// Called when the <see cref="TextChanged"/> event is raised.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> containing the event data.</param>
        protected virtual void OnTextChanged(EventArgs e) => TextChanged?.Invoke(this, new TextChangedEventArgs(Text));
    }
}