using LibUISharp.Internal;

namespace LibUISharp.Drawing
{
    /// <summary>
    /// Represents extension keys on a keyboard, including the number pad and function keys.
    /// </summary>
    [LibuiType("uiExtKey")]
    public enum ExtensionKey
    {
        /// <summary>
        /// The escape key.
        /// </summary>
        Escape = 1,

        /// <summary>
        /// The insert key on most keyboards. Equivalent to the help key on Apple keyboards.
        /// </summary>
        Insert = 2,

        /// <summary>
        /// The delete key.
        /// </summary>
        Delete = 3,

        /// <summary>
        /// The home key.
        /// </summary>
        Home = 4,

        /// <summary>
        /// The end key.
        /// </summary>
        End = 5,

        /// <summary>
        /// The page-up key.
        /// </summary>
        PageUp = 6,

        /// <summary>
        /// The page-down key.
        /// </summary>
        PageDown = 7,

        /// <summary>
        /// The up arrow key.
        /// </summary>
        Up = 8,

        /// <summary>
        /// The down arrow key.
        /// </summary>
        Down = 9,

        /// <summary>
        /// The left arrow key.
        /// </summary>
        Left = 10,

        /// <summary>
        /// The right arrow key.
        /// </summary>
        Right = 11,

        // F1..F12 are guaranteed to be consecutive.

        /// <summary>
        /// The first function key.
        /// </summary>
        F1 = 12,

        /// <summary>
        /// The second function key.
        /// </summary>
        F2 = 13,

        /// <summary>
        /// The third function key.
        /// </summary>
        F3 = 14,

        /// <summary>
        /// The fourth function key.
        /// </summary>
        F4 = 15,

        /// <summary>
        /// The fifth function key.
        /// </summary>
        F5 = 16,

        /// <summary>
        /// The sixth function key.
        /// </summary>
        F6 = 17,

        /// <summary>
        /// The seventh function key.
        /// </summary>
        F7 = 18,

        /// <summary>
        /// The eighth function key.
        /// </summary>
        F8 = 19,

        /// <summary>
        /// The ninth function key.
        /// </summary>
        F9 = 20,

        /// <summary>
        /// The tenth function key.
        /// </summary>
        F10 = 21,

        /// <summary>
        /// The eleventh function key.
        /// </summary>
        F11 = 22,

        /// <summary>
        /// The twelveth function key.
        /// </summary>
        F12 = 23,

        // Number pad keys are independent of number lock.
        // N0..N9 are guaranteed to be consecutive.

        /// <summary>
        /// The 0 number-pad key.
        /// </summary>
        N0 = 24,

        /// <summary>
        /// The 1 number-pad key.
        /// </summary>
        N1 = 25,

        /// <summary>
        /// The 2 number-pad key.
        /// </summary>
        N2 = 26,

        /// <summary>
        /// The 3 number-pad key.
        /// </summary>
        N3 = 27,

        /// <summary>
        /// The 4 number-pad key.
        /// </summary>
        N4 = 28,

        /// <summary>
        /// The 5 number-pad key.
        /// </summary>
        N5 = 29,

        /// <summary>
        /// The 6 number-pad key.
        /// </summary>
        N6 = 30,

        /// <summary>
        /// The 7 number-pad key.
        /// </summary>
        N7 = 31,

        /// <summary>
        /// The 8 number-pad key.
        /// </summary>
        N8 = 32,

        /// <summary>
        /// The 9 number-pad key.
        /// </summary>
        N9 = 33,

        /// <summary>
        /// The decimal number-pad key.
        /// </summary>
        NDot = 34,

        /// <summary>
        /// The enter number-pad key.
        /// </summary>
        NEnter = 35,

        /// <summary>
        /// The add number-pad key.
        /// </summary>
        NAdd = 36,

        /// <summary>
        /// The subtract number-pad key.
        /// </summary>
        NSubtract = 37,

        /// <summary>
        /// The multiply number-pad key.
        /// </summary>
        NMultiply = 38,

        /// <summary>
        /// The divide number-pad key.
        /// </summary>
        NDivide = 39
    }
}