using System;
using System.Runtime.InteropServices;

namespace LibUISharp.Internal
{
    // C Header: ui.h
    internal static class LibuiLibrary
    {
        private const CallingConvention Convention = CallingConvention.Cdecl;
        private const LayoutKind Layout = LayoutKind.Sequential;

        private static class FunctionLoader
        {
            private static readonly string[] WinNTLibNames = new[] 
            {
                @"runtimes\win7-x64\native\libui.dll"
            };
            private static readonly string[] LinuxLibNames = new[] 
            {
                @"runtimes\linux-x64\native\libui.so",
                @"runtimes\linux-x64\native\libui.so.0"
            };
            private static readonly string[] MacOSLibNames = new[]
            {
                @"runtimes\osx-x64\native\libui.dylib",
                @"runtimes\osx-x64\native\libui.A.dylib"
            };

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

        [StructLayout(Layout)]
        public struct uiInitOptions
        {
            public UIntPtr Size;
        }

        #region General (Application, Text)
        [UnmanagedFunctionPointer(Convention)]
        private delegate IntPtr uiInit_t(ref uiInitOptions options);
        public static IntPtr uiInit(ref uiInitOptions options) => FunctionLoader.Load<uiInit_t>("uiInit")(ref options);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiUnInit_t();
        public static void uiUnInit() => FunctionLoader.Load<uiUnInit_t>("uiUnInit")();

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiFreeInitError_t(IntPtr err);
        public static void uiFreeInitError(IntPtr err) => FunctionLoader.Load<uiFreeInitError_t>("uiFreeInitError")(err);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiMain_t();
        public static void uiMain() => FunctionLoader.Load<uiMain_t>("uiMain")();

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiMainSteps_t();
        public static void uiMainSteps() => FunctionLoader.Load<uiMainSteps_t>("uiMainSteps")();

        [UnmanagedFunctionPointer(Convention)]
        private delegate bool uiMainStep_t(bool wait);
        public static bool uiMainStep(bool wait) => FunctionLoader.Load<uiMainStep_t>("uiMainStep")(wait);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiQuit_t();
        public static void uiQuit() => FunctionLoader.Load<uiQuit_t>("uiQuit")();

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiQueueMain_t(uiQueueMain_tf f, IntPtr data);
        [UnmanagedFunctionPointer(Convention)]
        public delegate void uiQueueMain_tf(IntPtr data);
        public static void uiQueueMain(uiQueueMain_tf f, IntPtr data) => FunctionLoader.Load<uiQueueMain_t>("uiQueueMain")(f, data);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiOnShouldQuit_t(uiOnShouldQuit_tf f, IntPtr data);
        [UnmanagedFunctionPointer(Convention)]
        public delegate bool uiOnShouldQuit_tf(IntPtr data);
        public static void uiOnShouldQuit(uiOnShouldQuit_tf f, IntPtr data) => FunctionLoader.Load<uiOnShouldQuit_t>("uiOnShouldQuit")(f, data);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiFreeText_t(IntPtr text);
        public static void uiFreeText(IntPtr text) => FunctionLoader.Load<uiFreeText_t>("uiFreeText")(text);
        #endregion

        #region uiControl (Contol)
        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiControlDestroy_t(IntPtr c);
        public static void uiControlDestroy(IntPtr c) => FunctionLoader.Load<uiControlDestroy_t>("uiControlDestroy")(c);

        [UnmanagedFunctionPointer(Convention)]
        private delegate UIntPtr uiControlHandle_t(IntPtr c);
        public static UIntPtr uiControlHandle(IntPtr c) => FunctionLoader.Load<uiControlHandle_t>("uiControlHandle")(c);

        [UnmanagedFunctionPointer(Convention)]
        private delegate IntPtr uiControlParent_t(IntPtr c);
        public static IntPtr uiControlParent(IntPtr c) => FunctionLoader.Load<uiControlParent_t>("uiControlParent")(c);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiControlSetParent_t(IntPtr c, IntPtr parent);
        public static void uiControlSetParent(IntPtr c, IntPtr parent) => FunctionLoader.Load<uiControlSetParent_t>("uiControlSetParent")(c, parent);

        [UnmanagedFunctionPointer(Convention)]
        private delegate bool uiControlToplevel_t(IntPtr c);
        public static bool uiControlToplevel(IntPtr c) => FunctionLoader.Load<uiControlToplevel_t>("uiControlToplevel")(c);

        [UnmanagedFunctionPointer(Convention)]
        private delegate bool uiControlVisible_t(IntPtr c);
        public static bool uiControlVisible(IntPtr c) => FunctionLoader.Load<uiControlVisible_t>("uiControlVisible")(c);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiControlShow_t(IntPtr c);
        public static void uiControlShow(IntPtr c) => FunctionLoader.Load<uiControlShow_t>("uiControlShow")(c);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiControlHide_t(IntPtr c);
        public static void uiControlHide(IntPtr c) => FunctionLoader.Load<uiControlHide_t>("uiControlHide")(c);

        [UnmanagedFunctionPointer(Convention)]
        private delegate bool uiControlEnabled_t(IntPtr c);
        public static bool uiControlEnabled(IntPtr c) => FunctionLoader.Load<uiControlEnabled_t>("uiControlEnabled")(c);

        [UnmanagedFunctionPointer(Convention)]
        private delegate bool uiControlEnable_t(IntPtr c);
        public static void uiControlEnable(IntPtr c) => FunctionLoader.Load<uiControlEnable_t>("uiControlEnable")(c);

        [UnmanagedFunctionPointer(Convention)]
        private delegate bool uiControlDisable_t(IntPtr c);
        public static void uiControlDisable(IntPtr c) => FunctionLoader.Load<uiControlDisable_t>("uiControlDisable")(c);

        [UnmanagedFunctionPointer(Convention)]
        private delegate bool uiControlVerifySetParent_t(IntPtr c, IntPtr parent);
        public static void uiControlVerifySetParent(IntPtr c, IntPtr parent) => FunctionLoader.Load<uiControlVerifySetParent_t>("uiControlVerifySetParent")(c, parent);

        [UnmanagedFunctionPointer(Convention)]
        private delegate bool uiControlEnabledToUser_t(IntPtr c);
        public static bool uiControlEnabledToUser(IntPtr c) => FunctionLoader.Load<uiControlEnabledToUser_t>("uiControlEnabledToUser")(c);
        #endregion

        #region uiWindow (Window)
        [UnmanagedFunctionPointer(Convention)]
        private delegate IntPtr uiWindowTitle_t(IntPtr w);
        public static IntPtr uiWindowTitle(IntPtr w) => FunctionLoader.Load<uiWindowTitle_t>("uiWindowTitle")(w);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiWindowSetTitle_t(IntPtr w, IntPtr title);
        public static void uiWindowSetTitle(IntPtr w, IntPtr title) => FunctionLoader.Load<uiWindowSetTitle_t>("uiWindowSetTitle")(w, title);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiWindowContentSize_t(IntPtr w, out int width, out int height);
        public static void uiWindowContentSize(IntPtr w, out int width, out int height) => FunctionLoader.Load<uiWindowContentSize_t>("uiWindowContentSize")(w, out width, out height);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiWindowSetContentSize_t(IntPtr w, int width, int height);
        public static void uiWindowSetContentSize(IntPtr w, int width, int height) => FunctionLoader.Load<uiWindowSetContentSize_t>("uiWindowSetContentSize")(w, width, height);

        [UnmanagedFunctionPointer(Convention)]
        private delegate bool uiWindowFullscreen_t(IntPtr w);
        public static bool uiWindowFullscreen(IntPtr w) => FunctionLoader.Load<uiWindowFullscreen_t>("uiWindowFullscreen")(w);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiWindowSetFullscreen_t(IntPtr w, bool fullscreen);
        public static void uiWindowSetFullscreen(IntPtr w, bool fullscreen) => FunctionLoader.Load<uiWindowSetFullscreen_t>("uiWindowSetFullscreen")(w, fullscreen);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiWindowOnContentSizeChanged_t(IntPtr w, uiWindowOnContentSizeChanged_tf f, IntPtr data);
        [UnmanagedFunctionPointer(Convention)]
        public delegate void uiWindowOnContentSizeChanged_tf(IntPtr w, IntPtr data);
        public static void uiWindowOnContentSizeChanged(IntPtr w, uiWindowOnContentSizeChanged_tf f, IntPtr data) => FunctionLoader.Load<uiWindowOnContentSizeChanged_t>("uiWindowOnContentSizeChanged")(w, f, data);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiWindowOnClosing_t(IntPtr w, uiWindowOnClosing_tf f, IntPtr data);
        [UnmanagedFunctionPointer(Convention)]
        public delegate bool uiWindowOnClosing_tf(IntPtr w, IntPtr data);
        public static void uiWindowOnClosing(IntPtr w, uiWindowOnClosing_tf f, IntPtr data) => FunctionLoader.Load<uiWindowOnClosing_t>("uiWindowOnClosing")(w, f, data);

