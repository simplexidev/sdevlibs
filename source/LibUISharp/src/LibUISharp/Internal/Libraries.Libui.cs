using System;
using System.Runtime.InteropServices;
using LibUISharp.Drawing;
using NativeLibraryLoader;

namespace LibUISharp.Internal
{
    internal static partial class Libraries
    {
        internal static class Libui
        {
            internal const CallingConvention Convention = CallingConvention.Cdecl;
            internal const LayoutKind StructLayout = LayoutKind.Sequential;

            private static NativeLibrary Library
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
            internal static T Call<T>(string name) => NativeCall<T>(Library, name);

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

            // _UI_EXTERN void uiAreaSetSize(uiArea *a, int width, int height);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiAreaSetSize(IntPtr a, int width, int height);

            // _UI_EXTERN void uiAreaQueueRedrawAll(uiArea *a);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiAreaQueueRedrawAll(IntPtr a);

            // _UI_EXTERN void uiAreaScrollTo(uiArea *a, double x, double y, double width, double height);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiAreaScrollTo(IntPtr a, double x, double y, double width, double height);

            // _UI_EXTERN void uiAreaBeginUserWindowMove(uiArea *a);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiAreaBeginUserWindowMove(IntPtr a);

            // _UI_EXTERN void uiAreaBeginUserWindowResize(uiArea *a, uiWindowResizeEdge edge);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiAreaBeginUserWindowResize(IntPtr a, WindowEdge edge);

            // _UI_EXTERN uiArea *uiNewArea(uiAreaHandler *ah);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate IntPtr uiNewArea(NativeSurfaceHandler ah);

            // _UI_EXTERN uiArea *uiNewScrollingArea(uiAreaHandler *ah, int width, int height);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate IntPtr uiNewScrollingArea(NativeSurfaceHandler ah, int width, int height);

            // ========================================================================
            // ============IMPLEMENTATIONS FOR CALLS BELOW ARE NOT FINISHED============
            // ========================================================================

            // _UI_EXTERN uiDrawPath *uiDrawNewPath(uiDrawFillMode fillMode);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate IntPtr uiDrawNewPath(FillMode fillMode);

            // _UI_EXTERN void uiDrawFreePath(uiDrawPath *p);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiDrawFreePath(IntPtr p);

            // _UI_EXTERN void uiDrawPathNewFigure(uiDrawPath *p, double x, double y);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiDrawPathNewFigure(IntPtr p, double x, double y);

            // _UI_EXTERN void uiDrawPathNewFigureWithArc(uiDrawPath *p, double xCenter, double yCenter, double radius, double startAngle, double sweep, int negative);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiDrawPathNewFigureWithArc(IntPtr p, double xCenter, double yCenter, double radius, double startAngle, double sweep, bool negative);

            // _UI_EXTERN void uiDrawPathLineTo(uiDrawPath *p, double x, double y);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiDrawPathLineTo(IntPtr p, double x, double y);

            // _UI_EXTERN void uiDrawPathArcTo(uiDrawPath *p, double xCenter, double yCenter, double radius, double startAngle, double sweep, int negative);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiDrawPathArcTo(IntPtr p, double xCenter, double yCenter, double radius, double startAngle, double sweep, bool negative);

            // _UI_EXTERN void uiDrawPathBezierTo(uiDrawPath *p, double c1x, double c1y, double c2x, double c2y, double endX, double endY);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiDrawPathBezierTo(IntPtr p, double c1x, double c1y, double c2x, double c2y, double endX, double endY);

            // _UI_EXTERN void uiDrawPathCloseFigure(uiDrawPath *p);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiDrawPathCloseFigure(IntPtr p);

            // _UI_EXTERN void uiDrawPathAddRectangle(uiDrawPath *p, double x, double y, double width, double height);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiDrawPathAddRectangle(IntPtr p, double x, double y, double width, double height);

            // _UI_EXTERN void uiDrawPathEnd(uiDrawPath *p);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiDrawPathEnd(IntPtr p);

            // _UI_EXTERN void uiDrawStroke(uiDrawContext* c, uiDrawPath* path, uiDrawBrush* b, uiDrawStrokeParams* p);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiDrawStroke(IntPtr context, IntPtr path, ref uiDrawBrush brush, ref uiDrawStrokeParams strokeParam);

            // _UI_EXTERN void uiDrawFill(uiDrawContext* c, uiDrawPath* path, uiDrawBrush* b);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiDrawFill(IntPtr context, IntPtr path, ref uiDrawBrush brush);

