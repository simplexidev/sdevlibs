//using LibUISharp.CodeAnalysis;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace LibUISharp.Native
{
    /// <summary>
    /// Provides static access to the raw <c>libui</c> types and functions. This class is for advanced users.
    /// </summary>
    //[NativeAssembly("libui", NativeAssemblyFormats.Any, CallConvention = NativeCallConvention.Cdecl)]
    [SuppressMessage("Naming", "CA1712:Do not prefix enum values with type name", Justification = "<Pending>")]
    [SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [SuppressMessage("Design", "CA1034:Nested types should not be visible", Justification = "<Pending>")]
    [SuppressMessage("Performance", "CA1815:Override equals and operator equals on value types", Justification = "<Pending>")]
    public static unsafe partial class Libui
    {
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

        /*[NativeCall]*/ public static partial sbyte* uiInit(uiInitOptions* options);
        /*[NativeCall]*/ public static partial void uiUninit();
        /*[NativeCall]*/ public static partial void uiFreeInitError(sbyte* err);
        /*[NativeCall]*/ public static partial void uiMain();
        /*[NativeCall]*/ public static partial void uiMainSteps();
        /*[NativeCall]*/ public static partial int uiMainStep(int wait);
        /*[NativeCall]*/ public static partial void uiQuit();
        /*[NativeCall]*/ public static partial void uiQueueMain(delegate* unmanaged[Cdecl]<void*, void> f, void* data);
        /*[NativeCall]*/ public static partial void uiTimer(int milliseconds, delegate* unmanaged[Cdecl]<void*, int> f, void* data);
        /*[NativeCall]*/ public static partial void uiOnShouldQuit(delegate* unmanaged[Cdecl]<void*, void> f, void* data);
        /*[NativeCall]*/ public static partial void uiFreeText(sbyte* text);

        /*[NativeCall]*/ public static partial void uiControlDestroy(uiControl* c);
        /*[NativeCall]*/ public static partial UIntPtr uiControlHandle(uiControl* c);
        /*[NativeCall]*/ public static partial uiControl* uiControlParent(uiControl* c);
        /*[NativeCall]*/ public static partial void uiControlSetParent(uiControl* c);
        /*[NativeCall]*/ public static partial bool uiControlToplevel(uiControl* c);
        /*[NativeCall]*/ public static partial bool uiControlVisible(uiControl* c);
        /*[NativeCall]*/ public static partial void uiControlShow(uiControl* c);
        /*[NativeCall]*/ public static partial void uiControlHide(uiControl* c);
        /*[NativeCall]*/ public static partial bool uiControlEnabled(uiControl* c);
        /*[NativeCall]*/ public static partial void uiControlEnable(uiControl* c);
        /*[NativeCall]*/ public static partial void uiControlDisable(uiControl* c);
        /*[NativeCall]*/ public static partial uiControl* uiAllocControl(uint* n, uint OSsig, uint typesig, sbyte* typenamestr);
        /*[NativeCall]*/ public static partial void uiFreeControl(uiControl* c);
        /*[NativeCall]*/ public static partial void uiControlVerifySetParent(uiControl* c1, uiControl* c2);
        /*[NativeCall]*/ public static partial bool uiControlEnabledToUser(uiControl* c);
        /*[NativeCall]*/ public static partial void uiUserBugCannotSetParentOnToplevel(sbyte* type);

        /*[NativeCall]*/ public static partial sbyte* uiWindowTitle(void* w);
        /*[NativeCall]*/ public static partial void uiWindowSetTitle(void* w, sbyte* title);
        /*[NativeCall]*/ public static partial void uiWindowContentSize(void* w, int* width, int* height);
        /*[NativeCall]*/ public static partial void uiWindowSetContentSize(void* w, int width, int height);
        /*[NativeCall]*/ public static partial int uiWindowFullscreen(void* w);
        /*[NativeCall]*/ public static partial void uiWindowSetFullscreen(void* w, int fullscreen);
        /*[NativeCall]*/ public static partial void uiWindowOnContentSizeChanged(void* w, delegate* unmanaged[Cdecl]<void*, void*, int> f, void* data);
        /*[NativeCall]*/ public static partial void uiWindowOnClosing(void* w, delegate* unmanaged[Cdecl]<void*, void*, int> f, void* data);
        /*[NativeCall]*/ public static partial int uiWindowBorderless(void* w);
        /*[NativeCall]*/ public static partial void uiWindowSetBorderless(void* w, int borderless);
        /*[NativeCall]*/ public static partial void uiWindowSetChild(void* w, uiControl* child);
        /*[NativeCall]*/ public static partial int uiWindowMargined(void* w);
        /*[NativeCall]*/ public static partial void uiWindowSetMargined(void* w, int margined);
        /*[NativeCall]*/ public static partial void* uiNewWindow(sbyte* title, int width, int height, int hasMenubar);
    }
}