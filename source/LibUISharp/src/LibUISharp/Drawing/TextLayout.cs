using System;
using LibUISharp.Internal;
using LibUISharp.SafeHandles;

namespace LibUISharp.Drawing
{
    // uiDrawTextLayout
    public class TextLayout : UIComponent<SafeTextLayoutHandle>, IUIComponent
    {
        private bool disposed = false;

        public TextLayout(TextLayoutOptions options)
        {
            Handle = new SafeTextLayoutHandle(LibuiLibrary.uiDrawNewTextLayout((options.ToLibuiDrawTextLayoutParams())));
            Options = options;
        }

        public TextLayoutOptions Options { get; }

        public SizeD Extents
        {
            get
            {
                LibuiLibrary.uiDrawTextLayoutExtents(Handle.DangerousGetHandle(), out double w, out double h);
                return new SizeD(w, h);
            }
        }

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

    // uiDrawTextLayoutParams
    public readonly struct TextLayoutOptions
    {
        public TextLayoutOptions(AttributedText text, Font defaultFont, double width, TextAlignment alignment)
        {
            Text = text;
            DefaultFont = defaultFont;
            Width = width;
            Alignment = alignment;
        }

        public AttributedText Text { get; }
        public Font DefaultFont { get; }
        public double Width { get; }
        public TextAlignment Alignment { get; }
    }
}