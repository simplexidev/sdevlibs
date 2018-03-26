using LibUISharp.Drawing;
using System;
using System.Runtime.InteropServices;

namespace LibUISharp.Internal
{
    //TODO: When ALL of the TODOs below are done, separate the structs, enums, and methods into different files.
    //TODO: uiTab helper methods.
    //TODO: uiGroup helper methods.
    //TODO: uiCombobox helper methods.
    //TODO: uiEditableCombobox helper methods.
    //TODO: uiRadioButtons helper methods.
    //TODO: uiMenuItem helper methods.
    //TODO: uiMenu helper methods.
    internal static partial class LibUI
    {
#if WINDOWS
        private const string LibUIRef = "libui.dll";
#elif LINUX
        private const string LibUIRef = "libui.so";
#elif MACOS
        private const string LibUIRef = "libui.dylib";
#endif
        private const CallingConvention Cdecl = CallingConvention.Cdecl;
        
        #region General
        [DllImport(LibUIRef, CallingConvention = Cdecl, EntryPoint = "uiInit")]
        private static extern IntPtr uiInit_(ref uiInitOptions options);
        public static void uiInit(ref uiInitOptions options)
        {
            IntPtr errPtr = uiInit_(ref options);
            string errStr = UTF8Helper.ToUTF8Str(errPtr);

            if (string.IsNullOrEmpty(errStr))
            {
                Console.WriteLine(errStr);
                uiFreeInitError(errPtr);
                throw new ExternalException(errStr);
            }
        }

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiUnInit();

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        private static extern void uiFreeInitError(IntPtr err);

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiMain();

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiMainSteps();

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern bool uiMainStep(bool wait);

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiQuit();

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiQueueMain(uiQueueMainHandler f, IntPtr data);
        public static void uiQueueMain(uiQueueMainHandler f) => uiQueueMain(f, IntPtr.Zero);

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiOnShouldQuit(uiOnShouldQuitHandler f, IntPtr data);
        public static void uiOnShouldQuit(uiOnShouldQuitHandler f) => uiOnShouldQuit(f, IntPtr.Zero);

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiFreeText(IntPtr text);
        #endregion
        #region uiControl
        [DllImport(LibUIRef, CallingConvention = Cdecl, SetLastError = true)]
        public static extern void uiControlDestroy(IntPtr c);
        public static void uiControlDestroy(ControlSafeHandle c) => uiControlDestroy(c.DangerousGetHandle());

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern UIntPtr uiControlHandle(IntPtr c);

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiControlParent(IntPtr c);
        public static ControlSafeHandle uiControlParent(ControlSafeHandle c) => new ControlSafeHandle(uiControlParent(c.DangerousGetHandle()));

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiControlSetParent(IntPtr c, IntPtr parent);
        public static void uiControlSetParent(ControlSafeHandle c, ControlSafeHandle parent) => uiControlSetParent(c.DangerousGetHandle(), parent.DangerousGetHandle());

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern bool uiControlTopLevel(IntPtr c);
        public static bool uiControlTopLevel(ControlSafeHandle c) => uiControlTopLevel(c.DangerousGetHandle());

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern bool uiControlVisible(IntPtr c);
        public static bool uiControlVisible(ControlSafeHandle c) => uiControlVisible(c.DangerousGetHandle());

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiControlShow(IntPtr c);
        public static void uiControlShow(ControlSafeHandle c) => uiControlShow(c.DangerousGetHandle());

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiControlHide(IntPtr c);
        public static void uiControlHide(ControlSafeHandle c) => uiControlHide(c.DangerousGetHandle());

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern bool uiControlEnabled(IntPtr c);
        public static bool uiControlEnabled(ControlSafeHandle c) => uiControlEnabled(c.DangerousGetHandle());

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiControlEnable(IntPtr c);
        public static void uiControlEnable(ControlSafeHandle c) => uiControlEnable(c.DangerousGetHandle());

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiControlDisable(IntPtr c);
        public static void uiControlDisable(ControlSafeHandle c) => uiControlDisable(c.DangerousGetHandle());

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiControlVerifySetParent(IntPtr c, IntPtr parent);
        public static void uiControlVerifySetParent(ControlSafeHandle c, ControlSafeHandle parent) => uiControlVerifySetParent(c.DangerousGetHandle(), parent.DangerousGetHandle());

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern bool uiControlEnabledToUser(IntPtr c);
        public static bool uiControlEnabledToUser(ControlSafeHandle c) => uiControlEnabledToUser(c.DangerousGetHandle());
        #endregion
        #region uiWindow
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiWindowTitle(IntPtr w);
        public static string uiWindowTitle(ControlSafeHandle w) => UTF8Helper.ToUTF8Str(uiWindowTitle(w.DangerousGetHandle()));

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiWindowSetTitle(IntPtr w, IntPtr title);
        public static void uiWindowSetTitle(ControlSafeHandle w, string title)
        {
            IntPtr strPtr = UTF8Helper.ToUTF8Ptr(title);
            uiWindowSetTitle(w.DangerousGetHandle(), strPtr);
            Marshal.FreeHGlobal(strPtr);
        }

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiWindowContentSize(IntPtr w, out int width, out int height);
        public static void uiWindowContentSize(ControlSafeHandle w, out int width, out int height) => uiWindowContentSize(w.DangerousGetHandle(), out width, out height);
        public static Size uiWindowContentSize(ControlSafeHandle w)
        {
            uiWindowContentSize(w, out int width, out int height);
            return new Size(width, height);
        }

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiWindowSetContentSize(IntPtr w, int width, int height);
        public static void uiWindowSetContentSize(ControlSafeHandle w, int width, int height) => uiWindowSetContentSize(w.DangerousGetHandle(), width, height);
        public static void uiWindowSetContentSize(ControlSafeHandle w, Size size) => uiWindowSetContentSize(w, size.Width, size.Height);

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern bool uiWindowFullscreen(IntPtr w);
        public static bool uiWindowFullscreen(ControlSafeHandle w) => uiWindowFullscreen(w.DangerousGetHandle());

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiWindowSetFullscreen(IntPtr w, bool fullscreen);
        public static void uiWindowSetFullscreen(ControlSafeHandle w, bool fullscreen) => uiWindowSetFullscreen(w.DangerousGetHandle(), fullscreen);

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiWindowOnContentSizeChanged(IntPtr w, uiOnContentSizeChangedHandler f, IntPtr data);
        public static void uiWindowOnContentSizeChanged(ControlSafeHandle w, uiOnContentSizeChangedHandler handler, IntPtr data) => uiWindowOnContentSizeChanged(w.DangerousGetHandle(), handler, data);
        public static void uiWindowOnContentSizeChanged(ControlSafeHandle w, uiOnContentSizeChangedHandler handler) => uiWindowOnContentSizeChanged(w, handler, IntPtr.Zero);

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiWindowOnClosing(IntPtr w, uiOnClosingHandler f, IntPtr data);
        public static void uiWindowOnClosing(ControlSafeHandle w, uiOnClosingHandler handler, IntPtr data) => uiWindowOnClosing(w.DangerousGetHandle(), handler, data);
        public static void uiWindowOnClosing(ControlSafeHandle w, uiOnClosingHandler handler) => uiWindowOnClosing(w, handler, IntPtr.Zero);

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern bool uiWindowBorderless(IntPtr w);
        public static bool uiWindowBorderless(ControlSafeHandle w) => uiWindowBorderless(w.DangerousGetHandle());

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiWindowSetBorderless(IntPtr w, bool borderless);
        public static void uiWindowSetBorderless(ControlSafeHandle w, bool borderless) => uiWindowSetBorderless(w.DangerousGetHandle(), borderless);

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiWindowSetChild(IntPtr w, IntPtr child);
        public static void uiWindowSetChild(ControlSafeHandle w, ControlSafeHandle child) => uiWindowSetChild(w.DangerousGetHandle(), child.DangerousGetHandle());

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern bool uiWindowMargined(IntPtr w);
        public static bool uiWindowMargined(ControlSafeHandle w) => uiWindowMargined(w.DangerousGetHandle());

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiWindowSetMargined(IntPtr w, bool margined);
        public static void uiWindowSetMargined(ControlSafeHandle w, bool margined) => uiWindowSetMargined(w.DangerousGetHandle(), margined);

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewWindow(IntPtr title, int width, int height, bool hasMenubar);
        public static ControlSafeHandle uiNewWindow(string title, int width, int height, bool hasMenuBar)
        {
            IntPtr strPtr = UTF8Helper.ToUTF8Ptr(title);
            ControlSafeHandle safeHandle = new ControlSafeHandle(uiNewWindow(strPtr, width, height, hasMenuBar));
            Marshal.FreeHGlobal(strPtr);
            return safeHandle;
        }
        public static ControlSafeHandle uiNewWindow(string title, Size size, bool hasMenuBar) => uiNewWindow(title, size.Width, size.Height, hasMenuBar);
        #endregion
        #region uiButton
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiButtonText(IntPtr b);
        public static string uiButtonText(ControlSafeHandle b) => UTF8Helper.ToUTF8Str(uiButtonText(b.DangerousGetHandle()));

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiButtonSetText(IntPtr b, IntPtr text);
        public static void uiButtonSetText(ControlSafeHandle b, string text)
        {
            IntPtr strPtr = UTF8Helper.ToUTF8Ptr(text);
            uiButtonSetText(b.DangerousGetHandle(), strPtr);
            Marshal.FreeHGlobal(strPtr);
        }

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiButtonOnClicked(IntPtr b, uiOnClickedHandler f, IntPtr data);
        public static void uiButtonOnClicked(ControlSafeHandle b, uiOnClickedHandler handler, IntPtr data) => uiButtonOnClicked(b.DangerousGetHandle(), handler, data);
        public static void uiButtonOnClicked(ControlSafeHandle b, uiOnClickedHandler handler) => uiButtonOnClicked(b, handler, IntPtr.Zero);

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewButton(IntPtr text);
        public static ControlSafeHandle uiNewButton(string text)
        {
            IntPtr strPtr = UTF8Helper.ToUTF8Ptr(text);
            ControlSafeHandle safeHandle = new ControlSafeHandle(uiNewButton(strPtr));
            Marshal.FreeHGlobal(strPtr);
            return safeHandle;
        }
        #endregion
        #region uiBox/uiHorizontalBox/uiVerticalBox
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiBoxAppend(IntPtr b, IntPtr child, bool stretchy);
        public static void uiBoxAppend(ControlSafeHandle b, ControlSafeHandle child, bool stretchy) => uiBoxAppend(b.DangerousGetHandle(), child.DangerousGetHandle(), stretchy);

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiBoxDelete(IntPtr b, int index);
        public static void uiBoxDelete(ControlSafeHandle b, int index) => uiBoxDelete(b.DangerousGetHandle(), index);

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern bool uiBoxPadded(IntPtr b);
        public static bool uiBoxPadded(ControlSafeHandle b) => uiBoxPadded(b.DangerousGetHandle());

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiBoxSetPadded(IntPtr b, bool padded);
        public static void uiBoxSetPadded(ControlSafeHandle b, bool padded) => uiBoxSetPadded(b.DangerousGetHandle(), padded);

