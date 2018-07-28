using System;
using LibUISharp.Internal;
using static LibUISharp.Internal.Libraries;

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
            Handle = Libui.Call<Libui.uiNewRadioButtons>()();
            InitializeEvents();
        }

        /// <summary>
        /// Occurs when the <see cref="SelectedIndex"/> property is changed.
        /// </summary>
        public event EventHandler SelectedIndexChanged;

        /// <summary>
        /// Gets or sets the index of the selected item in the list.
        /// </summary>
        public int SelectedIndex
        {
            get
            {
                index = Libui.Call<Libui.uiRadioButtonsSelected>()(this);
                return index;
            }
            set
            {
                if (index != value)
                {
                    Libui.Call<Libui.uiRadioButtonsSetSelected>()(this, value);
                    index = value;
                }
            }
        }

        /// <summary>
        /// Adds a radio button to the end of the list.
        /// </summary>
        /// <param name="item">The text of the radio button to be added to the end of the list.</param>
        public void Add(string item) => Libui.Call<Libui.uiRadioButtonsAppend>()(this, item);

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
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        protected virtual void OnSelectedIndexChanged(EventArgs e) => SelectedIndexChanged?.Invoke(this, e);

        /// <summary>
        /// Initializes this UI component's events.
        /// </summary>
        protected sealed override void InitializeEvents() => Libui.Call<Libui.uiRadioButtonsOnSelected>()(this, (btn, data) => { OnSelectedIndexChanged(EventArgs.Empty); }, IntPtr.Zero);
    }
}