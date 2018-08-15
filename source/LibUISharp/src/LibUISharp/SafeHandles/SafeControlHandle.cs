using System;
using LibUISharp.Internal;

namespace LibUISharp.SafeHandles
{
    /// <summary>
    /// Represents a wrapper class for a control handle.
    /// </summary>
    public sealed class SafeControlHandle : SafeHandleZeroIsInvalid
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SafeControlHandle"/> class.
        /// </summary>
        /// <param name="existingHandle"> An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
        /// <param name="ownsHandle"><see langword="true"/> to reliably release the handle during the finalization phase; <see langword="false"/> to prevent reliable release (not recommended).</param>
        public SafeControlHandle(IntPtr existingHandle, bool ownsHandle = true) : base(ownsHandle) => SetHandle(existingHandle);

        /// <summary>
        /// Returns the value of the platform-native control handle.
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
        /// <returns><see langword="true"/> if the handle is released successfully; otherwise, in the event of a catastrophic failure, <see langword="false"/>.</returns>
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

        //TODO: Documentation.
        public static implicit operator IntPtr(SafeControlHandle safeHandle) => safeHandle.handle;
    }
}