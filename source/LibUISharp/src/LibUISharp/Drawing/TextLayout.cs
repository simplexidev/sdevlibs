using System;
using static LibUISharp.Native.NativeMethods;

namespace LibUISharp.Drawing
{
    public class TextLayout : UIComponent
    {
        private bool disposed = false;

        public TextLayout(TextLayoutOptions options)
        {
            Handle = Libui.uiDrawNewTextLayout(options.Native);
            Options = options;
        }

        public TextLayoutOptions Options { get; }

        public SizeD Extents
        {
            get
            {
                Libui.uiDrawTextLayoutExtents(this, out double w, out double h);
                return new SizeD(w, h);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing && Handle != IntPtr.Zero)
                    Libui.uiDrawFreeTextLayout(this);
                disposed = true;
                base.Dispose(disposing);
            }
        }
    }
}