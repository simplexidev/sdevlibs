using System;
using static LibUISharp.Internal.LibUI;

namespace LibUISharp
{
    public class Form : ContainerControl<FormItemCollection, Form>
    {
        private bool padded;

        public Form() => Handle = uiNewForm();

        public bool Padded
        {
            get
            {
                padded = uiFormPadded(Handle);
                return padded;
            }
            set
            {
                if (padded != value)
                {
                    uiFormSetPadded(Handle, value);
                    padded = value;
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