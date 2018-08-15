using LibUISharp.Internal;

namespace LibUISharp.Drawing
{
    /// <summary>
    /// Identifies the underline style of text.
    /// </summary>
    [NativeType("uiUnderline")]
    public enum UnderlineStyle : long
    {
        /// <summary>
        /// No underline.
        /// </summary>
        None = 0,

        /// <summary>
        /// A single line.
        /// </summary>
        Single = 1,

        /// <summary>
        /// A double line.
        /// </summary>
        Double = 2,

        /// <summary>
        /// A wavy or dotted line.
        /// </summary>
        Special = 3
    }
}