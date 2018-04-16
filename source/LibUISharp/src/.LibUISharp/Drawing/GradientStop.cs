using System.Runtime.InteropServices;

namespace LibUISharp.Drawing
{
    // uiGradientStop
    [StructLayout(LayoutKind.Sequential)]
    public struct GradientStop
    {
        public GradientStop(double pos, Color color)
        {
            Position = pos;
            Color = color;
        }
        public double Position { get; set; }
        public Color Color { get; set; }
    }
}
