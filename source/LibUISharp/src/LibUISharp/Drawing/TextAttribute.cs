using System;
using LibUISharp.Internal;
using static LibUISharp.Internal.LibUI;

namespace LibUISharp.Drawing
{
    // uiAttribute
    public abstract class TextAttribute : UIComponent
    {
        private bool disposed = false;

        internal TextAttributeSafeHandle Handle { get; set; }

        internal uiAttributeType Type => uiAttributeGetType(Handle);

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

    public sealed class FontFamilyAttribute : TextAttribute
    {
        public FontFamilyAttribute(string family) => Handle = uiNewFamilyAttribute(family);

        public string FontFamily => uiAttributeFamily(Handle);
    }

    public sealed class FontSizeAttribute : TextAttribute
    {
        public FontSizeAttribute(double size) => Handle = uiNewSizeAttribute(size);

        public double Size => uiAttributeSize(Handle);
    }

    public sealed class FontWeightAttribute : TextAttribute
    {
        public FontWeightAttribute(FontWeight weight)=> Handle = uiNewWeightAttribute((uiTextWeight)weight);

        public FontWeight FontWeight => (FontWeight)uiAttributeWeight(Handle);
    }

    public sealed class FontStyleAttribute : TextAttribute
    {
        public FontStyleAttribute(FontStyle style) => Handle = uiNewItalicAttribute((uiTextItalic)style);

        public FontStyle FontStyle => (FontStyle)uiAttributeItalic(Handle);
    }

    public sealed class FontStretchAttribute : TextAttribute
    {
        public FontStretchAttribute(FontStretch stretch) => Handle = uiNewStretchAttribute((uiTextStretch)stretch);

        public FontStretch FontStretch => (FontStretch)uiAttributeItalic(Handle);
    }

    public sealed class ForegroundColorAttribute : TextAttribute
    {
        public ForegroundColorAttribute(Color color) => Handle = uiNewColorAttribute(color.R, color.G, color.B, color.A);

        public Color Color
        {
            get
            {
                uiAttributeColor(Handle, out double r, out double g, out double b, out double a);
                return new Color(r, g, b, a);
            }
        }
    }
    public sealed class BackgroundColorAttribute : TextAttribute
    {
        public BackgroundColorAttribute(Color color)
        {
            Handle = uiNewBackgroundAttribute(color.R, color.G, color.B, color.A);
            Color = color;
        }

        public Color Color
        {
            get;
            //{
                // uiAttributeColor(Handle, out double r, out double g, out double b, out double a);
                // return new Color(r, g, b, a);
            //}
        }
    }

    public sealed class UnderlineStyleAttribute : TextAttribute
    {
        public UnderlineStyleAttribute(UnderlineStyle style) => Handle = uiNewUnderlineAttribute((uiUnderline)style);

        public UnderlineStyle UnderlineStyle => (UnderlineStyle)uiAttributeUnderline(Handle);
    }

    public sealed class UnderlineColorAttribute : TextAttribute
    {
        public UnderlineColorAttribute(Color color) => Handle = uiNewColorAttribute(color.R, color.G, color.B, color.A);

        public UnderlineColor UnderlineColor
        {
            get
            {
                uiAttributeUnderline(Handle, out uiUnderlineColor u, out double r, out double g, out double b, out double a);
                return (UnderlineColor)u;
            }
        }
        public Color Color
        {
            get
            {
                uiAttributeColor(Handle, out double r, out double g, out double b, out double a);
                return new Color(r, g, b, a);
            }
        }
    }

    public sealed class FontFeaturesAttribute : TextAttribute
    {
        public FontFeaturesAttribute(FontFeatures features) => Handle = uiNewFeaturesAttribute(features.Handle);

        public FontFeatures FontFeatures => new FontFeatures(uiAttributeFeatures(Handle));
    }
}