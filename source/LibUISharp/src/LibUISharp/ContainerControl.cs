using System;
using System.Collections;
using System.Collections.Generic;

namespace LibUISharp
{
    internal interface IContainerControl<TContainer, out TCollection>
        where TContainer : ContainerControl
        where TCollection : ControlCollection<TContainer>
    {
        TCollection Children { get; }
    }

    /// <summary>
    /// Represents a <see cref="Control"/> that contains a collection of child <see cref="Control"/>s.
    /// </summary>
    public class ContainerControl : Control { }

    /// <summary>
    /// Represents a <see cref="Control"/> that contains a collection of child <see cref="Control"/>s.
    /// </summary>
    public class ContainerControl<TContainer, TCollection> : ContainerControl, IContainerControl<TContainer, TCollection>
        where TContainer : ContainerControl
        where TCollection : ControlCollection<TContainer>
    {
        private TCollection children;
        private bool disposed = false;
        
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <param name="disposing">Whether or not this <see cref="Control'/> is disposing.</param>
        protected sealed override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                    children.Clear();
                disposed = true;
                base.Dispose(disposing);
            }
        }

        /// <summary>
        /// Gets this <see cref="ContainerControl{TContainer, TCollection}"/>'s child <see cref="Control"/>s.
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
    }

    /// <summary>
    /// Represents a collection of child <see cref="Control"/> objects inside of a <see cref="ContainerControl"/>.
    /// </summary>
    /// <typeparam name="TContainer"></typeparam>
    public class ControlCollection<TContainer> : IList<Control>
        where TContainer : ContainerControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ControlCollection{TContainer}"/> class with the specified parent.
        /// </summary>
        /// <param name="parent">The parent <typeparamref name="TContainer"/> of this <see cref="ControlCollection{TContainer}"/>.</param>
        public ControlCollection(TContainer parent)
        {
            Parent = parent;
            InnerList = new List<Control>();
        }

        /// <summary>
        /// Gets this <see cref="ControlCollection{TContainer}"/>'s parent <typeparamref name="TContainer"/>.
        /// </summary>
        protected TContainer Parent { get; }

        /// <summary>
        /// Gets this <see cref="ControlCollection{TContainer}"/>'s inner <see cref="List{T}"/>.
        /// </summary>
        protected List<Control> InnerList { get; }

        /// <summary>
        /// Gets the number of elements contained in the <see cref="ControlCollection{TContainer}"/>.
        /// </summary>
        public int Count => InnerList.Count;

        /// <summary>
        /// Gets whether this <see cref="ControlCollection{TContainer}"/> is read-only or not.
        /// </summary>
        public bool IsReadOnly { get; }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns><see cref="IEnumerator{T}"/> object that can be used to iterate through the collection.</returns>
        public IEnumerator<Control> GetEnumerator() => new ControlCollectionEnumerator(this);


        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns><see cref="IEnumerator"/> object that can be used to iterate through the collection.</returns>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <summary>
        /// Adds a <see cref="Control'/> to the end of the <see cref="ControlCollection{TContainer}"/>.
        /// </summary>
        /// <param name="item">The <see cref="Control'/> to be added to the end of the <see cref="ControlCollection{TContainer}"/>.</param>
        public virtual void Add(Control item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            if (item.TopLevel) throw new ArgumentException("Cannot add a top-level control to a ControlCollection.");
            item.Index = Count;
            item.Parent = Parent;
            InnerList.Add(item);
            //TODO: Parent.UpdateLayout();
        }

        /// <summary>
        /// Removes all elements from the <see cref="ControlCollection{TContainer}"/>.
        /// </summary>
        public virtual void Clear()
        {
            try
            {
                while (Count != 0)
                {
                    RemoveAt(Count - 1);
                }
            }
            finally
            {
                //TODO: Parent.UpdateLayout();
            }
        }

        /// <summary>
        /// Determines whether a <see cref="Control"/> is in the <see cref="ControlCollection{TContainer}"/>.
        /// </summary>
        /// <param name="item">The <see cref="Control'/> to locate in the <see cref="ControlCollection{TContainer}"/>.</param>
        /// <returns>true if item is found in the <see cref="ControlCollection{TContainer}"/>; otherwise, false.</returns>
        public virtual bool Contains(Control item)
        {
            if (item == null)
                return false;
            for (int i = 0; i < InnerList.Count; i++)
            {
                Control inner = InnerList[i];
                if (inner != null && inner.Equals(item))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Copies the entire <see cref="ControlCollection{TContainer}"/> to a compatible one-dimensional array, starting at the specified index of the target array.
        /// </summary>
        /// <param name="array">The one-dimensional System.Array that is the destination of the elements copied from <see cref="ControlCollection{TContainer}"/>. The System.Array must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        public void CopyTo(Control[] array, int arrayIndex) => throw new NotImplementedException();

        /// <summary>
        /// Determines the index of a specific item in the <see cref="ControlCollection{TContainer}"/>.
        /// </summary>
        /// <param name="item">The <see cref="Control'/> to locate in the <see cref="ControlCollection{TContainer}"/>.<param>
        /// <returns>The index of item if found in the list; otherwise, -1.</returns>
        public int IndexOf(Control item) => InnerList.IndexOf(item);

        /// <summary>
        /// Inserts an item to the <see cref="ControlCollection{TContainer}"/> at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which item should be inserted.</param>
        /// <param name="item">The <see cref="Control'/> to insert into the <see cref="ControlCollection{TContainer}"/>.</param>
        public virtual void Insert(int index, Control item)
        {
            if (index > Count + 1)
                throw new NotImplementedException();
            else
            {
                item.Index = index;
                item.Parent = Parent;
                InnerList.Insert(index, item);
            }
        }

        /// <summary>
        /// Removes the first occurrence of a specific <see cref="Control'/> from the <see cref="ControlCollection{TContainer}"/>.
        /// </summary>
        /// <param name="item">The <see cref="Control'/> to remove from the <see cref="ControlCollection{TContainer}"/>.</param>
        /// <returns>true if item is successfully removed; otherwise, false. This method also returns false if item was not found in the <see cref="ControlCollection{TContainer}"/>.</returns>
        public virtual bool Remove(Control item)
        {
            if (item == null)
                return false;
            foreach (Control control in InnerList)
            {
                if (control.Index > item.Index)
                    control.Index--;
            }
            item.Index = -1;
            item.Parent = null;
            bool success = InnerList.Remove(item);
            if (success)
                item.Dispose();
            return success;
        }

        /// <summary>
        /// Removes the <see cref="ControlCollection{TContainer}"/> item at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the item to remove.</param>
        public virtual void RemoveAt(int index) => Remove(InnerList[index]);

        /// <summary>
        /// Gets or sets the element at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the element to get or set.</param>
        /// <returns>The element at the specified index.</returns>
        public Control this[int index]
        {
            get => InnerList[index];
            set => throw new NotImplementedException();
        }

        private class ControlCollectionEnumerator : IEnumerator<Control>
        {
            private int curIndex;
            private ControlCollection<TContainer> curControls;

            public ControlCollectionEnumerator(ControlCollection<TContainer> controls)
            {
                curControls = controls;
                curIndex = -1;
            }

            public bool MoveNext()
            {
                if (++curIndex >= curControls.Count)
                    return false;
                else
                    Current = curControls[curIndex];
                return true;
            }

            public void Reset() => curIndex = -1;

            public Control Current { get; private set; }

            object IEnumerator.Current
            {
                get
                {
                    if (curIndex == -1) return null;
                    return Current;
                }
            }

            public void Dispose() { }
        }
    }
}