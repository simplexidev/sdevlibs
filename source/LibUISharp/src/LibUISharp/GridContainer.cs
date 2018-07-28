using System;
using System.Drawing;
using LibUISharp.Internal;
using static LibUISharp.Internal.Libraries;

namespace LibUISharp
{
    /// <summary>
    /// Represents a container control that allows for specific sizes and positions for each child control.
    /// </summary>
    [NativeType("uiGrid")]
    public class GridContainer : MultiContainer<GridContainer, GridContainer.ControlList, Control>
    {
        private bool isPadded;

        /// <summary>
        /// Initializes a new instance of the <see cref="GridContainer"/> class.
        /// </summary>
        public GridContainer() => Handle = Libui.Call<Libui.uiNewGrid>()();

        /// <summary>
        /// Gets or sets a value indiating whether this <see cref="GridContainer"/> has interior padding or not.
        /// </summary>
        public bool IsPadded
        {
            get
            {
                isPadded = Libui.Call<Libui.uiGridPadded>()(this);
                return isPadded;
            }
            set
            {
                if (isPadded != value)
                {
                    Libui.Call<Libui.uiGridSetPadded>()(this, value);
                    isPadded = value;
                }
            }
        }

        /// <summary>
        /// Represents a collection of child <see cref="Control"/> objects inside of a <see cref="GridContainer"/>.
        /// </summary>
        public class ControlList : ControlListBase
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="ControlList"/> class with the specified parent.
            /// </summary>
            /// <param name="owner">The parent <see cref="GridContainer"/> of this <see cref="ControlList"/>.</param>
            public ControlList(GridContainer owner) : base(owner) { }

            /// <summary>
            /// Adds a <see cref="Control"/> to the end of the <see cref="ControlList"/>.
            /// </summary>
            /// <param name="child">The <see cref="Control"/> to be added to the end of the <see cref="ControlList"/>.</param>
            public override void Add(Control child) => Add(child, 0, 0, 0, 0, 0, 0, Alignment.Fill);

            /// <summary>
            /// Adds a <see cref="Control"/> to the end of the <see cref="ControlList"/>.
            /// </summary>
            /// <param name="child">The <see cref="Control"/> to be added to the end of the <see cref="ControlList"/>.</param>
            /// <param name="rect">A <see cref="Rectangle"/> representing the location and size of <paramref name="child"/>.</param>
            /// <param name="expand">A <see cref="Size"/> representing the h and v-expand.</param>
            /// <param name="alignment">The alignment of <paramref name="child"/>.</param>
            public void Add(Control child, Rectangle rect, Size expand, Alignment alignment) => Add(child, rect.Location, rect.Size, expand, alignment);

            /// <summary>
            /// Adds a <see cref="Control"/> to the end of the <see cref="ControlList"/>.
            /// </summary>
            /// <param name="child">The <see cref="Control"/> to be added to the end of the <see cref="ControlList"/>.</param>
            /// <param name="location">The top-left location of <paramref name="child"/>.</param>
            /// <param name="size">The size of <paramref name="child"/>.</param>
            /// <param name="expand">A <see cref="Size"/> representing the h and v-expand.</param>
            /// <param name="alignment">The alignment of <paramref name="child"/>.</param>
            public void Add(Control child, Point location, Size size, Size expand, Alignment alignment) => Add(child, location.X, location.Y, size.Width, size.Height, expand.Width, expand.Height, alignment);

            /// <summary>
            /// Adds a <see cref="Control"/> to the end of the <see cref="ControlList"/>.
            /// </summary>
            /// <param name="child">The <see cref="Control"/> to be added to the end of the <see cref="ControlList"/>.</param>
            /// <param name="x">The x-coordinate of the child's location.</param>
            /// <param name="y">The y-coordinate of the child's location.</param>
            /// <param name="width">The width of the child.</param>
            /// <param name="height">The height of the child.</param>
            /// <param name="hexpand">The horizontal expand of <paramref name="child"/>.</param>
            /// <param name="vexpand">The vertical expand of <paramref name="child"/>.</param>
            /// <param name="alignment">The alignment of <paramref name="child"/>.</param>
            public void Add(Control child, int x, int y, int width, int height, int hexpand, int vexpand, Alignment alignment)
            {
                base.Add(child);
                ToNativeAligns(alignment, out NativeAlignment halign, out NativeAlignment valign);
                Libui.Call<Libui.uiGridAppend>()(Owner, child, x, y, width, height, hexpand, halign, vexpand, valign);
            }

            /// <summary>
            /// <see cref="ControlList"/> does not support this method, and will throw a <see cref="NotSupportedException"/>.
            /// Use <see cref="Insert(Control, Control, RelativeAlignment, int, int, int, int, Alignment)"/> or <see cref="Insert(Control, Control, RelativeAlignment, Size, Size, Alignment)"/> instead.
            /// </summary>
            /// <param name="index">The zero-based index at which child should be inserted.</param>
            /// <param name="child">The <see cref="Control"/> to insert into the <see cref="ControlList"/>.</param>
            public override void Insert(int index, Control child) => throw new NotSupportedException();

