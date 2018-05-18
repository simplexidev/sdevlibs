using LibUISharp.Internal;
using LibUISharp.SafeHandles;
using System;
using System.Runtime.InteropServices;

// uiCheckbox
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
            IntPtr strPtr = text.ToLibuiString();
            Handle = new SafeControlHandle(LibuiLibrary.uiNewCheckbox(strPtr));
            Marshal.FreeHGlobal(strPtr);
            this.text = text;
            InitializeEvents();
        }

        //TODO: Maybe change this To separate Checked and Unchecked events.
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
                text = LibuiLibrary.uiCheckboxText(Handle.DangerousGetHandle()).ToStringEx();
                return text;
            }
            set
            {
                if (text != value)
                {
                    IntPtr strPtr = value.ToLibuiString();
                    LibuiLibrary.uiCheckboxSetText(Handle.DangerousGetHandle(), strPtr);
                    Marshal.FreeHGlobal(strPtr);
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
                @checked = LibuiLibrary.uiCheckboxChecked(Handle.DangerousGetHandle());
                return @checked;
            }
            set
            {
                if (@checked != value)
                {
                    LibuiLibrary.uiCheckboxSetChecked(Handle.DangerousGetHandle(), value);
                    @checked = value;
                }
            }
        }

        /// <inheritdoc/>
        protected sealed override void InitializeEvents() => LibuiLibrary.uiCheckboxOnToggled(Handle.DangerousGetHandle(), (checkbox, data) => { OnToggled(EventArgs.Empty); }, IntPtr.Zero);

        /// <summary>
        /// Called when the <see cref="Checked"/> property checges.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> containing the event data.</param>
        protected virtual void OnToggled(EventArgs e) => Toggled?.Invoke(this, e);
    }
}