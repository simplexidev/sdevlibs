using System;
using System.Runtime.InteropServices;
using LibUISharp.Drawing;
using NativeLibraryLoader;

namespace LibUISharp.Internal
{
    internal static partial class NativeCalls
    {
        private const CallingConvention Cdecl = CallingConvention.Cdecl;

        private static T Call<T>() where T : Delegate
#if !DEBUG_NATIVECALLS
            => Libui.LoadFunction<T>(typeof(T).Name);
#else
        {
            Console.WriteLine($"[NativeCall] Calling native method '{typeof(T).Name}'.");
            return Libui.LoadFunction<T>(typeof(T).Name);
        }
#endif

        private static NativeLibrary Libui
        {
            get
            {
                if (PlatformHelper.IsWinNT) return new NativeLibrary("libui.dll");
                else if (PlatformHelper.IsLinux) return new NativeLibrary("libui.so");
                else if (PlatformHelper.IsMacOS) return new NativeLibrary("libui.dylib");
                else throw new PlatformNotSupportedException();
            }
        }

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate string uiInit(ref StartupOptions options);
        internal static string Init(ref StartupOptions options) => Call<uiInit>()(ref options);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiUnInit();
        internal static void UnInit() => Call<uiUnInit>()();

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiFreeInitError(string err);
        internal static void FreeInitError(string err) => Call<uiFreeInitError>()(err);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiMain();
        internal static void Main() => Call<uiMain>()();

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiMainSteps();
        internal static void MainSteps() => Call<uiMainSteps>()();

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate bool uiMainStep(bool wait);
        internal static bool MainStep(bool wait) => Call<uiMainStep>()(wait);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiQuit();
        internal static void Quit() => Call<uiQuit>()();

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiQueueMain([MarshalAs(UnmanagedType.FunctionPtr)] Action<IntPtr> f, IntPtr data);
        internal static void QueueMain([MarshalAs(UnmanagedType.FunctionPtr)] Action<IntPtr> f, IntPtr data) => Call<uiQueueMain>()(f, data);

        //TODO: Implement this.
        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiTimer(int milliseconds, [MarshalAs(UnmanagedType.FunctionPtr)] Func<IntPtr, bool> f, IntPtr data);
        internal static void Timer(int milliseconds, [MarshalAs(UnmanagedType.FunctionPtr)] Func<IntPtr, bool> f, IntPtr data) => Call<uiTimer>()(milliseconds, f, data);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiOnShouldQuit([MarshalAs(UnmanagedType.FunctionPtr)] Func<bool, bool> f, IntPtr data);
        internal static void OnShouldQuit([MarshalAs(UnmanagedType.FunctionPtr)] Func<bool, bool> f, IntPtr data) => Call<uiOnShouldQuit>()(f, data);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiFreeText(string text);
        internal static void FreeText(string text) => Call<uiFreeText>()(text);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiControlDestroy(IntPtr c);
        internal static void ControlDestroy(IntPtr c) => Call<uiControlDestroy>()(c);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate UIntPtr uiControlHandle(IntPtr c);
        internal static UIntPtr ControlHandle(IntPtr c) => Call<uiControlHandle>()(c);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate IntPtr uiControlParent(IntPtr c);
        internal static IntPtr ControlParent(IntPtr c) => Call<uiControlParent>()(c);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiControlSetParent(IntPtr c, IntPtr parent);
        internal static void ControlSetParent(IntPtr c, IntPtr parent) => Call<uiControlSetParent>()(c, parent);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate bool uiControlToplevel(IntPtr c);
        internal static bool ControlTopLevel(IntPtr c) => Call<uiControlToplevel>()(c);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate bool uiControlVisible(IntPtr c);
        internal static bool ControlVisible(IntPtr c) => Call<uiControlVisible>()(c);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiControlShow(IntPtr c);
        internal static void ControlShow(IntPtr c) => Call<uiControlShow>()(c);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiControlHide(IntPtr c);
        internal static void ControlHide(IntPtr c) => Call<uiControlHide>()(c);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate bool uiControlEnabled(IntPtr c);
        internal static bool ControlEnabled(IntPtr c) => Call<uiControlEnabled>()(c);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiControlEnable(IntPtr c);
        internal static void ControlEnable(IntPtr c) => Call<uiControlEnable>()(c);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiControlDisable(IntPtr c);
        internal static void ControlDisable(IntPtr c) => Call<uiControlDisable>()(c);