        [UnmanagedFunctionPointer(Convention)]
        private delegate bool uiWindowBorderless_t(IntPtr w);
        public static bool uiWindowBorderless(IntPtr w) => FunctionLoader.Load<uiWindowBorderless_t>("uiWindowBorderless")(w);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiWindowSetBorderless_t(IntPtr w, bool borderless);
        public static void uiWindowSetBorderless(IntPtr w, bool borderless) => FunctionLoader.Load<uiWindowSetBorderless_t>("uiWindowSetBorderless")(w, borderless);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiWindowSetChild_t(IntPtr w, IntPtr child);
        public static void uiWindowSetChild(IntPtr w, IntPtr child) => FunctionLoader.Load<uiWindowSetChild_t>("uiWindowSetChild")(w, child);

        [UnmanagedFunctionPointer(Convention)]
        private delegate bool uiWindowMargined_t(IntPtr w);
        public static bool uiWindowMargined(IntPtr w) => FunctionLoader.Load<uiWindowMargined_t>("uiWindowMargined")(w);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiWindowSetMargined_t(IntPtr w, bool margined);
        public static void uiWindowSetMargined(IntPtr w, bool margined) => FunctionLoader.Load<uiWindowSetMargined_t>("uiWindowSetMargined")(w, margined);

        [UnmanagedFunctionPointer(Convention)]
        private delegate IntPtr uiNewWindow_t(IntPtr title, int width, int height, bool hasMenubar);
        public static IntPtr uiNewWindow(IntPtr title, int width, int height, bool hasMenubar) => FunctionLoader.Load<uiNewWindow_t>("uiNewWindow")(title, width, height, hasMenubar);
        #endregion

        #region uiButton (Button)
        [UnmanagedFunctionPointer(Convention)]
        private delegate IntPtr uiButtonText_t(IntPtr b);
        public static IntPtr uiButtonText(IntPtr b) => FunctionLoader.Load<uiButtonText_t>("uiButtonText")(b);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiButtonSetText_t(IntPtr b, IntPtr title);
        public static void uiButtonSetText(IntPtr b, IntPtr title) => FunctionLoader.Load<uiButtonSetText_t>("uiButtonSetText")(b, title);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiButtonOnClicked_t(IntPtr b, uiButtonOnClicked_tf f, IntPtr data);
        [UnmanagedFunctionPointer(Convention)]
        public delegate void uiButtonOnClicked_tf(IntPtr b, IntPtr data);
        public static void uiButtonOnClicked(IntPtr b, uiButtonOnClicked_tf f, IntPtr data) => FunctionLoader.Load<uiButtonOnClicked_t>("uiButtonOnClicked")(b, f, data);

        [UnmanagedFunctionPointer(Convention)]
        private delegate IntPtr uiNewButton_t(IntPtr text);
        public static IntPtr uiNewButton(IntPtr text) => FunctionLoader.Load<uiNewButton_t>("uiNewButton")(text);
        #endregion

        #region uiBox (StackPanel)
        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiBoxAppend_t(IntPtr b, IntPtr child, bool stretchy);
        public static void uiBoxAppend(IntPtr b, IntPtr child, bool stretchy) => FunctionLoader.Load<uiBoxAppend_t>("uiBoxAppend")(b, child, stretchy);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiBoxDelete_t(IntPtr b, int index);
        public static void uiBoxDelete(IntPtr b, int index) => FunctionLoader.Load<uiBoxDelete_t>("uiBoxDelete")(b, index);

        [UnmanagedFunctionPointer(Convention)]
        private delegate bool uiBoxPadded_t(IntPtr b);
        public static bool uiBoxPadded(IntPtr b) => FunctionLoader.Load<uiBoxPadded_t>("uiBoxPadded")(b);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiBoxSetPadded_t(IntPtr b, bool padded);
        public static void uiBoxSetPadded(IntPtr b, bool padded) => FunctionLoader.Load<uiBoxSetPadded_t>("uiBoxSetPadded")(b, padded);

        [UnmanagedFunctionPointer(Convention)]
        private delegate IntPtr uiNewHorizontalBox_t();
        public static IntPtr uiNewHorizontalBox() => FunctionLoader.Load<uiNewHorizontalBox_t>("uiNewHorizontalBox")();

        [UnmanagedFunctionPointer(Convention)]
        private delegate IntPtr uiNewVerticalBox_t();
        public static IntPtr uiNewVerticalBox() => FunctionLoader.Load<uiNewVerticalBox_t>("uiNewVerticalBox")();
        #endregion

        #region uiCheckbox (CheckBox)
        [UnmanagedFunctionPointer(Convention)]
        private delegate IntPtr uiCheckboxText_t(IntPtr c);
        public static IntPtr uiCheckboxText(IntPtr c) => FunctionLoader.Load<uiCheckboxText_t>("uiCheckboxText")(c);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiCheckboxSetText_t(IntPtr c, IntPtr text);
        public static void uiCheckboxSetText(IntPtr c, IntPtr text) => FunctionLoader.Load<uiCheckboxSetText_t>("uiCheckboxSetText")(c, text);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiCheckboxOnToggled_t(IntPtr c, uiCheckboxOnToggled_tf f, IntPtr data);
        [UnmanagedFunctionPointer(Convention)]
        public delegate void uiCheckboxOnToggled_tf(IntPtr c, IntPtr data);
        public static void uiCheckboxOnToggled(IntPtr c, uiCheckboxOnToggled_tf f, IntPtr data) => FunctionLoader.Load<uiCheckboxOnToggled_t>("uiCheckboxOnToggled")(c, f, data);

        [UnmanagedFunctionPointer(Convention)]
        private delegate bool uiCheckboxChecked_t(IntPtr c);
        public static bool uiCheckboxChecked(IntPtr c) => FunctionLoader.Load<uiCheckboxChecked_t>("uiCheckboxChecked")(c);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiCheckboxSetChecked_t(IntPtr c, bool @checked);
        public static void uiCheckboxSetChecked(IntPtr c, bool @checked) => FunctionLoader.Load<uiCheckboxSetChecked_t>("uiCheckboxSetChecked")(c, @checked);

        [UnmanagedFunctionPointer(Convention)]
        private delegate IntPtr uiNewCheckbox_t(IntPtr text);
        public static IntPtr uiNewCheckbox(IntPtr text) => FunctionLoader.Load<uiNewCheckbox_t>("uiNewCheckbox")(text);
        #endregion

        #region uiEntry/uiPasswordEntry/uiSearchEntry (TextBox/PasswordBox/SearchBox)
        [UnmanagedFunctionPointer(Convention)]
        private delegate IntPtr uiEntryText_t(IntPtr e);
        public static IntPtr uiEntryText(IntPtr e) => FunctionLoader.Load<uiEntryText_t>("uiEntryText")(e);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiEntrySetText_t(IntPtr e, IntPtr text);
        public static void uiEntrySetText(IntPtr e, IntPtr text) => FunctionLoader.Load<uiEntrySetText_t>("uiEntrySetText")(e, text);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiEntryOnChanged_t(IntPtr e, uiEntryOnChanged_tf f, IntPtr data);
        [UnmanagedFunctionPointer(Convention)]
        public delegate void uiEntryOnChanged_tf(IntPtr e, IntPtr data);
        public static void uiEntryOnChanged(IntPtr e, uiEntryOnChanged_tf f, IntPtr data) => FunctionLoader.Load<uiEntryOnChanged_t>("uiEntryOnChanged")(e, f, data);

        [UnmanagedFunctionPointer(Convention)]
        private delegate bool uiEntryReadOnly_t(IntPtr e);
        public static bool uiEntryReadOnly(IntPtr e) => FunctionLoader.Load<uiEntryReadOnly_t>("uiEntryReadOnly")(e);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiEntrySetReadOnly_t(IntPtr e, bool @readonly);
        public static void uiEntrySetReadOnly(IntPtr e, bool @readonly) => FunctionLoader.Load<uiEntrySetReadOnly_t>("uiEntrySetReadOnly")(e, @readonly);

        [UnmanagedFunctionPointer(Convention)]
        private delegate IntPtr uiNewEntry_t();
        public static IntPtr uiNewEntry() => FunctionLoader.Load<uiNewEntry_t>("uiNewEntry")();

        [UnmanagedFunctionPointer(Convention)]
        private delegate IntPtr uiNewPasswordEntry_t();
        public static IntPtr uiNewPasswordEntry() => FunctionLoader.Load<uiNewPasswordEntry_t>("uiNewPasswordEntry")();

        [UnmanagedFunctionPointer(Convention)]
        private delegate IntPtr uiNewSearchEntry_t();
        public static IntPtr uiNewSearchEntry() => FunctionLoader.Load<uiNewSearchEntry_t>("uiNewSearchEntry")();
        #endregion

        #region uiLabel (Label)
        [UnmanagedFunctionPointer(Convention)]
        private delegate IntPtr uiLabelText_t(IntPtr l);
        public static IntPtr uiLabelText(IntPtr l) => FunctionLoader.Load<uiLabelText_t>("uiLabelText")(l);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiLabelSetText_t(IntPtr l, IntPtr text);
        public static void uiLabelSetText(IntPtr l, IntPtr text) => FunctionLoader.Load<uiLabelSetText_t>("uiLabelSetText")(l, text);

