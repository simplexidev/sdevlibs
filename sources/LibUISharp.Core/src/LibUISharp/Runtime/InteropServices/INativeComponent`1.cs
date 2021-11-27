/***********************************************************************************************************************
 * FileName:            INativeComponent`1.cs
 * Copyright/License:   https://github.com/tom-corwin/libuisharp/blob/master/LICENSE.md
***********************************************************************************************************************/

using LibUISharp.ComponentModel;

namespace LibUISharp.Runtime.InteropServices
{
    public interface INativeComponent<T> : IComponent where T : unmanaged
    {
        unsafe T* Handle { get; }
    }
}