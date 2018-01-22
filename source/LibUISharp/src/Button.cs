using System;
using System.Runtime.InteropServices;
using LibUISharp.Internal;

using static LibUISharp.Internal.UI;

namespace LibUISharp
{
    public class Button : Control
    {
        public event EventHandler Click;

        public Button(string text)
        {
            this.text = text;
            IntPtr strPtr = MarshalHelper.StringToUTF8(text);
            Handle = new UIControlHandle(uiNewButton(strPtr));
            Initialize();
            Marshal.FreeHGlobal(strPtr);
        }

        private string text;
        public string Text
        {
            get => text = MarshalHelper.StringFromUTF8(uiButtonText(Handle.DangerousGetHandle()));
            set
            {
                if (text != value)
                {
                    IntPtr strPtr = MarshalHelper.StringToUTF8(value);
                    uiButtonSetText(Handle.DangerousGetHandle(), strPtr);
                    Marshal.FreeHGlobal(strPtr);
                    text = value;
                }
            }
        }

        protected sealed override void Initialize() =>
            uiButtonOnClicked(Handle.DangerousGetHandle(), (button, data) => { OnClick(EventArgs.Empty); }, IntPtr.Zero);

        protected virtual void OnClick(EventArgs e) => Click?.Invoke(this, e);
    }
}