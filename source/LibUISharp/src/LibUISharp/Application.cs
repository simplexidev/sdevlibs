using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using LibUISharp.Internal;
using LibUISharp.SafeHandles;

namespace LibUISharp
{
    /// <summary>
    /// Encapsulates an application with a user-interface.
    /// </summary>
    public sealed class Application : UIComponent
    {
        private static object _lock = new object();
        private static bool initialized = false;
        private static StartupOptions Options = new StartupOptions();
        private static readonly Queue<Action> queue = new Queue<Action>();
        private bool disposed = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="Application"/> class.
        /// </summary>
        public Application()
        {
            lock (_lock)
            {
                if (initialized)
                    throw new InvalidOperationException("You cannot have more than one instance of the Application class at once.");
                Current = this;
                initialized = true;
                InitializeComponent();
                InitializeEvents();
            }
        }

        /// <summary>
        /// Occurs just before an application shuts down.
        /// </summary>
        public event Func<bool, bool> Exiting;

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
            if (window.IsInvalid) throw new UIComponentInvalidHandleException<SafeControlHandle>(window);
            MainWindow = window;
            return Run(() => { window.Show(); });
        }

        private int Run(Action action)
        {
            try
            {
                QueueMain(action);
                NativeCalls.Main();
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
            queue.Enqueue(action);
            NativeCalls.QueueMain(data =>
            {
                lock (_lock)
                {
                    Action a = queue.Dequeue();
                    a.Invoke();
                }
            }, new IntPtr(queue.Count));
        }

        private void Steps() => NativeCalls.MainSteps();

        private bool Step(bool wait) => NativeCalls.MainStep(wait);

        /// <summary>
        /// Shuts down this application.
        /// </summary>
        public void Shutdown() => NativeCalls.Quit();

        /// <summary>
        /// Initializes this UI component.
        /// </summary>
        protected sealed override void InitializeComponent()
        {
            string error = NativeCalls.Init(ref Options);

            if (!string.IsNullOrEmpty(error))
            {
                Console.WriteLine(error);
                NativeCalls.FreeInitError(error);
                throw new UIException(error);
            }
        }

        /// <summary>
        /// Initializes this UI component's events.
        /// </summary>
        protected sealed override void InitializeEvents() => NativeCalls.OnShouldQuit(data => { return Exiting.Invoke(true); }, IntPtr.Zero);

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <param name="disposing">Whether or not this <see cref="Application"/> is disposing.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing)
            {
                if (initialized)
                    NativeCalls.UnInit();
            }
            disposed = true;
            base.Dispose(disposing);
        }
    }

    [NativeType("uiInitOptions")]
    [StructLayout(LayoutKind.Sequential)]
    internal class StartupOptions : IEquatable<StartupOptions>
    {
        private UIntPtr size;

        public StartupOptions() : this(0) { }
        public StartupOptions(uint size) => Size = size;
        public StartupOptions(UIntPtr size) => this.size = size;

        public uint Size
        {
            get => (uint)size;
            private set => size = new UIntPtr(value);
        }

        public bool Equals(StartupOptions options) => size == options.size;

        public override bool Equals(object obj) => (obj is StartupOptions) && Equals((StartupOptions)obj);

        public override int GetHashCode() => unchecked(HashHelper.GenerateHash(size));

        public override string ToString() => size.ToString();
    }
}