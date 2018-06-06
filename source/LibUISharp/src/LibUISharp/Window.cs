using LibUISharp.Drawing;
using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using static LibUISharp.Native.NativeMethods;

namespace LibUISharp
{
    /// <summary>
    /// Represents a window that makes up an application's user interface.
    /// </summary>
    public class Window : Control
    {
        private Control child;
        private bool isMargined, fullscreen, borderless;
        private Size size;
        private string title;
        private bool disposed = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="Window"/> class, with the options of specifying
        /// the window's width, height, title, and whether or not it has a <see cref="Menu"/>.
        /// </summary>
        /// <param name="title">The title at the top of the window.</param>
        /// <param name="width">The width of the window.</param>
        /// <param name="height">The height of the window.</param>
        /// <param name="hasMenu">Whether or not the window will have a menu.</param>
        public Window(string title = "", int width = 600, int height = 400, bool hasMenu = false)
        {
            Handle = Libui.uiNewWindow(title, width, height, hasMenu);

            this.title = title;
            Console.Title = title;
            size = new Size(width, height);
            HasMenu = hasMenu;

            InitializeEvents();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Window"/> class, with the options of specifying
        /// the window's size, title, and whether or not it has a <see cref="Menu"/>.
        /// </summary>
        /// <param name="title">The title at the top of the window.</param>
        /// <param name="size">The size of the window.</param>
        /// <param name="hasMenu">Whether or not the window will have a menu.</param>
        public Window(string title, Size size, bool hasMenu = false) : this(title, size.Width, size.Height, hasMenu) { }

        /// <summary>
        /// Occurs when the window is closing.
        /// </summary>
        public EventHandler<CancelEventArgs> WindowClosing;

        /// <summary>
        /// Occurs when the <see cref="Size"/> property value changes.
        /// </summary>
        public EventHandler SizeChanged;

        /// <summary>
        /// Gets whether or not this window has a menu.
        /// </summary>
        public bool HasMenu { get; }

        /// <summary>
        /// Gets or sets the title of this window.
        /// </summary>
        public string Title
        {
            get => title = Libui.uiWindowTitle(this);
            set
            {
                if (title != value)
                {
                    Libui.uiWindowSetTitle(this, value);
                    title = value;
                    Console.Title = title;
                }
            }
        }

        /// <summary>
        /// Gets or sets the content size of this window.
        /// </summary>
        public Size Size
        {
            get
            {
                Libui.uiWindowContentSize(this, out int w, out int h);
                size = new Size(w, h);
                return size;
            }
            set
            {
                if (size != value)
                {
                    Libui.uiWindowSetContentSize(this, value.Width, value.Height);
                    size = value;
                }
            }
        }

        /// <summary>
        /// Gets the content width of this window.
        /// </summary>
        public int Width => Size.Width;

        /// <summary>
        /// Gets the content height of this window.
        /// </summary>
        public int Height => Size.Height;

        /// <summary>
        /// Gets or sets whether or not this window fills the entire screen.
        /// </summary>
        public bool Fullscreen
        {
            get
            {
                fullscreen = Libui.uiWindowFullscreen(this);
                return fullscreen;
            }
            set
            {
                if (fullscreen != value)
                {
                    Libui.uiWindowSetFullscreen(this, value);
                    fullscreen = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets whether or not this window has borders.
        /// </summary>
        public bool Borderless
        {
            get
            {
                borderless = Libui.uiWindowBorderless(this);
                return borderless;
            }
            set
            {
                if (borderless != value)
                {
                    Libui.uiWindowSetBorderless(this, value);
                    borderless = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the child <see cref="Control"/> of this window.
        /// </summary>
        public Control Child
        {
            get => child;
            set
            {
                if (Handle != IntPtr.Zero)
                {
                    if (value == null) throw new UIException("Cannot add a null Control to a Window.");
                    Libui.uiWindowSetChild(this, value);
                    child = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets whether this window has margins between its child control and its border.
        /// </summary>
        public bool IsMargined
        {
            get
            {
                isMargined = Libui.uiWindowMargined(this);
                return isMargined;
            }
            set
            {
                if (isMargined != value)
                {
                    Libui.uiWindowSetMargined(this, value);
                    isMargined = value;
                }
            }
        }

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

        /// <summary>
        /// Closes the window.
        /// </summary>
        public void Close()
        {
            Hide();
            Dispose();
        }

        /// <summary>
        /// Raises the <see cref="WindowClosing"/> event.
        /// </summary>
        /// <param name="e">A <see cref="CancelEventArgs"/> containing the event data.</param>
        protected virtual void OnWindowClosing(CancelEventArgs e) => WindowClosing?.Invoke(this, e);

        /// <summary>
        /// Raises the <see cref="SizeChanged"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> containing the event data.</param>
        protected virtual void OnSizeChanged(EventArgs e) => SizeChanged?.Invoke(this, e);

        /// <summary>
        /// Initializes this UI component's events.
        /// </summary>
        protected sealed override void InitializeEvents()
        {
            if (Handle == IntPtr.Zero)
                throw new TypeInitializationException(nameof(Window), new InvalidComObjectException());

            Libui.uiWindowOnClosing(this, (window, data) =>
            {
                CancelEventArgs args = new CancelEventArgs();
                OnWindowClosing(args);
                bool cancel = args.Cancel;
                if (!cancel)
                {
                    if (this != Application.MainWindow)
                        Close();
                    else
                        Application.Current.Shutdown();
                }
                return !cancel;
            }, IntPtr.Zero);

            Libui.uiWindowOnContentSizeChanged(this, (window, data) => { OnSizeChanged(EventArgs.Empty); }, IntPtr.Zero);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <param name="disposing">Whether or not this control is disposing.</param>
        protected sealed override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (child != null)
                    {
                        child.Dispose();
                        child = null;
                    }
                }
                disposed = true;
                base.Dispose(disposing);
            }
        }
    }
}