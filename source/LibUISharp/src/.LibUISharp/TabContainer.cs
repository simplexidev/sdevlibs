using LibUISharp.Internal;
using System;
using static LibUISharp.Internal.Libraries;

namespace LibUISharp
{
    /// <summary>
    /// Represents a control that contains multiple <see cref="TabPage"/> objects that share the same space on the screen.
    /// </summary>
    [LibuiType("uiTab")]
    public class TabContainer : MultiContainer<TabContainer, TabContainer.ControlCollection, TabPage>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TabContainer"/> class.
        /// </summary>
        public TabContainer() => Handle = Libui.Call<Libui.uiNewTab>()();

        /// <summary>
        /// Represents a collection of child <see cref="TabPage"/> objects inside of a <see cref="TabContainer"/>.
        /// </summary>
        public new class ControlCollection : MultiContainer<TabContainer, ControlCollection, TabPage>.ControlCollection
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="ItemCollection"/> class with the specified parent.
            /// </summary>
            /// <param name="parent">The parent <see cref="TabContainer"/> of this <see cref="ItemCollection"/>.</param>
            public ControlCollection(TabContainer parent) : base(parent) { }

            /// <summary>
            /// Adds a <see cref="TabPage"/> to the end of the <see cref="ItemCollection"/>.
            /// </summary>
            /// <param name="item">The <see cref="TabPage"/> to be added to the end of the <see cref="ItemCollection"/>.</param>
            public override void Add(TabPage item)
            {
                if (item == null) throw new ArgumentException("You cannot add a null TabPage to a TabContainer.");
                base.Add(item);
                Libui.Call<Libui.uiTabAppend>()(Owner, item.Name, item);
                item.DelayRender();
            }

            /// <summary>
            /// Adds a <see cref="TabPage"/> to the <see cref="ItemCollection"/> at the specified index.
            /// </summary>
            /// <param name="index">The zero-based index at which item should be inserted.</param>
            /// <param name="item">The <see cref="TabPage"/> to insert into the <see cref="ItemCollection"/>.</param>
            public override void AddAt(int index, TabPage item)
            {
                if (item == null) throw new ArgumentNullException(nameof(item));
                base.AddAt(index, item);
                Libui.Call<Libui.uiTabInsertAt>()(Owner, item.Name, index, item);
                item.DelayRender();
            }

            /// <summary>
            /// Removes the first occurrence of a specific <see cref="TabPage"/> from the <see cref="ItemCollection"/>.
            /// </summary>
            /// <param name="item">The <see cref="TabPage"/> to remove from the <see cref="ItemCollection"/>.</param>
            /// <returns>true if item is successfully removed; otherwise, false. This method also returns false if item was not found in the <see cref="ItemCollection"/>.</returns>
            public override bool Remove(TabPage item)
            {
                if (item == null) throw new ArgumentNullException(nameof(item));
                Libui.Call<Libui.uiTabDelete>()(Owner, item.Index);
                return base.Remove(item);
            }
        }
    }

    /// <summary>
    /// Represents a single tab page in a <see cref="TabContainer"/>.
    /// </summary>
    public class TabPage : SingleContainer<TabPage, Control>
    {
        private Control childField;
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
                if (childField != value)
                {
                    childField = value;
                    Handle = childField.Handle;
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