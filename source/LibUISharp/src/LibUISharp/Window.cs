using LibUISharp.Drawing;
using LibUISharp.Native.Libraries;
using LibUISharp.Native.SafeHandles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

// uiWindow
namespace LibUISharp
{
    /// <summary>
    /// Represents a windiw that makes up an application's user interface.
    /// </summary>
    public class Window : Control
    {
        private Control child;
        private bool margins, fullscreen, borderless;
        private Size size;
        private string title;
        private bool disposed = false;
        private static readonly Dictionary<SafeControlHandle, Window> WindowCache = new Dictionary<SafeControlHandle, Window>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Window"/> class, with the options of specifying
        /// the window's width, height, title, and whether or not it has a <see cref="MenuBar"/>.
        /// </summary>
        /// <param name="width">The width of the window.</param>
        /// <param name="height">The height of the window.</param>
        /// <param name="title">The title at the top of the window.</param>
        /// <param name="hasMenuStrip">Whether or not the window will have a menu.</param>
        public Window(int width = 500, int height = 300, string title = null, bool hasMenuStrip = false) : base()
        {
            if (string.IsNullOrEmpty(title))
                title = "LibUISharp";

            IntPtr strPtr = LibuiLibrary.UTF8Helper.ToUTF8Ptr(title);
            Handle = new SafeControlHandle(LibuiLibrary.uiNewWindow(strPtr, width, height, hasMenuStrip));
            Marshal.FreeHGlobal(strPtr);

            WindowCache.Add(Handle, this);
            this.title = title;
            size = new Size(width, height);
            InitializeEvents();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Window"/> class, with the options of specifying
        /// the window's size, title, and whether or not it has a <see cref="MenuBar"/>.
        /// </summary>
        /// <param name="size">The size of the window.</param>
        /// <param name="title">The title at the top of the window.</param>
        /// <param name="hasMenuStrip">Whether or not the window will have a menu.</param>
        public Window(Size size, string title = null, bool hasMenuStrip = false) : this(size.Width, size.Height, title, hasMenuStrip) { }

        /// <summary>
        /// Occurs when the window is closing.
        /// </summary>
        public EventHandler<CancelEventArgs> WindowClosing;

        /// <summary>
        /// Occurs when the <see cref="Size"/> property value changes.
        /// </summary>
        public EventHandler SizeChanged;

        /// <summary>
        /// Gets or sets the title of this window.
        /// </summary>
        public string Title
        {
            get
            {
                title = LibuiLibrary.UTF8Helper.ToUTF16Str(LibuiLibrary.uiWindowTitle(Handle.DangerousGetHandle()));
                return title;
            }
            set
            {
                if (title != value)
                {
                    if (string.IsNullOrEmpty(value))
                        title = "LibUISharp";
                    else
                        title = value;

                    IntPtr strPtr = LibuiLibrary.UTF8Helper.ToUTF8Ptr(title);
                    LibuiLibrary.uiWindowSetTitle(Handle.DangerousGetHandle(), strPtr);
                    Marshal.FreeHGlobal(strPtr);
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
                LibuiLibrary.uiWindowContentSize(Handle.DangerousGetHandle(), out int w, out int h);
                size = new Size(w, h);
                return size;
            }
            set
            {
                if (size != value)
                {
                    LibuiLibrary.uiWindowSetContentSize(Handle.DangerousGetHandle(), value.Width, value.Height);
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
                fullscreen = LibuiLibrary.uiWindowFullscreen(Handle.DangerousGetHandle());
                return fullscreen;
            }
            set
            {
                if (fullscreen != value)
                {
                    LibuiLibrary.uiWindowSetFullscreen(Handle.DangerousGetHandle(), value);
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
                borderless = LibuiLibrary.uiWindowBorderless(Handle.DangerousGetHandle());
                return borderless;
            }
            set
            {
                if (borderless != value)
                {
                    LibuiLibrary.uiWindowSetBorderless(Handle.DangerousGetHandle(), value);
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
                if (!Handle.IsInvalid)
                {
                    if (value == null)
                        throw new LibuiException("Cannot add a null Control to a Window.");
                    LibuiLibrary.uiWindowSetChild(Handle.DangerousGetHandle(), value.Handle.DangerousGetHandle());
                }
                child = value;
            }
        }

        /// <summary>
        /// Gets or sets whether this window has margins between its child control and its border.
        /// </summary>
        public bool Margins
        {
            get
            {
                margins = LibuiLibrary.uiWindowMargined(Handle.DangerousGetHandle());
                return margins;
            }
            set
            {
                if (margins != value)
                {
                    LibuiLibrary.uiWindowSetMargined(Handle.DangerousGetHandle(), value);
                    margins = value;
                }
            }
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
        /// Closes the window.
        /// </summary>
        public void Close()
        {
            Hide();
            WindowCache.Remove(Handle);
            Dispose();
        }

        #region Control Implementation/Overrides
        /// <inheritdoc/> 
        protected sealed override void InitializeEvents()
        {
            if (Handle.IsInvalid)
                throw new TypeInitializationException(nameof(Window), new InvalidComObjectException());

            LibuiLibrary.uiWindowOnClosing(Handle.DangerousGetHandle(), (window, data) =>
            {
                CancelEventArgs args = new CancelEventArgs();
                OnWindowClosing(args);
                bool cancel = args.Cancel;
                if (!cancel)
                {
                    if (WindowCache.Count > 1 && this != Application.MainWindow)
                        Close();
                    else
                        Application.Current.Shutdown();
                }
                return !cancel;
            }, IntPtr.Zero);

            LibuiLibrary.uiWindowOnContentSizeChanged(Handle.DangerousGetHandle(), (window, data) => { OnSizeChanged(EventArgs.Empty); }, IntPtr.Zero);
        }

        /// <inheritdoc/>
        protected override void Dispose(bool disposing)
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
        #endregion
    }
}