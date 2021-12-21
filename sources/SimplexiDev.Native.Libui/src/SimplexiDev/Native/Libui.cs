/***********************************************************************************************************************
 * FileName:            Libui.cs
 * Copyright/License:   https://github.com/simplexidev/sdfx/blob/main/LICENSE.md
***********************************************************************************************************************/

using SimplexiDev.Build;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace SimplexiDev.Native
{
    /// <summary>
    /// Provides static access to the raw <c>libui</c> types and functions. This class is for advanced use.
    /// </summary>
    [NativeAssembly("libui", NativeAssemblyFormats.All, CallConvention = NativeCallConvention.Cdecl)]
    [SuppressMessage("Naming", "CA1712:Do not prefix enum values with type name", Justification = "<Pending>")]
    [SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    [SuppressMessage("Design", "CA1034:Nested types should not be visible", Justification = "<Pending>")]
    [SuppressMessage("Performance", "CA1815:Override equals and operator equals on value types", Justification = "<Pending>")]
    public static unsafe partial class Libui
    {
        //TODO: Should we just use Math.PI and MathF.PI?
        public const double uiPi = 3.14159265358979323846264338327950288419716939937510582097494459;

        //TODO: Possibly replace with a boolean: if true, continue; if false, stop;
        public enum uiForEach
        {
            uiForEachContinue,
            uiForEachStop
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct uiInitOptions
        {
            public UIntPtr Size;
        }

        [NativeCall] public static partial byte* uiInit(uiInitOptions* options);
        [NativeCall] public static partial void uiUninit();
        [NativeCall] public static partial void uiFreeInitError(byte* err);
        [NativeCall] public static partial void uiMain();
        [NativeCall] public static partial void uiMainSteps();
        [NativeCall] public static partial bool uiMainStep(bool wait);
        [NativeCall] public static partial void uiQuit();
        [NativeCall] public static partial void uiQueueMain(delegate* unmanaged[Cdecl]<IntPtr, void> f, IntPtr data);
        [NativeCall] public static partial void uiTimer(int milliseconds, delegate* unmanaged[Cdecl]<IntPtr, int> f, IntPtr data);
        [NativeCall] public static partial void uiOnShouldQuit(delegate* unmanaged[Cdecl]<IntPtr, bool> f, IntPtr data);
        [NativeCall] public static partial void uiFreeText(byte* text);

        //// public struct uiControl { }

        [NativeCall] public static partial void uiControlDestroy(IntPtr c);
        [NativeCall] public static partial UIntPtr uiControlHandle(IntPtr c);
        [NativeCall] public static partial IntPtr uiControlParent(IntPtr c);
        [NativeCall] public static partial void uiControlSetParent(IntPtr c);
        [NativeCall] public static partial bool uiControlToplevel(IntPtr c);
        [NativeCall] public static partial bool uiControlVisible(IntPtr c);
        [NativeCall] public static partial void uiControlShow(IntPtr c);
        [NativeCall] public static partial void uiControlHide(IntPtr c);
        [NativeCall] public static partial bool uiControlEnabled(IntPtr c);
        [NativeCall] public static partial void uiControlEnable(IntPtr c);
        [NativeCall] public static partial void uiControlDisable(IntPtr c);
        //// [NativeCall] public static partial IntPtr uiAllocControl(UIntPtr n, uint OSsig, uint typesig, IntPtr typenamestr);
        //// [NativeCall] public static partial void uiFreeControl(IntPtr c);
        [NativeCall] public static partial void uiControlVerifySetParent(IntPtr c1, IntPtr c2);
        [NativeCall] public static partial bool uiControlEnabledToUser(IntPtr c);
        [NativeCall] public static partial void uiUserBugCannotSetParentOnToplevel(byte* type);

        [NativeCall] public static partial byte* uiWindowTitle(IntPtr w);
        [NativeCall] public static partial void uiWindowSetTitle(IntPtr w, byte* title);
        [NativeCall] public static partial void uiWindowContentSize(IntPtr w, int* width, int* height);
        [NativeCall] public static partial void uiWindowSetContentSize(IntPtr w, int width, int height);
        [NativeCall] public static partial int uiWindowFullscreen(IntPtr w);
        [NativeCall] public static partial void uiWindowSetFullscreen(IntPtr w, bool fullscreen);
        [NativeCall] public static partial void uiWindowOnContentSizeChanged(IntPtr w, delegate* unmanaged[Cdecl]<IntPtr, void> f, IntPtr data);
        [NativeCall] public static partial void uiWindowOnClosing(IntPtr w, delegate* unmanaged[Cdecl]<IntPtr, IntPtr, bool> f, IntPtr data);
        [NativeCall] public static partial int uiWindowBorderless(IntPtr w);
        [NativeCall] public static partial void uiWindowSetBorderless(IntPtr w, bool borderless);
        [NativeCall] public static partial void uiWindowSetChild(IntPtr w, IntPtr child);
        [NativeCall] public static partial int uiWindowMargined(IntPtr w);
        [NativeCall] public static partial void uiWindowSetMargined(IntPtr w, bool margined);
        [NativeCall] public static partial IntPtr uiNewWindow(byte* title, int width, int height, bool hasMenubar);
        
        /*
        [NativeCall] public static partial byte* uiButtonText(IntPtr b);
        [NativeCall] public static partial void uiButtonSetText(IntPtr b, byte* text);
        [NativeCall] public static partial void uiButtonOnClicked(IntPtr b, delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void> f, IntPtr data);
        [NativeCall] public static partial IntPtr uiNewButton(byte* text);
        
        [NativeCall] public static partial void uiBoxAppend(IntPtr b, IntPtr child, int stretches);
        [NativeCall] public static partial int uiBoxDelete(IntPtr b, int index);
        [NativeCall] public static partial void uiBoxPadded(IntPtr b);
        [NativeCall] public static partial IntPtr uiBoxSetPadded(IntPtr b, int padded);
        [NativeCall] public static partial IntPtr uiNewHorizontalBox();
        [NativeCall] public static partial IntPtr uiNewVerticalBox();

        [NativeCall] public static partial byte* uiCheckboxText(IntPtr c);
        [NativeCall] public static partial void uiCheckboxSetText(IntPtr c, byte* text);
        [NativeCall] public static partial void uiCheckboxOnToggle(byte* text);
        [NativeCall] public static partial bool uiCheckboxChecked(IntPtr c);
        [NativeCall] public static partial void uiCheckboxSetChecked(IntPtr c, bool @checked);
        [NativeCall] public static partial IntPtr uiNewCheckbox(byte* text);

        [NativeCall] public static partial byte* uiEntryText(IntPtr e);
        [NativeCall] public static partial void uiEntrySetText(IntPtr e, byte* text);
        [NativeCall] public static partial void uiEntryOnChanged(IntPtr e, delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void> f, IntPtr data);
        [NativeCall] public static partial bool uiEntryReadOnly(IntPtr e);
        [NativeCall] public static partial void uiEntrySetReadOnly(IntPtr e, bool @readonly);
        [NativeCall] public static partial IntPtr uiNewEntry();
        [NativeCall] public static partial IntPtr uiNewPasswordEntry();
        [NativeCall] public static partial IntPtr uiNewSearchEntry();

        [NativeCall] public static partial byte* uiLabelText(IntPtr l);
        [NativeCall] public static partial void uiLabelSetText(IntPtr l, byte* text);
        [NativeCall] public static partial IntPtr uiNewLabel(byte* text);
        */
    }
}