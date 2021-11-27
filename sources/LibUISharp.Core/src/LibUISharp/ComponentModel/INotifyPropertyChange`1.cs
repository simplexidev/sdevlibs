/***********************************************************************************************************************
 * FileName:            INotifyPropertyChange`1.cs
 * Copyright/License:   https://github.com/tom-corwin/libuisharp/blob/master/LICENSE.md
***********************************************************************************************************************/

namespace LibUISharp.ComponentModel
{
    public interface INotifyPropertyChange<T>
    {
        event EventHandler<T, PropertyChangeEventArgs> PropertyChanging;
        event EventHandler<T, PropertyChangeEventArgs> PropertyChanged;

        void OnPropertyChanging(string? propertyName = null) { }
        void OnPropertyChanged(string? propertyName = null) { }
    }
}
