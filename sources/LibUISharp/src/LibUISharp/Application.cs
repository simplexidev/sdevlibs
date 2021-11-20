using LibUISharp.Native;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using static LibUISharp.Native.NativeMethods;

namespace LibUISharp
{
    /// <summary>
    /// Enacpsulates an application with a user-interface.
    /// </summary>
    public sealed class Application : UIComponent
    {
        private static object _lock = new object();
        private static bool created = false;
        private static Libui.uiInitOptions Options = new Libui.uiInitOptions() { Size = UIntPtr.Zero };
        private bool disposed = false;
        private static readonly Queue<Action> queue = new Queue<Action>();

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
                Libui.uiMain();
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
            /*lock (_lock)
            {
                Libui.uiQueueMain(data => { action?.Invoke(); }, IntPtr.Zero);
            }*/
            queue.Enqueue(action);
            Libui.uiQueueMain(data =>
            {
                lock (_lock)
                {
                    Action a = queue.Dequeue();
                    a.Invoke();
                }
            }, new IntPtr(queue.Count));
        }

        private void Steps() => Libui.uiMainSteps();

        private bool Step(bool wait) => Libui.uiMainStep(wait);

        /// <summary>
        /// Shut down this application.
        /// </summary>
        public void Shutdown() => Libui.uiQuit();

        /// <summary>
        /// Initializes this UI component.
        /// </summary>
        protected sealed override void InitializeComponent()
        {
            string error = Libui.uiInit(ref Options);

            if (!string.IsNullOrEmpty(error))
            {
                Console.WriteLine(error);
                Libui.uiFreeInitError(error);
                throw new UIException(error);
            }

            // This must be possible on Linux and macOS.
#if !DEBUG
            if (PlatformHelper.IsWinNT)
            {
                IntPtr ptr = WinAPI.GetConsoleWindow();
                WinAPI.ShowWindow(ptr, 0); // 0 = SW_HIDE, 4 = SW_SHOWNOACTIVATE
            }
#endif
        }

        /// <summary>
        /// Initializes this UI component's events.
        /// </summary>
        protected sealed override void InitializeEvents() => Libui.uiOnShouldQuit(data =>
            {
                CancelEventArgs args = new CancelEventArgs();
                Exiting?.Invoke(this, args);
                return !args.Cancel;
            }, IntPtr.Zero);

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <param name="disposing">Whether or not this control is disposing.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (!disposed)
                    Libui.uiUnInit();
                disposed = true;
                base.Dispose(disposing);
            }
        }
    }
}