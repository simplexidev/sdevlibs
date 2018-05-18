using LibUISharp.Internal;
using LibUISharp.SafeHandles;
using System;
using System.Runtime.InteropServices;

namespace LibUISharp
{
    // uiRadioButtons
    public class RadioButtonGroup : Control
    {
        private int index;

        public RadioButtonGroup()
        {
            Handle = new SafeControlHandle(LibuiLibrary.uiNewRadioButtons());
            InitializeEvents();
        }

        public event EventHandler Selected;

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

        public void Add(params string[] items)
        {

            if (items == null)
                LibuiLibrary.uiRadioButtonsAppend(Handle.DangerousGetHandle(), IntPtr.Zero);
            else
            {
                foreach (string s in items)
                {
                    IntPtr strPtr = s.ToLibuiString();
                    LibuiLibrary.uiRadioButtonsAppend(Handle.DangerousGetHandle(), strPtr);
                    Marshal.FreeHGlobal(strPtr);
                }
            }
        }

        protected virtual void OnSelected(EventArgs e) => Selected?.Invoke(this, e);

        protected sealed override void InitializeEvents() => LibuiLibrary.uiRadioButtonsOnSelected(Handle.DangerousGetHandle(), (btn, data) => { OnSelected(EventArgs.Empty); }, IntPtr.Zero);
    }
}