            /// <summary>
            /// Adds a <see cref="Control"/> to the <see cref="ControlList"/> at the specified index.
            /// </summary>
            /// <param name="existing">The existing control at which child should be inserted.</param>
            /// <param name="child">The <see cref="Control"/> to insert into the <see cref="ControlList"/>.</param>
            /// <param name="relativeAlignment">The relative placement of the child control to the existing one.</param>
            /// <param name="size">The size of <paramref name="child"/>.</param>
            /// <param name="expand">A <see cref="Size"/> representing the h and v-expand.</param>
            /// <param name="alignment">The alignment of <paramref name="child"/> in the container.</param>
            public void Insert(Control existing, Control child, RelativeAlignment relativeAlignment, Size size, Size expand, Alignment alignment) => Insert(existing, child, relativeAlignment, size.Width, size.Height, expand.Width, expand.Height, alignment);

            /// <summary>
            /// Adds a <see cref="Control"/> to the <see cref="ControlList"/> at the specified index.
            /// </summary>
            /// <param name="existing">The existing control at which child should be inserted.</param>
            /// <param name="child">The <see cref="Control"/> to insert into the <see cref="ControlList"/>.</param>
            /// <param name="relativeAlignment">The relative placement of the child control to the existing one.</param>
            /// <param name="width">The width of the child.</param>
            /// <param name="height">The height of the child.</param>
            /// <param name="hexpand">The horizontal expand of <paramref name="child"/>.</param>
            /// <param name="vexpand">The vertical expand of <paramref name="child"/>.</param>
            /// <param name="alignment">The alignment of <paramref name="child"/>.</param>
            public void Insert(Control existing, Control child, RelativeAlignment relativeAlignment, int width, int height, int hexpand, int vexpand, Alignment alignment)
            {
                base.Insert(existing.Index, child);
                ToNativeAligns(alignment, out NativeAlignment halign, out NativeAlignment valign);
                Libui.Call<Libui.uiGridInsertAt>()(Owner, child, existing, relativeAlignment, width, height, hexpand, halign, vexpand, valign);
            }

            /// <summary>
            /// <see cref="ControlList"/> does not support this method, and will throw a <see cref="NotSupportedException"/>.
            /// </summary>
            /// <param name="child">The <see cref="Control"/> to remove from the <see cref="ControlList"/>.</param>
            /// <returns>true if child is successfully removed; otherwise, false. This method also returns false if child was not found in the <see cref="ControlList"/>.</returns>
            public override bool Remove(Control child) => throw new NotSupportedException();

            private static void ToNativeAligns(Alignment a, out NativeAlignment hAlign, out NativeAlignment vAlign)
            {
                switch (a)
                {
                    case Alignment.Fill:
                        vAlign = NativeAlignment.Fill;
                        hAlign = NativeAlignment.Fill;
                        break;
                    case Alignment.Center:
                        vAlign = NativeAlignment.Center;
                        hAlign = NativeAlignment.Center;
                        break;
                    case Alignment.Top:
                        vAlign = NativeAlignment.Start;
                        hAlign = NativeAlignment.Fill;
                        break;
                    case Alignment.TopLeft:
                        vAlign = NativeAlignment.Start;
                        hAlign = NativeAlignment.Start;
                        break;
                    case Alignment.TopCenter:
                        vAlign = NativeAlignment.Start;
                        hAlign = NativeAlignment.Center;
                        break;
                    case Alignment.TopRight:
                        vAlign = NativeAlignment.Start;
                        hAlign = NativeAlignment.End;
                        break;
                    case Alignment.Left:
                        vAlign = NativeAlignment.Fill;
                        hAlign = NativeAlignment.Start;
                        break;
                    case Alignment.LeftCenter:
                        vAlign = NativeAlignment.Center;
                        hAlign = NativeAlignment.Start;
                        break;
                    case Alignment.Right:
                        vAlign = NativeAlignment.Fill;
                        hAlign = NativeAlignment.End;
                        break;
                    case Alignment.RightCenter:
                        vAlign = NativeAlignment.Center;
                        hAlign = NativeAlignment.End;
                        break;
                    case Alignment.Bottom:
                        vAlign = NativeAlignment.End;
                        hAlign = NativeAlignment.Fill;
                        break;
                    case Alignment.BottomLeft:
                        vAlign = NativeAlignment.End;
                        hAlign = NativeAlignment.Start;
                        break;
                    case Alignment.BottomCenter:
                        vAlign = NativeAlignment.End;
                        hAlign = NativeAlignment.Center;
                        break;
                    case Alignment.BottomRight:
                        vAlign = NativeAlignment.End;
                        hAlign = NativeAlignment.End;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(a));
                }
            }
        }
    }
}