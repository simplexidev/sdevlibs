using NativeLibraryLoader;
using System;
using System.Runtime.InteropServices;

namespace LibUISharp.Native.Libraries
{
    // C Header: ui.h
    internal static class LibuiLibrary
    {
        private const CallingConvention callingConvention = CallingConvention.Cdecl;
        private const LayoutKind layoutKind = LayoutKind.Sequential;

        private static class FunctionLoader
        {
            private static readonly string[] WinNTLibNames = new[] { "libui.dll" };
            private static readonly string[] LinuxLibNames = new[] { "libui.so", "libui.so.0" };
            private static readonly string[] MacOSLibNames = new[] { "libui.dylib", "libui.A.dylib" };

            private static NativeLibrary LibuiNativeLibrary
            {
                get
                {
                    if (PlatformHelper.IsWinNT) return new NativeLibrary(WinNTLibNames);
                    else if (PlatformHelper.IsLinux) return new NativeLibrary(LinuxLibNames);
                    else if (PlatformHelper.IsMacOS) return new NativeLibrary(MacOSLibNames);
                    else throw new PlatformNotSupportedException();
                }
            }

            public static T Load<T>(string name) => LibuiNativeLibrary.LoadFunction<T>(name);
        }

        public enum uiForEach : uint
        {
            uiForEachContinue,
            uiForEachStop
        }

