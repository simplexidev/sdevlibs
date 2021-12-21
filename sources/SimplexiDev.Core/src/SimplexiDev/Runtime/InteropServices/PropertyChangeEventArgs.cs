/***********************************************************************************************************************
 * FileName:            PropertyChangeEventArgs.cs
 * Copyright/License:   https://github.com/simplexidev/sdfx/blob/main/LICENSE.md
***********************************************************************************************************************/

using System;

namespace SimplexiDev.Runtime.InteropServices
{
    /// <summary>
    /// Provides data for a property change event.
    /// </summary>
    public sealed class PropertyChangeEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyChangeEventArgs"/> class with the specified property name and status.
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="status"></param>
        public PropertyChangeEventArgs(string? propertyName, PropertyChangeStatus status)
        {
            PropertyName = propertyName;
            Status = status;
        }

        /// <summary>
        /// The name of the property that was changed.
        /// </summary>
        public string? PropertyName { get; }

        /// <summary>
        /// The status of the property change.
        /// </summary>
        public PropertyChangeStatus Status { get; }
    }
}
