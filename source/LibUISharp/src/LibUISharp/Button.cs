using System;
using LibUISharp.Internal;
using LibUISharp.SafeHandles;

namespace LibUISharp
{
    /// <summary>
    /// Represents a basic button control with text.
    /// </summary>
    [NativeType("uiButton")]
    public class Button : Control
    {
        private string text;

        /// <summary>
        /// Initializes a new instance of the <see cref="Button"/> class with the specified text.
        /// </summary>
        /// <param name="text">The text to be displayed by this button.</param>
        public Button(string text)
        {
            Handle = NativeCalls.NewButton(text);
            this.text = text;
            InitializeEvents();
        }

        /// <summary>
        /// Occurs when the button is clicked.
        /// </summary>
        public event Action Click;

        /// <summary>
        /// Gets or sets the text within this button.
        /// </summary>
        public string Text
        {
            get
            {
                if (IsInvalid) throw new UIComponentInvalidHandleException<SafeControlHandle>(this);
                text = NativeCalls.ButtonText(Handle);
                return text;
            }
            set
            {
                if (text == value) return;
                if (IsInvalid) throw new UIComponentInvalidHandleException<SafeControlHandle>(this);
                NativeCalls.ButtonSetText(Handle, value);
                text = value;
            }
        }

        /// <summary>
        /// Raises the <see cref="Click"/> event.
        /// </summary>
        protected virtual void OnClick() => Click?.Invoke();

        /// <summary>
        /// Initializes this UI component's events.
        /// </summary>
        protected sealed override void InitializeEvents()
        {
            if (IsInvalid) throw new UIComponentInvalidHandleException<SafeControlHandle>(this);
            NativeCalls.ButtonOnClicked(Handle, (button, data) => { OnClick(); }, IntPtr.Zero);
        }
    }
}