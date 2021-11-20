using System;
using static LibUISharp.Native.NativeMethods;

namespace LibUISharp
{
    /// <summary>
    /// Represents a selection control with a drop-down list that can be shown or hidden by clicking the arrow on the control.
    /// </summary>
    public class ComboBox : ComboBoxBase
    {
        private int index = -1;

        /// <summary>
        /// Initalizes a new instance of the <see cref="ComboBox"/> class.
        /// </summary>
        public ComboBox() : base()
        {
            Handle = Libui.uiNewCombobox();
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
                index = Libui.uiComboboxSelected(this);
                return index;
            }
            set
            {
                if (index != value)
                {
                    Libui.uiComboboxSetSelected(this, value);
                    index = value;
                }
            }
        }

        /// <summary>
        /// Adds a drop-down item to this control.
        /// </summary>
        /// <param name="item">The item to add to this control.</param>
        public override void Add(string item) => Libui.uiComboboxAppend(this, item);

        /// <summary>
        /// Called when the <see cref="Selected"/> event is raised.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> that contains the event data.</param>
        protected virtual void OnSelected(EventArgs e) => Selected?.Invoke(this, e);

        /// <summary>
        /// Initializes this UI component's events.
        /// </summary>
        protected sealed override void InitializeEvents() => Libui.uiComboboxOnSelected(this, (c, data) => { OnSelected(EventArgs.Empty); }, IntPtr.Zero);
    }
}