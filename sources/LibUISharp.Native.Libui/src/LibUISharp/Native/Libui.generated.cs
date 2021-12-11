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
        public static partial bool uiMainStep(bool wait) => ((delegate* unmanaged[Cdecl]<bool, bool>)__assembly__.LoadFuncPtr(nameof(uiMainStep)))(wait);

        //TODO: [GeneratedCode("LibUISharp.CodeAnalysis.NativeCallGenerator", "1.0.0")]
        public static partial void uiQuit() => ((delegate* unmanaged[Cdecl]<void>)__assembly__.LoadFuncPtr(nameof(uiQuit)))();

        //TODO: [GeneratedCode("LibUISharp.CodeAnalysis.NativeCallGenerator", "1.0.0")]
        public static partial void uiQueueMain(delegate* unmanaged[Cdecl]<IntPtr, void> f, IntPtr data) => ((delegate* unmanaged[Cdecl]<delegate* unmanaged[Cdecl]<IntPtr, void>, IntPtr, void>)__assembly__.LoadFuncPtr(nameof(uiQueueMain)))(f, data);

        //TODO: [GeneratedCode("LibUISharp.CodeAnalysis.NativeCallGenerator", "1.0.0")]
        public static partial void uiTimer(int milliseconds, delegate* unmanaged[Cdecl]<IntPtr, int> f, IntPtr data) => ((delegate* unmanaged[Cdecl]<int, delegate* unmanaged[Cdecl]<IntPtr, int>, IntPtr, void>)__assembly__.LoadFuncPtr(nameof(uiTimer)))(milliseconds, f, data);

        //TODO: [GeneratedCode("LibUISharp.CodeAnalysis.NativeCallGenerator", "1.0.0")]
        public static partial void uiOnShouldQuit(delegate* unmanaged[Cdecl]<IntPtr, bool> f, IntPtr data) => ((delegate* unmanaged[Cdecl]<delegate* unmanaged[Cdecl]<IntPtr, bool>, IntPtr, void>)__assembly__.LoadFuncPtr(nameof(uiOnShouldQuit)))(f, data);

        //TODO: [GeneratedCode("LibUISharp.CodeAnalysis.NativeCallGenerator", "1.0.0")]
        public static partial void uiFreeText(byte* text) => ((delegate* unmanaged[Cdecl]<byte*, void>)__assembly__.LoadFuncPtr(nameof(uiFreeText)))(text);

        //TODO: [GeneratedCode("LibUISharp.CodeAnalysis.NativeCallGenerator", "1.0.0")]
        public static partial void uiControlDestroy(IntPtr c) => ((delegate* unmanaged[Cdecl]<IntPtr, void>)__assembly__.LoadFuncPtr(nameof(uiControlDestroy)))(c);

        //TODO: [GeneratedCode("LibUISharp.CodeAnalysis.NativeCallGenerator", "1.0.0")]
        public static partial UIntPtr uiControlHandle(IntPtr c) => ((delegate* unmanaged[Cdecl]<IntPtr, UIntPtr>)__assembly__.LoadFuncPtr(nameof(uiControlHandle)))(c);

        //TODO: [GeneratedCode("LibUISharp.CodeAnalysis.NativeCallGenerator", "1.0.0")]
        public static partial IntPtr uiControlParent(IntPtr c) => ((delegate* unmanaged[Cdecl]<IntPtr, IntPtr>)__assembly__.LoadFuncPtr(nameof(uiControlParent)))(c);

        //TODO: [GeneratedCode("LibUISharp.CodeAnalysis.NativeCallGenerator", "1.0.0")]
        public static partial void uiControlSetParent(IntPtr c) => ((delegate* unmanaged[Cdecl]<IntPtr, void>)__assembly__.LoadFuncPtr(nameof(uiControlSetParent)))(c);

        //TODO: [GeneratedCode("LibUISharp.CodeAnalysis.NativeCallGenerator", "1.0.0")]
        public static partial bool uiControlToplevel(IntPtr c) => ((delegate* unmanaged[Cdecl]<IntPtr, bool>)__assembly__.LoadFuncPtr(nameof(uiControlToplevel)))(c);

        //TODO: [GeneratedCode("LibUISharp.CodeAnalysis.NativeCallGenerator", "1.0.0")]
        public static partial bool uiControlVisible(IntPtr c) => ((delegate* unmanaged[Cdecl]<IntPtr, bool>)__assembly__.LoadFuncPtr(nameof(uiControlVisible)))(c);

        //TODO: [GeneratedCode("LibUISharp.CodeAnalysis.NativeCallGenerator", "1.0.0")]
        public static partial void uiControlShow(IntPtr c) => ((delegate* unmanaged[Cdecl]<IntPtr, void>)__assembly__.LoadFuncPtr(nameof(uiControlShow)))(c);

        //TODO: [GeneratedCode("LibUISharp.CodeAnalysis.NativeCallGenerator", "1.0.0")]
        public static partial void uiControlHide(IntPtr c) => ((delegate* unmanaged[Cdecl]<IntPtr, void>)__assembly__.LoadFuncPtr(nameof(uiControlHide)))(c);

        //TODO: [GeneratedCode("LibUISharp.CodeAnalysis.NativeCallGenerator", "1.0.0")]
        public static partial bool uiControlEnabled(IntPtr c) => ((delegate* unmanaged[Cdecl]<IntPtr, bool>)__assembly__.LoadFuncPtr(nameof(uiControlEnabled)))(c);

        //TODO: [GeneratedCode("LibUISharp.CodeAnalysis.NativeCallGenerator", "1.0.0")]
        public static partial void uiControlEnable(IntPtr c) => ((delegate* unmanaged[Cdecl]<IntPtr, void>)__assembly__.LoadFuncPtr(nameof(uiControlEnable)))(c);

        //TODO: [GeneratedCode("LibUISharp.CodeAnalysis.NativeCallGenerator", "1.0.0")]
        public static partial void uiControlDisable(IntPtr c) => ((delegate* unmanaged[Cdecl]<IntPtr, void>)__assembly__.LoadFuncPtr(nameof(uiControlDisable)))(c);

        //// [GeneratedCode("LibUISharp.CodeAnalysis.NativeCallGenerator", "1.0.0")]
        //// public static partial IntPtr uiAllocControl(uint* n, uint OSsig, uint typesig, IntPtr typenamestr) => ((delegate* unmanaged[Cdecl]<uint*, uint, uint, IntPtr, IntPtr>)__assembly__.LoadFuncPtr(nameof(uiAllocControl)))(n, OSsig, typesig, typenamestr);

        //// [GeneratedCode("LibUISharp.CodeAnalysis.NativeCallGenerator", "1.0.0")]
        //// public static partial void uiFreeControl(IntPtr c) => ((delegate* unmanaged[Cdecl]<IntPtr, void>)__assembly__.LoadFuncPtr(nameof(uiFreeControl)))(c);

        //TODO: [GeneratedCode("LibUISharp.CodeAnalysis.NativeCallGenerator", "1.0.0")]
        public static partial void uiControlVerifySetParent(IntPtr c1, IntPtr c2) => ((delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void>)__assembly__.LoadFuncPtr(nameof(uiControlVerifySetParent)))(c1, c2);

        //TODO: [GeneratedCode("LibUISharp.CodeAnalysis.NativeCallGenerator", "1.0.0")]
        public static partial bool uiControlEnabledToUser(IntPtr c) => ((delegate* unmanaged[Cdecl]<IntPtr, bool>)__assembly__.LoadFuncPtr(nameof(uiControlEnabledToUser)))(c);

        //TODO: [GeneratedCode("LibUISharp.CodeAnalysis.NativeCallGenerator", "1.0.0")]
        public static partial void uiUserBugCannotSetParentOnToplevel(byte* type) => ((delegate* unmanaged[Cdecl]<byte*, void>)__assembly__.LoadFuncPtr(nameof(uiUserBugCannotSetParentOnToplevel)))(type);

        //TODO: [GeneratedCode("LibUISharp.CodeAnalysis.NativeCallGenerator", "1.0.0")]
        public static partial byte* uiWindowTitle(IntPtr w) => ((delegate* unmanaged[Cdecl]<IntPtr, byte*>)__assembly__.LoadFuncPtr(nameof(uiWindowTitle)))(w);

        //TODO: [GeneratedCode("LibUISharp.CodeAnalysis.NativeCallGenerator", "1.0.0")]
        public static partial void uiWindowSetTitle(IntPtr w, byte* title) => ((delegate* unmanaged[Cdecl]<IntPtr, byte*, void>)__assembly__.LoadFuncPtr(nameof(uiWindowSetTitle)))(w, title);

        //TODO: [GeneratedCode("LibUISharp.CodeAnalysis.NativeCallGenerator", "1.0.0")]
        public static partial void uiWindowContentSize(IntPtr w, int* width, int* height) => ((delegate* unmanaged[Cdecl]<IntPtr, int*, int*, void>)__assembly__.LoadFuncPtr(nameof(uiWindowContentSize)))(w, width, height);

        //TODO: [GeneratedCode("LibUISharp.CodeAnalysis.NativeCallGenerator", "1.0.0")]
        public static partial void uiWindowSetContentSize(IntPtr w, int width, int height) => ((delegate* unmanaged[Cdecl]<IntPtr, int, int, void>)__assembly__.LoadFuncPtr(nameof(uiWindowSetContentSize)))(w, width, height);

        //TODO: [GeneratedCode("LibUISharp.CodeAnalysis.NativeCallGenerator", "1.0.0")]
        public static partial int uiWindowFullscreen(IntPtr w) => ((delegate* unmanaged[Cdecl]<IntPtr, int>)__assembly__.LoadFuncPtr(nameof(uiWindowFullscreen)))(w);

        //TODO: [GeneratedCode("LibUISharp.CodeAnalysis.NativeCallGenerator", "1.0.0")]
        public static partial void uiWindowSetFullscreen(IntPtr w, bool fullscreen) => ((delegate* unmanaged[Cdecl]<IntPtr, bool, void>)__assembly__.LoadFuncPtr(nameof(uiWindowSetFullscreen)))(w, fullscreen);

        //TODO: [GeneratedCode("LibUISharp.CodeAnalysis.NativeCallGenerator", "1.0.0")]
        public static partial void uiWindowOnContentSizeChanged(IntPtr w, delegate* unmanaged[Cdecl]<IntPtr, void> f, IntPtr data) => ((delegate* unmanaged[Cdecl]<IntPtr, delegate* unmanaged[Cdecl]<IntPtr, void>, IntPtr, void>)__assembly__.LoadFuncPtr(nameof(uiWindowOnContentSizeChanged)))(w, f, data);

        //TODO: [GeneratedCode("LibUISharp.CodeAnalysis.NativeCallGenerator", "1.0.0")]
        public static partial void uiWindowOnClosing(IntPtr w, delegate* unmanaged[Cdecl]<IntPtr, IntPtr, bool> f, IntPtr data) => ((delegate* unmanaged[Cdecl]<IntPtr, delegate* unmanaged[Cdecl]<IntPtr, IntPtr, bool>, IntPtr, void>)__assembly__.LoadFuncPtr(nameof(uiWindowOnClosing)))(w, f, data);

        //TODO: [GeneratedCode("LibUISharp.CodeAnalysis.NativeCallGenerator", "1.0.0")]
        public static partial int uiWindowBorderless(IntPtr w) => ((delegate* unmanaged[Cdecl]<IntPtr, int>)__assembly__.LoadFuncPtr(nameof(uiWindowBorderless)))(w);

        //TODO: [GeneratedCode("LibUISharp.CodeAnalysis.NativeCallGenerator", "1.0.0")]
        public static partial void uiWindowSetBorderless(IntPtr w, bool borderless) => ((delegate* unmanaged[Cdecl]<IntPtr, bool, void>)__assembly__.LoadFuncPtr(nameof(uiWindowSetBorderless)))(w, borderless);

        //TODO: [GeneratedCode("LibUISharp.CodeAnalysis.NativeCallGenerator", "1.0.0")]
        public static partial void uiWindowSetChild(IntPtr w, IntPtr child) => ((delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void>)__assembly__.LoadFuncPtr(nameof(uiWindowSetChild)))(w, child);

        //TODO: [GeneratedCode("LibUISharp.CodeAnalysis.NativeCallGenerator", "1.0.0")]
        public static partial int uiWindowMargined(IntPtr w) => ((delegate* unmanaged[Cdecl]<IntPtr, int>)__assembly__.LoadFuncPtr(nameof(uiWindowMargined)))(w);

        //TODO: [GeneratedCode("LibUISharp.CodeAnalysis.NativeCallGenerator", "1.0.0")]
        public static partial void uiWindowSetMargined(IntPtr w, bool margined) => ((delegate* unmanaged[Cdecl]<IntPtr, bool, void>)__assembly__.LoadFuncPtr(nameof(uiWindowSetMargined)))(w, margined);

        //TODO: [GeneratedCode("LibUISharp.CodeAnalysis.NativeCallGenerator", "1.0.0")]
        public static partial IntPtr uiNewWindow(byte* title, int width, int height, bool hasMenubar) => ((delegate* unmanaged[Cdecl]<byte*, int, int, bool, IntPtr>)__assembly__.LoadFuncPtr(nameof(uiNewWindow)))(title, width, height, hasMenubar);
    }
}