            // _UI_EXTERN void uiDrawMatrixSetIdentity(uiDrawMatrix* m);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiDrawMatrixSetIdentity(Matrix matrix);

            // _UI_EXTERN void uiDrawMatrixTranslate(uiDrawMatrix* m, double x, double y);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiDrawMatrixTranslate(Matrix matrix, double x, double y);

            // _UI_EXTERN void uiDrawMatrixScale(uiDrawMatrix* m, double xCenter, double yCenter, double x, double y);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiDrawMatrixScale(Matrix matrix, double xCenter, double yCenter, double x, double y);

            // _UI_EXTERN void uiDrawMatrixRotate(uiDrawMatrix* m, double x, double y, double amount);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiDrawMatrixRotate(Matrix matrix, double x, double y, double amount);

            // _UI_EXTERN void uiDrawMatrixSkew(uiDrawMatrix* m, double x, double y, double xamount, double yamount);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiDrawMatrixSkew(Matrix matrix, double x, double y, double xamount, double yamount);

            // _UI_EXTERN void uiDrawMatrixMultiply(uiDrawMatrix* dest, uiDrawMatrix* src);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiDrawMatrixMultiply(Matrix dest, Matrix src);

            // _UI_EXTERN int uiDrawMatrixInvertible(uiDrawMatrix* m);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate bool uiDrawMatrixInvertible(Matrix matrix);

            // _UI_EXTERN int uiDrawMatrixInvert(uiDrawMatrix* m);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate int uiDrawMatrixInvert(Matrix matrix);

            // _UI_EXTERN void uiDrawMatrixTransformPoint(uiDrawMatrix* m, double* x, double* y);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiDrawMatrixTransformPoint(Matrix matrix, out double x, out double y);

            // _UI_EXTERN void uiDrawMatrixTransformSize(uiDrawMatrix* m, double* x, double* y);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiDrawMatrixTransformSize(Matrix matrix, out double x, out double y);

            // _UI_EXTERN void uiDrawTransform(uiDrawContext* c, uiDrawMatrix* m);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiDrawTransform(IntPtr context, Matrix matrix);

            // _UI_EXTERN void uiDrawClip(uiDrawContext* c, uiDrawPath* path);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiDrawClip(IntPtr context, IntPtr path);

            // _UI_EXTERN void uiDrawSave(uiDrawContext* c);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiDrawSave(IntPtr context);

            // _UI_EXTERN void uiDrawRestore(uiDrawContext* c);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiDrawRestore(IntPtr context);

            // _UI_EXTERN void uiFreeAttribute(uiAttribute *a);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiFreeAttribute(IntPtr a);

            // _UI_EXTERN uiAttributeType uiAttributeGetType(const uiAttribute *a);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate uiAttributeType uiAttributeGetType(IntPtr a);

            // _UI_EXTERN uiAttribute *uiNewFamilyAttribute(const char *family);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate IntPtr uiNewFamilyAttribute(string family);

            // _UI_EXTERN const char *uiAttributeFamily(const uiAttribute *a);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate string uiAttributeFamily(IntPtr a);

            // _UI_EXTERN uiAttribute *uiNewSizeAttribute(double size);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate IntPtr uiNewSizeAttribute(double size);

            // _UI_EXTERN double uiAttributeSize(const uiAttribute *a);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate double uiAttributeSize(IntPtr a);

            // _UI_EXTERN uiAttribute *uiNewWeightAttribute(uiTextWeight weight);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate IntPtr uiNewWeightAttribute(FontWeight weight);

            // _UI_EXTERN uiTextWeight uiAttributeWeight(const uiAttribute *a);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate FontWeight uiAttributeWeight(IntPtr a);

            // _UI_EXTERN uiAttribute *uiNewItalicAttribute(uiTextItalic italic);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate IntPtr uiNewItalicAttribute(FontStyle italic);

            // _UI_EXTERN uiTextItalic uiAttributeItalic(const uiAttribute *a);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate FontStyle uiAttributeItalic(IntPtr a);

            // _UI_EXTERN uiAttribute *uiNewStretchAttribute(uiTextStretch stretch);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate IntPtr uiNewStretchAttribute(FontStretch stretch);

            // _UI_EXTERN uiTextStretch uiAttributeStretch(const uiAttribute *a);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate FontStretch uiAttributeStretch(IntPtr a);

