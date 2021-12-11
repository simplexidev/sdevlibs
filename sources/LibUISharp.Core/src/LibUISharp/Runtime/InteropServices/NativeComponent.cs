/***********************************************************************************************************************
 * FileName:            NativeComponent.cs
 * Copyright/License:   https://github.com/tom-corwin/libuisharp/blob/master/LICENSE.md
***********************************************************************************************************************/

using System;
using System.Collections.Generic;

namespace LibUISharp.Runtime.InteropServices
{
    /// <summary>
    /// Represents a native object with a pointer as a handle.
    /// </summary>
    public abstract class NativeComponent : Disposable
    {
        private bool isInitialized;
        private IntPtr handle = IntPtr.Zero;
        protected static readonly Dictionary<IntPtr, NativeComponent> cache = new();

        /// <summary>
        /// Initializes a new instance of the <see cref="NativeComponent"/> class.
        /// </summary>
        /// <param name="initArgs">An array of objects representing the parameters required for initialization, defined in the derived class.</param>
        protected NativeComponent(params object[] initArgs) : base()
        {
#pragma warning disable CA2214 // Do not call overridable methods in constructors
            StartInitialization(initArgs);
            CreateHandle(initArgs);
            EndInitialization();
#pragma warning restore CA2214 // Do not call overridable methods in constructors
        }

        /// <summary>
        /// Occurs when the native hande is created.
        /// </summary>
        public event EventHandler<NativeComponent, EventArgs> HandleCreated;

        /// <summary>
        /// Occurs when the native handle is destroyed.
        /// </summary>
        public event EventHandler<NativeComponent, EventArgs> HandleDestroyed;

        /// <summary>
        /// Occurs when the <see cref="NativeComponent"/> is initializing.
        /// </summary>
        public event EventHandler<NativeComponent, EventArgs> Initializing;

        /// <summary>
        /// Occurs when the <see cref="NativeComponent"/> is initialized.
        /// </summary>
        public event EventHandler<NativeComponent, EventArgs> Initialized;

        /// <summary>
        /// Occurs when a property value is changing.
        /// </summary>
        public event EventHandler<NativeComponent, PropertyChangeEventArgs> PropertyChanging;

        /// <summary>
        /// Occurs when a property value is changed.
        /// </summary>
        public event EventHandler<NativeComponent, PropertyChangeEventArgs> PropertyChanged;

        /// <summary>
        /// The native handle for this <see cref="NativeComponent"/>.
        /// </summary>
        public IntPtr Handle
        {
            get => handle;
            protected set
            {
                if (handle != IntPtr.Zero) throw new Exception("Handle has already been created and cannot be recreated at this time. Dispose the NativeCmponent first.");
                if (handle == value) return;
                OnPropertyChanging(nameof(Handle));
                handle = value;
                cache.Add(Handle, this);
                OnPropertyChanged(nameof(Handle));
            }
        }

        /// <summary>
        /// Gets a value determining if this <see cref="NativeComponent"/> has been initialized.
        /// </summary>
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

        /// <summary>
        /// Starts the initialization process for this <see cref="NativeComponent"/>.
        /// </summary>
        /// <param name="args">An array of objects representing the parameters required for initialization, defined in the derived class.</param>
        protected virtual void StartInitialization(params object[] args) => OnInitializing();

        /// <summary>
        /// Creates the native handle for this <see cref="NativeComponent"/> instance.
        /// </summary>
        /// <param name="args">An array of objects representing the parameters required for creating the native handle, defined in the derived class.</param>
        protected virtual void CreateHandle(params object[] args) => OnHandleCreated();

        /// <summary>
        /// Destroys the native handle for this <see cref="NativeComponent"/> instance. Occurs when this object is disposed.
        /// </summary>
        protected virtual void DestroyHandle() => OnHandleDestroyed();

        /// <summary>
        /// Finishes the initialization process for this <see cref="NativeComponent"/>.
        /// </summary>
        protected virtual void EndInitialization()
        {
            IsInitialized = true;
            OnInitialized();
        }

        /// <summary>
        /// Raises the <see cref="HandleCreated"/> event.
        /// </summary>
        protected virtual void OnHandleCreated() => HandleCreated?.Invoke(this, EventArgs.Empty);

        /// <summary>
        /// Raises the <see cref="HandleDestroyed"/> event.
        /// </summary>
        protected virtual void OnHandleDestroyed() => HandleDestroyed?.Invoke(this, EventArgs.Empty);

        /// <summary>
        /// Raises the <see cref="Initializing"/> event.
        /// </summary>
        protected virtual void OnInitializing() => Initializing?.Invoke(this, EventArgs.Empty);

        /// <summary>
        /// Raises the <see cref="Initialized"/> event.
        /// </summary>
        protected virtual void OnInitialized() => Initialized?.Invoke(this, EventArgs.Empty);

        /// <summary>
        /// Raises the <see cref="PropertyChanging"/> event.
        /// </summary>
        /// <param name="propertyName">The name of the property that is changing.</param>
        protected virtual void OnPropertyChanging(string? propertyName = null) => PropertyChanging?.Invoke(this, new(propertyName, PropertyChangeStatus.InProgress));

        /// <summary>
        /// Raises the <see cref="PropertyChanged"/> event.
        /// </summary>
        /// <param name="propertyName">The name of the property that has changed.</param>
        protected virtual void OnPropertyChanged(string? propertyName = null) => PropertyChanged?.Invoke(this, new(propertyName, PropertyChangeStatus.Completed));

        /// <inheritdoc/>
        protected override void ReleaseUnmanagedResources()
        {
            cache.Remove(Handle);
            DestroyHandle();
            base.ReleaseUnmanagedResources();
        }

        /// <inheritdoc/>
        protected override void ReleaseManagedResources()
        {
            isInitialized = false;
            base.ReleaseManagedResources();
        }
    }
}