using System;

using static LibUISharp.Internal.LibUI;

namespace LibUISharp
{
    public class TabControl : ContainerControl<TabPageCollection, TabControl>
    {
        public TabControl() => Handle = uiNewTab();
    }

    public class TabPage : Control
    {
        protected Control child;
        private bool uninitialized = true;
        private bool margins;

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
                    Handle = child.Handle;
                }
            }
        }

        public bool Margins
        {
            get
            {
                if (Parent != null && Parent.Handle.IsInvalid)
                {
                    margins = uiTabMargined(Parent.Handle, Index);
                    uninitialized = false;
                }
                return margins;
            }
            set
            {
                if (margins != value)
                {
                    if (Parent != null && Parent.Handle.IsInvalid)
                        uiTabSetMargined(Parent.Handle, Index, value);
                    margins = value;
                }
            }
        }

        protected internal override void DelayRender()
        {
            if (uninitialized && margins)
                uiTabSetMargined(Parent.Handle, Index, margins);
        }
    }

    public class TabPageCollection : ControlCollection<TabControl>
    {
        public TabPageCollection(TabControl parent) : base(parent) { }

        public override void Add(Control child)
        {
            if (!(child is TabPage))
                throw new ArgumentException("You can only add a TabPage to a TabControl.");
            TabPage c = child as TabPage;
            if (child == null)
                throw new ArgumentException("You cannot add a null TabPage to a TabControl.");
            base.Add(c);
            uiTabAppend(Owner.Handle, c.Name, c.Handle);
            c.DelayRender();
        }

        public override void Insert(int i, Control child)
        {
            if (!(child is TabPage))
                throw new ArgumentException("You can only add a TabPage to a TabControl.");
            TabPage c = child as TabPage;
            if (child == null)
                throw new ArgumentException("You cannot add a null TabPage to a TabControl.");
            base.Insert(i, child);
            uiTabInsertAt(Owner.Handle, c.Name, i, c.Handle);
            c.DelayRender();
        }

        public override bool Remove(Control item)
        {
            uiTabDelete(Owner.Handle, item.Index);
            return base.Remove(item);
        }
    }
}