        [DllImport(LibUIRef, CallingConvention = Cdecl, EntryPoint = "uiNewHorizontalBox")]
        public static extern IntPtr uiNewHorizontalBox_();
        public static ControlSafeHandle uiNewHorizontalBox() => new ControlSafeHandle(uiNewHorizontalBox_());

        [DllImport(LibUIRef, CallingConvention = Cdecl, EntryPoint = "uiNewVerticalBox")]
        public static extern IntPtr uiNewVerticalBox_();
        public static ControlSafeHandle uiNewVerticalBox() => new ControlSafeHandle(uiNewVerticalBox_());
        #endregion

        #region uiCheckbox
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiCheckboxText(IntPtr c);
        public static string uiCheckboxText(ControlSafeHandle c) => UTF8Helper.ToUTF8Str(uiCheckboxText(c.DangerousGetHandle()));

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiCheckboxSetText(IntPtr c, IntPtr text);
        public static void uiCheckboxSetText(ControlSafeHandle c, string text)
        {
            IntPtr strPtr = UTF8Helper.ToUTF8Ptr(text);
            uiCheckboxSetText(c.DangerousGetHandle(), strPtr);
            Marshal.FreeHGlobal(strPtr);
        }

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiCheckboxOnToggled(IntPtr c, uiOnToggledHandler f, IntPtr data);
        public static void uiCheckboxOnToggled(ControlSafeHandle c, uiOnToggledHandler handler, IntPtr data) => uiCheckboxOnToggled(c.DangerousGetHandle(), handler, data);
        public static void uiCheckboxOnToggled(ControlSafeHandle c, uiOnToggledHandler handler) => uiCheckboxOnToggled(c, handler, IntPtr.Zero);

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern bool uiCheckboxChecked(IntPtr c);
        public static bool uiCheckboxChecked(ControlSafeHandle c) => uiCheckboxChecked(c.DangerousGetHandle());

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiCheckboxSetChecked(IntPtr c, bool @checked);
        public static void uiCheckboxSetChecked(ControlSafeHandle c, bool @checked) => uiCheckboxSetChecked(c.DangerousGetHandle(), @checked);

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewCheckbox(IntPtr text);
        public static ControlSafeHandle uiNewCheckbox(string text)
        {
            IntPtr strPtr = UTF8Helper.ToUTF8Ptr(text);
            ControlSafeHandle safeHandle = new ControlSafeHandle(uiNewCheckbox(strPtr));
            Marshal.FreeHGlobal(strPtr);
            return safeHandle;
        }
        #endregion
        //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        #region uiEntry
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiEntryText(IntPtr entry);
        public static string uiEntryText(ControlSafeHandle textbox) => UTF8Helper.ToUTF8Str(uiEntryText(textbox.DangerousGetHandle()));

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiEntrySetText(IntPtr entry, IntPtr text);
        public static void uiEntrySetText(ControlSafeHandle textbox, string text)
        {
            IntPtr strPtr = UTF8Helper.ToUTF8Ptr(text);
            uiEntrySetText(textbox.DangerousGetHandle(), strPtr);
            Marshal.FreeHGlobal(strPtr);
        }

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiEntryOnChanged(IntPtr entry, uiOnTextChangedHandler f, IntPtr data);
        public static void uiEntryOnChanged(ControlSafeHandle textbox, uiOnTextChangedHandler handler, IntPtr data) => uiEntryOnChanged(textbox.DangerousGetHandle(), handler, data);
        public static void uiEntryOnChanged(ControlSafeHandle textbox, uiOnTextChangedHandler handler) => uiEntryOnChanged(textbox, handler, IntPtr.Zero);

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern bool uiEntryReadOnly(IntPtr entry);
        public static bool uiEntryReadOnly(ControlSafeHandle textbox) => uiEntryReadOnly(textbox.DangerousGetHandle());

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiEntrySetReadOnly(IntPtr entry, bool isReadOnly);
        public static void uiEntrySetReadOnly(ControlSafeHandle textbox, bool readOnly) => uiEntrySetReadOnly(textbox.DangerousGetHandle(), readOnly);

