using LibUISharp.Runtime;
using LibUISharp.Runtime.InteropServices;

using System;
//TODO: using System.CodeDom.Compiler;

namespace LibUISharp.Native
{
    public static unsafe partial class Libui
    {
        //TODO: [GeneratedCode("LibUISharp.CodeAnalysis.NativeCallGenerator", "1.0.0")]
        private static readonly NativeAssembly __assembly__ = new(Platform.IsWindows ? "libui.dll" : Platform.IsMacOS ? "libui.dylib" : Platform.IsLinux ? "libui.so" : Platform.IsFreeBSD ? "libui.so.2" : throw new PlatformNotSupportedException());

        //TODO: [GeneratedCode("LibUISharp.CodeAnalysis.NativeCallGenerator", "1.0.0")]
        public static partial byte* uiInit(uiInitOptions* options) => ((delegate* unmanaged[Cdecl]<uiInitOptions*, byte*>)__assembly__.LoadFuncPtr(nameof(uiInit)))(options);

        //TODO: [GeneratedCode("LibUISharp.CodeAnalysis.NativeCallGenerator", "1.0.0")]
        public static partial void uiUninit() => ((delegate* unmanaged[Cdecl]<void>)__assembly__.LoadFuncPtr(nameof(uiUninit)))();

        //TODO: [GeneratedCode("LibUISharp.CodeAnalysis.NativeCallGenerator", "1.0.0")]
        public static partial void uiFreeInitError(byte* err) => ((delegate* unmanaged[Cdecl]<byte*, void>)__assembly__.LoadFuncPtr(nameof(uiFreeInitError)))(err);

        //TODO: [GeneratedCode("LibUISharp.CodeAnalysis.NativeCallGenerator", "1.0.0")]
        public static partial void uiMain() => ((delegate* unmanaged[Cdecl]<void>)__assembly__.LoadFuncPtr(nameof(uiMain)))();

        //TODO: [GeneratedCode("LibUISharp.CodeAnalysis.NativeCallGenerator", "1.0.0")]
        public static partial void uiMainSteps() => ((delegate* unmanaged[Cdecl]<void>)__assembly__.LoadFuncPtr(nameof(uiMainSteps)))();

        //TODO: [GeneratedCode("LibUISharp.CodeAnalysis.NativeCallGenerator", "1.0.0")]
        public static partial int uiMainStep(int wait) => ((delegate* unmanaged[Cdecl]<int, int>)__assembly__.LoadFuncPtr(nameof(uiMainStep)))(wait);

        //TODO: [GeneratedCode("LibUISharp.CodeAnalysis.NativeCallGenerator", "1.0.0")]
        public static partial void uiQuit() => ((delegate* unmanaged[Cdecl]<void>)__assembly__.LoadFuncPtr(nameof(uiQuit)))();

        //TODO: [GeneratedCode("LibUISharp.CodeAnalysis.NativeCallGenerator", "1.0.0")]
        public static partial void uiQueueMain(delegate* unmanaged[Cdecl]<void*, void> f, void* data) => ((delegate* unmanaged[Cdecl]<delegate* unmanaged[Cdecl]<void*, void>, void*, void>)__assembly__.LoadFuncPtr(nameof(uiQueueMain)))(f, data);

        //TODO: [GeneratedCode("LibUISharp.CodeAnalysis.NativeCallGenerator", "1.0.0")]
        public static partial void uiTimer(int milliseconds, delegate* unmanaged[Cdecl]<void*, int> f, void* data) => ((delegate* unmanaged[Cdecl]<int, delegate* unmanaged[Cdecl]<void*, int>, void*, void>)__assembly__.LoadFuncPtr(nameof(uiTimer)))(milliseconds, f, data);

        //TODO: [GeneratedCode("LibUISharp.CodeAnalysis.NativeCallGenerator", "1.0.0")]
        public static partial void uiOnShouldQuit(delegate* unmanaged[Cdecl]<void*, void> f, void* data) => ((delegate* unmanaged[Cdecl]<delegate* unmanaged[Cdecl]<void*, void>, void*, void>)__assembly__.LoadFuncPtr(nameof(uiOnShouldQuit)))(f, data);

        //TODO: [GeneratedCode("LibUISharp.CodeAnalysis.NativeCallGenerator", "1.0.0")]
        public static partial void uiFreeText(byte* text) => ((delegate* unmanaged[Cdecl]<byte*, void>)__assembly__.LoadFuncPtr(nameof(uiFreeText)))(text);

        //TODO: [GeneratedCode("LibUISharp.CodeAnalysis.NativeCallGenerator", "1.0.0")]
        public static partial void uiControlDestroy(void* c) => ((delegate* unmanaged[Cdecl]<void*, void>)__assembly__.LoadFuncPtr(nameof(uiControlDestroy)))(c);

        //TODO: [GeneratedCode("LibUISharp.CodeAnalysis.NativeCallGenerator", "1.0.0")]
        public static partial UIntPtr uiControlHandle(void* c) => ((delegate* unmanaged[Cdecl]<void*, UIntPtr>)__assembly__.LoadFuncPtr(nameof(uiControlHandle)))(c);

