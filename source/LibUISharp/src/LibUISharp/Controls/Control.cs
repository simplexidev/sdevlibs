using System;
using System.Collections;
using System.Collections.Generic;
using LibUISharp.Internal;

namespace LibUISharp.Controls
{
    //TODO: uiControlVerifySetParent(IntPtr,IntPtr) => VerifyParent(Control)
    public abstract class Control : IControl
    {
        private bool visible, enabled;
        private bool disposed = false;
        private static readonly Dictionary<ControlSafeHandle, Control> ControlCache = new Dictionary<ControlSafeHandle, Control>();

        protected Control()
        {
            if (this is Window)
                visible = false;
            else
                visible = true;
            ControlCache.Add(Handle, this);
        }

        public event EventHandler LocationChanged, Resize;

        public virtual bool Enabled
        {
            get => LibUI.ControlEnabled(Handle);
            set
            {
                if (enabled == value) return;
                if (value)
                    LibUI.ControlEnable(Handle);
                else
                    LibUI.ControlDisable(Handle);
                enabled = value;
            }
        }

        public virtual bool Visible
        {
            get => LibUI.ControlVisible(Handle);
            set
            {
                if (visible == value) return;
                if (value)
                    LibUI.ControlShow(Handle);
                else
                    LibUI.ControlHide(Handle);
                visible = value;
            }
        }

        public bool TopLevel
        {
            get
            {
                if (!Handle.IsInvalid)
                    return LibUI.ControlTopLevel(Handle);
                return false;
            }
            //TODO: set { }
        }

        public bool EnabledToUser
        {
            get
            {
                if (!Handle.IsInvalid)
                    return LibUI.ControlEnabledToUser(Handle);
                throw new InvalidOperationException();
            }
        }
        
        public Control Parent { get; internal set; }
        public int Index { get; protected internal set; }
        protected internal ControlSafeHandle Handle { get; set; }

        public virtual void Enable() => Enabled = true;
        public virtual void Disable() => Enabled = false;
        public virtual void Show() => Visible = true;
        public virtual void Hide() => Visible = false;

        protected virtual void OnResize(EventArgs e) => Resize?.Invoke(this, e);
        protected virtual void OnLocationChanged(EventArgs e) => LocationChanged?.Invoke(this, e);

        protected virtual void InitializeEvents() { }
        protected virtual void InitializeComponent() { }
        protected internal virtual void DelayRender() { }

        protected virtual void Destroy()
        {
            if (!Handle.IsInvalid)
                Handle.Close();
            ControlCache.Remove(Handle);
        }
        
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                    Destroy();
                disposed = true;
            }
        }

        ~Control() => Dispose(false);
        
        public virtual void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

    public class ContainerControl : Control { }

    public class ContainerControl<TChild, TContainerControl> : ContainerControl, IContainerControl<TChild, TContainerControl>
        where TChild : ControlCollection<TContainerControl>
        where TContainerControl : ContainerControl
    {
        public override void Dispose()
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

    interface IContainerControl<out TChild, TContainerControl>
        where TChild : ControlCollection<TContainerControl>
        where TContainerControl : ContainerControl
    {
        TChild Children { get; }
    }

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