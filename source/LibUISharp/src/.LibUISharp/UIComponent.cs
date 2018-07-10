using System;
using System.Collections.Generic;

namespace LibUISharp
{
    /// <summary>
    /// The base implementation for a UI component.
    /// </summary>
    public abstract class UIComponent : IDisposable
    {
        private IntPtr handle = IntPtr.Zero;
        private bool disposed = false;
        private Dictionary<IntPtr, UIComponent> componentCache = new Dictionary<IntPtr, UIComponent>();

        /// <summary>
        /// Gets this control's native handle.
        /// </summary>
        internal protected IntPtr Handle
        {
            get => handle;
            private protected set
            {
                handle = value;
                componentCache.Add(handle, this);
            }
        }

        /// <summary>
        /// Initializes this UI component.
        /// </summary>
        protected virtual void InitializeComponent() { }

        /// <summary>
        /// Initializes this UI component's events.
        /// </summary>
        protected virtual void InitializeEvents() { }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <param name="disposing">Whether or not this control is disposing.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing && handle != IntPtr.Zero)
                {
                    componentCache.Remove(this);
                    Handle = IntPtr.Zero;
                }
                disposed = true;
            }
        }

        /// <summary>
        /// Converts the specified <see cref="UIComponent"/> object to a <see cref="IntPtr"/> structure.
        /// </summary>
        /// <param name="c">The <see cref="UIComponent"/> to be converted.</param>
        /// <returns>The <see cref="IntPtr"/> that results from the conversion.</returns>
        public static implicit operator IntPtr(UIComponent c) => c.Handle;
    }
}