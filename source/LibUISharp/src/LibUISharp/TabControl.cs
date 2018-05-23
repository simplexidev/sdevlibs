using LibUISharp.Internal;
using LibUISharp.SafeHandles;
using System;
using System.Runtime.InteropServices;

// uiTab
namespace LibUISharp
{
    public class TabControl : ContainerControl<TabControl, TabPageCollection>
    {
        public TabControl() => Handle = new SafeControlHandle(LibuiLibrary.uiNewTab());
    }

    public class TabPage : Control
    {
        protected Control childField;
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
            get => childField;
            protected set
            {
                if (childField != value)
                {
                    childField = value;
                    Handle = childField.Handle;
                }
            }
        }

        public bool Margins
        {
            get
            {
                if (Parent != null && Parent.Handle.IsInvalid)
                {
                    margins = LibuiLibrary.uiTabMargined(Parent.Handle.DangerousGetHandle(), Index);
                    uninitialized = false;
                }
                return margins;
            }
            set
            {
                if (margins != value)
                {
                    if (Parent != null && Parent.Handle.IsInvalid)
                        LibuiLibrary.uiTabSetMargined(Parent.Handle.DangerousGetHandle(), Index, value);
                    margins = value;
                }
            }
        }

        protected internal override void DelayRender()
        {
            if (uninitialized && margins)
                LibuiLibrary.uiTabSetMargined(Parent.Handle.DangerousGetHandle(), Index, margins);
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
            IntPtr strPtr = c.Name.ToLibuiString();
            LibuiLibrary.uiTabAppend(Parent.Handle.DangerousGetHandle(), strPtr, c.Handle.DangerousGetHandle());
            Marshal.FreeHGlobal(strPtr);
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
            IntPtr strPtr = c.Name.ToLibuiString();
            LibuiLibrary.uiTabInsertAt(Parent.Handle.DangerousGetHandle(), strPtr, i, c.Handle.DangerousGetHandle());
            Marshal.FreeHGlobal(strPtr);
            c.DelayRender();
        }

        public override bool Remove(Control item)
        {
            LibuiLibrary.uiTabDelete(Parent.Handle.DangerousGetHandle(), item.Index);
            return base.Remove(item);
        }
    }
}