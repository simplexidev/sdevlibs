using LibUISharp.Runtime;
using LibUISharp.Runtime.InteropServices;

using System;
//using System.CodeDom.Compiler;

namespace LibUISharp.Native
{
    // [GeneratedCode("LibUISharp.CodeAnalysis.NativeCallGenerator", "1.0.0")]
    public static unsafe partial class Libui
    {
        private static readonly NativeAssembly __assembly__ = new(Platform.IsWindows ? "libui.dll" : Platform.IsMacOS ? "libui.dylib" : Platform.IsLinux ? "libui.so" : Platform.IsFreeBSD ? "libui.so.2" : throw new PlatformNotSupportedException());

        public static partial sbyte* uiInit(uiInitOptions* options) => ((delegate* unmanaged[Cdecl]<uiInitOptions*, sbyte*>)__assembly__.LoadFuncPtr(nameof(uiInit)))(options);
        public static partial void uiUninit() => ((delegate* unmanaged[Cdecl]<void>)__assembly__.LoadFuncPtr(nameof(uiUninit)))();
        public static partial void uiFreeInitError(sbyte* err) => ((delegate* unmanaged[Cdecl]<sbyte*, void>)__assembly__.LoadFuncPtr(nameof(uiFreeInitError)))(err);
        public static partial void uiMain() => ((delegate* unmanaged[Cdecl]<void>)__assembly__.LoadFuncPtr(nameof(uiMain)))();
        public static partial void uiMainSteps() => ((delegate* unmanaged[Cdecl]<void>)__assembly__.LoadFuncPtr(nameof(uiMainSteps)))();
        public static partial int uiMainStep(int wait) => ((delegate* unmanaged[Cdecl]<int, int>)__assembly__.LoadFuncPtr(nameof(uiMainStep)))(wait);
        public static partial void uiQuit() => ((delegate* unmanaged[Cdecl]<void>)__assembly__.LoadFuncPtr(nameof(uiQuit)))();
        public static partial void uiQueueMain(delegate* unmanaged[Cdecl]<void*, void> f, void* data) => ((delegate* unmanaged[Cdecl]<delegate* unmanaged[Cdecl]<void*, void>, void*, void>)__assembly__.LoadFuncPtr(nameof(uiQueueMain)))(f, data);
        public static partial void uiTimer(int milliseconds, delegate* unmanaged[Cdecl]<void*, int> f, void* data) => ((delegate* unmanaged[Cdecl]<int, delegate* unmanaged[Cdecl]<void*, int>, void*, void>)__assembly__.LoadFuncPtr(nameof(uiTimer)))(milliseconds, f, data);
        public static partial void uiOnShouldQuit(delegate* unmanaged[Cdecl]<void*, void> f, void* data) => ((delegate* unmanaged[Cdecl]<delegate* unmanaged[Cdecl]<void*, void>, void*, void>)__assembly__.LoadFuncPtr(nameof(uiOnShouldQuit)))(f, data);
        public static partial void uiFreeText(sbyte* text) => ((delegate* unmanaged[Cdecl]<sbyte*, void>)__assembly__.LoadFuncPtr(nameof(uiFreeText)))(text);

        public static partial void uiControlDestroy(uiControl* c) => ((delegate* unmanaged[Cdecl]<uiControl*, void>)__assembly__.LoadFuncPtr(nameof(uiControlDestroy)))(c);
        public static partial UIntPtr uiControlHandle(uiControl* c) => ((delegate* unmanaged[Cdecl]<uiControl*, UIntPtr>)__assembly__.LoadFuncPtr(nameof(uiControlHandle)))(c);
        public static partial uiControl* uiControlParent(uiControl* c) => ((delegate* unmanaged[Cdecl]<uiControl*, uiControl*>)__assembly__.LoadFuncPtr(nameof(uiControlParent)))(c);
        public static partial void uiControlSetParent(uiControl* c) => ((delegate* unmanaged[Cdecl]<uiControl*, void>)__assembly__.LoadFuncPtr(nameof(uiControlSetParent)))(c);
        public static partial bool uiControlToplevel(uiControl* c) => ((delegate* unmanaged[Cdecl]<uiControl*, bool>)__assembly__.LoadFuncPtr(nameof(uiControlToplevel)))(c);
        public static partial bool uiControlVisible(uiControl* c) => ((delegate* unmanaged[Cdecl]<uiControl*, bool>)__assembly__.LoadFuncPtr(nameof(uiControlVisible)))(c);
        public static partial void uiControlShow(uiControl* c) => ((delegate* unmanaged[Cdecl]<uiControl*, void>)__assembly__.LoadFuncPtr(nameof(uiControlShow)))(c);
        public static partial void uiControlHide(uiControl* c) => ((delegate* unmanaged[Cdecl]<uiControl*, void>)__assembly__.LoadFuncPtr(nameof(uiControlHide)))(c);
        public static partial bool uiControlEnabled(uiControl* c) => ((delegate* unmanaged[Cdecl]<uiControl*, bool>)__assembly__.LoadFuncPtr(nameof(uiControlEnabled)))(c);
        public static partial void uiControlEnable(uiControl* c) => ((delegate* unmanaged[Cdecl]<uiControl*, void>)__assembly__.LoadFuncPtr(nameof(uiControlEnable)))(c);
        public static partial void uiControlDisable(uiControl* c) => ((delegate* unmanaged[Cdecl]<uiControl*, void>)__assembly__.LoadFuncPtr(nameof(uiControlDisable)))(c);
        public static partial uiControl* uiAllocControl(uint* n, uint OSsig, uint typesig, sbyte* typenamestr) => ((delegate* unmanaged[Cdecl]<uint*, uint, uint, sbyte*, uiControl*>)__assembly__.LoadFuncPtr(nameof(uiAllocControl)))(n, OSsig, typesig, typenamestr);
        public static partial void uiFreeControl(uiControl* c) => ((delegate* unmanaged[Cdecl]<uiControl*, void>)__assembly__.LoadFuncPtr(nameof(uiFreeControl)))(c);
        public static partial void uiControlVerifySetParent(uiControl* c1, uiControl* c2) => ((delegate* unmanaged[Cdecl]<uiControl*, uiControl*, void>)__assembly__.LoadFuncPtr(nameof(uiControlVerifySetParent)))(c1, c2);
        public static partial bool uiControlEnabledToUser(uiControl* c) => ((delegate* unmanaged[Cdecl]<uiControl*, bool>)__assembly__.LoadFuncPtr(nameof(uiControlEnabledToUser)))(c);
        public static partial void uiUserBugCannotSetParentOnToplevel(sbyte* type) => ((delegate* unmanaged[Cdecl]<sbyte*, void>)__assembly__.LoadFuncPtr(nameof(uiUserBugCannotSetParentOnToplevel)))(type);

