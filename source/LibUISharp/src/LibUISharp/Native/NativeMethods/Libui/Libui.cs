using System;
using System.Runtime.InteropServices;

namespace LibUISharp.Native
{
    internal static partial class NativeMethods
    {
        internal static partial class Libui
        {
            private const CallingConvention Convention = CallingConvention.Cdecl;
            private const LayoutKind Layout = LayoutKind.Sequential;

            // _UI_EXTERN const char *uiInit(uiInitOptions *options);
            [UnmanagedFunctionPointer(Convention)]
            private delegate string uiInit_t(ref StartupOptions options);
            internal static string uiInit(ref StartupOptions options) => FunctionLoader.LoadLibuiFunc<uiInit_t>("uiInit")(ref options);

            // _UI_EXTERN void uiUninit(void);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiUnInit_t();
            internal static void uiUnInit() => FunctionLoader.LoadLibuiFunc<uiUnInit_t>("uiUnInit")();

            // _UI_EXTERN void uiFreeInitError(const char *err);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiFreeInitError_t(string err);
            internal static void uiFreeInitError(string err) => FunctionLoader.LoadLibuiFunc<uiFreeInitError_t>("uiFreeInitError")(err);

            // _UI_EXTERN void uiMain(void);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiMain_t();
            internal static void uiMain() => FunctionLoader.LoadLibuiFunc<uiMain_t>("uiMain")();

            // _UI_EXTERN void uiMainSteps(void);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiMainSteps_t();
            internal static void uiMainSteps() => FunctionLoader.LoadLibuiFunc<uiMainSteps_t>("uiMainSteps")();

            // _UI_EXTERN int uiMainStep(int wait);
            [UnmanagedFunctionPointer(Convention)]
            private delegate bool uiMainStep_t(bool wait);
            internal static bool uiMainStep(bool wait) => FunctionLoader.LoadLibuiFunc<uiMainStep_t>("uiMainStep")(wait);

            // _UI_EXTERN void uiQuit(void);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiQuit_t();
            internal static void uiQuit() => FunctionLoader.LoadLibuiFunc<uiQuit_t>("uiQuit")();

            // _UI_EXTERN void uiQueueMain(void (*f)(void *data), void *data);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiQueueMain_t(uiQueueMain_tf f, IntPtr data);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate void uiQueueMain_tf(IntPtr data);
            internal static void uiQueueMain(uiQueueMain_tf f, IntPtr data) => FunctionLoader.LoadLibuiFunc<uiQueueMain_t>("uiQueueMain")(f, data);

            //TODO: Implement this.
            // _UI_EXTERN void uiTimer(int milliseconds, int (*f)(void *data), void *data);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiTimer_t(int milliseconds, uiTimer_tf f, IntPtr data);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate bool uiTimer_tf(IntPtr data);
            internal static void uiTimer(int milliseconds, uiTimer_tf f, IntPtr data) => FunctionLoader.LoadLibuiFunc<uiTimer_t>("uiTimer")(milliseconds, f, data);

            // _UI_EXTERN void uiOnShouldQuit(int (*f)(void *data), void *data);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiOnShouldQuit_t(uiOnShouldQuit_tf f, IntPtr data);
            [UnmanagedFunctionPointer(Convention)]
            internal delegate bool uiOnShouldQuit_tf(IntPtr data);
            internal static void uiOnShouldQuit(uiOnShouldQuit_tf f, IntPtr data) => FunctionLoader.LoadLibuiFunc<uiOnShouldQuit_t>("uiOnShouldQuit")(f, data);

            // _UI_EXTERN void uiFreeText(char *text);
            [UnmanagedFunctionPointer(Convention)]
            private delegate void uiFreeText_t(string text);
            internal static void uiFreeText(string text) => FunctionLoader.LoadLibuiFunc<uiFreeText_t>("uiFreeText")(text);
        }
    }
}