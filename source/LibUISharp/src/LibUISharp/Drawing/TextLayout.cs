using System;
using LibUISharp.Internal;
using static LibUISharp.Internal.LibUI;

namespace LibUISharp.Drawing.Text
{
    // uiDrawTextLayout
    public class TextLayout : IDisposable
    {
        private bool disposed = false;

        public TextLayout(TextLayoutOptions options)
        {
            Handle = uiDrawNewTextLayout((uiDrawTextLayoutParams)options);
            Options = options;
        }

        public TextLayoutOptions Options { get; }
        internal TextLayoutSafeHandle Handle { get; set; }

        public SizeD Extents
        {
            get
            {
                uiDrawTextLayoutExtents(Handle, out double w, out double h);
                return new SizeD(w, h);
            }
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

        public virtual void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

    // uiDrawTextLayoutParams
    public readonly struct TextLayoutOptions
    {
        public AttributedText Text { get; }
        public Font DefaultFont { get; }
        public double Width { get; }
        public TextAlignment Alignment { get; }
    }
}