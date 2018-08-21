using static LibUISharp.Native.NativeMethods;

namespace LibUISharp.Drawing
{
    public sealed class FontFeaturesAttribute : TextAttribute
    {
        public FontFeaturesAttribute(FontFeatures features) => Handle = Libui.uiNewFeaturesAttribute(features);

        public FontFeatures FontFeatures => new FontFeatures(Libui.uiAttributeFeatures(this));
    }
}