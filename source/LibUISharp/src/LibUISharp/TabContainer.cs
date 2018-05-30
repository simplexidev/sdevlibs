using LibUISharp.Internal;
using LibUISharp.SafeHandles;

namespace LibUISharp
{
    /// <summary>
    /// Represents a control that contains multiple <see cref="TabPage"/> objects that share the same space on the screen.
    /// </summary>
    public class TabContainer : ContainerControl<TabPage, TabContainerItemCollection>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TabContainer"/> class.
        /// </summary>
        public TabContainer() => Handle = new SafeControlHandle(LibuiLibrary.uiNewTab());
    }

    /// <summary>
    /// Represents a single tab page in a <see cref="TabContainer"/>.
    /// </summary>
    public class TabPage : Control
    {
        private Control childField;
        private bool initialized = false;
        private bool margins;

        /// <summary>
        /// Initializes a new instance of the <see cref="TabPage"/> class with the specified name.
        /// </summary>
        /// <param name="name">The name for this <see cref="TabPage"/>.</param>
        public TabPage(string name) => Name = name;

        /// <summary>
        /// Initializes a new instance of the <see cref="TabPage"/> class with the specified name and child <see cref="Control"/>.
        /// </summary>
        /// <param name="name">The name for this <see cref="TabPage"/>.</param>
        /// <param name="child">The child <see cref="Control"/> contained in this <see cref="TabPage"/>.</param>
        public TabPage(string name, Control child)
        {
            Name = name;
            Child = child;
        }

        /// <summary>
        /// Gets the name of this <see cref="TabPage"/>.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the child contained in this <see cref="TabPage"/>.
        /// </summary>
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

        /// <summary>
        /// Gets or sets a value indicating whether or not this <see cref="TabPage"/> has outer margins.
        /// </summary>
        public bool Margins
        {
            get
            {
                if (Parent != null && !Parent.Handle.IsInvalid)
                {
                    margins = LibuiLibrary.uiTabMargined(Parent.Handle.DangerousGetHandle(), Index);
                    initialized = true;
                }
                return margins;
            }
            set
            {
                if (margins != value)
                {
                    if (Parent != null && !Parent.Handle.IsInvalid)
                        LibuiLibrary.uiTabSetMargined(Parent.Handle.DangerousGetHandle(), Index, value);
                    margins = value;
                }
            }
        }

        /// <summary>
        /// Performs pre-rendering operations.
        /// </summary>
        protected internal override void DelayRender()
        {
            if (!initialized && margins)
                LibuiLibrary.uiTabSetMargined(Parent.Handle.DangerousGetHandle(), Index, margins);
        }
    }
}