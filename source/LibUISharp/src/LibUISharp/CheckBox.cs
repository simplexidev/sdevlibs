using System;
using LibUISharp.Internal;
using LibUISharp.SafeHandles;

namespace LibUISharp
{
    /// <summary>
    /// Represents a control that a user can set and clear.
    /// </summary>
    [NativeType("uiCheckbox")]
    public class CheckBox : Control
    {
        private string text;
        private bool @checked = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckBox"/> class with the specified text.
        /// </summary>
        /// <param name="text">The text specified by the <see cref="CheckBox"/>.</param>
        /// <param name="checked">The state of the <see cref="CheckBox"/>.</param>
        public CheckBox(string text, bool @checked = false)
        {
            Handle = NativeCalls.NewCheckbox(text);
            Text = text;
            Checked = @checked;
            InitializeEvents();
        }

        //TODO: Maybe change this to separate Checked and Unchecked events.
        /// <summary>
        /// Occurs when the <see cref="Checked"/> property is changed.
        /// </summary>
        public event Action Toggled;

        /// <summary>
        /// Gets or sets the text shown by this <see cref="CheckBox"/>.
        /// </summary>
        public string Text
        {
            get
            {
                if (IsInvalid) throw new UIComponentInvalidHandleException<SafeControlHandle>(this);
                text = NativeCalls.CheckboxText(Handle);
                return text;
            }
            set
            {
                if (text == value) return;
                if (IsInvalid) throw new UIComponentInvalidHandleException<SafeControlHandle>(this);
                NativeCalls.CheckboxSetText(Handle, value);
                text = value;
            }
        }

        /// <summary>
        /// Gets or sets the state of this <see cref="CheckBox"/>.
        /// </summary>
        public bool Checked
        {
            get
            {
                if (IsInvalid) throw new UIComponentInvalidHandleException<SafeControlHandle>(this);
                @checked = NativeCalls.CheckboxChecked(Handle);
                return @checked;
            }
            set
            {
                if (@checked == value) return;
                if (IsInvalid) throw new UIComponentInvalidHandleException<SafeControlHandle>(this);
                NativeCalls.CheckboxSetChecked(Handle, value);
                @checked = value;
            }
        }

        /// <summary>
        /// Called when the <see cref="Toggled"/> event is raised.
        /// </summary>
        protected virtual void OnToggled() => Toggled?.Invoke();

        /// <summary>
        /// Initializes this UI component's events.
        /// </summary>
        protected sealed override void InitializeEvents()
        {
            if (IsInvalid) throw new UIComponentInvalidHandleException<SafeControlHandle>(this);
            NativeCalls.CheckboxOnToggled(Handle, (checkbox, data) => { OnToggled(); }, IntPtr.Zero);
        }
    }
}