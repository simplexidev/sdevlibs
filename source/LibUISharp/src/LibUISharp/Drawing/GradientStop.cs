using System.Runtime.InteropServices;
using static LibUISharp.Native.NativeMethods;

namespace LibUISharp.Drawing
{
    /// <summary>
    /// Represents a color inside of a gradient.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct GradientStop
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GradientStop"/> structure.
        /// </summary>
        /// <param name="pos">The specified position.</param>
        /// <param name="color">The specified color.</param>
        public GradientStop(double pos, Color color)
        {
            Position = pos;
            Color = color;
        }

        /// <summary>
        /// For most <see cref="GradientBrush"/> objects, this defines where the color stop will start or end. (0 = start, 1 = end). For <see cref="RadialGradientBrush"/> objects, 0 is the center at the start point and 1 is the circle with the outer radius and the end center.
        /// </summary>
        public double Position { get; set; }

        /// <summary>
        /// the color of the color stop.
        /// </summary>
        public Color Color { get; set; }

        internal Libui.uiDrawBrushGradientStop ToUIGradientBrush() => new Libui.uiDrawBrushGradientStop()
        {
            Pos = Position,
            R = Color.R,
            G = Color.G,
            B = Color.B,
            A = Color.A
        };
    }
}