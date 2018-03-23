using System;
using System.Runtime.InteropServices;
using LibUISharp.Controls;
using LibUISharp.Drawing;

namespace LibUISharp.Internal
{
    internal static class LibUIAPI
    {
#region Panel/HPanel/VPanel [uiBox/uiHorizontalBox/uiVerticalBox]
        public static void PanelAppend(ControlSafeHandle parent, ControlSafeHandle child, bool stretches) => uiBoxAppend(parent.DangerousGetHandle(), child.DangerousGetHandle(), stretches);
        public static void PanelDelete(ControlSafeHandle parent, int index) => uiBoxDelete(parent.DangerousGetHandle(), index);
        public static bool PanelGetPadding(ControlSafeHandle panel) => uiBoxPadded(panel.DangerousGetHandle());
        public static void PanelSetPadding(ControlSafeHandle panel, bool padding) => uiBoxSetPadded(panel.DangerousGetHandle(), padding);
        public static ControlSafeHandle NewPanel(Orientation orientation)
        {
            if (orientation == Orientation.Vertical)
                return new ControlSafeHandle(uiNewVerticalBox());
            else if (orientation == Orientation.Horizontal)
                return new ControlSafeHandle(uiNewHorizontalBox());
            else
                throw new ArgumentOutOfRangeException("orientation");

        }
#endregion
#region CheckBox [uiCheckbox]
        public static string CheckBoxGetText(ControlSafeHandle checkbox) => UTF8Helper.ToUTF8Str(uiCheckboxText(checkbox.DangerousGetHandle()));
        public static void CheckBoxSetText(ControlSafeHandle checkbox, string text)
        {
            IntPtr strPtr = UTF8Helper.ToUTF8Ptr(text);
            uiCheckboxSetText(checkbox.DangerousGetHandle(), strPtr);
            Marshal.FreeHGlobal(strPtr);
        }
        public static void CheckBoxOnCheckedChanged(ControlSafeHandle checkbox, OnCheckedChangedEventHandler handler, IntPtr data) => uiCheckboxOnToggled(checkbox.DangerousGetHandle(), handler, data);
        public static void CheckBoxOnCheckedChanged(ControlSafeHandle checkbox, OnCheckedChangedEventHandler handler) => CheckBoxOnCheckedChanged(checkbox, handler, IntPtr.Zero);
        public static bool CheckBoxGetChecked(ControlSafeHandle checkbox) => uiCheckboxChecked(checkbox.DangerousGetHandle());
        public static void CheckBoxSetChecked(ControlSafeHandle checkbox, bool @checked) => uiCheckboxSetChecked(checkbox.DangerousGetHandle(), @checked);
        public static ControlSafeHandle NewCheckBox(string text)
        {
            IntPtr strPtr = UTF8Helper.ToUTF8Ptr(text);
            ControlSafeHandle safeHandle = new ControlSafeHandle(uiNewCheckbox(strPtr));
            Marshal.FreeHGlobal(strPtr);
            return safeHandle;
        }
#endregion
#region TextBox/PasswordBox/SearchBox [uiEntry/uiPasswordEntry/uiSearchEntry]
        public static string TextBoxGetText(ControlSafeHandle textbox) => UTF8Helper.ToUTF8Str(uiEntryText(textbox.DangerousGetHandle()));
        public static void TextBoxSetText(ControlSafeHandle textbox, string text)
        {
            IntPtr strPtr = UTF8Helper.ToUTF8Ptr(text);
            uiEntrySetText(textbox.DangerousGetHandle(), strPtr);
            Marshal.FreeHGlobal(strPtr);
        }
        public static void TextBoxOnTextChanged(ControlSafeHandle textbox, OnTextChangedEventHandler handler, IntPtr data) => uiEntryOnChanged(textbox.DangerousGetHandle(), handler, data);
        public static void TextBoxOnTextChanged(ControlSafeHandle textbox, OnTextChangedEventHandler handler) => TextBoxOnTextChanged(textbox, handler, IntPtr.Zero);
        public static bool TextBoxGetReadOnly(ControlSafeHandle textbox) => uiEntryReadOnly(textbox.DangerousGetHandle());
        public static void TextBoxSetReadOnly(ControlSafeHandle textbox, bool readOnly) => uiEntrySetReadOnly(textbox.DangerousGetHandle(), readOnly);
        public static ControlSafeHandle NewTextBox() => new ControlSafeHandle(uiNewEntry());
        public static ControlSafeHandle NewPasswordBox() => new ControlSafeHandle(uiNewPasswordEntry());
        public static ControlSafeHandle NewSearchBox() => new ControlSafeHandle(uiNewSearchEntry());
#endregion
#region Label [uiLabel]
        public static string LabelGetText(ControlSafeHandle label) => UTF8Helper.ToUTF8Str(uiLabelText(label.DangerousGetHandle()));
        public static void LabelSetText(ControlSafeHandle label, string text)
        {
            IntPtr strPtr = UTF8Helper.ToUTF8Ptr(text);
            uiLabelSetText(label.DangerousGetHandle(), strPtr);
            Marshal.FreeHGlobal(strPtr);
        }
        public static ControlSafeHandle NewLabel(string text)
        {
            IntPtr strPtr = UTF8Helper.ToUTF8Ptr(text);
            ControlSafeHandle safeHandle = new ControlSafeHandle(uiNewLabel(strPtr));
            Marshal.FreeHGlobal(strPtr);
            return safeHandle;
        }
#endregion
#region TabControl/TabPage [uiTab]
        public static void TabControlAppend(ControlSafeHandle tabcontrol, string name, ControlSafeHandle child)
        {

        }
#endregion
#region GroupBox [uiGroup]
#endregion
#region SpinBox [uiSpinbox]
        public static int SpinBoxGetValue(ControlSafeHandle spinbox) => uiSpinboxValue(spinbox.DangerousGetHandle());
        public static void SpinBoxSetValue(ControlSafeHandle spinbox, int val) => uiSpinboxSetValue(spinbox.DangerousGetHandle(), val);
        public static void SpinBoxOnValueChanged(ControlSafeHandle spinbox, OnValueChangedEventHandler handler, IntPtr data) => uiSpinboxOnChanged(spinbox.DangerousGetHandle(), handler, data);
        public static void SpinBoxOnValueChanged(ControlSafeHandle spinbox, OnValueChangedEventHandler handler) => SpinBoxOnValueChanged(spinbox, handler, IntPtr.Zero);
        public static ControlSafeHandle NewSpinBox(int min, int max) => new ControlSafeHandle(uiNewSpinbox(min, max));
#endregion
#region Slider [uiSlider]
        public static int SliderGetValue(ControlSafeHandle spinbox) => uiSliderValue(spinbox.DangerousGetHandle());
        public static void SliderSetValue(ControlSafeHandle spinbox, int val) => uiSliderSetValue(spinbox.DangerousGetHandle(), val);
        public static void SliderOnValueChanged(ControlSafeHandle spinbox, OnValueChangedEventHandler handler, IntPtr data) => uiSliderOnChanged(spinbox.DangerousGetHandle(), handler, data);
        public static void SliderOnValueChanged(ControlSafeHandle spinbox, OnValueChangedEventHandler handler) => SliderOnValueChanged(spinbox, handler, IntPtr.Zero);
        public static ControlSafeHandle NewSlider(int min, int max) => new ControlSafeHandle(uiNewSlider(min, max));
#endregion
#region ProgressBar [uiProgressBar]
        public static int ProgressBarGetValue(ControlSafeHandle progressbar) => uiProgressBarValue(progressbar.DangerousGetHandle());
        public static void ProgressBarSetValue(ControlSafeHandle progressbar, int val) => uiProgressBarSetValue(progressbar.DangerousGetHandle(), val);
        public static ControlSafeHandle NewProgressBar() => new ControlSafeHandle(uiNewProgressBar());
#endregion
#region Separator/HSeparator/VSeparator [uiSeparator/uiHorizontalSeparator/uiVerticalSeparator]
        public static ControlSafeHandle NewSeparator(Orientation orientation)
        {
            if (orientation == Orientation.Horizontal)
                return new ControlSafeHandle(uiNewHorizontalSeparator());
            else if (orientation == Orientation.Vertical)
                return new ControlSafeHandle(uiNewVerticalSeparator());
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
        public static ControlSafeHandle NewDateTimePicker() => new ControlSafeHandle(uiNewDateTimePicker());
        public static ControlSafeHandle NewDatePicker() => new ControlSafeHandle(uiNewDatePicker());
        public static ControlSafeHandle NewTimePicker() => new ControlSafeHandle(uiNewTimePicker());
#endregion
#region MultilineTextBox [uiMultilineEntry]
        public static string MultilineTextBoxGetText(ControlSafeHandle textbox) => UTF8Helper.ToUTF8Str(uiMultilineEntryText(textbox.DangerousGetHandle()));
        public static void MultilineTextBoxSetText(ControlSafeHandle textbox, string text)
        {
            IntPtr strPtr = UTF8Helper.ToUTF8Ptr(text);
            uiMultilineEntrySetText(textbox.DangerousGetHandle(), strPtr);
            Marshal.FreeHGlobal(strPtr);
        }
        public static void MultilineTextBoxAppend(ControlSafeHandle textbox, params string[] lines)
        {
            foreach (string s in lines)
            {
                IntPtr strPtr = UTF8Helper.ToUTF8Ptr(s);
                uiMultilineEntryAppend(textbox.DangerousGetHandle(), strPtr);
                Marshal.FreeHGlobal(strPtr);
            }
        }
        public static void MultilineTextBoxOnTextChanged(ControlSafeHandle textbox, OnTextChangedEventHandler handler, IntPtr data) => uiMultilineEntryOnChanged(textbox.DangerousGetHandle(), handler, data);
        public static void MultilineTextBoxOnTextChanged(ControlSafeHandle textbox, OnTextChangedEventHandler handler) => MultilineTextBoxOnTextChanged(textbox, handler, IntPtr.Zero);
        public static bool MultilineTextBoxGetReadOnly(ControlSafeHandle textbox) => uiMultilineEntryReadOnly(textbox.DangerousGetHandle());
        public static void MultilineTextBoxSetReadOnly(ControlSafeHandle textbox, bool readOnly) => uiMultilineEntrySetReadOnly(textbox.DangerousGetHandle(), readOnly);
        public static ControlSafeHandle NewMultilineTextBox() => new ControlSafeHandle(uiNewMultilineEntry());
        public static ControlSafeHandle NewNonWrappingMultilineTextBox() => new ControlSafeHandle(uiNewNonWrappingMultilineEntry());
#endregion
#region MenuStripItem [uiMenuItem]
#endregion
#region MenuStrip [uiMenu]
#endregion
    }
}