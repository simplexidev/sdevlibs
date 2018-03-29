using System;
using LibUISharp.Internal;
using static LibUISharp.Internal.LibUI;

namespace LibUISharp.Drawing
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

    // uiDrawTextAlign
    public enum TextAlignment : uint
    {
        Left = 0,
        Center = 1,
        Right = 2
    }

    // uiFontDescriptor
    public readonly struct Font
    {
        public string Family { get; }
        public double Size { get; }
        public FontWeight Weight { get; }
        public FontItalic Italic { get; }
        public FontStretch Stretch { get; }
    }

    // uiTextWeight
    public enum FontWeight : uint
    {
        Minimum = 0,
        Thin = 100,
        UltraLight = 200,
        Light = 300,
        Book = 350,
        Normal = 400,
        Medium = 500,
        SemiBold = 600,
        Bold = 700,
        UltraBold = 800,
        Heavy = 900,
        UltraHeavy = 950,
        Maximum = 1000
    }

    // uiTextItalic
    public enum FontItalic : uint
    {
        Normal,
        Oblique,
        Italic
    }

    // uiTextStretch
    public enum FontStretch : uint
    {
        UltraCondensed,
        ExtraCondensed,
        Condensed,
        SemiCondensed,
        Normal,
        SemiExpanded,
        Expanded,
        ExtraExpanded,
        UltraExpanded
    }
}