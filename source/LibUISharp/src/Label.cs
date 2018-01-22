using System;
using System.Runtime.InteropServices;
using LibUISharp.Internal;
using static LibUISharp.Internal.UI;

namespace LibUISharp
{
    public class Label : Control
    {
        public Label(string text)
        {
            this.text = text;
            IntPtr strPtr = MarshalHelper.StringToUTF8(text);
            Handle = new UIControlHandle(uiNewLabel(strPtr));
            Marshal.FreeHGlobal(strPtr);
        }

        private string text;
        public string Text
        {
            get => text = MarshalHelper.StringFromUTF8(uiLabelText(Handle.DangerousGetHandle()));
            set
            {
                if (text != value)
                {
                    IntPtr strPtr = MarshalHelper.StringToUTF8(value);
                    uiLabelSetText(Handle.DangerousGetHandle(), strPtr);
                    Marshal.FreeHGlobal(strPtr);
                    text = value;
                }
            }
        }
    }
}