using LibUISharp.Internal;
using LibUISharp.SafeHandles;

namespace LibUISharp
{
    /// <summary>
    /// Defines the base class for controls, which are <see cref="UIComponent{T}"/> objects with visual representation.
    /// </summary>
    [NativeType("uiControl")]
    public abstract class Control : UIComponent<SafeControlHandle>
    {
        private bool enabled, visible;

        /// <summary>
        /// Initializes a new instance of the <see cref="Control"/> class.
        /// </summary>
        protected Control()
        {
            if (this is Window)
                visible = false;
            else
                visible = true;
        }

        /// <summary>
        /// Gets the parent control of this control.
        /// </summary>
        public Control Parent { get; internal set; }

        /// <summary>
        /// Gets the index of this control.
        /// </summary>
        public int Index { get; protected internal set; }

        /// <summary>
        /// Gets or sets a value indicating whether the control can respond to interaction.
        /// </summary>
        public virtual bool Enabled
        {
            get => NativeCalls.ControlEnabled(Handle);
            set
            {
                if (enabled == value) return;
                if (value) Enable();
                else Disable();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the control and all its child controls are displayed.
        /// </summary>
        public virtual bool Visible
        {
            get => NativeCalls.ControlVisible(Handle);
            set
            {
                if (visible == value) return;
                if (value) Show();
                else Hide();
            }
        }

        /// <summary>
        /// Gets a value indicating whether or not this is the top-most control.
        /// </summary>
        public bool TopLevel
        {
            get
            {
                if (!Handle.IsInvalid)
                    return NativeCalls.ControlTopLevel(Handle);
                return false;
            }
        }

        /// <summary>
        /// Enables this control to accept user-interaction.
        /// </summary>
        public virtual void Enable()
        {
            if (!enabled)
            {
                NativeCalls.ControlEnable(Handle);
                enabled = true;
            }
        }

        /// <summary>
        /// Disables the control from accepting user-interaction.
        /// </summary>
        public virtual void Disable()
        {
            if (enabled)
            {
                NativeCalls.ControlDisable(Handle);
                enabled = false;
            }
        }

        /// <summary>
        /// Displays this control to the user.
        /// </summary>
        public virtual void Show()
        {
            if (!visible)
            {
                NativeCalls.ControlShow(Handle);
                visible = true;
            }
        }

        /// <summary>
        /// Conceals this control from the user.
        /// </summary>
        public virtual void Hide()
        {
            if (visible)
            {
                NativeCalls.ControlHide(Handle);
                visible = false;
            }
        }

        /// <summary>
        /// Performs pre-rendering operations.
        /// </summary>
        protected internal virtual void DelayRender() { }
    }
}