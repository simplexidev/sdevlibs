using System;
using LibUISharp.Internal;

namespace LibUISharp.SafeHandles
{
    /// <summary>
    /// Provides a managed wrapper for a control handle.
    /// </summary>
    public sealed class SafeControlHandle : SafeHandleZeroIsInvalid
    {
        /// <summary>
        /// Initializes a new instance of the SafeHandleZeroOrMinusOneIsInvalid class, specifying whether the handle is to be reliably released.
        /// </summary>
        /// <param name="existingHandle">The handle to be wrapped.</param>
        /// <param name="ownsHandle"><see langword="true"/> to reliably let <see cref="SafeControlHandle"/> release the handle during the finalization phase; otherwise, <see langword="false"/>.</param>
        public SafeControlHandle(IntPtr existingHandle, bool ownsHandle = true) : base(ownsHandle) => SetHandle(existingHandle);

        /// <summary>
        /// Returns the value of the libui control handle.
        /// </summary>
        /// <returns>The value of the control handle if not invalid; otherwise, <see cref="UIntPtr.Zero"/>.</returns>
        [CLSCompliant(false)]
        public UIntPtr DangerousGetControlHandle()
        {
            if (!IsInvalid)
                return NativeCalls.ControlHandle(handle);
            else
                return UIntPtr.Zero;
        }

        /// <summary>
        /// When overridden in a derived class, executes the code required to free the handle.
        /// </summary>
        /// <returns><see langword="true"/> if the handle is released successfully; otherwise, in the event of a catastrophic failure, <see langword="false"/>. </returns>
        protected override bool ReleaseHandle()
        {
            bool released;
            try
            {
                NativeCalls.ControlDestroy(handle);
                handle = IntPtr.Zero;
                released = true;
            }
            catch
            {
                released = false;
            }
            return released;
        }
    }
}
