using static LibUISharp.Native.NativeMethods;

namespace LibUISharp.Drawing
{
    public sealed class FontSizeAttribute : TextAttribute
    {
        public FontSizeAttribute(double size) => Handle = Libui.uiNewSizeAttribute(size);

        public double Size => Libui.uiAttributeSize(this);
    }
}