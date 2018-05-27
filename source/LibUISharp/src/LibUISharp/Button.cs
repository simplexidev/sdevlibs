using LibUISharp.Internal;
using LibUISharp.SafeHandles;
using System;
using System.Runtime.InteropServices;

namespace LibUISharp
{
    /// <summary>
    /// Represents a basic button control with text.
    /// </summary>
    public class Button : Control
    {
        private string text;

        /// <summary>
        /// Initializes a new instance of the <see cref="Button"/> class with the specified text.
        /// </summary>
        /// <param name="text">The text to be displayed by this button.</param>
        public Button(string text)
        {
            IntPtr strPtr = text.ToLibuiString();
            Handle = new SafeControlHandle(LibuiLibrary.uiNewButton(strPtr));
            Marshal.FreeHGlobal(strPtr);
            this.text = text;
            InitializeEvents();
        }

        /// <summary>
        /// Occurs when the button is clicked.
        /// </summary>
        public event EventHandler Click;

        /// <summary>
        /// Gets or sets the text within this button.
        /// </summary>
        public string Text
        {
            get
            {
                text = LibuiLibrary.uiButtonText(Handle.DangerousGetHandle()).ToStringEx();
                return text;
            }
            set
            {
                if (text != value)
                {
                    IntPtr strPtr = value.ToLibuiString();
                    LibuiLibrary.uiButtonSetText(Handle.DangerousGetHandle(), strPtr);
                    Marshal.FreeHGlobal(strPtr);
                    text = value;
                }
            }
        }

        /// <summary>
        /// Initializes this UI component's events.
        /// </summary>
        protected sealed override void InitializeEvents() => LibuiLibrary.uiButtonOnClicked(Handle.DangerousGetHandle(), (button, data) => { OnClick(EventArgs.Empty); }, IntPtr.Zero);

        /// <summary>
        /// Raises the <see cref="Click"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        protected virtual void OnClick(EventArgs e) => Click?.Invoke(this, e);
    }
}