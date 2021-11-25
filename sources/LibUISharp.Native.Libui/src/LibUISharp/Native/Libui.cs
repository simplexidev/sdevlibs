using LibUISharp.Internal;
using LibUISharp.Runtime.InteropServices;

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
    internal static unsafe
#if USE_NATIVECALLGENERATOR
        partial
#endif
        class Libui
    {
#if !USE_NATIVECALLGENERATOR
        private static readonly NativeAssembly __assembly__ = new NativeAssembly(Platform.IsWindows ? "libui.dll" : Platform.IsMacOS ? "libui.dylib" : Platform.IsLinux ? "libui.so" : Platform.IsFreeBSD ? "libui.so.2" : throw new PlatformNotSupportedException());
#endif

        public const double uiPi = 3.14159265358979323846264338327950288419716939937510582097494459;

        public enum uiForEach
        {
            uiForEachContinue,
            uiForEachStop
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct uiInitOptions
        {
            public uint* Size;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct uiControl
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
            public delegate* unmanaged[Cdecl]<uiControl*, void> Hide;
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
        public static sbyte* uiInit(uiInitOptions* options) => ((delegate* unmanaged[Cdecl]<uiInitOptions*, sbyte*>)__assembly__.LoadFuncPtr(nameof(uiInit)))(options);
        public static void uiUninit() => ((delegate* unmanaged[Cdecl]<void>)__assembly__.LoadFuncPtr(nameof(uiUninit)))();
        public static void uiFreeInitError(sbyte* err) => ((delegate* unmanaged[Cdecl]<sbyte*, void>)__assembly__.LoadFuncPtr(nameof(uiFreeInitError)))(err);
        public static void uiMain() => ((delegate* unmanaged[Cdecl]<void>)__assembly__.LoadFuncPtr(nameof(uiMain)))();
        public static void uiMainSteps() => ((delegate* unmanaged[Cdecl]<void>)__assembly__.LoadFuncPtr(nameof(uiMainSteps)))();
        public static int uiMainStep(int wait) => ((delegate* unmanaged[Cdecl]<int, int>)__assembly__.LoadFuncPtr(nameof(uiMainStep)))(wait);
        public static void uiQuit() => ((delegate* unmanaged[Cdecl]<void>)__assembly__.LoadFuncPtr(nameof(uiQuit)))();
        public static void uiQueueMain(delegate* unmanaged[Cdecl]<void*, void> f, void* data) => ((delegate* unmanaged[Cdecl]<delegate* unmanaged[Cdecl]<void*, void>, void*, void>)__assembly__.LoadFuncPtr(nameof(uiQueueMain)))(f, data);
        public static void uiTimer(int milliseconds, delegate* unmanaged[Cdecl]<void*, int> f, void* data) => ((delegate* unmanaged[Cdecl]<int, delegate* unmanaged[Cdecl]<void*, int>, void*, void>)__assembly__.LoadFuncPtr(nameof(uiTimer)))(milliseconds, f, data);
        public static void uiOnShouldQuit(delegate* unmanaged[Cdecl]<void*, void> f, void* data) => ((delegate* unmanaged[Cdecl]<delegate* unmanaged[Cdecl]<void*, void>, void*, void>)__assembly__.LoadFuncPtr(nameof(uiOnShouldQuit)))(f, data);
        public static void uiFreeText(sbyte* text) => ((delegate* unmanaged[Cdecl]<sbyte*, void>)__assembly__.LoadFuncPtr(nameof(uiFreeText)))(text);

        public static void uiControlDestroy(uiControl* c) => ((delegate* unmanaged[Cdecl]<uiControl*, void>)__assembly__.LoadFuncPtr(nameof(uiControlDestroy)))(c);
        public static UIntPtr uiControlHandle(uiControl* c) => ((delegate* unmanaged[Cdecl]<uiControl*, UIntPtr>)__assembly__.LoadFuncPtr(nameof(uiControlHandle)))(c);
        public static uiControl* uiControlParent(uiControl* c) => ((delegate* unmanaged[Cdecl]<uiControl*, uiControl*>)__assembly__.LoadFuncPtr(nameof(uiControlParent)))(c);
        public static void uiControlSetParent(uiControl* c) => ((delegate* unmanaged[Cdecl]<uiControl*, void>)__assembly__.LoadFuncPtr(nameof(uiControlSetParent)))(c);
        public static int uiControlToplevel(uiControl* c) => ((delegate* unmanaged[Cdecl]<uiControl*, int>)__assembly__.LoadFuncPtr(nameof(uiControlToplevel)))(c);
        public static int uiControlVisible(uiControl* c) => ((delegate* unmanaged[Cdecl]<uiControl*, int>)__assembly__.LoadFuncPtr(nameof(uiControlVisible)))(c);
        public static void uiControlShow(uiControl* c) => ((delegate* unmanaged[Cdecl]<uiControl*, void>)__assembly__.LoadFuncPtr(nameof(uiControlShow)))(c);
        public static void uiControlHide(uiControl* c) => ((delegate* unmanaged[Cdecl]<uiControl*, void>)__assembly__.LoadFuncPtr(nameof(uiControlHide)))(c);
        public static int uiControlEnabled(uiControl* c) => ((delegate* unmanaged[Cdecl]<uiControl*, int>)__assembly__.LoadFuncPtr(nameof(uiControlEnabled)))(c);
        public static void uiControlEnable(uiControl* c) => ((delegate* unmanaged[Cdecl]<uiControl*, void>)__assembly__.LoadFuncPtr(nameof(uiControlEnable)))(c);
        public static void uiControlDisable(uiControl* c) => ((delegate* unmanaged[Cdecl]<uiControl*, void>)__assembly__.LoadFuncPtr(nameof(uiControlDisable)))(c);
        public static uiControl* uiAllocControl(uint* n, uint OSsig, uint typesig, sbyte* typenamestr) => ((delegate* unmanaged[Cdecl]<uint*, uint, uint, sbyte*, uiControl*>)__assembly__.LoadFuncPtr(nameof(uiAllocControl)))(n, OSsig, typesig, typenamestr);
        public static void uiFreeControl(uiControl* c) => ((delegate* unmanaged[Cdecl]<uiControl*, void>)__assembly__.LoadFuncPtr(nameof(uiFreeControl)))(c);
        public static void uiControlVerifySetParent(uiControl* c1, uiControl* c2) => ((delegate* unmanaged[Cdecl]<uiControl*, uiControl*, void>)__assembly__.LoadFuncPtr(nameof(uiControlVerifySetParent)))(c1, c2);
        public static int uiControlEnabledToUser(uiControl* c) => ((delegate* unmanaged[Cdecl]<uiControl*, int>)__assembly__.LoadFuncPtr(nameof(uiControlEnabledToUser)))(c);
        public static void uiUserBugCannotSetParentOnToplevel(sbyte* type) => ((delegate* unmanaged[Cdecl]<sbyte*, void>)__assembly__.LoadFuncPtr(nameof(uiUserBugCannotSetParentOnToplevel)))(type);

        public static sbyte* uiWindowTitle(void* w) => ((delegate* unmanaged[Cdecl]<void*, sbyte*>)__assembly__.LoadFuncPtr(nameof(uiWindowTitle)))(w);
        public static void uiWindowSetTitle(void* w, sbyte* title) => ((delegate* unmanaged[Cdecl]<void*, sbyte*, void>)__assembly__.LoadFuncPtr(nameof(uiWindowSetTitle)))(w, title);
        public static void uiWindowContentSize(void* w, int* width, int* height) => ((delegate* unmanaged[Cdecl]<void*, int*, int*, void>)__assembly__.LoadFuncPtr(nameof(uiWindowContentSize)))(w, width, height);
        public static void uiWindowSetContentSize(void* w, int width, int height) => ((delegate* unmanaged[Cdecl]<void*, int, int, void>)__assembly__.LoadFuncPtr(nameof(uiWindowSetContentSize)))(w, width, height);
        public static int uiWindowFullscreen(void* w) => ((delegate* unmanaged[Cdecl]<void*, int>)__assembly__.LoadFuncPtr(nameof(uiWindowFullscreen)))(w);
        public static void uiWindowSetFullscreen(void* w, int fullscreen) => ((delegate* unmanaged[Cdecl]<void*, int, void>)__assembly__.LoadFuncPtr(nameof(uiWindowSetFullscreen)))(w, fullscreen);
        public static void uiWindowOnContentSizeChanged(void* w, delegate* unmanaged[Cdecl]<void*, void*, int> f, void* data) => ((delegate* unmanaged[Cdecl]<void*, delegate* unmanaged[Cdecl]<void*, void*, int>, void*, void>)__assembly__.LoadFuncPtr(nameof(uiWindowOnContentSizeChanged)))(w, f, data);
        public static void uiWindowOnClosing(void* w, delegate* unmanaged[Cdecl]<void*, void*, int> f, void* data) => ((delegate* unmanaged[Cdecl]<void*, delegate* unmanaged[Cdecl]<void*, void*, int>, void*, void>)__assembly__.LoadFuncPtr(nameof(uiWindowOnClosing)))(w, f, data);
        public static int uiWindowBorderless(void* w) => ((delegate* unmanaged[Cdecl]<void*, int>)__assembly__.LoadFuncPtr(nameof(uiWindowBorderless)))(w);
        public static void uiWindowSetBorderless(void* w, int borderless) => ((delegate* unmanaged[Cdecl]<void*, int, void>)__assembly__.LoadFuncPtr(nameof(uiWindowSetBorderless)))(w, borderless);
        public static void uiWindowSetChild(void* w, uiControl* child) => ((delegate* unmanaged[Cdecl]<void*, uiControl*, void>)__assembly__.LoadFuncPtr(nameof(uiWindowSetChild)))(w, child);
        public static int uiWindowMargined(void* w) => ((delegate* unmanaged[Cdecl]<void*, int>)__assembly__.LoadFuncPtr(nameof(uiWindowMargined)))(w);
        public static void uiWindowSetMargined(void* w, int margined) => ((delegate* unmanaged[Cdecl]<void*, int, void>)__assembly__.LoadFuncPtr(nameof(uiWindowSetMargined)))(w, margined);
        public static void* uiNewWindow(sbyte* title, int width, int height, int hasMenubar) => ((delegate* unmanaged[Cdecl]<sbyte*, int, int, int, void*>)__assembly__.LoadFuncPtr(nameof(uiNewWindow)))(title, width, height, hasMenubar);

#endif
    }
}