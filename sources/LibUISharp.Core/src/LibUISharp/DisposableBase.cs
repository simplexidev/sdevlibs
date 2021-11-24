/***********************************************************************************************************************
 * FileName:            DisposableBase.cs
 * Copyright/License:   https://github.com/tom-corwin/libuisharp/blob/master/LICENSE.md
***********************************************************************************************************************/

using System;

namespace LibUISharp
{
    /// <summary>
    /// Provides a base implementation for the <see cref="IDisposableEx"/> interface.
    /// </summary>
    public abstract class DisposableBase : IDisposableEx
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Disposable"/> class.
        /// </summary>
        protected DisposableBase() => IsDisposed = false;

        /// <summary>
        /// Trys to free resources and perform other cleanup operations before being reclaimed by garbage collection.
        /// </summary>
        ~DisposableBase() => Dispose(false);

        /// <summary>
        /// Occurs when an object is disposing.
        /// </summary>
        public event EventHandler<DisposableBase, EventArgs> Disposing;

        /// <summary>
        /// Occurs when an object is disposed.
        /// </summary>
        public event EventHandler<DisposableBase, EventArgs> Disposed;

        /// <summary>
        /// Determines whether this object is disposed.
        /// </summary>
        public bool IsDisposed { get; private set; }

        /// <summary>
        /// Performs tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Raises the <see cref="Disposing"/> event.
        /// </summary>
        protected virtual void OnDisposing() => Disposing?.Invoke(this, EventArgs.Empty);

        /// <summary>
        /// Raises the <see cref="Disposed"/> event.
        /// </summary>
        protected virtual void OnDisposed() => Disposed?.Invoke(this, EventArgs.Empty);

        /// <summary>
        /// Performs tasks associated with freeing, releasing, or resetting managed resources.
        /// </summary>
        protected virtual void ReleaseManagedResources() { }

        /// <summary>
        /// Performs tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        protected virtual void ReleaseUnmanagedResources() { }

        protected virtual void Dispose(bool disposing)
        {
            OnDisposing();
            if (disposing)
                ReleaseManagedResources();
            ReleaseUnmanagedResources();
            IsDisposed = true;
            OnDisposed();
        }
    }
}