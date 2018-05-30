using System;
using System.Collections;
using System.Collections.Generic;

namespace LibUISharp
{
    /// <summary>
    /// Defines methods to maniplulate collections of <see cref="Control"/> object.
    /// </summary>
    /// <typeparam name="T">The type of <see cref="Control"/> in this collection.</typeparam>
    internal interface IControlCollection<T> : ICollection, ICollection<T>, IEnumerable, IEnumerable<T> { }

    /// <summary>
    /// Represents a collection of child <see cref="Control"/> objects inside of a <see cref="ContainerControl"/>.
    /// </summary>
    /// <typeparam name="T">The type of <see cref="Control"/> in this collection.</typeparam>
    public abstract class ControlCollection<T> : IControlCollection<T>
        where T : Control
    {
        private readonly int defaultCapacity = 4;
        private readonly int growFactor = 2;
        private bool isReadOnly = false;
        private T[] innerArray;
        private int size;

        /// <summary>
        /// Initializes a new instance of the <see cref="ControlCollection{T}"/> class with the specified owner.
        /// </summary>
        /// <param name="owner">The owner <see cref="Control"/> of this <see cref="ControlCollection{T}"/>.</param>
        protected ControlCollection(Control owner) => Owner = owner ?? throw new ArgumentNullException(nameof(owner));

        internal ControlCollection(Control owner, int defaultCapacity, int growFactor) : this(owner)
        {
            this.defaultCapacity = defaultCapacity;
            this.growFactor = growFactor;
        }

        /// <summary>
        /// Gets this <see cref="ControlCollection{T}"/>'s owner <see cref="Control"/>.
        /// </summary>
        protected Control Owner { get; }

        /// <summary>
        /// Gets the number of elements contained in the <see cref="ControlCollection{T}"/>.
        /// </summary>
        public int Count { get; }

        /// <summary>
        /// Gets a value indicating whether the <see cref="ControlCollection{T}"/> is read-only.
        /// </summary>
        public bool IsReadOnly => isReadOnly == false;

        /// <summary>
        /// Gets a value indicating whether access to the <see cref="ControlCollection{T}"/> is synchronized (thread safe).
        /// </summary>
        public bool IsSynchronized => false;

        /// <summary>
        /// Gets an object that can be used to synchronize access to the <see cref="ControlCollection{T}"/>
        /// </summary>
        public object SyncRoot => this;

        /// <summary>
        /// Adds a <see cref="Control"/> to the end of the <see cref="ControlCollection{T}"/>.
        /// </summary>
        /// <param name="child">The <see cref="Control"/> to be added to the end of the <see cref="ControlCollection{T}"/>.</param>
        protected virtual void Add(T child)
        {
            if (child == null) throw new ArgumentNullException(nameof(child));
            if (child.TopLevel) throw new ArgumentException("Cannot add a top-level control to a ControlCollection.");

            if (innerArray == null)
                innerArray = new T[defaultCapacity];
            else if (size >= innerArray.Length)
            {
                T[] array = new T[innerArray.Length * growFactor];
                Array.Copy(innerArray, array, innerArray.Length);
                innerArray = array;
            }

            child.Index = size;
            child.Parent = Owner;
            innerArray[size] = child;
            //TODO: Owner.UpdateLayout();
            size++;
        }

        /// <summary>
        /// Adds a control to the <see cref="ControlCollection{T}"/> at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which item should be inserted.</param>
        /// <param name="child">The <see cref="Control"/> to insert into the <see cref="ControlCollection{T}"/>.</param>
        protected virtual void AddAt(int index, T child)
        {
            if (child == null) throw new ArgumentNullException(nameof(child));
            if (index < 0 || index > size) throw new ArgumentOutOfRangeException(nameof(index));

            if (innerArray == null)
                innerArray = new T[defaultCapacity];
            else if (size >= innerArray.Length)
            {
                T[] array = new T[innerArray.Length * growFactor];
                Array.Copy(innerArray, array, index);
                array[index] = child;
                Array.Copy(innerArray, index, array, index + 1, size - index);
                innerArray = array;
            }
            else if (index < size)
                Array.Copy(innerArray, index, innerArray, index + 1, size - index);

            child.Index = index;
            child.Parent = Owner;
            innerArray[size] = child;
            size++;
        }

        /// <summary>
        /// Removes the first occurrence of a specific <see cref="Control"/> from the <see cref="ControlCollection{T}"/>.
        /// </summary>
        /// <param name="child">The <see cref="Control"/> to remove from the <see cref="ControlCollection{T}"/>.</param>
        /// <returns>true if item is successfully removed; otherwise, false. This method also returns false if item was not found in the <see cref="ControlCollection{T}"/>.</returns>
        public virtual bool Remove(T child)
        {
            if (isReadOnly) throw new NotSupportedException("Cannot remove items while the collection is read-only.");
            if (!Contains(child))
                return false;

            int index = IndexOf(child);
            if (index >= 0)
            {
                size--;
                child.Index = -1;
                child.Parent = null;
                if (index < size)
                    Array.Copy(innerArray, index + 1, innerArray, index, size - 1);
                innerArray[size] = default;
                child.Dispose();
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Removes all elements from the <see cref="ControlCollection{T}"/>.
        /// </summary>
        public void Clear()
        {
            if (innerArray != null)
            {
                foreach (T child in innerArray)
                {
                    Remove(child);
                }
            }
            //TODO: Owner.UpdateLayout();
        }

        /// <summary>
        /// Determines whether a <see cref="Control"/> is in the <see cref="ControlCollection{T}"/>.
        /// </summary>
        /// <param name="child">The <see cref="Control"/> to locate in the <see cref="ControlCollection{T}"/>.</param>
        /// <returns>true if item is found in the <see cref="ControlCollection{T}"/>; otherwise, false.</returns>
        public bool Contains(T child)
        {
            if (innerArray == null || child == null)
                return false;

            for (int i = 0; i < size; i++)
            {
                if (ReferenceEquals(child, innerArray[i]))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Copies the entire <see cref="ControlCollection{T}"/> to a compatible one-dimensional array, starting at the specified index of the target array.
        /// </summary>
        /// <param name="array">The one-dimensional <see cref="Array"/> that is the destination of the elements copied from <see cref="ControlCollection{T}"/>. The <see cref="Array"/> must have zero-based indexing.</param>
        /// <param name="index">The zero-based index in <paramref name="array"/> at which copying begins.</param>
        public void CopyTo(Array array, int index)
        {
            if (innerArray == null)
                return;
            if ((array != null) && (array.Rank != 1))
                throw new ArgumentException("array must be 1-dimensional.", nameof(array));

            Array.Copy(innerArray, 0, array, index, size);
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>An <see cref="IEnumerator{T}"/> object that can be used to iterate through the collection.</returns>
        public IEnumerator<T> GetEnumerator() => new ControlCollectionEnumerator(this);

        /// <summary>
        /// Determines the index of a specific value in the <see cref="ControlCollection{T}"/>.
        /// </summary>
        /// <param name="value">The control to locate in the <see cref="ControlCollection{T}"/>.</param>
        /// <returns>The index of item if found in the list; otherwise, -1.</returns>
        public int IndexOf(T value)
        {
            if (innerArray == null)
                return -1;
            return Array.IndexOf(innerArray, value, 0, size);
        }

        internal void SetReadOnly(bool readOnly)
        {
            if (isReadOnly != readOnly)
                isReadOnly = readOnly;
        }

        void ICollection<T>.Add(T child) => Add(child);
        void ICollection<T>.CopyTo(T[] array, int index) => CopyTo(array, index);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

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
                return innerArray[index];
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

            private void Dispose(bool disposing)
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