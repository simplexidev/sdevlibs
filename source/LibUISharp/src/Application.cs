using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using LibUISharp.Internal;

using static LibUISharp.Internal.UI;

namespace LibUISharp
{
    public class Application : IDisposable
    {
        private static Application instance;
        private static object _lock = new object();
        private static bool appCreated;

        public static Window MainWindow { get; set; }
        public static Application Current => instance;

        public event EventHandler<CancelEventArgs> OnShouldQuit;

        private void Initialize()
        {
            // Hide the console window on Windows.
            if (PlatformHelper.IsWindows) ShowWindow(GetConsoleWindow(), 0);

            uiInitOptions options = new uiInitOptions { Size = UIntPtr.Zero };
            IntPtr errPtr = uiInit(ref options);
            string errStr = MarshalHelper.StringFromUTF8(errPtr);
            if (!string.IsNullOrEmpty(errStr))
            {
                Console.WriteLine(errStr);
                uiFreeInitError(errPtr);
                throw new ExternalException(errStr);
            }

            uiOnShouldQuit(data =>
            {
                CancelEventArgs args = new CancelEventArgs();
                OnShouldQuit?.Invoke(this, args);
                return !args.Cancel;
            }, IntPtr.Zero);
        }

        public int Run(Window window)
        {
            MainWindow = window;
            return Run(() => { window.Show(); });
        }

        protected int Run(Action action)
        {
            try
            {
                QueueMain(action);
                uiMain();
            } catch (Exception) { return -1; }
            return 0;
        }

        public static void QueueMain(Action action)
        {
            lock (_lock)
                uiQueueMain(data => { action?.Invoke(); }, IntPtr.Zero);
        }

        private void Steps() => uiMainSteps();

        private bool Step(bool wait) => uiMainStep(wait);

        public void Dispose() => uiUnInit();

        public void Quit() => uiQuit();
    }
}