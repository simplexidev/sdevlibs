using System;
using System.Collections;
using System.Collections.Generic;
using LibUISharp.SafeHandles;

namespace LibUISharp
{
    /// <summary>
    /// Represents a <see cref="Control"/> that contains one or more child controls.
    /// </summary>
    public abstract class Container : Control { }

    internal interface ISingleContainer<TContainer, TChild>
        where TContainer : SingleContainer<TContainer, TChild>
        where TChild : Control
    {
        TChild Child { set; }
    }

    /// <summary>
    /// Represents a <see cref="Container"/> that contains a single child <see cref="Control"/>.
    /// </summary>
    /// <typeparam name="TContainer">The type of <see cref="SingleContainer{TContainer, TChild}"/>.</typeparam>
    /// <typeparam name="TChild">The type of the child <see cref="Control"/>.</typeparam>
    public abstract class SingleContainer<TContainer, TChild> : Container, ISingleContainer<TContainer, TChild>
        where TContainer : SingleContainer<TContainer, TChild>
        where TChild : Control
    {
        private TChild child;
        private bool disposed = false;

        /// <summary>
        /// Sets this <see cref="SingleContainer{TContainer, TChild}"/>'s child <see cref="Control"/>.
        /// </summary>
        public virtual TChild Child
        {
            set
            {
                if (child == null)
                    child = (TChild)Activator.CreateInstance(typeof(TChild), this);
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <param name="disposing">Whether or not this <see cref="SingleContainer{TContainer, TChild}"/> is disposing.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing)
            {
                if (child != null)
                    child.Dispose();
            }
            disposed = true;
            base.Dispose(disposing);
        }
    }

    internal interface IMultiContainer<TContainer, out TCollection, TChild>
        where TContainer : MultiContainer<TContainer, TCollection, TChild>
        where TCollection : MultiContainer<TContainer, TCollection, TChild>.ControlListBase
        where TChild : Control
    {
        TCollection Children { get; }
    }

