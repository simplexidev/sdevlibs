/***********************************************************************************************************************
 * FileName:            PropertyChangeStatus.cs
 * Copyright/License:   https://github.com/simplexidev/sdfx/blob/main/LICENSE.md
***********************************************************************************************************************/

namespace SimplexiDev.Runtime.InteropServices
{
    /// <summary>
    /// Represents the status of a property change event.
    /// </summary>
    public enum PropertyChangeStatus
    {
        /// <summary>
        /// The property is changing.
        /// </summary>
        InProgress,

        /// <summary>
        /// The proeprty has been changed.
        /// </summary>
        Completed
    }
}
