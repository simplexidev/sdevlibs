/***********************************************************************************************************************
 * FileName:            IComponent.cs
 * Copyright/License:   https://github.com/tom-corwin/libuisharp/blob/master/LICENSE.md
***********************************************************************************************************************/

namespace LibUISharp.ComponentModel
{
    public interface IComponent : IDisposableEx, INotifyPropertyChange<Component>, ISupportInitialization<Component> { }
}