    /// <summary>
    /// Represents a <see cref="Container"/> that contains a collection of child <see cref="Control"/> objects.
    /// </summary>
    /// <typeparam name="TContainer">The type of <see cref="MultiContainer{TContainer, TCollection, TChild}"/>.</typeparam>
    /// <typeparam name="TCollection">The type of <see cref="ControlListBase"/>.</typeparam>
    /// <typeparam name="TChild">The type of the child <see cref="Control"/>.</typeparam>
    public abstract class MultiContainer<TContainer, TCollection, TChild> : Container, IMultiContainer<TContainer, TCollection, TChild>
        where TContainer : MultiContainer<TContainer, TCollection, TChild>
        where TCollection : MultiContainer<TContainer, TCollection, TChild>.ControlListBase
        where TChild : Control
    {
        private TCollection children;
        private bool disposed = false;

        /// <summary>
        /// Sets this <see cref="MultiContainer{TContainer, TCollection, TChild}"/>'s child <see cref="Control"/> objects.
        /// </summary>
        public virtual TCollection Children
        {
            get
            {
                if (children == null)
                    children = (TCollection)Activator.CreateInstance(typeof(TCollection), this);
                return children;
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <param name="disposing">Whether or not this <see cref="Control"/> is disposing.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing)
            {
                if (children != null)
                    children.Clear();
            }
            disposed = true;
            base.Dispose(disposing);
        }

        /// <summary>
        /// Represents the base class for a collection of <typeparamref name="TChild"/> objects inside of a <see cref="MultiContainer{TContainer, TCollection, TChild}"/>.
        /// </summary>
        public abstract class ControlListBase : IList, IList<TChild>, ICollection, ICollection<TChild>, IEnumerable, IEnumerable<TChild>
        {
            private readonly int defaultCapacity = 4;
            private readonly int growFactor = 2;
            private bool isReadOnly = false;
            private TChild[] innerArray;
            private int size;

            /// <summary>
            /// Initializes a new instance of the <see cref="ControlListBase"/> class with the specified owner.
            /// </summary>
            /// <param name="owner">The owner <see cref="Control"/> of this <see cref="ControlListBase"/>.</param>
            protected ControlListBase(TContainer owner) => Owner = owner ?? throw new ArgumentNullException(nameof(owner));

            internal ControlListBase(TContainer owner, int defaultCapacity, int growFactor) : this(owner)
            {
                this.defaultCapacity = defaultCapacity;
                this.growFactor = growFactor;
            }

            /// <summary>
            /// Gets this <see cref="ControlListBase"/>'s owner <see cref="Control"/>.
            /// </summary>
            protected TContainer Owner { get; }

            //TODO: Implement this.
            /// <summary>
            /// Gets the number of elements contained in the <see cref="ControlListBase"/>.
            /// </summary>
            public int Count { get; }

            /// <summary>
            /// Gets a value indicating whether the <see cref="ControlListBase"/> is read-only.
            /// </summary>
            public bool IsReadOnly => isReadOnly == false;

            /// <summary>
            /// Adds a <see cref="Control"/> to the end of the <see cref="ControlListBase"/>.
            /// </summary>
            /// <param name="child">The <see cref="Control"/> to be added to the end of the <see cref="ControlListBase"/>.</param>
            public virtual void Add(TChild child)
            {
                if (child == null) throw new ArgumentNullException(nameof(child));
                if (child.IsInvalid) throw new UIComponentInvalidHandleException<SafeControlHandle>(child);
                // if (child.TopLevel) throw new ArgumentException("Cannot add a top-level control to a ControlListBase.");
                if (Contains(child)) throw new InvalidOperationException("Cannot add the same control more than once.");

                if (innerArray == null)
                    innerArray = new TChild[defaultCapacity];
                else if (size >= innerArray.Length)
                {
                    TChild[] array = new TChild[innerArray.Length * growFactor];
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
            /// Adds a control to the <see cref="ControlListBase"/> at the specified index.
            /// </summary>
            /// <param name="index">The zero-based index at which item should be inserted.</param>
            /// <param name="child">The <see cref="Control"/> to insert into the <see cref="ControlListBase"/>.</param>
            public virtual void Insert(int index, TChild child)
            {
                if (index < 0 || index > size) throw new ArgumentOutOfRangeException(nameof(index));
                if (child == null) throw new ArgumentNullException(nameof(child));
                // if (child.TopLevel) throw new ArgumentException("Cannot add a top-level control to a ControlListBase.");
                if (Contains(child)) throw new InvalidOperationException("Cannot add the same control more than once.");

                if (innerArray == null)
                    innerArray = new TChild[defaultCapacity];
                else if (size >= innerArray.Length)
                {
                    TChild[] array = new TChild[innerArray.Length * growFactor];
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
            /// Removes the first occurrence of a specific <see cref="Control"/> from the <see cref="ControlListBase"/>.
            /// </summary>
            /// <param name="child">The <see cref="Control"/> to remove from the <see cref="ControlListBase"/>.</param>
            /// <returns>true if item is successfully removed; otherwise, false. This method also returns false if item was not found in the <see cref="ControlListBase"/>.</returns>
            public virtual bool Remove(TChild child)
            {
                if (child == null) throw new ArgumentNullException(nameof(child));
                if (child.IsInvalid) throw new UIComponentInvalidHandleException<SafeControlHandle>(child);
                if (isReadOnly) throw new NotSupportedException("Cannot remove items while the collection is read-only.");
                if (!Contains(child)) return false;

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
            /// Removes all elements from the <see cref="ControlListBase"/>.
            /// </summary>
            public void Clear()
            {
                if (innerArray != null)
                {
                    foreach (TChild child in innerArray)
                    {
                        Remove(child);
                    }
                }
                //TODO: Owner.UpdateLayout();
            }

            /// <summary>
            /// Determines whether a <see cref="Control"/> is in the <see cref="ControlListBase"/>.
            /// </summary>
            /// <param name="child">The <see cref="Control"/> to locate in the <see cref="ControlListBase"/>.</param>
            /// <returns>true if item is found in the <see cref="ControlListBase"/>; otherwise, false.</returns>
            public bool Contains(TChild child)
            {
                if (innerArray == null || child == null || child.IsInvalid)
                    return false;

                for (int i = 0; i < size; i++)
                {
                    if (ReferenceEquals(child, innerArray[i]))
                        return true;
                }

                return false;
            }

            /// <summary>
            /// Copies the entire <see cref="ControlListBase"/> to a compatible one-dimensional array, starting at the specified index of the target array.
            /// </summary>
            /// <param name="array">The one-dimensional <see cref="Array"/> that is the destination of the elements copied from <see cref="ControlListBase"/>. The <see cref="Array"/> must have zero-based indexing.</param>
            /// <param name="index">The zero-based index in <paramref name="array"/> at which copying begins.</param>
            public void CopyTo(Array array, int index)
            {
                if (innerArray == null) return;
                if ((array != null) && (array.Rank != 1)) throw new ArgumentException("array must be 1-dimensional.", nameof(array));
                Array.Copy(innerArray, 0, array, index, size);
            }

            /// <summary>
            /// Determines the index of a specific value in the <see cref="ControlListBase"/>.
            /// </summary>
            /// <param name="value">The control to locate in the <see cref="ControlListBase"/>.</param>
            /// <returns>The index of item if found in the list; otherwise, -1.</returns>
            public int IndexOf(TChild value)
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

            /// <summary>
            /// Gets the element at the specified index.
            /// </summary>
            /// <param name="index">The zero-based index of the element to get or set.</param>
            /// <returns>The element at the specified index.</returns>
            public virtual TChild this[int index]
            {
                get
                {
                    if (index < 0 || index >= size) throw new ArgumentOutOfRangeException(nameof(index));
                    return innerArray[index];
                }
            }

            #region IList<TChild> Implementation
            int IList.Add(object value)
            {
                try
                {
                    Add((TChild)value);
                }
                catch
                {
                    return -1;
                }
                return IndexOf((TChild)value);
            }
            void ICollection<TChild>.Add(TChild item) => Add(item);
            void IList.Clear() => Clear();
            void ICollection<TChild>.Clear() => Clear();
            bool IList.Contains(object value) => Contains((TChild)value);
            bool ICollection<TChild>.Contains(TChild item) => Contains(item);
            void ICollection.CopyTo(Array array, int index) => CopyTo(array, index);
            void ICollection<TChild>.CopyTo(TChild[] array, int arrayIndex) => CopyTo(array, arrayIndex);
            IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable<TChild>)this).GetEnumerator();
            IEnumerator<TChild> IEnumerable<TChild>.GetEnumerator() => new ControlListEnumerator(this);
            int IList.IndexOf(object value) => IndexOf((TChild)value);
            int IList<TChild>.IndexOf(TChild item) => IndexOf(item);
            void IList.Insert(int index, object value) => Insert(index, (TChild)value);
            void IList<TChild>.Insert(int index, TChild item) => Insert(index, item);
            void IList.Remove(object value) => Remove((TChild)value);
            bool ICollection<TChild>.Remove(TChild item) => Remove(item);
            void IList.RemoveAt(int index) => throw new NotSupportedException();
            void IList<TChild>.RemoveAt(int index) => throw new NotSupportedException();

            object IList.this[int index]
            {
                get => this[index];
                set => throw new NotSupportedException();
            }
            TChild IList<TChild>.this[int index]
            {
                get => this[index];
                set => throw new NotSupportedException();
            }

            int ICollection.Count => Count;
            int ICollection<TChild>.Count => Count;
            bool IList.IsFixedSize => IsReadOnly;
            bool IList.IsReadOnly => IsReadOnly;
            bool ICollection<TChild>.IsReadOnly => IsReadOnly;
            bool ICollection.IsSynchronized => false;
            object ICollection.SyncRoot => this;
            #endregion

            private sealed class ControlListEnumerator : IEnumerator<TChild>, ICloneable
            {
                private ControlListBase list;
                private TChild current;
                private int index;
                private bool disposed = false;

                internal ControlListEnumerator(ControlListBase list)
                {
                    this.list = list;
                    index = -1;
                }

                public bool MoveNext()
                {
                    if (index < (list.Count - 1))
                    {
                        index++;
                        current = list[index];
                        return true;
                    }

                    index = list.Count;
                    return false;
                }

                object IEnumerator.Current => Current;

                public TChild Current
                {
                    get
                    {
                        if (index == -1 || index >= list.Count)
                            throw new InvalidOperationException("index is out of range.");
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
                    if (disposed) return;
                    if (disposing)
                    {
                        if (list != null)
                            list.Clear();
                    }
                    disposed = true;
                }
            }
        }
    }
}