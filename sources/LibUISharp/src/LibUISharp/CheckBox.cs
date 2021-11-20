using System;
using static LibUISharp.Native.NativeMethods;

namespace LibUISharp
{
    /// <summary>
    /// Represents a control that a user can set and clear.
    /// </summary>
    public class CheckBox : Control
    {
        private string text;
        private bool @checked;

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckBox"/> class with the specified text.
        /// </summary>
        /// <param name="text">The text specified by the <see cref="CheckBox"/>.</param>
        public CheckBox(string text)
        {
            Handle = Libui.uiNewCheckbox(text);
            this.text = text;
            InitializeEvents();
        }

        //TODO: Maybe change this to separate Checked and Unchecked events.
        /// <summary>
        /// Occurs when the <see cref="Checked"/> property is changed.
        /// </summary>
        public event EventHandler Toggled;
        
        /// <summary>
        /// Gets or sets the text shown by this <see cref="CheckBox"/>.
        /// </summary>
        public string Text
        {
            get
            {
                text = Libui.uiCheckboxText(this);
                return text;
            }
            set
            {
                if (text != value)
                {
                    Libui.uiCheckboxSetText(this, value);
                    text = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the state of this <see cref="CheckBox"/>.
        /// </summary>
        public bool Checked
        {
            get
            {
                @checked = Libui.uiCheckboxChecked(this);
                return @checked;
            }
            set
            {
                if (@checked != value)
                {
                    Libui.uiCheckboxSetChecked(this, value);
                    @checked = value;
                }
            }
        }

        /// <summary>
        /// Initializes this UI component's events.
        /// </summary>
        protected sealed override void InitializeEvents() => Libui.uiCheckboxOnToggled(this, (checkbox, data) => { OnToggled(EventArgs.Empty); }, IntPtr.Zero);

        /// <summary>
        /// Called when the <see cref="Toggled"/> event is raised.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> containing the event data.</param>
        protected virtual void OnToggled(EventArgs e) => Toggled?.Invoke(this, e);
    }
}