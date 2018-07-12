using NativeLibraryLoader;
using System;
using System.Runtime.InteropServices;

namespace LibUISharp.Internal
{
    internal static partial class Libraries
    {
        internal static class Libui
        {
            internal const CallingConvention Convention = CallingConvention.Cdecl;

            internal static NativeLibrary Library
            {
                get
                {
                    if (PlatformHelper.IsWinNT) return new NativeLibrary("libui.dll");
                    else if (PlatformHelper.IsLinux) return new NativeLibrary("libui.so");
                    else if (PlatformHelper.IsMacOS) return new NativeLibrary("libui.dylib");
                    else throw new PlatformNotSupportedException();
                }
            }

            internal static T Call<T>() => Call<T>(typeof(T).Name);
            internal static T Call<T>(string name) => LoadCall<T>(Library, name);

            // _UI_EXTERN const char *uiInit(uiInitOptions *options);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate string uiInit(ref StartupOptions options);

            // _UI_EXTERN void uiUninit(void);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiUnInit();

            // _UI_EXTERN void uiFreeInitError(const char *err);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiFreeInitError(string err);

            // _UI_EXTERN void uiMain(void);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiMain();

            // _UI_EXTERN void uiMainSteps(void);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiMainSteps();

            // _UI_EXTERN int uiMainStep(int wait);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate bool uiMainStep(bool wait);

            // _UI_EXTERN void uiQuit(void);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiQuit();

            // _UI_EXTERN void uiQueueMain(void (*f)(void *data), void *data);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiQueueMain(uiQueueMain_f f, IntPtr data);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiQueueMain_f(IntPtr data);

            //TODO: Implement this.
            // _UI_EXTERN void uiTimer(int milliseconds, int (*f)(void *data), void *data);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiTimer(int milliseconds, uiTimer_f f, IntPtr data);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate bool uiTimer_f(IntPtr data);

            // _UI_EXTERN void uiOnShouldQuit(int (*f)(void *data), void *data);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiOnShouldQuit(uiOnShouldQuit_f f, IntPtr data);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate bool uiOnShouldQuit_f(IntPtr data);

            // _UI_EXTERN void uiFreeText(char *text);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiFreeText(string text);

            // _UI_EXTERN void uiControlDestroy(uiControl *);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiControlDestroy(IntPtr c);

            // _UI_EXTERN uintptr uiControlHandle(uiControl *);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate UIntPtr uiControlHandle(IntPtr c);

            // _UI_EXTERN uiControl *uiControlParent(uiControl *);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate IntPtr uiControlParent(IntPtr c);

            // _UI_EXTERN void uiControlSetParent(uiControl *, uiControl *);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiControlSetParent(IntPtr c, IntPtr parent);

            // _UI_EXTERN int uiControlToplevel(uiControl *);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate bool uiControlToplevel(IntPtr c);

            // _UI_EXTERN int uiControlVisible(uiControl *);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate bool uiControlVisible(IntPtr c);

            // _UI_EXTERN void uiControlShow(uiControl *);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiControlShow(IntPtr c);

            // _UI_EXTERN void uiControlHide(uiControl *);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiControlHide(IntPtr c);

            // _UI_EXTERN int uiControlEnabled(uiControl *);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate bool uiControlEnabled(IntPtr c);

            // _UI_EXTERN void uiControlEnable(uiControl *);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate bool uiControlEnable(IntPtr c);

            // _UI_EXTERN void uiControlDisable(uiControl *);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate bool uiControlDisable(IntPtr c);

            //TODO: Implement this.
            // _UI_EXTERN int uiControlEnabledToUser(uiControl *);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate bool uiControlEnabledToUser(IntPtr c);

            //TODO: Implement this.
            // _UI_EXTERN void uiControlVerifySetParent(uiControl *, uiControl *);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate bool uiControlVerifySetParent(IntPtr c, IntPtr parent);

            // _UI_EXTERN char *uiWindowTitle(uiWindow *w);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate string uiWindowTitle(IntPtr w);

            // _UI_EXTERN void uiWindowSetTitle(uiWindow *w, const char *title);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiWindowSetTitle(IntPtr w, string title);

