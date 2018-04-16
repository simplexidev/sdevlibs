using LibUISharp.Native.SafeHandles;
using System;

namespace LibUISharp
{
    /// <summary>
    /// The base implementation for a Libui component.
    /// </summary>
    public abstract class LibuiComponent : IDisposable
    {
        /// <summary>
        /// Initializes a Libui component.
        /// </summary>
        protected virtual void InitializeComponent() { }

        /// <summary>
        /// Initializes a Libui component's events.
        /// </summary>
        protected virtual void InitializeEvents() { }

        /// <inheritdoc/>
        public abstract void Dispose();

        /// <inheritdoc cref="Dispose()"/>
        /// <param name="disposing">Whether or not the component is disposing.</param>
        protected abstract void Dispose(bool disposing);
    }

    /// <summary>
    /// The base inplementation for a Libui component with the specified type of <see cref="LibuiSafeHandle"/>.
    /// </summary>
    /// <typeparam name="T">The type of safe handle.</typeparam>
    public abstract class LibuiComponent<T> : LibuiComponent
        where T : LibuiSafeHandle
    {
        /// <summary>
        /// Gets the components native handle, in the form of a <see cref="LibuiSafeHandle"/>.
        /// </summary>
        internal protected abstract T Handle { get; private protected set; }
    }
}