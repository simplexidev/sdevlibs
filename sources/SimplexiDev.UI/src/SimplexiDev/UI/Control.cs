/***********************************************************************************************************************
 * FileName:            Control.cs
 * Copyright/License:   https://github.com/simplexidev/sdfx/blob/main/LICENSE.md
***********************************************************************************************************************/

using System;

using SimplexiDev.Native;
using SimplexiDev.Runtime.InteropServices;

namespace SimplexiDev.UI
{
    /// <summary>
    /// Defines a base class for controls, which are <see cref="NativeComponent"/> objects with visual representation.
    /// </summary>
    public unsafe class Control : NativeComponent
    {
        private Control parent;
        private bool visible;
        private bool enabled = true;

        /// <summary>
        /// Initializes a new instance of the <see cref="Control"/> class.
        /// </summary>
        /// <inheritdoc/>
        protected Control(params object[] initArgs) : base(initArgs) { }

        /// <summary>
        /// Gets or sets the parent container of the control.
        /// </summary>
        public Control Parent
        {
            get => parent;
            internal set
            {
                ArgumentNullException.ThrowIfNull(value, nameof(value));
                if (parent == value) return;
                OnPropertyChanging(nameof(Parent));
                //TODO: Parameters might be backwards.
                Libui.uiControlVerifySetParent(Handle, value.Handle);
                Libui.uiControlSetParent(value.Handle);
                parent = value;
                OnPropertyChanged(nameof(Parent));
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the control can respond to interaction.
        /// </summary>
        public virtual bool Enabled
        {
            get => enabled;
            set
            {
                ArgumentNullException.ThrowIfNull(value, nameof(value));
                if (enabled == value) return;
                OnPropertyChanging(nameof(Enabled));
                if (value)
                    Libui.uiControlEnable(Handle);
                else
                    Libui.uiControlDisable(Handle);
                enabled = value;
                OnPropertyChanged(nameof(Enabled));
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the control and all its child controls are displayed.
        /// </summary>
        public virtual bool Visible
        {
            get => visible;
            set
            {
                ArgumentNullException.ThrowIfNull(value, nameof(value));
                if (visible == value) return;
                OnPropertyChanging(nameof(Visible));
                if (value)
                    Libui.uiControlShow(Handle);
                else
                    Libui.uiControlHide(Handle);
                visible = value;
                OnPropertyChanged(nameof(Visible));
            }
        }

        /// <summary>
        /// Determines whether this is a top-level <see cref="Control"/>.
        /// </summary>
        public bool TopLevel => Libui.uiControlToplevel(Handle);

        /// <summary>
        /// Gets or sets a value indicating whether the control can respond to user interaction.
        /// </summary>
        public bool EnabledToUser => Libui.uiControlEnabledToUser(Handle);

        public virtual void Show() => Visible = true;
        public virtual void Hide() => Visible = false;
        public virtual void Enable() => Enabled = true;
        public virtual void Disable() => Enabled = false;

        /// <inheritdoc/>
        protected override void StartInitialization(params object[] args)
        {
            base.StartInitialization(args);
            visible = this is not Window;
        }

        /// <inheritdoc/>
        protected override void DestroyHandle()
        {
            if (Handle != IntPtr.Zero)
                Libui.uiControlDestroy(Handle);
            base.DestroyHandle();
        }
    }
}