        [DllImport(LibUIRef, CallingConvention = Cdecl, EntryPoint = "uiNewEntry")]
        public static extern IntPtr uiNewEntry_();
        public static ControlSafeHandle uiNewEntry() => new ControlSafeHandle(uiNewEntry_());

        [DllImport(LibUIRef, CallingConvention = Cdecl, EntryPoint = "uiNewPasswordEntry")]
        public static extern IntPtr uiNewPasswordEntry_();
        public static ControlSafeHandle uiNewPasswordEntry() => new ControlSafeHandle(uiNewPasswordEntry_());

        [DllImport(LibUIRef, CallingConvention = Cdecl, EntryPoint = "uiNewSearchEntry")]
        public static extern IntPtr uiNewSearchEntry_();
        public static ControlSafeHandle uiNewSearchEntry() => new ControlSafeHandle(uiNewSearchEntry_());
        #endregion
        #region uiLabel
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiLabelText(IntPtr label);
        public static string uiLabelText(ControlSafeHandle label) => UTF8Helper.ToUTF8Str(uiLabelText(label.DangerousGetHandle()));

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiLabelSetText(IntPtr label, IntPtr text);
        public static void uiLabelSetText(ControlSafeHandle label, string text)
        {
            IntPtr strPtr = UTF8Helper.ToUTF8Ptr(text);
            uiLabelSetText(label.DangerousGetHandle(), strPtr);
            Marshal.FreeHGlobal(strPtr);
        }

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewLabel(IntPtr text);
        public static ControlSafeHandle uiNewLabel(string text)
        {
            IntPtr strPtr = UTF8Helper.ToUTF8Ptr(text);
            ControlSafeHandle safeHandle = new ControlSafeHandle(uiNewLabel(strPtr));
            Marshal.FreeHGlobal(strPtr);
            return safeHandle;
        }
        #endregion
        #region Tab
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiTabAppend(IntPtr tab, IntPtr name, IntPtr child);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiTabInsertAt(IntPtr tab, IntPtr name, int before, IntPtr child);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiTabDelete(IntPtr tab, int index);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern int uiTabNumPages(IntPtr tab);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern bool uiTabMargined(IntPtr tab, int page);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiTabSetMargined(IntPtr tab, int page, bool margined);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewTab();
        #endregion
        #region Group
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiGroupTitle(IntPtr group);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiGroupSetTitle(IntPtr group, IntPtr title);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiGroupSetChild(IntPtr group, IntPtr child);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern bool uiGroupMargined(IntPtr group);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiGroupSetMargined(IntPtr group, bool margined);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewGroup(IntPtr title);
        #endregion
        #region uiSpinbox
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern int uiSpinboxValue(IntPtr spinBox);
        public static int uiSpinBoxValue(ControlSafeHandle spinbox) => uiSpinboxValue(spinbox.DangerousGetHandle());
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiSpinboxSetValue(IntPtr spinBox, int value);
        public static void uiSpinBoxSetValue(ControlSafeHandle spinbox, int val) => uiSpinboxSetValue(spinbox.DangerousGetHandle(), val);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiSpinboxOnChanged(IntPtr spinBox, uiOnValueChangedHandler f, IntPtr data);
        public static void uiSpinBoxOnChanged(ControlSafeHandle spinbox, uiOnValueChangedHandler handler, IntPtr data) => uiSpinboxOnChanged(spinbox.DangerousGetHandle(), handler, data);
        public static void uiSpinBoxOnChanged(ControlSafeHandle spinbox, uiOnValueChangedHandler handler) => uiSpinBoxOnChanged(spinbox, handler, IntPtr.Zero);
        [DllImport(LibUIRef, CallingConvention = Cdecl, EntryPoint = "uiNewSpinbox")]
        public static extern IntPtr uiNewSpinbox_(int min, int max);
        public static ControlSafeHandle uiNewSpinBox(int min, int max) => new ControlSafeHandle(uiNewSpinbox_(min, max));
        #endregion
        #region uiSlider
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern int uiSliderValue(IntPtr slider);
        public static int uiSliderValue(ControlSafeHandle slider) => uiSliderValue(slider.DangerousGetHandle());
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiSliderSetValue(IntPtr slider, int value);
        public static void uiSliderSetValue(ControlSafeHandle slider, int val) => uiSliderSetValue(slider.DangerousGetHandle(), val);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiSliderOnChanged(IntPtr slider, uiOnValueChangedHandler f, IntPtr data);
        public static void uiSliderOnChanged(ControlSafeHandle slider, uiOnValueChangedHandler handler, IntPtr data) => uiSliderOnChanged(slider.DangerousGetHandle(), handler, data);
        public static void uiSliderOnChanged(ControlSafeHandle slider, uiOnValueChangedHandler handler) => uiSliderOnChanged(slider, handler, IntPtr.Zero);
        [DllImport(LibUIRef, CallingConvention = Cdecl, EntryPoint = "uiNewSlider")]
        public static extern IntPtr uiNewSlider_(int min, int max);
        public static ControlSafeHandle uiNewSlider(int min, int max) => new ControlSafeHandle(uiNewSlider_(min, max));
        #endregion
        #region uiProgressBar
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern int uiProgressBarValue(IntPtr progressBar);
        public static int uiProgressBarValue(ControlSafeHandle progressbar) => uiProgressBarValue(progressbar.DangerousGetHandle());
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiProgressBarSetValue(IntPtr progressBar, int number);
        public static void uiProgressBarSetValue(ControlSafeHandle progressbar, int val) => uiProgressBarSetValue(progressbar.DangerousGetHandle(), val);
        [DllImport(LibUIRef, CallingConvention = Cdecl, EntryPoint = "uiNewProgressBar")]
        public static extern IntPtr uiNewProgressBar_();
        public static ControlSafeHandle uiNewProgressBar() => new ControlSafeHandle(uiNewProgressBar_());
        #endregion
        #region uiHorizontalSeparator/uiVerticalSeparator
        [DllImport(LibUIRef, CallingConvention = Cdecl, EntryPoint = "uiNewHorizontalSeparator")]
        public static extern IntPtr uiNewHorizontalSeparator_();
        public static ControlSafeHandle uiNewHorizontalSeparator() => new ControlSafeHandle(uiNewHorizontalSeparator_());
        [DllImport(LibUIRef, CallingConvention = Cdecl, EntryPoint = "uiNewVerticalSeparator")]
        public static extern IntPtr uiNewVerticalSeparator_();
        public static ControlSafeHandle uiNewVerticalSeparator() => new ControlSafeHandle(uiNewVerticalSeparator_());
        #endregion
        #region ComboBox
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiComboboxAppend(IntPtr comboBox, IntPtr text);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern int uiComboboxSelected(IntPtr comboBox);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiComboboxSetSelected(IntPtr comboBox, int n);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiComboboxOnSelected(IntPtr comboBox, uiOnValueSelectedHandler comboBoxOnSelected, IntPtr data);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewCombobox();
        #endregion
        #region EditableComboBox
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiEditableComboboxAppend(IntPtr comboBox, IntPtr text);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiEditableComboboxText(IntPtr comboBox);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiEditableComboboxSetText(IntPtr comboBox, IntPtr text);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiEditableComboboxOnChanged(IntPtr comboBox, uiOnTextChangedHandler editableComboBoxOnChanged, IntPtr data);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewEditableCombobox();
        #endregion
        #region RadioButtons
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiRadioButtonsAppend(IntPtr radioButton, IntPtr text);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern int uiRadioButtonsSelected(IntPtr radioButton);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiRadioButtonsSetSelected(IntPtr radioButton, int index);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiRadioButtonsOnSelected(IntPtr radioButton, uiOnValueSelectedHandler radioButtonOnSelected, IntPtr data);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewRadioButtons();
        #endregion
        #region uiDateTimePicker/uiDatePicker/uiTimePicker
        [DllImport(LibUIRef, CallingConvention = Cdecl, EntryPoint = "uiNewDateTimePicker")]
        public static extern IntPtr uiNewDateTimePicker_();
        public static ControlSafeHandle uiNewDateTimePicker() => new ControlSafeHandle(uiNewDateTimePicker_());
        [DllImport(LibUIRef, CallingConvention = Cdecl, EntryPoint = "uiNewDatePicker")]
        public static extern IntPtr uiNewDatePicker_();
        public static ControlSafeHandle uiNewDatePicker() => new ControlSafeHandle(uiNewDatePicker_());
        [DllImport(LibUIRef, CallingConvention = Cdecl, EntryPoint = "uiNewTimePicker")]
        public static extern IntPtr uiNewTimePicker_();
        public static ControlSafeHandle uiNewTimePicker() => new ControlSafeHandle(uiNewTimePicker_());
        #endregion
        #region uiMultilineEntry
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiMultilineEntryText(IntPtr entry);
        public static string uiMultilineEntryText(ControlSafeHandle textbox) => UTF8Helper.ToUTF8Str(uiMultilineEntryText(textbox.DangerousGetHandle()));
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiMultilineEntrySetText(IntPtr entry, IntPtr text);
        public static void uiMultilineEntrySetText(ControlSafeHandle textbox, string text)
        {
            IntPtr strPtr = UTF8Helper.ToUTF8Ptr(text);
            uiMultilineEntrySetText(textbox.DangerousGetHandle(), strPtr);
            Marshal.FreeHGlobal(strPtr);
        }
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiMultilineEntryAppend(IntPtr entry, IntPtr text);
        public static void uiMultilineEntryAppend(ControlSafeHandle textbox, params string[] lines)
        {
            foreach (string s in lines)
            {
                IntPtr strPtr = UTF8Helper.ToUTF8Ptr(s);
                uiMultilineEntryAppend(textbox.DangerousGetHandle(), strPtr);
                Marshal.FreeHGlobal(strPtr);
            }
        }
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiMultilineEntryOnChanged(IntPtr entry, uiOnTextChangedHandler f, IntPtr data);
        public static void uiMultilineEntryOnChanged(ControlSafeHandle textbox, uiOnTextChangedHandler handler, IntPtr data) => uiMultilineEntryOnChanged(textbox.DangerousGetHandle(), handler, data);
        public static void uiMultilineEntryOnChanged(ControlSafeHandle textbox, uiOnTextChangedHandler handler) => uiMultilineEntryOnChanged(textbox, handler, IntPtr.Zero);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern bool uiMultilineEntryReadOnly(IntPtr entry);
        public static bool uiMultilineEntryReadOnly(ControlSafeHandle textbox) => uiMultilineEntryReadOnly(textbox.DangerousGetHandle());
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiMultilineEntrySetReadOnly(IntPtr entry, bool isReadOnly);
        public static void uiMultilineEntrySetReadOnly(ControlSafeHandle textbox, bool readOnly) => uiMultilineEntrySetReadOnly(textbox.DangerousGetHandle(), readOnly);
        [DllImport(LibUIRef, CallingConvention = Cdecl, EntryPoint = "uiNewMultilineEntry")]
        public static extern IntPtr uiNewMultilineEntry_();
        public static ControlSafeHandle uiNewMultilineEntry() => new ControlSafeHandle(uiNewMultilineEntry_());
        [DllImport(LibUIRef, CallingConvention = Cdecl, EntryPoint = "uiNewNonWrappingMultilineEntry")]
        public static extern IntPtr uiNewNonWrappingMultilineEntry_();
        public static ControlSafeHandle uiNewNonWrappingMultilineEntry() => new ControlSafeHandle(uiNewNonWrappingMultilineEntry_());
        #endregion
        #region MenuItem
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiMenuItemEnable(IntPtr menuItem);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiMenuItemDisable(IntPtr menuItem);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiMenuItemOnClicked(IntPtr menuItem, uiMenuItemOnClickedHandler menuItemOnClicked, IntPtr data);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern bool uiMenuItemChecked(IntPtr menuItem);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiMenuItemSetChecked(IntPtr menuItem, bool isChecked);
        #endregion
        #region Menu
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiMenuAppendItem(IntPtr menu, IntPtr name);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiMenuAppendCheckItem(IntPtr menu, IntPtr name);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiMenuAppendQuitItem(IntPtr menu);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiMenuAppendPreferencesItem(IntPtr menu);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiMenuAppendAboutItem(IntPtr menu);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiMenuAppendSeparator(IntPtr menu);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewMenu(IntPtr name);
        #endregion
        #region uiOpenFile/uiSaveFile/uiMsgBox
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiOpenFile(IntPtr parent);
        public static string uiOpenFile(ControlSafeHandle parent) => UTF8Helper.ToUTF8Str(uiOpenFile(parent.DangerousGetHandle()));

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiSaveFile(IntPtr parent);
        public static string uiSaveFile(ControlSafeHandle parent) => UTF8Helper.ToUTF8Str(uiSaveFile(parent.DangerousGetHandle()));

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiMsgBox(IntPtr parent, IntPtr title, IntPtr description);
        public static void uiMsgBox(ControlSafeHandle parent, string title, string description, bool error)
        {
            IntPtr titlePtr = UTF8Helper.ToUTF8Ptr(title);
            IntPtr descrPtr = UTF8Helper.ToUTF8Ptr(description);
            if (!error)
                uiMsgBox(parent.DangerousGetHandle(), titlePtr, descrPtr);
            else
                uiMsgBoxError(parent.DangerousGetHandle(), titlePtr, descrPtr);
            Marshal.FreeHGlobal(titlePtr);
            Marshal.FreeHGlobal(descrPtr);
        }

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        private static extern void uiMsgBoxError(IntPtr parent, IntPtr title, IntPtr description);
        #endregion

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiAreaSetSize(IntPtr area, int width, int height);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiAreaQueueReDrawAll(IntPtr area);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiAreaScrollTo(IntPtr area, double x, double y, double width, double height);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiAreaBeginUserWindowMove(IntPtr area);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiAreaBeginUserWindowResize(IntPtr area, uiWindowResizeEdge edge);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewArea(uiAreaHandler ah);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewScrollingArea(uiAreaHandler ah, int width, int height);