            // _UI_EXTERN void uiWindowContentSize(uiWindow *w, int *width, int *height);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiWindowContentSize(IntPtr w, out int width, out int height);

            // _UI_EXTERN void uiWindowSetContentSize(uiWindow *w, int width, int height);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiWindowSetContentSize(IntPtr w, int width, int height);

            // _UI_EXTERN int uiWindowFullscreen(uiWindow *w);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate bool uiWindowFullscreen(IntPtr w);

            // _UI_EXTERN void uiWindowSetFullscreen(uiWindow *w, int fullscreen);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiWindowSetFullscreen(IntPtr w, bool fullscreen);

            // _UI_EXTERN void uiWindowOnContentSizeChanged(uiWindow *w, void (*f)(uiWindow *, void *), void *data);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiWindowOnContentSizeChanged(IntPtr w, uiWindowOnContentSizeChanged_f f, IntPtr data);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiWindowOnContentSizeChanged_f(IntPtr w, IntPtr data);

            // _UI_EXTERN void uiWindowOnClosing(uiWindow *w, int (*f)(uiWindow *w, void *data), void *data);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiWindowOnClosing(IntPtr w, uiWindowOnClosing_f f, IntPtr data);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate bool uiWindowOnClosing_f(IntPtr w, IntPtr data);

            // _UI_EXTERN int uiWindowBorderless(uiWindow *w);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate bool uiWindowBorderless(IntPtr w);

            // _UI_EXTERN void uiWindowSetBorderless(uiWindow *w, int borderless);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiWindowSetBorderless(IntPtr w, bool borderless);

            // _UI_EXTERN void uiWindowSetChild(uiWindow *w, uiControl *child);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiWindowSetChild(IntPtr w, IntPtr child);

            // _UI_EXTERN int uiWindowMargined(uiWindow *w);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate bool uiWindowMargined(IntPtr w);

            // _UI_EXTERN void uiWindowSetMargined(uiWindow *w, int margined);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiWindowSetMargined(IntPtr w, bool margined);

            // _UI_EXTERN uiWindow *uiNewWindow(const char *title, int width, int height, int hasMenubar);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate IntPtr uiNewWindow(string title, int width, int height, bool hasMenubar);

            // _UI_EXTERN char *uiButtonText(uiButton *b);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate string uiButtonText(IntPtr b);

            // _UI_EXTERN void uiButtonSetText(uiButton *b, const char *text);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiButtonSetText(IntPtr b, string text);

            // _UI_EXTERN void uiButtonOnClicked(uiButton *b, void (*f)(uiButton *b, void *data), void *data);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiButtonOnClicked(IntPtr b, uiButtonOnClickedf f, IntPtr data);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiButtonOnClickedf(IntPtr b, IntPtr data);

            // _UI_EXTERN uiButton *uiNewButton(const char *text);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate IntPtr uiNewButton(string text);

            // _UI_EXTERN void uiBoxAppend(uiBox *b, uiControl *child, int stretchy);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiBoxAppend(IntPtr b, IntPtr child, bool stretchy);

            // _UI_EXTERN void uiBoxDelete(uiBox *b, int index);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiBoxDelete(IntPtr b, int index);

            // _UI_EXTERN int uiBoxPadded(uiBox *b);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate bool uiBoxPadded(IntPtr b);

            // _UI_EXTERN void uiBoxSetPadded(uiBox *b, int padded);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiBoxSetPadded(IntPtr b, bool padded);

            // _UI_EXTERN uiBox *uiNewHorizontalBox(void);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate IntPtr uiNewHorizontalBox();

            // _UI_EXTERN uiBox *uiNewVerticalBox(void);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate IntPtr uiNewVerticalBox();

            // _UI_EXTERN char *uiCheckboxText(uiCheckbox *c);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate string uiCheckboxText(IntPtr c);

            // _UI_EXTERN void uiCheckboxSetText(uiCheckbox *c, const char *text);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiCheckboxSetText(IntPtr c, string text);

            // _UI_EXTERN void uiCheckboxOnToggled(uiCheckbox *c, void (*f)(uiCheckbox *c, void *data), void *data);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiCheckboxOnToggled(IntPtr c, uiCheckboxOnToggled_f f, IntPtr data);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiCheckboxOnToggled_f(IntPtr c, IntPtr data);

