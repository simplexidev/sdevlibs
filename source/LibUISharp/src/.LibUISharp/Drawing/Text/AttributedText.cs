using System;
using LibUISharp.Internal;
using static LibUISharp.Internal.LibUI;

namespace LibUISharp.Drawing
{
    //TODO: This isn't what this should be. Needs 100% redone.
    public class AttributedText : UIComponent
    {
        private bool disposed = false;

        public AttributedText(string text)
        {
            Handle = uiNewAttributedString(text);
        }
        
        internal AttributedTextSafeHandle Handle { get; set; }

        public string Text => uiAttributedStringString(Handle);

        public uint Len() => uiAttributedStringLen(Handle).ToUInt32();

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