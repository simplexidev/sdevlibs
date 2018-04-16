using NativeLibraryLoader;
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace LibUISharp.Native.Libraries
{
    // C Header: ui.h
    internal static class LibuiLibrary
    {
        private const CallingConvention callingConvention = CallingConvention.Cdecl;
        private const LayoutKind layoutKind = LayoutKind.Sequential;

        private static class FunctionLoader
        {
            private static readonly string[] WinNTLibNames = new[] { "libui.dll" };
            private static readonly string[] LinuxLibNames = new[] { "libui.so", "libui.so.0" };
            private static readonly string[] MacOSLibNames = new[] { "libui.dylib", "libui.A.dylib" };

            private static NativeLibrary LibuiNativeLibrary
            {
                get
                {
                    if (PlatformHelper.IsWinNT) return new NativeLibrary(WinNTLibNames);
                    else if (PlatformHelper.IsLinux) return new NativeLibrary(LinuxLibNames);
                    else if (PlatformHelper.IsMacOS) return new NativeLibrary(MacOSLibNames);
                    else throw new PlatformNotSupportedException();
                }
            }

            public static T Load<T>(string name) => LibuiNativeLibrary.LoadFunction<T>(name);
        }

        public static class UTF8Helper
        {
            //! You MUST call System.Marshal.FreeHGlobal() after using this
            //! or it will cause a memory leak.
            public static IntPtr ToUTF8Ptr(string str)
            {
                if (str == null)
                    return IntPtr.Zero;

                byte[] bytes = Encoding.UTF8.GetBytes(str);
                Array.Resize(ref bytes, bytes.Length + 1);
                bytes[bytes.Length - 1] = 0;
                IntPtr ptr = Marshal.AllocHGlobal(bytes.Length);
                Marshal.Copy(bytes, 0, ptr, bytes.Length);
                return ptr;
            }

            public static string ToUTF16Str(IntPtr ptr)
            {
                if (ptr == IntPtr.Zero)
                    return string.Empty;

                byte b = Marshal.ReadByte(ptr);
                int i = 0;
                while (b != 0)
                    b = Marshal.ReadByte(ptr, ++i);

                byte[] bytes = new byte[i];
                Marshal.Copy(ptr, bytes, 0, bytes.Length);
                string str = Encoding.UTF8.GetString(bytes, 0, bytes.Length);
                uiFreeText(ptr);
                return str;
            }
        }

        public enum uiForEach : uint
        {
            uiForEachContinue,
            uiForEachStop
        }

        [StructLayout(layoutKind)]
        public struct uiInitOptions
        {
            public UIntPtr Size;
        }

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate IntPtr uiInit_t(ref uiInitOptions options);
        public static IntPtr uiInit(ref uiInitOptions options) => FunctionLoader.Load<uiInit_t>("uiInit")(ref options);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiUnInit_t();
        public static void uiUnInit() => FunctionLoader.Load<uiUnInit_t>("uiUnInit")();

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiFreeInitError_t(IntPtr err);
        public static void uiFreeInitError(IntPtr err) => FunctionLoader.Load<uiFreeInitError_t>("uiFreeInitError")(err);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiMain_t();
        public static void uiMain() => FunctionLoader.Load<uiMain_t>("uiMain")();

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiMainSteps_t();
        public static void uiMainSteps() => FunctionLoader.Load<uiMainSteps_t>("uiMainSteps")();

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate bool uiMainStep_t(bool wait);
        public static bool uiMainStep(bool wait) => FunctionLoader.Load<uiMainStep_t>("uiMainStep")(wait);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiQuit_t();
        public static void uiQuit() => FunctionLoader.Load<uiQuit_t>("uiQuit")();

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiQueueMain_t(uiQueueMain_tf f, IntPtr data);
        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiQueueMain_tf(IntPtr data);
        public static void uiQueueMain(uiQueueMain_tf f, IntPtr data) => FunctionLoader.Load<uiQueueMain_t>("uiQueueMain")(f, data);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiOnShouldQuit_t(uiOnShouldQuit_tf f, IntPtr data);
        [UnmanagedFunctionPointer(callingConvention)]
        public delegate bool uiOnShouldQuit_tf(IntPtr data);
        public static void uiOnShouldQuit(uiOnShouldQuit_tf f, IntPtr data) => FunctionLoader.Load<uiOnShouldQuit_t>("uiOnShouldQuit")(f, data);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiFreeText_t(IntPtr text);
        public static void uiFreeText(IntPtr text) => FunctionLoader.Load<uiFreeText_t>("uiFreeText")(text);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiControlDestroy_t(IntPtr c);
        public static void uiControlDestroy(IntPtr c) => FunctionLoader.Load<uiControlDestroy_t>("uiControlDestroy")(c);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate UIntPtr uiControlHandle_t(IntPtr c);
        public static UIntPtr uiControlHandle(IntPtr c) => FunctionLoader.Load<uiControlHandle_t>("uiControlHandle")(c);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate IntPtr uiControlParent_t(IntPtr c);
        public static IntPtr uiControlParent(IntPtr c) => FunctionLoader.Load<uiControlParent_t>("uiControlParent")(c);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiControlSetParent_t(IntPtr c, IntPtr parent);
        public static void uiControlSetParent(IntPtr c, IntPtr parent) => FunctionLoader.Load<uiControlSetParent_t>("uiControlSetParent")(c, parent);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate bool uiControlTopLevel_t(IntPtr c);
        public static bool uiControlTopLevel(IntPtr c) => FunctionLoader.Load<uiControlTopLevel_t>("uiControlTopLevel")(c);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate bool uiControlVisible_t(IntPtr c);
        public static bool uiControlVisible(IntPtr c) => FunctionLoader.Load<uiControlVisible_t>("uiControlVisible")(c);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiControlShow_t(IntPtr c);
        public static void uiControlShow(IntPtr c) => FunctionLoader.Load<uiControlShow_t>("uiControlShow")(c);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiControlHide_t(IntPtr c);
        public static void uiControlHide(IntPtr c) => FunctionLoader.Load<uiControlHide_t>("uiControlHide")(c);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate bool uiControlEnabled_t(IntPtr c);
        public static bool uiControlEnabled(IntPtr c) => FunctionLoader.Load<uiControlEnabled_t>("uiControlEnabled")(c);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate bool uiControlEnable_t(IntPtr c);
        public static void uiControlEnable(IntPtr c) => FunctionLoader.Load<uiControlEnable_t>("uiControlEnable")(c);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate bool uiControlDisable_t(IntPtr c);
        public static void uiControlDisable(IntPtr c) => FunctionLoader.Load<uiControlDisable_t>("uiControlDisable")(c);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate bool uiControlVerifySetParent_t(IntPtr c, IntPtr parent);
        public static void uiControlVerifySetParent(IntPtr c, IntPtr parent) => FunctionLoader.Load<uiControlVerifySetParent_t>("uiControlVerifySetParent")(c, parent);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate bool uiControlEnabledToUser_t(IntPtr c);
        public static bool uiControlEnabledToUser(IntPtr c) => FunctionLoader.Load<uiControlEnabledToUser_t>("uiControlEnabledToUser")(c);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate IntPtr uiWindowTitle_t(IntPtr w);
        public static IntPtr uiWindowTitle(IntPtr w) => FunctionLoader.Load<uiWindowTitle_t>("uiWindowTitle")(w);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiWindowSetTitle_t(IntPtr w, IntPtr title);
        public static void uiWindowSetTitle(IntPtr w, IntPtr title) => FunctionLoader.Load<uiWindowSetTitle_t>("uiWindowSetTitle")(w, title);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiWindowContentSize_t(IntPtr w, out int width, out int height);
        public static void uiWindowContentSize(IntPtr w, out int width, out int height) => FunctionLoader.Load<uiWindowContentSize_t>("uiWindowContentSize")(w, out width, out height);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiWindowSetContentSize_t(IntPtr w, int width, int height);
        public static void uiWindowSetContentSize(IntPtr w, int width, int height) => FunctionLoader.Load<uiWindowSetContentSize_t>("uiWindowSetContentSize")(w, width, height);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate bool uiWindowFullscreen_t(IntPtr w);
        public static bool uiWindowFullscreen(IntPtr w) => FunctionLoader.Load<uiWindowFullscreen_t>("uiWindowFullscreen")(w);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiWindowSetFullscreen_t(IntPtr w, bool fullscreen);
        public static void uiWindowSetFullscreen(IntPtr w, bool fullscreen) => FunctionLoader.Load<uiWindowSetFullscreen_t>("uiWindowSetFullscreen")(w, fullscreen);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiWindowOnContentSizeChanged_t(IntPtr w, uiWindowOnContentSizeChanged_tf f, IntPtr data);
        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiWindowOnContentSizeChanged_tf(IntPtr w, IntPtr data);
        public static void uiWindowOnContentSizeChanged(IntPtr w, uiWindowOnContentSizeChanged_tf f, IntPtr data) => FunctionLoader.Load<uiWindowOnContentSizeChanged_t>("uiWindowOnContentSizeChanged")(w, f, data);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiWindowOnClosing_t(IntPtr w, uiWindowOnClosing_tf f, IntPtr data);
        [UnmanagedFunctionPointer(callingConvention)]
        public delegate bool uiWindowOnClosing_tf(IntPtr w, IntPtr data);
        public static void uiWindowOnClosing(IntPtr w, uiWindowOnClosing_tf f, IntPtr data) => FunctionLoader.Load<uiWindowOnClosing_t>("uiWindowOnClosing")(w, f, data);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate bool uiWindowBorderless_t(IntPtr w);
        public static bool uiWindowBorderless(IntPtr w) => FunctionLoader.Load<uiWindowBorderless_t>("uiWindowBorderless")(w);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiWindowSetBorderless_t(IntPtr w, bool borderless);
        public static void uiWindowSetBorderless(IntPtr w, bool borderless) => FunctionLoader.Load<uiWindowSetBorderless_t>("uiWindowSetBorderless")(w, borderless);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiWindowSetChild_t(IntPtr w, IntPtr child);
        public static void uiWindowSetChild(IntPtr w, IntPtr child) => FunctionLoader.Load<uiWindowSetChild_t>("uiWindowSetChild")(w, child);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate bool uiWindowMargined_t(IntPtr w);
        public static bool uiWindowMargined(IntPtr w) => FunctionLoader.Load<uiWindowMargined_t>("uiWindowMargined")(w);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiWindowSetMargined_t(IntPtr w, bool margined);
        public static void uiWindowSetMargined(IntPtr w, bool margined) => FunctionLoader.Load<uiWindowSetMargined_t>("uiWindowSetMargined")(w, margined);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate IntPtr uiNewWindow_t(IntPtr title, int width, int height, bool hasMenubar);
        public static IntPtr uiNewWindow(IntPtr title, int width, int height, bool hasMenubar) => FunctionLoader.Load<uiNewWindow_t>("uiNewWindow")(title, width, height, hasMenubar);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate IntPtr uiButtonText_t(IntPtr b);
        public static IntPtr uiButtonText(IntPtr b) => FunctionLoader.Load<uiButtonText_t>("uiButtonText")(b);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiButtonSetText_t(IntPtr b, IntPtr title);
        public static void uiButtonSetText(IntPtr b, IntPtr title) => FunctionLoader.Load<uiButtonSetText_t>("uiButtonSetText")(b, title);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiButtonOnClicked_t(IntPtr b, uiButtonOnClicked_tf f, IntPtr data);
        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiButtonOnClicked_tf(IntPtr b, IntPtr data);
        public static void uiButtonOnClicked(IntPtr b, uiButtonOnClicked_tf f, IntPtr data) => FunctionLoader.Load<uiButtonOnClicked_t>("uiButtonOnClicked")(b, f, data);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate IntPtr uiNewButton_t(IntPtr text);
        public static IntPtr uiNewButton(IntPtr text) => FunctionLoader.Load<uiNewButton_t>("uiNewButton")(text);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiBoxAppend_t(IntPtr b, IntPtr child, bool stretchy);
        public static void uiBoxAppend(IntPtr b, IntPtr child, bool stretchy) => FunctionLoader.Load<uiBoxAppend_t>("uiBoxAppend")(b, child, stretchy);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiBoxDelete_t(IntPtr b, int index);
        public static void uiBoxDelete(IntPtr b, int index) => FunctionLoader.Load<uiBoxDelete_t>("uiBoxDelete")(b, index);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate bool uiBoxPadded_t(IntPtr b);
        public static bool uiBoxPadded(IntPtr b) => FunctionLoader.Load<uiBoxPadded_t>("uiBoxPadded")(b);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiBoxSetPadded_t(IntPtr b, bool padded);
        public static void uiBoxSetPadded(IntPtr b, bool padded) => FunctionLoader.Load<uiBoxSetPadded_t>("uiButtonSetPadded")(b, padded);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate IntPtr uiNewHorizontalBox_t();
        public static IntPtr uiNewHorizontalBox() => FunctionLoader.Load<uiNewHorizontalBox_t>("uiNewHorizontalBox")();

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate IntPtr uiNewVerticalBox_t();
        public static IntPtr uiNewVerticalBox() => FunctionLoader.Load<uiNewVerticalBox_t>("uiNewVerticalBox")();

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate IntPtr uiCheckboxText_t(IntPtr c);
        public static IntPtr uiCheckboxText(IntPtr c) => FunctionLoader.Load<uiCheckboxText_t>("uiCheckboxText")(c);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiCheckboxSetText_t(IntPtr c, IntPtr text);
        public static void uiCheckboxSetText(IntPtr c, IntPtr text) => FunctionLoader.Load<uiCheckboxSetText_t>("uiCheckboxSetText")(c, text);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiCheckboxOnToggled_t(IntPtr c, uiCheckboxOnToggled_tf f, IntPtr data);
        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiCheckboxOnToggled_tf(IntPtr c, IntPtr data);
        public static void uiCheckboxOnToggled(IntPtr c, uiCheckboxOnToggled_tf f, IntPtr data) => FunctionLoader.Load<uiCheckboxOnToggled_t>("uiCheckboxOnToggled")(c, f, data);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate bool uiCheckboxChecked_t(IntPtr c);
        public static bool uiCheckboxChecked(IntPtr c) => FunctionLoader.Load<uiCheckboxChecked_t>("uiCheckboxChecked")(c);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiCheckboxSetChecked_t(IntPtr c, bool @checked);
        public static void uiCheckboxSetChecked(IntPtr c, bool @checked) => FunctionLoader.Load<uiCheckboxSetChecked_t>("uiCheckboxSetChecked")(c, @checked);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate IntPtr uiNewCheckbox_t(IntPtr text);
        public static IntPtr uiNewCheckbox(IntPtr text) => FunctionLoader.Load<uiNewCheckbox_t>("uiNewCheckbox")(text);

        //TODO: From here down is broken code.
        //\/////////////////////////////////////////////////////////////////

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate IntPtr uiEntryText(IntPtr e);
        public static string uiEntryText(ControlSafeHandle e) => UTF8Helper.ToUTF8Str(uiEntryText(e.DangerousGetHandle()));

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiEntrySetText(IntPtr e, IntPtr text);
        public static void uiEntrySetText(ControlSafeHandle e, string text)
        {
            IntPtr strPtr = UTF8Helper.ToUTF8Ptr(text);
            uiEntrySetText(e.DangerousGetHandle(), strPtr);
            Marshal.FreeHGlobal(strPtr);
        }

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiEntryOnChanged(IntPtr e, uiOnEventHandler f, IntPtr data);
        public static void uiEntryOnChanged(ControlSafeHandle e, uiOnEventHandler f, IntPtr data) => uiEntryOnChanged(e.DangerousGetHandle(), f, data);
        public static void uiEntryOnChanged(ControlSafeHandle e, uiOnEventHandler f) => uiEntryOnChanged(e, f, IntPtr.Zero);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate bool uiEntryReadOnly(IntPtr e);
        public static bool uiEntryReadOnly(ControlSafeHandle e) => uiEntryReadOnly(e.DangerousGetHandle());

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiEntrySetReadOnly(IntPtr e, bool @readonly);
        public static void uiEntrySetReadOnly(ControlSafeHandle e, bool @readonly) => uiEntrySetReadOnly(e.DangerousGetHandle(), @readonly);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate IntPtr _uiNewEntry();
        public static ControlSafeHandle uiNewEntry() => new ControlSafeHandle(_uiNewEntry());

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate IntPtr _uiNewPasswordEntry();
        public static ControlSafeHandle uiNewPasswordEntry() => new ControlSafeHandle(_uiNewPasswordEntry());

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate IntPtr _uiNewSearchEntry();
        public static ControlSafeHandle uiNewSearchEntry() => new ControlSafeHandle(_uiNewSearchEntry());

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate IntPtr uiLabelText(IntPtr l);
        public static string uiLabelText(ControlSafeHandle l) => UTF8Helper.ToUTF8Str(uiLabelText(l.DangerousGetHandle()));

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiLabelSetText(IntPtr l, IntPtr text);
        public static void uiLabelSetText(ControlSafeHandle l, string text)
        {
            IntPtr strPtr = UTF8Helper.ToUTF8Ptr(text);
            uiLabelSetText(l.DangerousGetHandle(), strPtr);
            Marshal.FreeHGlobal(strPtr);
        }

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate IntPtr uiNewLabel(IntPtr text);
        public static ControlSafeHandle uiNewLabel(string text)
        {
            IntPtr strPtr = UTF8Helper.ToUTF8Ptr(text);
            ControlSafeHandle safeHandle = new ControlSafeHandle(uiNewLabel(strPtr));
            Marshal.FreeHGlobal(strPtr);
            return safeHandle;
        }

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiTabAppend(IntPtr t, IntPtr name, IntPtr c);
        public static void uiTabAppend(ControlSafeHandle t, string name, ControlSafeHandle c)
        {
            IntPtr strPtr = UTF8Helper.ToUTF8Ptr(name);
            uiTabAppend(t.DangerousGetHandle(), strPtr, c.DangerousGetHandle());
            Marshal.FreeHGlobal(strPtr);
        }

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiTabInsertAt(IntPtr t, IntPtr name, int before, IntPtr c);
        public static void uiTabInsertAt(ControlSafeHandle t, string name, int before, ControlSafeHandle c)
        {
            IntPtr strPtr = UTF8Helper.ToUTF8Ptr(name);
            uiTabInsertAt(t.DangerousGetHandle(), strPtr, before, c.DangerousGetHandle());
            Marshal.FreeHGlobal(strPtr);
        }

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiTabDelete(IntPtr t, int index);
        public static void uiTabDelete(ControlSafeHandle t, int index) => uiTabDelete(t.DangerousGetHandle(), index);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate int uiTabNumPages(IntPtr t);
        public static int uiTabNumPages(ControlSafeHandle t) => uiTabNumPages(t.DangerousGetHandle());

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate bool uiTabMargined(IntPtr t, int page);
        public static bool uiTabMargined(ControlSafeHandle t, int page) => uiTabMargined(t.DangerousGetHandle(), page);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiTabSetMargined(IntPtr t, int page, bool margined);
        public static void uiTabSetMargined(ControlSafeHandle t, int page, bool margined) => uiTabSetMargined(t.DangerousGetHandle(), page, margined);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate IntPtr _uiNewTab();
        public static ControlSafeHandle uiNewTab() => new ControlSafeHandle(_uiNewTab());

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate IntPtr uiGroupTitle(IntPtr g);
        public static string uiGroupTitle(ControlSafeHandle g) => UTF8Helper.ToUTF8Str(uiGroupTitle(g.DangerousGetHandle()));

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiGroupSetTitle(IntPtr g, IntPtr title);
        public static void uiGroupSetTitle(ControlSafeHandle g, string title)
        {
            IntPtr strPtr = UTF8Helper.ToUTF8Ptr(title);
            uiGroupSetTitle(g.DangerousGetHandle(), strPtr);
            Marshal.FreeHGlobal(strPtr);
        }

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiGroupSetChild(IntPtr g, IntPtr child);
        public static void uiGroupSetChild(ControlSafeHandle g, ControlSafeHandle child) => uiGroupSetChild(g.DangerousGetHandle(), child.DangerousGetHandle());

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate bool uiGroupMargined(IntPtr g);
        public static bool uiGroupMargined(ControlSafeHandle g) => uiGroupMargined(g.DangerousGetHandle());

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiGroupSetMargined(IntPtr g, bool margined);
        public static void uiGroupSetMargined(ControlSafeHandle g, bool margined) => uiGroupSetMargined(g.DangerousGetHandle(), margined);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate IntPtr uiNewGroup(IntPtr title);
        public static ControlSafeHandle uiNewGroup(string title)
        {
            IntPtr strPtr = UTF8Helper.ToUTF8Ptr(title);
            ControlSafeHandle safeHandle = new ControlSafeHandle(uiNewGroup(strPtr));
            Marshal.FreeHGlobal(strPtr);
            return safeHandle;
        }

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate int uiSpinboxValue(IntPtr s);
        public static int uiSpinboxValue(ControlSafeHandle s) => uiSpinboxValue(s.DangerousGetHandle());

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiSpinboxSetValue(IntPtr s, int value);
        public static void uiSpinboxSetValue(ControlSafeHandle s, int value) => uiSpinboxSetValue(s.DangerousGetHandle(), value);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiSpinboxOnChanged(IntPtr s, uiOnEventHandler f, IntPtr data);
        public static void uiSpinboxOnChanged(ControlSafeHandle s, uiOnEventHandler f, IntPtr data) => uiSpinboxOnChanged(s.DangerousGetHandle(), f, data);
        public static void uiSpinboxOnChanged(ControlSafeHandle s, uiOnEventHandler f) => uiSpinboxOnChanged(s, f, IntPtr.Zero);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate IntPtr _uiNewSpinbox(int min, int max);
        public static ControlSafeHandle uiNewSpinbox(int min, int max) => new ControlSafeHandle(_uiNewSpinbox(min, max));

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate int uiSliderValue(IntPtr s);
        public static int uiSliderValue(ControlSafeHandle s) => uiSliderValue(s.DangerousGetHandle());

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiSliderSetValue(IntPtr s, int value);
        public static void uiSliderSetValue(ControlSafeHandle s, int value) => uiSliderSetValue(s.DangerousGetHandle(), value);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiSliderOnChanged(IntPtr s, uiOnEventHandler f, IntPtr data);
        public static void uiSliderOnChanged(ControlSafeHandle s, uiOnEventHandler f, IntPtr data) => uiSliderOnChanged(s.DangerousGetHandle(), f, data);
        public static void uiSliderOnChanged(ControlSafeHandle s, uiOnEventHandler f) => uiSliderOnChanged(s, f, IntPtr.Zero);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate IntPtr _uiNewSlider(int min, int max);
        public static ControlSafeHandle uiNewSlider(int min, int max) => new ControlSafeHandle(_uiNewSlider(min, max));

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate int uiProgressBarValue(IntPtr p);
        public static int uiProgressBarValue(ControlSafeHandle p) => uiProgressBarValue(p.DangerousGetHandle());

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiProgressBarSetValue(IntPtr p, int n);
        public static void uiProgressBarSetValue(ControlSafeHandle p, int n) => uiProgressBarSetValue(p.DangerousGetHandle(), n);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate IntPtr _uiNewProgressBar();
        public static ControlSafeHandle uiNewProgressBar() => new ControlSafeHandle(_uiNewProgressBar());

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate IntPtr _uiNewHorizontalSeparator();
        public static ControlSafeHandle uiNewHorizontalSeparator() => new ControlSafeHandle(_uiNewHorizontalSeparator());

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate IntPtr _uiNewVerticalSeparator();
        public static ControlSafeHandle uiNewVerticalSeparator() => new ControlSafeHandle(_uiNewVerticalSeparator());

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiComboboxAppend(IntPtr c, IntPtr text);
        public static void uiComboboxAppend(ControlSafeHandle c, string text)
        {
            IntPtr strPtr = UTF8Helper.ToUTF8Ptr(text);
            uiComboboxAppend(c.DangerousGetHandle(), strPtr);
            Marshal.FreeHGlobal(strPtr);
        }

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate int uiComboboxSelected(IntPtr c);
        public static int uiComboboxSelected(ControlSafeHandle c) => uiComboboxSelected(c.DangerousGetHandle());

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiComboboxSetSelected(IntPtr c, int n);
        public static void uiComboboxSetSelected(ControlSafeHandle c, int n) => uiComboboxSetSelected(c.DangerousGetHandle(), n);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiComboboxOnSelected(IntPtr c, uiOnEventHandler f, IntPtr data);
        public static void uiComboboxOnSelected(ControlSafeHandle c, uiOnEventHandler f, IntPtr data) => uiComboboxOnSelected(c.DangerousGetHandle(), f, data);
        public static void uiComboboxOnSelected(ControlSafeHandle c, uiOnEventHandler f) => uiComboboxOnSelected(c, f, IntPtr.Zero);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate IntPtr _uiNewCombobox();
        public static ControlSafeHandle uiNewCombobox() => new ControlSafeHandle(_uiNewCombobox());

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiEditableComboboxAppend(IntPtr c, IntPtr text);
        public static void uiEditableComboboxAppend(ControlSafeHandle c, string text)
        {
            IntPtr strPtr = UTF8Helper.ToUTF8Ptr(text);
            uiEditableComboboxAppend(c.DangerousGetHandle(), strPtr);
            Marshal.FreeHGlobal(strPtr);
        }

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate IntPtr uiEditableComboboxText(IntPtr comboBox);
        public static string uiEditableComboboxText(ControlSafeHandle c) => UTF8Helper.ToUTF8Str(uiEditableComboboxText(c.DangerousGetHandle()));

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiEditableComboboxSetText(IntPtr c, IntPtr text);
        public static void uiEditableComboboxSetText(ControlSafeHandle c, string text)
        {
            IntPtr strPtr = UTF8Helper.ToUTF8Ptr(text);
            uiEditableComboboxSetText(c.DangerousGetHandle(), strPtr);
            Marshal.FreeHGlobal(strPtr);

        }

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiEditableComboboxOnChanged(IntPtr c, uiOnEventHandler f, IntPtr data);
        public static void uiEditableComboboxOnChanged(ControlSafeHandle c, uiOnEventHandler f, IntPtr data) => uiEditableComboboxOnChanged(c.DangerousGetHandle(), f, data);
        public static void uiEditableComboboxOnChanged(ControlSafeHandle c, uiOnEventHandler f) => uiEditableComboboxOnChanged(c, f);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate IntPtr _uiNewEditableCombobox();
        public static ControlSafeHandle uiNewEditableCombobox() => new ControlSafeHandle(_uiNewEditableCombobox());

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiRadioButtonsAppend(IntPtr r, IntPtr text);
        public static void uiRadioButtonsAppend(ControlSafeHandle r, string text)
        {
            IntPtr strPtr = UTF8Helper.ToUTF8Ptr(text);
            uiRadioButtonsAppend(r.DangerousGetHandle(), strPtr);
            Marshal.FreeHGlobal(strPtr);
        }

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate int uiRadioButtonsSelected(IntPtr r);
        public static int uiRadioButtonsSelected(ControlSafeHandle r) => uiRadioButtonsSelected(r.DangerousGetHandle());

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiRadioButtonsSetSelected(IntPtr r, int n);
        public static void uiRadioButtonsSetSelected(ControlSafeHandle r, int n) => uiRadioButtonsSetSelected(r.DangerousGetHandle(), n);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiRadioButtonsOnSelected(IntPtr r, uiOnEventHandler f, IntPtr data);
        public static void uiRadioButtonsOnSelected(ControlSafeHandle r, uiOnEventHandler f, IntPtr data) => uiRadioButtonsOnSelected(r.DangerousGetHandle(), f, data);
        public static void uiRadioButtonsOnSelected(ControlSafeHandle r, uiOnEventHandler f) => uiRadioButtonsOnSelected(r, f, IntPtr.Zero);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate IntPtr _uiNewRadioButtons();
        public static ControlSafeHandle uiNewRadioButtons() => new ControlSafeHandle(_uiNewRadioButtons());

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate IntPtr _uiNewDateTimePicker();
        public static ControlSafeHandle uiNewDateTimePicker() => new ControlSafeHandle(_uiNewDateTimePicker());

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate IntPtr _uiNewDatePicker();
        public static ControlSafeHandle uiNewDatePicker() => new ControlSafeHandle(_uiNewDatePicker());

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate IntPtr _uiNewTimePicker();
        public static ControlSafeHandle uiNewTimePicker() => new ControlSafeHandle(_uiNewTimePicker());

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate IntPtr uiMultilineEntryText(IntPtr e);
        public static string uiMultilineEntryText(ControlSafeHandle e) => UTF8Helper.ToUTF8Str(uiMultilineEntryText(e.DangerousGetHandle()));

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiMultilineEntrySetText(IntPtr e, IntPtr text);
        public static void uiMultilineEntrySetText(ControlSafeHandle e, string text)
        {
            IntPtr strPtr = UTF8Helper.ToUTF8Ptr(text);
            uiMultilineEntrySetText(e.DangerousGetHandle(), strPtr);
            Marshal.FreeHGlobal(strPtr);
        }

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiMultilineEntryAppend(IntPtr e, IntPtr text);
        public static void uiMultilineEntryAppend(ControlSafeHandle e, params string[] lines)
        {
            foreach (string s in lines)
            {
                IntPtr strPtr = UTF8Helper.ToUTF8Ptr(s);
                uiMultilineEntryAppend(e.DangerousGetHandle(), strPtr);
                Marshal.FreeHGlobal(strPtr);
            }
        }

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiMultilineEntryOnChanged(IntPtr e, uiOnEventHandler f, IntPtr data);
        public static void uiMultilineEntryOnChanged(ControlSafeHandle e, uiOnEventHandler f, IntPtr data) => uiMultilineEntryOnChanged(e.DangerousGetHandle(), f, data);
        public static void uiMultilineEntryOnChanged(ControlSafeHandle e, uiOnEventHandler f) => uiMultilineEntryOnChanged(e, f, IntPtr.Zero);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate bool uiMultilineEntryReadOnly(IntPtr e);
        public static bool uiMultilineEntryReadOnly(ControlSafeHandle e) => uiMultilineEntryReadOnly(e.DangerousGetHandle());

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiMultilineEntrySetReadOnly(IntPtr e, bool @readonly);
        public static void uiMultilineEntrySetReadOnly(ControlSafeHandle e, bool @readonly) => uiMultilineEntrySetReadOnly(e.DangerousGetHandle(), @readonly);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate IntPtr _uiNewMultilineEntry();
        public static ControlSafeHandle uiNewMultilineEntry() => new ControlSafeHandle(_uiNewMultilineEntry());

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate IntPtr _uiNewNonWrappingMultilineEntry();
        public static ControlSafeHandle uiNewNonWrappingMultilineEntry() => new ControlSafeHandle(_uiNewNonWrappingMultilineEntry());

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiMenuItemEnable(IntPtr m);
        public static void uiMenuItemEnable(ControlSafeHandle m) => uiMenuItemEnable(m.DangerousGetHandle());

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiMenuItemDisable(IntPtr m);
        public static void uiMenuItemDisable(ControlSafeHandle m) => uiMenuItemDisable(m.DangerousGetHandle());

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void uiMenuItemOnClickedHandler(IntPtr menuItem, IntPtr window, IntPtr data);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiMenuItemOnClicked(IntPtr m, uiMenuItemOnClickedHandler f, IntPtr data);
        public static void uiMenuItemOnClicked(ControlSafeHandle m, uiMenuItemOnClickedHandler f, IntPtr data) => uiMenuItemOnClicked(m.DangerousGetHandle(), f, data);
        public static void uiMenuItemOnClicked(ControlSafeHandle m, uiMenuItemOnClickedHandler f) => uiMenuItemOnClicked(m, f, IntPtr.Zero);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate bool uiMenuItemChecked(IntPtr m);
        public static bool uiMenuItemChecked(ControlSafeHandle m) => uiMenuItemChecked(m.DangerousGetHandle());

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiMenuItemSetChecked(IntPtr m, bool @checked);
        public static void uiMenuItemSetChecked(ControlSafeHandle m, bool @checked) => uiMenuItemSetChecked(m.DangerousGetHandle(), @checked);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate IntPtr uiMenuAppendItem(IntPtr m, IntPtr name);
        public static ControlSafeHandle uiMenuAppendItem(ControlSafeHandle m, string name)
        {
            IntPtr strPtr = UTF8Helper.ToUTF8Ptr(name);
            ControlSafeHandle safeHandle = new ControlSafeHandle(uiMenuAppendItem(m.DangerousGetHandle(), strPtr));
            Marshal.FreeHGlobal(strPtr);
            return safeHandle;
        }

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate IntPtr uiMenuAppendCheckItem(IntPtr m, IntPtr name);
        public static ControlSafeHandle uiMenuAppendCheckItem(ControlSafeHandle m, string name)
        {
            IntPtr strPtr = UTF8Helper.ToUTF8Ptr(name);
            ControlSafeHandle safeHandle = new ControlSafeHandle(uiMenuAppendCheckItem(m.DangerousGetHandle(), strPtr));
            Marshal.FreeHGlobal(strPtr);
            return safeHandle;
        }

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate IntPtr uiMenuAppendQuitItem(IntPtr m);
        public static ControlSafeHandle uiMenuAppendQuitItem(ControlSafeHandle m) => new ControlSafeHandle(uiMenuAppendQuitItem(m.DangerousGetHandle()));

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate IntPtr uiMenuAppendPreferencesItem(IntPtr m);
        public static ControlSafeHandle uiMenuAppendPreferencesItem(ControlSafeHandle m) => new ControlSafeHandle(uiMenuAppendPreferencesItem(m.DangerousGetHandle()));

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate IntPtr uiMenuAppendAboutItem(IntPtr m);
        public static ControlSafeHandle uiMenuAppendAboutItem(ControlSafeHandle m) => new ControlSafeHandle(uiMenuAppendAboutItem(m.DangerousGetHandle()));

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiMenuAppendSeparator(IntPtr m);
        public static void uiMenuAppendSeparator(ControlSafeHandle m) => uiMenuAppendSeparator(m.DangerousGetHandle());

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate IntPtr uiNewMenu(IntPtr name);
        public static ControlSafeHandle uiNewMenu(string name)
        {
            IntPtr strPtr = UTF8Helper.ToUTF8Ptr(name);
            ControlSafeHandle safeHandle = new ControlSafeHandle(uiNewMenu(strPtr));
            Marshal.FreeHGlobal(strPtr);
            return safeHandle;
        }

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate IntPtr uiOpenFile(IntPtr parent);
        public static string uiOpenFile(ControlSafeHandle parent) => UTF8Helper.ToUTF8Str(uiOpenFile(parent.DangerousGetHandle()));

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate IntPtr uiSaveFile(IntPtr parent);
        public static string uiSaveFile(ControlSafeHandle parent) => UTF8Helper.ToUTF8Str(uiSaveFile(parent.DangerousGetHandle()));

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiMsgBox(IntPtr parent, IntPtr title, IntPtr description);
        public static void uiMsgBox(ControlSafeHandle parent, string title, string description)
        {
            IntPtr titlePtr = UTF8Helper.ToUTF8Ptr(title);
            IntPtr descrPtr = UTF8Helper.ToUTF8Ptr(description);
            uiMsgBox(parent.DangerousGetHandle(), titlePtr, descrPtr);
            Marshal.FreeHGlobal(titlePtr);
            Marshal.FreeHGlobal(descrPtr);
        }

        [UnmanagedFunctionPointer(callingConvention)]
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

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiAreaSetSize(IntPtr a, int width, int height);
        public static void uiAreaSetSize(ControlSafeHandle a, int width, int height) => uiAreaSetSize(a.DangerousGetHandle(), width, height);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiAreaQueueReDrawAll(IntPtr a);
        public static void uiAreaQueueReDrawAll(ControlSafeHandle a) => uiAreaQueueReDrawAll(a.DangerousGetHandle());

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiAreaScrollTo(IntPtr area, double x, double y, double width, double height);
        public static void uiAreaScrollTo(ControlSafeHandle a, double x, double y, double width, double height) => uiAreaScrollTo(a.DangerousGetHandle(), x, y, width, height);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiAreaBeginUserWindowMove(IntPtr area);
        public static void uiAreaBeginUserWindowMove(ControlSafeHandle a) => uiAreaBeginUserWindowMove(a.DangerousGetHandle());

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiAreaBeginUserWindowResize(IntPtr area, uiWindowResizeEdge edge);
        public static void uiAreaBeginUserWindowResize(ControlSafeHandle a, uiWindowResizeEdge edge) => uiAreaBeginUserWindowResize(a.DangerousGetHandle(), (uiWindowResizeEdge)edge);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate IntPtr _uiNewArea(uiAreaHandler ah);
        public static ControlSafeHandle uiNewArea(uiAreaHandler ah) => new ControlSafeHandle(_uiNewArea(ah));

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate IntPtr _uiNewScrollingArea(uiAreaHandler ah, int width, int height);
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

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate IntPtr uiDrawNewPath(uiDrawFillMode fillMode);
        public static PathSafeHandle uiDrawNewPath(FillMode fillMode) => new PathSafeHandle(uiDrawNewPath((uiDrawFillMode)fillMode));

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiDrawFreePath(IntPtr p);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiDrawPathNewFigure(IntPtr p, double x, double y);
        public static void uiDrawPathNewFigure(PathSafeHandle p, double x, double y) => uiDrawPathNewFigure(p.DangerousGetHandle(), x, y);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiDrawPathNewFigureWithArc(IntPtr p, double xCenter, double yCenter, double radius, double startAngle, double sweep, bool negative);
        public static void uiDrawPathNewFigureWithArc(PathSafeHandle p, double xCenter, double yCenter, double radius, double startAngle, double sweep, bool negative) => uiDrawPathNewFigureWithArc(p.DangerousGetHandle(), xCenter, yCenter, radius, startAngle, sweep, negative);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiDrawPathLineTo(IntPtr p, double x, double y);
        public static void uiDrawPathLineTo(PathSafeHandle p, double x, double y) => uiDrawPathLineTo(p.DangerousGetHandle(), x, y);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiDrawPathArcTo(IntPtr p, double xCenter, double yCenter, double radius, double startAngle, double sweep, bool negative);
        public static void uiDrawPathArcTo(PathSafeHandle p, double xCenter, double yCenter, double radius, double startAngle, double sweep, bool negative) => uiDrawPathArcTo(p.DangerousGetHandle(), xCenter, yCenter, radius, startAngle, sweep, negative);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiDrawPathBezierTo(IntPtr p, double c1x, double c1y, double c2x, double c2y, double endX, double endY);
        public static void uiDrawPathBezierTo(PathSafeHandle p, double c1x, double c1y, double c2x, double c2y, double endX, double endY) => uiDrawPathBezierTo(p.DangerousGetHandle(), c1x, c1y, c2x, c2y, endX, endY);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiDrawPathCloseFigure(IntPtr p);
        public static void uiDrawPathCloseFigure(PathSafeHandle p) => uiDrawPathCloseFigure(p.DangerousGetHandle());

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiDrawPathAddRectangle(IntPtr p, double x, double y, double width, double height);
        public static void uiDrawPathAddRectangle(PathSafeHandle p, double x, double y, double width, double height) => uiDrawPathAddRectangle(p.DangerousGetHandle(), x, y, width, height);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiDrawPathEnd(IntPtr p);
        public static void uiDrawPathEnd(PathSafeHandle p) => uiDrawPathEnd(p.DangerousGetHandle());

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiDrawStroke(IntPtr context, IntPtr path, ref uiDrawBrush brush, ref uiDrawStrokeParams strokeParam);
        public static void uiDrawStroke(LibUISafeHandle c, PathSafeHandle p, ref uiDrawBrush brush, ref uiDrawStrokeParams strokeParams) => uiDrawStroke(c.DangerousGetHandle(), p.DangerousGetHandle(), ref brush, ref strokeParams);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiDrawFill(IntPtr context, IntPtr path, ref uiDrawBrush brush);
        public static void uiDrawFill(LibUISafeHandle c, PathSafeHandle path, ref uiDrawBrush brush) => uiDrawFill(c.DangerousGetHandle(), path.DangerousGetHandle(), ref brush);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiDrawMatrixSetIdentity(uiDrawMatrix matrix);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiDrawMatrixTranslate(uiDrawMatrix matrix, double x, double y);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiDrawMatrixScale(uiDrawMatrix matrix, double xCenter, double yCenter, double x, double y);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiDrawMatrixRotate(uiDrawMatrix matrix, double x, double y, double amount);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiDrawMatrixSkew(uiDrawMatrix matrix, double x, double y, double xamount, double yamount);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiDrawMatrixMultiply(uiDrawMatrix dest, uiDrawMatrix src);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate bool uiDrawMatrixInvertible(uiDrawMatrix matrix);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate int uiDrawMatrixInvert(uiDrawMatrix matrix);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiDrawMatrixTransformPoint(uiDrawMatrix matrix, out double x, out double y);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiDrawMatrixTransformSize(uiDrawMatrix matrix, out double x, out double y);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiDrawTransform(IntPtr context, uiDrawMatrix matrix);
        public static void uiDrawTransform(LibUISafeHandle c, uiDrawMatrix matrix) => uiDrawTransform(c.DangerousGetHandle(), matrix);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiDrawClip(IntPtr context, IntPtr path);
        public static void uiDrawClip(LibUISafeHandle context, PathSafeHandle path) => uiDrawClip(context.DangerousGetHandle(), path.DangerousGetHandle());

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiDrawSave(IntPtr context);
        public static void uiDrawSave(LibUISafeHandle c) => uiDrawSave(c.DangerousGetHandle());

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiDrawRestore(IntPtr context);
        public static void uiDrawRestore(LibUISafeHandle c) => uiDrawRestore(c.DangerousGetHandle());

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiFreeAttribute(IntPtr a);

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

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate uiAttributeType uiAttributeGetType(IntPtr a);
        public static uiAttributeType uiAttributeGetType(TextAttributeSafeHandle a) => uiAttributeGetType(a.DangerousGetHandle());

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate IntPtr uiNewFamilyAttribute(IntPtr family);
        public static TextAttributeSafeHandle uiNewFamilyAttribute(string family)
        {
            IntPtr strPtr = UTF8Helper.ToUTF8Ptr(family);
            TextAttributeSafeHandle safeHandle = new TextAttributeSafeHandle(uiNewFamilyAttribute(strPtr));
            Marshal.FreeHGlobal(strPtr);
            return safeHandle;
        }

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate IntPtr uiAttributeFamily(IntPtr a);
        public static string uiAttributeFamily(TextAttributeSafeHandle a) => UTF8Helper.ToUTF8Str(uiAttributeFamily(a.DangerousGetHandle()));

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate IntPtr _uiNewSizeAttribute(double size);
        public static TextAttributeSafeHandle uiNewSizeAttribute(double size) => new TextAttributeSafeHandle(_uiNewSizeAttribute(size));

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate double uiAttributeSize(IntPtr a);
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

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate IntPtr _uiNewWeightAttribute(uiTextWeight weight);
        public static TextAttributeSafeHandle uiNewWeightAttribute(uiTextWeight weight) => new TextAttributeSafeHandle(_uiNewWeightAttribute(weight));

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate uiTextWeight uiAttributeWeight(IntPtr a);
        public static uiTextWeight uiAttributeWeight(TextAttributeSafeHandle a) => uiAttributeWeight(a.DangerousGetHandle());

        public enum uiTextItalic : uint
        {
            uiTextItalicNormal,
            uiTextItalicOblique,
            uiTextItalicItalic
        }

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate IntPtr _uiNewItalicAttribute(uiTextItalic italic);
        public static TextAttributeSafeHandle uiNewItalicAttribute(uiTextItalic italic) => new TextAttributeSafeHandle(_uiNewItalicAttribute(italic));

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate uiTextItalic uiAttributeItalic(IntPtr a);
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

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate IntPtr _uiNewStretchAttribute(uiTextStretch stretch);
        public static TextAttributeSafeHandle uiNewStretchAttribute(uiTextStretch stretch) => new TextAttributeSafeHandle(_uiNewStretchAttribute(stretch));

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate uiTextStretch uiAttributeStretch(IntPtr a);
        public static uiTextStretch uiAttributeStretch(TextAttributeSafeHandle a) => uiAttributeStretch(a.DangerousGetHandle());

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate IntPtr _uiNewColorAttribute(double r, double g, double b, double a);
        public static TextAttributeSafeHandle uiNewColorAttribute(double r, double g, double b, double a) => new TextAttributeSafeHandle(_uiNewColorAttribute(r, g, b, a));

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiAttributeColor(IntPtr a, out double r, out double g, out double b, out double alpha);
        public static void uiAttributeColor(TextAttributeSafeHandle a, out double r, out double g, out double b, out double alpha) => uiAttributeColor(a.DangerousGetHandle(), out r, out g, out b, out alpha);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate IntPtr _uiNewBackgroundAttribute(double r, double g, double b, double a);
        public static TextAttributeSafeHandle uiNewBackgroundAttribute(double r, double g, double b, double a) => new TextAttributeSafeHandle(_uiNewBackgroundAttribute(r, g, b, a));

        public enum uiUnderline : uint
        {
            uiUnderlineNone,
            uiUnderlineSingle,
            uiUnderlineDouble,
            uiUnderlineSuggestion, // wavy or dotted underlines used for spelling/grammar checkers
        }

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate IntPtr _uiNewUnderlineAttribute(uiUnderline u);
        public static TextAttributeSafeHandle uiNewUnderlineAttribute(uiUnderline u) => new TextAttributeSafeHandle(_uiNewUnderlineAttribute(u));

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate uiUnderline uiAttributeUnderline(IntPtr a);
        public static uiUnderline uiAttributeUnderline(TextAttributeSafeHandle a) => uiAttributeUnderline(a.DangerousGetHandle());

        public enum uiUnderlineColor : uint
        {
            uiUnderlineColorCustom,
            uiUnderlineColorSpelling,
            uiUnderlineColorGrammar,
            uiUnderlineColorAuxiliary, // for instance, the color used by smart replacements on macOS or in Microsoft Office
        }

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate IntPtr _uiNewUnderlineColorAttribute(uiUnderlineColor u, double r, double g, double b, double a);
        public static TextAttributeSafeHandle uiNewUnderlineColorAttribute(uiUnderlineColor u, double r, double g, double b, double a) => new TextAttributeSafeHandle(_uiNewUnderlineColorAttribute(u, r, g, b, a));

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiAttributeUnderline(IntPtr a, out uiUnderlineColor u, out double r, out double g, out double b, out double alpha);
        public static void uiAttributeUnderline(TextAttributeSafeHandle a, out uiUnderlineColor u, out double r, out double g, out double b, out double alpha) => uiAttributeUnderline(a.DangerousGetHandle(), out u, out r, out g, out b, out alpha);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uiForEach uiOpenTypeFeaturesForEachFunc(IntPtr otf, byte a, byte b, byte c, byte d, uint value, IntPtr data);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate IntPtr _uiNewOpenTypeFeatures();
        public static FontFeaturesSafeHandle uiNewOpenTypeFeatures() => new FontFeaturesSafeHandle(_uiNewOpenTypeFeatures());

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiFreeOpenTypeFeatures(IntPtr otf);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate IntPtr uiOpenTypeFeaturesClone(IntPtr otf);
        public static FontFeaturesSafeHandle uiOpenTypeFeaturesClone(FontFeaturesSafeHandle otf) => new FontFeaturesSafeHandle(otf.DangerousGetHandle());

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiOpenTypeFeaturesAdd(IntPtr otf, byte a, byte b, byte c, byte d, uint value);
        public static void uiOpenTypeFeaturesAdd(FontFeaturesSafeHandle otf, byte a, byte b, byte c, byte d, uint value) => uiOpenTypeFeaturesAdd(otf.DangerousGetHandle(), a, b, c, d, value);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiOpenTypeFeaturesRemove(IntPtr otf, byte a, byte b, byte c, byte d);
        public static void uiOpenTypeFeaturesRemove(FontFeaturesSafeHandle otf, byte a, byte b, byte c, byte d) => uiOpenTypeFeaturesRemove(otf.DangerousGetHandle(), a, b, c, d);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate int uiOpenTypeFeaturesGet(IntPtr otf, byte a, byte b, byte c, byte d, out uint value);
        public static int uiOpenTypeFeaturesGet(FontFeaturesSafeHandle otf, byte a, byte b, byte c, byte d, out uint value) => uiOpenTypeFeaturesGet(otf.DangerousGetHandle(), a, b, c, d, out value);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiOpenTypeFeaturesForEach(IntPtr otf, uiOpenTypeFeaturesForEachFunc f, IntPtr data);
        public static void uiOpenTypeFeaturesForEach(FontFeaturesSafeHandle otf, uiOpenTypeFeaturesForEachFunc f, IntPtr data) => uiOpenTypeFeaturesForEach(otf.DangerousGetHandle(), f, data);
        public static void uiOpenTypeFeaturesForEach(FontFeaturesSafeHandle otf, uiOpenTypeFeaturesForEachFunc f) => uiOpenTypeFeaturesForEach(otf, f, IntPtr.Zero);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate IntPtr uiNewFeaturesAttribute(IntPtr otf);
        public static TextAttributeSafeHandle uiNewFeaturesAttribute(FontFeaturesSafeHandle otf) => new TextAttributeSafeHandle(uiNewFeaturesAttribute(otf.DangerousGetHandle()));

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate IntPtr uiAttributeFeatures(IntPtr a);
        public static FontFeaturesSafeHandle uiAttributeFeatures(TextAttributeSafeHandle a) => new FontFeaturesSafeHandle(uiAttributeFeatures(a.DangerousGetHandle()));

        #region TODO: uiAttributedString
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uiForEach uiAttributedStringForEachAttributeFunc(IntPtr s, IntPtr a, UIntPtr start, UIntPtr end, IntPtr data);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate IntPtr uiNewAttributedString(IntPtr initialString);
        public static AttributedTextSafeHandle uiNewAttributedString(string initialString)
        {
            IntPtr strPtr = UTF8Helper.ToUTF8Ptr(initialString);
            AttributedTextSafeHandle safeHandle = new AttributedTextSafeHandle(uiNewAttributedString(strPtr));
            Marshal.FreeHGlobal(strPtr);
            return safeHandle;
        }

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiFreeAttributedString(IntPtr s);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate IntPtr uiAttributedStringString(IntPtr s);
        public static string uiAttributedStringString(AttributedTextSafeHandle s) => UTF8Helper.ToUTF8Str(uiAttributedStringString(s.DangerousGetHandle()));

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate UIntPtr uiAttributedStringLen(IntPtr s);
        public static UIntPtr uiAttributedStringLen(AttributedTextSafeHandle s) => uiAttributedStringLen(s.DangerousGetHandle());

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiAttributedStringAppendUnattributed(IntPtr s, IntPtr str);
        public static void uiAttributedStringAppendUnattributed(AttributedTextSafeHandle s, string str)
        {
            IntPtr strPtr = UTF8Helper.ToUTF8Ptr(str);
            uiAttributedStringAppendUnattributed(s.DangerousGetHandle(), strPtr);
            Marshal.FreeHGlobal(strPtr);
        }

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiAttributedStringInsertAtUnattributed(IntPtr s, IntPtr str, UIntPtr at);
        public static void uiAttributedStringInsertAtUnattributed(AttributedTextSafeHandle s, string str, UIntPtr at)
        {
            IntPtr strPtr = UTF8Helper.ToUTF8Ptr(str);
            uiAttributedStringAppendUnattributed(s.DangerousGetHandle(), strPtr);
            Marshal.FreeHGlobal(strPtr);
        }

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiAttributedStringDelete(IntPtr s, UIntPtr start, UIntPtr end);
        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiAttributedStringSetAttribute(IntPtr s, IntPtr a, UIntPtr start, UIntPtr end);
        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiAttributedStringForEachAttribute(IntPtr s, uiAttributedStringForEachAttributeFunc f, IntPtr data);
        [UnmanagedFunctionPointer(callingConvention)]
        public delegate UIntPtr uiAttributedStringNumGraphemes(IntPtr s);
        [UnmanagedFunctionPointer(callingConvention)]
        public delegate UIntPtr uiAttributedStringByteIndexToGrapheme(IntPtr s, UIntPtr pos);
        [UnmanagedFunctionPointer(callingConvention)]
        public delegate UIntPtr uiAttributedStringGraphemeToByteIndex(IntPtr s, UIntPtr pos);
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
            public IntPtr String;
            public uiFontDescriptor DefaultFont;
            public double Width;
            public uiDrawTextAlign Align;

            public static explicit operator uiDrawTextLayoutParams(TextLayoutOptions o) => new uiDrawTextLayoutParams()
            {
                String = o.Text.Handle.DangerousGetHandle(),
                DefaultFont = (uiFontDescriptor)o.DefaultFont,
                Width = o.Width,
                Align = (uiDrawTextAlign)o.Alignment
            };
        }

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate IntPtr uiDrawNewTextLayout_t(uiDrawTextLayoutParams param);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiDrawFreeTextLayout_t(IntPtr tl);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiDrawText_t(IntPtr c, IntPtr tl, double x, double y);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiDrawTextLayoutExtents_t(IntPtr tl, out double width, out double height);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiFontButtonFont_t(IntPtr b, out uiFontDescriptor desc);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiFontButtonOnChanged_t(IntPtr b, uiFontButtonOnChanged_tf f, IntPtr data);
        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiFontButtonOnChanged_tf(IntPtr b, IntPtr data);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate IntPtr uiNewFontButton_t();

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiFreeFontButtonFont_t(uiFontDescriptor desc);

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

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiColorButtonColor_t(IntPtr b, out double red, out double green, out double blue, out double alpha);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiColorButtonSetColor_t(IntPtr b, double red, double green, double blue, double alpha);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiColorButtonOnChanged_t(IntPtr b, uiColorButtonOnChanged_tf f, IntPtr data);
        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiColorButtonOnChanged_tf(IntPtr b, IntPtr data);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate IntPtr uiNewColorButton_t();

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiFormAppend_t(IntPtr f, IntPtr label, IntPtr c, bool stretchy);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiFormDelete_t(IntPtr f, int index);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate bool uiFormPadded_t(IntPtr f);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiFormSetPadded_t(IntPtr f, bool padded);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate IntPtr uiNewForm_t();

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

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiGridAppend_t(IntPtr grid, IntPtr child, int left, int top, int xspan, int yspan, int hexpand, uiAlign halign, int vexpand, uiAlign valign);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiGridInsertAt_t(IntPtr grid, IntPtr child, IntPtr existing, uiAt at, int xspan, int yspan, int hexpand, uiAlign halign, int vexpand, uiAlign valign);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate bool uiGridPadded_t(IntPtr grid);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate void uiGridSetPadded_t(IntPtr grid, bool padded);

        [UnmanagedFunctionPointer(callingConvention)]
        public delegate IntPtr uiNewGrid_t();

    }
}