            // _UI_EXTERN int uiCheckboxChecked(uiCheckbox *c);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate bool uiCheckboxChecked(IntPtr c);

            // _UI_EXTERN void uiCheckboxSetChecked(uiCheckbox *c, int checked);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiCheckboxSetChecked(IntPtr c, bool @checked);

            // _UI_EXTERN uiCheckbox *uiNewCheckbox(const char *text);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate IntPtr uiNewCheckbox(string text);

            // _UI_EXTERN char *uiEntryText(uiEntry *e);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate string uiEntryText(IntPtr e);

            // _UI_EXTERN void uiEntrySetText(uiEntry *e, const char *text);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiEntrySetText(IntPtr e, string text);

            // _UI_EXTERN void uiEntryOnChanged(uiEntry *e, void (*f)(uiEntry *e, void *data), void *data);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiEntryOnChanged(IntPtr e, uiEntryOnChanged_f f, IntPtr data);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiEntryOnChanged_f(IntPtr e, IntPtr data);

            // _UI_EXTERN int uiEntryReadOnly(uiEntry *e);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate bool uiEntryReadOnly(IntPtr e);

            // _UI_EXTERN void uiEntrySetReadOnly(uiEntry *e, int readonly);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiEntrySetReadOnly(IntPtr e, bool @readonly);

            // _UI_EXTERN uiEntry *uiNewEntry(void);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate IntPtr uiNewEntry();

            // _UI_EXTERN uiEntry *uiNewPasswordEntry(void);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate IntPtr uiNewPasswordEntry();

            // _UI_EXTERN uiEntry *uiNewSearchEntry(void);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate IntPtr uiNewSearchEntry();

            // _UI_EXTERN char *uiLabelText(uiLabel *l);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate string uiLabelText(IntPtr l);

            // _UI_EXTERN void uiLabelSetText(uiLabel *l, const char *text);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiLabelSetText(IntPtr l, string text);

            // _UI_EXTERN uiLabel *uiNewLabel(const char* text);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate IntPtr uiNewLabel(string text);

            // _UI_EXTERN void uiTabAppend(uiTab *t, const char *name, uiControl *c);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiTabAppend(IntPtr t, string name, IntPtr c);

            // _UI_EXTERN void uiTabInsertAt(uiTab *t, const char *name, int before, uiControl *c);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiTabInsertAt(IntPtr t, string name, int before, IntPtr c);

            // _UI_EXTERN void uiTabDelete(uiTab *t, int index);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiTabDelete(IntPtr t, int index);

            // _UI_EXTERN int uiTabNumPages(uiTab *t);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate int uiTabNumPages(IntPtr t);

            // _UI_EXTERN int uiTabMargined(uiTab *t, int page);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate bool uiTabMargined(IntPtr t, int page);

            // _UI_EXTERN void uiTabSetMargined(uiTab *t, int page, int margined);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiTabSetMargined(IntPtr t, int page, bool margined);

            // _UI_EXTERN uiTab *uiNewTab(void);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate IntPtr uiNewTab();

            // _UI_EXTERN char *uiGroupTitle(uiGroup *g);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate string uiGroupTitle(IntPtr g);

            // _UI_EXTERN void uiGroupSetTitle(uiGroup *g, const char *title);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiGroupSetTitle(IntPtr g, string title);

            // _UI_EXTERN void uiGroupSetChild(uiGroup *g, uiControl *c);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiGroupSetChild(IntPtr g, IntPtr child);

            // _UI_EXTERN int uiGroupMargined(uiGroup *g);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate bool uiGroupMargined(IntPtr g);

            // _UI_EXTERN void uiGroupSetMargined(uiGroup *g, int margined);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiGroupSetMargined(IntPtr g, bool margined);

            // _UI_EXTERN uiGroup *uiNewGroup(const char *title);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate IntPtr uiNewGroup(string title);


            // _UI_EXTERN int uiSpinboxValue(uiSpinbox *s);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate int uiSpinboxValue(IntPtr s);

            // _UI_EXTERN void uiSpinboxSetValue(uiSpinbox *s, int value);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiSpinboxSetValue(IntPtr s, int value);