        [StructLayout(layoutKind)]
        public struct uiInitOptions
        {
            public UIntPtr Size;
        }

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate IntPtr uiInit_t(ref uiInitOptions options);
        public static IntPtr uiInit(ref uiInitOptions options) => FunctionLoader.Load<uiInit_t>("uiInit")(ref options);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiUnInit_t();
        public static void uiUnInit() => FunctionLoader.Load<uiUnInit_t>("uiUnInit")();

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiFreeInitError_t(IntPtr err);
        public static void uiFreeInitError(IntPtr err) => FunctionLoader.Load<uiFreeInitError_t>("uiFreeInitError")(err);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiMain_t();
        public static void uiMain() => FunctionLoader.Load<uiMain_t>("uiMain")();

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiMainSteps_t();
        public static void uiMainSteps() => FunctionLoader.Load<uiMainSteps_t>("uiMainSteps")();

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate bool uiMainStep_t(bool wait);
        public static bool uiMainStep(bool wait) => FunctionLoader.Load<uiMainStep_t>("uiMainStep")(wait);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiQuit_t();
        public static void uiQuit() => FunctionLoader.Load<uiQuit_t>("uiQuit")();

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiQueueMain_t(uiQueueMain_tf f, IntPtr data);
        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiQueueMain_tf(IntPtr data);
        public static void uiQueueMain(uiQueueMain_tf f, IntPtr data) => FunctionLoader.Load<uiQueueMain_t>("uiQueueMain")(f, data);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiOnShouldQuit_t(uiOnShouldQuit_tf f, IntPtr data);
        [UnmanagedFunctionPointer(callingConvention)]
        public delegate bool uiOnShouldQuit_tf(IntPtr data);
        public static void uiOnShouldQuit(uiOnShouldQuit_tf f, IntPtr data) => FunctionLoader.Load<uiOnShouldQuit_t>("uiOnShouldQuit")(f, data);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiFreeText_t(IntPtr text);
        public static void uiFreeText(IntPtr text) => FunctionLoader.Load<uiFreeText_t>("uiFreeText")(text);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiControlDestroy_t(IntPtr c);
        public static void uiControlDestroy(IntPtr c) => FunctionLoader.Load<uiControlDestroy_t>("uiControlDestroy")(c);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate UIntPtr uiControlHandle_t(IntPtr c);
        public static UIntPtr uiControlHandle(IntPtr c) => FunctionLoader.Load<uiControlHandle_t>("uiControlHandle")(c);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate IntPtr uiControlParent_t(IntPtr c);
        public static IntPtr uiControlParent(IntPtr c) => FunctionLoader.Load<uiControlParent_t>("uiControlParent")(c);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiControlSetParent_t(IntPtr c, IntPtr parent);
        public static void uiControlSetParent(IntPtr c, IntPtr parent) => FunctionLoader.Load<uiControlSetParent_t>("uiControlSetParent")(c, parent);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate bool uiControlTopLevel_t(IntPtr c);
        public static bool uiControlTopLevel(IntPtr c) => FunctionLoader.Load<uiControlTopLevel_t>("uiControlTopLevel")(c);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate bool uiControlVisible_t(IntPtr c);
        public static bool uiControlVisible(IntPtr c) => FunctionLoader.Load<uiControlVisible_t>("uiControlVisible")(c);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiControlShow_t(IntPtr c);
        public static void uiControlShow(IntPtr c) => FunctionLoader.Load<uiControlShow_t>("uiControlShow")(c);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiControlHide_t(IntPtr c);
        public static void uiControlHide(IntPtr c) => FunctionLoader.Load<uiControlHide_t>("uiControlHide")(c);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate bool uiControlEnabled_t(IntPtr c);
        public static bool uiControlEnabled(IntPtr c) => FunctionLoader.Load<uiControlEnabled_t>("uiControlEnabled")(c);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate bool uiControlEnable_t(IntPtr c);
        public static void uiControlEnable(IntPtr c) => FunctionLoader.Load<uiControlEnable_t>("uiControlEnable")(c);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate bool uiControlDisable_t(IntPtr c);
        public static void uiControlDisable(IntPtr c) => FunctionLoader.Load<uiControlDisable_t>("uiControlDisable")(c);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate bool uiControlVerifySetParent_t(IntPtr c, IntPtr parent);
        public static void uiControlVerifySetParent(IntPtr c, IntPtr parent) => FunctionLoader.Load<uiControlVerifySetParent_t>("uiControlVerifySetParent")(c, parent);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate bool uiControlEnabledToUser_t(IntPtr c);
        public static bool uiControlEnabledToUser(IntPtr c) => FunctionLoader.Load<uiControlEnabledToUser_t>("uiControlEnabledToUser")(c);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate IntPtr uiWindowTitle_t(IntPtr w);
        public static IntPtr uiWindowTitle(IntPtr w) => FunctionLoader.Load<uiWindowTitle_t>("uiWindowTitle")(w);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiWindowSetTitle_t(IntPtr w, IntPtr title);
        public static void uiWindowSetTitle(IntPtr w, IntPtr title) => FunctionLoader.Load<uiWindowSetTitle_t>("uiWindowSetTitle")(w, title);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiWindowContentSize_t(IntPtr w, out int width, out int height);
        public static void uiWindowContentSize(IntPtr w, out int width, out int height) => FunctionLoader.Load<uiWindowContentSize_t>("uiWindowContentSize")(w, out width, out height);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiWindowSetContentSize_t(IntPtr w, int width, int height);
        public static void uiWindowSetContentSize(IntPtr w, int width, int height) => FunctionLoader.Load<uiWindowSetContentSize_t>("uiWindowSetContentSize")(w, width, height);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate bool uiWindowFullscreen_t(IntPtr w);
        public static bool uiWindowFullscreen(IntPtr w) => FunctionLoader.Load<uiWindowFullscreen_t>("uiWindowFullscreen")(w);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiWindowSetFullscreen_t(IntPtr w, bool fullscreen);
        public static void uiWindowSetFullscreen(IntPtr w, bool fullscreen) => FunctionLoader.Load<uiWindowSetFullscreen_t>("uiWindowSetFullscreen")(w, fullscreen);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiWindowOnContentSizeChanged_t(IntPtr w, uiWindowOnContentSizeChanged_tf f, IntPtr data);
        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiWindowOnContentSizeChanged_tf(IntPtr w, IntPtr data);
        public static void uiWindowOnContentSizeChanged(IntPtr w, uiWindowOnContentSizeChanged_tf f, IntPtr data) => FunctionLoader.Load<uiWindowOnContentSizeChanged_t>("uiWindowOnContentSizeChanged")(w, f, data);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiWindowOnClosing_t(IntPtr w, uiWindowOnClosing_tf f, IntPtr data);
        [UnmanagedFunctionPointer(callingConvention)]
        public delegate bool uiWindowOnClosing_tf(IntPtr w, IntPtr data);
        public static void uiWindowOnClosing(IntPtr w, uiWindowOnClosing_tf f, IntPtr data) => FunctionLoader.Load<uiWindowOnClosing_t>("uiWindowOnClosing")(w, f, data);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate bool uiWindowBorderless_t(IntPtr w);
        public static bool uiWindowBorderless(IntPtr w) => FunctionLoader.Load<uiWindowBorderless_t>("uiWindowBorderless")(w);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiWindowSetBorderless_t(IntPtr w, bool borderless);
        public static void uiWindowSetBorderless(IntPtr w, bool borderless) => FunctionLoader.Load<uiWindowSetBorderless_t>("uiWindowSetBorderless")(w, borderless);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiWindowSetChild_t(IntPtr w, IntPtr child);
        public static void uiWindowSetChild(IntPtr w, IntPtr child) => FunctionLoader.Load<uiWindowSetChild_t>("uiWindowSetChild")(w, child);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate bool uiWindowMargined_t(IntPtr w);
        public static bool uiWindowMargined(IntPtr w) => FunctionLoader.Load<uiWindowMargined_t>("uiWindowMargined")(w);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiWindowSetMargined_t(IntPtr w, bool margined);
        public static void uiWindowSetMargined(IntPtr w, bool margined) => FunctionLoader.Load<uiWindowSetMargined_t>("uiWindowSetMargined")(w, margined);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate IntPtr uiNewWindow_t(IntPtr title, int width, int height, bool hasMenubar);
        public static IntPtr uiNewWindow(IntPtr title, int width, int height, bool hasMenubar) => FunctionLoader.Load<uiNewWindow_t>("uiNewWindow")(title, width, height, hasMenubar);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate IntPtr uiButtonText_t(IntPtr b);
        public static IntPtr uiButtonText(IntPtr b) => FunctionLoader.Load<uiButtonText_t>("uiButtonText")(b);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiButtonSetText_t(IntPtr b, IntPtr title);
        public static void uiButtonSetText(IntPtr b, IntPtr title) => FunctionLoader.Load<uiButtonSetText_t>("uiButtonSetText")(b, title);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiButtonOnClicked_t(IntPtr b, uiButtonOnClicked_tf f, IntPtr data);
        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiButtonOnClicked_tf(IntPtr b, IntPtr data);
        public static void uiButtonOnClicked(IntPtr b, uiButtonOnClicked_tf f, IntPtr data) => FunctionLoader.Load<uiButtonOnClicked_t>("uiButtonOnClicked")(b, f, data);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate IntPtr uiNewButton_t(IntPtr text);
        public static IntPtr uiNewButton(IntPtr text) => FunctionLoader.Load<uiNewButton_t>("uiNewButton")(text);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiBoxAppend_t(IntPtr b, IntPtr child, bool stretchy);
        public static void uiBoxAppend(IntPtr b, IntPtr child, bool stretchy) => FunctionLoader.Load<uiBoxAppend_t>("uiBoxAppend")(b, child, stretchy);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiBoxDelete_t(IntPtr b, int index);
        public static void uiBoxDelete(IntPtr b, int index) => FunctionLoader.Load<uiBoxDelete_t>("uiBoxDelete")(b, index);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate bool uiBoxPadded_t(IntPtr b);
        public static bool uiBoxPadded(IntPtr b) => FunctionLoader.Load<uiBoxPadded_t>("uiBoxPadded")(b);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiBoxSetPadded_t(IntPtr b, bool padded);
        public static void uiBoxSetPadded(IntPtr b, bool padded) => FunctionLoader.Load<uiBoxSetPadded_t>("uiButtonSetPadded")(b, padded);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate IntPtr uiNewHorizontalBox_t();
        public static IntPtr uiNewHorizontalBox() => FunctionLoader.Load<uiNewHorizontalBox_t>("uiNewHorizontalBox")();

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate IntPtr uiNewVerticalBox_t();
        public static IntPtr uiNewVerticalBox() => FunctionLoader.Load<uiNewVerticalBox_t>("uiNewVerticalBox")();

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate IntPtr uiCheckboxText_t(IntPtr c);
        public static IntPtr uiCheckboxText(IntPtr c) => FunctionLoader.Load<uiCheckboxText_t>("uiCheckboxText")(c);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiCheckboxSetText_t(IntPtr c, IntPtr text);
        public static void uiCheckboxSetText(IntPtr c, IntPtr text) => FunctionLoader.Load<uiCheckboxSetText_t>("uiCheckboxSetText")(c, text);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiCheckboxOnToggled_t(IntPtr c, uiCheckboxOnToggled_tf f, IntPtr data);
        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiCheckboxOnToggled_tf(IntPtr c, IntPtr data);
        public static void uiCheckboxOnToggled(IntPtr c, uiCheckboxOnToggled_tf f, IntPtr data) => FunctionLoader.Load<uiCheckboxOnToggled_t>("uiCheckboxOnToggled")(c, f, data);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate bool uiCheckboxChecked_t(IntPtr c);
        public static bool uiCheckboxChecked(IntPtr c) => FunctionLoader.Load<uiCheckboxChecked_t>("uiCheckboxChecked")(c);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiCheckboxSetChecked_t(IntPtr c, bool @checked);
        public static void uiCheckboxSetChecked(IntPtr c, bool @checked) => FunctionLoader.Load<uiCheckboxSetChecked_t>("uiCheckboxSetChecked")(c, @checked);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate IntPtr uiNewCheckbox_t(IntPtr text);
        public static IntPtr uiNewCheckbox(IntPtr text) => FunctionLoader.Load<uiNewCheckbox_t>("uiNewCheckbox")(text);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate IntPtr uiEntryText_t(IntPtr e);
        public static IntPtr uiEntryText(IntPtr e) => FunctionLoader.Load<uiEntryText_t>("uiEntryText")(e);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiEntrySetText_t(IntPtr e, IntPtr text);
        public static void uiEntrySetText(IntPtr e, IntPtr text) => FunctionLoader.Load<uiEntrySetText_t>("uiEntrySetText")(e, text);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiEntryOnChanged_t(IntPtr e, uiEntryOnChanged_tf f, IntPtr data);
        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiEntryOnChanged_tf(IntPtr e, IntPtr data);
        public static void uiEntryOnChanged(IntPtr e, uiEntryOnChanged_tf f, IntPtr data) => FunctionLoader.Load<uiEntryOnChanged_t>("uiEntryOnChanged")(e, f, data);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate bool uiEntryReadOnly_t(IntPtr e);
        public static bool uiEntryReadOnly(IntPtr e) => FunctionLoader.Load<uiEntryReadOnly_t>("uiEntryReadOnly")(e);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiEntrySetReadOnly_t(IntPtr e, bool @readonly);
        public static void uiEntrySetReadOnly(IntPtr e, bool @readonly) => FunctionLoader.Load<uiEntrySetReadOnly_t>("uiEntrySetReadOnly")(e, @readonly);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate IntPtr uiNewEntry_t();
        public static IntPtr uiNewEntry() => FunctionLoader.Load<uiNewEntry_t>("uiNewEntry")();

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate IntPtr uiNewPasswordEntry_t();
        public static IntPtr uiNewPasswordEntry() => FunctionLoader.Load<uiNewPasswordEntry_t>("uiNewPasswordEntry")();

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate IntPtr uiNewSearchEntry_t();
        public static IntPtr uiNewSearchEntry() => FunctionLoader.Load<uiNewSearchEntry_t>("uiNewSearchEntry")();

