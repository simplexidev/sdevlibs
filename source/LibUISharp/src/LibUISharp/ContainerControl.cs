using System;

namespace LibUISharp
{
    /// <summary>
    /// Represents a <see cref="Control"/> that contains a collection of child <see cref="Control"/>s.
    /// </summary>
    public class ContainerControl : Control { }

    /// <summary>
    /// Represents a <see cref="Control"/> that contains a collection of child <see cref="Control"/>s.
    /// </summary>
    public class ContainerControl<TContainer, TCollection> : ContainerControl, IContainerControl<TContainer, TCollection>
        where TContainer : ContainerControl
        where TCollection : ControlCollection<TContainer>
    {
        private TCollection children;

        /// <inheritdoc />
        public override void Dispose()
        {
            Children.Clear();
            base.Dispose();
        }

        /// <summary>
        /// Gets this <see cref="ContainerControl{TContainer, TCollection}"/>'s child <see cref="Control"/>s.
        /// </summary>
        public virtual TCollection Children
        {
            get
            {
                if (children == null)
                    children = (TCollection)Activator.CreateInstance(typeof(TCollection), this);
                return children;
            }
        }
    }
}