using System;

namespace LibUISharp
{
    public class DataEventArgs : EventArgs
    {
        public DataEventArgs(IntPtr data) => Data = data;
        public IntPtr Data { get; }
    }
}