            // _UI_EXTERN void uiSpinboxOnChanged(uiSpinbox *s, void (*f)(uiSpinbox *s, void *data), void *data);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiSpinboxOnChanged(IntPtr s, uiSpinboxOnChanged_f f, IntPtr data);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiSpinboxOnChanged_f(IntPtr s, IntPtr data);

            // _UI_EXTERN uiSpinbox *uiNewSpinbox(int min, int max);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate IntPtr uiNewSpinbox(int min, int max);

            // _UI_EXTERN int uiSliderValue(uiSlider *s);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate int uiSliderValue(IntPtr s);

            // _UI_EXTERN void uiSliderSetValue(uiSlider *s, int value);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiSliderSetValue(IntPtr s, int value);

            // _UI_EXTERN void uiSliderOnChanged(uiSlider *s, void (*f)(uiSlider *s, void *data), void *data);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiSliderOnChanged(IntPtr s, uiSliderOnChanged_f f, IntPtr data);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiSliderOnChanged_f(IntPtr s, IntPtr data);

            // _UI_EXTERN uiSlider *uiNewSlider(int min, int max);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate IntPtr uiNewSlider(int min, int max);

            // _UI_EXTERN int uiProgressBarValue(uiProgressBar* p);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate int uiProgressBarValue(IntPtr p);

            // _UI_EXTERN void uiProgressBarSetValue(uiProgressBar* p, int n);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiProgressBarSetValue(IntPtr p, int n);

            // _UI_EXTERN uiProgressBar * uiNewProgressBar(void);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate IntPtr uiNewProgressBar();

            // _UI_EXTERN uiSeparator *uiNewHorizontalSeparator(void);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate IntPtr uiNewHorizontalSeparator();

            // _UI_EXTERN uiSeparator *uiNewVerticalSeparator(void);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate IntPtr uiNewVerticalSeparator();

            // _UI_EXTERN void uiComboboxAppend(uiCombobox *c, const char *text);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiComboboxAppend(IntPtr c, string text);

            // _UI_EXTERN int uiComboboxSelected(uiCombobox *c);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate int uiComboboxSelected(IntPtr c);

            // _UI_EXTERN void uiComboboxSetSelected(uiCombobox *c, int n);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiComboboxSetSelected(IntPtr c, int n);

            // _UI_EXTERN void uiComboboxOnSelected(uiCombobox *c, void (*f)(uiCombobox *c, void *data), void *data);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiComboboxOnSelected(IntPtr c, uiComboboxOnSelected_f f, IntPtr data);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiComboboxOnSelected_f(IntPtr c, IntPtr data);

            // _UI_EXTERN uiCombobox *uiNewCombobox(void);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate IntPtr uiNewCombobox();

            // _UI_EXTERN void uiEditableComboboxAppend(uiEditableCombobox *c, const char *text);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiEditableComboboxAppend(IntPtr c, string text);

            // _UI_EXTERN char *uiEditableComboboxText(uiEditableCombobox *c);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate string uiEditableComboboxText(IntPtr c);

            // _UI_EXTERN void uiEditableComboboxSetText(uiEditableCombobox *c, const char *text);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiEditableComboboxSetText(IntPtr c, string text);

            // _UI_EXTERN void uiEditableComboboxOnChanged(uiEditableCombobox *c, void (*f)(uiEditableCombobox *c, void *data), void *data);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiEditableComboboxOnChanged(IntPtr c, uiEditableComboboxOnChanged_f f, IntPtr data);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiEditableComboboxOnChanged_f(IntPtr c, IntPtr data);

            // _UI_EXTERN uiEditableCombobox *uiNewEditableCombobox(void);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate IntPtr uiNewEditableCombobox();

            // _UI_EXTERN void uiRadioButtonsAppend(uiRadioButtons *r, const char *text);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiRadioButtonsAppend(IntPtr r, string text);

            // _UI_EXTERN int uiRadioButtonsSelected(uiRadioButtons *r);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate int uiRadioButtonsSelected(IntPtr r);

            // _UI_EXTERN void uiRadioButtonsSetSelected(uiRadioButtons *r, int n);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiRadioButtonsSetSelected(IntPtr r, int n);

