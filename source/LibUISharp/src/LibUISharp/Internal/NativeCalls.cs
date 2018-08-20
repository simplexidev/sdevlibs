using System;
using System.Runtime.InteropServices;
using LibUISharp.Drawing;
using LibUISharp.SafeHandles;

namespace LibUISharp.Internal
{
    //TODO: Implement uiTimer.
    //TODO: Implement uiFreeText.
    //TODO: Implement uiControlVerifySetParent.
    //TODO: Implement uiControlEnabledToUser.
    //TODO: Implement uiTable*.

    internal static partial class NativeCalls
    {
        internal static string Init(ref StartupOptions options) => Call<uiInit>()(ref options);
        internal static void UnInit() => Call<uiUnInit>()();
        internal static void FreeInitError(string err) => Call<uiFreeInitError>()(err);
        internal static void Main() => Call<uiMain>()();
        internal static void MainSteps() => Call<uiMainSteps>()();
        internal static bool MainStep(bool wait) => Call<uiMainStep>()(wait);
        internal static void Quit() => Call<uiQuit>()();
        internal static void QueueMain(QueueMainCallback f, IntPtr data) => Call<uiQueueMain>()(f, data);
        internal static void Timer(int milliseconds, TimerCallback f, IntPtr data) => Call<uiTimer>()(milliseconds, f, data);
        internal static void OnShouldQuit(OnShouldQuitCallback f, IntPtr data) => Call<uiOnShouldQuit>()(f, data);

        internal static void FreeText(string text) => Call<uiFreeText>()(text);

        internal static void ControlDestroy(SafeControlHandle c) => Call<uiControlDestroy>()(c);
        internal static UIntPtr ControlHandle(SafeControlHandle c) => Call<uiControlHandle>()(c);
        internal static IntPtr ControlParent(SafeControlHandle c) => Call<uiControlParent>()(c);
        internal static void ControlSetParent(SafeControlHandle c, SafeControlHandle parent) => Call<uiControlSetParent>()(c, parent);
        internal static bool ControlTopLevel(SafeControlHandle c) => Call<uiControlToplevel>()(c);
        internal static bool ControlVisible(SafeControlHandle c) => Call<uiControlVisible>()(c);
        internal static void ControlShow(SafeControlHandle c) => Call<uiControlShow>()(c);
        internal static void ControlHide(SafeControlHandle c) => Call<uiControlHide>()(c);
        internal static bool ControlEnabled(SafeControlHandle c) => Call<uiControlEnabled>()(c);
        internal static void ControlEnable(SafeControlHandle c) => Call<uiControlEnable>()(c);
        internal static void ControlDisable(SafeControlHandle c) => Call<uiControlDisable>()(c);

        internal static string WindowTitle(SafeControlHandle w) => Call<uiWindowTitle>()(w);
        internal static void WindowSetTitle(SafeControlHandle w, string title) => Call<uiWindowSetTitle>()(w, title);
        internal static void WindowContentSize(SafeControlHandle w, out int width, out int height) => Call<uiWindowContentSize>()(w, out width, out height);
        internal static void WindowSetContentSize(SafeControlHandle w, int width, int height) => Call<uiWindowSetContentSize>()(w, width, height);
        internal static bool WindowFullscreen(SafeControlHandle w) => Call<uiWindowFullscreen>()(w);
        internal static void WindowSetFullscreen(SafeControlHandle w, bool fullscreen) => Call<uiWindowSetFullscreen>()(w, fullscreen);
        internal static void WindowOnContentSizeChanged(SafeControlHandle w, WindowOnContentSizeChangedCallback f, IntPtr data) => Call<uiWindowOnContentSizeChanged>()(w, f, data);
        internal static void WindowOnClosing(SafeControlHandle w, WindowOnClosingCallback f, IntPtr data) => Call<uiWindowOnClosing>()(w, f, data);
        internal static bool WindowBorderless(SafeControlHandle w) => Call<uiWindowBorderless>()(w);
        internal static void WindowSetBorderless(SafeControlHandle w, bool borderless) => Call<uiWindowSetBorderless>()(w, borderless);
        internal static void WindowSetChild(SafeControlHandle w, SafeControlHandle child) => Call<uiWindowSetChild>()(w, child);
        internal static bool WindowMargined(SafeControlHandle w) => Call<uiWindowMargined>()(w);
        internal static void WindowSetMargined(SafeControlHandle w, bool margined) => Call<uiWindowSetMargined>()(w, margined);
        internal static SafeControlHandle NewWindow(string title, int width, int height, bool hasMenubar) => new SafeControlHandle(Call<uiNewWindow>()(title, width, height, hasMenubar));

