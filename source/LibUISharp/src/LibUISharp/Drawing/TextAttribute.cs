using System;
using System.Runtime.InteropServices;
using LibUISharp.Internal;
using LibUISharp.SafeHandles;

namespace LibUISharp.Drawing
{
    // uiAttribute
    public abstract class TextAttribute : UIComponent<SafeTextAttributeHandle>, IUIComponent
    {
        private bool disposed = false;

        internal LibuiLibrary.uiAttributeType Type => LibuiLibrary.uiAttributeGetType(Handle.DangerousGetHandle());

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

    public sealed class FontFamilyAttribute : TextAttribute
    {
        public FontFamilyAttribute(string family)
        {
            IntPtr strPtr = family.ToLibuiString();
            Handle = new SafeTextAttributeHandle(LibuiLibrary.uiNewFamilyAttribute(strPtr));
            Marshal.FreeHGlobal(strPtr);
        }

        public string FontFamily => LibuiLibrary.uiAttributeFamily(Handle.DangerousGetHandle()).ToStringEx();
    }

    public sealed class FontSizeAttribute : TextAttribute
    {
        public FontSizeAttribute(double size) => Handle = new SafeTextAttributeHandle(LibuiLibrary.uiNewSizeAttribute(size));

        public double Size => LibuiLibrary.uiAttributeSize(Handle.DangerousGetHandle());
    }

    public sealed class FontWeightAttribute : TextAttribute
    {
        public FontWeightAttribute(FontWeight weight)=> Handle = new SafeTextAttributeHandle(LibuiLibrary.uiNewWeightAttribute((LibuiLibrary.uiTextWeight)weight));

        public FontWeight FontWeight => (FontWeight)LibuiLibrary.uiAttributeWeight(Handle.DangerousGetHandle());
    }

    public sealed class FontStyleAttribute : TextAttribute
    {
        public FontStyleAttribute(FontStyle style) => Handle = new SafeTextAttributeHandle(LibuiLibrary.uiNewItalicAttribute((LibuiLibrary.uiTextItalic)style));

        public FontStyle FontStyle => (FontStyle)LibuiLibrary.uiAttributeItalic(Handle.DangerousGetHandle());
    }

    public sealed class FontStretchAttribute : TextAttribute
    {
        public FontStretchAttribute(FontStretch stretch) => Handle = new SafeTextAttributeHandle(LibuiLibrary.uiNewStretchAttribute((LibuiLibrary.uiTextStretch)stretch));

        public FontStretch FontStretch => (FontStretch)LibuiLibrary.uiAttributeItalic(Handle.DangerousGetHandle());
    }

    public sealed class ForegroundColorAttribute : TextAttribute
    {
        public ForegroundColorAttribute(Color color) => Handle = new SafeTextAttributeHandle(LibuiLibrary.uiNewColorAttribute(color.R, color.G, color.B, color.A));

        public Color Color
        {
            get
            {
                LibuiLibrary.uiAttributeColor(Handle.DangerousGetHandle(), out double r, out double g, out double b, out double a);
                return new Color(r, g, b, a);
            }
        }
    }
    public sealed class BackgroundColorAttribute : TextAttribute
    {
        public BackgroundColorAttribute(Color color)
        {
            Handle = new SafeTextAttributeHandle(LibuiLibrary.uiNewBackgroundAttribute(color.R, color.G, color.B, color.A));
            Color = color;
        }

        public Color Color
        {
            get;
            //{
            //    uiAttributeColor(Handle.DangerousGetHandle(), out double r, out double g, out double b, out double a);
            //    return new Color(r, g, b, a);
            //}
        }
    }

    public sealed class UnderlineStyleAttribute : TextAttribute
    {
        public UnderlineStyleAttribute(UnderlineStyle style) => Handle = new SafeTextAttributeHandle(LibuiLibrary.uiNewUnderlineAttribute((LibuiLibrary.uiUnderline)style));

        public UnderlineStyle UnderlineStyle => (UnderlineStyle)LibuiLibrary.uiAttributeUnderline(Handle.DangerousGetHandle());
    }

    public sealed class UnderlineColorAttribute : TextAttribute
    {
        public UnderlineColorAttribute(Color color) => Handle = new SafeTextAttributeHandle(LibuiLibrary.uiNewColorAttribute(color.R, color.G, color.B, color.A));

        public UnderlineColor UnderlineColor
        {
            get
            {
                LibuiLibrary.uiAttributeUnderline(Handle.DangerousGetHandle(), out LibuiLibrary.uiUnderlineColor u, out double r, out double g, out double b, out double a);
                return (UnderlineColor)u;
            }
        }
        public Color Color
        {
            get
            {
                LibuiLibrary.uiAttributeColor(Handle.DangerousGetHandle(), out double r, out double g, out double b, out double a);
                return new Color(r, g, b, a);
            }
        }
    }

    public sealed class FontFeaturesAttribute : TextAttribute
    {
        public FontFeaturesAttribute(FontFeatures features) => Handle = new SafeTextAttributeHandle(LibuiLibrary.uiNewFeaturesAttribute(features.Handle.DangerousGetHandle()));

        public FontFeatures FontFeatures => new FontFeatures(new SafeFontFeaturesHandle(LibuiLibrary.uiAttributeFeatures(Handle.DangerousGetHandle())));
    }
}