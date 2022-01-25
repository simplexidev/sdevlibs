/***********************************************************************************************************************
 * FileName:            Window.cs
 * Copyright/License:   https://github.com/simplexidev/sdfx/blob/main/LICENSE.md
***********************************************************************************************************************/

using SimplexiDev.Internal;
using SimplexiDev.Native;

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SimplexiDev.UI
{
    /// <summary>
    /// Represents a window that makes up an application's user interface.
    /// </summary>
    public unsafe class Window : Control
    {
        private string title;
        private (int, int) contentSize;
        private bool fullscreen, borderless, margined, hasMenu;
        private Control child;

        /// <summary>
        /// Initializes a new instance of the <see cref="Window"/> class.
        /// </summary>
        /// <param name="title">The title to be displayed at the top of the window.</param>
        /// <param name="hasMenu">Whether this form has a menu at the top or not.</param>
        public Window(bool hasMenu = false) : this("Window", 600, 400, hasMenu) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Window"/> class.
        /// </summary>
        /// <param name="title">The title to be displayed at the top of the window.</param>
        /// <param name="hasMenu">Whether this form has a menu at the top or not.</param>
        public Window(string title, bool hasMenu = false) : this(title, 600, 400, hasMenu) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Window"/> class.
        /// </summary>
        /// <param name="title">The title to be displayed at the top of the window.</param>
        /// <param name="width">The width of the content size.</param>
        /// <param name="height">The height of the content size.</param>
        /// <param name="hasMenu">Whether this form has a menu at the top or not.</param>
        public Window(string title, int width, int height, bool hasMenu = false) : base(title, width, height, hasMenu) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Window"/> class.
        /// </summary>
        /// <param name="title">The title to be displayed at the top of the window.</param>
        /// <param name="contentSize">The content size of the window.</param>
        /// <param name="hasMenu">Whether this form has a menu at the top or not.</param>
        public Window(string title, (int, int) contentSize, bool hasMenu = false) : this(title, contentSize.Item1, contentSize.Item2, hasMenu) { }

        /// <summary>
        /// Occurs when the window is closing.
        /// </summary>
        public event EventHandler<Window, CancelEventArgs> Closing;

        /// <summary>
        /// Occurs when the content size of the window changes.
        /// </summary>
        public event EventHandler<Window, EventArgs> SizeChanged;

        public bool HasMenu => hasMenu;

        /// <summary>
        /// Gets or sets the title of the window.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the content size of the window.
        /// </summary>
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

        /// <summary>
        /// Gets or sets a value determining whether the window is fullscreen or not.
        /// </summary>
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

        /// <summary>
        /// Gets or sets a value determining whether or nor the window is borderless.
        /// </summary>
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

        /// <summary>
        /// Gets or sets a value determining whether or nor the window is margined.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the child control for this window.
        /// </summary>
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

        /// <summary>
        /// Closes and diposes the window.
        /// </summary>
        public void Close()
        {
            Hide();
            Dispose();
        }

        /// <inheritdoc/>
        protected override void StartInitialization(params object[] args)
        {
            base.StartInitialization(args);
            title = (string)args[0];
            contentSize = ((int)args[1], (int)args[2]);
            hasMenu = (bool)args[3];
        }

        /// <inheritdoc/>
        protected override void CreateHandle(params object[] args)
        {
            ArgumentNullException.ThrowIfNull(args);
            Handle = Libui.uiNewWindow(Utf8Helper.GetUtf8Pointer((string)args[0]), (int)args[1], (int)args[2], (bool)args[3]);
            base.CreateHandle(args);
        }

        /// <inheritdoc/>
        protected override void EndInitialization()
        {
            if (Handle == IntPtr.Zero)
                throw new TypeInitializationException(nameof(Window), new InvalidComObjectException());

            Libui.uiWindowOnClosing(Handle, &OnClosingFunc, IntPtr.Zero);
            Libui.uiWindowOnContentSizeChanged(Handle, &OnSizeChangedFunc, IntPtr.Zero);
        }

        /// <inheritdoc/>
        protected override void DestroyHandle()
        {
            if (child != null)
            {
                child.Dispose();
                child = null;
            }
            base.DestroyHandle();
        }

        /// <summary>
        /// Raises the <see cref="Closing"/> event.
        /// </summary>
        /// <param name="e">The event data.</param>
        protected internal virtual void OnClosing(CancelEventArgs e) => Closing?.Invoke(this, e);

        /// <summary>
        /// Raises the <see cref="SizeChanged"/> event.
        /// </summary>
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
                    Application.Shutdown();
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