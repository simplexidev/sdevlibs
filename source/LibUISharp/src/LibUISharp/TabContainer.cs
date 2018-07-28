using System;
using LibUISharp.Internal;
using static LibUISharp.Internal.Libraries;

namespace LibUISharp
{
    /// <summary>
    /// Represents a control that contains multiple <see cref="TabPage"/> objects that share the same space on the screen.
    /// </summary>
    [LibuiType("uiTab")]
    public class TabContainer : MultiContainer<TabContainer, TabContainer.ControlList, TabPage>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TabContainer"/> class.
        /// </summary>
        public TabContainer() => Handle = Libui.Call<Libui.uiNewTab>()();

        /// <summary>
        /// Represents a collection of child <see cref="TabPage"/> objects inside of a <see cref="TabContainer"/>.
        /// </summary>
        public class ControlList : ControlListBase
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="ControlList"/> class with the specified parent.
            /// </summary>
            /// <param name="owner">The parent <see cref="StackContainer"/> of this <see cref="ControlList"/>.</param>
            public ControlList(TabContainer owner) : base(owner) { }

            /// <summary>
            /// Adds a <see cref="TabPage"/> to the end of the <see cref="ControlList"/>.
            /// </summary>
            /// <param name="label">The text beside the child <see cref="TabPage"/>.</param>
            /// <param name="child">The <see cref="TabPage"/> to be added to the end of the <see cref="ControlList"/>.</param>
            /// <param name="stretches">Whether or not <paramref name="child"/> stretches the area of the parent <see cref="TabPage"/></param>
            public override void Add(TabPage child)
            {
                base.Add(child);
                Libui.Call<Libui.uiTabAppend>()(Owner, child.Name, child);
                child.DelayRender();
            }

            /// <summary>
            /// Adds a <see cref="TabPage"/> to the <see cref="ControlList"/> at the specified index.
            /// </summary>
            /// <param name="index">The zero-based index at which child should be inserted.</param>
            /// <param name="child">The <see cref="TabPage"/> to insert into the <see cref="ControlList"/>.</param>
            public override void Insert(int index, TabPage child)
            {
                base.Insert(index, child);
                Libui.Call<Libui.uiTabInsertAt>()(Owner, child.Name, index, child);
                child.DelayRender();
            }

            /// <summary>
            /// Removes the first occurrence of a specific <see cref="TabPage"/> from the <see cref="ControlList"/>.
            /// </summary>
            /// <param name="child">The <see cref="TabPage"/> to remove from the <see cref="ControlList"/>.</param>
            /// <returns>true if child is successfully removed; otherwise, false. This method also returns false if child was not found in the <see cref="ControlList"/>.</returns>
            public new bool Remove(TabPage child)
            {
                if (base.Remove(child))
                {
                    Libui.Call<Libui.uiTabDelete>()(Owner, child.Index);
                    return true;
                }
                return false;
            }
        }
    }

    /// <summary>
    /// Represents a single tab page in a <see cref="TabContainer"/>.
    /// </summary>
    public class TabPage : SingleContainer<TabPage, Control>
    {
        private Control child;
        private bool initialized = false;
        private bool isMargined;

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
        /// Sets the child contained in this <see cref="TabPage"/>.
        /// </summary>
        public override Control Child
        {
            set
            {
                if (child != value)
                {
                    child = value;
                    Handle = child.Handle;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether or not this <see cref="TabPage"/> has outer isMargined.
        /// </summary>
        public bool IsMargined
        {
            get
            {
                if (Parent != null && Parent != IntPtr.Zero)
                {
                    isMargined = Libui.Call<Libui.uiTabMargined>()(Parent, Index);
                    initialized = true;
                }
                return isMargined;
            }
            set
            {
                if (isMargined != value)
                {
                    if (Parent != null && Parent != IntPtr.Zero)
                        Libui.Call<Libui.uiTabSetMargined>()(Parent, Index, value);
                    isMargined = value;
                }
            }
        }

        /// <summary>
        /// Performs pre-rendering operations.
        /// </summary>
        protected internal override void DelayRender()
        {
            if (!initialized && isMargined)
                Libui.Call<Libui.uiTabSetMargined>()(Parent, Index, isMargined);
        }
    }
}