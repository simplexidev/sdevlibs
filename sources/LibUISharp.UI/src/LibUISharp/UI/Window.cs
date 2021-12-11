using LibUISharp.Internal;
using LibUISharp.Native;

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace LibUISharp.UI
{
    public unsafe class Window : Control
    {
        private string title;
        private (int, int) contentSize;
        private bool fullscreen, borderless, margined, hasMenu;
        private Control child;

        public Window(string title, bool hasMenu = false) : this(title, 600, 400, hasMenu) { }
        public Window(string title, int width, int height, bool hasMenu = false) : base(title, width, height, hasMenu) { }
        public Window(string title, (int, int) contentSize, bool hasMenu = false) : this(title, contentSize.Item1, contentSize.Item2, hasMenu) { }

        public event EventHandler<Window, CancelEventArgs> Closing;
        public event EventHandler<Window, EventArgs> SizeChanged;

        public bool HasMenu => hasMenu;
        public string Title
        {
            get => title;
            set
            {
                ArgumentNullException.ThrowIfNull(value, nameof(value));
                if (title == value) return;
                OnPropertyChanging(nameof(Title));
                Libui.uiWindowSetTitle(Handle, Utf8Helper.GetUtf8Pointer(value));
                title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
        public (int, int) ContentSize
        {
            get => contentSize;
            set
            {
                ArgumentNullException.ThrowIfNull(value, nameof(value));
                if (contentSize == value) return;
                OnPropertyChanging(nameof(ContentSize));
                Libui.uiWindowSetContentSize(Handle, value.Item1, value.Item2);
                contentSize = value;
                OnPropertyChanged(nameof(ContentSize));
            }
        }
        public bool Fullscreen
        {
            get => fullscreen;
            set
            {
                ArgumentNullException.ThrowIfNull(value, nameof(value));
                if (fullscreen == value) return;
                OnPropertyChanging(nameof(Fullscreen));
                Libui.uiWindowSetFullscreen(Handle, value);
                fullscreen = value;
                OnPropertyChanged(nameof(Fullscreen));
            }
        }
        public bool Borderless
        {
            get => borderless;
            set
            {
                ArgumentNullException.ThrowIfNull(value, nameof(value));
                if (borderless == value) return;
                OnPropertyChanging(nameof(Borderless));
                Libui.uiWindowSetBorderless(Handle, value);
                borderless = value;
                OnPropertyChanged(nameof(Borderless));
            }
        }
        public bool Margined
        {
            get => margined;
            set
            {
                ArgumentNullException.ThrowIfNull(value, nameof(value));
                if (margined == value) return;
                OnPropertyChanging(nameof(Margined));
                Libui.uiWindowSetMargined(Handle, value);
                margined = value;
                OnPropertyChanged(nameof(Margined));
            }
        }
        public Control Child
        {
            get => child;
            set
            {
                ArgumentNullException.ThrowIfNull(value, nameof(value));
                if (child == value) return;
                OnPropertyChanging(nameof(Child));
                Libui.uiWindowSetChild(Handle, value.Handle);
                child = value;
                OnPropertyChanged(nameof(Child));
            }
        }

        public void Close()
        {
            Hide();
            Dispose();
        }

        protected override void StartInitialization(params object[] args)
        {
            base.StartInitialization(args);
            title = (string)args[0];
            contentSize = ((int)args[1], (int)args[2]);
            hasMenu = (bool)args[3];
        }
        protected override void CreateHandle(params object[] args)
        {
            ArgumentNullException.ThrowIfNull(args);
            Handle = Libui.uiNewWindow(Utf8Helper.GetUtf8Pointer((string)args[0]), (int)args[1], (int)args[2], (bool)args[3]);
            base.CreateHandle(args);
        }
        protected override void EndInitialization()
        {
            if (Handle == IntPtr.Zero)
                throw new TypeInitializationException(nameof(Window), new InvalidComObjectException());

            Libui.uiWindowOnClosing(Handle, &OnClosingFunc, IntPtr.Zero);
            Libui.uiWindowOnContentSizeChanged(Handle, &OnSizeChangedFunc, IntPtr.Zero);
        }
        protected override void DestroyHandle()
        {
            if (child != null)
            {
                child.Dispose();
                child = null;
            }
            base.DestroyHandle();
        }
        protected internal virtual void OnClosing(CancelEventArgs e) => Closing?.Invoke(this, e);
        protected internal virtual void OnSizeChanged() => SizeChanged?.Invoke(this, EventArgs.Empty);

        [UnmanagedCallersOnly(CallConvs = new Type[] { typeof(CallConvCdecl) })]
        private static bool OnClosingFunc(IntPtr window, IntPtr data)
        {
            CancelEventArgs args = new();
            ((Window)cache[window]).OnClosing(args);
            if (!args.Cancel)
            {
                if (((Window)cache[window]) != Application.MainWindow)
                    ((Window)cache[window]).Close();
                else
                    Application.Current.Shutdown();
            }
            return !args.Cancel;
        }

        [UnmanagedCallersOnly(CallConvs = new Type[] { typeof(CallConvCdecl) })]
        private static void OnSizeChangedFunc(IntPtr window) => ((Window)cache[window]).OnSizeChanged();
    }

    /*
    internal class Window_ : Control
    {
        /// <summary>
        /// Displays a dialog showing a message, or optionally, an error.
        /// </summary>
        /// <param name="title">The title of the message dialog.</param>
        /// <param name="description">The description of the message dialog.</param>
        /// <param name="isError">Whether the message is displayed as an error.</param>
        public void ShowMessageBox(string title, string description = null, bool isError = false) => ShowMessageBox(this, title, description, isError);

        /// <summary>
        /// Displays a dialog showing a message, or optionally, an error.
        /// </summary>
        /// <param name="w">The dialog's parent window.</param>
        /// <param name="title">The title of the message dialog.</param>
        /// <param name="description">The description of the message dialog.</param>
        /// <param name="isError">Whether the message is displayed as an error.</param>
        public static void ShowMessageBox(Window w, string title, string description = null, bool isError = false)
        {
            if (w == null) w = Application.MainWindow;

            if (isError)
                Libui.uiMsgBoxError(w, title, description);
            else
                Libui.uiMsgBox(w, title, description);
        }

        /// <summary>
        /// Displays a dialog allowing a user to select a file to save to.
        /// </summary>
        /// <param name="path">The file's path selected by the user to save to.</param>
        /// <returns><see langword="true"/> if the file can be saved to, else <see langword="false"/>.</returns>
        public bool ShowSaveFileDialog(out string path) => ShowSaveFileDialog(out path, this);

        /// <summary>
        /// Displays a dialog allowing a user to select a file to save to.
        /// </summary>
        /// <param name="writeStream">The file selected by the user as a writable stream.</param>
        /// <returns><see langword="true"/> if the file can be saved to, else <see langword="false"/>.</returns>
        public bool ShowSaveFileDialog(out Stream writeStream) => ShowSaveFileDialog(out writeStream, this);

        /// <summary>
        /// Displays a dialog allowing a user to select a file to save to.
        /// </summary>
        /// <param name="path">The file's path selected by the user to save to.</param>
        /// <param name="w">The dialog's parent window.</param>
        /// <returns><see langword="true"/> if the file can be saved to, else <see langword="false"/>.</returns>
        public static bool ShowSaveFileDialog(out string path, Window w)
        {
            if (w == null) w = Application.MainWindow;

            path = Libui.uiSaveFile(w);
            if (string.IsNullOrEmpty(path))
                return false;
            else
                return true;
        }

        /// <summary>
        /// Displays a dialog allowing a user to select a file to save to.
        /// </summary>
        /// <param name="writeStream">The file selected by the user as a writable stream.</param>
        /// <param name="w">The dialog's parent window.</param>
        /// <returns><see langword="true"/> if the file can be saved to, else <see langword="false"/>.</returns>
        public static bool ShowSaveFileDialog(out Stream writeStream, Window w)
        {
            if (ShowSaveFileDialog(out string path, w))
            {
                writeStream = File.OpenWrite(path);
                return true;
            }
            else
            {
                writeStream = null;
                return false;
            }
        }

        /// <summary>
        /// Displays a dialog allowing a user to select a file to open.
        /// </summary>
        /// <param name="path">The file's path selected by the user.</param>
        /// <returns><see langword="true"/> if the file exists, else <see langword="false"/>.</returns>
        public bool ShowOpenFileDialog(out string path) => ShowOpenFileDialog(out path, this);

        /// <summary>
        /// Displays a dialog allowing a user to select a file to open.
        /// </summary>
        /// <param name="readStream">The file selected by the user as a readable stream.</param>
        /// <returns><see langword="true"/> if the file exists, else <see langword="false"/>.</returns>
        public bool ShowOpenFileDialog(out Stream readStream) => ShowOpenFileDialog(out readStream, this);

        /// <summary>
        /// Displays a dialog allowing a user to select a file to open.
        /// </summary>
        /// <param name="path">The file's path selected by the user.</param>
        /// <param name="w">The dialog's parent window.</param>
        /// <returns><see langword="true"/> if the file exists, else <see langword="false"/>.</returns>
        public static bool ShowOpenFileDialog(out string path, Window w)
        {
            if (w == null) w = Application.MainWindow;

            path = Libui.uiOpenFile(w);
            if (string.IsNullOrEmpty(path))
                return false;
            else
                return true;
        }

        /// <summary>
        /// Displays a dialog allowing a user to select a file to open.
        /// </summary>
        /// <param name="readStream">The file selected by the user as a readable stream.</param>
        /// <param name="w">The dialog's parent window.</param>
        /// <returns><see langword="true"/> if the file exists, else <see langword="false"/>.</returns>
        public static bool ShowOpenFileDialog(out Stream readStream, Window w)
        {
            if (ShowOpenFileDialog(out string path, w))
            {
                readStream = File.OpenRead(path);
                return true;
            }
            else
            {
                readStream = null;
                return false;
            }
        }

    }
    */
}