        //TODO: Finish writing static functions below this line.
        // /////////////////////////////////////////////////////////////////

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate IntPtr uiLabelText_t(IntPtr l);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiLabelSetText_t(IntPtr l, IntPtr text);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate IntPtr uiNewLabel_t(IntPtr text);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiTabAppend_t(IntPtr t, IntPtr name, IntPtr c);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiTabInsertAt_t(IntPtr t, IntPtr name, int before, IntPtr c);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiTabDelete_t(IntPtr t, int index);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate int uiTabNumPages_t(IntPtr t);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate bool uiTabMargined_t(IntPtr t, int page);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiTabSetMargined_t(IntPtr t, int page, bool margined);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate IntPtr uiNewTab_t();

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate IntPtr uiGroupTitle_t(IntPtr g);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiGroupSetTitle_t(IntPtr g, IntPtr title);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiGroupSetChild_t(IntPtr g, IntPtr child);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate bool uiGroupMargined_t(IntPtr g);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiGroupSetMargined_t(IntPtr g, bool margined);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate IntPtr uiNewGroup_t(IntPtr title);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate int uiSpinboxValue_t(IntPtr s);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiSpinboxSetValue_t(IntPtr s, int value);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiSpinboxOnChanged_t(IntPtr s, uiSpinboxOnChanged_tf f, IntPtr data);
        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiSpinboxOnChanged_tf(IntPtr s, IntPtr data);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate IntPtr uiNewSpinbox_t(int min, int max);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate int uiSliderValue_t(IntPtr s);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiSliderSetValue_t(IntPtr s, int value);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiSliderOnChanged_t(IntPtr s, uiSliderOnChanged_tf f, IntPtr data);
        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiSliderOnChanged_tf(IntPtr s, IntPtr data);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate IntPtr uiNewSlider_t(int min, int max);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate int uiProgressBarValue_t(IntPtr p);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiProgressBarSetValue_t(IntPtr p, int n);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate IntPtr uiNewProgressBar_t();

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate IntPtr uiNewHorizontalSeparator_t();

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate IntPtr uiNewVerticalSeparator_t();

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiComboboxAppend_t(IntPtr c, IntPtr text);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate int uiComboboxSelected_t(IntPtr c);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiComboboxSetSelected_t(IntPtr c, int n);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiComboboxOnSelected_t(IntPtr c, uiComboboxOnSelected_tf f, IntPtr data);
        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiComboboxOnSelected_tf(IntPtr c, IntPtr data);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate IntPtr uiNewCombobox_t();

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiEditableComboboxAppend_t(IntPtr c, IntPtr text);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate IntPtr uiEditableComboboxText_t(IntPtr comboBox);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiEditableComboboxSetText_t(IntPtr c, IntPtr text);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiEditableComboboxOnChanged_t(IntPtr c, uiEditableComboboxOnChanged_tf f, IntPtr data);
        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiEditableComboboxOnChanged_tf(IntPtr c, IntPtr data);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate IntPtr uiNewEditableCombobox_t();

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiRadioButtonsAppend_t(IntPtr r, IntPtr text);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate int uiRadioButtonsSelected_t(IntPtr r);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiRadioButtonsSetSelected_t(IntPtr r, int n);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiRadioButtonsOnSelected_t(IntPtr r, uiRadioButtonsOnSelected_tf f, IntPtr data);
        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiRadioButtonsOnSelected_tf(IntPtr r, IntPtr data);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate IntPtr uiNewRadioButtons_t();

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate IntPtr uiNewDateTimePicker_t();

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate IntPtr uiNewDatePicker_t();

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate IntPtr uiNewTimePicker_t();

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate IntPtr uiMultilineEntryText_t(IntPtr e);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiMultilineEntrySetText_t(IntPtr e, IntPtr text);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiMultilineEntryAppend_t(IntPtr e, IntPtr text);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiMultilineEntryOnChanged_t(IntPtr e, uiMultilineEntryOnChanged_tf f, IntPtr data);
        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiMultilineEntryOnChanged_tf(IntPtr e, IntPtr data);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate bool uiMultilineEntryReadOnly_t(IntPtr e);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiMultilineEntrySetReadOnly_t(IntPtr e, bool @readonly);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate IntPtr uiNewMultilineEntry_t();

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate IntPtr uiNewNonWrappingMultilineEntry_t();

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiMenuItemEnable_t(IntPtr m);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiMenuItemDisable_t(IntPtr m);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiMenuItemOnClicked_t(IntPtr m, uiMenuItemOnClicked_tf f, IntPtr data);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void uiMenuItemOnClicked_tf(IntPtr menuItem, IntPtr window, IntPtr data);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate bool uiMenuItemChecked_t(IntPtr m);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiMenuItemSetChecked_t(IntPtr m, bool @checked);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate IntPtr uiMenuAppendItem_t(IntPtr m, IntPtr name);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate IntPtr uiMenuAppendCheckItem_t(IntPtr m, IntPtr name);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate IntPtr uiMenuAppendQuitItem_t(IntPtr m);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate IntPtr uiMenuAppendPreferencesItem_t(IntPtr m);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate IntPtr uiMenuAppendAboutItem_t(IntPtr m);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiMenuAppendSeparator_t(IntPtr m);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate IntPtr uiNewMenu_t(IntPtr name);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate IntPtr uiOpenFile_t(IntPtr parent);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate IntPtr uiSaveFile_t(IntPtr parent);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiMsgBox_t(IntPtr parent, IntPtr title, IntPtr description);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiMsgBoxError_t(IntPtr parent, IntPtr title, IntPtr description);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiAreaDrawHandler(IntPtr handler, IntPtr area, [In, Out]ref uiAreaDrawParams param);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiAreaMouseEventHandler(IntPtr handler, IntPtr area, [In, Out]ref uiAreaMouseEvent mouseEvent);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiAreaMouseCrossedHandler(IntPtr handler, IntPtr area, bool left);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiAreaDragBrokenHandler(IntPtr handler, IntPtr area);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate bool uiAreaKeyEventHandler(IntPtr handler, IntPtr area, [In, Out]ref uiAreaKeyEvent keyEvent);

