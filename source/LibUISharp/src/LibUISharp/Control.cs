using System;
using LibUISharp.Internal;
using static LibUISharp.Internal.Libraries;

namespace LibUISharp
{
    /// <summary>
    /// Defines the base class for controls, which are <see cref="UIComponent"/> objects with visual representation.
    /// </summary>
    [LibuiType("uiControl")]
    public abstract class Control : UIComponent
    {
        private bool enabled, visible;
        private bool disposed = false;

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
            get => Libui.Call<Libui.uiControlEnabled>()(this);
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
            get => Libui.Call<Libui.uiControlVisible>()(this);
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
                if (Handle != IntPtr.Zero)
                    return Libui.Call<Libui.uiControlToplevel>()(Handle);
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
                Libui.Call<Libui.uiControlEnable>()(this);
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
                Libui.Call<Libui.uiControlDisable>()(this);
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
                Libui.Call<Libui.uiControlShow>()(this);
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
                Libui.Call<Libui.uiControlHide>()(this);
                visible = false;
            }
        }

        /// <summary>
        /// Performs pre-rendering operations.
        /// </summary>
        protected internal virtual void DelayRender() { }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <param name="disposing">Whether or not this control is disposing.</param>
        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing && Handle != IntPtr.Zero)
                    Libui.Call<Libui.uiControlDestroy>()(this);
                disposed = true;
                base.Dispose(disposing);
            }
        }
    }
}