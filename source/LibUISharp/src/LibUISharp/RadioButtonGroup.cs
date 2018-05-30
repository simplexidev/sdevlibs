using LibUISharp.Internal;
using LibUISharp.SafeHandles;
using System;
using System.Runtime.InteropServices;

namespace LibUISharp
{
    /// <summary>
    /// Represents a control that encapsulates a group of radio buttons.
    /// </summary>
    public class RadioButtonList : Control
    {
        private int index;

        /// <summary>
        /// Initializes a new instance of the <see cref="RadioButtonList"/> class.
        /// </summary>
        public RadioButtonList()
        {
            Handle = new SafeControlHandle(LibuiLibrary.uiNewRadioButtons());
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
                index = LibuiLibrary.uiRadioButtonsSelected(Handle.DangerousGetHandle());
                return index;
            }
            set
            {
                if (index != value)
                {
                    LibuiLibrary.uiRadioButtonsSetSelected(Handle.DangerousGetHandle(), value);
                    index = value;
                }
            }
        }

        /// <summary>
        /// Adds a radio button to the end of the list.
        /// </summary>
        /// <param name="item">The text of the radio button to be added to the end of the list.</param>
       public void Add(string item)
        {
            if (string.IsNullOrEmpty(item))
                LibuiLibrary.uiRadioButtonsAppend(Handle.DangerousGetHandle(), IntPtr.Zero);
            else
            {
                    IntPtr strPtr = item.ToLibuiString();
                    LibuiLibrary.uiRadioButtonsAppend(Handle.DangerousGetHandle(), strPtr);
                    Marshal.FreeHGlobal(strPtr);
            }
        }

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
        protected sealed override void InitializeEvents() => LibuiLibrary.uiRadioButtonsOnSelected(Handle.DangerousGetHandle(), (btn, data) => { OnSelectedIndexChanged(EventArgs.Empty); }, IntPtr.Zero);
    }
}