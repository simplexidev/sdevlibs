using LibUISharp.Drawing;
using LibUISharp.Internal;
using System;

namespace LibUISharp
{
    /// <summary>
    /// Represents a collection of child <see cref="Control"/>s inside of a <see cref="GridContainer"/>.
    /// </summary>
    public sealed class GridContainerItemCollection : ControlCollection<Control>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GridContainerItemCollection"/> class with the specified parent.
        /// </summary>
        /// <param name="owner">The parent <see cref="GridContainer"/> of this <see cref="GridContainerItemCollection"/>.</param>
        public GridContainerItemCollection(GridContainer owner) : base(owner) { }

        /// <summary>
        /// Adds a <see cref="Control"/> to the end of the <see cref="GridContainerItemCollection"/>.
        /// </summary>
        /// <param name="child">The <see cref="Control"/> to be added to the end of the <see cref="GridContainerItemCollection"/>.</param>
        public override void Add(Control child) => Add(child, 0, 0, 0, 0, 0, 0, Alignment.Fill);

        /// <summary>
        /// Adds a <see cref="Control"/> to the end of the <see cref="GridContainerItemCollection"/>.
        /// </summary>
        /// <param name="child">The <see cref="Control"/> to be added to the end of the <see cref="GridContainerItemCollection"/>.</param>
        /// <param name="rect">A <see cref="Rectangle"/> representing the location and size of <paramref name="child"/>.</param>
        /// <param name="expand">A <see cref="Size"/> representing the h and v-expand.</param>
        /// <param name="alignment">The alignment of <paramref name="child"/>.</param>
        public void Add(Control child, Rectangle rect, Size expand, Alignment alignment) => Add(child, rect.Location, rect.Size, expand, alignment);

        /// <summary>
        /// Adds a <see cref="Control"/> to the end of the <see cref="GridContainerItemCollection"/>.
        /// </summary>
        /// <param name="child">The <see cref="Control"/> to be added to the end of the <see cref="GridContainerItemCollection"/>.</param>
        /// <param name="location">The top-left location of <paramref name="child"/>.</param>
        /// <param name="size">The size of <paramref name="child"/>.</param>
        /// <param name="expand">A <see cref="Size"/> representing the h and v-expand.</param>
        /// <param name="alignment">The alignment of <paramref name="child"/>.</param>
        public void Add(Control child, Point location, Size size, Size expand, Alignment alignment) => Add(child, location.X, location.Y, size.Width, size.Height, expand.Width, expand.Height, alignment);

        /// <summary>
        /// Adds a <see cref="Control"/> to the end of the <see cref="GridContainerItemCollection"/>.
        /// </summary>
        /// <param name="child">The <see cref="Control"/> to be added to the end of the <see cref="GridContainerItemCollection"/>.</param>
        /// <param name="x">The x-coordinate of the child's location.</param>
        /// <param name="y">The y-coordinate of the child's location.</param>
        /// <param name="width">The width of the child.</param>
        /// <param name="height">The height of the child.</param>
        /// <param name="hexpand">The horizontal expand of <paramref name="child"/>.</param>
        /// <param name="vexpand">The vertical expand of <paramref name="child"/>.</param>
        /// <param name="alignment">The alignment of <paramref name="child"/>.</param>
        public void Add(Control child, int x, int y, int width, int height, int hexpand, int vexpand, Alignment alignment)
        {
            if (child == null)
                throw new ArgumentNullException(nameof(child));
            if (Contains(child))
                throw new InvalidOperationException("Cannot add a Control that is already contained in this GridContainerItemCollection.");
            alignment.ToLibuiAligns(out LibuiLibrary.uiAlign halign, out LibuiLibrary.uiAlign valign);
            LibuiLibrary.uiGridAppend(Owner.Handle.DangerousGetHandle(), child.Handle.DangerousGetHandle(), x, y, width, height, hexpand, halign, vexpand, valign);
            base.Add(child);
        }
        /// <summary>
        /// <see cref="GridContainerItemCollection"/> does not support this method, and will throw a <see cref="NotSupportedException"/>.
        /// Use <see cref="AddAt(Control, Control, RelativeAlignment, int, int, int, int, Alignment)"/> or <see cref="AddAt(Control, Control, RelativeAlignment, Size, Size, Alignment)"/> instead.
        /// </summary>
        /// <param name="index">The zero-based index at which item should be inserted.</param>
        /// <param name="child">The <see cref="Control"/> to insert into the <see cref="GridContainerItemCollection"/>.</param>
        public override void AddAt(int index, Control child) => throw new NotSupportedException();

        /// <summary>
        /// Adds a control to the <see cref="GridContainerItemCollection"/> at the specified index.
        /// </summary>
        /// <param name="existing">The existing control at which item should be inserted.</param>
        /// <param name="child">The <see cref="Control"/> to insert into the <see cref="GridContainerItemCollection"/>.</param>
        /// <param name="relativeAlignment">The relative placement of the child control to the existing one.</param>
        /// <param name="size">The size of <paramref name="child"/>.</param>
        /// <param name="expand">A <see cref="Size"/> representing the h and v-expand.</param>
        /// <param name="alignment">The alignment of <paramref name="child"/> in the container.</param>
        public void AddAt(Control existing, Control child, RelativeAlignment relativeAlignment, Size size, Size expand, Alignment alignment) => AddAt(existing, child, relativeAlignment, size.Width, size.Height, expand.Width, expand.Height, alignment);

        /// <summary>
        /// Adds a control to the <see cref="GridContainerItemCollection"/> at the specified index.
        /// </summary>
        /// <param name="existing">The existing control at which item should be inserted.</param>
        /// <param name="child">The <see cref="Control"/> to insert into the <see cref="GridContainerItemCollection"/>.</param>
        /// <param name="relativeAlignment">The relative placement of the child control to the existing one.</param>
        /// <param name="width">The width of the child.</param>
        /// <param name="height">The height of the child.</param>
        /// <param name="hexpand">The horizontal expand of <paramref name="child"/>.</param>
        /// <param name="vexpand">The vertical expand of <paramref name="child"/>.</param>
        /// <param name="alignment">The alignment of <paramref name="child"/>.</param>
        public void AddAt(Control existing, Control child, RelativeAlignment relativeAlignment, int width, int height, int hexpand, int vexpand, Alignment alignment)
        {
            if (child == null)
                throw new ArgumentNullException(nameof(child));
            if (Contains(child))
                throw new InvalidOperationException("Cannot add a Control that is already contained in this GridContainerItemCollection.");
            alignment.ToLibuiAligns(out LibuiLibrary.uiAlign halign, out LibuiLibrary.uiAlign valign);
            LibuiLibrary.uiGridInsertAt(Owner.Handle.DangerousGetHandle(), child.Handle.DangerousGetHandle(), child.Handle.DangerousGetHandle(), (LibuiLibrary.uiAt)relativeAlignment, width, height, hexpand, halign, vexpand, valign);
            base.AddAt(existing.Index, child);
        }

        /// <summary>
        /// <see cref="GridContainerItemCollection"/> does not support this method, and will throw a <see cref="NotSupportedException"/>.
        /// </summary>
        /// <param name="child">The <see cref="Control"/> to remove from the <see cref="GridContainerItemCollection"/>.</param>
        /// <returns>true if item is successfully removed; otherwise, false. This method also returns false if item was not found in the <see cref="GridContainerItemCollection"/>.</returns>
        public override bool Remove(Control child) => throw new NotSupportedException();
    }
}