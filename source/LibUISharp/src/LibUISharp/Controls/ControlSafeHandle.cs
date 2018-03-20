using System;
using System.Runtime.InteropServices;
using LibUISharp.Internal;

namespace LibUISharp.Controls
{
    public sealed class ControlSafeHandle : LibUISafeHandle
    {
        public ControlSafeHandle() : this(IntPtr.Zero) { }
        public ControlSafeHandle(IntPtr ptr) : base(ptr) { }

        public UIntPtr DangerousGetControlHandle()
        {
            if (!IsInvalid)
                return LibUI.ControlHandle(this);
            else
                return UIntPtr.Zero;
        }

        protected override bool ReleaseHandle()
        {
            LibUI.ControlDestroy(this);
            handle = IntPtr.Zero;
            return Marshal.GetLastWin32Error() == 0;
        }
    }
}