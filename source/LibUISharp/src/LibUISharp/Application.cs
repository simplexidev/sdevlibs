using System;
using System.ComponentModel;

using static LibUISharp.Internal.LibUI;

namespace LibUISharp
{
    public sealed class Application : IDisposable
    {
        private static object _lock = new object();
        private static bool created;
        private static uiInitOptions Options = new uiInitOptions(UIntPtr.Zero);
        private int exitCode;

        public Application()
        {
            lock (_lock)
            {
                if (created)
                    throw new InvalidOperationException("Cannot create more than one Application everytime.");
                Current = this;
                created = true;
                InitializeComponent();
                InitializeEvents();
            }
        }

        public event EventHandler<CancelEventArgs> OnExit;

        public static Application Current { get; private set; }

        internal static Window MainWindow { get; private set; }

        public int ExitCode
        {
            set
            {
                if (value != exitCode)
                    exitCode = value;
            }
        }

        public int Run(Window window)
        {
            MainWindow = window;
            return Run(() => { window.Show(); });
        }

        private int Run(Action action)
        {
            try
            {
                QueueMain(action);
                uiMain();
            }
            catch (Exception)
            {
                return -1;
            }
            return 0;
        }

        public static void QueueMain(Action action)
        {
            lock (_lock)
            {
                uiQueueMain(data => { action?.Invoke(); });
            }
        }

        private void Steps() => uiMainSteps();

        private bool Step(bool wait) => uiMainStep(wait);

        public void Dispose() => uiUnInit();

        public void Exit() => uiQuit();

        private void InitializeComponent()
        {
#if WINDOWS
            WindowsNT.ConsoleWindow(false);
#endif
            uiInit(ref Options);
        }

        private void InitializeEvents() =>
            uiOnShouldQuit(data =>
            {
                CancelEventArgs args = new CancelEventArgs();
                OnExit?.Invoke(this, args);
                return !args.Cancel;
            });
    }
}