        public static partial sbyte* uiWindowTitle(void* w) => ((delegate* unmanaged[Cdecl]<void*, sbyte*>)__assembly__.LoadFuncPtr(nameof(uiWindowTitle)))(w);
        public static partial void uiWindowSetTitle(void* w, sbyte* title) => ((delegate* unmanaged[Cdecl]<void*, sbyte*, void>)__assembly__.LoadFuncPtr(nameof(uiWindowSetTitle)))(w, title);
        public static partial void uiWindowContentSize(void* w, int* width, int* height) => ((delegate* unmanaged[Cdecl]<void*, int*, int*, void>)__assembly__.LoadFuncPtr(nameof(uiWindowContentSize)))(w, width, height);
        public static partial void uiWindowSetContentSize(void* w, int width, int height) => ((delegate* unmanaged[Cdecl]<void*, int, int, void>)__assembly__.LoadFuncPtr(nameof(uiWindowSetContentSize)))(w, width, height);
        public static partial int uiWindowFullscreen(void* w) => ((delegate* unmanaged[Cdecl]<void*, int>)__assembly__.LoadFuncPtr(nameof(uiWindowFullscreen)))(w);
        public static partial void uiWindowSetFullscreen(void* w, int fullscreen) => ((delegate* unmanaged[Cdecl]<void*, int, void>)__assembly__.LoadFuncPtr(nameof(uiWindowSetFullscreen)))(w, fullscreen);
        public static partial void uiWindowOnContentSizeChanged(void* w, delegate* unmanaged[Cdecl]<void*, void*, int> f, void* data) => ((delegate* unmanaged[Cdecl]<void*, delegate* unmanaged[Cdecl]<void*, void*, int>, void*, void>)__assembly__.LoadFuncPtr(nameof(uiWindowOnContentSizeChanged)))(w, f, data);
        public static partial void uiWindowOnClosing(void* w, delegate* unmanaged[Cdecl]<void*, void*, int> f, void* data) => ((delegate* unmanaged[Cdecl]<void*, delegate* unmanaged[Cdecl]<void*, void*, int>, void*, void>)__assembly__.LoadFuncPtr(nameof(uiWindowOnClosing)))(w, f, data);
        public static partial int uiWindowBorderless(void* w) => ((delegate* unmanaged[Cdecl]<void*, int>)__assembly__.LoadFuncPtr(nameof(uiWindowBorderless)))(w);
        public static partial void uiWindowSetBorderless(void* w, int borderless) => ((delegate* unmanaged[Cdecl]<void*, int, void>)__assembly__.LoadFuncPtr(nameof(uiWindowSetBorderless)))(w, borderless);
        public static partial void uiWindowSetChild(void* w, uiControl* child) => ((delegate* unmanaged[Cdecl]<void*, uiControl*, void>)__assembly__.LoadFuncPtr(nameof(uiWindowSetChild)))(w, child);
        public static partial int uiWindowMargined(void* w) => ((delegate* unmanaged[Cdecl]<void*, int>)__assembly__.LoadFuncPtr(nameof(uiWindowMargined)))(w);
        public static partial void uiWindowSetMargined(void* w, int margined) => ((delegate* unmanaged[Cdecl]<void*, int, void>)__assembly__.LoadFuncPtr(nameof(uiWindowSetMargined)))(w, margined);
        public static partial void* uiNewWindow(sbyte* title, int width, int height, int hasMenubar) => ((delegate* unmanaged[Cdecl]<sbyte*, int, int, int, void*>)__assembly__.LoadFuncPtr(nameof(uiNewWindow)))(title, width, height, hasMenubar);
    }
}
