using LibUISharp.Internal;

namespace LibUISharp.Drawing
{
    /// <summary>
    /// Specifies whether text is left-aligned, right-aligned, or centered.
    /// </summary>
    [NativeType("uiDrawTextAlign")]
    public enum TextAlignment : long
    {
        /// <summary>
        /// Text is aligned to the left.
        /// </summary>
        Left = 0,

        /// <summary>
        /// Text is centered.
        /// </summary>
        Center = 1,

        /// <summary>
        /// Text is aligned to the right.
        /// </summary>
        Right = 2
    }
}