        [StructLayout(LayoutKind.Sequential)]
        internal class uiAreaHandler
        {
            public IntPtr Draw;
            public IntPtr MouseEvent;
            public IntPtr MouseCrossed;
            public IntPtr DragBroken;
            public IntPtr KeyEvent;
        }

        public enum uiWindowResizeEdge : uint
        {
            uiWindowResizeEdgeLeft,
            uiWindowResizeEdgeTop,
            uiWindowResizeEdgeRight,
            uiWindowResizeEdgeBottom,
            uiWindowResizeEdgeTopLeft,
            uiWindowResizeEdgeTopRight,
            uiWindowResizeEdgeBottomLeft,
            uiWindowResizeEdgeBottomRight
        }

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiAreaSetSize_t(IntPtr a, int width, int height);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiAreaQueueReDrawAll_t(IntPtr a);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiAreaScrollTo_t(IntPtr area, double x, double y, double width, double height);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiAreaBeginUserWindowMove_t(IntPtr area);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiAreaBeginUserWindowResize_t(IntPtr area, uiWindowResizeEdge edge);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate IntPtr uiNewArea_t(uiAreaHandler ah);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate IntPtr uiNewScrollingArea_t(uiAreaHandler ah, int width, int height);

        [StructLayout(LayoutKind.Sequential)]
        internal struct uiAreaDrawParams
        {
            public IntPtr Context;

