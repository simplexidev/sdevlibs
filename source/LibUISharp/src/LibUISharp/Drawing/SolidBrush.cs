using static LibUISharp.Native.NativeMethods;

namespace LibUISharp.Drawing
{
    /// <summary>
    /// Paints an area with a solid color.
    /// </summary>
    public sealed class SolidBrush : Brush
    {
        private Color color;

        /// <summary>
        /// Initializes a new instance of the <see cref="SolidBrush"/> class.
        /// </summary>
        public SolidBrush() => Native.Type = Libui.uiDrawBrushType.uiDrawBrushTypeSolid;

        /// <summary>
        /// Initializes a new instance of the <see cref="SolidBrush"/> class of the specified color..
        /// </summary>
        /// <param name="color">The specified color.</param>
        public SolidBrush(Color color) : this() => Color = color;

        /// <summary>
        /// Gets or sets the <see cref="Drawing.Color"/> of this <see cref="SolidBrush"/>.
        /// </summary>
        public Color Color
        {
            get
            {
                color = new Color(Native.R, Native.G, Native.B, Native.A);
                return color;
            }
            set
            {
                if (color != value)
                {
                    Native.R = value.R;
                    Native.G = value.G;
                    Native.B = value.B;
                    Native.A = value.A;
                    color = value;
                }
            }
        }
    }
}