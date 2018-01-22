using System;
using System.Runtime.InteropServices;

namespace LibUISharp.Internal
{
    internal static partial class UI
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void uiQueueMainDelegate(IntPtr data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool uiOnShouldQuitDelegate(IntPtr data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void uiWindowOnContentSizeChangedDelegate(IntPtr window, IntPtr data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool uiWindowOnClosingDelegate(IntPtr window, IntPtr data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void uiButtonOnClickedDelegate(IntPtr button, IntPtr data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void uiCheckboxOnToggledDelegate(IntPtr checkbox, IntPtr data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void uiEntryOnChangedDelegate(IntPtr entry, IntPtr data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void uiSpinBoxOnChangedDelegate(IntPtr spinBox, IntPtr data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void uiSliderOnChangedDelegate(IntPtr slider, IntPtr data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void uiComboboxOnSelectedDelegate(IntPtr comboBox, IntPtr data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void uiEditableComboboxOnChangedDelegate(IntPtr comboBox, IntPtr data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void uiRadioButtonsOnSelectedDelegate(IntPtr radioButton, IntPtr data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void uiColorButtonOnChangedDelegate(IntPtr button, IntPtr data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void uiMultilineEntryOnChangedDelegate(IntPtr entry, IntPtr data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void uiMenuItemOnClickedDelegate(IntPtr menuItem, IntPtr window, IntPtr data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void uiAreaHandlerDrawDelegate(IntPtr handler, IntPtr area, [In, Out]ref uiAreaDrawParams param);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void uiAreaHandlerMouseEventDelegate(IntPtr handler, IntPtr area, [In, Out]ref uiAreaMouseEvent mouseEvent);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void uiAreaHandlerMouseCrossedDelegate(IntPtr handler, IntPtr area, bool left);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void uiAreaHandlerDragBrokenDelegate(IntPtr handler, IntPtr area);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool uiAreaHandlerKeyEventDelegate(IntPtr handler, IntPtr area, [In, Out]ref uiAreaKeyEvent keyEvent);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool uiOpenTypeFeaturesForEachDelegate(IntPtr fontFeatures, byte a, byte b, byte c, byte d, uint value, IntPtr data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool uiAttributedStringForEachAttributeDelegate(IntPtr attrStr, IntPtr attrSpec, UIntPtr start, UIntPtr end, IntPtr data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void uiFontButtonOnChangedDelegate(IntPtr button, IntPtr data);
    }
}