using System;
using LibUISharp.Internal;
using static LibUISharp.Internal.Libraries;

namespace LibUISharp
{
    /// <summary>
    /// Arranges child elements into a single line that can be oriented horizontally or vertically.
    /// </summary>
    [LibuiType("uiBox")]
    public class StackContainer : MultiContainer<StackContainer, StackContainer.ControlList, Control>
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
        /// Gets or sets a value indicating whether this <see cref="StackContainer"/> has interior isPadded or not.
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
        /// Represents a collection of child <see cref="Control"/> objects inside of a <see cref="StackContainer"/>.
        /// </summary>
        public class ControlList : ControlListBase
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="ControlList"/> class with the specified parent.
            /// </summary>
            /// <param name="owner">The parent <see cref="StackContainer"/> of this <see cref="ControlList"/>.</param>
            public ControlList(StackContainer owner) : base(owner) { }

            /// <summary>
            /// Adds a <see cref="Control"/> to the end of the <see cref="ControlList"/>.
            /// </summary>
            /// <param name="child">The <see cref="Control"/> to be added to the end of the <see cref="ControlList"/>.</param>
            public override void Add(Control child) => Add(child, false);

            /// <summary>
            /// Adds a <see cref="Control"/> to the end of the <see cref="ControlList"/>.
            /// </summary>
            /// <param name="child">The <see cref="Control"/> to be added to the end of the <see cref="ControlList"/>.</param>
            /// <param name="stretches">Whether or not <paramref name="child"/> stretches the area of the parent <see cref="Control"/></param>
            public void Add(Control child, bool stretches)
            {
                base.Add(child);
                Libui.Call<Libui.uiBoxAppend>()(Owner, child, stretches);
            }

            /// <summary>
            /// <see cref="ControlList"/> does not support this method, and will throw a <see cref="NotSupportedException"/>.
            /// </summary>
            /// <param name="index">The zero-based index at which child should be inserted.</param>
            /// <param name="child">The <see cref="Control"/> to insert into the <see cref="ControlList"/>.</param>
            public override void Insert(int index, Control child) => throw new NotSupportedException();

            /// <summary>
            /// Removes the first occurrence of a specific <see cref="Control"/> from the <see cref="ControlList"/>.
            /// </summary>
            /// <param name="child">The <see cref="Control"/> to remove from the <see cref="ControlList"/>.</param>
            /// <returns>true if child is successfully removed; otherwise, false. This method also returns false if child was not found in the <see cref="ControlList"/>.</returns>
            public new bool Remove(Control child)
            {
                if (base.Remove(child))
                {
                    Libui.Call<Libui.uiBoxDelete>()(Owner, child.Index);
                    return true;
                }
                return false;
            }
        }
    }
}