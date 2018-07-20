using System;
using static LibUISharp.Native.NativeMethods;

namespace LibUISharp.Drawing
{
    //TODO: This is a WIP, mostly just a dummy class for now.
    public class AttributedText : UIComponent
    {
        private bool disposed = false;

        public AttributedText(string text) => Handle = Libui.uiNewAttributedString(text);

        public string Text => Libui.uiAttributedStringString(this);

        public long Len() => Libui.uiAttributedStringLen(this).ToUInt32();

        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing && Handle != IntPtr.Zero)
                    Libui.uiFreeAttributedString(this);
                disposed = true;
                base.Dispose(disposing);
            }
        }
    }
}