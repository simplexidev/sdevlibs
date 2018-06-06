using System;
using System.Runtime.InteropServices;

namespace LibUISharp.Native
{
    internal static partial class NativeMethods
    {
        internal static partial class Libui
        {
            // _UI_EXTERN char *uiWindowTitle(uiWindow *w);
            [UnmanagedFunctionPointer(Convention)]
            private delegate string uiWindowTitle_t(IntPtr w);
            public static string uiWindowTitle(IntPtr w) => FunctionLoader.LoadLibuiFunc<uiWindowTitle_t>("uiWindowTitle")(w);

            // _UI_EXTERN void uiWindowSetTitle(uiWindow *w, const char *title);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiWindowSetTitle_t(IntPtr w, string title);
            public static void uiWindowSetTitle(IntPtr w, string title) => FunctionLoader.LoadLibuiFunc<uiWindowSetTitle_t>("uiWindowSetTitle")(w, title);

            // _UI_EXTERN void uiWindowContentSize(uiWindow *w, int *width, int *height);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiWindowContentSize_t(IntPtr w, out int width, out int height);
            public static void uiWindowContentSize(IntPtr w, out int width, out int height) => FunctionLoader.LoadLibuiFunc<uiWindowContentSize_t>("uiWindowContentSize")(w, out width, out height);

            // _UI_EXTERN void uiWindowSetContentSize(uiWindow *w, int width, int height);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiWindowSetContentSize_t(IntPtr w, int width, int height);
            public static void uiWindowSetContentSize(IntPtr w, int width, int height) => FunctionLoader.LoadLibuiFunc<uiWindowSetContentSize_t>("uiWindowSetContentSize")(w, width, height);

            // _UI_EXTERN int uiWindowFullscreen(uiWindow *w);
            [UnmanagedFunctionPointer(Convention)]
            private delegate bool uiWindowFullscreen_t(IntPtr w);
            public static bool uiWindowFullscreen(IntPtr w) => FunctionLoader.LoadLibuiFunc<uiWindowFullscreen_t>("uiWindowFullscreen")(w);

            // _UI_EXTERN void uiWindowSetFullscreen(uiWindow *w, int fullscreen);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiWindowSetFullscreen_t(IntPtr w, bool fullscreen);
            public static void uiWindowSetFullscreen(IntPtr w, bool fullscreen) => FunctionLoader.LoadLibuiFunc<uiWindowSetFullscreen_t>("uiWindowSetFullscreen")(w, fullscreen);

            // _UI_EXTERN void uiWindowOnContentSizeChanged(uiWindow *w, void (*f)(uiWindow *, void *), void *data);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiWindowOnContentSizeChanged_t(IntPtr w, uiWindowOnContentSizeChanged_tf f, IntPtr data);
            [UnmanagedFunctionPointer(Convention)]
            public delegate void uiWindowOnContentSizeChanged_tf(IntPtr w, IntPtr data);
            public static void uiWindowOnContentSizeChanged(IntPtr w, uiWindowOnContentSizeChanged_tf f, IntPtr data) => FunctionLoader.LoadLibuiFunc<uiWindowOnContentSizeChanged_t>("uiWindowOnContentSizeChanged")(w, f, data);

            // _UI_EXTERN void uiWindowOnClosing(uiWindow *w, int (*f)(uiWindow *w, void *data), void *data);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiWindowOnClosing_t(IntPtr w, uiWindowOnClosing_tf f, IntPtr data);
            [UnmanagedFunctionPointer(Convention)]
            public delegate bool uiWindowOnClosing_tf(IntPtr w, IntPtr data);
            public static void uiWindowOnClosing(IntPtr w, uiWindowOnClosing_tf f, IntPtr data) => FunctionLoader.LoadLibuiFunc<uiWindowOnClosing_t>("uiWindowOnClosing")(w, f, data);

            // _UI_EXTERN int uiWindowBorderless(uiWindow *w);
            [UnmanagedFunctionPointer(Convention)]
            private delegate bool uiWindowBorderless_t(IntPtr w);
            public static bool uiWindowBorderless(IntPtr w) => FunctionLoader.LoadLibuiFunc<uiWindowBorderless_t>("uiWindowBorderless")(w);

            // _UI_EXTERN void uiWindowSetBorderless(uiWindow *w, int borderless);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiWindowSetBorderless_t(IntPtr w, bool borderless);
            public static void uiWindowSetBorderless(IntPtr w, bool borderless) => FunctionLoader.LoadLibuiFunc<uiWindowSetBorderless_t>("uiWindowSetBorderless")(w, borderless);

            // _UI_EXTERN void uiWindowSetChild(uiWindow *w, uiControl *child);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiWindowSetChild_t(IntPtr w, IntPtr child);
            public static void uiWindowSetChild(IntPtr w, IntPtr child) => FunctionLoader.LoadLibuiFunc<uiWindowSetChild_t>("uiWindowSetChild")(w, child);

            // _UI_EXTERN int uiWindowMargined(uiWindow *w);
            [UnmanagedFunctionPointer(Convention)]
            private delegate bool uiWindowMargined_t(IntPtr w);
            public static bool uiWindowMargined(IntPtr w) => FunctionLoader.LoadLibuiFunc<uiWindowMargined_t>("uiWindowMargined")(w);

            // _UI_EXTERN void uiWindowSetMargined(uiWindow *w, int margined);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiWindowSetMargined_t(IntPtr w, bool margined);
            public static void uiWindowSetMargined(IntPtr w, bool margined) => FunctionLoader.LoadLibuiFunc<uiWindowSetMargined_t>("uiWindowSetMargined")(w, margined);

            // _UI_EXTERN uiWindow *uiNewWindow(const char *title, int width, int height, int hasMenubar);
            [UnmanagedFunctionPointer(Convention)]
            private delegate IntPtr uiNewWindow_t(string title, int width, int height, bool hasMenubar);
            public static IntPtr uiNewWindow(string title, int width, int height, bool hasMenubar) => FunctionLoader.LoadLibuiFunc<uiNewWindow_t>("uiNewWindow")(title, width, height, hasMenubar);

            // _UI_EXTERN char *uiOpenFile(uiWindow *parent);
            [UnmanagedFunctionPointer(Convention)]
            private delegate string uiOpenFile_t(IntPtr parent);
            public static string uiOpenFile(IntPtr parent) => FunctionLoader.LoadLibuiFunc<uiOpenFile_t>("uiOpenFile")(parent);

            // _UI_EXTERN char *uiSaveFile(uiWindow *parent);
            [UnmanagedFunctionPointer(Convention)]
            private delegate string uiSaveFile_t(IntPtr parent);
            public static string uiSaveFile(IntPtr parent) => FunctionLoader.LoadLibuiFunc<uiSaveFile_t>("uiSaveFile")(parent);

            // _UI_EXTERN void uiMsgBox(uiWindow *parent, const char *title, const char *description);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiMsgBox_t(IntPtr parent, string title, string description);
            public static void uiMsgBox(IntPtr parent, string title, string description) => FunctionLoader.LoadLibuiFunc<uiMsgBox_t>("uiMsgBox")(parent, title, description);

            // _UI_EXTERN void uiMsgBoxError(uiWindow *parent, const char *title, const char *description);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiMsgBoxError_t(IntPtr parent, string title, string description);
            public static void uiMsgBoxError(IntPtr parent, string title, string description) => FunctionLoader.LoadLibuiFunc<uiMsgBoxError_t>("uiMsgBoxError")(parent, title, description);
        }
    }
}