using static LibUISharp.Native.NativeMethods;

namespace LibUISharp.Drawing
{
    public sealed class FontStretchAttribute : TextAttribute
    {
        public FontStretchAttribute(FontStretch stretch) => Handle = Libui.uiNewStretchAttribute(stretch);

        public FontStretch FontStretch => Libui.uiAttributeStretch(this);
    }
}