        public const double uiDrawDefaultMiterLimit = 10.0;

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiDrawNewPath(uiDrawFillMode fillMode);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiDrawFreePath(IntPtr path);

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiDrawPathNewFigure(IntPtr path, double x, double y);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiDrawPathNewFigureWithArc(IntPtr path, double xCenter, double yCenter, double radius, double startAngle, double sweep, bool negative);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiDrawPathLineTo(IntPtr path, double x, double y);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiDrawPathArcTo(IntPtr path, double xCenter, double yCenter, double radius, double startAngle, double sweep, bool negative);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiDrawPathBezierTo(IntPtr path, double c1x, double c1y, double c2x, double c2y, double endX, double endY);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiDrawPathCloseFigure(IntPtr path);

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiDrawPathAddRectangle(IntPtr path, double x, double y, double width, double height);

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiDrawPathEnd(IntPtr path);

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiDrawStroke(IntPtr context, IntPtr path, ref uiDrawBrush brush, ref uiDrawStrokeParams strokeParam);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiDrawFill(IntPtr context, IntPtr path, ref uiDrawBrush brush);

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiDrawMatrixSetIdentity(uiDrawMatrix matrix);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiDrawMatrixTranslate(uiDrawMatrix matrix, double x, double y);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiDrawMatrixScale(uiDrawMatrix matrix, double xCenter, double yCenter, double x, double y);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiDrawMatrixRotate(uiDrawMatrix matrix, double x, double y, double amount);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiDrawMatrixSkew(uiDrawMatrix matrix, double x, double y, double xamount, double yamount);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiDrawMatrixMultiply(uiDrawMatrix dest, uiDrawMatrix src);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern bool uiDrawMatrixInvertible(uiDrawMatrix matrix);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern int uiDrawMatrixInvert(uiDrawMatrix matrix);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiDrawMatrixTransformPoint(uiDrawMatrix matrix, out double x, out double y);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiDrawMatrixTransformSize(uiDrawMatrix matrix, out double x, out double y);

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiDrawTransform(IntPtr context, uiDrawMatrix matrix);

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiDrawClip(IntPtr context, IntPtr path);

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiDrawSave(IntPtr context);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiDrawRestore(IntPtr context);

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiFreeAttribute(IntPtr a);

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern uiAttributeType uiAttributeGetType(IntPtr a);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewFamilyAttribute(IntPtr family);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiAttributeFamily(IntPtr a);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewSizeAttribute(double size);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern double uiAttributeSize(IntPtr a);

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewWeightAttribute(uiTextWeight weight);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern uiTextWeight uiAttributeWeight(IntPtr a);

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewItalicAttribute(uiTextItalic italic);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern uiTextItalic uiAttributeItalic(IntPtr a);

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewStretchAttribute(uiTextStretch stretch);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern uiTextStretch uiAttributeStretch(IntPtr a);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewColorAttribute(double r, double g, double b, double a);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiAttributeColor(IntPtr a, out double r, out double g, out double b, out double alpha);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewBackgroundAttribute(double r, double g, double b, double a);

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewUnderlineAttribute(uiUnderline u);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern uiUnderline uiAttributeUnderline(IntPtr a);

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewUnderlineColorAttribute(uiUnderlineColor u, double r, double g, double b, double a);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiAttributeUnderline(IntPtr a, out uiUnderlineColor u, out double r, out double g, out double b, out double alpha);

