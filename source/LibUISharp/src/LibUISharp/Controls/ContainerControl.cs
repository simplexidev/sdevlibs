using System;

namespace LibUISharp.Controls
{
    public class ContainerControl : Control { }

    public class ContainerControl<TContainer, TCollection> : ContainerControl, IContainerControl<TContainer, TCollection>
        where TContainer : ContainerControl
        where TCollection : ControlCollection<TContainer>
    {
        public override void Dispose()
        {
            Children.Clear();
            base.Dispose();
        }

        private TCollection children;

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

    internal interface IContainerControl<TContainer, out TCollection>
        where TContainer : ContainerControl
        where TCollection : ControlCollection<TContainer>
    {
        TCollection Children { get; }
    }
}