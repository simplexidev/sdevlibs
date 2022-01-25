/***********************************************************************************************************************
 * FileName:            IDisposableEx.cs
 * Copyright/License:   https://github.com/simplexidev/sdfx/blob/main/LICENSE.md
***********************************************************************************************************************/

using System;

namespace SimplexiDev
{
    /// <summary>
    /// Provides added functionality on top of the <see cref="IDisposable"/> interface.
    /// </summary>
    public interface IDisposableEx : IDisposable
    {
        /// <summary>
        /// Determines whether this object is disposed.
        /// </summary>
        bool IsDisposed { get; }

        /// <summary>
        /// Occurs when an object is disposing.
        /// </summary>
        public event EventHandler<Disposable, EventArgs> Disposing;

        /// <summary>
        /// Occurs when an object is disposed.
        /// </summary>
        public event EventHandler<Disposable, EventArgs> Disposed;

        /// <summary>
        /// Safely performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources, invoking the specified action in the event of an exception.
        /// </summary>
        /// <param name="exceptionHandler">The action to be invoked in the event of an exception.</param>
        /// <returns><c>true</c> if properly disposed; otherwise, <c>false</c>.</returns>
        bool SafeDispose(Action<Exception> exceptionHandler = null)
        {
            if (this == null)
                return true;

            try
            {
                Dispose();
                return true;
            }
            catch (ObjectDisposedException)
            {
                return true;
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch (Exception ex)
#pragma warning restore CA1031 // Do not catch general exception types
            {
                exceptionHandler?.Invoke(ex);
                return false;
            }
        }
    }
}