            // _UI_EXTERN void uiRadioButtonsOnSelected(uiRadioButtons *r, void (*f)(uiRadioButtons *, void *), void *data);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiRadioButtonsOnSelected(IntPtr r, uiRadioButtonsOnSelected_f f, IntPtr data);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiRadioButtonsOnSelected_f(IntPtr r, IntPtr data);

            // _UI_EXTERN uiRadioButtons *uiNewRadioButtons(void);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate IntPtr uiNewRadioButtons();

            // _UI_EXTERN void uiDateTimePickerTime(uiDateTimePicker *d, struct tm *time);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiDateTimePickerTime(IntPtr d, out UIDateTime time);

            // _UI_EXTERN void uiDateTimePickerSetTime(uiDateTimePicker *d, const struct tm *time);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiDateTimePickerSetTime(IntPtr d, UIDateTime time);

            // _UI_EXTERN void uiDateTimePickerOnChanged(uiDateTimePicker *d, void (*f)(uiDateTimePicker *, void *), void *data);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiDateTimePickerOnChanged(IntPtr d, uiDateTimePickerOnChanged_f f, IntPtr data);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiDateTimePickerOnChanged_f(IntPtr d, IntPtr data);

            // _UI_EXTERN uiDateTimePicker *uiNewDateTimePicker(void);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate IntPtr uiNewDateTimePicker();

            // _UI_EXTERN uiDateTimePicker *uiNewDatePicker(void);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate IntPtr uiNewDatePicker();

            // _UI_EXTERN uiDateTimePicker *uiNewTimePicker(void);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate IntPtr uiNewTimePicker();

            // _UI_EXTERN char *uiMultilineEntryText(uiMultilineEntry *e);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate string uiMultilineEntryText(IntPtr e);

            // _UI_EXTERN void uiMultilineEntrySetText(uiMultilineEntry *e, const char *text);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiMultilineEntrySetText(IntPtr e, string text);

            // _UI_EXTERN void uiMultilineEntryAppend(uiMultilineEntry *e, const char *text);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiMultilineEntryAppend(IntPtr e, string text);

            // _UI_EXTERN void uiMultilineEntryOnChanged(uiMultilineEntry *e, void (*f)(uiMultilineEntry *e, void *data), void *data);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiMultilineEntryOnChanged(IntPtr e, uiMultilineEntryOnChanged_f f, IntPtr data);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiMultilineEntryOnChanged_f(IntPtr e, IntPtr data);

            // _UI_EXTERN int uiMultilineEntryReadOnly(uiMultilineEntry *e);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate bool uiMultilineEntryReadOnly(IntPtr e);

            // _UI_EXTERN void uiMultilineEntrySetReadOnly(uiMultilineEntry *e, int readonly);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiMultilineEntrySetReadOnly(IntPtr e, bool @readonly);

            // _UI_EXTERN uiMultilineEntry *uiNewMultilineEntry(void);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate IntPtr uiNewMultilineEntry();

            // _UI_EXTERN uiMultilineEntry *uiNewNonWrappingMultilineEntry(void);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate IntPtr uiNewNonWrappingMultilineEntry();

            // _UI_EXTERN void uiMenuItemEnable(uiMenuItem *m);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiMenuItemEnable(IntPtr m);

            // _UI_EXTERN void uiMenuItemDisable(uiMenuItem *m);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiMenuItemDisable(IntPtr m);

            // _UI_EXTERN void uiMenuItemOnClicked(uiMenuItem *m, void (*f)(uiMenuItem *sender, uiWindow *window, void *data), void *data);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiMenuItemOnClicked(IntPtr m, uiMenuItemOnClicked_f f, IntPtr data);
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void uiMenuItemOnClicked_f(IntPtr menuItem, IntPtr window, IntPtr data);

            // _UI_EXTERN int uiMenuItemChecked(uiMenuItem *m);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate bool uiMenuItemChecked(IntPtr m);

            // _UI_EXTERN void uiMenuItemSetChecked(uiMenuItem *m, int checked);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiMenuItemSetChecked(IntPtr m, bool @checked);

            // _UI_EXTERN uiMenuItem *uiMenuAppendItem(uiMenu *m, const char *name);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate IntPtr uiMenuAppendItem(IntPtr m, string name);

            // _UI_EXTERN uiMenuItem *uiMenuAppendCheckItem(uiMenu *m, const char *name);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate IntPtr uiMenuAppendCheckItem(IntPtr m, string name);