            //! Only defined for non-scrolling areas.
            public double AreaWidth;
            public double AreaHeight;

            public double ClipX;
            public double ClipY;
            public double ClipWidth;
            public double ClipHeight;
        }

        public enum uiDrawBrushType : uint
        {
            uiDrawBrushTypeSolid,
            uiDrawBrushTypeLinearGradient,
            uiDrawBrushTypeRadialGradient,
            uiDrawBrushTypeImage
        }

        public enum uiDrawLineCap : uint
        {
            uiDrawLineCapFlat,
            uiDrawLineCapRound,
            uiDrawLineCapSquare,
        }

        public enum uiDrawLineJoin : uint
        {
            uiDrawLineJoinMiter,
            uiDrawLineJoinRound,
            uiDrawLineJoinBevel
        }

        public const double uiDrawDefaultMiterLimit = 10.0;

        public enum uiDrawFillMode : uint
        {
            uiDrawFillModeWinding,
            uiDrawFillModeAlternate
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct uiDrawMatrix
        {
            public double M11;
            public double M12;
            public double M21;
            public double M22;
            public double M31;
            public double M32;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct uiDrawBrush
        {
            [MarshalAs(UnmanagedType.I4)]
            public uiDrawBrushType Type;

            // Solid Brushes
            public double R;
            public double G;
            public double B;
            public double A;

            // Gradient Brushes
            public double X0; // linear: start X, radial: start X
            public double Y0; // linear: start Y, radial: start Y
            public double X1; // linear: end X,   radial: outer circle center X
            public double Y1; // linear: end Y,   radial: outer circle center Y
            public double OuterRadius; // radial gradients only
            public IntPtr Stops;
            public UIntPtr NumStops;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct uiDrawBrushGradientStop
        {
            public double Pos;
            public double R;
            public double G;
            public double B;
            public double A;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct uiDrawStrokeParams
        {
            public uiDrawLineCap Cap;
            public uiDrawLineJoin Join;
            public double Thickness;
            public double MiterLimit;
            public IntPtr Dashes;
            public UIntPtr NumDashes;
            public double DashPhase;
        }

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate IntPtr uiDrawNewPath_t(uiDrawFillMode fillMode);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiDrawFreePath_t(IntPtr p);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiDrawPathNewFigure_t(IntPtr p, double x, double y);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiDrawPathNewFigureWithArc_t(IntPtr p, double xCenter, double yCenter, double radius, double startAngle, double sweep, bool negative);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiDrawPathLineTo_t(IntPtr p, double x, double y);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiDrawPathArcTo_t(IntPtr p, double xCenter, double yCenter, double radius, double startAngle, double sweep, bool negative);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiDrawPathBezierTo_t(IntPtr p, double c1x, double c1y, double c2x, double c2y, double endX, double endY);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiDrawPathCloseFigure_t(IntPtr p);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiDrawPathAddRectangle_t(IntPtr p, double x, double y, double width, double height);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiDrawPathEnd_t(IntPtr p);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiDrawStroke_t(IntPtr context, IntPtr path, ref uiDrawBrush brush, ref uiDrawStrokeParams strokeParam);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiDrawFill_t(IntPtr context, IntPtr path, ref uiDrawBrush brush);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiDrawMatrixSetIdentity_t(uiDrawMatrix matrix);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiDrawMatrixTranslate_t(uiDrawMatrix matrix, double x, double y);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiDrawMatrixScale_t(uiDrawMatrix matrix, double xCenter, double yCenter, double x, double y);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiDrawMatrixRotate_t(uiDrawMatrix matrix, double x, double y, double amount);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiDrawMatrixSkew_t(uiDrawMatrix matrix, double x, double y, double xamount, double yamount);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiDrawMatrixMultiply_t(uiDrawMatrix dest, uiDrawMatrix src);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate bool uiDrawMatrixInvertible_t(uiDrawMatrix matrix);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate int uiDrawMatrixInvert_t(uiDrawMatrix matrix);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiDrawMatrixTransformPoint_t(uiDrawMatrix matrix, out double x, out double y);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiDrawMatrixTransformSize_t(uiDrawMatrix matrix, out double x, out double y);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiDrawTransform_t(IntPtr context, uiDrawMatrix matrix);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiDrawClip_t(IntPtr context, IntPtr path);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiDrawSave_t(IntPtr context);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiDrawRestore_t(IntPtr context);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiFreeAttribute_t(IntPtr a);

        public enum uiAttributeType : uint
        {
            uiAttributeTypeFamily,
            uiAttributeTypeSize,
            uiAttributeTypeWeight,
            uiAttributeTypeItalic,
            uiAttributeTypeStretch,
            uiAttributeTypeColor,
            uiAttributeTypeBackground,
            uiAttributeTypeUnderline,
            uiAttributeTypeUnderlineColor,
            uiAttributeTypeFeatures
        }

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate uiAttributeType uiAttributeGetType_t(IntPtr a);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate IntPtr uiNewFamilyAttribute_t(IntPtr family);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate IntPtr uiAttributeFamily_t(IntPtr a);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate IntPtr uiNewSizeAttribute_t(double size);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate double uiAttributeSize_t(IntPtr a);

        public enum uiTextWeight : uint
        {
            uiTextWeightMinimum = 0,
            uiTextWeightThin = 100,
            uiTextWeightUltraLight = 200,
            uiTextWeightLight = 300,
            uiTextWeightBook = 350,
            uiTextWeightNormal = 400,
            uiTextWeightMedium = 500,
            uiTextWeightSemiBold = 600,
            uiTextWeightBold = 700,
            uiTextWeightUltraBold = 800,
            uiTextWeightHeavy = 900,
            uiTextWeightUltraHeavy = 950,
            uiTextWeightMaximum = 1000
        }

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate IntPtr uiNewWeightAttribute_t(uiTextWeight weight);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate uiTextWeight uiAttributeWeight_t(IntPtr a);

        public enum uiTextItalic : uint
        {
            uiTextItalicNormal,
            uiTextItalicOblique,
            uiTextItalicItalic
        }

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate IntPtr uiNewItalicAttribute_t(uiTextItalic italic);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate uiTextItalic uiAttributeItalic_t(IntPtr a);

        public enum uiTextStretch : uint
        {
            uiTextStretchUltraCondensed,
            uiTextStretchExtraCondensed,
            uiTextStretchCondensed,
            uiTextStretchSemiCondensed,
            uiTextStretchNormal,
            uiTextStretchSemiExpanded,
            uiTextStretchExpanded,
            uiTextStretchExtraExpanded,
            uiTextStretchUltraExpanded
        }

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate IntPtr uiNewStretchAttribute_t(uiTextStretch stretch);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate uiTextStretch uiAttributeStretch_t(IntPtr a);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate IntPtr uiNewColorAttribute_t(double r, double g, double b, double a);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiAttributeColor_t(IntPtr a, out double r, out double g, out double b, out double alpha);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate IntPtr uiNewBackgroundAttribute_t(double r, double g, double b, double a);

        public enum uiUnderline : uint
        {
            uiUnderlineNone,
            uiUnderlineSingle,
            uiUnderlineDouble,
            uiUnderlineSuggestion, // wavy or dotted underlines used for spelling/grammar checkers
        }

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate IntPtr uiNewUnderlineAttribute_t(uiUnderline u);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate uiUnderline uiAttributeUnderline_t(IntPtr a);

        public enum uiUnderlineColor : uint
        {
            uiUnderlineColorCustom,
            uiUnderlineColorSpelling,
            uiUnderlineColorGrammar,
            uiUnderlineColorAuxiliary, // for instance, the color used by smart replacements on macOS or in Microsoft Office
        }

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate IntPtr uiNewUnderlineColorAttribute_t(uiUnderlineColor u, double r, double g, double b, double a);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiAttributeUnderline__t(IntPtr a, out uiUnderlineColor u, out double r, out double g, out double b, out double alpha);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uiForEach uiOpenTypeFeaturesForEachFunc(IntPtr otf, byte a, byte b, byte c, byte d, uint value, IntPtr data);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate IntPtr uiNewOpenTypeFeatures_t();

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiFreeOpenTypeFeatures_t(IntPtr otf);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate IntPtr uiOpenTypeFeaturesClone_t(IntPtr otf);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiOpenTypeFeaturesAdd_t(IntPtr otf, byte a, byte b, byte c, byte d, uint value);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiOpenTypeFeaturesRemove_t(IntPtr otf, byte a, byte b, byte c, byte d);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate int uiOpenTypeFeaturesGet_t(IntPtr otf, byte a, byte b, byte c, byte d, out uint value);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiOpenTypeFeaturesForEach_t(IntPtr otf, uiOpenTypeFeaturesForEachFunc f, IntPtr data);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate IntPtr uiNewFeaturesAttribute_t(IntPtr otf);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate IntPtr uiAttributeFeatures_t(IntPtr a);
        
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uiForEach uiAttributedStringForEachAttributeFunc(IntPtr s, IntPtr a, UIntPtr start, UIntPtr end, IntPtr data);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate IntPtr uiNewAttributedString_t(IntPtr initialString);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiFreeAttributedString_t(IntPtr s);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate IntPtr uiAttributedStringString_t(IntPtr s);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate UIntPtr uiAttributedStringLen_t(IntPtr s);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiAttributedStringAppendUnattributed_t(IntPtr s, IntPtr str);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiAttributedStringInsertAtUnattributed_t(IntPtr s, IntPtr str, UIntPtr at);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiAttributedStringDelete_t(IntPtr s, UIntPtr start, UIntPtr end);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiAttributedStringSetAttribute_t(IntPtr s, IntPtr a, UIntPtr start, UIntPtr end);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiAttributedStringForEachAttribute_t(IntPtr s, uiAttributedStringForEachAttributeFunc f, IntPtr data);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate UIntPtr uiAttributedStringNumGraphemes_t(IntPtr s);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate UIntPtr uiAttributedStringByteIndexToGrapheme_t(IntPtr s, UIntPtr pos);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate UIntPtr uiAttributedStringGraphemeToByteIndex_t(IntPtr s, UIntPtr pos);

        [StructLayout(LayoutKind.Sequential)]
        public struct uiFontDescriptor
        {
            public IntPtr Family;
            public double Size;
            public uiTextWeight Weight;
            public uiTextItalic Italic;
            public uiTextStretch Stretch;
        }

        public enum uiDrawTextAlign : uint
        {
            uiDrawTextAlignLeft,
            uiDrawTextAlignCenter,
            uiDrawTextAlignRight
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct uiDrawTextLayoutParams
        {
            public IntPtr String;
            public uiFontDescriptor DefaultFont;
            public double Width;
            public uiDrawTextAlign Align;
        }

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate IntPtr uiDrawNewTextLayout_t(uiDrawTextLayoutParams param);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiDrawFreeTextLayout_t(IntPtr tl);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiDrawText_t(IntPtr c, IntPtr tl, double x, double y);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiDrawTextLayoutExtents_t(IntPtr tl, out double width, out double height);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiFontButtonFont_t(IntPtr b, out uiFontDescriptor desc);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiFontButtonOnChanged_t(IntPtr b, uiFontButtonOnChanged_tf f, IntPtr data);
        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiFontButtonOnChanged_tf(IntPtr b, IntPtr data);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate IntPtr uiNewFontButton_t();

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiFreeFontButtonFont_t(uiFontDescriptor desc);

        [Flags]
        public enum uiModifiers : uint
        {
            uiModifierCtrl = 1 << 0,
            uiModifierAlt = 1 << 1,
            uiModifierShift = 1 << 2,
            uiModifierSuper = 1 << 3
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct uiAreaMouseEvent
        {
            public double X;
            public double Y;

            public double AreaWidth;
            public double AreaHeight;

            public bool Down;
            public bool Up;

            public int Count;

            public uiModifiers Modifiers;

            public ulong Held1To64;
        }

        public enum uiExtKey : uint
        {
            uiExtKeyEscape = 1,
            uiExtKeyInsert, // equivalent to "Help" on Apple keyboards
            uiExtKeyDelete,
            uiExtKeyHome,
            uiExtKeyEnd,
            uiExtKeyPageUp,
            uiExtKeyPageDown,
            uiExtKeyUp,
            uiExtKeyDown,
            uiExtKeyLeft,
            uiExtKeyRight,
            uiExtKeyF1, // F1..F12 are guaranteed to be consecutive
            uiExtKeyF2,
            uiExtKeyF3,
            uiExtKeyF4,
            uiExtKeyF5,
            uiExtKeyF6,
            uiExtKeyF7,
            uiExtKeyF8,
            uiExtKeyF9,
            uiExtKeyF10,
            uiExtKeyF11,
            uiExtKeyF12,
            uiExtKeyN0, // numpad keys; independent of Num Lock state
            uiExtKeyN1, // N0..N9 are guaranteed to be consecutive
            uiExtKeyN2,
            uiExtKeyN3,
            uiExtKeyN4,
            uiExtKeyN5,
            uiExtKeyN6,
            uiExtKeyN7,
            uiExtKeyN8,
            uiExtKeyN9,
            uiExtKeyNDot,
            uiExtKeyNEnter,
            uiExtKeyNAdd,
            uiExtKeyNSubtract,
            uiExtKeyNMultiply,
            uiExtKeyNDivide
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct uiAreaKeyEvent
        {
            public byte Key;
            public uiExtKey ExtKey;
            public uiModifiers Modifier;
            public uiModifiers Modifiers;
            public bool Up;
        }

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiColorButtonColor_t(IntPtr b, out double red, out double green, out double blue, out double alpha);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiColorButtonSetColor_t(IntPtr b, double red, double green, double blue, double alpha);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiColorButtonOnChanged_t(IntPtr b, uiColorButtonOnChanged_tf f, IntPtr data);
        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiColorButtonOnChanged_tf(IntPtr b, IntPtr data);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate IntPtr uiNewColorButton_t();

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiFormAppend_t(IntPtr f, IntPtr label, IntPtr c, bool stretchy);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiFormDelete_t(IntPtr f, int index);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate bool uiFormPadded_t(IntPtr f);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiFormSetPadded_t(IntPtr f, bool padded);

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate IntPtr uiNewForm_t();

        public enum uiAlign : uint
        {
            uiAlignFill,
            uiAlignStart,
            uiAlignCenter,
            uiAlignEnd
        }

        public enum uiAt : uint
        {
            uiAtLeading,
            uiAtTop,
            uiAtTrailing,
            uiAtBottom
        }

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiGridAppend_t(IntPtr grid, IntPtr child, int left, int top, int xspan, int yspan, int hexpand, uiAlign halign, int vexpand, uiAlign valign);
        public static ui() => FunctionLoader.Load<ui_t>("ui")();

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiGridInsertAt_t(IntPtr grid, IntPtr child, IntPtr existing, uiAt at, int xspan, int yspan, int hexpand, uiAlign halign, int vexpand, uiAlign valign);
        public static ui() => FunctionLoader.Load<ui_t>("ui")();

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate bool uiGridPadded_t(IntPtr grid);
        public static ui() => FunctionLoader.Load<ui_t>("ui")();

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate void uiGridSetPadded_t(IntPtr grid, bool padded);
        public static void uiGridSetPadded(IntPtr g, bool padded) => FunctionLoader.Load<ui_t>("ui")();

        [UnmanagedFunctionPointer(callingConvention)]
        private delegate IntPtr uiNewGrid_t();
        public static IntPtr uiNewGrid() => FunctionLoader.Load<uiNewGrid_t>("uiNewGrid")();
    }
}