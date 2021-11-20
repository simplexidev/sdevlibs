using System;
using System.Collections;
using System.Collections.Generic;

namespace LibUISharp
{
    public abstract partial class ControlCollection<T> where T : Control
    {
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