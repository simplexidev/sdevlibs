using System;
using System.Runtime.InteropServices;
using LibUISharp.Internal;
using LibUISharp.SafeHandles;

namespace LibUISharp.Drawing
{
    //TODO: This isn't what this should be. Needs 100% redone.
    public class AttributedText : LibuiComponent
    {
        private bool disposed = false;

        public AttributedText(string text)
        {
            IntPtr strPtr = text.ToLibuiString();
            Handle = new SafeAttributedTextHandle(LibuiLibrary.uiNewAttributedString(strPtr));
            Marshal.FreeHGlobal(strPtr);
        }

        internal SafeAttributedTextHandle Handle { get; set; }

        public string Text => LibuiLibrary.uiAttributedStringString(Handle.DangerousGetHandle()).ToStringEx();

        public long Len() => LibuiLibrary.uiAttributedStringLen(Handle.DangerousGetHandle()).ToUInt32();

        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                    if (!Handle.IsInvalid)
                        Handle.Dispose();
                disposed = true;
            }
        }

        public override void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}