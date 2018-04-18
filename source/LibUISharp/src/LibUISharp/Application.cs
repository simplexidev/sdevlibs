using LibUISharp.Native;
using LibUISharp.Native.Libraries;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace LibUISharp
{
    /// <summary>
    /// Enacpsulates a LibUISharp (libui) application.
    /// </summary>
    public sealed class Application : LibuiComponent
    {
        private static object _lock = new object();
        private static bool created;
        private static LibuiLibrary.uiInitOptions Options = new LibuiLibrary.uiInitOptions() { Size = UIntPtr.Zero };
        private int exitCode;
        private bool disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="Application"/> class.
        /// </summary>
        public Application()
        {
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
        /// Starts a LibUIShatrp (libui) application and opens the specified window.
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

        #region LibuiComponent Implementation
        /// <inheritdoc />
        protected sealed override void InitializeComponent()
        {
            if (PlatformHelper.IsWinNT)
            {
                IntPtr ptr = Kernel32Library.GetConsoleWindow();
                User32Library.ShowWindow(ptr, 0); // 0 = SW_HIDE, 4 = SW_SHOWNOACTIVATE
            }

            IntPtr errPtr = LibuiLibrary.uiInit(ref Options);
            string errStr = LibuiConvert.ToString(errPtr);

            if (string.IsNullOrEmpty(errStr))
            {
                Console.WriteLine(errStr);
                LibuiLibrary.uiFreeInitError(errPtr);
                throw new LibuiException(errStr);
            }
        }

        /// <inheritdoc />
        protected sealed override void InitializeEvents() => LibuiLibrary.uiOnShouldQuit(data =>
            {
                CancelEventArgs args = new CancelEventArgs();
                Exiting?.Invoke(this, args);
                return !args.Cancel;
            }, IntPtr.Zero);

        /// <inheritdoc />
        public override void Dispose() => Dispose(true);

        /// <inheritdoc />
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (!disposed)
                    LibuiLibrary.uiUnInit();
                disposed = true;
            }
        }
        #endregion
    }
}