using System;
using System.Runtime.InteropServices;
using LibUISharp.Drawing;

namespace LibUISharp.Internal
{
    internal static partial class UI
    {
        public const string LibUI = "libui";
        public const CallingConvention Cdecl = CallingConvention.Cdecl;
        
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern IntPtr uiInit(ref uiInitOptions options);
        // _UI_EXTERN const char* uiInit(uiInitOptions * options);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiUnInit();
        // _UI_EXTERN void uiUninit(void);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiFreeInitError(IntPtr error);
        // _UI_EXTERN void uiFreeInitError(const char* err);

        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiMain();
        // _UI_EXTERN void uiMain(void);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiMainSteps();
        // _UI_EXTERN void uiMainSteps(void);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern bool uiMainStep(bool wait);
        // _UI_EXTERN int uiMainStep(int wait);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiQuit();
        // _UI_EXTERN void uiQuit(void);

        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiQueueMain(uiQueueMainDelegate queueMain, IntPtr data);
        // _UI_EXTERN void uiQueueMain(void (* f)(void* data), void* data);

        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiOnShouldQuit(uiOnShouldQuitDelegate onShouldQuit, IntPtr data);
        // _UI_EXTERN void uiOnShouldQuit(int (* f)(void* data), void* data);

        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiFreeText(IntPtr text);
        // _UI_EXTERN void uiFreeText(char* text);
        
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiControlDestroy(IntPtr control);
        // _UI_EXTERN void uiControlDestroy(uiControl*);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern UIntPtr uiControlHandle(IntPtr control);
        // _UI_EXTERN uintptr_t uiControlHandle(uiControl*);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern IntPtr uiControlParent(IntPtr control);
        // _UI_EXTERN uiControl *uiControlParent(uiControl*);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiControlSetParent(IntPtr control, IntPtr parent);
        // _UI_EXTERN void uiControlSetParent(uiControl*, uiControl*);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern bool uiControlTopLevel(IntPtr control);
        // _UI_EXTERN int uiControlToplevel(uiControl*);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern bool uiControlVisible(IntPtr control);
        // _UI_EXTERN int uiControlVisible(uiControl*);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiControlShow(IntPtr control);
        // _UI_EXTERN void uiControlShow(uiControl*);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiControlHide(IntPtr control);
        // _UI_EXTERN void uiControlHide(uiControl*);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern bool uiControlEnabled(IntPtr control);
        // _UI_EXTERN int uiControlEnabled(uiControl*);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiControlEnable(IntPtr control);
        // _UI_EXTERN void uiControlEnable(uiControl*);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiControlDisable(IntPtr control);
        // _UI_EXTERN void uiControlDisable(uiControl*);

        //// [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        //// public static extern IntPtr uiAllocControl(UIntPtr size, uint osSignature, uint typeSignature, IntPtr typeName);
        // _UI_EXTERN uiControl *uiAllocControl(size_t n, uint32_t OSsig, uint32_t typesig, const char* typenamestr);
        //// [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        //// public static extern void uiFreeControl(IntPtr control);
        // _UI_EXTERN void uiFreeControl(uiControl*);

        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiControlVerifySetParent(IntPtr control, IntPtr parent);
        // _UI_EXTERN void uiControlVerifySetParent(uiControl*, uiControl*);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern bool uiControlEnabledToUser(IntPtr control);
        // _UI_EXTERN int uiControlEnabledToUser(uiControl*);

