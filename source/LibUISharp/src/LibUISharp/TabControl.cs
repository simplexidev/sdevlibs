using LibUISharp.Collections;
using static LibUISharp.Internal.LibUI;

namespace LibUISharp
{
    // uiTab
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
}