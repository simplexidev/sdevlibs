using static LibUISharp.Native.NativeMethods;

namespace LibUISharp.Drawing
{
    public sealed class ForegroundColorAttribute : TextAttribute
    {
        public ForegroundColorAttribute(Color color) => Handle = Libui.uiNewColorAttribute(color.R, color.G, color.B, color.A);

        public Color Color
        {
            get
            {
                Libui.uiAttributeColor(this, out double r, out double g, out double b, out double a);
                return new Color(r, g, b, a);
            }
        }
    }
}