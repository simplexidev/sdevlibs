using System;
using System.Runtime.InteropServices;
using LibUISharp.Internal;
using LibUISharp.SafeHandles;

namespace LibUISharp.Drawing
{
    //TODO: This isn't what this should be. Needs 100% redone.
    public class AttributedText : UIComponent<SafeAttributedTextHandle>, IUIComponent
    {
        private bool disposed = false;

        public AttributedText(string text)
        {
            IntPtr strPtr = text.ToLibuiString();
            Handle = new SafeAttributedTextHandle(LibuiLibrary.uiNewAttributedString(strPtr));
            Marshal.FreeHGlobal(strPtr);
        }

        public string Text => LibuiLibrary.uiAttributedStringString(Handle.DangerousGetHandle()).ToStringEx();

        public uint Len() => LibuiLibrary.uiAttributedStringLen(Handle.DangerousGetHandle()).ToUInt32();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                    if (!Handle.IsInvalid)
                        Handle.Dispose();
                disposed = true;
            }
        }
    }
}