using System;
using LibUISharp.Internal;
using LibUISharp.SafeHandles;

namespace LibUISharp
{
    /// <summary>
    /// Represents a selection control with a drop-down list that can be shown or hidden by clicking the arrow on the control.
    /// </summary>
    [NativeType("uiCombobox")]
    public class ComboBox : Control
    {
        private int index = 0;

        /// <summary>
        /// Initalizes a new instance of the <see cref="ComboBox"/> class.
        /// </summary>
        public ComboBox(string[] items = null, int startIndex = 0)
        {
            Handle = NativeCalls.NewCombobox();
            if (items != null && items.Length > 0)
                Add(items);
            SelectedIndex = startIndex;
            InitializeEvents();
        }

        /// <summary>
        /// Occurs when a drop-down item is selected.
        /// </summary>
        public event Action Selected;

        /// <summary>
        /// Gets or sets the selected item by index.
        /// </summary>
        public int SelectedIndex
        {
            get
            {
                if (IsInvalid) throw new UIComponentInvalidHandleException<SafeControlHandle>(this);
                index = NativeCalls.ComboboxSelected(Handle);
                return index;
            }
            set
            {
                if (index == value) return;
                if (IsInvalid) throw new UIComponentInvalidHandleException<SafeControlHandle>(this);
                NativeCalls.ComboboxSetSelected(Handle, value);
                index = value;
            }
        }

        /// <summary>
        /// Adds a drop-down item to this <see cref="ComboBox"/>.
        /// </summary>
        /// <param name="item">The item to add to this control.</param>
        public void Add(string item)
        {
            if (IsInvalid) throw new UIComponentInvalidHandleException<SafeControlHandle>(this);
            NativeCalls.ComboboxAppend(Handle, item);
        }

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
        protected virtual void OnSelected() => Selected?.Invoke();

        /// <summary>
        /// Initializes this UI component's events.
        /// </summary>
        protected sealed override void InitializeEvents()
        {

            if (IsInvalid) throw new UIComponentInvalidHandleException<SafeControlHandle>(this);
            NativeCalls.ComboboxOnSelected(Handle, (c, data) => { OnSelected(); }, IntPtr.Zero);
        }
    }
}