        //TODO: [GeneratedCode("LibUISharp.CodeAnalysis.NativeCallGenerator", "1.0.0")]
        public static partial void* uiControlParent(void* c) => ((delegate* unmanaged[Cdecl]<void*, void*>)__assembly__.LoadFuncPtr(nameof(uiControlParent)))(c);

        //TODO: [GeneratedCode("LibUISharp.CodeAnalysis.NativeCallGenerator", "1.0.0")]
        public static partial void uiControlSetParent(void* c) => ((delegate* unmanaged[Cdecl]<void*, void>)__assembly__.LoadFuncPtr(nameof(uiControlSetParent)))(c);

        //TODO: [GeneratedCode("LibUISharp.CodeAnalysis.NativeCallGenerator", "1.0.0")]
        public static partial bool uiControlToplevel(void* c) => ((delegate* unmanaged[Cdecl]<void*, bool>)__assembly__.LoadFuncPtr(nameof(uiControlToplevel)))(c);

        //TODO: [GeneratedCode("LibUISharp.CodeAnalysis.NativeCallGenerator", "1.0.0")]
        public static partial bool uiControlVisible(void* c) => ((delegate* unmanaged[Cdecl]<void*, bool>)__assembly__.LoadFuncPtr(nameof(uiControlVisible)))(c);

        //TODO: [GeneratedCode("LibUISharp.CodeAnalysis.NativeCallGenerator", "1.0.0")]
        public static partial void uiControlShow(void* c) => ((delegate* unmanaged[Cdecl]<void*, void>)__assembly__.LoadFuncPtr(nameof(uiControlShow)))(c);

        //TODO: [GeneratedCode("LibUISharp.CodeAnalysis.NativeCallGenerator", "1.0.0")]
        public static partial void uiControlHide(void* c) => ((delegate* unmanaged[Cdecl]<void*, void>)__assembly__.LoadFuncPtr(nameof(uiControlHide)))(c);

        //TODO: [GeneratedCode("LibUISharp.CodeAnalysis.NativeCallGenerator", "1.0.0")]
        public static partial bool uiControlEnabled(void* c) => ((delegate* unmanaged[Cdecl]<void*, bool>)__assembly__.LoadFuncPtr(nameof(uiControlEnabled)))(c);

        //TODO: [GeneratedCode("LibUISharp.CodeAnalysis.NativeCallGenerator", "1.0.0")]
        public static partial void uiControlEnable(void* c) => ((delegate* unmanaged[Cdecl]<void*, void>)__assembly__.LoadFuncPtr(nameof(uiControlEnable)))(c);

        //TODO: [GeneratedCode("LibUISharp.CodeAnalysis.NativeCallGenerator", "1.0.0")]
        public static partial void uiControlDisable(void* c) => ((delegate* unmanaged[Cdecl]<void*, void>)__assembly__.LoadFuncPtr(nameof(uiControlDisable)))(c);

        //// [GeneratedCode("LibUISharp.CodeAnalysis.NativeCallGenerator", "1.0.0")]
        //// public static partial void* uiAllocControl(uint* n, uint OSsig, uint typesig, IntPtr typenamestr) => ((delegate* unmanaged[Cdecl]<uint*, uint, uint, IntPtr, void*>)__assembly__.LoadFuncPtr(nameof(uiAllocControl)))(n, OSsig, typesig, typenamestr);

        //// [GeneratedCode("LibUISharp.CodeAnalysis.NativeCallGenerator", "1.0.0")]
        //// public static partial void uiFreeControl(void* c) => ((delegate* unmanaged[Cdecl]<void*, void>)__assembly__.LoadFuncPtr(nameof(uiFreeControl)))(c);

        //TODO: [GeneratedCode("LibUISharp.CodeAnalysis.NativeCallGenerator", "1.0.0")]
        public static partial void uiControlVerifySetParent(void* c1, void* c2) => ((delegate* unmanaged[Cdecl]<void*, void*, void>)__assembly__.LoadFuncPtr(nameof(uiControlVerifySetParent)))(c1, c2);

        //TODO: [GeneratedCode("LibUISharp.CodeAnalysis.NativeCallGenerator", "1.0.0")]
        public static partial bool uiControlEnabledToUser(void* c) => ((delegate* unmanaged[Cdecl]<void*, bool>)__assembly__.LoadFuncPtr(nameof(uiControlEnabledToUser)))(c);

        //TODO: [GeneratedCode("LibUISharp.CodeAnalysis.NativeCallGenerator", "1.0.0")]
        public static partial void uiUserBugCannotSetParentOnToplevel(byte* type) => ((delegate* unmanaged[Cdecl]<byte*, void>)__assembly__.LoadFuncPtr(nameof(uiUserBugCannotSetParentOnToplevel)))(type);

        //TODO: [GeneratedCode("LibUISharp.CodeAnalysis.NativeCallGenerator", "1.0.0")]
        public static partial byte* uiWindowTitle(void* w) => ((delegate* unmanaged[Cdecl]<void*, byte*>)__assembly__.LoadFuncPtr(nameof(uiWindowTitle)))(w);