        internal static string ButtonText(SafeControlHandle b) => Call<uiButtonText>()(b);
        internal static void ButtonSetText(SafeControlHandle b, string text) => Call<uiButtonSetText>()(b, text);
        internal static void ButtonOnClicked(SafeControlHandle b, ButtonOnClickedCallback f, IntPtr data) => Call<uiButtonOnClicked>()(b, f, data);
        internal static SafeControlHandle NewButton(string text) => new SafeControlHandle(Call<uiNewButton>()(text));

        internal static void BoxAppend(SafeControlHandle b, SafeControlHandle child, bool stretchy) => Call<uiBoxAppend>()(b, child, stretchy);
        internal static void BoxDelete(SafeControlHandle b, int index) => Call<uiBoxDelete>()(b, index);
        internal static bool BoxPadded(SafeControlHandle b) => Call<uiBoxPadded>()(b);
        internal static void BoxSetPadded(SafeControlHandle b, bool padded) => Call<uiBoxSetPadded>()(b, padded);
        internal static SafeControlHandle NewHorizontalBox() => new SafeControlHandle(Call<uiNewHorizontalBox>()());
        internal static SafeControlHandle NewVerticalBox() => new SafeControlHandle(Call<uiNewVerticalBox>()());

        internal static string CheckboxText(SafeControlHandle c) => Call<uiCheckboxText>()(c);
        internal static void CheckboxSetText(SafeControlHandle c, string text) => Call<uiCheckboxSetText>()(c, text);
        internal static void CheckboxOnToggled(SafeControlHandle c, CheckboxOnToggledCallback f, IntPtr data) => Call<uiCheckboxOnToggled>()(c, f, data);
        internal static bool CheckboxChecked(SafeControlHandle c) => Call<uiCheckboxChecked>()(c);
        internal static void CheckboxSetChecked(SafeControlHandle c, bool @checked) => Call<uiCheckboxSetChecked>()(c, @checked);
        internal static SafeControlHandle NewCheckbox(string text) => new SafeControlHandle(Call<uiNewCheckbox>()(text));

        internal static string EntryText(SafeControlHandle e) => Call<uiEntryText>()(e);
        internal static void EntrySetText(SafeControlHandle e, string text) => Call<uiEntrySetText>()(e, text);
        internal static void EntryOnChanged(SafeControlHandle e, EntryOnChangedCallback f, IntPtr data) => Call<uiEntryOnChanged>()(e, f, data);
        internal static bool EntryReadOnly(SafeControlHandle e) => Call<uiEntryReadOnly>()(e);
        internal static void EntrySetReadOnly(SafeControlHandle e, bool @readonly) => Call<uiEntrySetReadOnly>()(e, @readonly);
        internal static SafeControlHandle NewEntry() => new SafeControlHandle(Call<uiNewEntry>()());
        internal static SafeControlHandle NewPasswordEntry() => new SafeControlHandle(Call<uiNewPasswordEntry>()());
        internal static SafeControlHandle NewSearchEntry() => new SafeControlHandle(Call<uiNewSearchEntry>()());

        internal static string LabelText(SafeControlHandle l) => Call<uiLabelText>()(l);
        internal static void LabelSetText(SafeControlHandle l, string text) => Call<uiLabelSetText>()(l, text);
        internal static SafeControlHandle NewLabel(string text) => new SafeControlHandle(Call<uiNewLabel>()(text));

