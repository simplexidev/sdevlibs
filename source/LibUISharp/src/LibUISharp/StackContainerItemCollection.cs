using LibUISharp.Internal;
using System;

namespace LibUISharp
{
    /// <summary>
    /// Represents a collection of child <see cref="Control"/>s inside of a <see cref="StackContainer"/>.
    /// </summary>
    public sealed class StackContainerItemCollection : ControlCollection<Control>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StackContainerItemCollection"/> class with the specified parent.
        /// </summary>
        /// <param name="owner">The parent <see cref="StackContainer"/> of this <see cref="StackContainerItemCollection"/>.</param>
        public StackContainerItemCollection(StackContainer owner) : base(owner) { }

        /// <summary>
        /// Adds a <see cref="Control"/> to the end of the <see cref="StackContainerItemCollection"/>.
        /// </summary>
        /// <param name="child">The <see cref="Control"/> to be added to the end of the <see cref="StackContainerItemCollection"/>.</param>
        public override void Add(Control child) => Add(child, false);

        /// <summary>
        /// Adds a <see cref="Control"/> to the end of the <see cref="StackContainerItemCollection"/>.
        /// </summary>
        /// <param name="child">The <see cref="Control"/> to be added to the end of the <see cref="StackContainerItemCollection"/>.</param>
        /// <param name="stretches">Whether or not <paramref name="child"/> stretches the area of the parent <see cref="Control"/></param>
        public void Add(Control child, bool stretches = false)
        {
            if (Contains(child)) throw new InvalidOperationException("Cannot add the same control more than once.");
            if (child == null) return;
            LibuiLibrary.uiBoxAppend(Owner.Handle.DangerousGetHandle(), child.Handle.DangerousGetHandle(), stretches);
            base.Add(child);
        }
        
        /// <summary>
        /// <see cref="StackContainerItemCollection"/> does not support this method, and will throw a <see cref="NotSupportedException"/>.
        /// </summary>
        /// <param name="index">The zero-based index at which item should be inserted.</param>
        /// <param name="child">The <see cref="Control"/> to insert into the <see cref="StackContainerItemCollection"/>.</param>
        public override void AddAt(int index, Control child) => throw new NotSupportedException();

        /// <summary>
        /// Removes the first occurrence of a specific <see cref="Control"/> from the <see cref="StackContainerItemCollection"/>.
        /// </summary>
        /// <param name="child">The <see cref="Control"/> to remove from the <see cref="StackContainerItemCollection"/>.</param>
        /// <returns>true if item is successfully removed; otherwise, false. This method also returns false if item was not found in the <see cref="StackContainerItemCollection"/>.</returns>
        public override bool Remove(Control child)
        {
            LibuiLibrary.uiBoxDelete(Owner.Handle.DangerousGetHandle(), child.Index);
            return base.Remove(child);
        }
    }
}