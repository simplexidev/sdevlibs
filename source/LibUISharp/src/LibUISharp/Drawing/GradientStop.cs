using System.Runtime.InteropServices;

// uiGradientStop
namespace LibUISharp.Drawing
{
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