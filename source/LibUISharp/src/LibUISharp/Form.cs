using LibUISharp.Collections;
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
}