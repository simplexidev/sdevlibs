using System;
using System.Collections.Generic;
using LibUISharp.Internal;
using static LibUISharp.Internal.LibUI;

namespace LibUISharp
{
    // uiControl
    //TODO: uiControlVerifySetParent(IntPtr,IntPtr) => VerifyParent(Control)
    public abstract class Control : UIComponent, IControl
    {
        private bool visible, enabled;
        private bool disposed = false;
        private static readonly Dictionary<ControlSafeHandle, Control> ControlCache = new Dictionary<ControlSafeHandle, Control>();

        protected Control()
        {
            if (this is Window)
                visible = false;
            else
                visible = true;
            ControlCache.Add(Handle, this);
        }

        public event EventHandler LocationChanged, Resize;

        public virtual bool Enabled
        {
            get => uiControlEnabled(Handle);
            set
            {
                if (enabled == value) return;
                if (value)
                    uiControlEnable(Handle);
                else
                    uiControlDisable(Handle);
                enabled = value;
            }
        }

        public virtual bool Visible
        {
            get => uiControlVisible(Handle);
            set
            {
                if (visible == value) return;
                if (value)
                    uiControlShow(Handle);
                else
                    uiControlHide(Handle);
                visible = value;
            }
        }

        public bool TopLevel
        {
            get
            {
                if (!Handle.IsInvalid)
                    return uiControlTopLevel(Handle);
                return false;
            }
            //TODO: set { }
        }

        public bool EnabledToUser
        {
            get
            {
                if (!Handle.IsInvalid)
                    return uiControlEnabledToUser(Handle);
                throw new InvalidOperationException();
            }
        }
        
        public Control Parent { get; internal set; }
        public int Index { get; protected internal set; }
        internal ControlSafeHandle Handle { get; set; }

        public virtual void Enable() => Enabled = true;
        public virtual void Disable() => Enabled = false;
        public virtual void Show() => Visible = true;
        public virtual void Hide() => Visible = false;

        protected virtual void OnResize(EventArgs e) => Resize?.Invoke(this, e);
        protected virtual void OnLocationChanged(EventArgs e) => LocationChanged?.Invoke(this, e);
        
        protected internal virtual void DelayRender() { }

        protected virtual void Destroy()
        {
            if (!Handle.IsInvalid)
                Handle.Dispose();
            ControlCache.Remove(Handle);
        }
        
        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                    Destroy();
                disposed = true;
            }
        }
        
        public override void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}