        //TODO: Implement this.
        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiControlVerifySetParent(IntPtr c, IntPtr parent);
        internal static void ControlVerifySetParent(IntPtr c, IntPtr parent) => Call<uiControlVerifySetParent>()(c, parent);

        //TODO: Implement this.
        [UnmanagedFunctionPointer(Cdecl)]
        private delegate bool uiControlEnabledToUser(IntPtr c);
        internal static bool ControlEnabledToUser(IntPtr c) => Call<uiControlEnabledToUser>()(c);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate string uiWindowTitle(IntPtr w);
        internal static string WindowTitle(IntPtr w) => Call<uiWindowTitle>()(w);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiWindowSetTitle(IntPtr w, string title);
        internal static void WindowSetTitle(IntPtr w, string title) => Call<uiWindowSetTitle>()(w, title);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiWindowContentSize(IntPtr w, out int width, out int height);
        internal static void WindowContentSize(IntPtr w, out int width, out int height) => Call<uiWindowContentSize>()(w, out width, out height);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiWindowSetContentSize(IntPtr w, int width, int height);
        internal static void WindowSetContentSize(IntPtr w, int width, int height) => Call<uiWindowSetContentSize>()(w, width, height);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate bool uiWindowFullscreen(IntPtr w);
        internal static bool WindowFullscreen(IntPtr w) => Call<uiWindowFullscreen>()(w);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiWindowSetFullscreen(IntPtr w, bool fullscreen);
        internal static void WindowSetFullscreen(IntPtr w, bool fullscreen) => Call<uiWindowSetFullscreen>()(w, fullscreen);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiWindowOnContentSizeChanged(IntPtr w, [MarshalAs(UnmanagedType.FunctionPtr)] Action<IntPtr, IntPtr> f, IntPtr data);
        internal static void WindowOnContentSizeChanged(IntPtr w, [MarshalAs(UnmanagedType.FunctionPtr)] Action<IntPtr, IntPtr> f, IntPtr data) => Call<uiWindowOnContentSizeChanged>()(w, f, data);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiWindowOnClosing(IntPtr w, [MarshalAs(UnmanagedType.FunctionPtr)] Func<IntPtr, IntPtr, bool> f, IntPtr data);
        internal static void WindowOnClosing(IntPtr w, [MarshalAs(UnmanagedType.FunctionPtr)] Func<IntPtr, IntPtr, bool> f, IntPtr data) => Call<uiWindowOnClosing>()(w, f, data);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate bool uiWindowBorderless(IntPtr w);
        internal static bool WindowBorderless(IntPtr w) => Call<uiWindowBorderless>()(w);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiWindowSetBorderless(IntPtr w, bool borderless);
        internal static void WindowSetBorderless(IntPtr w, bool borderless) => Call<uiWindowSetBorderless>()(w, borderless);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiWindowSetChild(IntPtr w, IntPtr child);
        internal static void WindowSetChild(IntPtr w, IntPtr child) => Call<uiWindowSetChild>()(w, child);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate bool uiWindowMargined(IntPtr w);
        internal static bool WindowMargined(IntPtr w) => Call<uiWindowMargined>()(w);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiWindowSetMargined(IntPtr w, bool margined);
        internal static void WindowSetMargined(IntPtr w, bool margined) => Call<uiWindowSetMargined>()(w, margined);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate IntPtr uiNewWindow(string title, int width, int height, bool hasMenubar);
        internal static IntPtr NewWindow(string title, int width, int height, bool hasMenubar) => Call<uiNewWindow>()(title, width, height, hasMenubar);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate string uiButtonText(IntPtr b);
        internal static string ButtonText(IntPtr b) => Call<uiButtonText>()(b);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiButtonSetText(IntPtr b, string text);
        internal static void ButtonSetText(IntPtr b, string text) => Call<uiButtonSetText>()(b, text);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiButtonOnClicked(IntPtr b, [MarshalAs(UnmanagedType.FunctionPtr)] Action<IntPtr, IntPtr> f, IntPtr data);
        internal static void ButtonOnClicked(IntPtr b, [MarshalAs(UnmanagedType.FunctionPtr)] Action<IntPtr, IntPtr> f, IntPtr data) => Call<uiButtonOnClicked>()(b, f, data);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate IntPtr uiNewButton(string text);
        internal static IntPtr NewButton(string text) => Call<uiNewButton>()(text);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiBoxAppend(IntPtr b, IntPtr child, bool stretchy);
        internal static void BoxAppend(IntPtr b, IntPtr child, bool stretchy) => Call<uiBoxAppend>()(b, child, stretchy);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiBoxDelete(IntPtr b, int index);
        internal static void BoxDelete(IntPtr b, int index) => Call<uiBoxDelete>()(b, index);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate bool uiBoxPadded(IntPtr b);
        internal static bool BoxPadded(IntPtr b) => Call<uiBoxPadded>()(b);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiBoxSetPadded(IntPtr b, bool padded);
        internal static void BoxSetPadded(IntPtr b, bool padded) => Call<uiBoxSetPadded>()(b, padded);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate IntPtr uiNewHorizontalBox();
        internal static IntPtr NewHorizontalBox() => Call<uiNewHorizontalBox>()();

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate IntPtr uiNewVerticalBox();
        internal static IntPtr NewVerticalBox() => Call<uiNewVerticalBox>()();

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate string uiCheckboxText(IntPtr c);
        internal static string CheckboxText(IntPtr c) => Call<uiCheckboxText>()(c);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiCheckboxSetText(IntPtr c, string text);
        internal static void CheckboxSetText(IntPtr c, string text) => Call<uiCheckboxSetText>()(c, text);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiCheckboxOnToggled(IntPtr c, [MarshalAs(UnmanagedType.FunctionPtr)] Action<IntPtr, IntPtr> f, IntPtr data);
        internal static void CheckboxOnToggled(IntPtr c, [MarshalAs(UnmanagedType.FunctionPtr)] Action<IntPtr, IntPtr> f, IntPtr data) => Call<uiCheckboxOnToggled>()(c, f, data);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate bool uiCheckboxChecked(IntPtr c);
        internal static bool CheckboxChecked(IntPtr c) => Call<uiCheckboxChecked>()(c);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiCheckboxSetChecked(IntPtr c, bool @checked);
        internal static void CheckboxSetChecked(IntPtr c, bool @checked) => Call<uiCheckboxSetChecked>()(c, @checked);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate IntPtr uiNewCheckbox(string text);
        internal static IntPtr NewCheckbox(string text) => Call<uiNewCheckbox>()(text);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate string uiEntryText(IntPtr e);
        internal static string EntryText(IntPtr e) => Call<uiEntryText>()(e);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiEntrySetText(IntPtr e, string text);
        internal static void EntrySetText(IntPtr e, string text) => Call<uiEntrySetText>()(e, text);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiEntryOnChanged(IntPtr e, [MarshalAs(UnmanagedType.FunctionPtr)] Action<IntPtr, IntPtr> f, IntPtr data);
        internal static void EntryOnChanged(IntPtr e, [MarshalAs(UnmanagedType.FunctionPtr)] Action<IntPtr, IntPtr> f, IntPtr data) => Call<uiEntryOnChanged>()(e, f, data);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate bool uiEntryReadOnly(IntPtr e);
        internal static bool EntryReadOnly(IntPtr e) => Call<uiEntryReadOnly>()(e);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiEntrySetReadOnly(IntPtr e, bool @readonly);
        internal static void EntrySetReadOnly(IntPtr e, bool @readonly) => Call<uiEntrySetReadOnly>()(e, @readonly);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate IntPtr uiNewEntry();
        internal static IntPtr NewEntry() => Call<uiNewEntry>()();

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate IntPtr uiNewPasswordEntry();
        internal static IntPtr NewPasswordEntry() => Call<uiNewPasswordEntry>()();

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate IntPtr uiNewSearchEntry();
        internal static IntPtr NewSearchEntry() => Call<uiNewSearchEntry>()();

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate string uiLabelText(IntPtr l);
        internal static string LabelText(IntPtr l) => Call<uiLabelText>()(l);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiLabelSetText(IntPtr l, string text);
        internal static void LabelSetText(IntPtr l, string text) => Call<uiLabelSetText>()(l, text);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate IntPtr uiNewLabel(string text);
        internal static IntPtr NewLabel(string text) => Call<uiNewLabel>()(text);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiTabAppend(IntPtr t, string name, IntPtr c);
        internal static void TabAppend(IntPtr t, string name, IntPtr c) => Call<uiTabAppend>()(t, name, c);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiTabInsertAt(IntPtr t, string name, int before, IntPtr c);
        internal static void TabInsertAt(IntPtr t, string name, int before, IntPtr c) => Call<uiTabInsertAt>()(t, name, before, c);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiTabDelete(IntPtr t, int index);
        internal static void TabDelete(IntPtr t, int index) => Call<uiTabDelete>()(t, index);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate int uiTabNumPages(IntPtr t);
        internal static int TabNumPages(IntPtr t) => Call<uiTabNumPages>()(t);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate bool uiTabMargined(IntPtr t, int page);
        internal static bool TabMargined(IntPtr t, int page) => Call<uiTabMargined>()(t, page);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiTabSetMargined(IntPtr t, int page, bool margined);
        internal static void TabSetMargined(IntPtr t, int page, bool margined) => Call<uiTabSetMargined>()(t, page, margined);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate IntPtr uiNewTab();
        internal static IntPtr NewTab() => Call<uiNewTab>()();

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate string uiGroupTitle(IntPtr g);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiGroupSetTitle(IntPtr g, string title);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiGroupSetChild(IntPtr g, IntPtr child);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate bool uiGroupMargined(IntPtr g);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiGroupSetMargined(IntPtr g, bool margined);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate IntPtr uiNewGroup(string title);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate int uiSpinboxValue(IntPtr s);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiSpinboxSetValue(IntPtr s, int value);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiSpinboxOnChanged(IntPtr s, uiSpinboxOnChangedEvent f, IntPtr data);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate IntPtr uiNewSpinbox(int min, int max);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate int uiSliderValue(IntPtr s);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiSliderSetValue(IntPtr s, int value);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiSliderOnChanged(IntPtr s, uiSliderOnChangedEvent f, IntPtr data);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate IntPtr uiNewSlider(int min, int max);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate int uiProgressBarValue(IntPtr p);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiProgressBarSetValue(IntPtr p, int n);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate IntPtr uiNewProgressBar();

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate IntPtr uiNewHorizontalSeparator();

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate IntPtr uiNewVerticalSeparator();

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiComboboxAppend(IntPtr c, string text);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate int uiComboboxSelected(IntPtr c);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiComboboxSetSelected(IntPtr c, int n);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiComboboxOnSelected(IntPtr c, uiComboboxOnSelectedEvent f, IntPtr data);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate IntPtr uiNewCombobox();

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiEditableComboboxAppend(IntPtr c, string text);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate string uiEditableComboboxText(IntPtr c);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiEditableComboboxSetText(IntPtr c, string text);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiEditableComboboxOnChanged(IntPtr c, uiEditableComboboxOnChangedEvent f, IntPtr data);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate IntPtr uiNewEditableCombobox();

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiRadioButtonsAppend(IntPtr r, string text);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate int uiRadioButtonsSelected(IntPtr r);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiRadioButtonsSetSelected(IntPtr r, int n);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiRadioButtonsOnSelected(IntPtr r, uiRadioButtonsOnSelectedEvent f, IntPtr data);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate IntPtr uiNewRadioButtons();

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiDateTimePickerTime(IntPtr d, out UIDateTime time);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiDateTimePickerSetTime(IntPtr d, UIDateTime time);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiDateTimePickerOnChanged(IntPtr d, uiDateTimePickerOnChangedEvent f, IntPtr data);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate IntPtr uiNewDateTimePicker();

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate IntPtr uiNewDatePicker();

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate IntPtr uiNewTimePicker();

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate string uiMultilineEntryText(IntPtr e);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiMultilineEntrySetText(IntPtr e, string text);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiMultilineEntryAppend(IntPtr e, string text);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiMultilineEntryOnChanged(IntPtr e, uiMultilineEntryOnChangedEvent f, IntPtr data);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate bool uiMultilineEntryReadOnly(IntPtr e);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiMultilineEntrySetReadOnly(IntPtr e, bool @readonly);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate IntPtr uiNewMultilineEntry();

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate IntPtr uiNewNonWrappingMultilineEntry();

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiMenuItemEnable(IntPtr m);
        internal static void MenuItemEnable(IntPtr m) => Call<uiMenuItemEnable>()(m);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiMenuItemDisable(IntPtr m);
        internal static void MenuItemDisable(IntPtr m) => Call<uiMenuItemDisable>()(m);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiMenuItemOnClicked(IntPtr m, Action<IntPtr, IntPtr, IntPtr> f, IntPtr data);
        internal static void MenuItemOnClicked(IntPtr m, Action<IntPtr, IntPtr, IntPtr> f, IntPtr data) => Call<uiMenuItemOnClicked>()(m, f, data);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate bool uiMenuItemChecked(IntPtr m);
        internal static bool MenuItemChecked(IntPtr m) => Call<uiMenuItemChecked>()(m);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiMenuItemSetChecked(IntPtr m, bool @checked);
        internal static void MenuItemSetChecked(IntPtr m, bool @checked) => Call<uiMenuItemSetChecked>()(m, @checked);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate IntPtr uiMenuAppendItem(IntPtr m, string name);
        internal static IntPtr MenuAppendItem(IntPtr m, string name) => Call<uiMenuAppendItem>()(m, name);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate IntPtr uiMenuAppendCheckItem(IntPtr m, string name);
        internal static IntPtr MenuAppendCheckItem(IntPtr m, string name) => Call<uiMenuAppendCheckItem>()(m, name);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate IntPtr uiMenuAppendQuitItem(IntPtr m);
        internal static IntPtr MenuAppendQuitItem(IntPtr m) => Call<uiMenuAppendQuitItem>()(m);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate IntPtr uiMenuAppendPreferencesItem(IntPtr m);
        internal static IntPtr MenuAppendPreferencesItem(IntPtr m) => Call<uiMenuAppendPreferencesItem>()(m);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate IntPtr uiMenuAppendAboutItem(IntPtr m);
        internal static IntPtr MenuAppendAboutItem(IntPtr m) => Call<uiMenuAppendAboutItem>()(m);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiMenuAppendSeparator(IntPtr m);
        internal static void MenuAppendSeparator(IntPtr m) => Call<uiMenuAppendSeparator>()(m);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate IntPtr uiNewMenu(string name);
        internal static IntPtr NewMenu(string name) => Call<uiNewMenu>()(name);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate string uiOpenFile(IntPtr parent);
        internal static string OpenFile(IntPtr parent) => Call<uiOpenFile>()(parent);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate string uiSaveFile(IntPtr parent);
        internal static string SaveFile(IntPtr parent) => Call<uiSaveFile>()(parent);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiMsgBox(IntPtr parent, string title, string description);
        internal static void MsgBox(IntPtr parent, string title, string description) => Call<uiMsgBox>()(parent, title, description);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiMsgBoxError(IntPtr parent, string title, string description);
        internal static void MsgBoxError(IntPtr parent, string title, string description) => Call<uiMsgBoxError>()(parent, title, description);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiAreaSetSize(IntPtr a, int width, int height);
        internal static void AreaSetSize(IntPtr a, int width, int height) => Call<uiAreaSetSize>()(a, width, height);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiAreaQueueRedrawAll(IntPtr a);
        internal static void AreaQueueRedrawAll(IntPtr a) => Call<uiAreaQueueRedrawAll>()(a);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiAreaScrollTo(IntPtr a, double x, double y, double width, double height);
        internal static void AreaScrollTo(IntPtr a, double x, double y, double width, double height) => Call<uiAreaScrollTo>()(a, x, y, width, height);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiAreaBeginUserWindowMove(IntPtr a);
        internal static void AreaBeginUserWindowMove(IntPtr a) => Call<uiAreaBeginUserWindowMove>()(a);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiAreaBeginUserWindowResize(IntPtr a, WindowEdge edge);
        internal static void AreaBeginUserWindowResize(IntPtr a, WindowEdge edge) => Call<uiAreaBeginUserWindowResize>()(a, edge);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate IntPtr uiNewArea(NativeSurfaceHandler ah);
        internal static IntPtr NewArea(NativeSurfaceHandler ah) => Call<uiNewArea>()(ah);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate IntPtr uiNewScrollingArea(NativeSurfaceHandler ah, int width, int height);
        internal static IntPtr NewScrollingArea(NativeSurfaceHandler ah, int width, int height) => Call<uiNewScrollingArea>()(ah, width, height);

