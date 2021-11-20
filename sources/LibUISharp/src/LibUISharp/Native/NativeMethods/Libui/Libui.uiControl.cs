using System;
using System.Runtime.InteropServices;

namespace LibUISharp.Native
{
    internal static partial class NativeMethods
    {
        internal static partial class Libui
        {
            // _UI_EXTERN void uiControlDestroy(uiControl *);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiControlDestroy_t(IntPtr c);
            public static void uiControlDestroy(IntPtr c) => FunctionLoader.LoadLibuiFunc<uiControlDestroy_t>("uiControlDestroy")(c);

            // _UI_EXTERN uintptr_t uiControlHandle(uiControl *);
            [UnmanagedFunctionPointer(Convention)]
            private delegate UIntPtr uiControlHandle_t(IntPtr c);
            public static UIntPtr uiControlHandle(IntPtr c) => FunctionLoader.LoadLibuiFunc<uiControlHandle_t>("uiControlHandle")(c);

            // _UI_EXTERN uiControl *uiControlParent(uiControl *);
            [UnmanagedFunctionPointer(Convention)]
            private delegate IntPtr uiControlParent_t(IntPtr c);
            public static IntPtr uiControlParent(IntPtr c) => FunctionLoader.LoadLibuiFunc<uiControlParent_t>("uiControlParent")(c);

            // _UI_EXTERN void uiControlSetParent(uiControl *, uiControl *);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiControlSetParent_t(IntPtr c, IntPtr parent);
            public static void uiControlSetParent(IntPtr c, IntPtr parent) => FunctionLoader.LoadLibuiFunc<uiControlSetParent_t>("uiControlSetParent")(c, parent);

            // _UI_EXTERN int uiControlToplevel(uiControl *);
            [UnmanagedFunctionPointer(Convention)]
            private delegate bool uiControlToplevel_t(IntPtr c);
            public static bool uiControlToplevel(IntPtr c) => FunctionLoader.LoadLibuiFunc<uiControlToplevel_t>("uiControlToplevel")(c);

            // _UI_EXTERN int uiControlVisible(uiControl *);
            [UnmanagedFunctionPointer(Convention)]
            private delegate bool uiControlVisible_t(IntPtr c);
            public static bool uiControlVisible(IntPtr c) => FunctionLoader.LoadLibuiFunc<uiControlVisible_t>("uiControlVisible")(c);

            // _UI_EXTERN void uiControlShow(uiControl *);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiControlShow_t(IntPtr c);
            public static void uiControlShow(IntPtr c) => FunctionLoader.LoadLibuiFunc<uiControlShow_t>("uiControlShow")(c);

            // _UI_EXTERN void uiControlHide(uiControl *);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiControlHide_t(IntPtr c);
            public static void uiControlHide(IntPtr c) => FunctionLoader.LoadLibuiFunc<uiControlHide_t>("uiControlHide")(c);

            // _UI_EXTERN int uiControlEnabled(uiControl *);
            [UnmanagedFunctionPointer(Convention)]
            private delegate bool uiControlEnabled_t(IntPtr c);
            public static bool uiControlEnabled(IntPtr c) => FunctionLoader.LoadLibuiFunc<uiControlEnabled_t>("uiControlEnabled")(c);

            // _UI_EXTERN void uiControlEnable(uiControl *);
            [UnmanagedFunctionPointer(Convention)]
            private delegate bool uiControlEnable_t(IntPtr c);
            public static void uiControlEnable(IntPtr c) => FunctionLoader.LoadLibuiFunc<uiControlEnable_t>("uiControlEnable")(c);

            // _UI_EXTERN void uiControlDisable(uiControl *);
            [UnmanagedFunctionPointer(Convention)]
            private delegate bool uiControlDisable_t(IntPtr c);
            public static void uiControlDisable(IntPtr c) => FunctionLoader.LoadLibuiFunc<uiControlDisable_t>("uiControlDisable")(c);

            //// _UI_EXTERN uiControl *uiAllocControl(size_t n, uint32_t OSsig, uint32_t typesig, const char *typenamestr);
            //// _UI_EXTERN void uiFreeControl(uiControl *);

            //TODO: Implement this.
            // _UI_EXTERN int uiControlEnabledToUser(uiControl *);
            [UnmanagedFunctionPointer(Convention)]
            private delegate bool uiControlEnabledToUser_t(IntPtr c);
            public static bool uiControlEnabledToUser(IntPtr c) => FunctionLoader.LoadLibuiFunc<uiControlEnabledToUser_t>("uiControlEnabledToUser")(c);

            //TODO: Implement this.
            // _UI_EXTERN void uiControlVerifySetParent(uiControl *, uiControl *);
            [UnmanagedFunctionPointer(Convention)]
            private delegate bool uiControlVerifySetParent_t(IntPtr c, IntPtr parent);
            public static void uiControlVerifySetParent(IntPtr c, IntPtr parent) => FunctionLoader.LoadLibuiFunc<uiControlVerifySetParent_t>("uiControlVerifySetParent")(c, parent);

            //// _UI_EXTERN void uiUserBugCannotSetParentOnToplevel(const char *type);
        }
    }
}