            // _UI_EXTERN uiAttribute *uiNewColorAttribute(double r, double g, double b, double a);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate IntPtr uiNewColorAttribute(double r, double g, double b, double a);

            // _UI_EXTERN void uiAttributeColor(const uiAttribute *a, double *r, double *g, double *b, double *alpha);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiAttributeColor(IntPtr a, out double r, out double g, out double b, out double alpha);

            // _UI_EXTERN uiAttribute *uiNewBackgroundAttribute(double r, double g, double b, double a);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate IntPtr uiNewBackgroundAttribute(double r, double g, double b, double a);

            // _UI_EXTERN uiAttribute *uiNewUnderlineAttribute(uiUnderline u);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate IntPtr uiNewUnderlineAttribute(UnderlineStyle u);

            // _UI_EXTERN uiUnderline uiAttributeUnderline(const uiAttribute *a);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate UnderlineStyle uiAttributeUnderline(IntPtr a);

            // _UI_EXTERN uiAttribute *uiNewUnderlineColorAttribute(uiUnderlineColor u, double r, double g, double b, double a);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate IntPtr uiNewUnderlineColorAttribute(UnderlineColor u, double r, double g, double b, double a);

            // _UI_EXTERN void uiAttributeUnderlineColor(const uiAttribute *a, uiUnderlineColor *u, double *r, double *g, double *b, double *alpha);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiAttributeUnderlineColor(IntPtr a, out UnderlineColor u, out double r, out double g, out double b, out double alpha);

            // typedef uiForEach (*uiOpenTypeFeaturesForEachFunc)(const uiOpenTypeFeatures *otf, char a, char b, char c, char d, uint32 value, void *data);
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate uiForEach uiOpenTypeFeaturesForEachFunc(IntPtr otf, char a, char b, char c, char d, uint value, IntPtr data);

            // _UI_EXTERN uiOpenTypeFeatures *uiNewOpenTypeFeatures(void);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate IntPtr uiNewOpenTypeFeatures();

            // _UI_EXTERN void uiFreeOpenTypeFeatures(uiOpenTypeFeatures *otf);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiFreeOpenTypeFeatures(IntPtr otf);

            // _UI_EXTERN uiOpenTypeFeatures *uiOpenTypeFeaturesClone(const uiOpenTypeFeatures *otf);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate IntPtr uiOpenTypeFeaturesClone(IntPtr otf);

            // _UI_EXTERN void uiOpenTypeFeaturesAdd(uiOpenTypeFeatures *otf, char a, char b, char c, char d, uint32 value);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiOpenTypeFeaturesAdd(IntPtr otf, char a, char b, char c, char d, uint value);

            // _UI_EXTERN void uiOpenTypeFeaturesRemove(uiOpenTypeFeatures *otf, char a, char b, char c, char d);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiOpenTypeFeaturesRemove(IntPtr otf, char a, char b, char c, char d);

            // _UI_EXTERN int uiOpenTypeFeaturesGet(const uiOpenTypeFeatures *otf, char a, char b, char c, char d, uint32 *value);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate int uiOpenTypeFeaturesGet(IntPtr otf, char a, char b, char c, char d, out uint value);

            // _UI_EXTERN void uiOpenTypeFeaturesForEach(const uiOpenTypeFeatures *otf, uiOpenTypeFeaturesForEachFunc f, void *data);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiOpenTypeFeaturesForEach(IntPtr otf, uiOpenTypeFeaturesForEachFunc f, IntPtr data);

            // _UI_EXTERN uiAttribute *uiNewFeaturesAttribute(const uiOpenTypeFeatures *otf);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate IntPtr uiNewFeaturesAttribute(IntPtr otf);

            // _UI_EXTERN const uiOpenTypeFeatures *uiAttributeFeatures(const uiAttribute *a);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate IntPtr uiAttributeFeatures(IntPtr a);

            // typedef uiForEach(*uiAttributedStringForEachAttributeFunc)(const uiAttributedString* s, const uiAttribute* a, size start, size end, void* data);
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate uiForEach uiAttributedStringForEachAttributeFunc(IntPtr s, IntPtr a, UIntPtr start, UIntPtr end, IntPtr data);

            // _UI_EXTERN uiAttributedString *uiNewAttributedString(const char* initialString);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate IntPtr uiNewAttributedString(string initialString);

            // _UI_EXTERN void uiFreeAttributedString(uiAttributedString* s);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiFreeAttributedString(IntPtr s);

