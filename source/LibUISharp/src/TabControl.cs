using System;
using System.Runtime.InteropServices;
using LibUISharp.Internal;
using static LibUISharp.Internal.UI;

namespace LibUISharp
{
    public class TabControl : ContainerControl<TabPageCollection, TabControl>
    {
        public TabControl() => Handle = new UIControlHandle(uiNewTab());

        public virtual int Count => uiTabNumPages(Handle.DangerousGetHandle());
    }

    public class TabPage : Control
    {
        public TabPage(string name) => Name = name;

        public TabPage(string name, Control child)
        {
            Name = name;
            Child = child;
        }

        public string Name { get; }

        protected Control child;
        public Control Child
        {
            get => child;
            protected set
            {
                if (child != value)
                    child = value;
                Handle = child.Handle;
            }
        }

        private bool handleSet = false;
        private bool hasMargins;
        public bool HasMargins
        {
            get
            {
                if (Parent != null && Parent.Handle.IsInvalid)
                {
                    hasMargins = uiTabMargined(Parent.Handle.DangerousGetHandle(), Index);
                    handleSet = true;
                }
                return hasMargins;
            }
            set
            {
                if (hasMargins != value)
                {
                    if (Parent != null && Parent.Handle.IsInvalid)
                        uiTabSetMargined(Parent.Handle.DangerousGetHandle(), Index, value);
                    hasMargins = value;
                }
            }
        }

        protected internal override void DelayRender()
        {
            if (!handleSet && hasMargins)
                uiTabSetMargined(Parent.Handle.DangerousGetHandle(), Index, hasMargins);
        }
    }

    public class TabPageCollection : ControlCollection<TabControl>
    {
        public TabPageCollection(TabControl parent) : base(parent) { }

        public override void Add(Control child)
        {
            TabPage page = child as TabPage ?? throw new ArgumentNullException("child");
            base.Add(child);
            IntPtr strPtr = MarshalHelper.StringToUTF8(page.Name);
            uiTabAppend(Owner.Handle.DangerousGetHandle(), strPtr, child.Handle.DangerousGetHandle());
            Marshal.FreeHGlobal(strPtr);
            child.DelayRender();
        }

        public override void Insert(int i, Control child)
        {
            TabPage page = child as TabPage ?? throw new ArgumentNullException("child");
            base.Insert(i, child);
            IntPtr strPtr = MarshalHelper.StringToUTF8(page.Name);
            uiTabInsertAt(Owner.Handle.DangerousGetHandle(), strPtr, i, child.Handle.DangerousGetHandle());
            Marshal.FreeHGlobal(strPtr);
            child.DelayRender();
        }

        public override bool Remove(Control item)
        {
            uiTabDelete(Owner.Handle.DangerousGetHandle(), item.Index);
            return base.Remove(item);
        }
    }
}