        [UnmanagedFunctionPointer(Convention)]
        private delegate IntPtr uiNewLabel_t(IntPtr text);
        public static IntPtr uiNewLabel(IntPtr text) => FunctionLoader.Load<uiNewLabel_t>("uiNewLabel")(text);
        #endregion

        #region uiTab (TabControl)
        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiTabAppend_t(IntPtr t, IntPtr name, IntPtr c);
        public static void uiTabAppend(IntPtr t, IntPtr name, IntPtr c) => FunctionLoader.Load<uiTabAppend_t>("uiTabAppend")(t, name, c);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiTabInsertAt_t(IntPtr t, IntPtr name, int before, IntPtr c);
        public static void uiTabInsertAt(IntPtr t, IntPtr name, int before, IntPtr c) => FunctionLoader.Load<uiTabInsertAt_t>("uiTabInsertAt")(t, name, before, c);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiTabDelete_t(IntPtr t, int index);
        public static void uiTabDelete(IntPtr t, int index) => FunctionLoader.Load<uiTabDelete_t>("uiTabDelete")(t, index);

        [UnmanagedFunctionPointer(Convention)]
        private delegate int uiTabNumPages_t(IntPtr t);
        public static int uiTabNumPages(IntPtr t) => FunctionLoader.Load<uiTabNumPages_t>("uiTabNumPages")(t);

        [UnmanagedFunctionPointer(Convention)]
        private delegate bool uiTabMargined_t(IntPtr t, int page);
        public static bool uiTabMargined(IntPtr t, int page) => FunctionLoader.Load<uiTabMargined_t>("uiTabMargined")(t, page);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiTabSetMargined_t(IntPtr t, int page, bool margined);
        public static void uiTabSetMargined(IntPtr t, int page, bool margined) => FunctionLoader.Load<uiTabSetMargined_t>("uiTabSetMargined")(t, page, margined);

        [UnmanagedFunctionPointer(Convention)]
        private delegate IntPtr uiNewTab_t();
        public static IntPtr uiNewTab() => FunctionLoader.Load<uiNewTab_t>("uiNewTab")();
        #endregion

        #region uiGroup (GroupBox)
        [UnmanagedFunctionPointer(Convention)]
        private delegate IntPtr uiGroupTitle_t(IntPtr g);
        public static IntPtr uiGroupTitle(IntPtr g) => FunctionLoader.Load<uiGroupTitle_t>("uiGroupTitle")(g);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiGroupSetTitle_t(IntPtr g, IntPtr title);
        public static void uiGroupSetTitle(IntPtr g, IntPtr title) => FunctionLoader.Load<uiGroupSetTitle_t>("uiGroupSetTitle")(g, title);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiGroupSetChild_t(IntPtr g, IntPtr child);
        public static void uiGroupSetChild(IntPtr g, IntPtr child) => FunctionLoader.Load<uiGroupSetChild_t>("uiGroupSetChild")(g, child);

        [UnmanagedFunctionPointer(Convention)]
        private delegate bool uiGroupMargined_t(IntPtr g);
        public static bool uiGroupMargined(IntPtr g) => FunctionLoader.Load<uiGroupMargined_t>("uiGroupMargined")(g);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiGroupSetMargined_t(IntPtr g, bool margined);
        public static void uiGroupSetMargined(IntPtr g, bool margined) => FunctionLoader.Load<uiGroupSetMargined_t>("uiGroupSetMargined")(g, margined);

        [UnmanagedFunctionPointer(Convention)]
        private delegate IntPtr uiNewGroup_t(IntPtr title);
        public static IntPtr uiNewGroup(IntPtr title) => FunctionLoader.Load<uiNewGroup_t>("uiNewGroup")(title);
        #endregion

        #region uiSpinbox (SpinBox)
        [UnmanagedFunctionPointer(Convention)]
        private delegate int uiSpinboxValue_t(IntPtr s);
        public static int uiSpinboxValue(IntPtr s) => FunctionLoader.Load<uiSpinboxValue_t>("uiSpinboxValue")(s);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiSpinboxSetValue_t(IntPtr s, int value);
        public static void uiSpinboxSetValue(IntPtr s, int value) => FunctionLoader.Load<uiSpinboxSetValue_t>("uiSpinboxSetValue")(s, value);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiSpinboxOnChanged_t(IntPtr s, uiSpinboxOnChanged_tf f, IntPtr data);
        [UnmanagedFunctionPointer(Convention)]
        public delegate void uiSpinboxOnChanged_tf(IntPtr s, IntPtr data);
        public static void uiSpinboxOnChanged(IntPtr s, uiSpinboxOnChanged_tf f, IntPtr data) => FunctionLoader.Load<uiSpinboxOnChanged_t>("uiSpinboxOnChanged")(s, f, data);

        [UnmanagedFunctionPointer(Convention)]
        private delegate IntPtr uiNewSpinbox_t(int min, int max);
        public static IntPtr uiNewSpinbox(int min, int max) => FunctionLoader.Load<uiNewSpinbox_t>("uiNewSpinbox")(min, max);
        #endregion

        #region uiSlider (Slider)
        [UnmanagedFunctionPointer(Convention)]
        private delegate int uiSliderValue_t(IntPtr s);
        public static int uiSliderValue(IntPtr s) => FunctionLoader.Load<uiSliderValue_t>("uiSliderValue")(s);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiSliderSetValue_t(IntPtr s, int value);
        public static void uiSliderSetValue(IntPtr s, int value) => FunctionLoader.Load<uiSliderSetValue_t>("uiSliderSetValue")(s, value);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiSliderOnChanged_t(IntPtr s, uiSliderOnChanged_tf f, IntPtr data);
        [UnmanagedFunctionPointer(Convention)]
        public delegate void uiSliderOnChanged_tf(IntPtr s, IntPtr data);
        public static void uiSliderOnChanged(IntPtr s, uiSliderOnChanged_tf f, IntPtr data) => FunctionLoader.Load<uiSliderOnChanged_t>("uiSliderOnChanged")(s, f, data);

        [UnmanagedFunctionPointer(Convention)]
        private delegate IntPtr uiNewSlider_t(int min, int max);
        public static IntPtr uiNewSlider(int min, int max) => FunctionLoader.Load<uiNewSlider_t>("uiNewSlider")(min, max);
        #endregion

        #region uiProgressBar (ProgressBar)
        [UnmanagedFunctionPointer(Convention)]
        private delegate int uiProgressBarValue_t(IntPtr p);
        public static int uiProgressBarValue(IntPtr p) => FunctionLoader.Load<uiProgressBarValue_t>("uiProgressBarValue")(p);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiProgressBarSetValue_t(IntPtr p, int n);
        public static void uiProgressBarSetValue(IntPtr p, int n) => FunctionLoader.Load<uiProgressBarSetValue_t>("uiProgressBarSetValue")(p, n);

        [UnmanagedFunctionPointer(Convention)]
        private delegate IntPtr uiNewProgressBar_t();
        public static IntPtr uiNewProgressBar() => FunctionLoader.Load<uiNewProgressBar_t>("uiNewProgressBar")();
        #endregion

        #region uiSeparator/uiHorizontalSeparator/uiVerticalSeparator (Separator)
        [UnmanagedFunctionPointer(Convention)]
        private delegate IntPtr uiNewHorizontalSeparator_t();
        public static IntPtr uiNewHorizontalSeparator() => FunctionLoader.Load<uiNewHorizontalSeparator_t>("uiNewHorizontalSeparator")();

        [UnmanagedFunctionPointer(Convention)]
        private delegate IntPtr uiNewVerticalSeparator_t();
        public static IntPtr uiNewVerticalSeparator() => FunctionLoader.Load<uiNewVerticalSeparator_t>("uiNewVerticalSeparator")();
        #endregion

        #region uiCombobox (ComboBox)
        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiComboboxAppend_t(IntPtr c, IntPtr text);
        public static void uiComboboxAppend(IntPtr c, IntPtr text) => FunctionLoader.Load<uiComboboxAppend_t>("uiComboboxAppend")(c, text);

        [UnmanagedFunctionPointer(Convention)]
        private delegate int uiComboboxSelected_t(IntPtr c);
        public static int uiComboboxSelected(IntPtr c) => FunctionLoader.Load<uiComboboxSelected_t>("uiComboboxSelected")(c);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiComboboxSetSelected_t(IntPtr c, int n);
        public static void uiComboboxSetSelected(IntPtr c, int n) => FunctionLoader.Load<uiComboboxSetSelected_t>("uiComboboxSetSelected")(c, n);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiComboboxOnSelected_t(IntPtr c, uiComboboxOnSelected_tf f, IntPtr data);
        [UnmanagedFunctionPointer(Convention)]
        public delegate void uiComboboxOnSelected_tf(IntPtr c, IntPtr data);
        public static void uiComboboxOnSelected(IntPtr c, uiComboboxOnSelected_tf f, IntPtr data) => FunctionLoader.Load<uiComboboxOnSelected_t>("uiComboboxOnSelected")(c, f, data);

