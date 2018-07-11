using LibUISharp.Internal;
using System;
using static LibUISharp.Internal.Libraries;

namespace LibUISharp
{ 
    /// <summary>
    /// Arranges child elements into a single line that can be oriented horizontally or vertically.
    /// </summary>
    [LibuiType("uiBox")]
    public class StackContainer : MultiContainer<StackContainer, StackContainer.ControlCollection, Control>
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
        public new class ControlCollection : MultiContainer<StackContainer, ControlCollection, Control>.ControlCollection
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="ControlCollection"/> class with the specified parent.
            /// </summary>
            /// <param name="owner">The parent <see cref="StackContainer"/> of this <see cref="ControlCollection"/>.</param>
            public ControlCollection(StackContainer owner) : base(owner) { }

            /// <summary>
            /// Adds a <see cref="Control"/> to the end of the <see cref="ControlCollection"/>.
            /// </summary>
            /// <param name="child">The <see cref="Control"/> to be added to the end of the <see cref="ControlCollection"/>.</param>
            public override void Add(Control child) => Add(child, false);

            /// <summary>
            /// Adds a <see cref="Control"/> to the end of the <see cref="ControlCollection"/>.
            /// </summary>
            /// <param name="child">The <see cref="Control"/> to be added to the end of the <see cref="ControlCollection"/>.</param>
            /// <param name="stretches">Whether or not <paramref name="child"/> stretches the area of the parent <see cref="Control"/></param>
            public void Add(Control child, bool stretches = false)
            {
                if (Contains(child)) throw new InvalidOperationException("Cannot add the same control more than once.");
                if (child == null) return;
                Libui.Call<Libui.uiBoxAppend>()(Owner, child, stretches);
                base.Add(child);
            }

            /// <summary>
            /// <see cref="ControlCollection"/> does not support this method, and will throw a <see cref="NotSupportedException"/>.
            /// </summary>
            /// <param name="index">The zero-based index at which child should be inserted.</param>
            /// <param name="child">The <see cref="Control"/> to insert into the <see cref="ControlCollection"/>.</param>
            public override void AddAt(int index, Control child) => throw new NotSupportedException();

            /// <summary>
            /// Removes the first occurrence of a specific <see cref="Control"/> from the <see cref="ControlCollection"/>.
            /// </summary>
            /// <param name="child">The <see cref="Control"/> to remove from the <see cref="ControlCollection"/>.</param>
            /// <returns>true if child is successfully removed; otherwise, false. This method also returns false if child was not found in the <see cref="ControlCollection"/>.</returns>
            public override bool Remove(Control child)
            {
                Libui.Call<Libui.uiBoxDelete>()(Owner, child.Index);
                return base.Remove(child);
            }
        }
    }
}