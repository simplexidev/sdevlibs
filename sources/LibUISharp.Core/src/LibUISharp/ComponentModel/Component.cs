/***********************************************************************************************************************
 * FileName:            Component.cs
 * Copyright/License:   https://github.com/tom-corwin/libuisharp/blob/master/LICENSE.md
***********************************************************************************************************************/

using System;

namespace LibUISharp.ComponentModel
{
    /// <summary>
    /// Provides a base implentation for objects with initialization and property change events.
    /// </summary>
    public abstract class Component : Disposable, IComponent
    {
        private bool isInitialized;

        protected Component() { }

        /// <inheritdoc/>
        public bool IsInitialized
        {
            get => isInitialized;
            private set
            {
                if (isInitialized == value) return;
                OnPropertyChanging(nameof(IsInitialized));
                isInitialized = value;
                OnPropertyChanged(nameof(IsInitialized));
            }
        }

        /// <inheritdoc/>
        public override bool IsDisposed
        {
            get => base.IsDisposed;
            protected set
            {
                if (base.IsDisposed == value) return;
                OnPropertyChanging(nameof(IsDisposed));
                base.IsDisposed = value;
                OnPropertyChanged(nameof(IsDisposed));
            }
        }

        /// <inheritdoc/>
        public event EventHandler<Component, PropertyChangeEventArgs> PropertyChanging;

        /// <inheritdoc/>
        public event EventHandler<Component, PropertyChangeEventArgs> PropertyChanged;

        /// <inheritdoc/>
        public event EventHandler<Component, EventArgs> Initializing;

        /// <inheritdoc/>
        public event EventHandler<Component, EventArgs> Initialized;

        /// <inheritdoc/>
        public virtual void StartInitialization() => Initializing(this, EventArgs.Empty);

        /// <inheritdoc/>
        public virtual void EndInitialization() => Initialized?.Invoke(this, EventArgs.Empty);

        /// <inheritdoc/>
        protected override void ReleaseManagedResources() => isInitialized = false;

        /// <inheritdoc/>
        protected virtual void OnPropertyChanging(string? propertyName = null) => PropertyChanging?.Invoke(this, new(propertyName, PropertyChangeStatus.InProgress));

        /// <inheritdoc/>
        protected virtual void OnPropertyChanged(string? propertyName = null) => PropertyChanged?.Invoke(this, new(propertyName, PropertyChangeStatus.Completed));

        /// <inheritdoc/>
        protected virtual void OnInitializing() => Initializing?.Invoke(this, EventArgs.Empty);

        /// <inheritdoc/>
        protected virtual void OnInitialized() => Initialized?.Invoke(this, EventArgs.Empty);
    }
}