        [UnmanagedFunctionPointer(Convention)]
        private delegate IntPtr uiNewCombobox_t();
        public static IntPtr uiNewCombobox() => FunctionLoader.Load<uiNewCombobox_t>("uiNewCombobox")();
        #endregion

        #region uiEditableCombobox (EditableComboBox)
        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiEditableComboboxAppend_t(IntPtr c, IntPtr text);
        public static void uiEditableComboboxAppend(IntPtr c, IntPtr text) => FunctionLoader.Load<uiEditableComboboxAppend_t>("uiEditableComboboxAppend")(c, text);

        [UnmanagedFunctionPointer(Convention)]
        private delegate IntPtr uiEditableComboboxText_t(IntPtr c);
        public static IntPtr uiEditableComboboxText(IntPtr c) => FunctionLoader.Load<uiEditableComboboxText_t>("uiEditableComboboxText")(c);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiEditableComboboxSetText_t(IntPtr c, IntPtr text);
        public static void uiEditableComboboxSetText(IntPtr c, IntPtr text) => FunctionLoader.Load<uiEditableComboboxSetText_t>("uiEditableComboboxSetText")(c, text);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiEditableComboboxOnChanged_t(IntPtr c, uiEditableComboboxOnChanged_tf f, IntPtr data);
        [UnmanagedFunctionPointer(Convention)]
        public delegate void uiEditableComboboxOnChanged_tf(IntPtr c, IntPtr data);
        public static void uiEditableComboboxOnChanged(IntPtr c, uiEditableComboboxOnChanged_tf f, IntPtr data) => FunctionLoader.Load<uiEditableComboboxOnChanged_t>("uiEditableComboboxOnChanged")(c, f, data);

        [UnmanagedFunctionPointer(Convention)]
        private delegate IntPtr uiNewEditableCombobox_t();
        public static IntPtr uiNewEditableCombobox() => FunctionLoader.Load<uiNewEditableCombobox_t>("uiNewEditableCombobox")();
        #endregion

        #region uiRadioButtons (RadioButtonGroup)
        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiRadioButtonsAppend_t(IntPtr r, IntPtr text);
        public static void uiRadioButtonsAppend(IntPtr r, IntPtr text) => FunctionLoader.Load<uiRadioButtonsAppend_t>("uiRadioButtonsAppend")(r, text);

        [UnmanagedFunctionPointer(Convention)]
        private delegate int uiRadioButtonsSelected_t(IntPtr r);
        public static int uiRadioButtonsSelected(IntPtr r) => FunctionLoader.Load<uiRadioButtonsSelected_t>("uiRadioButtonsSelected")(r);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiRadioButtonsSetSelected_t(IntPtr r, int n);
        public static void uiRadioButtonsSetSelected(IntPtr r, int n) => FunctionLoader.Load<uiRadioButtonsSetSelected_t>("uiRadioButtonsSetSelected")(r, n);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiRadioButtonsOnSelected_t(IntPtr r, uiRadioButtonsOnSelected_tf f, IntPtr data);
        [UnmanagedFunctionPointer(Convention)]
        public delegate void uiRadioButtonsOnSelected_tf(IntPtr r, IntPtr data);
        public static void uiRadioButtonsOnSelected(IntPtr r, uiRadioButtonsOnSelected_tf f, IntPtr data) => FunctionLoader.Load<uiRadioButtonsOnSelected_t>("uiRadioButtonsOnSelected")(r, f, data);

        [UnmanagedFunctionPointer(Convention)]
        private delegate IntPtr uiNewRadioButtons_t();
        public static IntPtr uiNewRadioButtons() => FunctionLoader.Load<uiNewRadioButtons_t>("uiNewRadioButtons")();
        #endregion

#if LIBUI_4_0
        [StructLayout(Layout)]
        public struct tm
        {
            public int tm_sec;
            public int tm_min;
            public int tm_hour;
            public int tm_mday;
            public int tm_mon;
            public int tm_year;
            public int tm_wday; // undefined
            public int tm_yday; // undefined
            public int tm_isdst; // -1
        }

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiDateTimePickerTime_t(IntPtr d, out tm time);
        public static void uiDateTimePickerTime(IntPtr d, out tm time) => FunctionLoader.Load<uiDateTimePickerTime_t>("uiDateTimePickerTime")(d, out time);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiDateTimePickerSetTime_t(IntPtr d, tm time);
        public static void uiDateTimePickerSetTime(IntPtr d, tm time) => FunctionLoader.Load<uiDateTimePickerSetTime_t>("uiDateTimePickerSetTime")(d, time);

#endif
        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiDateTimePickerOnChanged_t(IntPtr d, uiDateTimePickerOnChanged_tf f, IntPtr data);
        [UnmanagedFunctionPointer(Convention)]
        public delegate void uiDateTimePickerOnChanged_tf(IntPtr d, IntPtr data);
        public static void uiDateTimePickerOnChanged(IntPtr d, uiDateTimePickerOnChanged_tf f, IntPtr data) => FunctionLoader.Load<uiDateTimePickerOnChanged_t>("uiDateTimePickerOnChanged")(d, f, data);

        [UnmanagedFunctionPointer(Convention)]
        private delegate IntPtr uiNewDateTimePicker_t();
        public static IntPtr uiNewDateTimePicker() => FunctionLoader.Load<uiNewDateTimePicker_t>("uiNewDateTimePicker")();

        [UnmanagedFunctionPointer(Convention)]
        private delegate IntPtr uiNewDatePicker_t();
        public static IntPtr uiNewDatePicker() => FunctionLoader.Load<uiNewDatePicker_t>("uiNewDatePicker")();

        [UnmanagedFunctionPointer(Convention)]
        private delegate IntPtr uiNewTimePicker_t();
        public static IntPtr uiNewTimePicker() => FunctionLoader.Load<uiNewTimePicker_t>("uiNewTimePicker")();

        [UnmanagedFunctionPointer(Convention)]
        private delegate IntPtr uiMultilineEntryText_t(IntPtr e);
        public static IntPtr uiMultilineEntryText(IntPtr e) => FunctionLoader.Load<uiMultilineEntryText_t>("uiMultilineEntryText")(e);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiMultilineEntrySetText_t(IntPtr e, IntPtr text);
        public static void uiMultilineEntrySetText(IntPtr e, IntPtr text) => FunctionLoader.Load<uiMultilineEntrySetText_t>("uiMultilineEntrySetText")(e, text);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiMultilineEntryAppend_t(IntPtr e, IntPtr text);
        public static void uiMultilineEntryAppend(IntPtr e, IntPtr text) => FunctionLoader.Load<uiMultilineEntryAppend_t>("uiMultilineEntryAppend")(e, text);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiMultilineEntryOnChanged_t(IntPtr e, uiMultilineEntryOnChanged_tf f, IntPtr data);
        [UnmanagedFunctionPointer(Convention)]
        public delegate void uiMultilineEntryOnChanged_tf(IntPtr e, IntPtr data);
        public static void uiMultilineEntryOnChanged(IntPtr e, uiMultilineEntryOnChanged_tf f, IntPtr data) => FunctionLoader.Load<uiMultilineEntryOnChanged_t>("uiMultilineEntryOnChanged")(e, f, data);

        [UnmanagedFunctionPointer(Convention)]
        private delegate bool uiMultilineEntryReadOnly_t(IntPtr e);
        public static bool uiMultilineEntryReadOnly(IntPtr e) => FunctionLoader.Load<uiMultilineEntryReadOnly_t>("uiMultilineEntryReadOnly")(e);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiMultilineEntrySetReadOnly_t(IntPtr e, bool @readonly);
        public static void uiMultilineEntrySetReadOnly(IntPtr e, bool @readonly) => FunctionLoader.Load<uiMultilineEntrySetReadOnly_t>("uiMultilineEntrySetReadOnly")(e, @readonly);

        [UnmanagedFunctionPointer(Convention)]
        private delegate IntPtr uiNewMultilineEntry_t();
        public static IntPtr uiNewMultilineEntry() => FunctionLoader.Load<uiNewMultilineEntry_t>("uiNewMultilineEntry")();

        [UnmanagedFunctionPointer(Convention)]
        private delegate IntPtr uiNewNonWrappingMultilineEntry_t();
        public static IntPtr uiNewNonWrappingMultilineEntry() => FunctionLoader.Load<uiNewNonWrappingMultilineEntry_t>("uiNewNonWrappingMultilineEntry")();

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiMenuItemEnable_t(IntPtr m);
        public static void uiMenuItemEnable(IntPtr m) => FunctionLoader.Load<uiMenuItemEnable_t>("uiMenuItemEnable")(m);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiMenuItemDisable_t(IntPtr m);
        public static void uiMenuItemDisable(IntPtr m) => FunctionLoader.Load<uiMenuItemDisable_t>("uiMenuItemDisable")(m);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiMenuItemOnClicked_t(IntPtr m, uiMenuItemOnClicked_tf f, IntPtr data);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void uiMenuItemOnClicked_tf(IntPtr menuItem, IntPtr window, IntPtr data);
        public static void uiMenuItemOnClicked(IntPtr m, uiMenuItemOnClicked_tf f, IntPtr data) => FunctionLoader.Load<uiMenuItemOnClicked_t>("uiMenuItemOnClicked")(m, f, data);

