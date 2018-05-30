using LibUISharp.Internal;
using LibUISharp.SafeHandles;
using System;

namespace LibUISharp
{
    //TODO: uiControlVerifySetParent(IntPtr,IntPtr).
    //TODO: uiControlEnabledToUser(IntPtr).
    //TODO: Re-add control caching.
    /// <summary>
    /// Defines the base class for controls, which are <see cref="UIComponent"/> objects with visual representation.
    /// </summary>
    public abstract class Control : UIComponent<SafeControlHandle>, IUIComponent
    {
        private bool visible, enabled;
        private bool disposed = false;

        /// <summary>
        /// Initializes a new <see cref="Control"/> class.
        /// </summary>
        protected Control()
        {
            if (this is Window)
                visible = false;
            else
                visible = true;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the control can respond to interaction.
        /// </summary>
        public virtual bool Enabled
        {
            get => LibuiLibrary.uiControlEnabled(Handle.DangerousGetHandle());
            set
            {
                if (enabled == value) return;
                if (value)
                    LibuiLibrary.uiControlEnable(Handle.DangerousGetHandle());
                else
                    LibuiLibrary.uiControlDisable(Handle.DangerousGetHandle());
                enabled = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the control and all its child controls are displayed.
        /// </summary>
        public virtual bool Visible
        {
            get => LibuiLibrary.uiControlVisible(Handle.DangerousGetHandle());
            set
            {
                if (visible == value) return;
                if (value)
                    LibuiLibrary.uiControlShow(Handle.DangerousGetHandle());
                else
                    LibuiLibrary.uiControlHide(Handle.DangerousGetHandle());
                visible = value;
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
                    return LibuiLibrary.uiControlToplevel(Handle.DangerousGetHandle());
                return false;
            }
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
        /// Enables this control to accept user-interaction.
        /// </summary>
        public virtual void Enable() => Enabled = true;

        /// <summary>
        /// Disables the control from accepting user-interaction.
        /// </summary>
        public virtual void Disable() => Enabled = false;

        /// <summary>
        /// Displays the control to the user.
        /// </summary>
        public virtual void Show() => Visible = true;

        /// <summary>
        /// Conceals the control from the user.
        /// </summary>
        public virtual void Hide() => Visible = false;

        /// <summary>
        /// Performs pre-rendering operations.
        /// </summary>
        protected internal virtual void DelayRender() { }

        /// <summary>
        /// Runs cleanup operations and destroys the control.
        /// </summary>
        protected virtual void Destroy()
        {
            if (!Handle.IsInvalid)
                Handle.Dispose();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <param name="disposing">Whether or not this control is disposing.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                    Destroy();
                disposed = true;
            }
        }
    }
}