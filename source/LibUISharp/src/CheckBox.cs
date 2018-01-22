using System;
using System.Runtime.InteropServices;
using LibUISharp.Internal;
using static LibUISharp.Internal.UI;

namespace LibUISharp
{
    public class CheckBox : Control
    {
        public event EventHandler Checked;
        public event EventHandler UnChecked;

        public CheckBox(string text)
        {
            IntPtr strPtr = MarshalHelper.StringToUTF8(text);
            Handle = new UIControlHandle(uiNewCheckbox(MarshalHelper.StringToUTF8(text)));
            Initialize();
            Marshal.FreeHGlobal(strPtr);
        }

        public string Text
        {
            get => MarshalHelper.StringFromUTF8(uiCheckboxText(Handle.DangerousGetHandle()));
            set
            {
                IntPtr strPtr = MarshalHelper.StringToUTF8(value);
                uiCheckboxSetText(Handle.DangerousGetHandle(), strPtr);
                Marshal.FreeHGlobal(strPtr);
            }
        }

        public bool IsChecked
        {
            get => uiCheckboxChecked(Handle.DangerousGetHandle());
            set => uiCheckboxSetChecked(Handle.DangerousGetHandle(), value);
        }

        protected sealed override void Initialize() => 
            uiCheckboxOnToggled(Handle.DangerousGetHandle(), (checkbox, data) => { OnToggle(EventArgs.Empty); }, IntPtr.Zero);

        protected virtual void OnToggle(EventArgs e)
        {
            if (IsChecked)
                Checked?.Invoke(this, e);
            else
                UnChecked?.Invoke(this, e);
        }
    }
}