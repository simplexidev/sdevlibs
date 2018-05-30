using System;

namespace LibUISharp
{
    internal interface IContainerControl<T, out TCollection>
    where T : Control
    where TCollection : ControlCollection<T>
    {
        TCollection Items { get; }
    }

    /// <summary>
    /// Represents a <see cref="Control"/> that contains a collection of child controls.
    /// </summary>
    public abstract class ContainerControl : Control { }

    /// <summary>
    /// Represents a <see cref="Control"/> that contains a collection of child controls.
    /// </summary>
    /// <typeparam name="T">The type of <see cref="Control"/>.</typeparam>
    /// <typeparam name="TCollection">The type of <see cref="ControlCollection{T}"/>.</typeparam>
    public class ContainerControl<T, TCollection> : ContainerControl, IContainerControl<T, TCollection>
        where T : Control
        where TCollection : ControlCollection<T>
    {
        private TCollection items;
        private bool disposed = false;

        /// <summary>
        /// Gets this <see cref="ContainerControl{T, TCollection}"/>'s child <see cref="Control"/> objects.
        /// </summary>
        public virtual TCollection Items
        {
            get
            {
                if (items == null)
                    items = (TCollection)Activator.CreateInstance(typeof(TCollection), this);
                return items;
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <param name="disposing">Whether or not this <see cref="Control"/> is disposing.</param>
        protected sealed override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                    items.Clear();
                disposed = true;
                base.Dispose(disposing);
            }
        }

    }
}