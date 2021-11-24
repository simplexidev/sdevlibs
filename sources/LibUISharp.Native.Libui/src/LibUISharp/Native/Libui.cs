using System;
using System.Runtime.InteropServices;
#if USE_NATIVECALLGENERATION
using LibUISharp.CodeAnalysis.NativeCallGeneration;
#endif

namespace LibUISharp.Native
{
#if USE_NATIVECALLGENERATION
    [NativeAssembly("libui", NativeAssemblyPlatforms.Windows | NativeAssemblyPlatforms.MacOS | NativeAssemblyPlatforms.Linux | NativeAssemblyPlatforms.FreeBSD)]
#endif
    internal static
#if USE_NATIVECALLGENERATOR
        partial
#endif
        class Libui
    {
#if !USE_NATIVECALLGENERATOR
        private static readonly NativeAssembly __assembly__ = new NativeAssembly(Platform.IsWindows ? "libui.dll" : Platform.IsMacOS ? "libui.dylib" : Platform.IsLinux ? "libui.so" : Platform.IsFreeBSD ? "libui.so.2" : throw new PlatformNotSupportedException())
#endif

        public const double uiPi = 3.14159265358979323846264338327950288419716939937510582097494459;

        public enum uiForEach
        {
            uiForEachContinue,
            uiForEachStop
        }

        [StructLayout(LayoutKind.Sequential)]
        public readonly struct uiInitOptions
        {
            public uint* Size;
        }
        [StructLayout(LayoutKind.Sequential)]
        public readonly struct uiControl
        {
            public uint Signature;
            public uint OSSignature;
            public uint TypeSignature;
            public delegate* unmanaged[Cdecl]<uiControl*, void> Destroy;
            public delegate* unmanaged[Cdecl]<uiControl*, UIntPtr> Handle;
            public delegate* unmanaged[Cdecl]<uiControl*, uiControl> Parent;
            public delegate* unmanaged[Cdecl]<uiControl*, void> SetParent;
            public delegate* unmanaged[Cdecl]<uiControl*, int> Toplevel;
            public delegate* unmanaged[Cdecl]<uiControl*, int> Visible;
            public delegate* unmanaged[Cdecl]<uiControl*, void> Show;
            public delegate* unmanaged[Cdecl]<uiControl*, void> Hide
            public delegate* unmanaged[Cdecl]<uiControl*, int> Enabled;
            public delegate* unmanaged[Cdecl]<uiControl*, void> Enable;
            public delegate* unmanaged[Cdecl]<uiControl*, void> Disable;
        }

#if USE_NATIVECALLGENERATOR
        [NativeCall] public static partial sbyte* uiInit(uiInitOptions* options);
        [NativeCall] public static partial void uiUninit();
        [NativeCall] public static partial void uiFreeInitError(sbyte* err);
        [NativeCall] public static partial void uiMain();
        [NativeCall] public static partial void uiMainSteps();
        [NativeCall] public static partial int uiMainStep(int wait);
        [NativeCall] public static partial void uiQuit();
        [NativeCall] public static partial void uiQueueMain(delegate* unmanaged[Cdecl]<void*, void> f, void* data);
        [NativeCall] public static partial void uiTimer(int milliseconds, delegate* unmanaged[Cdecl]<void*, int> f, void* data);
        [NativeCall] public static partial void uiOnShouldQuit(delegate* unmanaged[Cdecl]<void*, void> f, void* data);
        [NativeCall] public static partial void uiFreeText(sbyte* text);

