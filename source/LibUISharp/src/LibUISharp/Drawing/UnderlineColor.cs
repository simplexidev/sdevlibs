using System;
using LibUISharp.Internal;

namespace LibUISharp.Drawing
{
    //TODO: This needs more documentation.
    /// <summary>
    /// Identifies the underline color of text.
    /// </summary>
    [NativeType("uiUnderlineColor")]
    [Serializable]
    public enum UnderlineColor : long
    {
        Custom = 0,
        Spelling = 1,
        Grammar = 2,
        Auxillary = 3
    }
}