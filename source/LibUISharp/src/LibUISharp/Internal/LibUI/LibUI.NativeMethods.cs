using System;
using System.Runtime.InteropServices;

namespace LibUISharp.Internal
{
    internal static partial class LibUI
    {
        private static class NativeMethods
        {
            public const string LibUI = "libui";
            public const CallingConvention Cdecl = CallingConvention.Cdecl;

            #region General
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern IntPtr uiInit(ref InitOptions options);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern void uiUnInit();
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern void uiFreeInitError(IntPtr err);

            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern void uiMain();
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern void uiMainSteps();
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern bool uiMainStep(bool wait);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern void uiQuit();

            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern void uiQueueMain(QueueMainEventHandler f, IntPtr data);

            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern void uiOnShouldQuit(OnExitEventHandler f, IntPtr data);

            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern void uiFreeText(IntPtr text);

            #region Windows-specific Interop
            [DllImport("kernel32.dll", SetLastError = true)]
            public static extern IntPtr GetConsoleWindow();

            [DllImport("user32.dll", SetLastError = true)]
            public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
            #endregion
            #endregion
            #region uiControl
            [DllImport(LibUI, CallingConvention = Cdecl, SetLastError = true)]
            public static extern void uiControlDestroy(IntPtr control);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern UIntPtr uiControlHandle(IntPtr control);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern IntPtr uiControlParent(IntPtr control);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern void uiControlSetParent(IntPtr control, IntPtr parent);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern bool uiControlTopLevel(IntPtr control);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern bool uiControlVisible(IntPtr control);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern void uiControlShow(IntPtr control);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern void uiControlHide(IntPtr control);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern bool uiControlEnabled(IntPtr control);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern void uiControlEnable(IntPtr control);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern void uiControlDisable(IntPtr control);

            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern void uiControlVerifySetParent(IntPtr control, IntPtr parent);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern bool uiControlEnabledToUser(IntPtr control);
            #endregion
            #region uiWindow
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern IntPtr uiWindowTitle(IntPtr window);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern void uiWindowSetTitle(IntPtr window, IntPtr title);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern void uiWindowContentSize(IntPtr window, out int width, out int height);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern void uiWindowSetContentSize(IntPtr window, int width, int height);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern bool uiWindowFullscreen(IntPtr window);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern void uiWindowSetFullscreen(IntPtr window, bool fullscreen);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern void uiWindowOnContentSizeChanged(IntPtr window, OnSizeChangedEventHandler f, IntPtr data);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern void uiWindowOnClosing(IntPtr window, OnClosingEventHandler onClosing, IntPtr data);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern bool uiWindowBorderless(IntPtr window);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern void uiWindowSetBorderless(IntPtr window, bool borderless);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern void uiWindowSetChild(IntPtr window, IntPtr child);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern bool uiWindowMargined(IntPtr window);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern void uiWindowSetMargined(IntPtr window, bool margined);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern IntPtr uiNewWindow(IntPtr title, int width, int height, bool hasMenubar);
            #endregion
            #region uiButton
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern IntPtr uiButtonText(IntPtr button);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern void uiButtonSetText(IntPtr button, IntPtr text);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern void uiButtonOnClicked(IntPtr button, OnClickEventHandler f, IntPtr data);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern IntPtr uiNewButton(IntPtr text);
            #endregion
            #region uiBox/uiHorizontalBox/uiVerticalBox
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern void uiBoxAppend(IntPtr parent, IntPtr child, bool stretchy);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern void uiBoxDelete(IntPtr parent, int index);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern bool uiBoxPadded(IntPtr box);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern void uiBoxSetPadded(IntPtr box, bool padded);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern IntPtr uiNewHorizontalBox();
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern IntPtr uiNewVerticalBox();
            #endregion
            #region uiCheckbox
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern IntPtr uiCheckboxText(IntPtr checkBox);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern void uiCheckboxSetText(IntPtr checkBox, IntPtr text);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern void uiCheckboxOnToggled(IntPtr checkBox, OnCheckedChangedEventHandler f, IntPtr data);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern bool uiCheckboxChecked(IntPtr checkBox);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern void uiCheckboxSetChecked(IntPtr checkBox, bool check);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern IntPtr uiNewCheckbox(IntPtr text);
            #endregion
            #region uiEntry
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern IntPtr uiEntryText(IntPtr entry);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern void uiEntrySetText(IntPtr entry, IntPtr text);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern void uiEntryOnChanged(IntPtr entry, OnTextChangedEventHandler f, IntPtr data);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern bool uiEntryReadOnly(IntPtr entry);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern void uiEntrySetReadOnly(IntPtr entry, bool isReadOnly);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern IntPtr uiNewEntry();
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern IntPtr uiNewPasswordEntry();
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern IntPtr uiNewSearchEntry();
            #endregion
            #region uiLabel
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern IntPtr uiLabelText(IntPtr label);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern void uiLabelSetText(IntPtr label, IntPtr text);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern IntPtr uiNewLabel(IntPtr text);
            #endregion
            #region Tab
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern void uiTabAppend(IntPtr tab, IntPtr name, IntPtr child);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern void uiTabInsertAt(IntPtr tab, IntPtr name, int before, IntPtr child);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern void uiTabDelete(IntPtr tab, int index);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern int uiTabNumPages(IntPtr tab);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern bool uiTabMargined(IntPtr tab, int page);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern void uiTabSetMargined(IntPtr tab, int page, bool margined);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern IntPtr uiNewTab();
            #endregion
            #region Group
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern IntPtr uiGroupTitle(IntPtr group);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern void uiGroupSetTitle(IntPtr group, IntPtr title);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern void uiGroupSetChild(IntPtr group, IntPtr child);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern bool uiGroupMargined(IntPtr group);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern void uiGroupSetMargined(IntPtr group, bool margined);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern IntPtr uiNewGroup(IntPtr title);
            #endregion
            #region uiSpinbox
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern int uiSpinboxValue(IntPtr spinBox);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern void uiSpinboxSetValue(IntPtr spinBox, int value);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern void uiSpinboxOnChanged(IntPtr spinBox, OnValueChangedEventHandler f, IntPtr data);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern IntPtr uiNewSpinbox(int min, int max);
            #endregion
            #region uiSlider
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern int uiSliderValue(IntPtr slider);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern void uiSliderSetValue(IntPtr slider, int value);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern void uiSliderOnChanged(IntPtr slider, OnValueChangedEventHandler f, IntPtr data);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern IntPtr uiNewSlider(int min, int max);
            #endregion
            #region uiProgressBar
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern int uiProgressBarValue(IntPtr progressBar);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern void uiProgressBarSetValue(IntPtr progressBar, int number);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern IntPtr uiNewProgressBar();
            #endregion
            #region uiHorizontalSeparator/uiVerticalSeparator
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern IntPtr uiNewHorizontalSeparator();
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern IntPtr uiNewVerticalSeparator();
            #endregion
            #region ComboBox
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern void uiComboboxAppend(IntPtr comboBox, IntPtr text);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern int uiComboboxSelected(IntPtr comboBox);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern void uiComboboxSetSelected(IntPtr comboBox, int n);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern void uiComboboxOnSelected(IntPtr comboBox, uiComboboxOnSelectedDelegate comboBoxOnSelected, IntPtr data);
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void uiComboboxOnSelectedDelegate(IntPtr comboBox, IntPtr data);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern IntPtr uiNewCombobox();
            #endregion
            #region EditableComboBox
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern void uiEditableComboboxAppend(IntPtr comboBox, IntPtr text);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern IntPtr uiEditableComboboxText(IntPtr comboBox);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern void uiEditableComboboxSetText(IntPtr comboBox, IntPtr text);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern void uiEditableComboboxOnChanged(IntPtr comboBox, uiEditableComboboxOnChangedDelegate editableComboBoxOnChanged, IntPtr data);
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void uiEditableComboboxOnChangedDelegate(IntPtr comboBox, IntPtr data);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern IntPtr uiNewEditableCombobox();
            #endregion
            #region RadioButtons
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern void uiRadioButtonsAppend(IntPtr radioButton, IntPtr text);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern int uiRadioButtonsSelected(IntPtr radioButton);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern void uiRadioButtonsSetSelected(IntPtr radioButton, int index);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern void uiRadioButtonsOnSelected(IntPtr radioButton, uiRadioButtonsOnSelectedDelegate radioButtonOnSelected, IntPtr data);
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void uiRadioButtonsOnSelectedDelegate(IntPtr radioButton, IntPtr data);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern IntPtr uiNewRadioButtons();
            #endregion
            #region uiDateTimePicker/uiDatePicker/uiTimePicker
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern IntPtr uiNewDateTimePicker();
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern IntPtr uiNewDatePicker();
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern IntPtr uiNewTimePicker();
            #endregion
            #region uiMultilineEntry
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern IntPtr uiMultilineEntryText(IntPtr entry);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern void uiMultilineEntrySetText(IntPtr entry, IntPtr text);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern void uiMultilineEntryAppend(IntPtr entry, IntPtr text);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern void uiMultilineEntryOnChanged(IntPtr entry, OnTextChangedEventHandler f, IntPtr data);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern bool uiMultilineEntryReadOnly(IntPtr entry);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern void uiMultilineEntrySetReadOnly(IntPtr entry, bool isReadOnly);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern IntPtr uiNewMultilineEntry();
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern IntPtr uiNewNonWrappingMultilineEntry();
            #endregion
            #region MenuItem
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern void uiMenuItemEnable(IntPtr menuItem);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern void uiMenuItemDisable(IntPtr menuItem);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern void uiMenuItemOnClicked(IntPtr menuItem, uiMenuItemOnClickedDelegate menuItemOnClicked, IntPtr data);
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void uiMenuItemOnClickedDelegate(IntPtr menuItem, IntPtr window, IntPtr data);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern bool uiMenuItemChecked(IntPtr menuItem);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern void uiMenuItemSetChecked(IntPtr menuItem, bool isChecked);
            #endregion
            #region Menu
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern IntPtr uiMenuAppendItem(IntPtr menu, IntPtr name);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern IntPtr uiMenuAppendCheckItem(IntPtr menu, IntPtr name);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern IntPtr uiMenuAppendQuitItem(IntPtr menu);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern IntPtr uiMenuAppendPreferencesItem(IntPtr menu);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern IntPtr uiMenuAppendAboutItem(IntPtr menu);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern void uiMenuAppendSeparator(IntPtr menu);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern IntPtr uiNewMenu(IntPtr name);
            #endregion
            #region uiOpenFile/uiSaveFile/uiMsgBox
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern IntPtr uiOpenFile(IntPtr parent);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern IntPtr uiSaveFile(IntPtr parent);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern void uiMsgBox(IntPtr parent, IntPtr title, IntPtr description);
            [DllImport(LibUI, CallingConvention = Cdecl)]
            public static extern void uiMsgBoxError(IntPtr parent, IntPtr title, IntPtr description);
            #endregion
            #region 
            #endregion
            #region 
            #endregion
            #region 
            #endregion
            #region 
            #endregion
        }
    }
}