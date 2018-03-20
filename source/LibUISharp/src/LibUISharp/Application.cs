using System;
using System.ComponentModel;
using LibUISharp.Controls;
using LibUISharp.Internal;

namespace LibUISharp
{
    public sealed class Application : IDisposable
    {
        private static object _lock = new object();
        private static bool created;
        private static LibUI.InitOptions Options = new LibUI.InitOptions(UIntPtr.Zero);
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
                LibUI.Main();
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
                LibUI.QueueMain(data => { action?.Invoke(); });
            }
        }

        private void Steps() => LibUI.MainSteps();

        private bool Step(bool wait) => LibUI.MainStep(wait);

        public void Dispose() => LibUI.UnInitialize();

        public void Exit() => LibUI.Exit();

        private void InitializeComponent()
        {
            LibUI.ConsoleWindow(false);
            LibUI.Initialize(ref Options);
        }

        private void InitializeEvents() =>
            LibUI.OnExit(data =>
            {
                CancelEventArgs args = new CancelEventArgs();
                OnExit?.Invoke(this, args);
                return !args.Cancel;
            });
    }
}