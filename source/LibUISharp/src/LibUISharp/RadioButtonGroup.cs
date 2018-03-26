using System;

using static LibUISharp.Internal.LibUI;

namespace LibUISharp
{
    public class RadioButtonGroup : Control
    {
        public RadioButtonGroup()
        {
            Handle = uiNewRadioButtons();
            InitializeEvents();
        }

        public event EventHandler Selected;

        private int index;
        public int SelectedIndex
        {
            get
            {
                index = uiRadioButtonsSelected(Handle);
                return index;
            }
            set
            {
                if (index != value)
                {
                    uiRadioButtonsSetSelected(Handle, value);
                    index = value;
                }
            }
        }

        public void Add(params string[] items)
        {

            if (items == null)
                uiRadioButtonsAppend(Handle, null);
            else
            {
                foreach (string s in items)
                {
                    uiRadioButtonsAppend(Handle, s);
                }
            }
        }

        protected virtual void OnSelected(EventArgs e) => Selected?.Invoke(this, e);

        protected sealed override void InitializeEvents() => uiRadioButtonsOnSelected(Handle, (btn, data) => { OnSelected(EventArgs.Empty); });
    }
}