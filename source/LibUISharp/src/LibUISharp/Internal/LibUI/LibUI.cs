using LibUISharp.Drawing;
using System;
using System.Runtime.InteropServices;

namespace LibUISharp.Internal
{
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

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void uiOnClickHandler(IntPtr button, IntPtr data);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void uiOnCheckedChangedHandler(IntPtr checkbox, IntPtr data);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void uiOnTextChangedHandler(IntPtr entry, IntPtr data);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void uiOnValueChangedHandler(IntPtr spinBox, IntPtr data);
        
        public enum uiForEach : uint
        {
            Continue,
            Stop
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct uiInitOptions
        {
            public uiInitOptions(UIntPtr size) => Size = size;
            public UIntPtr Size;
        }
        
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
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

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void uiQueueMainHandler(IntPtr data);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiQueueMain(uiQueueMainHandler f, IntPtr data);
        public static void uiQueueMain(uiQueueMainHandler f) => uiQueueMain(f, IntPtr.Zero);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool uiOnShouldQuitHandler(IntPtr data);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiOnShouldQuit(uiOnShouldQuitHandler f, IntPtr data);
        public static void uiOnShouldQuit(uiOnShouldQuitHandler f) => uiOnShouldQuit(f, IntPtr.Zero);

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiFreeText(IntPtr text);

