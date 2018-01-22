using System;
using System.Runtime.InteropServices;
using LibUISharp.Internal;
using static LibUISharp.Internal.UI;

namespace LibUISharp
{
    public class ComboBox : Control
    {
        public event EventHandler Selected;

        public ComboBox()
        {
            Handle = new UIControlHandle(uiNewCombobox());
            Initialize();
        }

        public void Add(params string[] text)
        {
            IntPtr strPtr;
            if (text == null)
            {
                strPtr = MarshalHelper.StringToUTF8(null);
                uiComboboxAppend(Handle.DangerousGetHandle(), strPtr);
                Marshal.FreeHGlobal(strPtr);
            } else
            {
                foreach (string s in text)
                {
                    strPtr = MarshalHelper.StringToUTF8(s);
                    uiComboboxAppend(Handle.DangerousGetHandle(), strPtr);
                    Marshal.FreeHGlobal(strPtr);
                }
            }
        }

        private int selectedIndex = -1;
        public int SelectedIndex
        {
            get => selectedIndex = uiComboboxSelected(Handle.DangerousGetHandle());
            set
            {
                if (selectedIndex != value)
                {
                    uiComboboxSetSelected(Handle.DangerousGetHandle(), value);
                    selectedIndex = value;
                }
            }
        }

        protected virtual void OnIndexSelected(EventArgs e) => Selected?.Invoke(this, e);

        protected sealed override void Initialize() =>
            uiComboboxOnSelected(Handle.DangerousGetHandle(), (box, data) => { OnIndexSelected(EventArgs.Empty); }, IntPtr.Zero);
    }
}