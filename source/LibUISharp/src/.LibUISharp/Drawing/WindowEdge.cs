namespace LibUISharp.Drawing
{
    /// <summary>
    /// Specifies the edge of a <see cref="Window"/> object.
    /// </summary>
    public enum WindowEdge : long
    {
        /// <summary>
        /// Specifies the left edge of a <see cref="Window"/>.
        /// </summary>
        Left = 0,

        /// <summary>
        /// Specifies the top edge of a <see cref="Window"/>.
        /// </summary>
        Top = 1,

        /// <summary>
        /// Specifies the right edge of a <see cref="Window"/>.
        /// </summary>
        Right = 2,

        /// <summary>
        /// Specifies the bottom edge of a <see cref="Window"/>.
        /// </summary>
        Bottom = 3,

        /// <summary>
        /// Specifies the top-left left corner of a <see cref="Window"/>.
        /// </summary>
        TopLeft = 4,

        /// <summary>
        /// Specifies the top-right corner of the <see cref="Window"/>.
        /// </summary>
        TopRight = 5,

        /// <summary>
        /// Specifies the bottom-left corner of a <see cref="Window"/>.
        /// </summary>
        BottomLeft = 6,

        /// <summary>
        /// Specifies the bottom-right corner of a <see cref="Window"/>.
        /// </summary>
        BottomRight = 7
    }
}