        #region uiControl
        [DllImport(LibUIRef, CallingConvention = Cdecl, SetLastError = true)]
        public static extern void uiControlDestroy(IntPtr control);
        public static void uiControlDestroy(ControlSafeHandle control) => uiControlDestroy(control.DangerousGetHandle());

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern UIntPtr uiControlHandle(IntPtr control);

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiControlParent(IntPtr control);
        public static ControlSafeHandle uiControlParent(ControlSafeHandle control) => new ControlSafeHandle(uiControlParent(control.DangerousGetHandle()));

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiControlSetParent(IntPtr control, IntPtr parent);
        public static void uiControlSetParent(ControlSafeHandle control, ControlSafeHandle parent) => uiControlSetParent(control.DangerousGetHandle(), parent.DangerousGetHandle());

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern bool uiControlTopLevel(IntPtr control);
        public static bool uiControlTopLevel(ControlSafeHandle control) => uiControlTopLevel(control.DangerousGetHandle());

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern bool uiControlVisible(IntPtr control);
        public static bool uiControlVisible(ControlSafeHandle control) => uiControlVisible(control.DangerousGetHandle());

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiControlShow(IntPtr control);
        public static void uiControlShow(ControlSafeHandle control) => uiControlShow(control.DangerousGetHandle());

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiControlHide(IntPtr control);
        public static void uiControlHide(ControlSafeHandle control) => uiControlHide(control.DangerousGetHandle());

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern bool uiControlEnabled(IntPtr control);
        public static bool uiControlEnabled(ControlSafeHandle control) => uiControlEnabled(control.DangerousGetHandle());

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiControlEnable(IntPtr control);
        public static void uiControlEnable(ControlSafeHandle control) => uiControlEnable(control.DangerousGetHandle());

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiControlDisable(IntPtr control);
        public static void uiControlDisable(ControlSafeHandle control) => uiControlDisable(control.DangerousGetHandle());

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiControlVerifySetParent(IntPtr control, IntPtr parent);
        public static void uiControlVerifySetParent(ControlSafeHandle control, ControlSafeHandle parent) => uiControlVerifySetParent(control.DangerousGetHandle(), parent.DangerousGetHandle());

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern bool uiControlEnabledToUser(IntPtr control);
        public static bool uiControlEnabledToUser(ControlSafeHandle control) => uiControlEnabledToUser(control.DangerousGetHandle());
        #endregion
        #region uiWindow
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiWindowTitle(IntPtr window);
        public static string uiWindowTitle(ControlSafeHandle window) => UTF8Helper.ToUTF8Str(uiWindowTitle(window.DangerousGetHandle()));

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiWindowSetTitle(IntPtr window, IntPtr title);
        public static void uiWindowSetTitle(ControlSafeHandle window, string title)
        {
            IntPtr strPtr = UTF8Helper.ToUTF8Ptr(title);
            uiWindowSetTitle(window.DangerousGetHandle(), strPtr);
            Marshal.FreeHGlobal(strPtr);
        }

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiWindowContentSize(IntPtr window, out int width, out int height);
        public static void uiWindowContentSize(ControlSafeHandle window, out int width, out int height) => uiWindowContentSize(window.DangerousGetHandle(), out width, out height);
        public static Size uiWindowContentSize(ControlSafeHandle window)
        {
            uiWindowContentSize(window, out int w, out int h);
            return new Size(w, h);
        }

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiWindowSetContentSize(IntPtr window, int width, int height);
        public static void uiWindowSetContentSize(ControlSafeHandle window, int width, int height) => uiWindowSetContentSize(window.DangerousGetHandle(), width, height);
        public static void uiWindowSetContentSize(ControlSafeHandle window, Size size) => uiWindowSetContentSize(window, size.Width, size.Height);

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern bool uiWindowFullscreen(IntPtr window);
        public static bool uiWindowFullscreen(ControlSafeHandle window) => uiWindowFullscreen(window.DangerousGetHandle());

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiWindowSetFullscreen(IntPtr window, bool fullscreen);
        public static void uiWindowSetFullscreen(ControlSafeHandle window, bool fullscreen) => uiWindowSetFullscreen(window.DangerousGetHandle(), fullscreen);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void uiOnContentSizeChangedHandler(IntPtr window, IntPtr data);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiWindowOnContentSizeChanged(IntPtr window, uiOnContentSizeChangedHandler f, IntPtr data);
        public static void uiWindowOnContentSizeChanged(ControlSafeHandle window, uiOnContentSizeChangedHandler handler, IntPtr data) => uiWindowOnContentSizeChanged(window.DangerousGetHandle(), handler, data);
        public static void uiWindowOnContentSizeChanged(ControlSafeHandle window, uiOnContentSizeChangedHandler handler) => uiWindowOnContentSizeChanged(window, handler, IntPtr.Zero);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool uiOnClosingHandler(IntPtr window, IntPtr data);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiWindowOnClosing(IntPtr window, uiOnClosingHandler f, IntPtr data);
        public static void uiWindowOnClosing(ControlSafeHandle window, uiOnClosingHandler handler, IntPtr data) => uiWindowOnClosing(window.DangerousGetHandle(), handler, data);
        public static void uiWindowOnClosing(ControlSafeHandle window, uiOnClosingHandler handler) => uiWindowOnClosing(window, handler, IntPtr.Zero);

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern bool uiWindowBorderless(IntPtr window);
        public static bool uiWindowBorderless(ControlSafeHandle window) => uiWindowBorderless(window.DangerousGetHandle());

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiWindowSetBorderless(IntPtr window, bool borderless);
        public static void uiWindowSetBorderless(ControlSafeHandle window, bool borderless) => uiWindowSetBorderless(window.DangerousGetHandle(), borderless);

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiWindowSetChild(IntPtr window, IntPtr child);
        public static void uiWindowSetChild(ControlSafeHandle window, ControlSafeHandle child) => uiWindowSetChild(window.DangerousGetHandle(), child.DangerousGetHandle());

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern bool uiWindowMargined(IntPtr window);
        public static bool uiWindowMargined(ControlSafeHandle window) => uiWindowMargined(window.DangerousGetHandle());

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiWindowSetMargined(IntPtr window, bool margined);
        public static void uiWindowSetMargined(ControlSafeHandle window, bool margined) => uiWindowSetMargined(window.DangerousGetHandle(), margined);

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
        public static extern IntPtr uiButtonText(IntPtr button);
        public static string uiButtonText(ControlSafeHandle button) => UTF8Helper.ToUTF8Str(uiButtonText(button.DangerousGetHandle()));

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiButtonSetText(IntPtr button, IntPtr text);
        public static void uiButtonSetText(ControlSafeHandle button, string text)
        {
            IntPtr strPtr = UTF8Helper.ToUTF8Ptr(text);
            uiButtonSetText(button.DangerousGetHandle(), strPtr);
            Marshal.FreeHGlobal(strPtr);
        }

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiButtonOnClicked(IntPtr button, uiOnClickHandler f, IntPtr data);
        public static void uiButtonOnClick(ControlSafeHandle button, uiOnClickHandler handler, IntPtr data) => uiButtonOnClicked(button.DangerousGetHandle(), handler, data);
        public static void uiButtonOnClick(ControlSafeHandle button, uiOnClickHandler handler) => uiButtonOnClick(button, handler, IntPtr.Zero);

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
        public static extern void uiBoxAppend(IntPtr parent, IntPtr child, bool stretchy);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiBoxDelete(IntPtr parent, int index);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern bool uiBoxPadded(IntPtr box);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiBoxSetPadded(IntPtr box, bool padded);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewHorizontalBox();
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewVerticalBox();
        #endregion
        #region uiCheckbox
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiCheckboxText(IntPtr checkBox);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiCheckboxSetText(IntPtr checkBox, IntPtr text);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiCheckboxOnToggled(IntPtr checkBox, uiOnCheckedChangedHandler f, IntPtr data);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern bool uiCheckboxChecked(IntPtr checkBox);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiCheckboxSetChecked(IntPtr checkBox, bool check);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewCheckbox(IntPtr text);
        #endregion
        #region uiEntry
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiEntryText(IntPtr entry);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiEntrySetText(IntPtr entry, IntPtr text);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiEntryOnChanged(IntPtr entry, uiOnTextChangedHandler f, IntPtr data);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern bool uiEntryReadOnly(IntPtr entry);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiEntrySetReadOnly(IntPtr entry, bool isReadOnly);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewEntry();
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewPasswordEntry();
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewSearchEntry();
        #endregion
        #region uiLabel
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiLabelText(IntPtr label);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiLabelSetText(IntPtr label, IntPtr text);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewLabel(IntPtr text);
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
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiSpinboxSetValue(IntPtr spinBox, int value);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiSpinboxOnChanged(IntPtr spinBox, uiOnValueChangedHandler f, IntPtr data);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewSpinbox(int min, int max);
        #endregion
        #region uiSlider
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern int uiSliderValue(IntPtr slider);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiSliderSetValue(IntPtr slider, int value);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiSliderOnChanged(IntPtr slider, uiOnValueChangedHandler f, IntPtr data);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewSlider(int min, int max);
        #endregion
        #region uiProgressBar
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern int uiProgressBarValue(IntPtr progressBar);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiProgressBarSetValue(IntPtr progressBar, int number);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewProgressBar();
        #endregion
        #region uiHorizontalSeparator/uiVerticalSeparator
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewHorizontalSeparator();
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewVerticalSeparator();
        #endregion
        #region ComboBox
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiComboboxAppend(IntPtr comboBox, IntPtr text);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern int uiComboboxSelected(IntPtr comboBox);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiComboboxSetSelected(IntPtr comboBox, int n);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiComboboxOnSelected(IntPtr comboBox, uiComboboxOnSelectedDelegate comboBoxOnSelected, IntPtr data);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void uiComboboxOnSelectedDelegate(IntPtr comboBox, IntPtr data);
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
        public static extern void uiEditableComboboxOnChanged(IntPtr comboBox, uiEditableComboboxOnChangedDelegate editableComboBoxOnChanged, IntPtr data);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void uiEditableComboboxOnChangedDelegate(IntPtr comboBox, IntPtr data);
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
        public static extern void uiRadioButtonsOnSelected(IntPtr radioButton, uiRadioButtonsOnSelectedDelegate radioButtonOnSelected, IntPtr data);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void uiRadioButtonsOnSelectedDelegate(IntPtr radioButton, IntPtr data);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewRadioButtons();
        #endregion
        #region uiDateTimePicker/uiDatePicker/uiTimePicker
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewDateTimePicker();
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewDatePicker();
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewTimePicker();
        #endregion
        #region uiMultilineEntry
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiMultilineEntryText(IntPtr entry);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiMultilineEntrySetText(IntPtr entry, IntPtr text);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiMultilineEntryAppend(IntPtr entry, IntPtr text);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiMultilineEntryOnChanged(IntPtr entry, uiOnTextChangedHandler f, IntPtr data);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern bool uiMultilineEntryReadOnly(IntPtr entry);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiMultilineEntrySetReadOnly(IntPtr entry, bool isReadOnly);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewMultilineEntry();
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewNonWrappingMultilineEntry();
        #endregion
        #region MenuItem
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiMenuItemEnable(IntPtr menuItem);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiMenuItemDisable(IntPtr menuItem);
        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiMenuItemOnClicked(IntPtr menuItem, uiMenuItemOnClickedDelegate menuItemOnClicked, IntPtr data);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void uiMenuItemOnClickedDelegate(IntPtr menuItem, IntPtr window, IntPtr data);
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
        //TODO: ...
    }
}