using System;
using System.Collections;
using System.Collections.Generic;
using LibUISharp.Internal;

using static LibUISharp.Internal.UI;

namespace LibUISharp
{
    //TODO: Add a VerifySetParent() method and incorporate it into the Parent property.
    //TODO: Add an EnabledToUser get-only property.
    //TODO: Maybe add an interface named IControl.
    public abstract class Control : IDisposable
    {
        protected Control()
        {
            if (this is Window) visible = false;
            else visible = true;
        }

        ~Control() => Dispose(false);

        public event EventHandler LocationChanged, Resize;

        protected internal UIControlHandle Handle { get; protected set; }

        private bool enabled;
        public virtual bool Enabled
        {
            get => uiControlEnabled(Handle.DangerousGetHandle());
            set
            {
                if (enabled == value) return;
                if (value) Enable();
                else Disable();
                enabled = value;
            }
        }

        private bool visible;
        public virtual bool Visible
        {
            get => uiControlVisible(Handle.DangerousGetHandle());
            set
            {
                if (visible == value) return;
                if (value) Show();
                else Hide();
                visible = value;
            }
        }

        public bool TopLevel
        {
            get
            {
                if (!Handle.IsInvalid)
                    return uiControlTopLevel(Handle.DangerousGetHandle());
                return false;
            }
        }

        public Control Parent { get; internal set; }
        public int Index { get; protected internal set; }

        protected virtual void OnResize(EventArgs e) => Resize?.Invoke(this, e);
        protected virtual void OnLocationChanged(EventArgs e) => LocationChanged?.Invoke(this, e);
        protected internal virtual void DelayRender() { }
        protected virtual void Initialize() { }

        public virtual void Show() => uiControlShow(Handle.DangerousGetHandle());
        public virtual void Hide() => uiControlHide(Handle.DangerousGetHandle());
        public virtual void Enable() => uiControlEnable(Handle.DangerousGetHandle());
        public virtual void Disable() => uiControlDisable(Handle.DangerousGetHandle());

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (disposing && !Handle.IsInvalid)
                Handle.Close();
        }
    }

    public class ContainerControl : Control { }

    public class ContainerControl<TChild, TContainerControl> : ContainerControl, IContainerControl<TChild, TContainerControl>
        where TChild : ControlCollection<TContainerControl> where TContainerControl : ContainerControl
    {
        protected new void Dispose()
        {
            Children.Clear();
            base.Dispose();
        }

        private TChild children;
        public virtual TChild Children
        {
            get
            {
                if (children == null)
                    children = (TChild)Activator.CreateInstance(typeof(TChild), this);
                return children;
            }
        }
    }

    public class ControlCollection<TOwner> : IList<Control> where TOwner : ContainerControl
    {
        public ControlCollection(TOwner owner)
        {
            Owner = owner;
            InnerList = new List<Control>();
        }

        protected TOwner Owner { get; set; }
        protected List<Control> InnerList { get; }

        public int Count => InnerList.Count;
        public bool IsReadOnly { get; }

        public IEnumerator<Control> GetEnumerator() => new ControlCollectionEnumerator(this);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public virtual void Add(Control item)
        {
            if (item == null) return;
            if (item.TopLevel) throw new ArgumentException("cannot attach the toplevel control.");
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
                    RemoveAt(Count - 1);
            } finally { }//TODO: Owner.UpdateLayout();
        }

        public virtual bool Contains(Control item)
        {
            if (item == null) return false;
            for (int i = 0; i < InnerList.Count; i++)
            {
                Control inner = InnerList[i];
                if (inner != null && inner.Equals(item)) return true;
            }
            return false;
        }

        public void CopyTo(Control[] array, int arrayIndex) => throw new NotImplementedException();

        public virtual bool Remove(Control item)
        {
            if (item == null) return false;
            // update indexes of other items 
            foreach (Control control in InnerList)
                if (control.Index > item.Index)
                    control.Index--;
            item.Index = -1;
            item.Parent = null;
            bool success = InnerList.Remove(item);
            if (success)
                item.Dispose(true);
            return success;
        }

        public int IndexOf(Control item) => InnerList.IndexOf(item);

        public virtual void Insert(int index, Control item)
        {
            if (index > Count + 1) throw new NotImplementedException();
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
                if (++curIndex >= curControls.Count) return false;
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

    internal interface IContainerControl<out TChild, TContainerControl>
        where TChild : ControlCollection<TContainerControl>
        where TContainerControl : ContainerControl
    {
        TChild Children { get; }
    }
}