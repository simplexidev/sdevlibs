using System;
using static LibUISharp.Internal.LibUI;

namespace LibUISharp
{
    public class Form : ContainerControl<FormItemCollection, Form>
    {
        private bool padding;

        public Form() => Handle = uiNewForm();

        public bool Padding
        {
            get
            {
                padding = uiFormPadded(Handle);
                return padding;
            }
            set
            {
                if (padding != value)
                {
                    uiFormSetPadded(Handle, value);
                    padding = value;
                }
            }
        }
    }

    public class FormItemCollection : ControlCollection<Form>
    {
        public FormItemCollection(Form owner) : base(owner) { }

        public override void Add(Control item) => Add("Label", item);

        public virtual void Add(string label, Control child, bool stretch = false)
        {
            if (Contains(child))
                throw new InvalidOperationException("cannot add the same control.");
            if (child == null) return;
            uiFormAppend(Owner.Handle, label, child.Handle, stretch);
            base.Add(child);
        }

        public override bool Remove(Control item)
        {
            uiFormDelete(Owner.Handle, item.Index);
            return base.Remove(item);
        }
    }
}