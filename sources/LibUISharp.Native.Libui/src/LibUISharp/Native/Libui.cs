//TODO: using LibUISharp.CodeAnalysis;

// size_t   => UIntPtr
// char     => sbyte
// char*    => IntPtr

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace LibUISharp.Native
{
    //TODO: Write an unsafe version of this.
    //TODO: Add `NativeCall` attributes to all partial functions.
    /// <summary>
    /// Provides static access to the raw <c>libui</c> types and functions. This class is for advanced use.
    /// </summary>
    //TODO: [NativeAssembly("libui", NativeAssemblyFormats.Any, CallConvention = NativeCallConvention.Cdecl)]
    [SuppressMessage("Naming", "CA1712:Do not prefix enum values with type name", Justification = "<Pending>")]
    [SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [SuppressMessage("Design", "CA1034:Nested types should not be visible", Justification = "<Pending>")]
    [SuppressMessage("Performance", "CA1815:Override equals and operator equals on value types", Justification = "<Pending>")]
    public static unsafe partial class Libui
    {
        #region Constants
        public const double uiPi = 3.14159265358979323846264338327950288419716939937510582097494459;
        #endregion

        #region Enums
        public enum uiForEach
        {
            uiForEachContinue,
            uiForEachStop
        }
        #endregion

        #region Structures
        [StructLayout(LayoutKind.Sequential)]
        public struct uiInitOptions
        {
            public uint* Size;
        }

        public struct uiControl
        {
            public uint Signature;
            public uint OSSignature;
            public uint TypeSignature;
            public delegate* unmanaged[Cdecl]<uiControl*, void> Destroy;
            public delegate* unmanaged[Cdecl]<uiControl*, UIntPtr> Handle;
            public delegate* unmanaged[Cdecl]<uiControl*, uiControl*> Parent;
            public delegate* unmanaged[Cdecl]<uiControl*, void> SetParent;
            public delegate* unmanaged[Cdecl]<uiControl*, int> TopLevel;
            public delegate* unmanaged[Cdecl]<uiControl*, int> Visible;
            public delegate* unmanaged[Cdecl]<uiControl*, void> Show;
            public delegate* unmanaged[Cdecl]<uiControl*, void> Hide;
            public delegate* unmanaged[Cdecl]<uiControl*, int> Enabled;
            public delegate* unmanaged[Cdecl]<uiControl*, void> Enable;
            public delegate* unmanaged[Cdecl]<uiControl*, void> Disable;
        }
        #endregion

        /*TODO: [NativeCall]*/ public static partial IntPtr uiInit(uiInitOptions* options);
        /*TODO: [NativeCall]*/ public static partial void uiUninit();
        /*TODO: [NativeCall]*/ public static partial void uiFreeInitError(IntPtr err);
        /*TODO: [NativeCall]*/ public static partial void uiMain();
        /*TODO: [NativeCall]*/ public static partial void uiMainSteps();
        /*TODO: [NativeCall]*/ public static partial int uiMainStep(int wait);
        /*TODO: [NativeCall]*/ public static partial void uiQuit();
        /*TODO: [NativeCall]*/ public static partial void uiQueueMain(delegate* unmanaged[Cdecl]<void*, void> f, void* data);
        /*TODO: [NativeCall]*/ public static partial void uiTimer(int milliseconds, delegate* unmanaged[Cdecl]<void*, int> f, void* data);
        /*TODO: [NativeCall]*/ public static partial void uiOnShouldQuit(delegate* unmanaged[Cdecl]<void*, void> f, void* data);
        /*TODO: [NativeCall]*/ public static partial void uiFreeText(IntPtr text);

        /*TODO: [NativeCall]*/ public static partial void uiControlDestroy(void* c);
        /*TODO: [NativeCall]*/ public static partial UIntPtr uiControlHandle(void* c);
        /*TODO: [NativeCall]*/ public static partial void* uiControlParent(void* c);
        /*TODO: [NativeCall]*/ public static partial void uiControlSetParent(void* c);
        /*TODO: [NativeCall]*/ public static partial bool uiControlToplevel(void* c);
        /*TODO: [NativeCall]*/ public static partial bool uiControlVisible(void* c);
        /*TODO: [NativeCall]*/ public static partial void uiControlShow(void* c);
        /*TODO: [NativeCall]*/ public static partial void uiControlHide(void* c);
        /*TODO: [NativeCall]*/ public static partial bool uiControlEnabled(void* c);
        /*TODO: [NativeCall]*/ public static partial void uiControlEnable(void* c);
        /*TODO: [NativeCall]*/ public static partial void uiControlDisable(void* c);
        /*TODO: [NativeCall]*/ public static partial void* uiAllocControl(uint* n, uint OSsig, uint typesig, IntPtr typenamestr);
        /*TODO: [NativeCall]*/ public static partial void uiFreeControl(void* c);
        /*TODO: [NativeCall]*/ public static partial void uiControlVerifySetParent(void* c1, void* c2);
        /*TODO: [NativeCall]*/ public static partial bool uiControlEnabledToUser(void* c);
        /*TODO: [NativeCall]*/ public static partial void uiUserBugCannotSetParentOnToplevel(IntPtr type);

        /*TODO: [NativeCall]*/ public static partial IntPtr uiWindowTitle(void* w);
        /*TODO: [NativeCall]*/ public static partial void uiWindowSetTitle(void* w, IntPtr title);
        /*TODO: [NativeCall]*/ public static partial void uiWindowContentSize(void* w, int* width, int* height);
        /*TODO: [NativeCall]*/ public static partial void uiWindowSetContentSize(void* w, int width, int height);
        /*TODO: [NativeCall]*/ public static partial int uiWindowFullscreen(void* w);
        /*TODO: [NativeCall]*/ public static partial void uiWindowSetFullscreen(void* w, int fullscreen);
        /*TODO: [NativeCall]*/ public static partial void uiWindowOnContentSizeChanged(void* w, delegate* unmanaged[Cdecl]<void*, void*, int> f, void* data);
        /*TODO: [NativeCall]*/ public static partial void uiWindowOnClosing(void* w, delegate* unmanaged[Cdecl]<void*, void*, int> f, void* data);
        /*TODO: [NativeCall]*/ public static partial int uiWindowBorderless(void* w);
        /*TODO: [NativeCall]*/ public static partial void uiWindowSetBorderless(void* w, int borderless);
        /*TODO: [NativeCall]*/ public static partial void uiWindowSetChild(void* w, void* child);
        /*TODO: [NativeCall]*/ public static partial int uiWindowMargined(void* w);
        /*TODO: [NativeCall]*/ public static partial void uiWindowSetMargined(void* w, int margined);
        /*TODO: [NativeCall]*/ public static partial void* uiNewWindow(IntPtr title, int width, int height, int hasMenubar);
        
        /*TODO: [NativeCall]*/ public static partial IntPtr uiButtonText(void* b);
        /*TODO: [NativeCall]*/ public static partial void uiButtonSetText(void* b, IntPtr text);
        /*TODO: [NativeCall]*/ public static partial void uiButtonOnClicked(void* b, delegate* unmanaged[Cdecl]<void*, void*, void> f, void* data);
        /*TODO: [NativeCall]*/ public static partial void* uiNewButton(IntPtr text);

        
        /*TODO: [NativeCall]*/ public static partial void uiBoxAppend(void* b, void* child, int stretches);
        /*TODO: [NativeCall]*/ public static partial int uiBoxDelete(void* b, int index);
        /*TODO: [NativeCall]*/ public static partial void uiBoxPadded(void* b);
        /*TODO: [NativeCall]*/ public static partial void* uiBoxSetPadded(void* b, int padded);
        /*TODO: [NativeCall]*/ public static partial void* uiNewHorizontalBox();
        /*TODO: [NativeCall]*/ public static partial void* uiNewVerticalBox();

        /*TODO: [NativeCall]*/ public static partial IntPtr uiCheckboxText(void* c);
        /*TODO: [NativeCall]*/ public static partial void uiCheckboxSetText(void* c, IntPtr text);
        /*TODO: [NativeCall]*/ public static partial void uiCheckboxOnToggle(IntPtr text);
        /*TODO: [NativeCall]*/ public static partial bool uiCheckboxChecked(void* c);
        /*TODO: [NativeCall]*/ public static partial void uiCheckboxSetChecked(void* c, bool @checked);
        /*TODO: [NativeCall]*/ public static partial void* uiNewCheckbox(IntPtr text);

        /*TODO: [NativeCall]*/ public static partial IntPtr uiEntryText(void* e);
        /*TODO: [NativeCall]*/ public static partial void uiEntrySetText(void* e, IntPtr text);
        /*TODO: [NativeCall]*/ public static partial void uiEntryOnChanged(void* e, delegate* unmanaged[Cdecl]<void*, void*, void> f, void* data);
        /*TODO: [NativeCall]*/ public static partial bool uiEntryReadOnly(void* e);
        /*TODO: [NativeCall]*/ public static partial void uiEntrySetReadOnly(void* e, bool @readonly);
        /*TODO: [NativeCall]*/ public static partial void* uiNewEntry();
        /*TODO: [NativeCall]*/ public static partial void* uiNewPasswordEntry();
        /*TODO: [NativeCall]*/ public static partial void* uiNewSearchEntry();

        /*TODO: [NativeCall]*/ public static partial IntPtr uiLabelText(void* l);
        /*TODO: [NativeCall]*/ public static partial void uiLabelSetText(void* l, IntPtr text);
        /*TODO: [NativeCall]*/ public static partial void* uiNewLabel(IntPtr text);

    }
}