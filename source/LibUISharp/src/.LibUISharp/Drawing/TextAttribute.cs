using System;
using static LibUISharp.Native.NativeMethods;

namespace LibUISharp.Drawing
{
    public abstract class TextAttribute : UIComponent
    {
        private bool disposed = false;

        internal Libui.uiAttributeType Type => Libui.uiAttributeGetType(this);

        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing && Handle != IntPtr.Zero)
                    Libui.uiFreeAttribute(this);
                disposed = true;
                base.Dispose(disposing);
            }
        }
    }
}