        // =========================================================================
        // ======= IMPLEMENTATIONS AND INTERNAL CALLS BELOW ARE NOT FINISHED =======
        // =========================================================================

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate IntPtr uiDrawNewPath(FillMode fillMode);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiDrawFreePath(IntPtr p);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiDrawPathNewFigure(IntPtr p, double x, double y);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiDrawPathNewFigureWithArc(IntPtr p, double xCenter, double yCenter, double radius, double startAngle, double sweep, bool negative);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiDrawPathLineTo(IntPtr p, double x, double y);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiDrawPathArcTo(IntPtr p, double xCenter, double yCenter, double radius, double startAngle, double sweep, bool negative);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiDrawPathBezierTo(IntPtr p, double c1x, double c1y, double c2x, double c2y, double endX, double endY);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiDrawPathCloseFigure(IntPtr p);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiDrawPathAddRectangle(IntPtr p, double x, double y, double width, double height);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiDrawPathEnd(IntPtr p);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiDrawStroke(IntPtr context, IntPtr path, ref Brush brush, ref StrokeOptions strokeParam);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiDrawFill(IntPtr context, IntPtr path, ref Brush brush);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiDrawMatrixSetIdentity(Matrix matrix);
        internal static void DrawMatrixSetIdentity(Matrix matrix) => Call<uiDrawMatrixSetIdentity>()(matrix);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiDrawMatrixTranslate(Matrix matrix, double x, double y);
        internal static void DrawMatrixTranslate(Matrix matrix, double x, double y) => Call<uiDrawMatrixTranslate>()(matrix, x, y);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiDrawMatrixScale(Matrix matrix, double xCenter, double yCenter, double x, double y);
        internal static void DrawMatrixScale(Matrix matrix, double xCenter, double yCenter, double x, double y) => Call<uiDrawMatrixScale>()(matrix, xCenter, yCenter, x, y);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiDrawMatrixRotate(Matrix matrix, double x, double y, double amount);
        internal static void DrawMatrixRotate(Matrix matrix, double x, double y, double amount) => Call<uiDrawMatrixRotate>()(matrix, x, y, amount);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiDrawMatrixSkew(Matrix matrix, double x, double y, double xamount, double yamount);
        internal static void DrawMatrixSkew(Matrix matrix, double x, double y, double xamount, double yamount) => Call<uiDrawMatrixSkew>()(matrix, x, y, xamount, yamount);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiDrawMatrixMultiply(Matrix dest, Matrix src);
        internal static void DrawMatrixMultiply(Matrix dest, Matrix src) => Call<uiDrawMatrixMultiply>()(dest, src);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate bool uiDrawMatrixInvertible(Matrix matrix);
        internal static bool DrawMatrixInvertible(Matrix matrix) => Call<uiDrawMatrixInvertible>()(matrix);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate int uiDrawMatrixInvert(Matrix matrix);
        internal static int DrawMatrixInvert(Matrix matrix) => Call<uiDrawMatrixInvert>()(matrix);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiDrawMatrixTransformPoint(Matrix matrix, out double x, out double y);
        internal static void DrawMatrixTransformPoint(Matrix matrix, out double x, out double y) => Call<uiDrawMatrixTransformPoint>()(matrix, out x, out y);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiDrawMatrixTransformSize(Matrix matrix, out double x, out double y);
        internal static void DrawMatrixTransformSize(Matrix matrix, out double x, out double y) => Call<uiDrawMatrixTransformSize>()(matrix, out x, out y);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiDrawTransform(IntPtr context, Matrix matrix);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiDrawClip(IntPtr context, IntPtr path);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiDrawSave(IntPtr context);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiDrawRestore(IntPtr context);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiFreeAttribute(IntPtr a);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate uiAttributeType uiAttributeGetType(IntPtr a);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate IntPtr uiNewFamilyAttribute(string family);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate string uiAttributeFamily(IntPtr a);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate IntPtr uiNewSizeAttribute(double size);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate double uiAttributeSize(IntPtr a);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate IntPtr uiNewWeightAttribute(FontWeight weight);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate FontWeight uiAttributeWeight(IntPtr a);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate IntPtr uiNewItalicAttribute(FontStyle italic);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate FontStyle uiAttributeItalic(IntPtr a);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate IntPtr uiNewStretchAttribute(FontStretch stretch);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate FontStretch uiAttributeStretch(IntPtr a);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate IntPtr uiNewColorAttribute(double r, double g, double b, double a);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiAttributeColor(IntPtr a, out double r, out double g, out double b, out double alpha);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate IntPtr uiNewBackgroundAttribute(double r, double g, double b, double a);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate IntPtr uiNewUnderlineAttribute(UnderlineStyle u);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate UnderlineStyle uiAttributeUnderline(IntPtr a);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate IntPtr uiNewUnderlineColorAttribute(UnderlineColor u, double r, double g, double b, double a);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiAttributeUnderlineColor(IntPtr a, out UnderlineColor u, out double r, out double g, out double b, out double alpha);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate uiForEach uiOpenTypeFeaturesForEachFunc(IntPtr otf, char a, char b, char c, char d, uint value, IntPtr data);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate IntPtr uiNewOpenTypeFeatures();

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiFreeOpenTypeFeatures(IntPtr otf);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate IntPtr uiOpenTypeFeaturesClone(IntPtr otf);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiOpenTypeFeaturesAdd(IntPtr otf, char a, char b, char c, char d, uint value);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiOpenTypeFeaturesRemove(IntPtr otf, char a, char b, char c, char d);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate int uiOpenTypeFeaturesGet(IntPtr otf, char a, char b, char c, char d, out uint value);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiOpenTypeFeaturesForEach(IntPtr otf, uiOpenTypeFeaturesForEachFunc f, IntPtr data);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate IntPtr uiNewFeaturesAttribute(IntPtr otf);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate IntPtr uiAttributeFeatures(IntPtr a);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate uiForEach uiAttributedStringForEachAttributeFunc(IntPtr s, IntPtr a, UIntPtr start, UIntPtr end, IntPtr data);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate IntPtr uiNewAttributedString(string initialString);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiFreeAttributedString(IntPtr s);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate string uiAttributedStringString(IntPtr s);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate UIntPtr uiAttributedStringLen(IntPtr s);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiAttributedStringAppendUnattributed(IntPtr s, IntPtr str);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiAttributedStringInsertAtUnattributed(IntPtr s, IntPtr str, UIntPtr at);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiAttributedStringDelete(IntPtr s, UIntPtr start, UIntPtr end);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiAttributedStringSetAttribute(IntPtr s, IntPtr a, UIntPtr start, UIntPtr end);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiAttributedStringForEachAttribute(IntPtr s, uiAttributedStringForEachAttributeFunc f, IntPtr data);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate UIntPtr uiAttributedStringNumGraphemes(IntPtr s);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate UIntPtr uiAttributedStringByteIndexToGrapheme(IntPtr s, UIntPtr pos);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate UIntPtr uiAttributedStringGraphemeToByteIndex(IntPtr s, UIntPtr pos);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate IntPtr uiDrawNewTextLayout(uiDrawTextLayoutParams param);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiDrawFreeTextLayout(IntPtr tl);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiDrawText(IntPtr c, IntPtr tl, double x, double y);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiDrawTextLayoutExtents(IntPtr tl, out double width, out double height);

