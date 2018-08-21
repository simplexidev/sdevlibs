using System;
using System.Runtime.InteropServices;

namespace LibUISharp.SafeHandles
{
    /// <summary>
    /// Provides a base class for libui safe handle implementations in which the value of 0 indicates an invalid handle.
    /// </summary>
    public abstract class SafeHandleZeroIsInvalid : SafeHandle
    {
        /// <summary>
        /// Initializes a new instance of the SafeHandleZeroOrMinusOneIsInvalid class, specifying whether the handle is to be reliably released.
        /// </summary>
        /// <param name="ownsHandle"><see langword="true"/> to reliably release the handle during the finalization phase; <see langword="false"/> to prevent reliable release (not recommended).</param>
        protected SafeHandleZeroIsInvalid(bool ownsHandle) : base(IntPtr.Zero, ownsHandle) { }

        /// <summary>
        /// Gets a value that indicates whether the handle is invalid.
        /// </summary>
        public override bool IsInvalid => handle == IntPtr.Zero;
    }
}