        //TODO: public class uiOpenTypeFeatures

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uiForEach uiOpenTypeFeaturesForEachFunc(IntPtr otf, byte a, byte b, byte c, byte d, uint value, IntPtr data);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewOpenTypeFeatures();
        [DllImport(LibUIRef, CallingConvention = Cdecl,
            SetLastError = true)]
        public static extern void uiFreeOpenTypeFeatures(IntPtr otf);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiOpenTypeFeaturesClone(IntPtr otf);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiOpenTypeFeaturesAdd(IntPtr otf, byte a, byte b, byte c, byte d, uint value);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiOpenTypeFeaturesRemove(IntPtr otf, byte a, byte b, byte c, byte d);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern int uiOpenTypeFeaturesGet(IntPtr otf, byte a, byte b, byte c, byte d, out uint value);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiOpenTypeFeaturesForEach(IntPtr otf, uiOpenTypeFeaturesForEachFunc f, IntPtr data);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewFeaturesAttribute(IntPtr otf);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiAttributeFeatures(IntPtr a);

        //TODO: public class uiAttributedString

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uiForEach uiAttributedStringForEachAttributeFunc(IntPtr s, IntPtr a, UIntPtr start, UIntPtr end, IntPtr data);

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewAttributedString(IntPtr initialString);
        [DllImport(LibUIRef, CallingConvention = Cdecl,
            SetLastError = true)]
        public static extern void uiFreeAttributedString(IntPtr s);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiAttributedStringString(IntPtr s);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern UIntPtr uiAttributedStringLen(IntPtr s);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiAttributedStringAppendUnattributed(IntPtr s, IntPtr str);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiAttributedStringInsertAtUnattributed(IntPtr s, IntPtr str, UIntPtr at);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiAttributedStringDelete(IntPtr s, UIntPtr start, UIntPtr end);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiAttributedStringSetAttribute(IntPtr s, IntPtr a, UIntPtr start, UIntPtr end);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiAttributedStringForEachAttribute(IntPtr s, uiAttributedStringForEachAttributeFunc f, IntPtr data);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern UIntPtr uiAttributedStringNumGraphemes(IntPtr s);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern UIntPtr uiAttributedStringByteIndexToGrapheme(IntPtr s, UIntPtr pos);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern UIntPtr uiAttributedStringGraphemeToByteIndex(IntPtr s, UIntPtr pos);

