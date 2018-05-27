using LibUISharp.Internal;
using System;
using System.ComponentModel;
using System.Text;

namespace LibUISharp
{
    /// <summary>
    /// Enacpsulates an application with a user-interface.
    /// </summary>
    public sealed class Application : UIComponent, IUIComponent
    {
        private static object _lock = new object();
        private static bool created = false;
        private static LibuiLibrary.uiInitOptions Options = new LibuiLibrary.uiInitOptions() { Size = UIntPtr.Zero };
        private int exitCode;
        private bool disposed = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="Application"/> class.
        /// </summary>
        public Application()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            lock (_lock)
            {
                if (created)
                    throw new InvalidOperationException("Cannot create more than one Application.");
                Current = this;
                created = true;
                InitializeComponent();
                InitializeEvents();
            }
        }

        /// <summary>
        /// Occurs just before an application shuts down.
        /// </summary>
        public event EventHandler<CancelEventArgs> Exiting;

        /// <summary>
        /// Gets the current instance of this <see cref="Application"/>.
        /// </summary>
        public static Application Current { get; private set; }

        internal static Window MainWindow { get; private set; }

        /// <summary>
        /// Sets this <see cref="Application"/>'s exit code.
        /// </summary>
        public int ExitCode
        {
            set
            {
                if (value != exitCode)
                    exitCode = value;
            }
        }

        /// <summary>
        /// Starts an application with a user-interface and opens the specified window.
        /// </summary>
        /// <param name="window">The specified window to open.</param>
        /// <returns>0 if successful, else returns -1.</returns>
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
                LibuiLibrary.uiMain();
            }
            catch (Exception)
            {
                return -1;
            }
            return 0;
        }

        /// <summary>
        /// Queues the specified action to run when possible on the UI thread.
        /// </summary>
        /// <param name="action">The <see cref="Action"/> to run.</param>
        public static void QueueMain(Action action)
        {
            lock (_lock)
            {
                LibuiLibrary.uiQueueMain(data => { action?.Invoke(); }, IntPtr.Zero);
            }
        }

        private void Steps() => LibuiLibrary.uiMainSteps();

        private bool Step(bool wait) => LibuiLibrary.uiMainStep(wait);

        /// <summary>
        /// Shut down this application.
        /// </summary>
        public void Shutdown() => LibuiLibrary.uiQuit();

        /// <summary>
        /// Initializes this UI component.
        /// </summary>
        protected sealed override void InitializeComponent()
        {
            IntPtr errPtr = LibuiLibrary.uiInit(ref Options);
            string errStr = errPtr.ToStringEx();

            if (!string.IsNullOrEmpty(errStr))
            {
                Console.WriteLine(errStr);
                LibuiLibrary.uiFreeInitError(errPtr);
                throw new UIException(errStr);
            }

            if (PlatformHelper.IsWinNT)
            {
                IntPtr ptr = Kernel32Library.GetConsoleWindow();
                User32Library.ShowWindow(ptr, 0); // 0 = SW_HIDE, 4 = SW_SHOWNOACTIVATE
            }
        }

        /// <summary>
        /// Initializes this UI component's events.
        /// </summary>
        protected sealed override void InitializeEvents() => LibuiLibrary.uiOnShouldQuit(data =>
            {
                CancelEventArgs args = new CancelEventArgs();
                Exiting?.Invoke(this, args);
                return !args.Cancel;
            }, IntPtr.Zero);
        
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <param name="disposing">Whether or not this control is disposing.</param>
        internal void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (!disposed)
                    LibuiLibrary.uiUnInit();
                disposed = true;
            }
        }
    }
}