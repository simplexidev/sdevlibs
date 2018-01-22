using System;
using System.Runtime.InteropServices;
using LibUISharp.Internal;
using static LibUISharp.Internal.UI;

namespace LibUISharp
{
    public class Form : ContainerControl<FormControlCollection, Form>
    {
        public Form() => Handle = new UIControlHandle(uiNewForm());

        private bool hasPadding;
        public bool HasPadding
        {
            get => hasPadding = uiFormPadded(Handle.DangerousGetHandle());
            set
            {
                if (hasPadding != value)
                {
                    uiFormSetPadded(Handle.DangerousGetHandle(), value);
                    hasPadding = value;
                }
            }
        }
    }

    public class FormControlCollection : ControlCollection<Form>
    {
        public FormControlCollection(Form owner) : base(owner) { }

        public override void Add(Control item) => Add("Label", item);

        public virtual void Add(string label, Control child, bool stretchy = false)
        {
            if (Contains(child)) throw new InvalidOperationException("Cannot add duplicate controls.");
            if (child == null) return;
            IntPtr strPtr = MarshalHelper.StringToUTF8(label);
            uiFormAppend(Owner.Handle.DangerousGetHandle(), strPtr, child.Handle.DangerousGetHandle(), stretchy);
            Marshal.FreeHGlobal(strPtr);
            base.Add(child);
        }

        public override bool Remove(Control item)
        {
            uiFormDelete(Owner.Handle.DangerousGetHandle(), item.Index);
            return base.Remove(item);
        }
    }
}