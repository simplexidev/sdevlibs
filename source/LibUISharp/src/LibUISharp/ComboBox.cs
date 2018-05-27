using System;
using System.Runtime.InteropServices;
using LibUISharp.Internal;
using LibUISharp.SafeHandles;

namespace LibUISharp
{
    /// <summary>
    /// Represents a base implemetation for a selection control with a drop-down list that can be shown or hidden by clicking the arrow on the control.
    /// </summary>
    public abstract class ComboBoxBase : Control
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ComboBoxBase"/> class.
        /// </summary>
        protected ComboBoxBase()
        {
            if (this is ComboBox)
                Handle = new SafeControlHandle(LibuiLibrary.uiNewCombobox());
            else if (this is EditableComboBox)
                Handle = new SafeControlHandle(LibuiLibrary.uiNewEditableCombobox());
        }

        /// <summary>
        /// Adds a drop-down item to this control.
        /// </summary>
        /// <param name="item">The item to add to this control.</param>
        public void Add(string item)
        {
            if (string.IsNullOrEmpty(item))
            {
                if (this is ComboBox)
                    LibuiLibrary.uiComboboxAppend(Handle.DangerousGetHandle(), IntPtr.Zero);
                else if (this is EditableComboBox)
                    LibuiLibrary.uiEditableComboboxAppend(Handle.DangerousGetHandle(), IntPtr.Zero);
            }
            else
            {
                IntPtr strPtr = item.ToLibuiString();
                if (this is ComboBox)
                    LibuiLibrary.uiComboboxAppend(Handle.DangerousGetHandle(), strPtr);
                else if (this is EditableComboBox)
                    LibuiLibrary.uiEditableComboboxAppend(Handle.DangerousGetHandle(), strPtr);
                Marshal.FreeHGlobal(strPtr);
            }
        }

        /// <summary>
        /// Adds drop-down items to this control.
        /// </summary>
        /// <param name="items">The items to add to this control</param>
        public void Add(params string[] items)
        {
            foreach (string s in items)
            {
                Add(s);
            }
        }
    }

    /// <summary>
    /// Represents a selection control with a drop-down list that can be shown or hidden by clicking the arrow on the control.
    /// </summary>
    public class ComboBox : ComboBoxBase
    {
        private int index = -1;

        /// <summary>
        /// Initalizes a new instance of the <see cref="ComboBox"/> class.
        /// </summary>
        public ComboBox() : base() => InitializeEvents();

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

        /// <summary>
        /// Called when the <see cref="Selected"/> event is raised.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> that contains the event data.</param>
        protected virtual void OnSelected(EventArgs e) => Selected?.Invoke(this, e);

        /// <summary>
        /// Initializes this UI component's events.
        /// </summary>
        protected sealed override void InitializeEvents() => LibuiLibrary.uiComboboxOnSelected(Handle.DangerousGetHandle(), (c, data) => { OnSelected(EventArgs.Empty); }, IntPtr.Zero);
    }

    /// <summary>
    /// Represents a selection control with a drop-down list that can be shown or hidden by clicking the arrow on the control, and can be typed into.
    /// </summary>
    public class EditableComboBox : ComboBoxBase
    {
        private string text;

        /// <summary>
        /// Initalizes a new instance of the <see cref="ComboBox"/> class.
        /// </summary>
        public EditableComboBox() : base() => InitializeEvents();

        /// <summary>
        /// Occurs when the <see cref="Text"/> property is changed.
        /// </summary>
        public event EventHandler<TextChangedEventArgs> TextChanged;

        /// <summary>
        /// Gets or sets the text of this <see cref="EditableComboBox"/>.
        /// </summary>
        public virtual string Text
        {
            get
            {
                text = LibuiLibrary.uiEditableComboboxText(Handle.DangerousGetHandle()).ToStringEx();
                return text;
            }
            set
            {
                if (text != value)
                {
                    IntPtr strPtr = value.ToLibuiString();
                    LibuiLibrary.uiEditableComboboxSetText(Handle.DangerousGetHandle(), strPtr);
                    Marshal.FreeHGlobal(strPtr);
                    text = value;
                }
            }
        }


        /// <summary>
        /// Called when the <see cref="TextChanged"/> event is raised.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> that contains the event data.</param>
        protected virtual void OnTextChanged(EventArgs e) => TextChanged?.Invoke(this, new TextChangedEventArgs(Text));

        /// <summary>
        /// Initializes this UI component's events.
        /// </summary>
        protected sealed override void InitializeEvents() => LibuiLibrary.uiEditableComboboxOnChanged(Handle.DangerousGetHandle(), (box, data) => { OnTextChanged(EventArgs.Empty); }, IntPtr.Zero);
    }
}