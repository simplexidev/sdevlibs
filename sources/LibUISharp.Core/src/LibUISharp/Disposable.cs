/***********************************************************************************************************************
 * FileName:            DisposableBase.cs
 * Copyright/License:   https://github.com/tom-corwin/libuisharp/blob/master/LICENSE.md
***********************************************************************************************************************/

using System;

namespace LibUISharp
{
    /// <summary>
    /// Provides a base implementation for extended disposable types.
    /// </summary>
    public abstract class Disposable : IDisposableEx
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Disposable"/> class.
        /// </summary>
        protected Disposable() => IsDisposed = false;

        /// <summary>
        /// Trys to free resources and perform other cleanup operations before being reclaimed by garbage collection.
        /// </summary>
        ~Disposable() => Dispose(false);

        /// <inheritdoc/>
        public event EventHandler<Disposable, EventArgs> Disposing;

        /// <inheritdoc/>
        public event EventHandler<Disposable, EventArgs> Disposed;

        /// <inheritdoc/>
        public virtual bool IsDisposed { get; protected set; }

        /// <inheritdoc/>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <inheritdoc/>
        protected virtual void OnDisposing() => Disposing?.Invoke(this, EventArgs.Empty);

        /// <inheritdoc/>
        protected virtual void OnDisposed() => Disposed?.Invoke(this, EventArgs.Empty);

        /// <inheritdoc/>
        protected virtual void ReleaseManagedResources() { }

        /// <inheritdoc/>
        protected virtual void ReleaseUnmanagedResources() { }

#pragma warning disable CA1063 // Implement IDisposable Correctly
        private void Dispose(bool disposing)
#pragma warning restore CA1063 // Implement IDisposable Correctly
        {
            OnDisposing();
            if (disposing)
                ReleaseManagedResources();
            ReleaseUnmanagedResources();
            IsDisposed = true;
            OnDisposed();
        }
#pragma warning disable IDE0079 // Remove unnecessary suppression
#pragma warning restore CA1063 // Implement IDisposable Correctly
#pragma warning restore IDE0079 // Remove unnecessary suppression
    }
}