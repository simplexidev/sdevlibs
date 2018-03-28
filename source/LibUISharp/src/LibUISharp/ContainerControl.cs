using System;
using LibUISharp.Collections;

namespace LibUISharp
{
    public class ContainerControl : Control { }

    public class ContainerControl<TChild, TContainerControl> : ContainerControl, IContainerControl<TChild, TContainerControl>
        where TChild : ControlCollection<TContainerControl>
        where TContainerControl : ContainerControl
    {
        public override void Dispose()
        {
            Children.Clear();
            base.Dispose();
        }

        private TChild children;

        public virtual TChild Children
        {
            get
            {
                if (children == null)
                    children = (TChild)Activator.CreateInstance(typeof(TChild), this);
                return children;
            }
        }
    }

    interface IContainerControl<out TChild, TContainerControl>
        where TChild : ControlCollection<TContainerControl>
        where TContainerControl : ContainerControl
    {
        TChild Children { get; }
    }
}