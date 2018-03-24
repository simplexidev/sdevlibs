using System;
using System.Runtime.InteropServices;

namespace LibUISharp.Internal
{
    internal static partial class LibUI
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void uiQueueMainHandler(IntPtr data);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool uiOnShouldQuitHandler(IntPtr data);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void uiOnContentSizeChangedHandler(IntPtr window, IntPtr data);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool uiOnClosingHandler(IntPtr window, IntPtr data);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void uiOnClickedHandler(IntPtr button, IntPtr data);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void uiOnToggledHandler(IntPtr checkbox, IntPtr data);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void uiOnTextChangedHandler(IntPtr entry, IntPtr data);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void uiOnValueChangedHandler(IntPtr spinBox, IntPtr data);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void uiOnValueSelectedSelected(IntPtr comboBox, IntPtr data);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void uiMenuItemOnClickedHandler(IntPtr menuItem, IntPtr window, IntPtr data);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void uiDrawHandler(IntPtr handler, IntPtr area, [In, Out]ref uiAreaDrawParams param);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void uiMouseEventHandler(IntPtr handler, IntPtr area, [In, Out]ref uiAreaMouseEvent mouseEvent);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void uiMouseCrossedHandler(IntPtr handler, IntPtr area, bool left);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void uiDragBrokenHandler(IntPtr handler, IntPtr area);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool uiKeyEventHandler(IntPtr handler, IntPtr area, [In, Out]ref uiAreaKeyEvent keyEvent);
    }
}