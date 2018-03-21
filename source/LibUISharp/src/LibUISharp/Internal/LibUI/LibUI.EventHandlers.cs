using System;
using System.Runtime.InteropServices;

namespace LibUISharp.Internal
{
    internal static partial class LibUI
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void QueueMainEventHandler(IntPtr data);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool OnExitEventHandler(IntPtr data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void OnSizeChangedEventHandler(IntPtr window, IntPtr data);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool OnClosingEventHandler(IntPtr window, IntPtr data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void OnClickEventHandler(IntPtr button, IntPtr data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void OnCheckedChangedEventHandler(IntPtr checkbox, IntPtr data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void OnTextChangedEventHandler(IntPtr entry, IntPtr data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void OnValueChangedEventHandler(IntPtr spinBox, IntPtr data);
    }
}