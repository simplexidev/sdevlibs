using System;
using System.Runtime.InteropServices;

namespace LibUISharp.Native
{
    internal static partial class NativeMethods
    {
        internal static partial class Libui
        {
            // _UI_EXTERN void uiDateTimePickerTime(uiDateTimePicker *d, struct tm *time);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiDateTimePickerTime_t(IntPtr d, out UIDateTime time);
            public static void uiDateTimePickerTime(IntPtr d, out UIDateTime time) => FunctionLoader.LoadLibuiFunc<uiDateTimePickerTime_t>("uiDateTimePickerTime")(d, out time);

            // _UI_EXTERN void uiDateTimePickerSetTime(uiDateTimePicker *d, const struct tm *time);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiDateTimePickerSetTime_t(IntPtr d, UIDateTime time);
            public static void uiDateTimePickerSetTime(IntPtr d, UIDateTime time) => FunctionLoader.LoadLibuiFunc<uiDateTimePickerSetTime_t>("uiDateTimePickerSetTime")(d, time);

            // _UI_EXTERN void uiDateTimePickerOnChanged(uiDateTimePicker *d, void (*f)(uiDateTimePicker *, void *), void *data);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiDateTimePickerOnChanged_t(IntPtr d, uiDateTimePickerOnChanged_tf f, IntPtr data);
            [UnmanagedFunctionPointer(Convention)]
            public delegate void uiDateTimePickerOnChanged_tf(IntPtr d, IntPtr data);
            public static void uiDateTimePickerOnChanged(IntPtr d, uiDateTimePickerOnChanged_tf f, IntPtr data) => FunctionLoader.LoadLibuiFunc<uiDateTimePickerOnChanged_t>("uiDateTimePickerOnChanged")(d, f, data);

            // _UI_EXTERN uiDateTimePicker *uiNewDateTimePicker(void);
            [UnmanagedFunctionPointer(Convention)]
            private delegate IntPtr uiNewDateTimePicker_t();
            public static IntPtr uiNewDateTimePicker() => FunctionLoader.LoadLibuiFunc<uiNewDateTimePicker_t>("uiNewDateTimePicker")();

            // _UI_EXTERN uiDateTimePicker *uiNewDatePicker(void);
            [UnmanagedFunctionPointer(Convention)]
            private delegate IntPtr uiNewDatePicker_t();
            public static IntPtr uiNewDatePicker() => FunctionLoader.LoadLibuiFunc<uiNewDatePicker_t>("uiNewDatePicker")();

            // _UI_EXTERN uiDateTimePicker *uiNewTimePicker(void);
            [UnmanagedFunctionPointer(Convention)]
            private delegate IntPtr uiNewTimePicker_t();
            public static IntPtr uiNewTimePicker() => FunctionLoader.LoadLibuiFunc<uiNewTimePicker_t>("uiNewTimePicker")();
        }
    }
}