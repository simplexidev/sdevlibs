using System;
using static LibUISharp.Native.NativeMethods;

namespace LibUISharp
{
    /// <summary>
    /// Represents a collection of child <see cref="Control"/>s inside of a <see cref="FormContainer"/>.
    /// </summary>
    public sealed class FormContainerItemCollection : ControlCollection<Control>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FormContainerItemCollection"/> class with the specified parent.
        /// </summary>
        /// <param name="owner">The parent <see cref="FormContainer"/> of this <see cref="FormContainerItemCollection"/>.</param>
        public FormContainerItemCollection(FormContainer owner) : base(owner) { }

        /// <summary>
        /// Adds a <see cref="Control"/> to the end of the <see cref="FormContainerItemCollection"/>.
        /// </summary>
        /// <param name="item">The <see cref="Control"/> to be added to the end of the <see cref="FormContainerItemCollection"/>.</param>
        public override void Add(Control item) => Add("Label", item);

        /// <summary>
        /// Adds a <see cref="Control"/> to the end of the <see cref="FormContainerItemCollection"/>.
        /// </summary>
        /// <param name="label">The text of the item's label.</param>
        /// <param name="item">The <see cref="Control"/> to be added to the end of the <see cref="FormContainerItemCollection"/>.</param>
        /// <param name="stretches">Whether or not <paramref name="item"/> stretches the area of the parent <see cref="Control"/></param>
        public void Add(string label, Control item, bool stretches = false)
        {
            if (Contains(item))
                throw new InvalidOperationException("cannot add the same control.");
            if (item == null) return;
            Libui.uiFormAppend(Owner, label, item, stretches);
            base.Add(item);
        }

        /// <summary>
        /// <see cref="FormContainerItemCollection"/> does not support this method, and will throw a <see cref="NotSupportedException"/>.
        /// </summary>
        /// <param name="index">The zero-based index at which item should be inserted.</param>
        /// <param name="item">The <see cref="Control"/> to insert into the <see cref="FormContainerItemCollection"/>.</param>
        public override void AddAt(int index, Control item) => throw new NotSupportedException();

        /// <summary>
        /// Removes the first occurrence of a specific <see cref="Control"/> from the <see cref="FormContainerItemCollection"/>.
        /// </summary>
        /// <param name="item">The <see cref="Control"/> to remove from the <see cref="FormContainerItemCollection"/>.</param>
        /// <returns>true if item is successfully removed; otherwise, false. This method also returns false if item was not found in the <see cref="FormContainerItemCollection"/>.</returns>
        public override bool Remove(Control item)
        {
            Libui.uiFormDelete(Owner, item.Index);
            return base.Remove(item);
        }
    }
}