        [UnmanagedFunctionPointer(Convention)]
        private delegate bool uiMenuItemChecked_t(IntPtr m);
        public static bool uiMenuItemChecked(IntPtr m) => FunctionLoader.Load<uiMenuItemChecked_t>("uiMenuItemChecked")(m);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiMenuItemSetChecked_t(IntPtr m, bool @checked);
        public static void uiMenuItemSetChecked(IntPtr m, bool @checked) => FunctionLoader.Load<uiMenuItemSetChecked_t>("uiMenuItemSetChecked")(m, @checked);

        [UnmanagedFunctionPointer(Convention)]
        private delegate IntPtr uiMenuAppendItem_t(IntPtr m, IntPtr name);
        public static IntPtr uiMenuAppendItem(IntPtr m, IntPtr name) => FunctionLoader.Load<uiMenuAppendItem_t>("uiMenuAppendItem")(m, name);

        [UnmanagedFunctionPointer(Convention)]
        private delegate IntPtr uiMenuAppendCheckItem_t(IntPtr m, IntPtr name);
        public static IntPtr uiMenuAppendCheckItem(IntPtr m, IntPtr name) => FunctionLoader.Load<uiMenuAppendCheckItem_t>("uiMenuAppendCheckItem")(m, name);

        [UnmanagedFunctionPointer(Convention)]
        private delegate IntPtr uiMenuAppendQuitItem_t(IntPtr m);
        public static IntPtr uiMenuAppendQuitItem(IntPtr m) => FunctionLoader.Load<uiMenuAppendQuitItem_t>("uiMenuAppendQuitItem")(m);

        [UnmanagedFunctionPointer(Convention)]
        private delegate IntPtr uiMenuAppendPreferencesItem_t(IntPtr m);
        public static IntPtr uiMenuAppendPreferencesItem(IntPtr m) => FunctionLoader.Load<uiMenuAppendPreferencesItem_t>("uiMenuAppendPreferencesItem")(m);

        [UnmanagedFunctionPointer(Convention)]
        private delegate IntPtr uiMenuAppendAboutItem_t(IntPtr m);
        public static IntPtr uiMenuAppendAboutItem(IntPtr m) => FunctionLoader.Load<uiMenuAppendAboutItem_t>("uiMenuAppendAboutItem")(m);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiMenuAppendSeparator_t(IntPtr m);
        public static void uiMenuAppendSeparator(IntPtr m) => FunctionLoader.Load<uiMenuAppendSeparator_t>("uiMenuAppendSeparator")(m);

        [UnmanagedFunctionPointer(Convention)]
        private delegate IntPtr uiNewMenu_t(IntPtr name);
        public static IntPtr uiNewMenu(IntPtr name) => FunctionLoader.Load<uiNewMenu_t>("uiNewMenu")(name);

        [UnmanagedFunctionPointer(Convention)]
        private delegate IntPtr uiOpenFile_t(IntPtr parent);
        public static IntPtr uiOpenFile(IntPtr parent) => FunctionLoader.Load<uiOpenFile_t>("uiOpenFile")(parent);

        [UnmanagedFunctionPointer(Convention)]
        private delegate IntPtr uiSaveFile_t(IntPtr parent);
        public static IntPtr uiSaveFile(IntPtr parent) => FunctionLoader.Load<uiSaveFile_t>("uiSaveFile")(parent);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiMsgBox_t(IntPtr parent, IntPtr title, IntPtr description);
        public static void uiMsgBox(IntPtr parent, IntPtr title, IntPtr description) => FunctionLoader.Load<uiMsgBox_t>("uiMsgBox")(parent, title, description);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiMsgBoxError_t(IntPtr parent, IntPtr title, IntPtr description);
        public static void uiMsgBoxError(IntPtr parent, IntPtr title, IntPtr description) => FunctionLoader.Load<uiMsgBoxError_t>("uiMsgBoxError")(parent, title, description);

        [StructLayout(Layout)]
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

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiAreaSetSize_t(IntPtr a, int width, int height);
        public static void uiAreaSetSize(IntPtr a, int width, int height) => FunctionLoader.Load<uiAreaSetSize_t>("uiAreaSetSize")(a, width, height);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiAreaQueueReDrawAll_t(IntPtr a);
        public static void uiAreaQueueReDrawAll(IntPtr a) => FunctionLoader.Load<uiAreaQueueReDrawAll_t>("uiAreaQueueReDrawAll")(a);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiAreaScrollTo_t(IntPtr a, double x, double y, double width, double height);
        public static void uiAreaScrollTo(IntPtr a, double x, double y, double width, double height) => FunctionLoader.Load<uiAreaScrollTo_t>("uiAreaScrollTo")(a, x, y, width, height);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiAreaBeginUserWindowMove_t(IntPtr a);
        public static void uiAreaBeginUserWindowMove(IntPtr a) => FunctionLoader.Load<uiAreaBeginUserWindowMove_t>("uiAreaBeginUserWindowMove")(a);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiAreaBeginUserWindowResize_t(IntPtr a, uiWindowResizeEdge edge);
        public static void uiAreaBeginUserWindowResize(IntPtr a, uiWindowResizeEdge edge) => FunctionLoader.Load<uiAreaBeginUserWindowResize_t>("uiAreaBeginUserWindowResize")(a, edge);

        [UnmanagedFunctionPointer(Convention)]
        private delegate IntPtr uiNewArea_t(uiAreaHandler ah);
        public static IntPtr uiNewArea(uiAreaHandler ah) => FunctionLoader.Load<uiNewArea_t>("uiNewArea")(ah);

        [UnmanagedFunctionPointer(Convention)]
        private delegate IntPtr uiNewScrollingArea_t(uiAreaHandler ah, int width, int height);
        public static IntPtr uiNewScrollingArea(uiAreaHandler ah, int width, int height) => FunctionLoader.Load<uiNewScrollingArea_t>("uiNewScrollingArea")(ah, width, height);

        [StructLayout(Layout)]
        public struct uiAreaDrawParams
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

        [StructLayout(Layout)]
        internal struct uiDrawMatrix
        {
            public double M11;
            public double M12;
            public double M21;
            public double M22;
            public double M31;
            public double M32;
        }

        [StructLayout(Layout)]
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

        [StructLayout(Layout)]
        internal struct uiDrawBrushGradientStop
        {
            public double Pos;
            public double R;
            public double G;
            public double B;
            public double A;
        }

        [StructLayout(Layout)]
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