        [NativeCall] public static partial void uiControlDestroy(uiControl* c);
        [NativeCall] public static partial UIntPtr uiControlHandle(uiControl* c);
        [NativeCall] public static partial uiControl* uiControlParent(uiControl* c);
        [NativeCall] public static partial void uiControlSetParent(uiControl* c);
        [NativeCall] public static partial int uiControlToplevel(uiControl* c);
        [NativeCall] public static partial int uiControlVisible(uiControl* c);
        [NativeCall] public static partial void uiControlShow(uiControl* c);
        [NativeCall] public static partial void uiControlHide(uiControl* c);
        [NativeCall] public static partial int uiControlEnabled(uiControl* c);
        [NativeCall] public static partial void uiControlEnable(uiControl* c);
        [NativeCall] public static partial void uiControlDisable(uiControl* c);
        [NativeCall] public static partial uiControl* uiAllocControl(uint* n, uint OSsig, uint typesig, sbyte* typenamestr);
        [NativeCall] public static partial void uiFreeControl(uiControl* c);
        [NativeCall] public static partial void uiControlVerifySetParent(uiControl* c1, uiControl c2);
        [NativeCall] public static partial int uiControlEnabledToUser(uiControl* c);
        [NativeCall] public static partial void uiUserBugCannotSetParentOnToplevel(sbyte* c);

        [NativeCall] public static partial sbyte* uiWindowTitle(void* w);
        [NativeCall] public static partial void uiWindowSetTitle(void*, sbyte* title);
        [NativeCall] public static partial void uiWindowContentSize(void* w, int* width, int* height);
        [NativeCall] public static partial void uiWindowSetContentSize(void* w, int width, int height);
        [NativeCall] public static partial int uiWindowFullscreen(void* w);
        [NativeCall] public static partial void uiWindowSetFullscreen(void* w, int fullscreen);
        [NativeCall] public static partial void uiWindowOnContentSizeChanged(void* w, delegate* unmanaged[Cdecl]<void*, void*, int> f, void* data);
        [NativeCall] public static partial void uiWindowOnClosing(void* w, delegate* unmanaged[Cdecl]<void*, void*, int> f, void* data);
        [NativeCall] public static partial int uiWindowBorderless(void* w);
        [NativeCall] public static partial void uiWindowSetBorderless(void* w, int borderless);
        [NativeCall] public static partial void uiWindowSetChild(void* w, uiControl* child);
        [NativeCall] public static partial int uiWindowMargined(void* w);
        [NativeCall] public static partial void uiWindowSetMargined(void* w, int margined);
        [NativeCall] public static partial void* uiNewWindow(sbyte* title, int width, int height, int hasMenubar);
#else
        public static sbyte* uiInit(uiInitOptions* options) => ((delegate* unmanaged[Cdecl]<uiInitOptions*, void>)__assembly__.GetFuncPtr(nameof(uiInit)))(options);
        public static void uiUninit() => ((delegate* unmanaged[Cdecl]<void>)__assembly__.GetFuncPtr(nameof(uiUninit)))();
        public static void uiFreeInitError(sbyte* err) => ((delegate* unmanaged[Cdecl]<sbyte*, void>)__assembly__.GetFuncPtr(nameof(uiFreeInitError)))(err);
        public static void uiMain() => ((delegate* unmanaged[Cdecl]<void>)__assembly__.GetFuncPtr(nameof(uiMain)))();
        public static void uiMainSteps() => ((delegate* unmanaged[Cdecl]<void>)__assembly__.GetFuncPtr(nameof(uiMainSteps)))();
        public static int uiMainStep(int wait) => ((delegate* unmanaged[Cdecl]<int, int>)__assembly__.GetFuncPtr(nameof(uiMainStep)))(wait);
        public static void uiQuit() => ((delegate* unmanaged[Cdecl]<void>)__assembly__.GetFuncPtr(nameof(uiQuit)))();
        public static void uiQueueMain(delegate* unmanaged[Cdecl]<void*, void> f, void* data) => ((delegate* unmanaged[Cdecl]<delegate* unmanaged[Cdecl]<void*, void>, void*, void>)__assembly__.GetFuncPtr(nameof(uiQueueMain)))(f, data);
        public static void uiTimer(int milliseconds, delegate* unmanaged[Cdecl]<void*, int> f, void* data) => ((delegate* unmanaged[Cdecl]<int, delegate* unmanaged[Cdecl]<void*, void>, void*, void>)__assembly__.GetFuncPtr(nameof(uiTimer)))(milliseconds, f, data);
        public static void uiOnShouldQuit(delegate* unmanaged[Cdecl]<void*, void> f, void* data) => ((delegate* unmanaged[Cdecl]<delegate* unmanaged[Cdecl]<void*, void>, void*, void>)__assembly__.GetFuncPtr(nameof(uiOnShouldQuit)))(f, data);
        public static void uiFreeText(sbyte* text) => ((delegate* unmanaged[Cdecl]<sbyte*, void>)__assembly__.GetFuncPtr(nameof(uiFreeText)))(text);

