using System;
using System.Runtime.InteropServices;
using LibUISharp.Controls;
using LibUISharp.Drawing;

namespace LibUISharp.Internal
{
    internal static partial class LibUI
    {
        /* Just use a bool for uiForEach; false (0) = Continue, and true (1) = Stop.
        public enum ForEach : uint
        {
            Continue,
            Stop
        }
        */

        [StructLayout(LayoutKind.Sequential)]
        public struct InitOptions
        {
            public InitOptions(UIntPtr size) => Size = size;

            public UIntPtr Size;
        }

        #region Application
        public static void Initialize(ref InitOptions options)
        {
            IntPtr errPtr = NativeMethods.uiInit(ref options);
            string errStr = UTF8Helper.ToUTF8Str(errPtr);

            if (string.IsNullOrEmpty(errStr))
            {
                Console.WriteLine(errStr);
                NativeMethods.uiFreeInitError(errPtr);
                throw new ExternalException(errStr);
            }
        }
        public static void UnInitialize() => NativeMethods.uiUnInit();

        public static void Main() => NativeMethods.uiMain();
        public static void MainSteps() => NativeMethods.uiMainSteps();
        public static bool MainStep(bool wait) => NativeMethods.uiMainStep(wait);
        public static void Exit() => NativeMethods.uiQuit();

        public static void QueueMain(QueueMainEventHandler handler, IntPtr data) => NativeMethods.uiQueueMain(handler, data);
        public static void QueueMain(QueueMainEventHandler handler) => QueueMain(handler, IntPtr.Zero);

        public static void OnExit(OnExitEventHandler handler, IntPtr data) => NativeMethods.uiOnShouldQuit(handler, data);
        public static void OnExit(OnExitEventHandler handler) => OnExit(handler, IntPtr.Zero);

        private static void FreeText(IntPtr text) => NativeMethods.uiFreeText(text);

        public static void ConsoleWindow(bool visible)
        {
            if (PlatformHelper.IsWindows)
            {
                IntPtr ptr = NativeMethods.GetConsoleWindow();
                if (visible)
                    NativeMethods.ShowWindow(ptr, 4); // 4 = SW_SHOWNOACTIVATE
                else
                    NativeMethods.ShowWindow(ptr, 0); // 0 = SW_HIDE
            }
        }
        #endregion
        #region Control [uiControl]
        public static void ControlDestroy(ControlSafeHandle control) => NativeMethods.uiControlDestroy(control.DangerousGetHandle());
        public static UIntPtr ControlHandle(ControlSafeHandle control) => NativeMethods.uiControlHandle(control.DangerousGetHandle());
        public static ControlSafeHandle ControlGetParent(ControlSafeHandle control) => new ControlSafeHandle(NativeMethods.uiControlParent(control.DangerousGetHandle()));
        public static void ControlSetParent(ControlSafeHandle control, ControlSafeHandle parent) => NativeMethods.uiControlSetParent(control.DangerousGetHandle(), parent.DangerousGetHandle());
        public static bool ControlTopLevel(ControlSafeHandle control) => NativeMethods.uiControlTopLevel(control.DangerousGetHandle());
        public static bool ControlVisible(ControlSafeHandle control) => NativeMethods.uiControlVisible(control.DangerousGetHandle());
        public static void ControlShow(ControlSafeHandle control) => NativeMethods.uiControlShow(control.DangerousGetHandle());
        public static void ControlHide(ControlSafeHandle control) => NativeMethods.uiControlHide(control.DangerousGetHandle());
        public static bool ControlEnabled(ControlSafeHandle control) => NativeMethods.uiControlEnabled(control.DangerousGetHandle());
        public static void ControlEnable(ControlSafeHandle control) => NativeMethods.uiControlEnable(control.DangerousGetHandle());
        public static void ControlDisable(ControlSafeHandle control) => NativeMethods.uiControlDisable(control.DangerousGetHandle());

