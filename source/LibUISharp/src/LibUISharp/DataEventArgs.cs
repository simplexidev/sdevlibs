using System;

namespace LibUISharp
{
    /// <summary>
    /// Provides pointer data for an event.
    /// </summary>
    public class DataEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataEventArgs"/> class.
        /// </summary>
        /// <param name="data">The pointer event data.</param>
        public DataEventArgs(IntPtr data) => Data = data;

        /// <summary>
        /// The pointer event data.
        /// </summary>
        public IntPtr Data { get; }
    }
}