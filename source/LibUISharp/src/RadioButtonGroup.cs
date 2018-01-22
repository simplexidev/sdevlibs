using System;
using System.Runtime.InteropServices;
using LibUISharp.Internal;
using static LibUISharp.Internal.UI;

namespace LibUISharp
{
    public class RadioButtonGroup : Control
    {

        public RadioButtonGroup()
        {
            Handle = new UIControlHandle(uiNewRadioButtons());
            Initialize();
        }

        private int selectedIndex;
        public int SelectedIndex
        {
            get => selectedIndex = uiRadioButtonsSelected(Handle.DangerousGetHandle());
            set
            {
                if (selectedIndex != value)
                {
                    uiRadioButtonsSetSelected(Handle.DangerousGetHandle(), value);
                    selectedIndex = value;
                }
            }
        }

        public void Add(params string[] text)
        {
            IntPtr strPtr;
            if (text == null)
            {
                strPtr = MarshalHelper.StringToUTF8(null);
                uiRadioButtonsAppend(Handle.DangerousGetHandle(), strPtr);
                Marshal.FreeHGlobal(strPtr);
            } else
            {
                foreach (string s in text)
                {
                    strPtr = MarshalHelper.StringToUTF8(s);
                    uiRadioButtonsAppend(Handle.DangerousGetHandle(), strPtr);
                    Marshal.FreeHGlobal(strPtr);
                }
            }
        }

        protected sealed override void Initialize() =>
            uiRadioButtonsOnSelected(Handle.DangerousGetHandle(), (btn, data) => { OnSelected(EventArgs.Empty); }, IntPtr.Zero);

        public event EventHandler Selected;
        protected virtual void OnSelected(EventArgs e) => Selected?.Invoke(this, e);
    }
}