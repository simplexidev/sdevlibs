/***********************************************************************************************************************
 * FileName:            ISupportInitialization`1.cs
 * Copyright/License:   https://github.com/tom-corwin/libuisharp/blob/master/LICENSE.md
***********************************************************************************************************************/

using System;

namespace LibUISharp.ComponentModel
{
    public interface ISupportInitialization<T>
    {
        event EventHandler<T, EventArgs> Initializing;
        event EventHandler<T, EventArgs> Initialized;
        bool IsInitialized { get; }
        void StartInitialization() { }
        void EndInitialization() { }
        void OnInitializing() { }
        void OnInitialized() { }
    }
}
