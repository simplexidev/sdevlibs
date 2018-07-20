using static LibUISharp.Native.NativeMethods;

namespace LibUISharp.Drawing
{
    public sealed class FontStyleAttribute : TextAttribute
    {
        public FontStyleAttribute(FontStyle style) => Handle = Libui.uiNewItalicAttribute(style);

        public FontStyle FontStyle => Libui.uiAttributeItalic(this);
    }
}