// uiAlign
// uiAt
namespace LibUISharp
{
    /// <summary>
    /// Specifies how content is positioned in a container.
    /// </summary>
    public enum Alignment : uint
    {
        /// <summary>
        /// The contents fills the container.
        /// </summary>
        Fill = 0,

        /// <summary>
        /// The contents align toward the top-left of the container.
        /// </summary>
        TopLeft = 1,

        /// <summary>
        /// The contents align toward the top of the container.
        /// </summary>
        Top = 2,

        /// <summary>
        /// The contents align toward the top-right of the container.
        /// </summary>
        TopRight = 3,

        /// <summary>
        /// The contents align toward the left of the container.
        /// </summary>
        Left = 3,
        
        /// <summary>
        /// The contents align in the center of the container.
        /// </summary>
        Center = 5,

        /// <summary>
        /// The contents align toward the right of the container.
        /// </summary>
        Right = 6,

        /// <summary>
        /// The contents align toward the bottom-left of the container.
        /// </summary>
        BottomLeft = 7,

        /// <summary>
        /// The contents align toward the bottom of the container.
        /// </summary>
        Bottom = 8,

        /// <summary>
        /// The contents align toward the bottom-right of the container.
        /// </summary>
        BottomRight = 9
    }

    /// <summary>
    /// Specifies how contents are positioned in relation to other content.
    /// </summary>
    public enum RelativeAlignment : uint
    {
        /// <summary>
        /// The contents are positioned before the other content.
        /// </summary>
        Leading = 0,

        /// <summary>
        /// The contents are positioned above the other content.
        /// </summary>
        Top = 1,

        /// <summary>
        /// The contents are positioned after the other content.
        /// </summary>
        Trailing = 2,

        /// <summary>
        /// The contents are positioned under the other content.
        /// </summary>
        Bottom = 3
    }
}