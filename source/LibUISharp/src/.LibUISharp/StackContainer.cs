using LibUISharp.Internal;
using System;
using static LibUISharp.Internal.Libraries;

namespace LibUISharp
{
    /// <summary>
    /// Arranges child elements into a single line that can be oriented horizontally or vertically.
    /// </summary>
    [LibuiType("uiBox")]
    public class StackContainer : ContainerControl<Control, StackContainer.ItemCollection>
    {
        private bool isPadded;

        /// <summary>
        /// Initializes a new instance of the <see cref="StackContainer"/> class with the specified orientation.
        /// </summary>
        /// <param name="orientation">The orientation controls are placed in the <see cref="StackContainer"/>.</param>
        public StackContainer(Orientation orientation)
        {
            switch (orientation)
            {
                case Orientation.Horizontal:
                    Handle = Libui.Call<Libui.uiNewHorizontalBox>()();
                    break;
                case Orientation.Vertical:
                    Handle = Libui.Call<Libui.uiNewVerticalBox>()();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(orientation));
            }
            Orientation = orientation;
        }

        /// <summary>
        /// Gets the dimension be which child controls are placed.
        /// </summary>
        public Orientation Orientation { get; }

        /// <summary>
        /// Gets or sets a value indiating whether this <see cref="StackContainer"/> has interior isPadded or not.
        /// </summary>
        public bool IsPadded
        {
            get
            {
                isPadded = Libui.Call<Libui.uiBoxPadded>()(this);
                return isPadded;
            }
            set
            {
                if (isPadded != value)
                {
                    Libui.Call<Libui.uiBoxSetPadded>()(this, value);
                    isPadded = value;
                }
            }
        }

        /// <summary>
        /// Represents a collection of child <see cref="Control"/>s inside of a <see cref="StackContainer"/>.
        /// </summary>
        public sealed class ItemCollection : ControlCollection<Control>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="ItemCollection"/> class with the specified parent.
            /// </summary>
            /// <param name="owner">The parent <see cref="StackContainer"/> of this <see cref="ItemCollection"/>.</param>
            public ItemCollection(StackContainer owner) : base(owner) { }

            /// <summary>
            /// Adds a <see cref="Control"/> to the end of the <see cref="ItemCollection"/>.
            /// </summary>
            /// <param name="item">The <see cref="Control"/> to be added to the end of the <see cref="ItemCollection"/>.</param>
            public override void Add(Control item) => Add(item, false);

            /// <summary>
            /// Adds a <see cref="Control"/> to the end of the <see cref="ItemCollection"/>.
            /// </summary>
            /// <param name="item">The <see cref="Control"/> to be added to the end of the <see cref="ItemCollection"/>.</param>
            /// <param name="stretches">Whether or not <paramref name="item"/> stretches the area of the parent <see cref="Control"/></param>
            public void Add(Control item, bool stretches = false)
            {
                if (Contains(item)) throw new InvalidOperationException("Cannot add the same control more than once.");
                if (item == null) return;
                Libui.Call<Libui.uiBoxAppend>()(Owner, item, stretches);
                base.Add(item);
            }

            /// <summary>
            /// <see cref="ItemCollection"/> does not support this method, and will throw a <see cref="NotSupportedException"/>.
            /// </summary>
            /// <param name="index">The zero-based index at which item should be inserted.</param>
            /// <param name="item">The <see cref="Control"/> to insert into the <see cref="ItemCollection"/>.</param>
            public override void AddAt(int index, Control item) => throw new NotSupportedException();

            /// <summary>
            /// Removes the first occurrence of a specific <see cref="Control"/> from the <see cref="ItemCollection"/>.
            /// </summary>
            /// <param name="item">The <see cref="Control"/> to remove from the <see cref="ItemCollection"/>.</param>
            /// <returns>true if item is successfully removed; otherwise, false. This method also returns false if item was not found in the <see cref="ItemCollection"/>.</returns>
            public override bool Remove(Control item)
            {
                Libui.Call<Libui.uiBoxDelete>()(Owner, item.Index);
                return base.Remove(item);
            }
        }
    }
}