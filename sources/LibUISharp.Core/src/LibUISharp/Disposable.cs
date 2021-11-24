/***********************************************************************************************************************
 * FileName:            Disposable.cs
 * Copyright/License:   https://github.com/tom-corwin/libuisharp/blob/master/LICENSE.md
***********************************************************************************************************************/

using System;

namespace LibUISharp
{
    /// <summary>
    /// Represents a simple disposable object.
    /// </summary>
    public sealed class Disposable : DisposableBase, IDisposableEx
    {
        private readonly Action releaseManagedResources;
        private readonly Action releaseUnmanagedResources;

        /// <summary>
        /// Initializes a new instance of the <see cref="Disposable"/> class.
        /// </summary>
        /// <param name="managedAction">The action to invoke during the disposal of managed resources.</param>
        /// <param name="unmanagedAction">The action to invoke during the disposal of unmanaged resources.</param>
        public Disposable(Action managedAction = null, Action unmanagedAction = null) : base()
        {
            releaseManagedResources = managedAction ?? (() => { });
            releaseUnmanagedResources = unmanagedAction ?? (() => { });
        }

        /// <inheritdoc/>
        protected override void ReleaseManagedResources() => releaseManagedResources?.Invoke();

        /// <inheritdoc/>
        protected override void ReleaseUnmanagedResources() => releaseUnmanagedResources?.Invoke();
    }
}