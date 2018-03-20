using System;
using System.Runtime.InteropServices;

namespace LibUISharp
{
    public abstract class LibUISafeHandle : SafeHandle
    {
        protected LibUISafeHandle() : this(IntPtr.Zero) { }
        protected LibUISafeHandle(IntPtr ptr) : base(ptr, true) { }

        public override bool IsInvalid => handle == IntPtr.Zero;
    }
}