namespace LibUISharp.Drawing
{
    /// <summary>
    /// Specifies how to join consecutive line or curve segments in a figure that are contained in a <see cref="StrokeOptions"/> object.
    /// </summary>
    public enum LineJoin : uint
    {
        /// <summary>
        /// Specifies a mitered line join.
        /// </summary>
        Miter = 0,

        /// <summary>
        /// Specifies a circular line join.
        /// </summary>
        Round = 1,

        /// <summary>
        /// Specifies a beveled line join.
        /// </summary>
        Bevel = 2
    }
}