        //// [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        //// public static extern bool uiUserBugCannotSetParentOnTopLevel(IntPtr type);
        // _UI_EXTERN int uiUserBugCannotSetParentOnTopLevel(const char *type);

        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern IntPtr uiWindowTitle(IntPtr window);
        // _UI_EXTERN char* uiWindowTitle(uiWindow* w);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiWindowSetTitle(IntPtr window, IntPtr title);
        // _UI_EXTERN void uiWindowSetTitle(uiWindow* w, const char* title);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiWindowContentSize(IntPtr window, out int width, out int height);
        // _UI_EXTERN void uiWindowContentSize(uiWindow* w, int* width, int* height);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiWindowSetContentSize(IntPtr window, int width, int height);
        // _UI_EXTERN void uiWindowSetContentSize(uiWindow* w, int width, int height);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern bool uiWindowFullscreen(IntPtr window);
        // _UI_EXTERN int uiWindowFullscreen(uiWindow* w);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiWindowSetFullscreen(IntPtr window, bool fullscreen);
        // _UI_EXTERN void uiWindowSetFullscreen(uiWindow* w, int fullscreen);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiWindowOnContentSizeChanged(IntPtr window, uiWindowOnContentSizeChangedDelegate onContentSizeChanged, IntPtr data);
        // _UI_EXTERN void uiWindowOnSizeChanged(uiWindow* w, void (* f)(uiWindow*, void*), void* data);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiWindowOnClosing(IntPtr window, uiWindowOnClosingDelegate onClosing, IntPtr data);
        // _UI_EXTERN void uiWindowOnClosing(uiWindow* w, int (* f)(uiWindow* w, void* data), void* data);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern bool uiWindowBorderless(IntPtr window);
        // _UI_EXTERN int uiWindowBorderless(uiWindow* w);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiWindowSetBorderless(IntPtr window, bool borderless);
        // _UI_EXTERN void uiWindowSetBorderless(uiWindow* w, int borderless);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiWindowSetChild(IntPtr window, IntPtr child);
        // _UI_EXTERN void uiWindowSetChild(uiWindow* w, uiControl* child);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern bool uiWindowMargined(IntPtr window);
        // _UI_EXTERN int uiWindowMargined(uiWindow* w);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiWindowSetMargined(IntPtr window, bool margined);
        // _UI_EXTERN void uiWindowSetMargined(uiWindow* w, int margined);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewWindow(IntPtr title, int width, int height, bool hasMenubar);
        // _UI_EXTERN uiWindow *uiNewWindow(const char* title, int width, int height, int hasMenubar);
        
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern IntPtr uiButtonText(IntPtr button);
        // _UI_EXTERN char* uiButtonText(uiButton* b);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiButtonSetText(IntPtr button, IntPtr text);
        // _UI_EXTERN void uiButtonSetText(uiButton* b, const char* text);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiButtonOnClicked(IntPtr button, uiButtonOnClickedDelegate buttonOnClicked, IntPtr data);
        // _UI_EXTERN void uiButtonOnClicked(uiButton* b, void (* f)(uiButton* b, void* data), void* data);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewButton(IntPtr text);
        // _UI_EXTERN uiButton *uiNewButton(const char* text);
        
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiBoxAppend(IntPtr parent, IntPtr child, bool stretchy);
        // _UI_EXTERN void uiBoxAppend(uiBox* b, uiControl* child, int stretchy);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiBoxDelete(IntPtr parent, int index);
        // _UI_EXTERN void uiBoxDelete(uiBox* b, int index);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern bool uiBoxPadded(IntPtr box);
        // _UI_EXTERN int uiBoxPadded(uiBox* b);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiBoxSetPadded(IntPtr box, bool padded);
        // _UI_EXTERN void uiBoxSetPadded(uiBox* b, int padded);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewHorizontalBox();
        // _UI_EXTERN uiBox *uiNewHorizontalBox(void);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewVerticalBox();
        // _UI_EXTERN uiBox *uiNewVerticalBox(void);
        
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern IntPtr uiCheckboxText(IntPtr checkBox);
        // _UI_EXTERN char* uiCheckboxText(uiCheckbox* c);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiCheckboxSetText(IntPtr checkBox, IntPtr text);
        // _UI_EXTERN void uiCheckboxSetText(uiCheckbox* c, const char* text);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiCheckboxOnToggled(IntPtr checkBox, uiCheckboxOnToggledDelegate checkBoxOnToggled, IntPtr data);
        // _UI_EXTERN void uiCheckboxOnToggled(uiCheckbox* c, void (* f)(uiCheckbox* c, void* data), void* data);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern bool uiCheckboxChecked(IntPtr checkBox);
        // _UI_EXTERN int uiCheckboxChecked(uiCheckbox* c);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiCheckboxSetChecked(IntPtr checkBox, bool check);
        // _UI_EXTERN void uiCheckboxSetChecked(uiCheckbox* c, int checked);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewCheckbox(IntPtr text);
        // _UI_EXTERN uiCheckbox *uiNewCheckbox(const char* text);
        
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern IntPtr uiEntryText(IntPtr entry);
        // _UI_EXTERN char* uiEntryText(uiEntry* e);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiEntrySetText(IntPtr entry, IntPtr text);
        // _UI_EXTERN void uiEntrySetText(uiEntry* e, const char* text);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiEntryOnChanged(IntPtr entry, uiEntryOnChangedDelegate entryOnChanged, IntPtr data);
        // _UI_EXTERN void uiEntryOnChanged(uiEntry* e, void (* f)(uiEntry* e, void* data), void* data);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern bool uiEntryReadOnly(IntPtr entry);
        // _UI_EXTERN int uiEntryReadOnly(uiEntry* e);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiEntrySetReadOnly(IntPtr entry, bool isReadOnly);
        // _UI_EXTERN void uiEntrySetReadOnly(uiEntry* e, int readonly);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewEntry();
        // _UI_EXTERN uiEntry *uiNewEntry(void);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewPasswordEntry();
        // _UI_EXTERN uiEntry *uiNewPasswordEntry(void);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewSearchEntry();
        // _UI_EXTERN uiEntry *uiNewSearchEntry(void);
        
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern IntPtr uiLabelText(IntPtr label);
        // _UI_EXTERN char* uiLabelText(uiLabel* l);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiLabelSetText(IntPtr label, IntPtr text);
        // _UI_EXTERN void uiLabelSetText(uiLabel* l, const char* text);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewLabel(IntPtr text);
        // _UI_EXTERN uiLabel *uiNewLabel(const char* text);
        
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiTabAppend(IntPtr tab, IntPtr name, IntPtr child);
        // _UI_EXTERN void uiTabAppend(uiTab* t, const char* name, uiControl *c);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiTabInsertAt(IntPtr tab, IntPtr name, int before, IntPtr child);
        // _UI_EXTERN void uiTabInsertAt(uiTab* t, const char* name, int before, uiControl *c);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiTabDelete(IntPtr tab, int index);
        // _UI_EXTERN void uiTabDelete(uiTab* t, int index);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern int uiTabNumPages(IntPtr tab);
        // _UI_EXTERN int uiTabNumPages(uiTab* t);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern bool uiTabMargined(IntPtr tab, int page);
        // _UI_EXTERN int uiTabMargined(uiTab* t, int page);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiTabSetMargined(IntPtr tab, int page, bool margined);
        // _UI_EXTERN void uiTabSetMargined(uiTab* t, int page, int margined);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewTab();
        // _UI_EXTERN uiTab *uiNewTab(void);
        
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern IntPtr uiGroupTitle(IntPtr group);
        // _UI_EXTERN char* uiGroupTitle(uiGroup* g);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiGroupSetTitle(IntPtr group, IntPtr title);
        // _UI_EXTERN void uiGroupSetTitle(uiGroup* g, const char* title);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiGroupSetChild(IntPtr group, IntPtr child);
        // _UI_EXTERN void uiGroupSetChild(uiGroup* g, uiControl* c);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern bool uiGroupMargined(IntPtr group);
        // _UI_EXTERN int uiGroupMargined(uiGroup* g);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiGroupSetMargined(IntPtr group, bool margined);
        // _UI_EXTERN void uiGroupSetMargined(uiGroup* g, int margined);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewGroup(IntPtr title);
        // _UI_EXTERN uiGroup *uiNewGroup(const char* title);
        
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern int uiSpinboxValue(IntPtr spinBox);
        // _UI_EXTERN int uiSpinboxValue(uiSpinbox* s);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiSpinboxSetValue(IntPtr spinBox, int value);
        // _UI_EXTERN void uiSpinboxSetValue(uiSpinbox* s, int value);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiSpinboxOnChanged(IntPtr spinBox, uiSpinBoxOnChangedDelegate spinBoxOnChanged, IntPtr data);
        // _UI_EXTERN void uiSpinboxOnChanged(uiSpinbox* s, void (* f)(uiSpinbox* s, void* data), void* data);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewSpinbox(int min, int max);
        // _UI_EXTERN uiSpinbox *uiNewSpinbox(int min, int max);
        
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern int uiSliderValue(IntPtr slider);
        // _UI_EXTERN int uiSliderValue(uiSlider* s);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiSliderSetValue(IntPtr slider, int value);
        // _UI_EXTERN void uiSliderSetValue(uiSlider* s, int value);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiSliderOnChanged(IntPtr slider, uiSliderOnChangedDelegate sliderOnChanged, IntPtr data);
        // _UI_EXTERN void uiSliderOnChanged(uiSlider* s, void (* f)(uiSlider* s, void* data), void* data);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewSlider(int min, int max);
        // _UI_EXTERN uiSlider *uiNewSlider(int min, int max);
        
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern int uiProgressBarValue(IntPtr progressBar);
        // _UI_EXTERN int uiProgressBarValue(uiProgressBar* p);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiProgressBarSetValue(IntPtr progressBar, int number);
        // _UI_EXTERN void uiProgressBarSetValue(uiProgressBar* p, int n);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewProgressBar();
        // _UI_EXTERN uiProgressBar *uiNewProgressBar(void);
        
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewHorizontalSeparator();
        // _UI_EXTERN uiSeparator *uiNewHorizontalSeparator(void);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewVerticalSeparator();
        // _UI_EXTERN uiSeparator *uiNewVerticalSeparator(void);
        
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiComboboxAppend(IntPtr comboBox, IntPtr text);
        // _UI_EXTERN void uiComboboxAppend(uiCombobox* c, const char* text);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern int uiComboboxSelected(IntPtr comboBox);
        // _UI_EXTERN int uiComboboxSelected(uiCombobox* c);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiComboboxSetSelected(IntPtr comboBox, int n);
        // _UI_EXTERN void uiComboboxSetSelected(uiCombobox* c, int n);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiComboboxOnSelected(IntPtr comboBox, uiComboboxOnSelectedDelegate comboBoxOnSelected, IntPtr data);
        // _UI_EXTERN void uiComboboxOnSelected(uiCombobox* c, void (* f)(uiCombobox* c, void* data), void* data);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewCombobox();
        // _UI_EXTERN uiCombobox *uiNewCombobox(void);
        
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiEditableComboboxAppend(IntPtr comboBox, IntPtr text);
        // _UI_EXTERN void uiEditableComboboxAppend(uiEditableCombobox* c, const char* text);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern IntPtr uiEditableComboboxText(IntPtr comboBox);
        // _UI_EXTERN char* uiEditableComboboxText(uiEditableCombobox* c);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiEditableComboboxSetText(IntPtr comboBox, IntPtr text);
        // _UI_EXTERN void uiEditableComboboxSetText(uiEditableCombobox* c, const char* text);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiEditableComboboxOnChanged(IntPtr comboBox, uiEditableComboboxOnChangedDelegate editableComboBoxOnChanged, IntPtr data);
        // _UI_EXTERN void uiEditableComboboxOnChanged(uiEditableCombobox* c, void (* f)(uiEditableCombobox* c, void* data), void* data);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewEditableCombobox();
        // _UI_EXTERN uiEditableCombobox *uiNewEditableCombobox(void);
        
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiRadioButtonsAppend(IntPtr radioButton, IntPtr text);
        // _UI_EXTERN void uiRadioButtonsAppend(uiRadioButtons* r, const char* text);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern int uiRadioButtonsSelected(IntPtr radioButton);
        // _UI_EXTERN int uiRadioButtonsSelected(uiRadioButtons* r);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiRadioButtonsSetSelected(IntPtr radioButton, int index);
        // _UI_EXTERN void uiRadioButtonsSetSelected(uiRadioButtons* r, int n);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiRadioButtonsOnSelected(IntPtr radioButton, uiRadioButtonsOnSelectedDelegate radioButtonOnSelected, IntPtr data);
        // _UI_EXTERN void uiRadioButtonsOnSelected(uiRadioButtons* r, void (* f)(uiRadioButtons*, void*), void* data);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewRadioButtons();
        // _UI_EXTERN uiRadioButtons *uiNewRadioButtons(void);
        
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewDateTimePicker();
        // _UI_EXTERN uiDateTimePicker *uiNewDateTimePicker(void);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewDatePicker();
        // _UI_EXTERN uiDateTimePicker *uiNewDatePicker(void);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewTimePicker();
        // _UI_EXTERN uiDateTimePicker *uiNewTimePicker(void);
        
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern IntPtr uiMultilineEntryText(IntPtr entry);
        // _UI_EXTERN char* uiMultilineEntryText(uiMultilineEntry* e);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiMultilineEntrySetText(IntPtr entry, IntPtr text);
        // _UI_EXTERN void uiMultilineEntrySetText(uiMultilineEntry* e, const char* text);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiMultilineEntryAppend(IntPtr entry, IntPtr text);
        // _UI_EXTERN void uiMultilineEntryAppend(uiMultilineEntry* e, const char* text);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiMultilineEntryOnChanged(IntPtr entry, uiMultilineEntryOnChangedDelegate multilineEntryOnChanged, IntPtr data);
        // _UI_EXTERN void uiMultilineEntryOnChanged(uiMultilineEntry* e, void (* f)(uiMultilineEntry* e, void* data), void* data);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern bool uiMultilineEntryReadOnly(IntPtr entry);
        // _UI_EXTERN int uiMultilineEntryReadOnly(uiMultilineEntry* e);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiMultilineEntrySetReadOnly(IntPtr entry, bool isReadOnly);
        // _UI_EXTERN void uiMultilineEntrySetReadOnly(uiMultilineEntry* e, int readonly);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewMultilineEntry();
        // _UI_EXTERN uiMultilineEntry *uiNewMultilineEntry(void);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewNonWrappingMultilineEntry();
        // _UI_EXTERN uiMultilineEntry *uiNewNonWrappingMultilineEntry(void);
        
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiMenuItemEnable(IntPtr menuItem);
        // _UI_EXTERN void uiMenuItemEnable(uiMenuItem* m);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiMenuItemDisable(IntPtr menuItem);
        // _UI_EXTERN void uiMenuItemDisable(uiMenuItem* m);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiMenuItemOnClicked(IntPtr menuItem, uiMenuItemOnClickedDelegate menuItemOnClicked, IntPtr data);
        // _UI_EXTERN void uiMenuItemOnClicked(uiMenuItem* m, void (* f)(uiMenuItem* sender, uiWindow* window, void* data), void* data);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern bool uiMenuItemChecked(IntPtr menuItem);
        // _UI_EXTERN int uiMenuItemChecked(uiMenuItem* m);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiMenuItemSetChecked(IntPtr menuItem, bool isChecked);
        // _UI_EXTERN void uiMenuItemSetChecked(uiMenuItem* m, int checked);
        
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern IntPtr uiMenuAppendItem(IntPtr menu, IntPtr name);
        // _UI_EXTERN uiMenuItem *uiMenuAppendItem(uiMenu* m, const char* name);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern IntPtr uiMenuAppendCheckItem(IntPtr menu, IntPtr name);
        // _UI_EXTERN uiMenuItem *uiMenuAppendCheckItem(uiMenu* m, const char* name);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern IntPtr uiMenuAppendQuitItem(IntPtr menu);
        // _UI_EXTERN uiMenuItem *uiMenuAppendQuitItem(uiMenu* m);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern IntPtr uiMenuAppendPreferencesItem(IntPtr menu);
        // _UI_EXTERN uiMenuItem *uiMenuAppendPreferencesItem(uiMenu* m);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern IntPtr uiMenuAppendAboutItem(IntPtr menu);
        // _UI_EXTERN uiMenuItem *uiMenuAppendAboutItem(uiMenu* m);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiMenuAppendSeparator(IntPtr menu);
        // _UI_EXTERN void uiMenuAppendSeparator(uiMenu* m);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewMenu(IntPtr name);
        // _UI_EXTERN uiMenu *uiNewMenu(const char* name);
        
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern IntPtr uiOpenFile(IntPtr parent);
        // _UI_EXTERN char* uiOpenFile(uiWindow* parent);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern IntPtr uiSaveFile(IntPtr parent);
        // _UI_EXTERN char* uiSaveFile(uiWindow* parent);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiMsgBox(IntPtr parent, IntPtr title, IntPtr description);
        // _UI_EXTERN void uiMsgBox(uiWindow* parent, const char* title, const char* description);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiMsgBoxError(IntPtr parent, IntPtr title, IntPtr description);
        // _UI_EXTERN void uiMsgBoxError(uiWindow* parent, const char* title, const char* description);
        
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiAreaSetSize(IntPtr area, int width, int height);
        // _UI_EXTERN void uiAreaSetSize(uiArea* a, int width, int height);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiAreaQueueReDrawAll(IntPtr area);
        // _UI_EXTERN void uiAreaQueueRedrawAll(uiArea* a);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiAreaScrollTo(IntPtr area, double x, double y, double width, double height);
        // _UI_EXTERN void uiAreaScrollTo(uiArea* a, double x, double y, double width, double height);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiAreaBeginUserWindowMove(IntPtr area);
        // _UI_EXTERN void uiAreaBeginUserWindowMove(uiArea* a);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiAreaBeginUserWindowResize(IntPtr area, WindowEdge edge);
        // _UI_EXTERN void uiAreaBeginUserWindowResize(uiArea* a, uiWindowResizeEdge edge);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewArea(uiAreaHandler ah);
        // _UI_EXTERN uiArea *uiNewArea(uiAreaHandler* ah);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewScrollingArea(uiAreaHandler ah, int width, int height);
        // _UI_EXTERN uiArea *uiNewScrollingArea(uiAreaHandler* ah, int width, int height);
        
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern IntPtr uiDrawNewPath(FillMode fillMode);
        // _UI_EXTERN uiDrawPath *uiDrawNewPath(uiDrawFillMode fillMode);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiDrawFreePath(IntPtr path);
        // _UI_EXTERN void uiDrawFreePath(uiDrawPath* p);

        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiDrawPathNewFigure(IntPtr path, double x, double y);
        // _UI_EXTERN void uiDrawPathNewFigure(uiDrawPath* p, double x, double y);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiDrawPathNewFigureWithArc(IntPtr path, double xCenter, double yCenter, double radius, double startAngle, double sweep, bool negative);
        // _UI_EXTERN void uiDrawPathNewFigureWithArc(uiDrawPath* p, double xCenter, double yCenter, double radius, double startAngle, double sweep, int negative);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiDrawPathLineTo(IntPtr path, double x, double y);
        // _UI_EXTERN void uiDrawPathLineTo(uiDrawPath* p, double x, double y);

        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiDrawPathArcTo(IntPtr path, double xCenter, double yCenter, double radius, double startAngle, double sweep, bool negative);
        // _UI_EXTERN void uiDrawPathArcTo(uiDrawPath* p, double xCenter, double yCenter, double radius, double startAngle, double sweep, int negative);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiDrawPathBezierTo(IntPtr path, double c1x, double c1y, double c2x, double c2y, double endX, double endY);
        // _UI_EXTERN void uiDrawPathBezierTo(uiDrawPath* p, double c1x, double c1y, double c2x, double c2y, double endX, double endY);

        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiDrawPathCloseFigure(IntPtr path);
        // _UI_EXTERN void uiDrawPathCloseFigure(uiDrawPath* p);

        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiDrawPathAddRectangle(IntPtr path, double x, double y, double width, double height);
        // _UI_EXTERN void uiDrawPathAddRectangle(uiDrawPath* p, double x, double y, double width, double height);

        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiDrawPathEnd(IntPtr path);
        // _UI_EXTERN void uiDrawPathEnd(uiDrawPath* p);

        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiDrawStroke(IntPtr context, IntPtr path, ref uiDrawBrush brush, ref uiDrawStrokeParams strokeParam);
        // _UI_EXTERN void uiDrawStroke(uiDrawContext* c, uiDrawPath* path, uiDrawBrush* b, uiDrawStrokeParams* p); double height);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiDrawFill(IntPtr context, IntPtr path, ref uiDrawBrush brush);
        // _UI_EXTERN void uiDrawFill(uiDrawContext* c, uiDrawPath* path, uiDrawBrush* b);
        
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiDrawMatrixSetIdentity(uiDrawMatrix matrix);
        // _UI_EXTERN void uiDrawMatrixSetIdentity(uiDrawMatrix* m);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiDrawMatrixTranslate(uiDrawMatrix matrix, double x, double y);
        // _UI_EXTERN void uiDrawMatrixTranslate(uiDrawMatrix* m, double x, double y);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiDrawMatrixScale(uiDrawMatrix matrix, double xCenter, double yCenter, double x, double y);
        // _UI_EXTERN void uiDrawMatrixScale(uiDrawMatrix* m, double xCenter, double yCenter, double x, double y);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiDrawMatrixRotate(uiDrawMatrix matrix, double x, double y, double amount);
        // _UI_EXTERN void uiDrawMatrixRotate(uiDrawMatrix* m, double x, double y, double amount);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiDrawMatrixSkew(uiDrawMatrix matrix, double x, double y, double xamount, double yamount);
        // _UI_EXTERN void uiDrawMatrixSkew(uiDrawMatrix* m, double x, double y, double xamount, double yamount);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiDrawMatrixMultiply(uiDrawMatrix dest, uiDrawMatrix src);
        // _UI_EXTERN void uiDrawMatrixMultiply(uiDrawMatrix* dest, uiDrawMatrix* src);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern bool uiDrawMatrixInvertible(uiDrawMatrix matrix);
        // _UI_EXTERN int uiDrawMatrixInvertible(uiDrawMatrix* m);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern int uiDrawMatrixInvert(uiDrawMatrix matrix);
        // _UI_EXTERN int uiDrawMatrixInvert(uiDrawMatrix* m);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiDrawMatrixTransformPoint(uiDrawMatrix matrix, out double x, out double y);
        // _UI_EXTERN void uiDrawMatrixTransformPoint(uiDrawMatrix* m, double* x, double* y);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiDrawMatrixTransformSize(uiDrawMatrix matrix, out double x, out double y);
        // _UI_EXTERN void uiDrawMatrixTransformSize(uiDrawMatrix* m, double* x, double* y);
        
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiDrawTransform(IntPtr context, uiDrawMatrix matrix);
        // _UI_EXTERN void uiDrawTransform(uiDrawContext* c, uiDrawMatrix* m);

        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiDrawClip(IntPtr context, IntPtr path);
        // _UI_EXTERN void uiDrawClip(uiDrawContext* c, uiDrawPath* path);

        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiDrawSave(IntPtr context);
        // _UI_EXTERN void uiDrawSave(uiDrawContext* c);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiDrawRestore(IntPtr context);
        // _UI_EXTERN void uiDrawRestore(uiDrawContext* c);
        
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewOpenTypeFeatures();
        // _UI_EXTERN uiOpenTypeFeatures *uiNewOpenTypeFeatures(void);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiFreeOpenTypeFeatures(IntPtr otf);
        // _UI_EXTERN void uiFreeOpenTypeFeatures(uiOpenTypeFeatures *otf);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern IntPtr uiOpenTypeFeaturesClone(IntPtr otf);
        // _UI_EXTERN uiOpenTypeFeatures *uiOpenTypeFeaturesClone(const uiOpenTypeFeatures *otf);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiOpenTypeFeaturesAdd(IntPtr otf, byte a, byte b, byte c, byte d, uint value);
        // _UI_EXTERN void uiOpenTypeFeaturesAdd(uiOpenTypeFeatures *otf, char a, char b, char c, char d, uint32_t value);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiOpenTypeFeaturesRemove(IntPtr otf, byte a, byte b, byte c, byte d);
        // _UI_EXTERN void uiOpenTypeFeaturesRemove(uiOpenTypeFeatures *otf, char a, char b, char c, char d);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern bool uiOpenTypeFeaturesGet(IntPtr otf, byte a, byte b, byte c, byte d, out uint value);
        // _UI_EXTERN int uiOpenTypeFeaturesGet(const uiOpenTypeFeatures *otf, char a, char b, char c, char d, uint32_t *value);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiOpenTypeFeaturesForEach(IntPtr otf, uiOpenTypeFeaturesForEachDelegate forEach, IntPtr data);
        // _UI_EXTERN void uiOpenTypeFeaturesForEach(const uiOpenTypeFeatures *otf, uiOpenTypeFeaturesForEachFunc f, void *data);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern bool uiOpenTypeFeaturesEqual(IntPtr otfA, IntPtr otfB);
        // _UI_EXTERN int uiOpenTypeFeaturesEqual(const uiOpenTypeFeatures *a, const uiOpenTypeFeatures *b);
        
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewAttributedString(IntPtr initalString);
        // _UI_EXTERN uiAttributedString *uiNewAttributedString(const char *initialString);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiFreeAttributedString(IntPtr attrStr);
        // _UI_EXTERN void uiFreeAttributedString(uiAttributedString *s);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern IntPtr uiAttributedStringString(IntPtr attrStr);
        // _UI_EXTERN const char *uiAttributedStringString(const uiAttributedString *s);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern UIntPtr uiAttributedStringLen(IntPtr attrStr);
        // _UI_EXTERN size_t uiAttributedStringLen(const uiAttributedString *s);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiAttributedStringAppendUnattributed(IntPtr attrStr, IntPtr str);
        // _UI_EXTERN void uiAttributedStringAppendUnattributed(uiAttributedString *s, const char *str);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiAttributedStringInsertAtUnattributed(IntPtr attrStr, IntPtr str, UIntPtr at);
        // _UI_EXTERN void uiAttributedStringInsertAtUnattributed(uiAttributedString *s, const char *str, size_t at);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiAttributedStringDelete(IntPtr attrStr, UIntPtr start, UIntPtr end);
        // _UI_EXTERN void uiAttributedStringDelete(uiAttributedString *s, size_t start, size_t end);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern UIntPtr uiAttributedStringNumGraphemes(IntPtr attrStr);
        // _UI_EXTERN size_t uiAttributedStringNumGraphemes(uiAttributedString *s);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern UIntPtr uiAttributedStringByteIndexToGrapheme(IntPtr attrStr, UIntPtr pos);
        // _UI_EXTERN size_t uiAttributedStringByteIndexToGrapheme(uiAttributedString *s, size_t pos);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern UIntPtr uiAttributedStringGraphemeToByteIndex(IntPtr attrStr, UIntPtr pos);
        // _UI_EXTERN size_t uiAttributedStringGraphemeToByteIndex(uiAttributedString *s, size_t pos);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiAttributedStringSetAttribute(IntPtr attrStr, uiAttributeSpec spec, UIntPtr start, UIntPtr end);
        // _UI_EXTERN void uiAttributedStringSetAttribute(uiAttributedString *s, uiAttributeSpec *spec, size_t start, size_t end);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiAttributedStringForEachAttribute(IntPtr attrStr, uiAttributedStringForEachAttributeDelegate forEachAttributeFunc, IntPtr data);
        // _UI_EXTERN void uiAttributedStringForEachAttribute(uiAttributedString *s, uiAttributedStringForEachAttributeFunc f, void *data);

