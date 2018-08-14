using LibUISharp.Internal;

namespace LibUISharp.Drawing
{
    /// <summary>
    /// Specifies how the interior of a closed path is filled.
    /// </summary>
    [NativeType("uiDrawFillMode")]
    public enum FillMode
    {
        /// <summary>
        /// Specifies the winding fill mode.
        /// </summary>
        Winding = 0,

        /// <summary>
        /// Specifies the alternate fill mode.
        /// </summary>
        Alternate = 1
    }
}