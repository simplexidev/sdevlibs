using System;
using LibUISharp.Internal;
using static LibUISharp.Internal.Libraries;

namespace LibUISharp
{
    /// <summary>
    /// Represents a selection control with a drop-down list that can be shown or hidden by clicking the arrow on the control.
    /// </summary>
    [LibuiType("uiCombobox")]
    public class ComboBox : Control
    {
        private int index = -1;

        /// <summary>
        /// Initalizes a new instance of the <see cref="ComboBox"/> class.
        /// </summary>
        public ComboBox()
        {
            Handle = Libui.Call<Libui.uiNewCombobox>()();
            InitializeEvents();
        }

        /// <summary>
        /// Occurs when a drop-down item is selected.
        /// </summary>
        public event EventHandler Selected;

        /// <summary>
        /// Gets or sets the selected item by index.
        /// </summary>
        public int SelectedIndex
        {
            get
            {
                index = Libui.Call<Libui.uiComboboxSelected>()(this);
                return index;
            }
            set
            {
                if (index != value)
                {
                    Libui.Call<Libui.uiComboboxSetSelected>()(this, value);
                    index = value;
                }
            }
        }

        /// <summary>
        /// Adds a drop-down item to this <see cref="ComboBox"/>.
        /// </summary>
        /// <param name="item">The item to add to this control.</param>
        public void Add(string item) => Libui.Call<Libui.uiComboboxAppend>()(this, item);

        /// <summary>
        /// Adds drop-down items to this <see cref="ComboBox"/>.
        /// </summary>
        /// <param name="items">The items to add to this control</param>
        public void Add(params string[] items)
        {
            foreach (string s in items)
            {
                Add(s);
            }
        }

        /// <summary>
        /// Called when the <see cref="Selected"/> event is raised.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> that contains the event data.</param>
        protected virtual void OnSelected(EventArgs e) => Selected?.Invoke(this, e);

        /// <summary>
        /// Initializes this UI component's events.
        /// </summary>
        protected sealed override void InitializeEvents() => Libui.Call<Libui.uiComboboxOnSelected>()(this, (c, data) => { OnSelected(EventArgs.Empty); }, IntPtr.Zero);
    }
}