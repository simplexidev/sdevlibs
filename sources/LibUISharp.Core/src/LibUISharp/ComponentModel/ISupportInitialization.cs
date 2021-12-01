/***********************************************************************************************************************
 * FileName:            ISupportInitialization.cs
 * Copyright/License:   https://github.com/tom-corwin/libuisharp/blob/master/LICENSE.md
***********************************************************************************************************************/

using System;

namespace LibUISharp.ComponentModel
{
    public interface ISupportInitialization
    {
        event EventHandler<Component, EventArgs> Initializing;
        event EventHandler<Component, EventArgs> Initialized;
        bool IsInitialized { get; }
    }
}