        // =========================================================================
        // ======= IMPLEMENTATIONS AND INTERNAL CALLS ABOVE ARE NOT FINISHED =======
        // =========================================================================

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiFontButtonFont(IntPtr b, out Font desc);
        internal static void FontButtonFont(IntPtr b, out Font desc) => Call<uiFontButtonFont>()(b, out desc);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiFontButtonOnChanged(IntPtr b, [MarshalAs(UnmanagedType.FunctionPtr)] Action<IntPtr, IntPtr> f, IntPtr data);
        internal static void FontButtonOnChanged(IntPtr b, [MarshalAs(UnmanagedType.FunctionPtr)] Action<IntPtr, IntPtr> f, IntPtr data) => Call<uiFontButtonOnChanged>()(b, f, data);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate IntPtr uiNewFontButton();
        internal static IntPtr NewFontButton() => Call<uiNewFontButton>()();

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiFreeFontButtonFont(Font desc);
        internal static void FreeFontButtonFont(Font desc) => Call<uiFreeFontButtonFont>()(desc);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiColorButtonColor(IntPtr b, out double red, out double green, out double blue, out double alpha);
        internal static void ColorButtonColor(IntPtr b, out double red, out double green, out double blue, out double alpha) => Call<uiColorButtonColor>()(b, out red, out green, out blue, out alpha);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiColorButtonSetColor(IntPtr b, double red, double green, double blue, double alpha);
        internal static void ColorButtonSetColor(IntPtr b, double red, double green, double blue, double alpha) => Call<uiColorButtonSetColor>()(b, red, green, blue, alpha);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiColorButtonOnChanged(IntPtr b, [MarshalAs(UnmanagedType.FunctionPtr)] Action<IntPtr, IntPtr> f, IntPtr data);
        internal static void ColorButtonOnChanged(IntPtr b, [MarshalAs(UnmanagedType.FunctionPtr)] Action<IntPtr, IntPtr> f, IntPtr data) => Call<uiColorButtonOnChanged>()(b, f, data);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate IntPtr uiNewColorButton();
        internal static IntPtr NewColorButton() => Call<uiNewColorButton>()();

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiFormAppend(IntPtr f, string label, IntPtr c, bool stretchy);
        internal static void FormAppend(IntPtr f, string label, IntPtr c, bool stretchy) => Call<uiFormAppend>()(f, label, c, stretchy);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiFormDelete(IntPtr f, int index);
        internal static void FormDelete(IntPtr f, int index) => Call<uiFormDelete>()(f, index);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate bool uiFormPadded(IntPtr f);
        internal static bool FormPadded(IntPtr f) => Call<uiFormPadded>()(f);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiFormSetPadded(IntPtr f, bool padded);
        internal static void FormSetPadded(IntPtr f, bool padded) => Call<uiFormSetPadded>()(f, padded);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate IntPtr uiNewForm();
        internal static IntPtr NewForm() => Call<uiNewForm>()();

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiGridAppend(IntPtr g, IntPtr c, int left, int top, int xspan, int yspan, int hexpand, NativeAlignment halign, int vexpand, NativeAlignment valign);
        internal static void GridAppend(IntPtr g, IntPtr c, int left, int top, int xspan, int yspan, int hexpand, NativeAlignment halign, int vexpand, NativeAlignment valign) => Call<uiGridAppend>()(g, c, left, top, xspan, yspan, hexpand, halign, vexpand, valign);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiGridInsertAt(IntPtr g, IntPtr c, IntPtr existing, RelativeAlignment at, int xspan, int yspan, int hexpand, NativeAlignment halign, int vexpand, NativeAlignment valign);
        internal static void GridInsertAt(IntPtr g, IntPtr c, IntPtr existing, RelativeAlignment at, int xspan, int yspan, int hexpand, NativeAlignment halign, int vexpand, NativeAlignment valign) => Call<uiGridInsertAt>()(g, c, existing, at, xspan, yspan, hexpand, halign, vexpand, valign);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate bool uiGridPadded(IntPtr g);
        internal static bool GridPadded(IntPtr g) => Call<uiGridPadded>()(g);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate void uiGridSetPadded(IntPtr g, bool padded);
        internal static void GridSetPadded(IntPtr g, bool padded) => Call<uiGridSetPadded>()(g, padded);

        [UnmanagedFunctionPointer(Cdecl)]
        private delegate IntPtr uiNewGrid();
        internal static IntPtr NewGrid() => Call<uiNewGrid>()();
    }
}