        [UnmanagedFunctionPointer(Convention)]
        private delegate IntPtr uiDrawNewPath_t(uiDrawFillMode fillMode);
        public static IntPtr uiDrawNewPath(uiDrawFillMode fillMode) => FunctionLoader.Load<uiDrawNewPath_t>("uiDrawNewPath")(fillMode);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiDrawFreePath_t(IntPtr p);
        public static void uiDrawFreePath(IntPtr p) => FunctionLoader.Load<uiDrawFreePath_t>("uiDrawFreePath")(p);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiDrawPathNewFigure_t(IntPtr p, double x, double y);
        public static void uiDrawPathNewFigure(IntPtr p, double x, double y) => FunctionLoader.Load<uiDrawPathNewFigure_t>("uiDrawPathNewFigure")(p, x, y);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiDrawPathNewFigureWithArc_t(IntPtr p, double xCenter, double yCenter, double radius, double startAngle, double sweep, bool negative);
        public static void uiDrawPathNewFigureWithArc(IntPtr p, double xCenter, double yCenter, double radius, double startAngle, double sweep, bool negative) => FunctionLoader.Load<uiDrawPathNewFigureWithArc_t>("uiDrawPathNewFigureWithArc")(p, xCenter, yCenter, radius, startAngle, sweep, negative);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiDrawPathLineTo_t(IntPtr p, double x, double y);
        public static void uiDrawPathLineTo(IntPtr p, double x, double y) => FunctionLoader.Load<uiDrawPathLineTo_t>("uiDrawPathLineTo")(p, x, y);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiDrawPathArcTo_t(IntPtr p, double xCenter, double yCenter, double radius, double startAngle, double sweep, bool negative);
        public static void uiDrawPathArcTo(IntPtr p, double xCenter, double yCenter, double radius, double startAngle, double sweep, bool negative) => FunctionLoader.Load<uiDrawPathArcTo_t>("uiDrawPathArcTo")(p, xCenter, yCenter, radius, startAngle, sweep, negative);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiDrawPathBezierTo_t(IntPtr p, double c1x, double c1y, double c2x, double c2y, double endX, double endY);
        public static void uiDrawPathBezierTo(IntPtr p, double c1x, double c1y, double c2x, double c2y, double endX, double endY) => FunctionLoader.Load<uiDrawPathBezierTo_t>("uiDrawPathBezierTo")(p, c1x, c1y, c2x, c2y, endX, endY);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiDrawPathCloseFigure_t(IntPtr p);
        public static void uiDrawPathCloseFigure(IntPtr p) => FunctionLoader.Load<uiDrawPathCloseFigure_t>("uiDrawPathCloseFigure")(p);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiDrawPathAddRectangle_t(IntPtr p, double x, double y, double width, double height);
        public static void uiDrawPathAddRectangle(IntPtr p, double x, double y, double width, double height) => FunctionLoader.Load<uiDrawPathAddRectangle_t>("uiDrawPathAddRectangle")(p, x, y, width, height);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiDrawPathEnd_t(IntPtr p);
        public static void uiDrawPathEnd(IntPtr p) => FunctionLoader.Load<uiDrawPathEnd_t>("uiDrawPathEnd")(p);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiDrawStroke_t(IntPtr context, IntPtr path, ref uiDrawBrush brush, ref uiDrawStrokeParams strokeParam);
        public static void uiDrawStroke(IntPtr context, IntPtr path, ref uiDrawBrush brush, ref uiDrawStrokeParams strokeParam) => FunctionLoader.Load<uiDrawStroke_t>("uiDrawStroke")(context, path, ref brush, ref strokeParam);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiDrawFill_t(IntPtr context, IntPtr path, ref uiDrawBrush brush);
        public static void uiDrawFill(IntPtr context, IntPtr path, ref uiDrawBrush brush) => FunctionLoader.Load<uiDrawFill_t>("uiDrawFill")(context, path, ref brush);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiDrawMatrixSetIdentity_t(uiDrawMatrix matrix);
        public static void uiDrawMatrixSetIdentity(uiDrawMatrix matrix) => FunctionLoader.Load<uiDrawMatrixSetIdentity_t>("uiDrawMatrixSetIdentity")(matrix);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiDrawMatrixTranslate_t(uiDrawMatrix matrix, double x, double y);
        public static void uiDrawMatrixTranslate(uiDrawMatrix matrix, double x, double y) => FunctionLoader.Load<uiDrawMatrixTranslate_t>("uiDrawMatrixTranslate")(matrix, x, y);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiDrawMatrixScale_t(uiDrawMatrix matrix, double xCenter, double yCenter, double x, double y);
        public static void uiDrawMatrixScale(uiDrawMatrix matrix, double xCenter, double yCenter, double x, double y) => FunctionLoader.Load<uiDrawMatrixScale_t>("uiDrawMatrixScale")(matrix, xCenter, yCenter, x, y);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiDrawMatrixRotate_t(uiDrawMatrix matrix, double x, double y, double amount);
        public static void uiDrawMatrixRotate(uiDrawMatrix matrix, double x, double y, double amount) => FunctionLoader.Load<uiDrawMatrixRotate_t>("uiDrawMatrixRotate")(matrix, x, y, amount);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiDrawMatrixSkew_t(uiDrawMatrix matrix, double x, double y, double xamount, double yamount);
        public static void uiDrawMatrixSkew(uiDrawMatrix matrix, double x, double y, double xamount, double yamount) => FunctionLoader.Load<uiDrawMatrixSkew_t>("uiDrawMatrixSkew")(matrix, x, y, xamount, yamount);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiDrawMatrixMultiply_t(uiDrawMatrix dest, uiDrawMatrix src);
        public static void uiDrawMatrixMultiply(uiDrawMatrix dest, uiDrawMatrix src) => FunctionLoader.Load<uiDrawMatrixMultiply_t>("uiDrawMatrixMultiply")(dest, src);

        [UnmanagedFunctionPointer(Convention)]
        private delegate bool uiDrawMatrixInvertible_t(uiDrawMatrix matrix);
        public static bool uiDrawMatrixInvertible(uiDrawMatrix matrix) => FunctionLoader.Load<uiDrawMatrixInvertible_t>("uiDrawMatrixInvertible")(matrix);

        [UnmanagedFunctionPointer(Convention)]
        private delegate int uiDrawMatrixInvert_t(uiDrawMatrix matrix);
        public static int uiDrawMatrixInvert(uiDrawMatrix matrix) => FunctionLoader.Load<uiDrawMatrixInvert_t>("uiDrawMatrixInvert")(matrix);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiDrawMatrixTransformPoint_t(uiDrawMatrix matrix, out double x, out double y);
        public static void uiDrawMatrixTransformPoint(uiDrawMatrix matrix, out double x, out double y) => FunctionLoader.Load<uiDrawMatrixTransformPoint_t>("uiDrawMatrixTransformPoint")(matrix, out x, out y);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiDrawMatrixTransformSize_t(uiDrawMatrix matrix, out double x, out double y);
        public static void uiDrawMatrixTransformSize(uiDrawMatrix matrix, out double x, out double y) => FunctionLoader.Load<uiDrawMatrixTransformSize_t>("uiDrawMatrixTransformSize")(matrix, out x, out y);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiDrawTransform_t(IntPtr context, uiDrawMatrix matrix);
        public static void uiDrawTransform(IntPtr context, uiDrawMatrix matrix) => FunctionLoader.Load<uiDrawTransform_t>("uiDrawTransform")(context, matrix);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiDrawClip_t(IntPtr context, IntPtr path);
        public static void uiDrawClip(IntPtr context, IntPtr path) => FunctionLoader.Load<uiDrawClip_t>("uiDrawClip")(context, path);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiDrawSave_t(IntPtr context);
        public static void uiDrawSave(IntPtr context) => FunctionLoader.Load<uiDrawSave_t>("uiDrawSave")(context);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiDrawRestore_t(IntPtr context);
        public static void uiDrawRestore(IntPtr context) => FunctionLoader.Load<uiDrawRestore_t>("uiDrawRestore")(context);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiFreeAttribute_t(IntPtr a);
        public static void uiFreeAttribute(IntPtr a) => FunctionLoader.Load<uiFreeAttribute_t>("uiFreeAttribute")(a);

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

        [UnmanagedFunctionPointer(Convention)]
        private delegate uiAttributeType uiAttributeGetType_t(IntPtr a);
        public static uiAttributeType uiAttributeGetType(IntPtr a) => FunctionLoader.Load<uiAttributeGetType_t>("uiAttributeGetType")(a);

        [UnmanagedFunctionPointer(Convention)]
        private delegate IntPtr uiNewFamilyAttribute_t(IntPtr family);
        public static IntPtr uiNewFamilyAttribute(IntPtr family) => FunctionLoader.Load<uiNewFamilyAttribute_t>("uiNewFamilyAttribute")(family);

        [UnmanagedFunctionPointer(Convention)]
        private delegate IntPtr uiAttributeFamily_t(IntPtr a);
        public static IntPtr uiAttributeFamily(IntPtr a) => FunctionLoader.Load<uiAttributeFamily_t>("uiAttributeFamily")(a);

        [UnmanagedFunctionPointer(Convention)]
        private delegate IntPtr uiNewSizeAttribute_t(double size);
        public static IntPtr uiNewSizeAttribute(double size) => FunctionLoader.Load<uiNewSizeAttribute_t>("uiNewSizeAttribute")(size);

        [UnmanagedFunctionPointer(Convention)]
        private delegate double uiAttributeSize_t(IntPtr a);
        public static double uiAttributeSize(IntPtr a) => FunctionLoader.Load<uiAttributeSize_t>("uiAttributeSize")(a);

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

        [UnmanagedFunctionPointer(Convention)]
        private delegate IntPtr uiNewWeightAttribute_t(uiTextWeight weight);
        public static IntPtr uiNewWeightAttribute(uiTextWeight weight) => FunctionLoader.Load<uiNewWeightAttribute_t>("uiNewWeightAttribute")(weight);

        [UnmanagedFunctionPointer(Convention)]
        private delegate uiTextWeight uiAttributeWeight_t(IntPtr a);
        public static uiTextWeight uiAttributeWeight(IntPtr a) => FunctionLoader.Load<uiAttributeWeight_t>("uiAttributeWeight")(a);

        public enum uiTextItalic : uint
        {
            uiTextItalicNormal,
            uiTextItalicOblique,
            uiTextItalicItalic
        }

        [UnmanagedFunctionPointer(Convention)]
        private delegate IntPtr uiNewItalicAttribute_t(uiTextItalic italic);
        public static IntPtr uiNewItalicAttribute(uiTextItalic italic) => FunctionLoader.Load<uiNewItalicAttribute_t>("uiNewItalicAttribute")(italic);

        [UnmanagedFunctionPointer(Convention)]
        private delegate uiTextItalic uiAttributeItalic_t(IntPtr a);
        public static uiTextItalic uiAttributeItalic(IntPtr a) => FunctionLoader.Load<uiAttributeItalic_t>("uiAttributeItalic")(a);

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

        [UnmanagedFunctionPointer(Convention)]
        private delegate IntPtr uiNewStretchAttribute_t(uiTextStretch stretch);
        public static IntPtr uiNewStretchAttribute(uiTextStretch stretch) => FunctionLoader.Load<uiNewStretchAttribute_t>("uiNewStretchAttribute")(stretch);

        [UnmanagedFunctionPointer(Convention)]
        private delegate uiTextStretch uiAttributeStretch_t(IntPtr a);
        public static uiTextStretch uiAttributeStretch(IntPtr a) => FunctionLoader.Load<uiAttributeStretch_t>("uiAttributeStretch")(a);

