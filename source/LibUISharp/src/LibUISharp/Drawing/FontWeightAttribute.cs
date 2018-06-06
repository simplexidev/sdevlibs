using static LibUISharp.Native.NativeMethods;

namespace LibUISharp.Drawing
{
    public sealed class FontWeightAttribute : TextAttribute
    {
        public FontWeightAttribute(FontWeight weight) => Handle = Libui.uiNewWeightAttribute(weight);

        public FontWeight FontWeight => Libui.uiAttributeWeight(this);
    }
}