        internal static void TabAppend(SafeControlHandle t, string name, SafeControlHandle c) => Call<uiTabAppend>()(t, name, c);
        internal static void TabInsertAt(SafeControlHandle t, string name, int before, IntPtr c) => Call<uiTabInsertAt>()(t, name, before, c);
        internal static void TabDelete(SafeControlHandle t, int index) => Call<uiTabDelete>()(t, index);
        internal static int TabNumPages(SafeControlHandle t) => Call<uiTabNumPages>()(t);
        internal static bool TabMargined(SafeControlHandle t, int page) => Call<uiTabMargined>()(t, page);
        internal static void TabSetMargined(SafeControlHandle t, int page, bool margined) => Call<uiTabSetMargined>()(t, page, margined);
        internal static SafeControlHandle NewTab() => new SafeControlHandle(Call<uiNewTab>()());

        internal static string GroupTitle(SafeControlHandle g) => Call<uiGroupTitle>()(g);
        internal static void GroupSetTitle(SafeControlHandle g, string title) => Call<uiGroupSetTitle>()(g, title);
        internal static void GroupSetChild(SafeControlHandle g, SafeControlHandle child) => Call<uiGroupSetChild>()(g, child);
        internal static bool GroupMargined(SafeControlHandle g) => Call<uiGroupMargined>()(g);
        internal static void GroupSetMargined(SafeControlHandle g, bool margined) => Call<uiGroupSetMargined>()(g, margined);
        internal static SafeControlHandle NewGroup(string title) => new SafeControlHandle(Call<uiNewGroup>()(title));

        internal static int SpinboxValue(SafeControlHandle s) => Call<uiSpinboxValue>()(s);
        internal static void SpinboxSetValue(SafeControlHandle s, int value) => Call<uiSpinboxSetValue>()(s, value);
        internal static void SpinboxOnChanged(SafeControlHandle s, SpinboxOnChangedCallback f, IntPtr data) => Call<uiSpinboxOnChanged>()(s, f, data);
        internal static SafeControlHandle NewSpinbox(int min, int max) => new SafeControlHandle(Call<uiNewSpinbox>()(min, max));

        internal static int SliderValue(SafeControlHandle s) => Call<uiSliderValue>()(s);
        internal static void SliderSetValue(SafeControlHandle s, int value) => Call<uiSliderSetValue>()(s, value);
        internal static void SliderOnChanged(SafeControlHandle s, SliderOnChangedCallback f, IntPtr data) => Call<uiSliderOnChanged>()(s, f, data);
        internal static SafeControlHandle NewSlider(int min, int max) => new SafeControlHandle(Call<uiNewSlider>()(min, max));

        internal static int ProgressBarValue(SafeControlHandle p) => Call<uiProgressBarValue>()(p);
        internal static void ProgressBarSetValue(SafeControlHandle p, int n) => Call<uiProgressBarSetValue>()(p, n);
        internal static SafeControlHandle NewProgressBar() => new SafeControlHandle(Call<uiNewProgressBar>()());

        internal static SafeControlHandle NewHorizontalSeparator() => new SafeControlHandle(Call<uiNewHorizontalSeparator>()());
        internal static SafeControlHandle NewVerticalSeparator() => new SafeControlHandle(Call<uiNewVerticalSeparator>()());

        internal static void ComboboxAppend(SafeControlHandle c, string text) => Call<uiComboboxAppend>()(c, text);
        internal static int ComboboxSelected(SafeControlHandle c) => Call<uiComboboxSelected>()(c);
        internal static void ComboboxSetSelected(SafeControlHandle c, int n) => Call<uiComboboxSetSelected>()(c, n);
        internal static void ComboboxOnSelected(SafeControlHandle c, ComboboxOnSelectedCallback f, IntPtr data) => Call<uiComboboxOnSelected>()(c, f, data);
        internal static SafeControlHandle NewCombobox() => new SafeControlHandle(Call<uiNewCombobox>()());

        internal static void EditableComboboxAppend(SafeControlHandle c, string text) => Call<uiEditableComboboxAppend>()(c, text);
        internal static string EditableComboboxText(SafeControlHandle c) => Call<uiEditableComboboxText>()(c);
        internal static void EditableComboboxSetText(SafeControlHandle c, string text) => Call<uiEditableComboboxSetText>()(c, text);
        internal static void EditableComboboxOnChanged(SafeControlHandle c, EditableComboboxOnChangedCallback f, IntPtr data) => Call<uiEditableComboboxOnChanged>()(c, f, data);
        internal static SafeControlHandle NewEditableCombobox() => new SafeControlHandle(Call<uiNewEditableCombobox>()());