        [UnmanagedFunctionPointer(Convention)]
        private delegate IntPtr uiNewColorAttribute_t(double r, double g, double b, double a);
        public static IntPtr uiNewColorAttribute(double r, double g, double b, double a) => FunctionLoader.Load<uiNewColorAttribute_t>("uiNewColorAttribute")(r, g, b, a);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiAttributeColor_t(IntPtr a, out double r, out double g, out double b, out double alpha);
        public static void uiAttributeColor(IntPtr a, out double r, out double g, out double b, out double alpha) => FunctionLoader.Load<uiAttributeColor_t>("uiAttributeColor")(a, out r, out g, out b, out alpha);

        [UnmanagedFunctionPointer(Convention)]
        private delegate IntPtr uiNewBackgroundAttribute_t(double r, double g, double b, double a);
        public static IntPtr uiNewBackgroundAttribute(double r, double g, double b, double a) => FunctionLoader.Load<uiNewBackgroundAttribute_t>("uiNewBackgroundAttribute")(r, g, b, a);

        public enum uiUnderline : uint
        {
            uiUnderlineNone,
            uiUnderlineSingle,
            uiUnderlineDouble,
            uiUnderlineSuggestion, // wavy or dotted underlines used for spelling/grammar checkers
        }

        [UnmanagedFunctionPointer(Convention)]
        private delegate IntPtr uiNewUnderlineAttribute_t(uiUnderline u);
        public static IntPtr uiNewUnderlineAttribute(uiUnderline u) => FunctionLoader.Load<uiNewUnderlineAttribute_t>("uiNewUnderlineAttribute")(u);

        [UnmanagedFunctionPointer(Convention)]
        private delegate uiUnderline uiAttributeUnderline_t(IntPtr a);
        public static uiUnderline uiAttributeUnderline(IntPtr a) => FunctionLoader.Load<uiAttributeUnderline_t>("uiAttributeUnderline")(a);

        public enum uiUnderlineColor : uint
        {
            uiUnderlineColorCustom,
            uiUnderlineColorSpelling,
            uiUnderlineColorGrammar,
            uiUnderlineColorAuxiliary, // for instance, the color used by smart replacements on macOS or in Microsoft Office
        }

        [UnmanagedFunctionPointer(Convention)]
        private delegate IntPtr uiNewUnderlineColorAttribute_t(uiUnderlineColor u, double r, double g, double b, double a);
        public static IntPtr uiNewUnderlineColorAttribute(uiUnderlineColor u, double r, double g, double b, double a) => FunctionLoader.Load<uiNewUnderlineColorAttribute_t>("uiNewUnderlineColorAttribute")(u, r, g, b, a);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiAttributeUnderline__t(IntPtr a, out uiUnderlineColor u, out double r, out double g, out double b, out double alpha);
        public static void uiAttributeUnderline(IntPtr a, out uiUnderlineColor u, out double r, out double g, out double b, out double alpha) => FunctionLoader.Load<uiAttributeUnderline__t>("uiAttributeUnderline")(a, out u, out r, out g, out b, out alpha);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uiForEach uiOpenTypeFeaturesForEachFunc(IntPtr otf, byte a, byte b, byte c, byte d, uint value, IntPtr data);

        [UnmanagedFunctionPointer(Convention)]
        private delegate IntPtr uiNewOpenTypeFeatures_t();
        public static IntPtr uiNewOpenTypeFeatures() => FunctionLoader.Load<uiNewOpenTypeFeatures_t>("uiNewOpenTypeFeatures")();

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiFreeOpenTypeFeatures_t(IntPtr otf);
        public static void uiFreeOpenTypeFeatures(IntPtr otf) => FunctionLoader.Load<uiFreeOpenTypeFeatures_t>("uiFreeOpenTypeFeatures")(otf);

        [UnmanagedFunctionPointer(Convention)]
        private delegate IntPtr uiOpenTypeFeaturesClone_t(IntPtr otf);
        public static IntPtr uiOpenTypeFeaturesClone(IntPtr otf) => FunctionLoader.Load<uiOpenTypeFeaturesClone_t>("uiOpenTypeFeaturesClone")(otf);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiOpenTypeFeaturesAdd_t(IntPtr otf, byte a, byte b, byte c, byte d, uint value);
        public static void uiOpenTypeFeaturesAdd(IntPtr otf, byte a, byte b, byte c, byte d, uint value) => FunctionLoader.Load<uiOpenTypeFeaturesAdd_t>("uiOpenTypeFeaturesAdd")(otf, a, b, c, d, value);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiOpenTypeFeaturesRemove_t(IntPtr otf, byte a, byte b, byte c, byte d);
        public static void uiOpenTypeFeaturesRemove(IntPtr otf, byte a, byte b, byte c, byte d) => FunctionLoader.Load<uiOpenTypeFeaturesRemove_t>("uiOpenTypeFeaturesRemove")(otf, a, b, c, d);

        [UnmanagedFunctionPointer(Convention)]
        private delegate int uiOpenTypeFeaturesGet_t(IntPtr otf, byte a, byte b, byte c, byte d, out uint value);
        public static int uiOpenTypeFeaturesGet(IntPtr otf, byte a, byte b, byte c, byte d, out uint value) => FunctionLoader.Load<uiOpenTypeFeaturesGet_t>("uiOpenTypeFeaturesGet")(otf, a, b, c, d, out value);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiOpenTypeFeaturesForEach_t(IntPtr otf, uiOpenTypeFeaturesForEachFunc f, IntPtr data);
        public static void uiOpenTypeFeaturesForEach(IntPtr otf, uiOpenTypeFeaturesForEachFunc f, IntPtr data) => FunctionLoader.Load<uiOpenTypeFeaturesForEach_t>("uiOpenTypeFeaturesForEach")(otf, f, data);

        [UnmanagedFunctionPointer(Convention)]
        private delegate IntPtr uiNewFeaturesAttribute_t(IntPtr otf);
        public static IntPtr uiNewFeaturesAttribute(IntPtr otf) => FunctionLoader.Load<uiNewFeaturesAttribute_t>("uiNewFeaturesAttribute")(otf);

        [UnmanagedFunctionPointer(Convention)]
        private delegate IntPtr uiAttributeFeatures_t(IntPtr a);
        public static IntPtr uiAttributeFeatures(IntPtr a) => FunctionLoader.Load<uiAttributeFeatures_t>("uiAttributeFeatures")(a);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uiForEach uiAttributedStringForEachAttributeFunc(IntPtr s, IntPtr a, UIntPtr start, UIntPtr end, IntPtr data);

        [UnmanagedFunctionPointer(Convention)]
        private delegate IntPtr uiNewAttributedString_t(IntPtr initialString);
        public static IntPtr uiNewAttributedString(IntPtr initialString) => FunctionLoader.Load<uiNewAttributedString_t>("uiNewAttributedString")(initialString);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiFreeAttributedString_t(IntPtr s);
        public static void uiFreeAttributedString(IntPtr s) => FunctionLoader.Load<uiFreeAttributedString_t>("uiFreeAttributedString")(s);

        [UnmanagedFunctionPointer(Convention)]
        private delegate IntPtr uiAttributedStringString_t(IntPtr s);
        public static IntPtr uiAttributedStringString(IntPtr s) => FunctionLoader.Load<uiAttributedStringString_t>("uiAttributedStringString")(s);

        [UnmanagedFunctionPointer(Convention)]
        private delegate UIntPtr uiAttributedStringLen_t(IntPtr s);
        public static UIntPtr uiAttributedStringLen(IntPtr s) => FunctionLoader.Load<uiAttributedStringLen_t>("uiAttributedStringLen")(s);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiAttributedStringAppendUnattributed_t(IntPtr s, IntPtr str);
        public static void uiAttributedStringAppendUnattributed(IntPtr s, IntPtr str) => FunctionLoader.Load<uiAttributedStringAppendUnattributed_t>("uiAttributedStringAppendUnattributed")(s, str);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiAttributedStringInsertAtUnattributed_t(IntPtr s, IntPtr str, UIntPtr at);
        public static void uiAttributedStringInsertAtUnattributed(IntPtr s, IntPtr str, UIntPtr at) => FunctionLoader.Load<uiAttributedStringInsertAtUnattributed_t>("uiAttributedStringInsertAtUnattributed")(s, str, at);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiAttributedStringDelete_t(IntPtr s, UIntPtr start, UIntPtr end);
        public static void uiAttributedStringDelete(IntPtr s, UIntPtr start, UIntPtr end) => FunctionLoader.Load<uiAttributedStringDelete_t>("uiAttributedStringDelete")(s, start, end);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiAttributedStringSetAttribute_t(IntPtr s, IntPtr a, UIntPtr start, UIntPtr end);
        public static void uiAttributedStringSetAttribute(IntPtr s, IntPtr a, UIntPtr start, UIntPtr end) => FunctionLoader.Load<uiAttributedStringSetAttribute_t>("uiAttributedStringSetAttribute")(s, a, start, end);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiAttributedStringForEachAttribute_t(IntPtr s, uiAttributedStringForEachAttributeFunc f, IntPtr data);
        public static void uiAttributedStringForEachAttribute(IntPtr s, uiAttributedStringForEachAttributeFunc f, IntPtr data) => FunctionLoader.Load<uiAttributedStringForEachAttribute_t>("uiAttributedStringForEachAttribute")(s, f, data);

