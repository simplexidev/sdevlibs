using static LibUISharp.Native.NativeMethods;

namespace LibUISharp
{
    /// <summary>
    /// Represents a container control that lists controls vertically with a corresponding label.
    /// </summary>
    public class FormContainer : ContainerControl<Control, FormContainerItemCollection>
    {
        private bool isPadded;

        /// <summary>
        /// Initializes a new instance of the <see cref="FormContainer"/> class.
        /// </summary>
        public FormContainer() => Handle = Libui.uiNewForm();

        /// <summary>
        /// Gets or sets a value indiating whether this <see cref="FormContainer"/> has interior padding or not.
        /// </summary>
        public bool IsPadded
        {
            get
            {
                isPadded = Libui.uiFormPadded(this);
                return isPadded;
            }
            set
            {
                if (isPadded != value)
                {
                    Libui.uiFormSetPadded(this, value);
                    isPadded = value;
                }
            }
        }
    }
}