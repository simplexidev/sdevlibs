using LibUISharp.Internal;
using LibUISharp.SafeHandles;
using System;
using System.Runtime.InteropServices;

// uiForm
namespace LibUISharp
{
    public class Form : ContainerControl<Form, FormItemCollection>
    {
        private bool padding;

        public Form() => Handle = new SafeControlHandle(LibuiLibrary.uiNewForm());

        public bool Padding
        {
            get
            {
                padding = LibuiLibrary.uiFormPadded(Handle.DangerousGetHandle());
                return padding;
            }
            set
            {
                if (padding != value)
                {
                    LibuiLibrary.uiFormSetPadded(Handle.DangerousGetHandle(), value);
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
            IntPtr strPtr = label.ToLibuiString();
            LibuiLibrary.uiFormAppend(Parent.Handle.DangerousGetHandle(), strPtr, child.Handle.DangerousGetHandle(), stretch);
            Marshal.FreeHGlobal(strPtr);
            base.Add(child);
        }

        public override bool Remove(Control item)
        {
            LibuiLibrary.uiFormDelete(Parent.Handle.DangerousGetHandle(), item.Index);
            return base.Remove(item);
        }
    }
}