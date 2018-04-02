using System;
using System.Runtime.InteropServices;
using LibUISharp.Drawing;

// Repository: https://github.com/andlabs/libui
// Commit: 51f72abba84e3941deba1c8f699046a48d1f7fb9
// C Header: ui.h

namespace LibUISharp.Internal
{
    //TODO: uiAttributedString class and helper methods.
    internal static partial class LibUI
    {
        private const string LibUIRef = "libui";
        private const CallingConvention Cdecl = CallingConvention.Cdecl;

        public enum uiForEach : uint
        {
            uiForEachContinue,
            uiForEachStop
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct uiInitOptions
        {
            public uiInitOptions(UIntPtr size) => Size = size;
            public UIntPtr Size;
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void uiOnEventHandler(IntPtr control, IntPtr data);

        [DllImport(LibUIRef, CallingConvention = Cdecl, EntryPoint = "uiInit")]
        private static extern IntPtr _uiInit(ref uiInitOptions options);
        public static void uiInit(ref uiInitOptions options)
        {
            IntPtr errPtr = _uiInit(ref options);
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

        //// [StructLayout(LayoutKind.Sequential)]
        //// public struct uiControl { }

        [DllImport(LibUIRef, CallingConvention = Cdecl, SetLastError = true)]
        public static extern void uiControlDestroy(IntPtr c);

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

        //// [DllImport(LibUIRef, CallingConvention = Cdecl)]
        //// public static extern void uiUserBugCannotSetParentOnTopLevel(IntPtr type);

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

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiWindowSetContentSize(IntPtr w, int width, int height);
        public static void uiWindowSetContentSize(ControlSafeHandle w, int width, int height) => uiWindowSetContentSize(w.DangerousGetHandle(), width, height);

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern bool uiWindowFullscreen(IntPtr w);
        public static bool uiWindowFullscreen(ControlSafeHandle w) => uiWindowFullscreen(w.DangerousGetHandle());

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiWindowSetFullscreen(IntPtr w, bool fullscreen);
        public static void uiWindowSetFullscreen(ControlSafeHandle w, bool fullscreen) => uiWindowSetFullscreen(w.DangerousGetHandle(), fullscreen);

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiWindowOnContentSizeChanged(IntPtr w, uiOnEventHandler f, IntPtr data);
        public static void uiWindowOnContentSizeChanged(ControlSafeHandle w, uiOnEventHandler f, IntPtr data) => uiWindowOnContentSizeChanged(w.DangerousGetHandle(), f, data);
        public static void uiWindowOnContentSizeChanged(ControlSafeHandle w, uiOnEventHandler f) => uiWindowOnContentSizeChanged(w, f, IntPtr.Zero);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool uiWindowOnClosingHandler(IntPtr control, IntPtr data);

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiWindowOnClosing(IntPtr w, uiWindowOnClosingHandler f, IntPtr data);
        public static void uiWindowOnClosing(ControlSafeHandle w, uiWindowOnClosingHandler f, IntPtr data) => uiWindowOnClosing(w.DangerousGetHandle(), f, data);
        public static void uiWindowOnClosing(ControlSafeHandle w, uiWindowOnClosingHandler f) => uiWindowOnClosing(w, f, IntPtr.Zero);

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
        public static extern void uiButtonOnClicked(IntPtr b, uiOnEventHandler f, IntPtr data);
        public static void uiButtonOnClicked(ControlSafeHandle b, uiOnEventHandler f, IntPtr data) => uiButtonOnClicked(b.DangerousGetHandle(), f, data);
        public static void uiButtonOnClicked(ControlSafeHandle b, uiOnEventHandler f) => uiButtonOnClicked(b, f, IntPtr.Zero);

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewButton(IntPtr text);
        public static ControlSafeHandle uiNewButton(string text)
        {
            IntPtr strPtr = UTF8Helper.ToUTF8Ptr(text);
            ControlSafeHandle safeHandle = new ControlSafeHandle(uiNewButton(strPtr));
            Marshal.FreeHGlobal(strPtr);
            return safeHandle;
        }

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
        public static extern IntPtr _uiNewHorizontalBox();
        public static ControlSafeHandle uiNewHorizontalBox() => new ControlSafeHandle(_uiNewHorizontalBox());

        [DllImport(LibUIRef, CallingConvention = Cdecl, EntryPoint = "uiNewVerticalBox")]
        public static extern IntPtr _uiNewVerticalBox();
        public static ControlSafeHandle uiNewVerticalBox() => new ControlSafeHandle(_uiNewVerticalBox());

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
        public static extern void uiCheckboxOnToggled(IntPtr c, uiOnEventHandler f, IntPtr data);
        public static void uiCheckboxOnToggled(ControlSafeHandle c, uiOnEventHandler f, IntPtr data) => uiCheckboxOnToggled(c.DangerousGetHandle(), f, data);
        public static void uiCheckboxOnToggled(ControlSafeHandle c, uiOnEventHandler f) => uiCheckboxOnToggled(c, f, IntPtr.Zero);

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

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiEntryText(IntPtr e);
        public static string uiEntryText(ControlSafeHandle e) => UTF8Helper.ToUTF8Str(uiEntryText(e.DangerousGetHandle()));

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiEntrySetText(IntPtr e, IntPtr text);
        public static void uiEntrySetText(ControlSafeHandle e, string text)
        {
            IntPtr strPtr = UTF8Helper.ToUTF8Ptr(text);
            uiEntrySetText(e.DangerousGetHandle(), strPtr);
            Marshal.FreeHGlobal(strPtr);
        }

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiEntryOnChanged(IntPtr e, uiOnEventHandler f, IntPtr data);
        public static void uiEntryOnChanged(ControlSafeHandle e, uiOnEventHandler f, IntPtr data) => uiEntryOnChanged(e.DangerousGetHandle(), f, data);
        public static void uiEntryOnChanged(ControlSafeHandle e, uiOnEventHandler f) => uiEntryOnChanged(e, f, IntPtr.Zero);

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern bool uiEntryReadOnly(IntPtr e);
        public static bool uiEntryReadOnly(ControlSafeHandle e) => uiEntryReadOnly(e.DangerousGetHandle());

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiEntrySetReadOnly(IntPtr e, bool @readonly);
        public static void uiEntrySetReadOnly(ControlSafeHandle e, bool @readonly) => uiEntrySetReadOnly(e.DangerousGetHandle(), @readonly);

        [DllImport(LibUIRef, CallingConvention = Cdecl, EntryPoint = "uiNewEntry")]
        public static extern IntPtr _uiNewEntry();
        public static ControlSafeHandle uiNewEntry() => new ControlSafeHandle(_uiNewEntry());

        [DllImport(LibUIRef, CallingConvention = Cdecl, EntryPoint = "uiNewPasswordEntry")]
        public static extern IntPtr _uiNewPasswordEntry();
        public static ControlSafeHandle uiNewPasswordEntry() => new ControlSafeHandle(_uiNewPasswordEntry());

        [DllImport(LibUIRef, CallingConvention = Cdecl, EntryPoint = "uiNewSearchEntry")]
        public static extern IntPtr _uiNewSearchEntry();
        public static ControlSafeHandle uiNewSearchEntry() => new ControlSafeHandle(_uiNewSearchEntry());

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiLabelText(IntPtr l);
        public static string uiLabelText(ControlSafeHandle l) => UTF8Helper.ToUTF8Str(uiLabelText(l.DangerousGetHandle()));

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiLabelSetText(IntPtr l, IntPtr text);
        public static void uiLabelSetText(ControlSafeHandle l, string text)
        {
            IntPtr strPtr = UTF8Helper.ToUTF8Ptr(text);
            uiLabelSetText(l.DangerousGetHandle(), strPtr);
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

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiTabAppend(IntPtr t, IntPtr name, IntPtr c);
        public static void uiTabAppend(ControlSafeHandle t, string name, ControlSafeHandle c)
        {
            IntPtr strPtr = UTF8Helper.ToUTF8Ptr(name);
            uiTabAppend(t.DangerousGetHandle(), strPtr, c.DangerousGetHandle());
            Marshal.FreeHGlobal(strPtr);
        }

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiTabInsertAt(IntPtr t, IntPtr name, int before, IntPtr c);
        public static void uiTabInsertAt(ControlSafeHandle t, string name, int before, ControlSafeHandle c)
        {
            IntPtr strPtr = UTF8Helper.ToUTF8Ptr(name);
            uiTabInsertAt(t.DangerousGetHandle(), strPtr, before, c.DangerousGetHandle());
            Marshal.FreeHGlobal(strPtr);
        }

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiTabDelete(IntPtr t, int index);
        public static void uiTabDelete(ControlSafeHandle t, int index) => uiTabDelete(t.DangerousGetHandle(), index);

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern int uiTabNumPages(IntPtr t);
        public static int uiTabNumPages(ControlSafeHandle t) => uiTabNumPages(t.DangerousGetHandle());

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern bool uiTabMargined(IntPtr t, int page);
        public static bool uiTabMargined(ControlSafeHandle t, int page) => uiTabMargined(t.DangerousGetHandle(), page);

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiTabSetMargined(IntPtr t, int page, bool margined);
        public static void uiTabSetMargined(ControlSafeHandle t, int page, bool margined) => uiTabSetMargined(t.DangerousGetHandle(), page, margined);

        [DllImport(LibUIRef, CallingConvention = Cdecl, EntryPoint = "uiNewTab")]
        public static extern IntPtr _uiNewTab();
        public static ControlSafeHandle uiNewTab() => new ControlSafeHandle(_uiNewTab());

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiGroupTitle(IntPtr g);
        public static string uiGroupTitle(ControlSafeHandle g) => UTF8Helper.ToUTF8Str(uiGroupTitle(g.DangerousGetHandle()));

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiGroupSetTitle(IntPtr g, IntPtr title);
        public static void uiGroupSetTitle(ControlSafeHandle g, string title)
        {
            IntPtr strPtr = UTF8Helper.ToUTF8Ptr(title);
            uiGroupSetTitle(g.DangerousGetHandle(), strPtr);
            Marshal.FreeHGlobal(strPtr);
        }

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiGroupSetChild(IntPtr g, IntPtr child);
        public static void uiGroupSetChild(ControlSafeHandle g, ControlSafeHandle child) => uiGroupSetChild(g.DangerousGetHandle(), child.DangerousGetHandle());

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern bool uiGroupMargined(IntPtr g);
        public static bool uiGroupMargined(ControlSafeHandle g) => uiGroupMargined(g.DangerousGetHandle());

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiGroupSetMargined(IntPtr g, bool margined);
        public static void uiGroupSetMargined(ControlSafeHandle g, bool margined) => uiGroupSetMargined(g.DangerousGetHandle(), margined);

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewGroup(IntPtr title);
        public static ControlSafeHandle uiNewGroup(string title)
        {
            IntPtr strPtr = UTF8Helper.ToUTF8Ptr(title);
            ControlSafeHandle safeHandle = new ControlSafeHandle(uiNewGroup(strPtr));
            Marshal.FreeHGlobal(strPtr);
            return safeHandle;
        }

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern int uiSpinboxValue(IntPtr s);
        public static int uiSpinboxValue(ControlSafeHandle s) => uiSpinboxValue(s.DangerousGetHandle());

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiSpinboxSetValue(IntPtr s, int value);
        public static void uiSpinboxSetValue(ControlSafeHandle s, int value) => uiSpinboxSetValue(s.DangerousGetHandle(), value);

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiSpinboxOnChanged(IntPtr s, uiOnEventHandler f, IntPtr data);
        public static void uiSpinboxOnChanged(ControlSafeHandle s, uiOnEventHandler f, IntPtr data) => uiSpinboxOnChanged(s.DangerousGetHandle(), f, data);
        public static void uiSpinboxOnChanged(ControlSafeHandle s, uiOnEventHandler f) => uiSpinboxOnChanged(s, f, IntPtr.Zero);

        [DllImport(LibUIRef, CallingConvention = Cdecl, EntryPoint = "uiNewSpinbox")]
        public static extern IntPtr _uiNewSpinbox(int min, int max);
        public static ControlSafeHandle uiNewSpinbox(int min, int max) => new ControlSafeHandle(_uiNewSpinbox(min, max));

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern int uiSliderValue(IntPtr s);
        public static int uiSliderValue(ControlSafeHandle s) => uiSliderValue(s.DangerousGetHandle());

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiSliderSetValue(IntPtr s, int value);
        public static void uiSliderSetValue(ControlSafeHandle s, int value) => uiSliderSetValue(s.DangerousGetHandle(), value);

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiSliderOnChanged(IntPtr s, uiOnEventHandler f, IntPtr data);
        public static void uiSliderOnChanged(ControlSafeHandle s, uiOnEventHandler f, IntPtr data) => uiSliderOnChanged(s.DangerousGetHandle(), f, data);
        public static void uiSliderOnChanged(ControlSafeHandle s, uiOnEventHandler f) => uiSliderOnChanged(s, f, IntPtr.Zero);

        [DllImport(LibUIRef, CallingConvention = Cdecl, EntryPoint = "uiNewSlider")]
        public static extern IntPtr _uiNewSlider(int min, int max);
        public static ControlSafeHandle uiNewSlider(int min, int max) => new ControlSafeHandle(_uiNewSlider(min, max));

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern int uiProgressBarValue(IntPtr p);
        public static int uiProgressBarValue(ControlSafeHandle p) => uiProgressBarValue(p.DangerousGetHandle());

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiProgressBarSetValue(IntPtr p, int n);
        public static void uiProgressBarSetValue(ControlSafeHandle p, int n) => uiProgressBarSetValue(p.DangerousGetHandle(), n);

        [DllImport(LibUIRef, CallingConvention = Cdecl, EntryPoint = "uiNewProgressBar")]
        public static extern IntPtr _uiNewProgressBar();
        public static ControlSafeHandle uiNewProgressBar() => new ControlSafeHandle(_uiNewProgressBar());

        [DllImport(LibUIRef, CallingConvention = Cdecl, EntryPoint = "uiNewHorizontalSeparator")]
        public static extern IntPtr _uiNewHorizontalSeparator();
        public static ControlSafeHandle uiNewHorizontalSeparator() => new ControlSafeHandle(_uiNewHorizontalSeparator());

        [DllImport(LibUIRef, CallingConvention = Cdecl, EntryPoint = "uiNewVerticalSeparator")]
        public static extern IntPtr _uiNewVerticalSeparator();
        public static ControlSafeHandle uiNewVerticalSeparator() => new ControlSafeHandle(_uiNewVerticalSeparator());

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiComboboxAppend(IntPtr c, IntPtr text);
        public static void uiComboboxAppend(ControlSafeHandle c, string text)
        {
            IntPtr strPtr = UTF8Helper.ToUTF8Ptr(text);
            uiComboboxAppend(c.DangerousGetHandle(), strPtr);
            Marshal.FreeHGlobal(strPtr);
        }

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern int uiComboboxSelected(IntPtr c);
        public static int uiComboboxSelected(ControlSafeHandle c) => uiComboboxSelected(c.DangerousGetHandle());

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiComboboxSetSelected(IntPtr c, int n);
        public static void uiComboboxSetSelected(ControlSafeHandle c, int n) => uiComboboxSetSelected(c.DangerousGetHandle(), n);

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiComboboxOnSelected(IntPtr c, uiOnEventHandler f, IntPtr data);
        public static void uiComboboxOnSelected(ControlSafeHandle c, uiOnEventHandler f, IntPtr data) => uiComboboxOnSelected(c.DangerousGetHandle(), f, data);
        public static void uiComboboxOnSelected(ControlSafeHandle c, uiOnEventHandler f) => uiComboboxOnSelected(c, f, IntPtr.Zero);

        [DllImport(LibUIRef, CallingConvention = Cdecl, EntryPoint = "uiNewCombobox")]
        public static extern IntPtr _uiNewCombobox();
        public static ControlSafeHandle uiNewCombobox() => new ControlSafeHandle(_uiNewCombobox());

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiEditableComboboxAppend(IntPtr c, IntPtr text);
        public static void uiEditableComboboxAppend(ControlSafeHandle c, string text)
        {
            IntPtr strPtr = UTF8Helper.ToUTF8Ptr(text);
            uiEditableComboboxAppend(c.DangerousGetHandle(), strPtr);
            Marshal.FreeHGlobal(strPtr);
        }

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiEditableComboboxText(IntPtr comboBox);
        public static string uiEditableComboboxText(ControlSafeHandle c) => UTF8Helper.ToUTF8Str(uiEditableComboboxText(c.DangerousGetHandle()));

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiEditableComboboxSetText(IntPtr c, IntPtr text);
        public static void uiEditableComboboxSetText(ControlSafeHandle c, string text)
        {
            IntPtr strPtr = UTF8Helper.ToUTF8Ptr(text);
            uiEditableComboboxSetText(c.DangerousGetHandle(), strPtr);
            Marshal.FreeHGlobal(strPtr);

        }

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiEditableComboboxOnChanged(IntPtr c, uiOnEventHandler f, IntPtr data);
        public static void uiEditableComboboxOnChanged(ControlSafeHandle c, uiOnEventHandler f, IntPtr data) => uiEditableComboboxOnChanged(c.DangerousGetHandle(), f, data);
        public static void uiEditableComboboxOnChanged(ControlSafeHandle c, uiOnEventHandler f) => uiEditableComboboxOnChanged(c, f);

        [DllImport(LibUIRef, CallingConvention = Cdecl, EntryPoint = "uiNewEditableCombobox")]
        public static extern IntPtr _uiNewEditableCombobox();
        public static ControlSafeHandle uiNewEditableCombobox() => new ControlSafeHandle(_uiNewEditableCombobox());

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiRadioButtonsAppend(IntPtr r, IntPtr text);
        public static void uiRadioButtonsAppend(ControlSafeHandle r, string text)
        {
            IntPtr strPtr = UTF8Helper.ToUTF8Ptr(text);
            uiRadioButtonsAppend(r.DangerousGetHandle(), strPtr);
            Marshal.FreeHGlobal(strPtr);
        }

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern int uiRadioButtonsSelected(IntPtr r);
        public static int uiRadioButtonsSelected(ControlSafeHandle r) => uiRadioButtonsSelected(r.DangerousGetHandle());

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiRadioButtonsSetSelected(IntPtr r, int n);
        public static void uiRadioButtonsSetSelected(ControlSafeHandle r, int n) => uiRadioButtonsSetSelected(r.DangerousGetHandle(), n);

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiRadioButtonsOnSelected(IntPtr r, uiOnEventHandler f, IntPtr data);
        public static void uiRadioButtonsOnSelected(ControlSafeHandle r, uiOnEventHandler f, IntPtr data) => uiRadioButtonsOnSelected(r.DangerousGetHandle(), f, data);
        public static void uiRadioButtonsOnSelected(ControlSafeHandle r, uiOnEventHandler f) => uiRadioButtonsOnSelected(r, f, IntPtr.Zero);

        [DllImport(LibUIRef, CallingConvention = Cdecl, EntryPoint = "uiNewRadioButtons")]
        public static extern IntPtr _uiNewRadioButtons();
        public static ControlSafeHandle uiNewRadioButtons() => new ControlSafeHandle(_uiNewRadioButtons());

        [DllImport(LibUIRef, CallingConvention = Cdecl, EntryPoint = "uiNewDateTimePicker")]
        public static extern IntPtr _uiNewDateTimePicker();
        public static ControlSafeHandle uiNewDateTimePicker() => new ControlSafeHandle(_uiNewDateTimePicker());

        [DllImport(LibUIRef, CallingConvention = Cdecl, EntryPoint = "uiNewDatePicker")]
        public static extern IntPtr _uiNewDatePicker();
        public static ControlSafeHandle uiNewDatePicker() => new ControlSafeHandle(_uiNewDatePicker());

        [DllImport(LibUIRef, CallingConvention = Cdecl, EntryPoint = "uiNewTimePicker")]
        public static extern IntPtr _uiNewTimePicker();
        public static ControlSafeHandle uiNewTimePicker() => new ControlSafeHandle(_uiNewTimePicker());

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiMultilineEntryText(IntPtr e);
        public static string uiMultilineEntryText(ControlSafeHandle e) => UTF8Helper.ToUTF8Str(uiMultilineEntryText(e.DangerousGetHandle()));

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiMultilineEntrySetText(IntPtr e, IntPtr text);
        public static void uiMultilineEntrySetText(ControlSafeHandle e, string text)
        {
            IntPtr strPtr = UTF8Helper.ToUTF8Ptr(text);
            uiMultilineEntrySetText(e.DangerousGetHandle(), strPtr);
            Marshal.FreeHGlobal(strPtr);
        }

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiMultilineEntryAppend(IntPtr e, IntPtr text);
        public static void uiMultilineEntryAppend(ControlSafeHandle e, params string[] lines)
        {
            foreach (string s in lines)
            {
                IntPtr strPtr = UTF8Helper.ToUTF8Ptr(s);
                uiMultilineEntryAppend(e.DangerousGetHandle(), strPtr);
                Marshal.FreeHGlobal(strPtr);
            }
        }

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiMultilineEntryOnChanged(IntPtr e, uiOnEventHandler f, IntPtr data);
        public static void uiMultilineEntryOnChanged(ControlSafeHandle e, uiOnEventHandler f, IntPtr data) => uiMultilineEntryOnChanged(e.DangerousGetHandle(), f, data);
        public static void uiMultilineEntryOnChanged(ControlSafeHandle e, uiOnEventHandler f) => uiMultilineEntryOnChanged(e, f, IntPtr.Zero);

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern bool uiMultilineEntryReadOnly(IntPtr e);
        public static bool uiMultilineEntryReadOnly(ControlSafeHandle e) => uiMultilineEntryReadOnly(e.DangerousGetHandle());

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiMultilineEntrySetReadOnly(IntPtr e, bool @readonly);
        public static void uiMultilineEntrySetReadOnly(ControlSafeHandle e, bool @readonly) => uiMultilineEntrySetReadOnly(e.DangerousGetHandle(), @readonly);

        [DllImport(LibUIRef, CallingConvention = Cdecl, EntryPoint = "uiNewMultilineEntry")]
        public static extern IntPtr _uiNewMultilineEntry();
        public static ControlSafeHandle uiNewMultilineEntry() => new ControlSafeHandle(_uiNewMultilineEntry());

        [DllImport(LibUIRef, CallingConvention = Cdecl, EntryPoint = "uiNewNonWrappingMultilineEntry")]
        public static extern IntPtr _uiNewNonWrappingMultilineEntry();
        public static ControlSafeHandle uiNewNonWrappingMultilineEntry() => new ControlSafeHandle(_uiNewNonWrappingMultilineEntry());

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiMenuItemEnable(IntPtr m);
        public static void uiMenuItemEnable(ControlSafeHandle m) => uiMenuItemEnable(m.DangerousGetHandle());

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiMenuItemDisable(IntPtr m);
        public static void uiMenuItemDisable(ControlSafeHandle m) => uiMenuItemDisable(m.DangerousGetHandle());

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void uiMenuItemOnClickedHandler(IntPtr menuItem, IntPtr window, IntPtr data);

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiMenuItemOnClicked(IntPtr m, uiMenuItemOnClickedHandler f, IntPtr data);
        public static void uiMenuItemOnClicked(ControlSafeHandle m, uiMenuItemOnClickedHandler f, IntPtr data) => uiMenuItemOnClicked(m.DangerousGetHandle(), f, data);
        public static void uiMenuItemOnClicked(ControlSafeHandle m, uiMenuItemOnClickedHandler f) => uiMenuItemOnClicked(m, f, IntPtr.Zero);

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern bool uiMenuItemChecked(IntPtr m);
        public static bool uiMenuItemChecked(ControlSafeHandle m) => uiMenuItemChecked(m.DangerousGetHandle());

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiMenuItemSetChecked(IntPtr m, bool @checked);
        public static void uiMenuItemSetChecked(ControlSafeHandle m, bool @checked) => uiMenuItemSetChecked(m.DangerousGetHandle(), @checked);

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiMenuAppendItem(IntPtr m, IntPtr name);
        public static ControlSafeHandle uiMenuAppendItem(ControlSafeHandle m, string name)
        {
            IntPtr strPtr = UTF8Helper.ToUTF8Ptr(name);
            ControlSafeHandle safeHandle = new ControlSafeHandle(uiMenuAppendItem(m.DangerousGetHandle(), strPtr));
            Marshal.FreeHGlobal(strPtr);
            return safeHandle;
        }

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiMenuAppendCheckItem(IntPtr m, IntPtr name);
        public static ControlSafeHandle uiMenuAppendCheckItem(ControlSafeHandle m, string name)
        {
            IntPtr strPtr = UTF8Helper.ToUTF8Ptr(name);
            ControlSafeHandle safeHandle = new ControlSafeHandle(uiMenuAppendCheckItem(m.DangerousGetHandle(), strPtr));
            Marshal.FreeHGlobal(strPtr);
            return safeHandle;
        }

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiMenuAppendQuitItem(IntPtr m);
        public static ControlSafeHandle uiMenuAppendQuitItem(ControlSafeHandle m) => new ControlSafeHandle(uiMenuAppendQuitItem(m.DangerousGetHandle()));

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiMenuAppendPreferencesItem(IntPtr m);
        public static ControlSafeHandle uiMenuAppendPreferencesItem(ControlSafeHandle m) => new ControlSafeHandle(uiMenuAppendPreferencesItem(m.DangerousGetHandle()));

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiMenuAppendAboutItem(IntPtr m);
        public static ControlSafeHandle uiMenuAppendAboutItem(ControlSafeHandle m) => new ControlSafeHandle(uiMenuAppendAboutItem(m.DangerousGetHandle()));

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiMenuAppendSeparator(IntPtr m);
        public static void uiMenuAppendSeparator(ControlSafeHandle m) => uiMenuAppendSeparator(m.DangerousGetHandle());

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewMenu(IntPtr name);
        public static ControlSafeHandle uiNewMenu(string name)
        {
            IntPtr strPtr = UTF8Helper.ToUTF8Ptr(name);
            ControlSafeHandle safeHandle = new ControlSafeHandle(uiNewMenu(strPtr));
            Marshal.FreeHGlobal(strPtr);
            return safeHandle;
        }

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiOpenFile(IntPtr parent);
        public static string uiOpenFile(ControlSafeHandle parent) => UTF8Helper.ToUTF8Str(uiOpenFile(parent.DangerousGetHandle()));

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiSaveFile(IntPtr parent);
        public static string uiSaveFile(ControlSafeHandle parent) => UTF8Helper.ToUTF8Str(uiSaveFile(parent.DangerousGetHandle()));

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiMsgBox(IntPtr parent, IntPtr title, IntPtr description);
        public static void uiMsgBox(ControlSafeHandle parent, string title, string description)
        {
            IntPtr titlePtr = UTF8Helper.ToUTF8Ptr(title);
            IntPtr descrPtr = UTF8Helper.ToUTF8Ptr(description);
            uiMsgBox(parent.DangerousGetHandle(), titlePtr, descrPtr);
            Marshal.FreeHGlobal(titlePtr);
            Marshal.FreeHGlobal(descrPtr);
        }

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        private static extern void uiMsgBoxError(IntPtr parent, IntPtr title, IntPtr description);
        public static void uiMsgBoxError(ControlSafeHandle parent, string title, string description)
        {
            IntPtr titlePtr = UTF8Helper.ToUTF8Ptr(title);
            IntPtr descrPtr = UTF8Helper.ToUTF8Ptr(description);
            uiMsgBoxError(parent.DangerousGetHandle(), titlePtr, descrPtr);
            Marshal.FreeHGlobal(titlePtr);
            Marshal.FreeHGlobal(descrPtr);
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void uiAreaDrawHandler(IntPtr handler, IntPtr area, [In, Out]ref uiAreaDrawParams param);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void uiAreaMouseEventHandler(IntPtr handler, IntPtr area, [In, Out]ref uiAreaMouseEvent mouseEvent);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void uiAreaMouseCrossedHandler(IntPtr handler, IntPtr area, bool left);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void uiAreaDragBrokenHandler(IntPtr handler, IntPtr area);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool uiAreaKeyEventHandler(IntPtr handler, IntPtr area, [In, Out]ref uiAreaKeyEvent keyEvent);

        [StructLayout(LayoutKind.Sequential)]
        internal class uiAreaHandler
        {
            public IntPtr Draw;
            public IntPtr MouseEvent;
            public IntPtr MouseCrossed;
            public IntPtr DragBroken;
            public IntPtr KeyEvent;
        }

        public enum uiWindowResizeEdge : uint
        {
            uiWindowResizeEdgeLeft,
            uiWindowResizeEdgeTop,
            uiWindowResizeEdgeRight,
            uiWindowResizeEdgeBottom,
            uiWindowResizeEdgeTopLeft,
            uiWindowResizeEdgeTopRight,
            uiWindowResizeEdgeBottomLeft,
            uiWindowResizeEdgeBottomRight
        }

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiAreaSetSize(IntPtr a, int width, int height);
        public static void uiAreaSetSize(ControlSafeHandle a, int width, int height) => uiAreaSetSize(a.DangerousGetHandle(), width, height);

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiAreaQueueReDrawAll(IntPtr a);
        public static void uiAreaQueueReDrawAll(ControlSafeHandle a) => uiAreaQueueReDrawAll(a.DangerousGetHandle());

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiAreaScrollTo(IntPtr area, double x, double y, double width, double height);
        public static void uiAreaScrollTo(ControlSafeHandle a, double x, double y, double width, double height) => uiAreaScrollTo(a.DangerousGetHandle(), x, y, width, height);

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiAreaBeginUserWindowMove(IntPtr area);
        public static void uiAreaBeginUserWindowMove(ControlSafeHandle a) => uiAreaBeginUserWindowMove(a.DangerousGetHandle());

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiAreaBeginUserWindowResize(IntPtr area, uiWindowResizeEdge edge);
        public static void uiAreaBeginUserWindowResize(ControlSafeHandle a, uiWindowResizeEdge edge) => uiAreaBeginUserWindowResize(a.DangerousGetHandle(), (uiWindowResizeEdge)edge);

        [DllImport(LibUIRef, CallingConvention = Cdecl, EntryPoint = "uiNewArea")]
        public static extern IntPtr _uiNewArea(uiAreaHandler ah);
        public static ControlSafeHandle uiNewArea(uiAreaHandler ah) => new ControlSafeHandle(_uiNewArea(ah));

        [DllImport(LibUIRef, CallingConvention = Cdecl, EntryPoint = "uiNewScrollingArea")]
        public static extern IntPtr _uiNewScrollingArea(uiAreaHandler ah, int width, int height);
        public static ControlSafeHandle uiNewScrollingArea(uiAreaHandler ah, int width, int height) => new ControlSafeHandle(_uiNewScrollingArea(ah, width, height));

        [StructLayout(LayoutKind.Sequential)]
        internal struct uiAreaDrawParams
        {
            public IntPtr Context;

            //! Only defined for non-scrolling areas.
            public double AreaWidth;
            public double AreaHeight;

            public double ClipX;
            public double ClipY;
            public double ClipWidth;
            public double ClipHeight;

            public static explicit operator DrawEventArgs(uiAreaDrawParams p) =>
                new DrawEventArgs(new Context(new ControlSafeHandle(p.Context)), new RectangleD(p.ClipX, p.ClipY, p.ClipWidth, p.ClipHeight), new SizeD(p.AreaWidth, p.AreaHeight));
        }

        public enum uiDrawBrushType : uint
        {
            uiDrawBrushTypeSolid,
            uiDrawBrushTypeLinearGradient,
            uiDrawBrushTypeRadialGradient,
            uiDrawBrushTypeImage
        }

        public enum uiDrawLineCap : uint
        {
            uiDrawLineCapFlat,
            uiDrawLineCapRound,
            uiDrawLineCapSquare,
        }

        public enum uiDrawLineJoin : uint
        {
            uiDrawLineJoinMiter,
            uiDrawLineJoinRound,
            uiDrawLineJoinBevel
        }

        public const double uiDrawDefaultMiterLimit = 10.0;

        public enum uiDrawFillMode : uint
        {
            uiDrawFillModeWinding,
            uiDrawFillModeAlternate
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct uiDrawMatrix
        {
            public double M11;
            public double M12;
            public double M21;
            public double M22;
            public double M31;
            public double M32;

            public static explicit operator uiDrawMatrix(Matrix m) => new uiDrawMatrix()
            {
                M11 = m.M11,
                M12 = m.M12,
                M21 = m.M21,
                M22 = m.M22,
                M31 = m.M31,
                M32 = m.M32
            };
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct uiDrawBrush
        {
            [MarshalAs(UnmanagedType.I4)]
            public uiDrawBrushType Type;

            // Solid Brushes
            public double R;
            public double G;
            public double B;
            public double A;

            // Gradient Brushes
            public double X0; // linear: start X, radial: start X
            public double Y0; // linear: start Y, radial: start Y
            public double X1; // linear: end X,   radial: outer circle center X
            public double Y1; // linear: end Y,   radial: outer circle center Y
            public double OuterRadius; // radial gradients only
            public IntPtr Stops;
            public UIntPtr NumStops;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct uiDrawBrushGradientStop
        {
            public double Pos;
            public double R;
            public double G;
            public double B;
            public double A;

            public static explicit operator uiDrawBrushGradientStop(GradientStop gs) => new uiDrawBrushGradientStop()
            {
                Pos = gs.Position,
                R = gs.Color.R,
                G = gs.Color.G,
                B = gs.Color.B,
                A = gs.Color.A
            };
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct uiDrawStrokeParams
        {
            public uiDrawLineCap Cap;
            public uiDrawLineJoin Join;
            public double Thickness;
            public double MiterLimit;
            public IntPtr Dashes;
            public UIntPtr NumDashes;
            public double DashPhase;
        }

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiDrawNewPath(uiDrawFillMode fillMode);
        public static PathSafeHandle uiDrawNewPath(FillMode fillMode) => new PathSafeHandle(uiDrawNewPath((uiDrawFillMode)fillMode));

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiDrawFreePath(IntPtr p);

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiDrawPathNewFigure(IntPtr p, double x, double y);
        public static void uiDrawPathNewFigure(PathSafeHandle p, double x, double y) => uiDrawPathNewFigure(p.DangerousGetHandle(), x, y);

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiDrawPathNewFigureWithArc(IntPtr p, double xCenter, double yCenter, double radius, double startAngle, double sweep, bool negative);
        public static void uiDrawPathNewFigureWithArc(PathSafeHandle p, double xCenter, double yCenter, double radius, double startAngle, double sweep, bool negative) => uiDrawPathNewFigureWithArc(p.DangerousGetHandle(), xCenter, yCenter, radius, startAngle, sweep, negative);

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiDrawPathLineTo(IntPtr p, double x, double y);
        public static void uiDrawPathLineTo(PathSafeHandle p, double x, double y) => uiDrawPathLineTo(p.DangerousGetHandle(), x, y);

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiDrawPathArcTo(IntPtr p, double xCenter, double yCenter, double radius, double startAngle, double sweep, bool negative);
        public static void uiDrawPathArcTo(PathSafeHandle p, double xCenter, double yCenter, double radius, double startAngle, double sweep, bool negative) => uiDrawPathArcTo(p.DangerousGetHandle(), xCenter, yCenter, radius, startAngle, sweep, negative);

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiDrawPathBezierTo(IntPtr p, double c1x, double c1y, double c2x, double c2y, double endX, double endY);
        public static void uiDrawPathBezierTo(PathSafeHandle p, double c1x, double c1y, double c2x, double c2y, double endX, double endY) => uiDrawPathBezierTo(p.DangerousGetHandle(), c1x, c1y, c2x, c2y, endX, endY);

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiDrawPathCloseFigure(IntPtr p);
        public static void uiDrawPathCloseFigure(PathSafeHandle p) => uiDrawPathCloseFigure(p.DangerousGetHandle());

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiDrawPathAddRectangle(IntPtr p, double x, double y, double width, double height);
        public static void uiDrawPathAddRectangle(PathSafeHandle p, double x, double y, double width, double height) => uiDrawPathAddRectangle(p.DangerousGetHandle(), x, y, width, height);

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiDrawPathEnd(IntPtr p);
        public static void uiDrawPathEnd(PathSafeHandle p) => uiDrawPathEnd(p.DangerousGetHandle());

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiDrawStroke(IntPtr context, IntPtr path, ref uiDrawBrush brush, ref uiDrawStrokeParams strokeParam);
        public static void uiDrawStroke(LibUISafeHandle c, PathSafeHandle p, ref uiDrawBrush brush, ref uiDrawStrokeParams strokeParams) => uiDrawStroke(c.DangerousGetHandle(), p.DangerousGetHandle(), ref brush, ref strokeParams);

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiDrawFill(IntPtr context, IntPtr path, ref uiDrawBrush brush);
        public static void uiDrawFill(LibUISafeHandle c, PathSafeHandle path, ref uiDrawBrush brush) => uiDrawFill(c.DangerousGetHandle(), path.DangerousGetHandle(), ref brush);

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
        public static void uiDrawTransform(LibUISafeHandle c, uiDrawMatrix matrix) => uiDrawTransform(c.DangerousGetHandle(), matrix);

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiDrawClip(IntPtr context, IntPtr path);
        public static void uiDrawClip(LibUISafeHandle context, PathSafeHandle path) => uiDrawClip(context.DangerousGetHandle(), path.DangerousGetHandle());

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiDrawSave(IntPtr context);
        public static void uiDrawSave(LibUISafeHandle c) => uiDrawSave(c.DangerousGetHandle());

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiDrawRestore(IntPtr context);
        public static void uiDrawRestore(LibUISafeHandle c) => uiDrawRestore(c.DangerousGetHandle());

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiFreeAttribute(IntPtr a);

        public enum uiAttributeType : uint
        {
            uiAttributeTypeFamily,
            uiAttributeTypeSize,
            uiAttributeTypeWeight,
            uiAttributeTypeItalic,
            uiAttributeTypeStretch,
            uiAttributeTypeColor,
            uiAttributeTypeBackground,
            uiAttributeTypeUnderline,
            uiAttributeTypeUnderlineColor,
            uiAttributeTypeFeatures
        }

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern uiAttributeType uiAttributeGetType(IntPtr a);
        public static uiAttributeType uiAttributeGetType(TextAttributeSafeHandle a) => uiAttributeGetType(a.DangerousGetHandle());

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewFamilyAttribute(IntPtr family);
        public static TextAttributeSafeHandle uiNewFamilyAttribute(string family)
        {
            IntPtr strPtr = UTF8Helper.ToUTF8Ptr(family);
            TextAttributeSafeHandle safeHandle = new TextAttributeSafeHandle(uiNewFamilyAttribute(strPtr));
            Marshal.FreeHGlobal(strPtr);
            return safeHandle;
        }

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiAttributeFamily(IntPtr a);
        public static string uiAttributeFamily(TextAttributeSafeHandle a) => UTF8Helper.ToUTF8Str(uiAttributeFamily(a.DangerousGetHandle()));

        [DllImport(LibUIRef, CallingConvention = Cdecl, EntryPoint = "uiNewSizeAttribute")]
        public static extern IntPtr _uiNewSizeAttribute(double size);
        public static TextAttributeSafeHandle uiNewSizeAttribute(double size) => new TextAttributeSafeHandle(_uiNewSizeAttribute(size));

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern double uiAttributeSize(IntPtr a);
        public static double uiAttributeSize(TextAttributeSafeHandle a) => uiAttributeSize(a.DangerousGetHandle());

        public enum uiTextWeight : uint
        {
            uiTextWeightMinimum = 0,
            uiTextWeightThin = 100,
            uiTextWeightUltraLight = 200,
            uiTextWeightLight = 300,
            uiTextWeightBook = 350,
            uiTextWeightNormal = 400,
            uiTextWeightMedium = 500,
            uiTextWeightSemiBold = 600,
            uiTextWeightBold = 700,
            uiTextWeightUltraBold = 800,
            uiTextWeightHeavy = 900,
            uiTextWeightUltraHeavy = 950,
            uiTextWeightMaximum = 1000
        }

        [DllImport(LibUIRef, CallingConvention = Cdecl, EntryPoint = "uiNewWeightAttribute")]
        public static extern IntPtr _uiNewWeightAttribute(uiTextWeight weight);
        public static TextAttributeSafeHandle uiNewWeightAttribute(uiTextWeight weight) => new TextAttributeSafeHandle(_uiNewWeightAttribute(weight));

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern uiTextWeight uiAttributeWeight(IntPtr a);
        public static uiTextWeight uiAttributeWeight(TextAttributeSafeHandle a) => uiAttributeWeight(a.DangerousGetHandle());

        public enum uiTextItalic : uint
        {
            uiTextItalicNormal,
            uiTextItalicOblique,
            uiTextItalicItalic
        }

        [DllImport(LibUIRef, CallingConvention = Cdecl, EntryPoint = "uiNewItalicAttribute")]
        public static extern IntPtr _uiNewItalicAttribute(uiTextItalic italic);
        public static TextAttributeSafeHandle uiNewItalicAttribute(uiTextItalic italic) => new TextAttributeSafeHandle(_uiNewItalicAttribute(italic));

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern uiTextItalic uiAttributeItalic(IntPtr a);
        public static uiTextItalic uiAttributeItalic(TextAttributeSafeHandle a) => uiAttributeItalic(a.DangerousGetHandle());

        public enum uiTextStretch : uint
        {
            uiTextStretchUltraCondensed,
            uiTextStretchExtraCondensed,
            uiTextStretchCondensed,
            uiTextStretchSemiCondensed,
            uiTextStretchNormal,
            uiTextStretchSemiExpanded,
            uiTextStretchExpanded,
            uiTextStretchExtraExpanded,
            uiTextStretchUltraExpanded
        }

        [DllImport(LibUIRef, CallingConvention = Cdecl, EntryPoint = "uiNewStretchAttribute")]
        public static extern IntPtr _uiNewStretchAttribute(uiTextStretch stretch);
        public static TextAttributeSafeHandle uiNewStretchAttribute(uiTextStretch stretch) => new TextAttributeSafeHandle(_uiNewStretchAttribute(stretch));

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern uiTextStretch uiAttributeStretch(IntPtr a);
        public static uiTextStretch uiAttributeStretch(TextAttributeSafeHandle a) => uiAttributeStretch(a.DangerousGetHandle());

        [DllImport(LibUIRef, CallingConvention = Cdecl, EntryPoint = "uiNewColorAttribute")]
        public static extern IntPtr _uiNewColorAttribute(double r, double g, double b, double a);
        public static TextAttributeSafeHandle uiNewColorAttribute(double r, double g, double b, double a) => new TextAttributeSafeHandle(_uiNewColorAttribute(r, g, b, a));

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiAttributeColor(IntPtr a, out double r, out double g, out double b, out double alpha);
        public static void uiAttributeColor(TextAttributeSafeHandle a, out double r, out double g, out double b, out double alpha) => uiAttributeColor(a.DangerousGetHandle(), out r, out g, out b, out alpha);

        [DllImport(LibUIRef, CallingConvention = Cdecl, EntryPoint = "uiNewBackgroundAttribute")]
        public static extern IntPtr _uiNewBackgroundAttribute(double r, double g, double b, double a);
        public static TextAttributeSafeHandle uiNewBackgroundAttribute(double r, double g, double b, double a) => new TextAttributeSafeHandle(_uiNewBackgroundAttribute(r, g, b, a));

        public enum uiUnderline : uint
        {
            uiUnderlineNone,
            uiUnderlineSingle,
            uiUnderlineDouble,
            uiUnderlineSuggestion, // wavy or dotted underlines used for spelling/grammar checkers
        }

        [DllImport(LibUIRef, CallingConvention = Cdecl, EntryPoint = "uiNewUnderlineAttribute")]
        public static extern IntPtr _uiNewUnderlineAttribute(uiUnderline u);
        public static TextAttributeSafeHandle uiNewUnderlineAttribute(uiUnderline u) => new TextAttributeSafeHandle(_uiNewUnderlineAttribute(u));

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern uiUnderline uiAttributeUnderline(IntPtr a);
        public static uiUnderline uiAttributeUnderline(TextAttributeSafeHandle a) => uiAttributeUnderline(a.DangerousGetHandle());

        public enum uiUnderlineColor : uint
        {
            uiUnderlineColorCustom,
            uiUnderlineColorSpelling,
            uiUnderlineColorGrammar,
            uiUnderlineColorAuxiliary, // for instance, the color used by smart replacements on macOS or in Microsoft Office
        }

        [DllImport(LibUIRef, CallingConvention = Cdecl, EntryPoint = "uiNewUnderlineColorAttribute")]
        public static extern IntPtr _uiNewUnderlineColorAttribute(uiUnderlineColor u, double r, double g, double b, double a);
        public static TextAttributeSafeHandle uiNewUnderlineColorAttribute(uiUnderlineColor u, double r, double g, double b, double a) => new TextAttributeSafeHandle(_uiNewUnderlineColorAttribute(u, r, g, b, a));

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiAttributeUnderline(IntPtr a, out uiUnderlineColor u, out double r, out double g, out double b, out double alpha);
        public static void uiAttributeUnderline(TextAttributeSafeHandle a, out uiUnderlineColor u, out double r, out double g, out double b, out double alpha) => uiAttributeUnderline(a.DangerousGetHandle(), out u, out r, out g, out b, out alpha);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uiForEach uiOpenTypeFeaturesForEachFunc(IntPtr otf, byte a, byte b, byte c, byte d, uint value, IntPtr data);

        [DllImport(LibUIRef, CallingConvention = Cdecl, EntryPoint = "uiNewOpenTypeFeatures")]
        public static extern IntPtr _uiNewOpenTypeFeatures();
        public static FontFeaturesSafeHandle uiNewOpenTypeFeatures() => new FontFeaturesSafeHandle(_uiNewOpenTypeFeatures());

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiFreeOpenTypeFeatures(IntPtr otf);

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiOpenTypeFeaturesClone(IntPtr otf);
        public static FontFeaturesSafeHandle uiOpenTypeFeaturesClone(FontFeaturesSafeHandle otf) => new FontFeaturesSafeHandle(otf.DangerousGetHandle());

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiOpenTypeFeaturesAdd(IntPtr otf, byte a, byte b, byte c, byte d, uint value);
        public static void uiOpenTypeFeaturesAdd(FontFeaturesSafeHandle otf, byte a, byte b, byte c, byte d, uint value) => uiOpenTypeFeaturesAdd(otf.DangerousGetHandle(), a, b, c, d, value);

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiOpenTypeFeaturesRemove(IntPtr otf, byte a, byte b, byte c, byte d);
        public static void uiOpenTypeFeaturesRemove(FontFeaturesSafeHandle otf, byte a, byte b, byte c, byte d) => uiOpenTypeFeaturesRemove(otf.DangerousGetHandle(), a, b, c, d);

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern int uiOpenTypeFeaturesGet(IntPtr otf, byte a, byte b, byte c, byte d, out uint value);
        public static int uiOpenTypeFeaturesGet(FontFeaturesSafeHandle otf, byte a, byte b, byte c, byte d, out uint value) => uiOpenTypeFeaturesGet(otf.DangerousGetHandle(), a, b, c, d, out value);

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiOpenTypeFeaturesForEach(IntPtr otf, uiOpenTypeFeaturesForEachFunc f, IntPtr data);
        public static void uiOpenTypeFeaturesForEach(FontFeaturesSafeHandle otf, uiOpenTypeFeaturesForEachFunc f, IntPtr data) => uiOpenTypeFeaturesForEach(otf.DangerousGetHandle(), f, data);
        public static void uiOpenTypeFeaturesForEach(FontFeaturesSafeHandle otf, uiOpenTypeFeaturesForEachFunc f) => uiOpenTypeFeaturesForEach(otf, f, IntPtr.Zero);

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewFeaturesAttribute(IntPtr otf);
        public static TextAttributeSafeHandle uiNewFeaturesAttribute(FontFeaturesSafeHandle otf) => new TextAttributeSafeHandle(uiNewFeaturesAttribute(otf.DangerousGetHandle()));

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiAttributeFeatures(IntPtr a);
        public static FontFeaturesSafeHandle uiAttributeFeatures(TextAttributeSafeHandle a) => new FontFeaturesSafeHandle(uiAttributeFeatures(a.DangerousGetHandle()));

        #region TODO: uiAttributedString
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uiForEach uiAttributedStringForEachAttributeFunc(IntPtr s, IntPtr a, UIntPtr start, UIntPtr end, IntPtr data);

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern IntPtr uiNewAttributedString(IntPtr initialString);
        public static AttributedTextSafeHandle uiNewAttributedString(string initialString)
        {
            IntPtr strPtr = UTF8Helper.ToUTF8Ptr(initialString);
            AttributedTextSafeHandle safeHandle = new AttributedTextSafeHandle(uiNewAttributedString(strPtr));
            Marshal.FreeHGlobal(strPtr);
            return safeHandle;
        }

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
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
        #endregion

        public struct uiFontDescriptor
        {
            IntPtr Family;
            double Size;
            uiTextWeight Weight;
            uiTextItalic Italic;
            uiTextStretch Stretch;

            public static explicit operator Font(uiFontDescriptor f) => new Font(UTF8Helper.ToUTF8Str(f.Family), f.Size, (FontWeight)f.Weight, (FontStyle)f.Italic, (FontStretch)f.Stretch);
            public static explicit operator uiFontDescriptor(Font f)
            {
                IntPtr strPtr = UTF8Helper.ToUTF8Ptr(f.Family);
                try
                {
                    return new uiFontDescriptor
                    {
                        Family = strPtr,
                        Size = f.Size,
                        Weight = (uiTextWeight)f.Weight,
                        Italic = (uiTextItalic)f.Style,
                        Stretch = (uiTextStretch)f.Weight
                    };
                }
                finally
                {
                    Marshal.FreeHGlobal(strPtr);
                }
            }
        }

        public enum uiDrawTextAlign : uint
        {
            uiDrawTextAlignLeft,
            uiDrawTextAlignCenter,
            uiDrawTextAlignRight
        }

        public struct uiDrawTextLayoutParams
        {
            IntPtr String;
            uiFontDescriptor DefaultFont;
            double Width;
            uiDrawTextAlign Align;
        }

        [DllImport(LibUIRef, CallingConvention = Cdecl, EntryPoint = "uiDrawNewTextLayout")]
        public static extern IntPtr _uiDrawNewTextLayout(uiDrawTextLayoutParams param);
        public static TextLayoutSafeHandle uiDrawNewTextLayout(uiDrawTextLayoutParams param) => new TextLayoutSafeHandle(_uiDrawNewTextLayout(param));

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiDrawFreeTextLayout(IntPtr tl);

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiDrawText(IntPtr c, IntPtr tl, double x, double y);
        public static void uiDrawText(LibUISafeHandle c, TextLayoutSafeHandle tl, double x, double y) => uiDrawText(c.DangerousGetHandle(), tl.DangerousGetHandle(), x, y);

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiDrawTextLayoutExtents(IntPtr tl, out double width, out double height);
        public static void uiDrawTextLayoutExtents(TextLayoutSafeHandle tl, out double width, out double height) => uiDrawTextLayoutExtents(tl.DangerousGetHandle(), out width, out height);

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiFontButtonFont(IntPtr b, out uiFontDescriptor desc);
        public static void uiFontButtonFont(ControlSafeHandle b, out uiFontDescriptor desc) => uiFontButtonFont(b.DangerousGetHandle(), out desc);

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiFontButtonOnChanged(IntPtr b, uiOnEventHandler f, IntPtr data);
        public static void uiFontButtonOnChanged(ControlSafeHandle b, uiOnEventHandler f, IntPtr data) => uiFontButtonOnChanged(b.DangerousGetHandle(), f, data);
        public static void uiFontButtonOnChanged(ControlSafeHandle b, uiOnEventHandler f) => uiFontButtonOnChanged(b, f, IntPtr.Zero);

        [DllImport(LibUIRef, CallingConvention = Cdecl, EntryPoint = "uiNewFontButton")]
        public static extern IntPtr _uiNewFontButton();
        public static ControlSafeHandle uiNewFontButton() => new ControlSafeHandle(_uiNewFontButton());

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiFreeFontButtonFont(uiFontDescriptor desc);

        [Flags]
        public enum uiModifiers : uint
        {
            uiModifierCtrl = 1 << 0,
            uiModifierAlt = 1 << 1,
            uiModifierShift = 1 << 2,
            uiModifierSuper = 1 << 3
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct uiAreaMouseEvent
        {
            public double X;
            public double Y;

            public double AreaWidth;
            public double AreaHeight;

            public bool Down;
            public bool Up;

            public int Count;

            public uiModifiers Modifiers;

            public ulong Held1To64;

            public static explicit operator MouseEventArgs(uiAreaMouseEvent e) =>
                new MouseEventArgs(new PointD(e.X, e.Y), new SizeD(e.AreaWidth, e.AreaHeight), e.Up, e.Down, e.Count, (KeyModifierFlags)e.Modifiers, e.Held1To64);
        }

        public enum uiExtKey : uint
        {
            uiExtKeyEscape = 1,
            uiExtKeyInsert, // equivalent to "Help" on Apple keyboards
            uiExtKeyDelete,
            uiExtKeyHome,
            uiExtKeyEnd,
            uiExtKeyPageUp,
            uiExtKeyPageDown,
            uiExtKeyUp,
            uiExtKeyDown,
            uiExtKeyLeft,
            uiExtKeyRight,
            uiExtKeyF1, // F1..F12 are guaranteed to be consecutive
            uiExtKeyF2,
            uiExtKeyF3,
            uiExtKeyF4,
            uiExtKeyF5,
            uiExtKeyF6,
            uiExtKeyF7,
            uiExtKeyF8,
            uiExtKeyF9,
            uiExtKeyF10,
            uiExtKeyF11,
            uiExtKeyF12,
            uiExtKeyN0, // numpad keys; independent of Num Lock state
            uiExtKeyN1, // N0..N9 are guaranteed to be consecutive
            uiExtKeyN2,
            uiExtKeyN3,
            uiExtKeyN4,
            uiExtKeyN5,
            uiExtKeyN6,
            uiExtKeyN7,
            uiExtKeyN8,
            uiExtKeyN9,
            uiExtKeyNDot,
            uiExtKeyNEnter,
            uiExtKeyNAdd,
            uiExtKeyNSubtract,
            uiExtKeyNMultiply,
            uiExtKeyNDivide
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct uiAreaKeyEvent
        {
            public byte Key;
            public uiExtKey ExtKey;
            public uiModifiers Modifier;
            public uiModifiers Modifiers;
            public bool Up;

            public static explicit operator KeyEventArgs(uiAreaKeyEvent e)
            {
                KeyModifierFlags m = 0;
                if (e.Modifiers.HasFlag(uiModifiers.uiModifierCtrl) || e.Modifiers.HasFlag(uiModifiers.uiModifierCtrl))
                    m |= KeyModifierFlags.Ctrl;
                if (e.Modifiers.HasFlag(uiModifiers.uiModifierAlt) || e.Modifiers.HasFlag(uiModifiers.uiModifierAlt))
                    m |= KeyModifierFlags.Alt;
                if (e.Modifiers.HasFlag(uiModifiers.uiModifierShift) || e.Modifiers.HasFlag(uiModifiers.uiModifierShift))
                    m |= KeyModifierFlags.Shift;
                if (e.Modifiers.HasFlag(uiModifiers.uiModifierSuper) || e.Modifiers.HasFlag(uiModifiers.uiModifierSuper))
                    m |= KeyModifierFlags.Super;

                return new KeyEventArgs(e.Key, (KeyExtension)e.ExtKey, m, e.Up);
            }
        }

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiColorButtonColor(IntPtr b, out double red, out double green, out double blue, out double alpha);
        public static void uiColorButtonColor(ControlSafeHandle b, out double red, out double green, out double blue, out double alpha) => uiColorButtonColor(b.DangerousGetHandle(), out red, out blue, out green, out alpha);
        public static Color uiColorButtonColor(ControlSafeHandle b)
        {
            uiColorButtonColor(b, out double red, out double green, out double blue, out double alpha);
            return new Color(red, green, blue, alpha);
        }

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiColorButtonSetColor(IntPtr b, double red, double green, double blue, double alpha);
        public static void uiColorButtonSetColor(ControlSafeHandle b, double red, double green, double blue, double alpha) => uiColorButtonSetColor(b.DangerousGetHandle(), red, green, blue, alpha);
        public static void uiColorButtonSetColor(ControlSafeHandle b, Color color) => uiColorButtonSetColor(b, color.R, color.G, color.B, color.A);

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiColorButtonOnChanged(IntPtr b, uiOnEventHandler f, IntPtr data);
        public static void uiColorButtonOnChanged(ControlSafeHandle b, uiOnEventHandler f, IntPtr data) => uiColorButtonOnChanged(b.DangerousGetHandle(), f, data);
        public static void uiColorButtonOnChanged(ControlSafeHandle b, uiOnEventHandler f) => uiColorButtonOnChanged(b, f, IntPtr.Zero);

        [DllImport(LibUIRef, CallingConvention = Cdecl, EntryPoint = "uiNewColorButton")]
        public static extern IntPtr _uiNewColorButton();
        public static ControlSafeHandle uiNewColorButton() => new ControlSafeHandle(_uiNewColorButton());

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiFormAppend(IntPtr f, IntPtr label, IntPtr c, bool stretchy);
        public static void uiFormAppend(ControlSafeHandle f, string label, ControlSafeHandle c, bool stretchy)
        {
            IntPtr strPtr = UTF8Helper.ToUTF8Ptr(label);
            uiFormAppend(c.DangerousGetHandle(), strPtr, c.DangerousGetHandle(), stretchy);
            Marshal.FreeHGlobal(strPtr);
        }

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiFormDelete(IntPtr f, int index);
        public static void uiFormDelete(ControlSafeHandle f, int index) => uiFormDelete(f.DangerousGetHandle(), index);

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern bool uiFormPadded(IntPtr f);
        public static bool uiFormPadded(ControlSafeHandle f) => uiFormPadded(f.DangerousGetHandle());

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiFormSetPadded(IntPtr f, bool padded);
        public static void uiFormSetPadded(ControlSafeHandle f, bool padded) => uiFormSetPadded(f.DangerousGetHandle(), padded);

        [DllImport(LibUIRef, CallingConvention = Cdecl, EntryPoint = "uiNewForm")]
        public static extern IntPtr _uiNewForm();
        public static ControlSafeHandle uiNewForm() => new ControlSafeHandle(_uiNewForm());

        public enum uiAlign : uint
        {
            uiAlignFill,
            uiAlignStart,
            uiAlignCenter,
            uiAlignEnd
        }

        public enum uiAt : uint
        {
            uiAtLeading,
            uiAtTop,
            uiAtTrailing,
            uiAtBottom
        }

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiGridAppend(IntPtr grid, IntPtr child, int left, int top, int xspan, int yspan, int hexpand, uiAlign halign, int vexpand, uiAlign valign);
        public static void uiGridAppend(ControlSafeHandle g, ControlSafeHandle c, int left, int top, int xspan, int yspan, int hexpand, Alignment halign, int vexpand, Alignment valign) => uiGridAppend(g.DangerousGetHandle(), c.DangerousGetHandle(), left, top, xspan, yspan, hexpand, (uiAlign)halign, vexpand, (uiAlign)valign);

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiGridInsertAt(IntPtr grid, IntPtr child, IntPtr existing, uiAt at, int xspan, int yspan, int hexpand, uiAlign halign, int vexpand, uiAlign valign);
        public static void uiGridInsertAt(ControlSafeHandle g, ControlSafeHandle c, ControlSafeHandle existing, RelativeAlignment at, int xspan, int yspan, int hexpand, Alignment halign, int vexpand, Alignment valign) => uiGridInsertAt(g.DangerousGetHandle(), c.DangerousGetHandle(), existing.DangerousGetHandle(), (uiAt)at, xspan, yspan, hexpand, (uiAlign)halign, vexpand, (uiAlign)valign);

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern bool uiGridPadded(IntPtr grid);
        public static bool uiGridPadded(ControlSafeHandle g) => uiGridPadded(g.DangerousGetHandle());

        [DllImport(LibUIRef, CallingConvention = Cdecl)]
        public static extern void uiGridSetPadded(IntPtr grid, bool padded);
        public static void uiGridSetPadded(ControlSafeHandle g, bool padded) => uiGridSetPadded(g.DangerousGetHandle(), padded);

        [DllImport(LibUIRef, CallingConvention = Cdecl, EntryPoint = "uiNewGrid")]
        public static extern IntPtr _uiNewGrid();
        public static ControlSafeHandle uiNewGrid() => new ControlSafeHandle(_uiNewGrid());


        private const string Kernel32Ref = "kernel32.dll";
        private const string User32Ref = "user32.dll";

        [DllImport(Kernel32Ref, SetLastError = true)]
        public static extern IntPtr GetConsoleWindow();
        [DllImport(User32Ref, SetLastError = true)]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        public static void winntConsoleWindowVisible(bool visible)
        {
            IntPtr ptr = GetConsoleWindow();
            if (visible)
                ShowWindow(ptr, 4); // 4 = SW_SHOWNOACTIVATE
            else
                ShowWindow(ptr, 0); // 0 = SW_HIDE
        }
    }
}