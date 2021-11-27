/***********************************************************************************************************************
 * FileName:            PropertyChangeEventArgs.cs
 * Copyright/License:   https://github.com/tom-corwin/libuisharp/blob/master/LICENSE.md
***********************************************************************************************************************/

using System;

namespace LibUISharp.ComponentModel
{
    public sealed class PropertyChangeEventArgs : EventArgs
    {
        public PropertyChangeEventArgs(string? propertyName, PropertyChangeStatus status)
        {
            PropertyName = propertyName;
            Status = status;
        }
        public string? PropertyName { get; }
        public PropertyChangeStatus Status { get; }
    }
}