        //TODO: [GeneratedCode("LibUISharp.CodeAnalysis.NativeCallGenerator", "1.0.0")]
        public static partial void uiWindowSetTitle(void* w, byte* title) => ((delegate* unmanaged[Cdecl]<void*, byte*, void>)__assembly__.LoadFuncPtr(nameof(uiWindowSetTitle)))(w, title);

        //TODO: [GeneratedCode("LibUISharp.CodeAnalysis.NativeCallGenerator", "1.0.0")]
        public static partial void uiWindowContentSize(void* w, int* width, int* height) => ((delegate* unmanaged[Cdecl]<void*, int*, int*, void>)__assembly__.LoadFuncPtr(nameof(uiWindowContentSize)))(w, width, height);

        //TODO: [GeneratedCode("LibUISharp.CodeAnalysis.NativeCallGenerator", "1.0.0")]
        public static partial void uiWindowSetContentSize(void* w, int width, int height) => ((delegate* unmanaged[Cdecl]<void*, int, int, void>)__assembly__.LoadFuncPtr(nameof(uiWindowSetContentSize)))(w, width, height);

        //TODO: [GeneratedCode("LibUISharp.CodeAnalysis.NativeCallGenerator", "1.0.0")]
        public static partial int uiWindowFullscreen(void* w) => ((delegate* unmanaged[Cdecl]<void*, int>)__assembly__.LoadFuncPtr(nameof(uiWindowFullscreen)))(w);

        //TODO: [GeneratedCode("LibUISharp.CodeAnalysis.NativeCallGenerator", "1.0.0")]
        public static partial void uiWindowSetFullscreen(void* w, bool fullscreen) => ((delegate* unmanaged[Cdecl]<void*, bool, void>)__assembly__.LoadFuncPtr(nameof(uiWindowSetFullscreen)))(w, fullscreen);

        //TODO: [GeneratedCode("LibUISharp.CodeAnalysis.NativeCallGenerator", "1.0.0")]
        public static partial void uiWindowOnContentSizeChanged(void* w, delegate* unmanaged[Cdecl]<void*, void*, bool> f, void* data) => ((delegate* unmanaged[Cdecl]<void*, delegate* unmanaged[Cdecl]<void*, void*, bool>, void*, void>)__assembly__.LoadFuncPtr(nameof(uiWindowOnContentSizeChanged)))(w, f, data);

        //TODO: [GeneratedCode("LibUISharp.CodeAnalysis.NativeCallGenerator", "1.0.0")]
        public static partial void uiWindowOnClosing(void* w, delegate* unmanaged[Cdecl]<void*, void*, bool> f, void* data) => ((delegate* unmanaged[Cdecl]<void*, delegate* unmanaged[Cdecl]<void*, void*, bool>, void*, void>)__assembly__.LoadFuncPtr(nameof(uiWindowOnClosing)))(w, f, data);

        //TODO: [GeneratedCode("LibUISharp.CodeAnalysis.NativeCallGenerator", "1.0.0")]
        public static partial int uiWindowBorderless(void* w) => ((delegate* unmanaged[Cdecl]<void*, int>)__assembly__.LoadFuncPtr(nameof(uiWindowBorderless)))(w);

        //TODO: [GeneratedCode("LibUISharp.CodeAnalysis.NativeCallGenerator", "1.0.0")]
        public static partial void uiWindowSetBorderless(void* w, bool borderless) => ((delegate* unmanaged[Cdecl]<void*, bool, void>)__assembly__.LoadFuncPtr(nameof(uiWindowSetBorderless)))(w, borderless);

        //TODO: [GeneratedCode("LibUISharp.CodeAnalysis.NativeCallGenerator", "1.0.0")]
        public static partial void uiWindowSetChild(void* w, void* child) => ((delegate* unmanaged[Cdecl]<void*, void*, void>)__assembly__.LoadFuncPtr(nameof(uiWindowSetChild)))(w, child);

        //TODO: [GeneratedCode("LibUISharp.CodeAnalysis.NativeCallGenerator", "1.0.0")]
        public static partial int uiWindowMargined(void* w) => ((delegate* unmanaged[Cdecl]<void*, int>)__assembly__.LoadFuncPtr(nameof(uiWindowMargined)))(w);

        //TODO: [GeneratedCode("LibUISharp.CodeAnalysis.NativeCallGenerator", "1.0.0")]
        public static partial void uiWindowSetMargined(void* w, bool margined) => ((delegate* unmanaged[Cdecl]<void*, bool, void>)__assembly__.LoadFuncPtr(nameof(uiWindowSetMargined)))(w, margined);

        //TODO: [GeneratedCode("LibUISharp.CodeAnalysis.NativeCallGenerator", "1.0.0")]
        public static partial void* uiNewWindow(byte* title, int width, int height, bool hasMenubar) => ((delegate* unmanaged[Cdecl]<byte*, int, int, bool, void*>)__assembly__.LoadFuncPtr(nameof(uiNewWindow)))(title, width, height, hasMenubar);
    }
}
