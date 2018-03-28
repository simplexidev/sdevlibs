using System;
using System.Runtime.InteropServices;

using static LibUISharp.Internal.LibUI;

namespace LibUISharp.Internal
{
    internal abstract class LibUISafeHandle : SafeHandle
    {
        protected LibUISafeHandle() : this(IntPtr.Zero) { }
        protected LibUISafeHandle(IntPtr ptr) : base(ptr, true) { }

        public override bool IsInvalid => handle == IntPtr.Zero;
    }

    internal sealed class ControlSafeHandle : LibUISafeHandle
    {
        public ControlSafeHandle() : this(IntPtr.Zero) { }
        public ControlSafeHandle(IntPtr ptr) : base(ptr) { }

        public UIntPtr DangerousGetControlHandle()
        {
            if (!IsInvalid)
                return uiControlHandle(handle);
            else
                return UIntPtr.Zero;
        }

        protected override bool ReleaseHandle()
        {
            uiControlDestroy(handle);
            handle = IntPtr.Zero;
            return Marshal.GetLastWin32Error() == 0;
        }
    }

    internal sealed class PathSafeHandle : LibUISafeHandle
    {
        public PathSafeHandle() : this(IntPtr.Zero) { }
        public PathSafeHandle(IntPtr ptr) : base(ptr) { }

        protected override bool ReleaseHandle()
        {
            uiDrawFreePath(handle);
            handle = IntPtr.Zero;
            // return Marshal.GetLastWin32Error() == 0;
            return true;
        }
    }
}