        //! DrawTextLayout
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern IntPtr uiDrawNewTextLayout(uiDrawTextLayoutParams param);
        // _UI_EXTERN uiDrawTextLayout *uiDrawNewTextLayout(uiDrawTextLayoutParams *params);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiDrawFreeTextLayout(IntPtr tl);
        // _UI_EXTERN void uiDrawFreeTextLayout(uiDrawTextLayout *tl);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiDrawText(IntPtr context, IntPtr textLayout, double x, double y);
        // _UI_EXTERN void uiDrawText(uiDrawContext *c, uiDrawTextLayout *tl, double x, double y);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiDrawTextLayoutExtents(IntPtr tl, out double width, out double height);
        // _UI_EXTERN void uiDrawTextLayoutExtents(uiDrawTextLayout *tl, double *width, double *height);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern int uiDrawTextLayoutNumLines(IntPtr tl);
        // _UI_EXTERN int uiDrawTextLayoutNumLines(uiDrawTextLayout *tl);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiDrawTextLayoutLineByteRange(IntPtr tl, int line, out UIntPtr start, out UIntPtr end);
        // _UI_EXTERN void uiDrawTextLayoutLineByteRange(uiDrawTextLayout *tl, int line, size_t *start, size_t *end);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiDrawTextLayoutLineGetMetrics(IntPtr tl, int line, out uiDrawTextLayoutLineMetrics m);
        // _UI_EXTERN void uiDrawTextLayoutLineGetMetrics(uiDrawTextLayout *tl, int line, uiDrawTextLayoutLineMetrics *m);

        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiDrawTextLayoutHitTest(IntPtr tl, double x, double y, out UIntPtr pos, out int line);
        // _UI_EXTERN void uiDrawTextLayoutHitTest(uiDrawTextLayout *tl, double x, double y, size_t *pos, int *line);

        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern double uiDrawTextLayoutByteLocationInLine(IntPtr tl, UIntPtr pos, int line);
        // _UI_EXTERN double uiDrawTextLayoutByteLocationInLine(uiDrawTextLayout *tl, size_t pos, int line);

        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiDrawCaret(IntPtr context, double x, double y, IntPtr textLayout, UIntPtr pos, IntPtr line);
        // _UI_EXTERN void uiDrawCaret(uiDrawContext *c, double x, double y, uiDrawTextLayout *layout, size_t pos, int *line);
        
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiFontButtonFont(IntPtr button, out uiDrawFontDescriptor decriptor);
        // _UI_EXTERN void uiFontButtonFont(uiFontButton *b, uiDrawFontDescriptor *desc);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiFontButtonOnChanged(IntPtr button, uiFontButtonOnChangedDelegate fontButtonOnChanged, IntPtr data);
        // _UI_EXTERN void uiFontButtonOnChanged(uiFontButton *b, void (*f)(uiFontButton *, void *), void *data);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewFontButton();
        // _UI_EXTERN uiFontButton *uiNewFontButton(void);
        
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiColorButtonColor(IntPtr button, out double red, out double green, out double blue, out double alpha);
        // _UI_EXTERN void uiColorButtonColor(uiColorButton* b, double* r, double* g, double* bl, double* a);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiColorButtonSetColor(IntPtr button, double red, double green, double blue, double alpha);
        // _UI_EXTERN void uiColorButtonSetColor(uiColorButton* b, double r, double g, double bl, double a);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiColorButtonOnChanged(IntPtr button, uiColorButtonOnChangedDelegate colorButtonOnChanged, IntPtr data);
        // _UI_EXTERN void uiColorButtonOnChanged(uiColorButton* b, void (* f)(uiColorButton*, void*), void* data);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewColorButton();
        // _UI_EXTERN uiColorButton *uiNewColorButton(void);
        
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiFormAppend(IntPtr form, IntPtr label, IntPtr child, bool stretchy);
        // _UI_EXTERN void uiFormAppend(uiForm* f, const char* label, uiControl *c, int stretchy);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiFormDelete(IntPtr form, int index);
        // _UI_EXTERN void uiFormDelete(uiForm* f, int index);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern bool uiFormPadded(IntPtr form);
        // _UI_EXTERN int uiFormPadded(uiForm* f);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiFormSetPadded(IntPtr form, bool padded);
        // _UI_EXTERN void uiFormSetPadded(uiForm* f, int padded);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewForm();
        // _UI_EXTERN uiForm *uiNewForm(void);
        
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiGridAppend(IntPtr grid, IntPtr child, int left, int top, int xspan, int yspan, int hexpand, Alignment halign, int vexpand, Alignment valign);
        // _UI_EXTERN void uiGridAppend(uiGrid* g, uiControl* c, int left, int top, int xspan, int yspan, int hexpand, uiAlign halign, int vexpand, uiAlign valign);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiGridInsertAt(IntPtr grid, IntPtr child, IntPtr existing, RelativeAlignment at, int xspan, int yspan, int hexpand, Alignment halign, int vexpand, Alignment valign);
        // _UI_EXTERN void uiGridInsertAt(uiGrid* g, uiControl* c, uiControl* existing, uiAt at, int xspan, int yspan, int hexpand, uiAlign halign, int vexpand, uiAlign valign);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern bool uiGridPadded(IntPtr grid);
        // _UI_EXTERN int uiGridPadded(uiGrid* g);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern void uiGridSetPadded(IntPtr grid, bool padded);
        // _UI_EXTERN void uiGridSetPadded(uiGrid* g, int padded);
        [DllImport(LibUI, SetLastError = true, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewGrid();
        // _UI_EXTERN uiGrid *uiNewGrid(void);

        #region Windows-specific Interop
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr GetConsoleWindow();
        
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        #endregion
    }
}