            // _UI_EXTERN uiMenuItem *uiMenuAppendQuitItem(uiMenu *m);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate IntPtr uiMenuAppendQuitItem(IntPtr m);

            // _UI_EXTERN uiMenuItem *uiMenuAppendPreferencesItem(uiMenu *m);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate IntPtr uiMenuAppendPreferencesItem(IntPtr m);

            // _UI_EXTERN uiMenuItem *uiMenuAppendAboutItem(uiMenu *m);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate IntPtr uiMenuAppendAboutItem(IntPtr m);

            // _UI_EXTERN void uiMenuAppendSeparator(uiMenu *m);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiMenuAppendSeparator(IntPtr m);

            // _UI_EXTERN uiMenu *uiNewMenu(const char *name);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate IntPtr uiNewMenu(string name);

            // _UI_EXTERN char *uiOpenFile(uiWindow *parent);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate string uiOpenFile(IntPtr parent);

            // _UI_EXTERN char *uiSaveFile(uiWindow *parent);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate string uiSaveFile(IntPtr parent);

            // _UI_EXTERN void uiMsgBox(uiWindow *parent, const char *title, const char *description);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiMsgBox(IntPtr parent, string title, string description);

            // _UI_EXTERN void uiMsgBoxError(uiWindow *parent, const char *title, const char *description);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiMsgBoxError(IntPtr parent, string title, string description);

            // ========================================================================



            // _UI_EXTERN void uiColorButtonColor(uiColorButton* b, double* r, double* g, double* bl, double* a);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiColorButtonColor(IntPtr b, out double red, out double green, out double blue, out double alpha);

            // _UI_EXTERN void uiColorButtonSetColor(uiColorButton* b, double r, double g, double bl, double a);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiColorButtonSetColor(IntPtr b, double red, double green, double blue, double alpha);

            // _UI_EXTERN void uiColorButtonOnChanged(uiColorButton* b, void (* f)(uiColorButton*, void*), void* data);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiColorButtonOnChanged(IntPtr b, uiColorButtonOnChanged_f f, IntPtr data);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiColorButtonOnChanged_f(IntPtr b, IntPtr data);

            // _UI_EXTERN uiColorButton *uiNewColorButton(void);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate IntPtr uiNewColorButton();

            // _UI_EXTERN void uiFormAppend(uiForm* f, const char* label, uiControl *c, int stretchy);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiFormAppend(IntPtr f, string label, IntPtr c, bool stretchy);

            // _UI_EXTERN void uiFormDelete(uiForm* f, int index);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiFormDelete(IntPtr f, int index);

            // _UI_EXTERN int uiFormPadded(uiForm* f);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate bool uiFormPadded(IntPtr f);

            // _UI_EXTERN void uiFormSetPadded(uiForm* f, int padded);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiFormSetPadded(IntPtr f, bool padded);

            // _UI_EXTERN uiForm *uiNewForm(void);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate IntPtr uiNewForm();

            // _UI_EXTERN void uiGridAppend(uiGrid* g, uiControl* c, int left, int top, int xspan, int yspan, int hexpand, uiAlign halign, int vexpand, uiAlign valign);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiGridAppend(IntPtr g, IntPtr c, int left, int top, int xspan, int yspan, int hexpand, AlignmentInternal halign, int vexpand, AlignmentInternal valign);

            // _UI_EXTERN void uiGridInsertAt(uiGrid* g, uiControl* c, uiControl* existing, uiAt at, int xspan, int yspan, int hexpand, uiAlign halign, int vexpand, uiAlign valign);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiGridInsertAt(IntPtr g, IntPtr c, IntPtr existing, RelativeAlignment at, int xspan, int yspan, int hexpand, AlignmentInternal halign, int vexpand, AlignmentInternal valign);

            // _UI_EXTERN int uiGridPadded(uiGrid* g);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate bool uiGridPadded(IntPtr g);

            // _UI_EXTERN void uiGridSetPadded(uiGrid* g, int padded);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiGridSetPadded(IntPtr g, bool padded);

            // _UI_EXTERN uiGrid *uiNewGrid(void);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate IntPtr uiNewGrid();
        }
    }
}