using static LibUISharp.Native.NativeMethods;

namespace LibUISharp.Drawing
{
    public sealed class FontFamilyAttribute : TextAttribute
    {
        public FontFamilyAttribute(string family) => Handle = Libui.uiNewFamilyAttribute(family);

        public string FontFamily => Libui.uiAttributeFamily(this);
    }
}