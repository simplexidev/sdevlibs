using System;
using LibUISharp.Internal;

namespace LibUISharp
{
    /// <summary>
    /// Represents a container control that lists controls vertically with a corresponding label.
    /// </summary>
    [NativeType("uiForm")]
    public class FormContainer : MultiContainer<FormContainer, FormContainer.ControlList, Control>
    {
        private bool isPadded;

        /// <summary>
        /// Initializes a new instance of the <see cref="FormContainer"/> class.
        /// </summary>
        public FormContainer() => Handle = NativeCalls.NewForm();

        /// <summary>
        /// Gets or sets a value indiating whether this <see cref="FormContainer"/> has interior padding or not.
        /// </summary>
        public bool IsPadded
        {
            get
            {
                isPadded = NativeCalls.FormPadded(Handle);
                return isPadded;
            }
            set
            {
                if (isPadded != value)
                {
                    NativeCalls.FormSetPadded(Handle, value);
                    isPadded = value;
                }
            }
        }

        /// <summary>
        /// Represents a collection of child <see cref="Control"/> objects inside of a <see cref="FormContainer"/>.
        /// </summary>
        public class ControlList : ControlListBase
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="ControlList"/> class with the specified parent.
            /// </summary>
            /// <param name="owner">The parent <see cref="StackContainer"/> of this <see cref="ControlList"/>.</param>
            public ControlList(FormContainer owner) : base(owner) { }

            /// <summary>
            /// <see cref="ControlList"/> does not support this method, and will throw a <see cref="NotSupportedException"/>.
            /// </summary>
            /// <param name="child">The <see cref="Control"/> to be added to the end of the <see cref="ControlList"/>.</param>
            public override void Add(Control child) => throw new NotSupportedException();

            /// <summary>
            /// Adds a <see cref="Control"/> to the end of the <see cref="ControlList"/>.
            /// </summary>
            /// <param name="label">The text beside the child <see cref="Control"/>.</param>
            /// <param name="child">The <see cref="Control"/> to be added to the end of the <see cref="ControlList"/>.</param>
            /// <param name="stretches">Whether or not <paramref name="child"/> stretches the area of the parent <see cref="Control"/></param>
            public void Add(string label, Control child, bool stretches = false)
            {
                base.Add(child);
                NativeCalls.FormAppend(Owner.Handle, label, child.Handle, stretches);
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
                    NativeCalls.FormDelete(Owner.Handle, child.Index);
                    return true;
                }
                return false;
            }
        }
    }
}