            // _UI_EXTERN const char* uiAttributedStringString(const uiAttributedString* s);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate string uiAttributedStringString(IntPtr s);

            // _UI_EXTERN size uiAttributedStringLen(const uiAttributedString* s);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate UIntPtr uiAttributedStringLen(IntPtr s);

            // _UI_EXTERN void uiAttributedStringAppendUnattributed(uiAttributedString* s, const char* str);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiAttributedStringAppendUnattributed(IntPtr s, IntPtr str);

            // _UI_EXTERN void uiAttributedStringInsertAtUnattributed(uiAttributedString* s, const char* str, size at);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiAttributedStringInsertAtUnattributed(IntPtr s, IntPtr str, UIntPtr at);

            // _UI_EXTERN void uiAttributedStringDelete(uiAttributedString* s, size start, size end);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiAttributedStringDelete(IntPtr s, UIntPtr start, UIntPtr end);

            // _UI_EXTERN void uiAttributedStringSetAttribute(uiAttributedString* s, uiAttribute* a, size start, size end);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiAttributedStringSetAttribute(IntPtr s, IntPtr a, UIntPtr start, UIntPtr end);

            // _UI_EXTERN void uiAttributedStringForEachAttribute(const uiAttributedString* s, uiAttributedStringForEachAttributeFunc f, void* data);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiAttributedStringForEachAttribute(IntPtr s, uiAttributedStringForEachAttributeFunc f, IntPtr data);

            // _UI_EXTERN size uiAttributedStringNumGraphemes(uiAttributedString* s);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate UIntPtr uiAttributedStringNumGraphemes(IntPtr s);

            // _UI_EXTERN size uiAttributedStringByteIndexToGrapheme(uiAttributedString* s, size pos);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate UIntPtr uiAttributedStringByteIndexToGrapheme(IntPtr s, UIntPtr pos);

            // _UI_EXTERN size uiAttributedStringGraphemeToByteIndex(uiAttributedString* s, size pos);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate UIntPtr uiAttributedStringGraphemeToByteIndex(IntPtr s, UIntPtr pos);

            // _UI_EXTERN uiDrawTextLayout *uiDrawNewTextLayout(uiDrawTextLayoutParams *params);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate IntPtr uiDrawNewTextLayout(uiDrawTextLayoutParams param);

            // _UI_EXTERN void uiDrawFreeTextLayout(uiDrawTextLayout *tl);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiDrawFreeTextLayout(IntPtr tl);

            // _UI_EXTERN void uiDrawText(uiDrawContext *c, uiDrawTextLayout *tl, double x, double y);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiDrawText(IntPtr c, IntPtr tl, double x, double y);

            // _UI_EXTERN void uiDrawTextLayoutExtents(uiDrawTextLayout *tl, double *width, double *height);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiDrawTextLayoutExtents(IntPtr tl, out double width, out double height);

            // ========================================================================
            // ============IMPLEMENTATIONS FOR CALLS ABOVE ARE NOT FINISHED============
            // ========================================================================

            // _UI_EXTERN void uiFontButtonFont(uiFontButton *b, uiFontDescriptor *desc);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiFontButtonFont(IntPtr b, out Font desc);

            // _UI_EXTERN void uiFontButtonOnChanged(uiFontButton *b, void (*f)(uiFontButton *, void *), void *data);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiFontButtonOnChanged(IntPtr b, uiFontButtonOnChanged_f f, IntPtr data);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiFontButtonOnChanged_f(IntPtr b, IntPtr data);

            // _UI_EXTERN uiFontButton *uiNewFontButton(void);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate IntPtr uiNewFontButton();

            // _UI_EXTERN void uiFreeFontButtonFont(uiFontDescriptor *desc);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiFreeFontButtonFont(Font desc);

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
            internal delegate void uiGridAppend(IntPtr g, IntPtr c, int left, int top, int xspan, int yspan, int hexpand, NativeAlignment halign, int vexpand, NativeAlignment valign);

            // _UI_EXTERN void uiGridInsertAt(uiGrid* g, uiControl* c, uiControl* existing, uiAt at, int xspan, int yspan, int hexpand, uiAlign halign, int vexpand, uiAlign valign);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiGridInsertAt(IntPtr g, IntPtr c, IntPtr existing, RelativeAlignment at, int xspan, int yspan, int hexpand, NativeAlignment halign, int vexpand, NativeAlignment valign);

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