        public static void uiControlDestroy(uiControl* c) => ((delegate* unmanaged[Cdecl]<uiControl*, void>)__assembly__.GetFuncPtr(nameof(uiControlDestroy)))(c);
        public static UIntPtr uiControlHandle(uiControl* c) => ((delegate* unmanaged[Cdecl]<uiControl*, UIntPtr>)__assembly__.GetFuncPtr(nameof(uiControlHandle)))(c);
        public static uiControl* uiControlParent(uiControl* c) => ((delegate* unmanaged[Cdecl]<uiControl*, uiControl*>)__assembly__.GetFuncPtr(nameof(uiControlParent)))(c);
        public static void uiControlSetParent(uiControl* c) => ((delegate* unmanaged[Cdecl]<uiControl*, void>)__assembly__.GetFuncPtr(nameof(uiControlSetParent)))(c);
        public static int uiControlToplevel(uiControl* c) => ((delegate* unmanaged[Cdecl]<uiControl*, int>)__assembly__.GetFuncPtr(nameof(uiControlToplevel)))(c);
        public static int uiControlVisible(uiControl* c) => ((delegate* unmanaged[Cdecl]<uiControl*, int>)__assembly__.GetFuncPtr(nameof(uiControlVisible)))(c);
        public static void uiControlShow(uiControl* c) => ((delegate* unmanaged[Cdecl]<uiControl*, void>)__assembly__.GetFuncPtr(nameof(uiControlShow)))(c);
        public static void uiControlHide(uiControl* c) => ((delegate* unmanaged[Cdecl]<uiControl*, void>)__assembly__.GetFuncPtr(nameof(uiControlHide)))(c);
        public static int uiControlEnabled(uiControl* c) => ((delegate* unmanaged[Cdecl]<uiControl*, int>)__assembly__.GetFuncPtr(nameof(uiControlEnabled)))(c);
        public static void uiControlEnable(uiControl* c) => ((delegate* unmanaged[Cdecl]<uiControl*, void>)__assembly__.GetFuncPtr(nameof(uiControlEnable)))(c);
        public static void uiControlDisable(uiControl* c) => ((delegate* unmanaged[Cdecl]<uiControl*, void>)__assembly__.GetFuncPtr(nameof(uiControlDisable)))(c);
        public static uiControl* uiAllocControl(uint* n, uint OSsig, uint typesig, sbyte* typenamestr) => ((delegate* unmanaged[Cdecl]<uint*, uint, uint, sbyte*, uiControl*>)__assembly__.GetFuncPtr(nameof(uiAllocControl)))(n, OSsig, typesig, typenamestr);
        public static void uiFreeControl(uiControl* c) => ((delegate* unmanaged[Cdecl]<uiControl*, void>)__assembly__.GetFuncPtr(nameof(uiFreeControl)))(c);
        public static void uiControlVerifySetParent(uiControl* c1, uiControl c2) => ((delegate* unmanaged[Cdecl]<uiControl*, uiControl*>)__assembly__.GetFuncPtr(nameof(uiControlVerifySetParent)))(c1, c2);
        public static int uiControlEnabledToUser(uiControl* c) => ((delegate* unmanaged[Cdecl]<uiControl*, int>)__assembly__.GetFuncPtr(nameof(uiControlEnabledToUser)))(c);
        public static void uiUserBugCannotSetParentOnToplevel(sbyte* type) => ((delegate* unmanaged[Cdecl]<uiControl*, void>)__assembly__.GetFuncPtr(nameof(uiUserBugCannotSetParentOnToplevel)))(type);

