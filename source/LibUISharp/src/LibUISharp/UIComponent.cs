using System;
using System.Collections.Generic;
using LibUISharp.Internal;
using LibUISharp.SafeHandles;

namespace LibUISharp
{
    /// <summary>
    /// The base implementation for a UI component.
    /// </summary>
    public abstract class UIComponent : IDisposable
    {
        private bool disposed = false;

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
        /// <param name="disposing">Whether or not this <see cref="UIComponent"/> is disposing.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing) { }
            disposed = true;
        }
    }

    /// <summary>
    /// The base implementation for a UI component that has a native handle.
    /// </summary>
    public abstract class UIComponent<T> : UIComponent, IEquatable<UIComponent<T>>
        where T : SafeHandleZeroIsInvalid
    {
        private T handle;
        private static Dictionary<T, UIComponent<T>> componentCache = new Dictionary<T, UIComponent<T>>();
        private bool disposed = false;

        /// <summary>
        /// Gets the handle for this <see cref="UIComponent{T}"/>.
        /// </summary>
        public T Handle
        {
            get => handle;
            internal set
            {
                handle = value;
                if (!componentCache.ContainsKey(value))
                    componentCache.Add(handle, this);
            }
        }

        internal bool IsInvalid => Handle.IsInvalid || Handle.IsClosed;

        /// <summary>
        /// Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <param name="obj">The object to compare with the current instance.</param>
        /// <returns>true if obj and this instance are the same type and represent the same value; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is UIComponent<T>))
                return false;
            return Equals((UIComponent<T>)obj);
        }

        /// <summary>
        /// Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <param name="component">The <see cref="UIComponent{T}"/> to compare with the current instance.</param>
        /// <returns><see langword="true"/> if <paramref name="component"/> and this instance are the same type and represent the same value; otherwise, <see langword="false"/>.</returns>
        public bool Equals(UIComponent<T> component) => handle == component.handle;

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode() => unchecked(HashHelper.GenerateHash(handle));

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString() => handle.DangerousGetHandle().ToString();

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <param name="disposing">Whether or not this <see cref="UIComponent{T}"/> is disposing.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing)
            {
                if (!IsInvalid)
                {
                    componentCache.Remove(handle);
                    handle.Dispose();
                }
            }
            disposed = true;
            base.Dispose(disposing);
        }
    }
}