        public static void ControlVerifySetParent(ControlSafeHandle control, ControlSafeHandle parent) => NativeMethods.uiControlVerifySetParent(control.DangerousGetHandle(), parent.DangerousGetHandle());
        public static bool ControlEnabledToUser(ControlSafeHandle control) => NativeMethods.uiControlEnabledToUser(control.DangerousGetHandle());
        #endregion
        #region Window [uiWindow]
        public static string WindowGetTitle(ControlSafeHandle window) => UTF8Helper.ToUTF8Str(NativeMethods.uiWindowTitle(window.DangerousGetHandle()));
        public static void WindowSetTitle(ControlSafeHandle window, string title)
        {
            IntPtr strPtr = UTF8Helper.ToUTF8Ptr(title);
            NativeMethods.uiWindowSetTitle(window.DangerousGetHandle(), strPtr);
            Marshal.FreeHGlobal(strPtr);
        }
        public static void WindowGetSize(ControlSafeHandle window, out int width, out int height) => NativeMethods.uiWindowContentSize(window.DangerousGetHandle(), out width, out height);
        public static Size WindowGetSize(ControlSafeHandle window)
        {
            WindowGetSize(window, out int w, out int h);
            return new Size(w, h);
        }
        public static void WindowSetSize(ControlSafeHandle window, int width, int height) => NativeMethods.uiWindowSetContentSize(window.DangerousGetHandle(), width, height);
        public static void WindowSetSize(ControlSafeHandle window, Size size) => WindowSetSize(window, size.Width, size.Height);
        public static bool WindowGetFullscreen(ControlSafeHandle window) => NativeMethods.uiWindowFullscreen(window.DangerousGetHandle());
        public static void WindowSetFullscreen(ControlSafeHandle window, bool fullscreen) => NativeMethods.uiWindowSetFullscreen(window.DangerousGetHandle(), fullscreen);
        public static void WindowOnSizeChanged(ControlSafeHandle window, OnSizeChangedEventHandler handler, IntPtr data) => NativeMethods.uiWindowOnContentSizeChanged(window.DangerousGetHandle(), handler, data);
        public static void WindowOnSizeChanged(ControlSafeHandle window, OnSizeChangedEventHandler handler) => WindowOnSizeChanged(window, handler, IntPtr.Zero);
        public static void WindowOnClosing(ControlSafeHandle window, OnClosingEventHandler handler, IntPtr data) => NativeMethods.uiWindowOnClosing(window.DangerousGetHandle(), handler, data);
        public static void WindowOnClosing(ControlSafeHandle window, OnClosingEventHandler handler) => WindowOnClosing(window, handler, IntPtr.Zero);
        public static bool WindowGetBorderless(ControlSafeHandle window) => NativeMethods.uiWindowBorderless(window.DangerousGetHandle());
        public static void WindowSetBorderless(ControlSafeHandle window, bool borderless) => NativeMethods.uiWindowSetBorderless(window.DangerousGetHandle(), borderless);
        public static void WindowSetChild(ControlSafeHandle window, ControlSafeHandle child) => NativeMethods.uiWindowSetChild(window.DangerousGetHandle(), child.DangerousGetHandle());
        public static bool WindowGetMargins(ControlSafeHandle window) => NativeMethods.uiWindowMargined(window.DangerousGetHandle());
        public static void WindowSetMargins(ControlSafeHandle window, bool margined) => NativeMethods.uiWindowSetMargined(window.DangerousGetHandle(), margined);
        public static ControlSafeHandle NewWindow(string title, int width, int height, bool hasMenuBar)
        {
            IntPtr strPtr = UTF8Helper.ToUTF8Ptr(title);
            ControlSafeHandle safeHandle = new ControlSafeHandle(NativeMethods.uiNewWindow(strPtr, width, height, hasMenuBar));
            Marshal.FreeHGlobal(strPtr);
            return safeHandle;
        }
        public static ControlSafeHandle NewWindow(string title, Size size, bool hasMenuBar) => NewWindow(title, size.Width, size.Height, hasMenuBar);
        #endregion
        #region Button [uiButton]
        public static string ButtonGetText(ControlSafeHandle button) => UTF8Helper.ToUTF8Str(NativeMethods.uiButtonText(button.DangerousGetHandle()));
        public static void ButtonSetText(ControlSafeHandle button, string text)
        {
            IntPtr strPtr = UTF8Helper.ToUTF8Ptr(text);
            NativeMethods.uiButtonSetText(button.DangerousGetHandle(), strPtr);
            Marshal.FreeHGlobal(strPtr);
        }
        public static void ButtonOnClick(ControlSafeHandle button, OnClickEventHandler handler, IntPtr data) => NativeMethods.uiButtonOnClicked(button.DangerousGetHandle(), handler, data);
        public static void ButtonOnClick(ControlSafeHandle button, OnClickEventHandler handler) => ButtonOnClick(button, handler, IntPtr.Zero);
        public static ControlSafeHandle NewButton(string text)
        {
            IntPtr strPtr = UTF8Helper.ToUTF8Ptr(text);
            ControlSafeHandle safeHandle = new ControlSafeHandle(NativeMethods.uiNewButton(strPtr));
            Marshal.FreeHGlobal(strPtr);
            return safeHandle;
        }
        #endregion
        #region Panel/HPanel/VPanel [uiBox/uiHorizontalBox/uiVerticalBox]
        public static void PanelAppend(ControlSafeHandle parent, ControlSafeHandle child, bool stretches) => NativeMethods.uiBoxAppend(parent.DangerousGetHandle(), child.DangerousGetHandle(), stretches);
        public static void PanelDelete(ControlSafeHandle parent, int index) => NativeMethods.uiBoxDelete(parent.DangerousGetHandle(), index);
        public static bool PanelGetPadding(ControlSafeHandle panel) => NativeMethods.uiBoxPadded(panel.DangerousGetHandle());
        public static void PanelSetPadding(ControlSafeHandle panel, bool padding) => NativeMethods.uiBoxSetPadded(panel.DangerousGetHandle(), padding);
        public static ControlSafeHandle NewPanel(Orientation orientation)
        {
            if (orientation == Orientation.Vertical)
                return new ControlSafeHandle(NativeMethods.uiNewVerticalBox());
            else if (orientation == Orientation.Horizontal)
                return new ControlSafeHandle(NativeMethods.uiNewHorizontalBox());
            else
                throw new ArgumentOutOfRangeException("orientation");

        }
        #endregion
        #region CheckBox [uiCheckbox]
        public static string CheckBoxGetText(ControlSafeHandle checkbox) => UTF8Helper.ToUTF8Str(NativeMethods.uiCheckboxText(checkbox.DangerousGetHandle()));
        public static void CheckBoxSetText(ControlSafeHandle checkbox, string text)
        {
            IntPtr strPtr = UTF8Helper.ToUTF8Ptr(text);
            NativeMethods.uiCheckboxSetText(checkbox.DangerousGetHandle(), strPtr);
            Marshal.FreeHGlobal(strPtr);
        }
        public static void CheckBoxOnCheckedChanged(ControlSafeHandle checkbox, OnCheckedChangedEventHandler handler, IntPtr data) => NativeMethods.uiCheckboxOnToggled(checkbox.DangerousGetHandle(), handler, data);
        public static void CheckBoxOnCheckedChanged(ControlSafeHandle checkbox, OnCheckedChangedEventHandler handler) => CheckBoxOnCheckedChanged(checkbox, handler, IntPtr.Zero);
        public static bool CheckBoxGetChecked(ControlSafeHandle checkbox) => NativeMethods.uiCheckboxChecked(checkbox.DangerousGetHandle());
        public static void CheckBoxSetChecked(ControlSafeHandle checkbox, bool @checked) => NativeMethods.uiCheckboxSetChecked(checkbox.DangerousGetHandle(), @checked);
        public static ControlSafeHandle NewCheckBox(string text)
        {
            IntPtr strPtr = UTF8Helper.ToUTF8Ptr(text);
            ControlSafeHandle safeHandle = new ControlSafeHandle(NativeMethods.uiNewCheckbox(strPtr));
            Marshal.FreeHGlobal(strPtr);
            return safeHandle;
        }
        #endregion
        #region TextBox/PasswordBox/SearchBox [uiEntry/uiPasswordEntry/uiSearchEntry]
        public static string TextBoxGetText(ControlSafeHandle textbox) => UTF8Helper.ToUTF8Str(NativeMethods.uiEntryText(textbox.DangerousGetHandle()));
        public static void TextBoxSetText(ControlSafeHandle textbox, string text)
        {
            IntPtr strPtr = UTF8Helper.ToUTF8Ptr(text);
            NativeMethods.uiEntrySetText(textbox.DangerousGetHandle(), strPtr);
            Marshal.FreeHGlobal(strPtr);
        }
        public static void TextBoxOnTextChanged(ControlSafeHandle textbox, OnTextChangedEventHandler handler, IntPtr data) => NativeMethods.uiEntryOnChanged(textbox.DangerousGetHandle(), handler, data);
        public static void TextBoxOnTextChanged(ControlSafeHandle textbox, OnTextChangedEventHandler handler) => TextBoxOnTextChanged(textbox, handler, IntPtr.Zero);
        public static bool TextBoxGetReadOnly(ControlSafeHandle textbox) => NativeMethods.uiEntryReadOnly(textbox.DangerousGetHandle());
        public static void TextBoxSetReadOnly(ControlSafeHandle textbox, bool readOnly) => NativeMethods.uiEntrySetReadOnly(textbox.DangerousGetHandle(), readOnly);
        public static ControlSafeHandle NewTextBox() => new ControlSafeHandle(NativeMethods.uiNewEntry());
        public static ControlSafeHandle NewPasswordBox() => new ControlSafeHandle(NativeMethods.uiNewPasswordEntry());
        public static ControlSafeHandle NewSearchBox() => new ControlSafeHandle(NativeMethods.uiNewSearchEntry());
        #endregion
        #region Label [uiLabel]
        public static string LabelGetText(ControlSafeHandle label) => UTF8Helper.ToUTF8Str(NativeMethods.uiLabelText(label.DangerousGetHandle()));
        public static void LabelSetText(ControlSafeHandle label, string text)
        {
            IntPtr strPtr = UTF8Helper.ToUTF8Ptr(text);
            NativeMethods.uiLabelSetText(label.DangerousGetHandle(), strPtr);
            Marshal.FreeHGlobal(strPtr);
        }
        public static ControlSafeHandle NewLabel(string text)
        {
            IntPtr strPtr = UTF8Helper.ToUTF8Ptr(text);
            ControlSafeHandle safeHandle = new ControlSafeHandle(NativeMethods.uiNewLabel(strPtr));
            Marshal.FreeHGlobal(strPtr);
            return safeHandle;
        }
        #endregion
        #region TabControl/TabPage [uiTab]
        #endregion
        #region GroupBox [uiGroup]
        #endregion
        #region SpinBox [uiSpinbox]
        public static int SpinBoxGetValue(ControlSafeHandle spinbox) => NativeMethods.uiSpinboxValue(spinbox.DangerousGetHandle());
        public static void SpinBoxSetValue(ControlSafeHandle spinbox, int val) => NativeMethods.uiSpinboxSetValue(spinbox.DangerousGetHandle(), val);
        public static void SpinBoxOnValueChanged(ControlSafeHandle spinbox, OnValueChangedEventHandler handler, IntPtr data) => NativeMethods.uiSpinboxOnChanged(spinbox.DangerousGetHandle(), handler, data);
        public static void SpinBoxOnValueChanged(ControlSafeHandle spinbox, OnValueChangedEventHandler handler) => SpinBoxOnValueChanged(spinbox, handler, IntPtr.Zero);
        public static ControlSafeHandle NewSpinBox(int min, int max) => new ControlSafeHandle(NativeMethods.uiNewSpinbox(min, max));
        #endregion
        #region Slider [uiSlider]
        public static int SliderGetValue(ControlSafeHandle spinbox) => NativeMethods.uiSliderValue(spinbox.DangerousGetHandle());
        public static void SliderSetValue(ControlSafeHandle spinbox, int val) => NativeMethods.uiSliderSetValue(spinbox.DangerousGetHandle(), val);
        public static void SliderOnValueChanged(ControlSafeHandle spinbox, OnValueChangedEventHandler handler, IntPtr data) => NativeMethods.uiSliderOnChanged(spinbox.DangerousGetHandle(), handler, data);
        public static void SliderOnValueChanged(ControlSafeHandle spinbox, OnValueChangedEventHandler handler) => SliderOnValueChanged(spinbox, handler, IntPtr.Zero);
        public static ControlSafeHandle NewSlider(int min, int max) => new ControlSafeHandle(NativeMethods.uiNewSlider(min, max));
        #endregion
        #region ProgressBar [uiProgressBar]
        public static int ProgressBarGetValue(ControlSafeHandle progressbar) => NativeMethods.uiProgressBarValue(progressbar.DangerousGetHandle());
        public static void ProgressBarSetValue(ControlSafeHandle progressbar, int val) => NativeMethods.uiProgressBarSetValue(progressbar.DangerousGetHandle(), val);
        public static ControlSafeHandle NewProgressBar() => new ControlSafeHandle(NativeMethods.uiNewProgressBar());
        #endregion
        #region Separator/HSeparator/VSeparator [uiSeparator/uiHorizontalSeparator/uiVerticalSeparator]
        public static ControlSafeHandle NewSeparator(Orientation orientation)
        {
            if (orientation == Orientation.Horizontal)
                return new ControlSafeHandle(NativeMethods.uiNewHorizontalSeparator());
            else if (orientation == Orientation.Vertical)
                return new ControlSafeHandle(NativeMethods.uiNewVerticalSeparator());
            else
                throw new ArgumentOutOfRangeException("orientation");
        }
        #endregion
        #region ComboBox [uiCombobox]
        #endregion
        #region EditableComboBox [uiEditableCombobox]
        #endregion
        #region RadioButtonGroup [uiRadioButtons]
        #endregion
        #region DateTimePicker/DatePicker/TimePicker [uiDateTimePicker/uiDatePicker/uiTimePicker]
        public static ControlSafeHandle NewDateTimePicker() => new ControlSafeHandle(NativeMethods.uiNewDateTimePicker());
        public static ControlSafeHandle NewDatePicker() => new ControlSafeHandle(NativeMethods.uiNewDatePicker());
        public static ControlSafeHandle NewTimePicker() => new ControlSafeHandle(NativeMethods.uiNewTimePicker());
        #endregion
        #region (Multiline)TextBox [uiMultilineEntry]
        public static string MultilineTextBoxGetText(ControlSafeHandle textbox) => UTF8Helper.ToUTF8Str(NativeMethods.uiMultilineEntryText(textbox.DangerousGetHandle()));
        public static void MultilineTextBoxSetText(ControlSafeHandle textbox, string text)
        {
            IntPtr strPtr = UTF8Helper.ToUTF8Ptr(text);
            NativeMethods.uiMultilineEntrySetText(textbox.DangerousGetHandle(), strPtr);
            Marshal.FreeHGlobal(strPtr);
        }
        public static void MultilineTextBoxAppend(ControlSafeHandle textbox, params string[] lines)
        {
            foreach (string s in lines)
            {
                IntPtr strPtr = UTF8Helper.ToUTF8Ptr(s);
                NativeMethods.uiMultilineEntryAppend(textbox.DangerousGetHandle(), strPtr);
                Marshal.FreeHGlobal(strPtr);
            }
        }
        public static void MultilineTextBoxOnTextChanged(ControlSafeHandle textbox, OnTextChangedEventHandler handler, IntPtr data) => NativeMethods.uiMultilineEntryOnChanged(textbox.DangerousGetHandle(), handler, data);
        public static void MultilineTextBoxOnTextChanged(ControlSafeHandle textbox, OnTextChangedEventHandler handler) => MultilineTextBoxOnTextChanged(textbox, handler, IntPtr.Zero);
        public static bool MultilineTextBoxGetReadOnly(ControlSafeHandle textbox) => NativeMethods.uiMultilineEntryReadOnly(textbox.DangerousGetHandle());
        public static void MultilineTextBoxSetReadOnly(ControlSafeHandle textbox, bool readOnly) => NativeMethods.uiMultilineEntrySetReadOnly(textbox.DangerousGetHandle(), readOnly);
        public static ControlSafeHandle NewMultilineTextBox() => new ControlSafeHandle(NativeMethods.uiNewMultilineEntry());
        public static ControlSafeHandle NewNonWrappingMultilineTextBox() => new ControlSafeHandle(NativeMethods.uiNewNonWrappingMultilineEntry());
        #endregion
        #region MenuStripItem [uiMenuItem]
        #endregion
        #region MenuStrip [uiMenu]
        #endregion
        #region OpenFileDialog/SaveFileDialog/MessageBox [uiOpenFile/uiSaveFile/uiMsgBox]
        public static string OpenFile(ControlSafeHandle parent) => UTF8Helper.ToUTF8Str(NativeMethods.uiOpenFile(parent.DangerousGetHandle()));
        public static string SaveFile(ControlSafeHandle parent) => UTF8Helper.ToUTF8Str(NativeMethods.uiSaveFile(parent.DangerousGetHandle()));
        public static void MessageBox(ControlSafeHandle parent, string title, string description, bool error = false)
        {
            IntPtr titlePtr = UTF8Helper.ToUTF8Ptr(title);
            IntPtr descrPtr = UTF8Helper.ToUTF8Ptr(description);
            if (!error)
                NativeMethods.uiMsgBox(parent.DangerousGetHandle(), titlePtr, descrPtr);
            else
                NativeMethods.uiMsgBoxError(parent.DangerousGetHandle(), titlePtr, descrPtr);
            Marshal.FreeHGlobal(titlePtr);
            Marshal.FreeHGlobal(descrPtr);
        }
        #endregion
    }
}