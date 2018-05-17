using System;
using System.Runtime.InteropServices;

namespace LibUISharp.SafeHandles
{
    /// <summary>
    /// Provides a base class for Libui safe handle implementations in which the value of  0 indicates an invalid handle.
    /// </summary>
    public abstract class SafeHandleZeroIsInvalid : SafeHandle
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SafeHandleZeroIsInvalid"/> class.
        /// </summary>
        /// <param name="existingHandle">An <see cref="IntPtr"/> object that represents a pre-existing handle to use.</param>
        /// <param name="ownsHandle">
        /// <see langword="true"/> to reliably release the handle during the finalization
        /// phase; <see langword="false"/> to prevent reliable release (not recommended).
        /// </param>
        protected SafeHandleZeroIsInvalid(IntPtr existingHandle, bool ownsHandle = true) : base(IntPtr.Zero, ownsHandle) => handle = existingHandle;

        /// <inheritdoc/>
        public override bool IsInvalid => handle == IntPtr.Zero;
    }
}