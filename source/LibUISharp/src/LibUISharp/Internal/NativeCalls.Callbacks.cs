using System;
using System.Runtime.InteropServices;
using LibUISharp.Drawing;

namespace LibUISharp.Internal
{
    internal static partial class NativeCalls
    {
        [UnmanagedFunctionPointer(Cdecl)] internal delegate void QueueMainCallback(IntPtr data);
        [UnmanagedFunctionPointer(Cdecl)] internal delegate bool TimerCallback(IntPtr data);
        [UnmanagedFunctionPointer(Cdecl)] internal delegate bool OnShouldQuitCallback(IntPtr data);
        [UnmanagedFunctionPointer(Cdecl)] internal delegate void WindowOnContentSizeChangedCallback(IntPtr w, IntPtr data);
        [UnmanagedFunctionPointer(Cdecl)] internal delegate bool WindowOnClosingCallback(IntPtr w, IntPtr data);
        [UnmanagedFunctionPointer(Cdecl)] internal delegate void ButtonOnClickedCallback(IntPtr b, IntPtr data);
        [UnmanagedFunctionPointer(Cdecl)] internal delegate void CheckboxOnToggledCallback(IntPtr w, IntPtr data);
        [UnmanagedFunctionPointer(Cdecl)] internal delegate void EntryOnChangedCallback(IntPtr w, IntPtr data);
        [UnmanagedFunctionPointer(Cdecl)] internal delegate void SpinboxOnChangedCallback(IntPtr w, IntPtr data);
        [UnmanagedFunctionPointer(Cdecl)] internal delegate void SliderOnChangedCallback(IntPtr w, IntPtr data);
        [UnmanagedFunctionPointer(Cdecl)] internal delegate void ComboboxOnSelectedCallback(IntPtr w, IntPtr data);
        [UnmanagedFunctionPointer(Cdecl)] internal delegate void EditableComboboxOnChangedCallback(IntPtr w, IntPtr data);
        [UnmanagedFunctionPointer(Cdecl)] internal delegate void RadioButtonsOnSelectedCallback(IntPtr w, IntPtr data);
        [UnmanagedFunctionPointer(Cdecl)] internal delegate void DateTimePickerOnChangedCallback(IntPtr w, IntPtr data);
        [UnmanagedFunctionPointer(Cdecl)] internal delegate void MultilineEntryOnChangedCallback(IntPtr w, IntPtr data);
        [UnmanagedFunctionPointer(Cdecl)] internal delegate void MenuItemOnClickedCallback(IntPtr sender, IntPtr window, IntPtr data);
        [UnmanagedFunctionPointer(Cdecl)] internal delegate void AreaHandlerDrawCallback(NativeSurfaceHandler handler, IntPtr area, DrawEventArgs args);
        [UnmanagedFunctionPointer(Cdecl)] internal delegate void AreaHandlerMouseEventCallback(NativeSurfaceHandler handler, IntPtr area, MouseEventArgs args);
        [UnmanagedFunctionPointer(Cdecl)] internal delegate void AreaHandlerMouseCrossedCallback(NativeSurfaceHandler handler, IntPtr area, bool left);
        [UnmanagedFunctionPointer(Cdecl)] internal delegate void AreaHandlerDragBrokenCallback(NativeSurfaceHandler handler, IntPtr area);
        [UnmanagedFunctionPointer(Cdecl)] internal delegate void AreaHandlerKeyEventCallback(NativeSurfaceHandler handler, IntPtr area, KeyEventArgs args);
        [UnmanagedFunctionPointer(Cdecl)] internal delegate void FontButtonOnChangedCallback(IntPtr w, IntPtr data);
        [UnmanagedFunctionPointer(Cdecl)] internal delegate void ColorButtonOnChangedCallback(IntPtr w, IntPtr data);
    }
}