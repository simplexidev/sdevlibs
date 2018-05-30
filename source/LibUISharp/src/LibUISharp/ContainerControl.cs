using System;
using System.Collections;
using System.Collections.Generic;

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

    /// <summary>
    /// Represents a collection of child <see cref="Control"/> objects inside of a <see cref="ContainerControl"/>.
    /// </summary>
    /// <typeparam name="T">The type of <see cref="Control"/> in this collection.</typeparam>
    public class ControlCollection<T> : ICollection, ICollection<T>, IEnumerable, ICloneable
        where T : Control
    {
        private readonly int defaultCapacity = 4;
        private readonly int gFactor = 2;
        private bool isReadOnly = false;
        private T[] controls;
        private int size;

        /// <summary>
        /// Initializes a new instance of the <see cref="ControlCollection{T}"/> class with the specified owner.
        /// </summary>
        /// <param name="owner">The owner <see cref="Control"/> of this <see cref="ControlCollection{T}"/>.</param>
        public ControlCollection(Control owner) => Owner = owner ?? throw new ArgumentNullException(nameof(owner));

        internal ControlCollection(Control owner, int defaultCapacity, int growFactor) : this(owner)
        {
            this.defaultCapacity = defaultCapacity;
            gFactor = growFactor;
        }

        /// <summary>
        /// Adds a <see cref="Control"/> to the end of the <see cref="ControlCollection{T}"/>.
        /// </summary>
        /// <param name="child">The <see cref="Control"/> to be added to the end of the <see cref="ControlCollection{T}"/>.</param>
        public virtual void Add(T child)
        {
            if (child == null) throw new ArgumentNullException(nameof(child));
            if (child.TopLevel) throw new ArgumentException("Cannot add a top-level control to a ControlCollection.");

            if (controls == null)
                controls = new T[defaultCapacity];
            else if (size >= controls.Length)
            {
                T[] array = new T[controls.Length * gFactor];
                Array.Copy(controls, array, controls.Length);
                controls = array;
            }

            child.Index = size;
            child.Parent = Owner;
            controls[size] = child;
            //TODO: Owner.UpdateLayout();
            size++;
        }

        /// <summary>
        /// Ads an item to the <see cref="ControlCollection{TContainer}"/> at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which item should be inserted.</param>
        /// <param name="item">The <see cref="Control"/> to insert into the <see cref="ControlCollection{T}"/>.</param>
        public virtual void AddAt(int index, T child)
        {
            if (child == null) throw new ArgumentNullException(nameof(child));
            if (index < 0 || index > size) throw new ArgumentOutOfRangeException(nameof(index));

            if (controls == null)
                controls = new T[defaultCapacity];
            else if (size >= controls.Length)
            {
                T[] array = new T[controls.Length * gFactor];
                Array.Copy(controls, array, index);
                array[index] = child;
                Array.Copy(controls, index, array, index + 1, size - index);
                controls = array;
            }
            else if (index < size)
                Array.Copy(controls, index, controls, index + 1, size - index);

            child.Index = index;
            child.Parent = Owner;
            controls[size] = child;
            size++;
        }

        /// <summary>
        /// Removes all elements from the <see cref="ControlCollection{T}"/>.
        /// </summary>
        public virtual void Clear()
        {
            if (controls != null)
            {
                for (int i = size - 1; 1 >= 0; i--)
                {
                    RemoveAt(i);
                }
            }
            //TODO: Owner.UpdateLayout();
        }

        /// <summary>
        /// Determines whether a <see cref="Control"/> is in the <see cref="ControlCollection{T}"/>.
        /// </summary>
        /// <param name="item">The <see cref="Control"/> to locate in the <see cref="ControlCollection{T}"/>.</param>
        /// <returns>true if item is found in the <see cref="ControlCollection{T}"/>; otherwise, false.</returns>
        public virtual bool Contains(T c)
        {
            if (controls == null || c == null)
                return false;

            for (int i = 0; i < size; i++)
            {
                if (ReferenceEquals(c, controls[i]))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Gets the number of elements contained in the <see cref="ControlCollection{T}"/>.
        /// </summary>
        public virtual int Count => size;

        /// <summary>
        /// Gets this <see cref="ControlCollection{T}"/>'s owner <see cref="Control">.
        /// </summary>
        protected Control Owner { get; }

        /// <summary>
        /// Determines the index of a specific value in the <see cref="ControlCollection{T}"/>.
        /// </summary>
        /// <param name="value">The <see cref="Control"/> to locate in the <see cref="ControlCollection{T}"/>.</param>
        /// <returns>The index of item if found in the list; otherwise, -1.</returns>
        public virtual int IndexOf(T value)
        {
            if (controls == null)
                return -1;
            return Array.IndexOf(controls, value, 0, size);
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns><see cref="IEnumerator{T}"/> object that can be used to iterate through the collection.</returns>
        public virtual IEnumerator<T> GetEnumerator() => new ControlCollectionEnumerator(this);

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>An <see cref="IEnumerator"/> object that can be used to iterate through the collection.</returns>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <summary>
        /// Copies the entire <see cref="ControlCollection{T}"/> to a compatible one-dimensional array, starting at the specified index of the target array.
        /// </summary>
        /// <param name="array">The one-dimensional <see cref="Array"/> that is the destination of the elements copied from <see cref="ControlCollection{T}"/>. The <see cref="Array"/> must have zero-based indexing.</param>
        /// <param name="index">The zero-based index in <paramref name="array"/> at which copying begins.</param>
        public virtual void CopyTo(Array array, int index)
        {
            if (controls == null)
                return;
            if ((array != null) && (array.Rank != 1))
                throw new ArgumentException("array must be 1-dimensional.", nameof(array));

            Array.Copy(controls, 0, array, index, size);
        }

        /// <summary>
        /// Copies the entire <see cref="ControlCollection{T}"/> to a compatible one-dimensional array, starting at the specified index of the target array.
        /// </summary>
        /// <param name="array">The one-dimensional <see cref="Array"/> that is the destination of the elements copied from <see cref="ControlCollection{T}"/>. The <see cref="Array"/> must have zero-based indexing.</param>
        /// <param name="index">The zero-based index in <paramref name="array"/> at which copying begins.</param>
        public virtual void CopyTo(T[] array, int index) => CopyTo(array, index);
        
        /// <summary>
        /// Gets a value indicating whether the <see cref="ControlCollection{T}"/> is read-only.
        /// </summary>
        public bool IsReadOnly => isReadOnly == false;

        internal void SetReadOnly(bool readOnly)
        {
            if (isReadOnly != readOnly)
                isReadOnly = readOnly;
        }

        /// <summary>
        /// Gets a value indicating whether access to the <see cref="ControlCollection{T}"/> is synchronized (thread safe).
        /// </summary>
        public bool IsSynchronized => false;
        
        /// <summary>
        /// Gets an object that can be used to synchronize access to the <see cref="ControlCollection{T}"/>
        /// </summary>
        public object SyncRoot => this;

        /// <summary>
        /// Removes the <see cref="ControlCollection{T}"/> item at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the item to remove.</param>
        public virtual void RemoveAt(int index)
        {
            if (isReadOnly) throw new NotSupportedException("Cannot remove items while the collection is read-only.");

            T child = this[index];
            size--;
            child.Index = -1;
            child.Parent = null;
            if (index < size)
                Array.Copy(controls, index + 1, controls, index, size - 1);
            controls[size] = default;
            child.Dispose();
        }

        /// <summary>
        /// Removes the first occurrence of a specific <see cref="T"/> from the <see cref="ControlCollection{T}"/>.
        /// </summary>
        /// <param name="item">The <see cref="Control"/> to remove from the <see cref="ControlCollection{T}"/>.</param>
        /// <returns>true if item is successfully removed; otherwise, false. This method also returns false if item was not found in the <see cref="ControlCollection{T}"/>.</returns>
        public virtual bool Remove(T value)
        {
            if (!Contains(value))
                return false;

            int index = IndexOf(value);
            if (index >= 0)
            {
                RemoveAt(index);
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>A new object that is a copy of this instance.</returns>
        public object Clone() => MemberwiseClone();

        /// <summary>
        /// Gets or sets the element at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the element to get or set.</param>
        /// <returns>The element at the specified index.</returns>
        public virtual T this[int index]
        {
            get
            {
                if (index < 0 || index >= size) throw new ArgumentOutOfRangeException(nameof(index));
                return controls[index];
            }
        }

        private sealed class ControlCollectionEnumerator : IEnumerator, IEnumerator<T>, ICloneable
        {
            private ControlCollection<T> collection;
            private T current;
            private int index;
            private bool disposed = false;

            internal ControlCollectionEnumerator(ControlCollection<T> collection)
            {
                this.collection = collection;
                index = -1;
            }

            public bool MoveNext()
            {
                if (index < (collection.Count - 1))
                {
                    index++;
                    current = collection[index];
                    return true;
                }

                index = collection.Count;
                return false;
            }

            object IEnumerator.Current => Current;

            public T Current
            {
                get
                {
                    if (index == -1 || index >= collection.Count) throw new InvalidOperationException("index is out of range.");
                    return current;
                }
            }

            public void Reset()
            {
                current = default;
                index = -1;
            }

            public object Clone() => MemberwiseClone();
            
            public void Dispose() => Dispose(true);

            void Dispose(bool disposing)
            {
                if (!disposed)
                {
                    if (disposing)
                        collection.Clear();
                    disposed = true;
                }
            }
        }
    }
}