        internal static void RadioButtonsAppend(SafeControlHandle r, string text) => Call<uiRadioButtonsAppend>()(r, text);
        internal static int RadioButtonsSelected(SafeControlHandle r) => Call<uiRadioButtonsSelected>()(r);
        internal static void RadioButtonsSetSelected(SafeControlHandle r, int n) => Call<uiRadioButtonsSetSelected>()(r, n);
        internal static void RadioButtonsOnSelected(SafeControlHandle r, RadioButtonsOnSelectedCallback f, IntPtr data) => Call<uiRadioButtonsOnSelected>()(r, f, data);
        internal static SafeControlHandle NewRadioButtons() => new SafeControlHandle(Call<uiNewRadioButtons>()());

        internal static void DateTimePickerTime(SafeControlHandle d, out UIDateTime time) => Call<uiDateTimePickerTime>()(d, out time);
        internal static void DateTimePickerSetTime(SafeControlHandle d, UIDateTime time) => Call<uiDateTimePickerSetTime>()(d, time);
        internal static void DateTimePickerOnChanged(SafeControlHandle d, DateTimePickerOnChangedCallback f, IntPtr data) => Call<uiDateTimePickerOnChanged>()(d, f, data);
        internal static SafeControlHandle NewDateTimePicker() => new SafeControlHandle(Call<uiNewDateTimePicker>()());
        internal static SafeControlHandle NewDatePicker() => new SafeControlHandle(Call<uiNewDatePicker>()());
        internal static SafeControlHandle NewTimePicker() => new SafeControlHandle(Call<uiNewTimePicker>()());

        internal static string MultilineEntryText(SafeControlHandle e) => Call<uiMultilineEntryText>()(e);
        internal static void MultilineEntrySetText(SafeControlHandle e, string text) => Call<uiMultilineEntrySetText>()(e, text);
        internal static void MultilineEntryAppend(SafeControlHandle e, string text) => Call<uiMultilineEntryAppend>()(e, text);
        internal static void MultilineEntryOnChanged(SafeControlHandle e, MultilineEntryOnChangedCallback f, IntPtr data) => Call<uiMultilineEntryOnChanged>()(e, f, data);
        internal static bool MultilineEntryReadOnly(SafeControlHandle e) => Call<uiMultilineEntryReadOnly>()(e);
        internal static void MultilineEntrySetReadOnly(SafeControlHandle e, bool @readonly) => Call<uiMultilineEntrySetReadOnly>()(e, @readonly);
        internal static SafeControlHandle NewMultilineEntry() => new SafeControlHandle(Call<uiNewMultilineEntry>()());
        internal static SafeControlHandle NewNonWrappingMultilineEntry() => new SafeControlHandle(Call<uiNewNonWrappingMultilineEntry>()());

        internal static void MenuItemEnable(SafeControlHandle m) => Call<uiMenuItemEnable>()(m);
        internal static void MenuItemDisable(SafeControlHandle m) => Call<uiMenuItemDisable>()(m);
        internal static void MenuItemOnClicked(SafeControlHandle m, MenuItemOnClickedCallback f, IntPtr data) => Call<uiMenuItemOnClicked>()(m, f, data);
        internal static bool MenuItemChecked(SafeControlHandle m) => Call<uiMenuItemChecked>()(m);
        internal static void MenuItemSetChecked(SafeControlHandle m, bool @checked) => Call<uiMenuItemSetChecked>()(m, @checked);
        internal static SafeControlHandle MenuAppendItem(SafeControlHandle m, string name) => new SafeControlHandle(Call<uiMenuAppendItem>()(m, name));
        internal static SafeControlHandle MenuAppendCheckItem(SafeControlHandle m, string name) => new SafeControlHandle(Call<uiMenuAppendCheckItem>()(m, name));
        internal static SafeControlHandle MenuAppendQuitItem(SafeControlHandle m) => new SafeControlHandle(Call<uiMenuAppendQuitItem>()(m));
        internal static SafeControlHandle MenuAppendPreferencesItem(SafeControlHandle m) => new SafeControlHandle(Call<uiMenuAppendPreferencesItem>()(m));
        internal static SafeControlHandle MenuAppendAboutItem(SafeControlHandle m) => new SafeControlHandle(Call<uiMenuAppendAboutItem>()(m));
        internal static void MenuAppendSeparator(SafeControlHandle m) => Call<uiMenuAppendSeparator>()(m);
        internal static SafeControlHandle NewMenu(string name) => new SafeControlHandle(Call<uiNewMenu>()(name));