        public static sbyte* uiWindowTitle(void* w) => ((delegate* unmanaged[Cdecl]<void*, sbyte*>)__assembly__.GetFuncPtr(nameof(uiWindowTitle)))(w);
        public static void uiWindowSetTitle(void* w, sbyte* title) => ((delegate* unmanaged[Cdecl]<void*, sbyte*, void>)__assembly__.GetFuncPtr(nameof(uiWindowSetTitle)))(w, title);
        public static void uiWindowContentSize(void* w, int* width, int* height) => ((delegate* unmanaged[Cdecl]<void*, int*, int*, void>)__assembly__.GetFuncPtr(nameof(uiWindowContentSize)))(w, width, height);
        public static void uiWindowSetContentSize(void* w, int width, int height) => ((delegate* unmanaged[Cdecl]<void*, int, int, void>)__assembly__.GetFuncPtr(nameof(uiWindowSetContentSize)))(w, width, height);
        public static int uiWindowFullscreen(void* w) => ((delegate* unmanaged[Cdecl]<void*, int>)__assembly__.GetFuncPtr(nameof(uiWindowFullscreen)))(w);
        public static void uiWindowSetFullscreen(void* w, int fullscreen) => ((delegate* unmanaged[Cdecl]<void*, int, void>)__assembly__.GetFuncPtr(nameof(uiWindowSetFullscreen)))(w fullscreen);
        public static void uiWindowOnContentSizeChanged(void* w, delegate* unmanaged[Cdecl]<void*, void*, int> f, void* data) => ((delegate* unmanaged[Cdecl]<void*, delegate* unmanaged[Cdecl]<void*, void*, int>, void*, void>)__assembly__.GetFuncPtr(nameof(uiWindowOnContentSizeChanged)))(w, f, data);
        public static void uiWindowOnClosing(void* w, delegate* unmanaged[Cdecl]<void*, void*, int> f, void* data) => ((delegate* unmanaged[Cdecl]<void*, delegate* unmanaged[Cdecl]<void*, void*, int>, void*, void>)__assembly__.GetFuncPtr(nameof(uiWindowOnClosing)))(w, f, data);
        public static int uiWindowBorderless(void* w) => ((delegate* unmanaged[Cdecl]<void*, int>)__assembly__.GetFuncPtr(nameof(uiWindowBorderless)))(w);
        public static void uiWindowSetBorderless(void* w, int borderless) => ((delegate* unmanaged[Cdecl]<void*, int, void>)__assembly__.GetFuncPtr(nameof(uiWindowSetBorderless)))(w, borderless);
        public static void uiWindowSetChild(void* w, uiControl* child) => ((delegate* unmanaged[Cdecl]<void*, uiControl, void>)__assembly__.GetFuncPtr(nameof(uiWindowSetChild)))(w, child);
        public static int uiWindowMargined(void* w) => ((delegate* unmanaged[Cdecl]<void*, int>)__assembly__.GetFuncPtr(nameof(uiWindowMargined)))(w);
        public static void uiWindowSetMargined(void* w, int margined) => ((delegate* unmanaged[Cdecl]<void*, int, void>)__assembly__.GetFuncPtr(nameof(uiWindowSetMargined)))(w, margined);
        public static void* uiNewWindow(sbyte* title, int width, int height, int hasMenubar) => ((delegate* unmanaged[Cdecl]<sbyte*, int, int, int, void*>)__assembly__.GetFuncPtr(nameof(uiNewWindow)))(title, width, height, hasMenubar);

#endif
    }
}