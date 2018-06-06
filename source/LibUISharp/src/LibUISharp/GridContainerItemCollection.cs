using LibUISharp.Drawing;
using System;
using static LibUISharp.Native.NativeMethods;

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
        /// <param name="item">The <see cref="Control"/> to be added to the end of the <see cref="GridContainerItemCollection"/>.</param>
        public override void Add(Control item) => Add(item, 0, 0, 0, 0, 0, 0, Alignment.Fill);

        /// <summary>
        /// Adds a <see cref="Control"/> to the end of the <see cref="GridContainerItemCollection"/>.
        /// </summary>
        /// <param name="item">The <see cref="Control"/> to be added to the end of the <see cref="GridContainerItemCollection"/>.</param>
        /// <param name="rect">A <see cref="Rectangle"/> representing the location and size of <paramref name="item"/>.</param>
        /// <param name="expand">A <see cref="Size"/> representing the h and v-expand.</param>
        /// <param name="alignment">The alignment of <paramref name="item"/>.</param>
        public void Add(Control item, Rectangle rect, Size expand, Alignment alignment) => Add(item, rect.Location, rect.Size, expand, alignment);

        /// <summary>
        /// Adds a <see cref="Control"/> to the end of the <see cref="GridContainerItemCollection"/>.
        /// </summary>
        /// <param name="item">The <see cref="Control"/> to be added to the end of the <see cref="GridContainerItemCollection"/>.</param>
        /// <param name="location">The top-left location of <paramref name="item"/>.</param>
        /// <param name="size">The size of <paramref name="item"/>.</param>
        /// <param name="expand">A <see cref="Size"/> representing the h and v-expand.</param>
        /// <param name="alignment">The alignment of <paramref name="item"/>.</param>
        public void Add(Control item, Point location, Size size, Size expand, Alignment alignment) => Add(item, location.X, location.Y, size.Width, size.Height, expand.Width, expand.Height, alignment);

        /// <summary>
        /// Adds a <see cref="Control"/> to the end of the <see cref="GridContainerItemCollection"/>.
        /// </summary>
        /// <param name="item">The <see cref="Control"/> to be added to the end of the <see cref="GridContainerItemCollection"/>.</param>
        /// <param name="x">The x-coordinate of the item's location.</param>
        /// <param name="y">The y-coordinate of the item's location.</param>
        /// <param name="width">The width of the item.</param>
        /// <param name="height">The height of the item.</param>
        /// <param name="hexpand">The horizontal expand of <paramref name="item"/>.</param>
        /// <param name="vexpand">The vertical expand of <paramref name="item"/>.</param>
        /// <param name="alignment">The alignment of <paramref name="item"/>.</param>
        public void Add(Control item, int x, int y, int width, int height, int hexpand, int vexpand, Alignment alignment)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));
            if (Contains(item))
                throw new InvalidOperationException("Cannot add a Control that is already contained in this GridContainerItemCollection.");
            ToUIAligns(alignment, out Libui.uiAlign halign, out Libui.uiAlign valign);
            Libui.uiGridAppend(Owner, item, x, y, width, height, hexpand, halign, vexpand, valign);
            base.Add(item);
        }
        /// <summary>
        /// <see cref="GridContainerItemCollection"/> does not support this method, and will throw a <see cref="NotSupportedException"/>.
        /// Use <see cref="AddAt(Control, Control, RelativeAlignment, int, int, int, int, Alignment)"/> or <see cref="AddAt(Control, Control, RelativeAlignment, Size, Size, Alignment)"/> instead.
        /// </summary>
        /// <param name="index">The zero-based index at which item should be inserted.</param>
        /// <param name="item">The <see cref="Control"/> to insert into the <see cref="GridContainerItemCollection"/>.</param>
        public override void AddAt(int index, Control item) => throw new NotSupportedException();

        /// <summary>
        /// Adds a control to the <see cref="GridContainerItemCollection"/> at the specified index.
        /// </summary>
        /// <param name="existing">The existing control at which item should be inserted.</param>
        /// <param name="item">The <see cref="Control"/> to insert into the <see cref="GridContainerItemCollection"/>.</param>
        /// <param name="relativeAlignment">The relative placement of the item control to the existing one.</param>
        /// <param name="size">The size of <paramref name="item"/>.</param>
        /// <param name="expand">A <see cref="Size"/> representing the h and v-expand.</param>
        /// <param name="alignment">The alignment of <paramref name="item"/> in the container.</param>
        public void AddAt(Control existing, Control item, RelativeAlignment relativeAlignment, Size size, Size expand, Alignment alignment) => AddAt(existing, item, relativeAlignment, size.Width, size.Height, expand.Width, expand.Height, alignment);

        /// <summary>
        /// Adds a control to the <see cref="GridContainerItemCollection"/> at the specified index.
        /// </summary>
        /// <param name="existing">The existing control at which item should be inserted.</param>
        /// <param name="item">The <see cref="Control"/> to insert into the <see cref="GridContainerItemCollection"/>.</param>
        /// <param name="relativeAlignment">The relative placement of the item control to the existing one.</param>
        /// <param name="width">The width of the item.</param>
        /// <param name="height">The height of the item.</param>
        /// <param name="hexpand">The horizontal expand of <paramref name="item"/>.</param>
        /// <param name="vexpand">The vertical expand of <paramref name="item"/>.</param>
        /// <param name="alignment">The alignment of <paramref name="item"/>.</param>
        public void AddAt(Control existing, Control item, RelativeAlignment relativeAlignment, int width, int height, int hexpand, int vexpand, Alignment alignment)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));
            if (Contains(item))
                throw new InvalidOperationException("Cannot add a Control that is already contained in this GridContainerItemCollection.");
            ToUIAligns(alignment, out Libui.uiAlign halign, out Libui.uiAlign valign);
            Libui.uiGridInsertAt(Owner, item, existing, relativeAlignment, width, height, hexpand, halign, vexpand, valign);
            base.AddAt(existing.Index, item);
        }

        /// <summary>
        /// <see cref="GridContainerItemCollection"/> does not support this method, and will throw a <see cref="NotSupportedException"/>.
        /// </summary>
        /// <param name="item">The <see cref="Control"/> to remove from the <see cref="GridContainerItemCollection"/>.</param>
        /// <returns>true if item is successfully removed; otherwise, false. This method also returns false if item was not found in the <see cref="GridContainerItemCollection"/>.</returns>
        public override bool Remove(Control item) => throw new NotSupportedException();

        private static void ToUIAligns(Alignment a, out Libui.uiAlign hAlign, out Libui.uiAlign vAlign)
        {
            switch (a)
            {
                case Alignment.Fill:
                    vAlign = Libui.uiAlign.uiAlignFill;
                    hAlign = Libui.uiAlign.uiAlignFill;
                    break;
                case Alignment.Center:
                    vAlign = Libui.uiAlign.uiAlignCenter;
                    hAlign = Libui.uiAlign.uiAlignCenter;
                    break;
                case Alignment.Top:
                    vAlign = Libui.uiAlign.uiAlignStart;
                    hAlign = Libui.uiAlign.uiAlignFill;
                    break;
                case Alignment.TopLeft:
                    vAlign = Libui.uiAlign.uiAlignStart;
                    hAlign = Libui.uiAlign.uiAlignStart;
                    break;
                case Alignment.TopCenter:
                    vAlign = Libui.uiAlign.uiAlignStart;
                    hAlign = Libui.uiAlign.uiAlignCenter;
                    break;
                case Alignment.TopRight:
                    vAlign = Libui.uiAlign.uiAlignStart;
                    hAlign = Libui.uiAlign.uiAlignEnd;
                    break;
                case Alignment.Left:
                    vAlign = Libui.uiAlign.uiAlignFill;
                    hAlign = Libui.uiAlign.uiAlignStart;
                    break;
                case Alignment.LeftCenter:
                    vAlign = Libui.uiAlign.uiAlignCenter;
                    hAlign = Libui.uiAlign.uiAlignStart;
                    break;
                case Alignment.Right:
                    vAlign = Libui.uiAlign.uiAlignFill;
                    hAlign = Libui.uiAlign.uiAlignEnd;
                    break;
                case Alignment.RightCenter:
                    vAlign = Libui.uiAlign.uiAlignCenter;
                    hAlign = Libui.uiAlign.uiAlignEnd;
                    break;
                case Alignment.Bottom:
                    vAlign = Libui.uiAlign.uiAlignEnd;
                    hAlign = Libui.uiAlign.uiAlignFill;
                    break;
                case Alignment.BottomLeft:
                    vAlign = Libui.uiAlign.uiAlignEnd;
                    hAlign = Libui.uiAlign.uiAlignStart;
                    break;
                case Alignment.BottomCenter:
                    vAlign = Libui.uiAlign.uiAlignEnd;
                    hAlign = Libui.uiAlign.uiAlignCenter;
                    break;
                case Alignment.BottomRight:
                    vAlign = Libui.uiAlign.uiAlignEnd;
                    hAlign = Libui.uiAlign.uiAlignEnd;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("hAlign|vAlign");
            }
        }
    }
}