        internal static string OpenFile(SafeControlHandle parent) => Call<uiOpenFile>()(parent);
        internal static string SaveFile(SafeControlHandle parent) => Call<uiSaveFile>()(parent);
        internal static void MsgBox(SafeControlHandle parent, string title, string description) => Call<uiMsgBox>()(parent, title, description);
        internal static void MsgBoxError(SafeControlHandle parent, string title, string description) => Call<uiMsgBoxError>()(parent, title, description);

        internal static void AreaSetSize(SafeControlHandle a, int width, int height) => Call<uiAreaSetSize>()(a, width, height);
        internal static void AreaQueueRedrawAll(SafeControlHandle a) => Call<uiAreaQueueRedrawAll>()(a);
        internal static void AreaScrollTo(SafeControlHandle a, double x, double y, double width, double height) => Call<uiAreaScrollTo>()(a, x, y, width, height);
        internal static void AreaBeginUserWindowMove(SafeControlHandle a) => Call<uiAreaBeginUserWindowMove>()(a);
        internal static void AreaBeginUserWindowResize(SafeControlHandle a, WindowEdge edge) => Call<uiAreaBeginUserWindowResize>()(a, edge);
        internal static SafeControlHandle NewArea(NativeSurfaceHandler ah) => new SafeControlHandle(Call<uiNewArea>()(ah));
        internal static SafeControlHandle NewScrollingArea(NativeSurfaceHandler ah, int width, int height) => new SafeControlHandle(Call<uiNewScrollingArea>()(ah, width, height));

        internal static SafePathHandle DrawNewPath(FillMode fillMode) => new SafePathHandle(Call<uiDrawNewPath>()(fillMode));
        internal static void DrawFreePath(IntPtr p) => Call<uiDrawFreePath>()(p);
        internal static void DrawPathNewFigure(SafePathHandle p, double x, double y) => Call<uiDrawPathNewFigure>()(p, x, y);
        internal static void DrawPathNewFigureWithArc(SafePathHandle p, double xCenter, double yCenter, double radius, double startAngle, double sweep, bool negative) => Call<uiDrawPathNewFigureWithArc>()(p, xCenter, yCenter, radius, startAngle, sweep, negative);
        internal static void DrawPathLineTo(SafePathHandle p, double x, double y) => Call<uiDrawPathLineTo>()(p, x, y);
        internal static void DrawPathArcTo(SafePathHandle p, double xCenter, double yCenter, double radius, double startAngle, double sweep, bool negative) => Call<uiDrawPathArcTo>()(p, xCenter, yCenter, radius, startAngle, sweep, negative);
        internal static void DrawPathBezierTo(SafePathHandle p, double c1x, double c1y, double c2x, double c2y, double endX, double endY) => Call<uiDrawPathBezierTo>()(p, c1x, c1y, c2x, c2y, endX, endY);
        internal static void DrawPathCloseFigure(SafePathHandle p) => Call<uiDrawPathCloseFigure>()(p);
        internal static void DrawPathAddRectangle(SafePathHandle p, double x, double y, double width, double height) => Call<uiDrawPathAddRectangle>()(p, x, y, width, height);
        internal static void DrawPathEnd(SafePathHandle p) => Call<uiDrawPathEnd>()(p);

        internal static void DrawStroke(SafeControlHandle context, SafePathHandle path, ref Brush brush, ref StrokeOptions strokeParam) => Call<uiDrawStroke>()(context, path, ref brush, ref strokeParam);
        internal static void DrawFill(SafeControlHandle context, SafePathHandle path, ref Brush brush) => Call<uiDrawFill>()(context, path, ref brush);

