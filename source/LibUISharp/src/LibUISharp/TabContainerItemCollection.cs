using LibUISharp.Internal;
using System;
using System.Runtime.InteropServices;

namespace LibUISharp
{
    /// <summary>
    /// Represents a collection of child <see cref="TabPage"/> objects inside of a <see cref="TabContainer"/>.
    /// </summary>
    public class TabContainerItemCollection : ControlCollection<TabPage>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TabContainerItemCollection"/> class with the specified parent.
        /// </summary>
        /// <param name="parent">The parent <see cref="TabContainer"/> of this <see cref="TabContainerItemCollection"/>.</param>
        public TabContainerItemCollection(TabContainer parent) : base(parent) { }

        /// <summary>
        /// Adds a <see cref="TabPage"/> to the end of the <see cref="TabContainerItemCollection"/>.
        /// </summary>
        /// <param name="item">The <see cref="TabPage"/> to be added to the end of the <see cref="TabContainerItemCollection"/>.</param>
        public override void Add(TabPage item)
        {
            if (item == null) throw new ArgumentException("You cannot add a null TabPage to a TabContainer.");
            base.Add(item);
            IntPtr strPtr = item.Name.ToLibuiString();
            LibuiLibrary.uiTabAppend(Owner.Handle.DangerousGetHandle(), strPtr, item.Handle.DangerousGetHandle());
            Marshal.FreeHGlobal(strPtr);
            item.DelayRender();
        }

        /// <summary>
        /// Adds a <see cref="TabPage"/> to the <see cref="TabContainerItemCollection"/> at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which item should be inserted.</param>
        /// <param name="item">The <see cref="TabPage"/> to insert into the <see cref="TabContainerItemCollection"/>.</param>
        public override void AddAt(int index, TabPage item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            base.AddAt(index, item);
            IntPtr strPtr = item.Name.ToLibuiString();
            LibuiLibrary.uiTabInsertAt(Owner.Handle.DangerousGetHandle(), strPtr, index, item.Handle.DangerousGetHandle());
            Marshal.FreeHGlobal(strPtr);
            item.DelayRender();
        }

        /// <summary>
        /// Removes the first occurrence of a specific <see cref="TabPage"/> from the <see cref="TabContainerItemCollection"/>.
        /// </summary>
        /// <param name="item">The <see cref="TabPage"/> to remove from the <see cref="TabContainerItemCollection"/>.</param>
        /// <returns>true if item is successfully removed; otherwise, false. This method also returns false if item was not found in the <see cref="TabContainerItemCollection"/>.</returns>
        public override bool Remove(TabPage item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            LibuiLibrary.uiTabDelete(Owner.Handle.DangerousGetHandle(), item.Index);
            return base.Remove(item);
        }
    }
}