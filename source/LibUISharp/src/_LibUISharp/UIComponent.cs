using System;
using System.Collections.Generic;
using LibUISharp.Internal;

namespace LibUISharp
{
    /// <summary>
    /// The base implementation for a UI component.
    /// </summary>
    public abstract class UIComponent : IEquatable<UIComponent>, IDisposable
    {
        private IntPtr handle = IntPtr.Zero;
        private bool disposed = false;
        private static Dictionary<IntPtr, UIComponent> componentCache = new Dictionary<IntPtr, UIComponent>();

        /// <summary>
        /// Gets this UI component's native handle.
        /// </summary>
        protected internal IntPtr Handle
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
        /// Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <param name="obj">The object to compare with the current instance.</param>
        /// <returns>true if obj and this instance are the same type and represent the same value; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is UIComponent))
                return false;
            return Equals((UIComponent)obj);
        }

        /// <summary>
        /// Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <param name="component">The <see cref="UIComponent"/> to compare with the current instance.</param>
        /// <returns><see langword="true"/> if <paramref name="component"/> and this instance are the same type and represent the same value; otherwise, <see langword="false"/>.</returns>
        public bool Equals(UIComponent component) => Handle == component.Handle;

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode() => unchecked(HashHelper.GenerateHash(Handle));

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString() => Handle.ToString();

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
                    componentCache.Remove(handle);
                    handle = IntPtr.Zero;
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