using System;
using static LibUISharp.Native.NativeMethods;

namespace LibUISharp
{
    /// <summary>
    /// Represents a selection control with a drop-down list that can be shown or hidden by clicking the arrow on the control, and can be typed into.
    /// </summary>
    public class EditableComboBox : ComboBoxBase
    {
        private string text;

        /// <summary>
        /// Initalizes a new instance of the <see cref="ComboBox"/> class.
        /// </summary>
        public EditableComboBox() : base()
        {
            Handle = Libui.uiNewEditableCombobox();
            InitializeEvents();
        }

        /// <summary>
        /// Occurs when the <see cref="Text"/> property is changed.
        /// </summary>
        public event EventHandler<TextChangedEventArgs> TextChanged;

        /// <summary>
        /// Gets or sets the text of this <see cref="EditableComboBox"/>.
        /// </summary>
        public virtual string Text
        {
            get
            {
                text = Libui.uiEditableComboboxText(this);
                return text;
            }
            set
            {
                if (text != value)
                {
                    Libui.uiEditableComboboxSetText(this, value);
                    text = value;
                }
            }
        }

        /// <summary>
        /// Adds a drop-down item to this control.
        /// </summary>
        /// <param name="item">The item to add to this control.</param>
        public override void Add(string item) => Libui.uiEditableComboboxAppend(this, item);

        /// <summary>
        /// Called when the <see cref="TextChanged"/> event is raised.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> that contains the event data.</param>
        protected virtual void OnTextChanged(EventArgs e) => TextChanged?.Invoke(this, new TextChangedEventArgs(Text));

        /// <summary>
        /// Initializes this UI component's events.
        /// </summary>
        protected sealed override void InitializeEvents() => Libui.uiEditableComboboxOnChanged(this, (box, data) => { OnTextChanged(EventArgs.Empty); }, IntPtr.Zero);
    }
}