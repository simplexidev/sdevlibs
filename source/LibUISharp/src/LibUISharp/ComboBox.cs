using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using static LibUISharp.Internal.LibUI;

namespace LibUISharp.Controls
{
    public abstract class ComboBoxBase : Control
    {
        protected ComboBoxBase()
        {
            if (this is ComboBox)
                Handle = uiNewCombobox();
            else if (this is EditableComboBox)
                Handle = uiNewEditableCombobox();
        }

        public void Add(params string[] items)
        {
            if (items == null)
            {
                if (this is ComboBox)
                    uiComboboxAppend(Handle, null);
                else if (this is EditableComboBox)
                    uiEditableComboboxAppend(Handle, null);
            }
            else
            {
                foreach (string s in items)
                {
                    if (this is ComboBox)
                        uiComboboxAppend(Handle, s);
                    else if (this is EditableComboBox)
                        uiEditableComboboxAppend(Handle, s);
                }
            }
        }
    }

    public class ComboBox : ComboBoxBase
    {
        public ComboBox() : base() =>  InitializeEvents();

        public event EventHandler Selected;

        private int index = -1;
        public int SelectedIndex
        {
            get
            {
                index = uiComboboxSelected(Handle);
                return index;
            }
            set
            {
                if (index != value)
                {
                    uiComboboxSetSelected(Handle, value);
                    index = value;
                }
            }
        }

        protected virtual void OnSelected(EventArgs e) => Selected?.Invoke(this, e);

        protected sealed override void InitializeEvents() => uiComboboxOnSelected(Handle, (c, data) => { OnSelected(EventArgs.Empty); });
    }

    public class EditableComboBox : ComboBoxBase
    {
        public EditableComboBox() : base() => InitializeEvents();

        public event EventHandler<TextChangedEventArgs> TextChanged;

        private string text;
        public virtual string Text
        {
            get
            {
                text = uiEditableComboboxText(Handle);
                return text;
            }
            set
            {
                if (text != value)
                {
                    uiEditableComboboxSetText(Handle, value);
                    text = value;
                }
            }
        }

        protected virtual void OnTextChanged(EventArgs e) => TextChanged?.Invoke(this, new TextChangedEventArgs(Text));

        protected sealed override void InitializeEvents() => uiEditableComboboxOnChanged(Handle, (box, data) => { OnTextChanged(EventArgs.Empty); });
    }
}