        //TODO: public class uiFontDescriptor

        //TODO: public class uiDrawTextLayout

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiDrawNewTextLayout(uiDrawTextLayoutParams param);
        [DllImport(LibUIRef, CallingConvention = Cdecl,
            SetLastError = true)]
        public static extern void uiDrawFreeTextLayout(IntPtr tl);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiDrawText(IntPtr c, IntPtr tl, double x, double y);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiDrawTextLayoutExtents(IntPtr tl, out double width, out double height);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern int uiDrawTextLayoutNumLines(IntPtr tl);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void UIDrawTextLayoutLineByteRange(IntPtr tl, int line, out IntPtr start, out IntPtr end);

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiColorButtonColor(IntPtr b, out double red, out double green, out double blue, out double alpha);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiColorButtonSetColor(IntPtr b, double red, double green, double blue, double alpha);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiColorButtonOnChanged(IntPtr b, uiColorButtonOnChangedDelegate colorButtonOnChanged, IntPtr data);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void uiColorButtonOnChangedDelegate(IntPtr b, IntPtr data);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewColorButton();

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiFormAppend(IntPtr form, IntPtr label, IntPtr child, bool stretchy);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiFormDelete(IntPtr form, int index);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern bool uiFormPadded(IntPtr form);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiFormSetPadded(IntPtr form, bool padded);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewForm();

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiGridAppend(IntPtr grid, IntPtr child, int left, int top, int xspan, int yspan, int hexpand, uiAlign halign, int vexpand, uiAlign valign);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiGridInsertAt(IntPtr grid, IntPtr child, IntPtr existing, uiAt at, int xspan, int yspan, int hexpand, uiAlign halign, int vexpand, uiAlign valign);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern bool uiGridPadded(IntPtr grid);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiGridSetPadded(IntPtr grid, bool padded);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewGrid();
    }
}