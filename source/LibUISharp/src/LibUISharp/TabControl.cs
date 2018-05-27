using LibUISharp.Internal;
using LibUISharp.SafeHandles;
using System;
using System.Runtime.InteropServices;

namespace LibUISharp
{
    /// <summary>
    /// Represents a control that contains multiple <see cref="TabPage"/> objects that share the same space on the screen.
    /// </summary>
    public class TabControl : ContainerControl<TabControl, TabPageCollection>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TabControl"/> class.
        /// </summary>
        public TabControl() => Handle = new SafeControlHandle(LibuiLibrary.uiNewTab());
    }

    /// <summary>
    /// Represents a single tab page in a <see cref="TabControl"/>.
    /// </summary>
    public class TabPage : Control
    {
        protected Control child;
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

    /// <summary>
    /// Represents a collection of child <see cref="TabPage"/>s inside of a <see cref="ControlCollection{TContainer}"/>.
    /// </summary>
    public class TabPageCollection : ControlCollection<TabControl>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TabPageCollection"/> class with the specified parent.
        /// </summary>
        /// <param name="parent">The parent <see cref="TabControl"/> of this <see cref="TabPageCollection"/>.</param>
        public TabPageCollection(TabControl parent) : base(parent) { }

        /// <summary>
        /// Adds a <see cref="Control"/> to the end of the <see cref="TabPageCollection"/>.
        /// </summary>
        /// <param name="item">The <see cref="Control"/> to be added to the end of the <see cref="TabPageCollection"/>.</param>
        public override void Add(Control item)
        {
            if (!(item is TabPage)) throw new ArgumentException("You can only add a TabPage to a TabControl.");
            Add((TabPage)item);
        }

        /// <summary>
        /// Adds a <see cref="TabPage"/> to the end of the <see cref="TabPageCollection"/>.
        /// </summary>
        /// <param name="item">The <see cref="TabPage"/> to be added to the end of the <see cref="TabPageCollection"/>.</param>
        public void Add(TabPage item)
        {
            if (item == null) throw new ArgumentException("You cannot add a null TabPage to a TabControl.");
            base.Add(item);
            IntPtr strPtr = item.Name.ToLibuiString();
            LibuiLibrary.uiTabAppend(Parent.Handle.DangerousGetHandle(), strPtr, item.Handle.DangerousGetHandle());
            Marshal.FreeHGlobal(strPtr);
            item.DelayRender();
        }

        /// <summary>
        /// Inserts a <see cref="Control"/>to the <see cref="TabPageCollection"/> at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which the <see cref="Control"/> should be inserted.</param>
        /// <param name="item">The <see cref="Control"/> to insert into the <see cref="TabPageCollection"/>.</param>
        public override void Insert(int i, Control item)
        {
            if (!(item is TabPage)) throw new ArgumentException("You can only insert a TabPage into a TabControl.");
            Insert(i, (TabPage)item);
        }

        /// <summary>
        /// Inserts a <see cref="TabPage"/>to the <see cref="TabPageCollection"/> at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which the <see cref="TabPage"/> should be inserted.</param>
        /// <param name="item">The <see cref="TabPage"/> to insert into the <see cref="TabPageCollection"/>.</param>
        public void Insert(int i, TabPage item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            base.Insert(i, item);
            IntPtr strPtr = item.Name.ToLibuiString();
            LibuiLibrary.uiTabInsertAt(Parent.Handle.DangerousGetHandle(), strPtr, i, item.Handle.DangerousGetHandle());
            Marshal.FreeHGlobal(strPtr);
            item.DelayRender();
        }

        /// <summary>
        /// Removes the first occurrence of a specific <see cref="Control"/> from the <see cref="TabPageCollection"/>.
        /// </summary>
        /// <param name="item">The <see cref="Control"/> to remove from the <see cref="TabPageCollection"/>.</param>
        /// <returns>true if item is successfully removed; otherwise, false. This method also returns false if item was not found in the <see cref="TabPageCollection"/>.</returns>
        public override bool Remove(Control item)
        {
            if (!(item is TabPage)) throw new ArgumentException("You can only remove a TabPage from a TabControl.");
            return Remove((TabPage)item);
        }

        /// <summary>
        /// Removes the first occurrence of a specific <see cref="TabPage"/> from the <see cref="TabPageCollection"/>.
        /// </summary>
        /// <param name="item">The <see cref="TabPage"/> to remove from the <see cref="TabPageCollection"/>.</param>
        /// <returns>true if item is successfully removed; otherwise, false. This method also returns false if item was not found in the <see cref="TabPageCollection"/>.</returns>
        public bool Remove(TabPage item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            LibuiLibrary.uiTabDelete(Parent.Handle.DangerousGetHandle(), item.Index);
            return base.Remove(item);
        }
    }
}