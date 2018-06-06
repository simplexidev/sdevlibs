using static LibUISharp.Native.NativeMethods;

namespace LibUISharp.Drawing
{
    public sealed class BackgroundColorAttribute : TextAttribute
    {
        public BackgroundColorAttribute(Color color)
        {
            Handle = Libui.uiNewBackgroundAttribute(color.R, color.G, color.B, color.A);
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
}