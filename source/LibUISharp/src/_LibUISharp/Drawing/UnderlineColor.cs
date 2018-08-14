using LibUISharp.Internal;

namespace LibUISharp.Drawing
{
    /// <summary>
    /// Identifies the underline color of text.
    /// </summary>
    [NativeType("uiUnderlineColor")]
    public enum UnderlineColor : long
    {
        Custom = 0,
        Spelling = 1,
        Grammar = 2,
        Auxillary = 3
    }
}