using System;
using LibUISharp.Internal;

namespace LibUISharp
{
    //TODO: Rename to TabControl.
    public class Tab : ContainerControl<TabPageCollection, Tab>
    {
        public Tab() => SafeHandle = new ControlSafeHandle(LibUINativeMethods.uiNewTab());
    }

    public class TabPage : Control
    {
        protected Control child;
        private bool beforeAdd = true;
        private bool allowMargins;

        public TabPage(string name) => Name = name;

        public TabPage(string name, Control child)
        {
            Name = name;
            Child = child;
        }

        public string Name { get; }

        public Control Child
        {
            get => child;
            protected set
            {
                if (child != value)
                {
                    child = value;
                    SafeHandle = child.SafeHandle;
                }
            }
        }

        public bool AllowMargins
        {
            get
            {
                if (Parent != null && Parent.SafeHandle.IsInvalid)
                {
                    allowMargins = LibUINativeMethods.uiTabMargined(Parent.SafeHandle.DangerousGetHandle(), Index);
                    beforeAdd = false;
                }
                return allowMargins;
            }
            set
            {
                if (allowMargins != value)
                {
                    if (Parent != null && Parent.SafeHandle.IsInvalid)
                        LibUINativeMethods.uiTabSetMargined(Parent.SafeHandle.DangerousGetHandle(), Index, value);
                    allowMargins = value;
                }
            }
        }

        protected internal override void DelayRender()
        {
            if (beforeAdd && allowMargins)
                LibUINativeMethods.uiTabSetMargined(Parent.SafeHandle.DangerousGetHandle(), Index, allowMargins);
        }
    }

    public class TabPageCollection : ControlCollection<Tab>
    {
        private UTF8SafeHandle text;

        public TabPageCollection(Tab uiParent) : base(uiParent) { }

        public override void Add(Control child)
        {
            TabPage page = child as TabPage;
            if (page == null)
                throw new ArgumentException("cannot only attach TabPage to Tab");
            base.Add(child);
            text = new UTF8SafeHandle(page.Name);
            LibUINativeMethods.uiTabAppend(Owner.SafeHandle.DangerousGetHandle(), text.DangerousGetHandle(), child.SafeHandle.DangerousGetHandle());
            child.DelayRender();
        }

        public override void Insert(int i, Control child)
        {
            TabPage page = child as TabPage;
            if (page == null)
                throw new ArgumentException("cannot only attach TabPage to Tab");
            base.Insert(i, child);
            LibUINativeMethods.uiTabInsertAt(Owner.SafeHandle.DangerousGetHandle(), text.DangerousGetHandle(), i, child.SafeHandle.DangerousGetHandle());
            child.DelayRender();
        }

        public override bool Remove(Control item)
        {
            LibUINativeMethods.uiTabDelete(Owner.SafeHandle.DangerousGetHandle(), item.Index);
            return base.Remove(item);
        }
    }
}