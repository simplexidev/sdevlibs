using System;
using LibUISharp.Internal;

namespace LibUISharp
{
    /// <summary>
    /// Represents a control that encapsulates a group of radio buttons.
    /// </summary>
    [NativeType("uiRadioButtons")]
    public class RadioButtonList : Control
    {
        private int index;

        /// <summary>
        /// Initializes a new instance of the <see cref="RadioButtonList"/> class.
        /// </summary>
        public RadioButtonList()
        {
            Handle = NativeCalls.NewRadioButtons();
            InitializeEvents();
        }

        /// <summary>
        /// Occurs when the <see cref="SelectedIndex"/> property is changed.
        /// </summary>
        public event Action SelectedIndexChanged;

        /// <summary>
        /// Gets or sets the index of the selected item in the list.
        /// </summary>
        public int SelectedIndex
        {
            get
            {
                index = NativeCalls.RadioButtonsSelected(Handle);
                return index;
            }
            set
            {
                if (index != value)
                {
                    NativeCalls.RadioButtonsSetSelected(Handle, value);
                    index = value;
                }
            }
        }

        /// <summary>
        /// Adds a radio button to the end of the list.
        /// </summary>
        /// <param name="item">The text of the radio button to be added to the end of the list.</param>
        public void Add(string item) => NativeCalls.RadioButtonsAppend(Handle, item);

        /// <summary>
        /// Adds radio buttons to the end of the list.
        /// </summary>
        /// <param name="items">The text of the radio buttons to be added to the end of the list.</param>
        public void Add(params string[] items)
        {
            if (items == null)
                Add(string.Empty);
            else
            {
                foreach (string item in items)
                {
                    Add(item);
                }
            }
        }

        /// <summary>
        /// Called when the <see cref="SelectedIndexChanged"/> event is raised.
        /// </summary>
        protected virtual void OnSelectedIndexChanged() => SelectedIndexChanged?.Invoke();

        /// <summary>
        /// Initializes this UI component's events.
        /// </summary>
        protected sealed override void InitializeEvents() => NativeCalls.RadioButtonsOnSelected(Handle, (btn, data) => { OnSelectedIndexChanged(); }, IntPtr.Zero);
    }
}