using System;

using LibUISharp.ComponentModel;
using LibUISharp.Native;
using LibUISharp.Runtime.InteropServices;

namespace LibUISharp.UI
{
    public unsafe class Control : Component
    {
        private Control parent;
        private bool visible;
        private bool enabled;

        protected Control() : base()
        {
            enabled = true;
            visible = this is not Window;
        }

        public void* ControlHandle { get; protected set; }

        public Control Parent
        {
            get => parent;
            internal set
            {
                ArgumentNullException.ThrowIfNull(value, nameof(value));
                if (parent == value) return;
                OnPropertyChanging(nameof(Parent));
                //TODO: Parameters might be backwards.
                Libui.uiControlVerifySetParent(ControlHandle, value.ControlHandle);
                Libui.uiControlSetParent(value.ControlHandle);
                parent = value;
                OnPropertyChanged(nameof(Parent));
            }
        }
        public virtual bool Enabled
        {
            get => enabled;
            set
            {
                ArgumentNullException.ThrowIfNull(value, nameof(value));
                if (enabled == value) return;
                OnPropertyChanging(nameof(Enabled));
                if (value)
                    Libui.uiControlEnable(ControlHandle);
                else
                    Libui.uiControlDisable(ControlHandle);
                enabled = value;
                OnPropertyChanged(nameof(Enabled));
            }
        }
        public virtual bool Visible
        {
            get => visible;
            set
            {
                ArgumentNullException.ThrowIfNull(value, nameof(value));
                if (visible == value) return;
                OnPropertyChanging(nameof(Visible));
                if (value)
                    Libui.uiControlShow(ControlHandle);
                else
                    Libui.uiControlHide(ControlHandle);
                visible = value;
                OnPropertyChanged(nameof(Visible));
            }
        }
        public bool TopLevel => Libui.uiControlToplevel(ControlHandle);
        public bool EnabledToUser => Libui.uiControlEnabledToUser(ControlHandle);

        public virtual void Show() => Visible = true;
        public virtual void Hide() => Visible = false;
        public virtual void Enable() => Enabled = true;
        public virtual void Disable() => Enabled = false;

        protected override void ReleaseUnmanagedResources()
        {
            if (ControlHandle is not null)
                Libui.uiControlDestroy(ControlHandle);
            base.ReleaseUnmanagedResources();
        }
    }
}