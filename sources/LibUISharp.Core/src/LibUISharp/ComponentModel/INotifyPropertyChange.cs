/***********************************************************************************************************************
 * FileName:            INotifyPropertyChange.cs
 * Copyright/License:   https://github.com/tom-corwin/libuisharp/blob/master/LICENSE.md
***********************************************************************************************************************/

namespace LibUISharp.ComponentModel
{
    public interface INotifyPropertyChange
    {
        event EventHandler<Component, PropertyChangeEventArgs> PropertyChanging;
        event EventHandler<Component, PropertyChangeEventArgs> PropertyChanged;
    }
}
