using LibUISharp.Internal;
using LibUISharp.SafeHandles;

namespace LibUISharp
{
    /// <summary>
    /// Represents a container control that lists controls horizontally with a corresponding label.
    /// </summary>
    public class FormContainer : ContainerControl<Control, FormContainerItemCollection>
    {
        private bool padding;

        /// <summary>
        /// Initializes a new instance of the <see cref="FormContainer"/> class.
        /// </summary>
        public FormContainer() => Handle = new SafeControlHandle(LibuiLibrary.uiNewForm());

        /// <summary>
        /// Gets or sets a value indiating whether this <see cref="FormContainer"/> has interior padding or not.
        /// </summary>
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
}