        internal static void DrawMatrixSetIdentity(Matrix matrix) => Call<uiDrawMatrixSetIdentity>()(matrix);
        internal static void DrawMatrixTranslate(Matrix matrix, double x, double y) => Call<uiDrawMatrixTranslate>()(matrix, x, y);
        internal static void DrawMatrixScale(Matrix matrix, double xCenter, double yCenter, double x, double y) => Call<uiDrawMatrixScale>()(matrix, xCenter, yCenter, x, y);
        internal static void DrawMatrixRotate(Matrix matrix, double x, double y, double amount) => Call<uiDrawMatrixRotate>()(matrix, x, y, amount);
        internal static void DrawMatrixSkew(Matrix matrix, double x, double y, double xamount, double yamount) => Call<uiDrawMatrixSkew>()(matrix, x, y, xamount, yamount);
        internal static void DrawMatrixMultiply(Matrix dest, Matrix src) => Call<uiDrawMatrixMultiply>()(dest, src);
        internal static bool DrawMatrixInvertible(Matrix matrix) => Call<uiDrawMatrixInvertible>()(matrix);
        internal static int DrawMatrixInvert(Matrix matrix) => Call<uiDrawMatrixInvert>()(matrix);
        internal static void DrawMatrixTransformPoint(Matrix matrix, out double x, out double y) => Call<uiDrawMatrixTransformPoint>()(matrix, out x, out y);
        internal static void DrawMatrixTransformSize(Matrix matrix, out double x, out double y) => Call<uiDrawMatrixTransformSize>()(matrix, out x, out y);

        //TODO: All missing functions.

        internal static void FontButtonFont(SafeControlHandle b, out Font desc) => Call<uiFontButtonFont>()(b, out desc);
        internal static void FontButtonOnChanged(SafeControlHandle b, FontButtonOnChangedCallback f, IntPtr data) => Call<uiFontButtonOnChanged>()(b, f, data);
        internal static SafeControlHandle NewFontButton() => new SafeControlHandle(Call<uiNewFontButton>()());
        internal static void FreeFontButtonFont(Font desc) => Call<uiFreeFontButtonFont>()(desc);

        internal static void ColorButtonColor(SafeControlHandle b, out double red, out double green, out double blue, out double alpha) => Call<uiColorButtonColor>()(b, out red, out green, out blue, out alpha);
        internal static void ColorButtonSetColor(SafeControlHandle b, double red, double green, double blue, double alpha) => Call<uiColorButtonSetColor>()(b, red, green, blue, alpha);
        internal static void ColorButtonOnChanged(SafeControlHandle b, ColorButtonOnChangedCallback f, IntPtr data) => Call<uiColorButtonOnChanged>()(b, f, data);
        internal static SafeControlHandle NewColorButton() => new SafeControlHandle(Call<uiNewColorButton>()());

        internal static void FormAppend(SafeControlHandle f, string label, SafeControlHandle c, bool stretchy) => Call<uiFormAppend>()(f, label, c, stretchy);
        internal static void FormDelete(SafeControlHandle f, int index) => Call<uiFormDelete>()(f, index);
        internal static bool FormPadded(SafeControlHandle f) => Call<uiFormPadded>()(f);
        internal static void FormSetPadded(SafeControlHandle f, bool padded) => Call<uiFormSetPadded>()(f, padded);
        internal static SafeControlHandle NewForm() => new SafeControlHandle(Call<uiNewForm>()());

        internal static void GridAppend(SafeControlHandle g, SafeControlHandle c, int left, int top, int xspan, int yspan, int hexpand, NativeAlignment halign, int vexpand, NativeAlignment valign) => Call<uiGridAppend>()(g, c, left, top, xspan, yspan, hexpand, halign, vexpand, valign);
        internal static void GridInsertAt(SafeControlHandle g, SafeControlHandle c, SafeControlHandle existing, RelativeAlignment at, int xspan, int yspan, int hexpand, NativeAlignment halign, int vexpand, NativeAlignment valign) => Call<uiGridInsertAt>()(g, c, existing, at, xspan, yspan, hexpand, halign, vexpand, valign);
        internal static bool GridPadded(SafeControlHandle g) => Call<uiGridPadded>()(g);
        internal static void GridSetPadded(SafeControlHandle g, bool padded) => Call<uiGridSetPadded>()(g, padded);
        internal static SafeControlHandle NewGrid() => new SafeControlHandle(Call<uiNewGrid>()());
    }
}