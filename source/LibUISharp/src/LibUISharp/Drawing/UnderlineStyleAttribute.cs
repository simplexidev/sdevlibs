using static LibUISharp.Native.NativeMethods;

namespace LibUISharp.Drawing
{
    public sealed class UnderlineStyleAttribute : TextAttribute
    {
        public UnderlineStyleAttribute(UnderlineStyle style) => Handle = Libui.uiNewUnderlineAttribute(style);

        public UnderlineStyle UnderlineStyle => Libui.uiAttributeUnderline(this);
    }
}