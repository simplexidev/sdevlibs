/***********************************************************************************************************************
 * FileName:            IDisposableEx.cs
 * Copyright/License:   https://github.com/tom-corwin/libuisharp/blob/master/LICENSE.md
***********************************************************************************************************************/

using System;

namespace LibuISharp
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
        /// Safely performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources, invoking the specified action in the event of an exception.
        /// </summary>
        /// <param name="exceptionHandler">The action to be invoked in the event of an exception.</param>
        /// <returns><c>true</c> if properly disposed; otherwise, <c>false</c>.</returns>
        [SuppressMessage("Design", "CA1031:Do not catch general exception types")]
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
            catch (Exception ex)
            {
                exceptionHandler?.Invoke(ex);
                return false;
            }
        }

        /// <summary>
        /// Performs tasks associated with freeing, releasing, or resetting managed resources.
        /// </summary>
        void ReleaseManagedResources() { }

        /// <summary>
        /// Performs tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        void ReleaseUnmanagedResources() { }
    }
}