        [UnmanagedFunctionPointer(Convention)]
        private delegate UIntPtr uiAttributedStringNumGraphemes_t(IntPtr s);
        public static UIntPtr uiAttributedStringNumGraphemes(IntPtr s) => FunctionLoader.Load<uiAttributedStringNumGraphemes_t>("uiAttributedStringNumGraphemes")(s);

        [UnmanagedFunctionPointer(Convention)]
        private delegate UIntPtr uiAttributedStringByteIndexToGrapheme_t(IntPtr s, UIntPtr pos);
        public static UIntPtr uiAttributedStringByteIndexToGrapheme(IntPtr s, UIntPtr pos) => FunctionLoader.Load<uiAttributedStringByteIndexToGrapheme_t>("uiAttributedStringByteIndexToGrapheme")(s, pos);

        [UnmanagedFunctionPointer(Convention)]
        private delegate UIntPtr uiAttributedStringGraphemeToByteIndex_t(IntPtr s, UIntPtr pos);
        public static UIntPtr uiAttributedStringGraphemeToByteIndex(IntPtr s, UIntPtr pos) => FunctionLoader.Load<uiAttributedStringGraphemeToByteIndex_t>("uiAttributedStringGraphemeToByteIndex")(s, pos);

        [StructLayout(Layout)]
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

        [StructLayout(Layout)]
        public struct uiDrawTextLayoutParams
        {
            public IntPtr String;
            public uiFontDescriptor DefaultFont;
            public double Width;
            public uiDrawTextAlign Align;
        }

        [UnmanagedFunctionPointer(Convention)]
        private delegate IntPtr uiDrawNewTextLayout_t(uiDrawTextLayoutParams param);
        public static IntPtr uiDrawNewTextLayout(uiDrawTextLayoutParams param) => FunctionLoader.Load<uiDrawNewTextLayout_t>("uiDrawNewTextLayout")(param);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiDrawFreeTextLayout_t(IntPtr tl);
        public static void uiDrawFreeTextLayout(IntPtr tl) => FunctionLoader.Load<uiDrawFreeTextLayout_t>("uiDrawFreeTextLayout")(tl);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiDrawText_t(IntPtr c, IntPtr tl, double x, double y);
        public static void uiDrawText(IntPtr c, IntPtr tl, double x, double y) => FunctionLoader.Load<uiDrawText_t>("uiDrawText")(c, tl, x, y);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiDrawTextLayoutExtents_t(IntPtr tl, out double width, out double height);
        public static void uiDrawTextLayoutExtents(IntPtr tl, out double width, out double height) => FunctionLoader.Load<uiDrawTextLayoutExtents_t>("uiDrawTextLayoutExtents")(tl, out width, out height);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiFontButtonFont_t(IntPtr b, out uiFontDescriptor desc);
        public static void uiFontButtonFont(IntPtr b, out uiFontDescriptor desc) => FunctionLoader.Load<uiFontButtonFont_t>("uiFontButtonFont")(b, out desc);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiFontButtonOnChanged_t(IntPtr b, uiFontButtonOnChanged_tf f, IntPtr data);
        [UnmanagedFunctionPointer(Convention)]
        public delegate void uiFontButtonOnChanged_tf(IntPtr b, IntPtr data);
        public static void uiFontButtonOnChanged(IntPtr b, uiFontButtonOnChanged_tf f, IntPtr data) => FunctionLoader.Load<uiFontButtonOnChanged_t>("uiFontButtonOnChanged")(b, f, data);

        [UnmanagedFunctionPointer(Convention)]
        private delegate IntPtr uiNewFontButton_t();
        public static IntPtr uiNewFontButton() => FunctionLoader.Load<uiNewFontButton_t>("uiNewFontButton")();

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiFreeFontButtonFont_t(uiFontDescriptor desc);
        public static void uiFreeFontButtonFont(uiFontDescriptor desc) => FunctionLoader.Load<uiFreeFontButtonFont_t>("uiFreeFontButtonFont")(desc);

        [Flags]
        public enum uiModifiers : uint
        {
            uiModifierCtrl = 1 << 0,
            uiModifierAlt = 1 << 1,
            uiModifierShift = 1 << 2,
            uiModifierSuper = 1 << 3
        }

        [StructLayout(Layout)]
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

            public long Held1To64;
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

        [StructLayout(Layout)]
        internal struct uiAreaKeyEvent
        {
            public byte Key;
            public uiExtKey ExtKey;
            public uiModifiers Modifier;
            public uiModifiers Modifiers;
            public bool Up;
        }

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiColorButtonColor_t(IntPtr b, out double red, out double green, out double blue, out double alpha);
        public static void uiColorButtonColor(IntPtr b, out double red, out double green, out double blue, out double alpha) => FunctionLoader.Load<uiColorButtonColor_t>("uiColorButtonColor")(b, out red, out blue, out green, out alpha);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiColorButtonSetColor_t(IntPtr b, double red, double green, double blue, double alpha);
        public static void uiColorButtonSetColor(IntPtr b, double red, double green, double blue, double alpha) => FunctionLoader.Load<uiColorButtonSetColor_t>("uiColorButtonSetColor")(b, red, blue, green, alpha);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiColorButtonOnChanged_t(IntPtr b, uiColorButtonOnChanged_tf f, IntPtr data);
        [UnmanagedFunctionPointer(Convention)]
        public delegate void uiColorButtonOnChanged_tf(IntPtr b, IntPtr data);
        public static void uiColorButtonOnChanged(IntPtr b, uiColorButtonOnChanged_tf f, IntPtr data) => FunctionLoader.Load<uiColorButtonOnChanged_t>("uiColorButtonOnChanged")(b, f, data);

        [UnmanagedFunctionPointer(Convention)]
        private delegate IntPtr uiNewColorButton_t();
        public static IntPtr uiNewColorButton() => FunctionLoader.Load<uiNewColorButton_t>("uiNewColorButton")();

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiFormAppend_t(IntPtr f, IntPtr label, IntPtr c, bool stretchy);
        public static void uiFormAppend(IntPtr f, IntPtr label, IntPtr c, bool stretchy) => FunctionLoader.Load<uiFormAppend_t>("uiFormAppend")(f, label, c, stretchy);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiFormDelete_t(IntPtr f, int index);
        public static void uiFormDelete(IntPtr f, int index) => FunctionLoader.Load<uiFormDelete_t>("uiFormDelete")(f, index);

        [UnmanagedFunctionPointer(Convention)]
        private delegate bool uiFormPadded_t(IntPtr f);
        public static bool uiFormPadded(IntPtr f) => FunctionLoader.Load<uiFormPadded_t>("uiFormPadded")(f);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiFormSetPadded_t(IntPtr f, bool padded);
        public static void uiFormSetPadded(IntPtr f, bool padded) => FunctionLoader.Load<uiFormSetPadded_t>("uiFormSetPadded")(f, padded);

        [UnmanagedFunctionPointer(Convention)]
        private delegate IntPtr uiNewForm_t();
        public static IntPtr uiNewForm() => FunctionLoader.Load<uiNewForm_t>("uiNewForm")();

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

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiGridAppend_t(IntPtr g, IntPtr c, int left, int top, int xspan, int yspan, int hexpand, uiAlign halign, int vexpand, uiAlign valign);
        public static void uiGridAppend(IntPtr g, IntPtr c, int left, int top, int xspan, int yspan, int hexpand, uiAlign halign, int vexpand, uiAlign valign) => FunctionLoader.Load<uiGridAppend_t>("uiGridAppend")(g, c, left, top, xspan, yspan, hexpand, halign, vexpand, valign);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiGridInsertAt_t(IntPtr g, IntPtr c, IntPtr existing, uiAt at, int xspan, int yspan, int hexpand, uiAlign halign, int vexpand, uiAlign valign);
        public static void uiGridInsertAt(IntPtr g, IntPtr c, IntPtr existing, uiAt at, int xspan, int yspan, int hexpand, uiAlign halign, int vexpand, uiAlign valign) => FunctionLoader.Load<uiGridInsertAt_t>("uiGridInsertAt")(g, c, existing, at, xspan, yspan, hexpand, halign, vexpand, valign);

        [UnmanagedFunctionPointer(Convention)]
        private delegate bool uiGridPadded_t(IntPtr g);
        public static bool uiGridPadded(IntPtr g) => FunctionLoader.Load<uiGridPadded_t>("uiGridPadded")(g);

        [UnmanagedFunctionPointer(Convention)]
        private delegate void uiGridSetPadded_t(IntPtr g, bool padded);
        public static void uiGridSetPadded(IntPtr g, bool padded) => FunctionLoader.Load<uiGridSetPadded_t>("uiGridSetPadded")(g, padded);

        [UnmanagedFunctionPointer(Convention)]
        private delegate IntPtr uiNewGrid_t();
        public static IntPtr uiNewGrid() => FunctionLoader.Load<uiNewGrid_t>("uiNewGrid")();
    }
}