using LibUISharp.Native.Libraries;
using System;

// uiCombobox
namespace LibUISharp
{
    /// <summary>
    /// Represents a selection control with a drop-down list that can be shown or hidden by clicking the arrow on the control.
    /// </summary>
    public class ComboBox : ComboBoxBase
    {
        private int index = -1;

        /// <summary>
        /// Creates a new instance of the <see cref="ComboBox"/> class.
        /// </summary>
        public ComboBox() : base() => InitializeEvents();

        public event EventHandler Selected;

        public int SelectedIndex
        {
            get
            {
                index = LibuiLibrary.uiComboboxSelected(Handle.DangerousGetHandle());
                return index;
            }
            set
            {
                if (index != value)
                {
                    LibuiLibrary.uiComboboxSetSelected(Handle.DangerousGetHandle(), value);
                    index = value;
                }
            }
        }

        protected virtual void OnSelected(EventArgs e) => Selected?.Invoke(this, e);

        /// <inheritdoc />
        protected sealed override void InitializeEvents() => LibuiLibrary.uiComboboxOnSelected(Handle.DangerousGetHandle(), (c, data) => { OnSelected(EventArgs.Empty); }, IntPtr.Zero);
    }
}