/***********************************************************************************************************************
 * FileName:            INativeComponent.cs
 * Copyright/License:   https://github.com/tom-corwin/libuisharp/blob/master/LICENSE.md
***********************************************************************************************************************/

using LibUISharp.ComponentModel;

namespace LibUISharp.Runtime.InteropServices
{
    public interface INativeComponent : IComponent
    {
        unsafe void* Handle { get; }
    }
}