using System;
using System.Collections;
using System.Collections.Generic;

namespace LibUISharp.Collections
{
    public class ControlCollection<TOwner> : IList<Control>
        where TOwner : ContainerControl
    {
        protected TOwner Owner { get; set; }

        protected List<Control> InnerList { get; }

        public ControlCollection(TOwner owner)
        {
            Owner = owner;
            InnerList = new List<Control>();
        }

        public IEnumerator<Control> GetEnumerator() => new ControlCollectionEnumerator(this);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public virtual void Add(Control item)
        {
            if (item == null)
                return;
            if (item.TopLevel)
                throw new ArgumentException("cannot attach the toplevel control.");
            item.Index = Count;
            item.Parent = Owner;
            InnerList.Add(item);
            //TODO: Owner.UpdateLayout();
        }

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
                //TODO: Owner.UpdateLayout();
            }
        }

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

        public void CopyTo(Control[] array, int arrayIndex) => throw new NotImplementedException();

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

        public int Count => InnerList.Count;
        public bool IsReadOnly { get; }
        public int IndexOf(Control item) => InnerList.IndexOf(item);

        public virtual void Insert(int index, Control item)
        {
            if (index > Count + 1)
                throw new NotImplementedException();
            else
            {
                item.Index = index;
                item.Parent = Owner;
                InnerList.Insert(index, item);
            }
        }

        public virtual void RemoveAt(int index) => Remove(InnerList[index]);

        public Control this[int i]
        {
            get => InnerList[i];
            set => throw new NotImplementedException();
        }

        private class ControlCollectionEnumerator : IEnumerator<Control>
        {
            private int curIndex;
            private ControlCollection<TOwner> curControls;

            public ControlCollectionEnumerator(ControlCollection<TOwner> controls)
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