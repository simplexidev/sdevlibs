using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using LibUISharp.Drawing;
using LibUISharp.Internal;
using static LibUISharp.Internal.Libraries;

namespace LibUISharp
{
    /// <summary>
    /// Represents a window that makes up an application's user interface.
    /// </summary>
    [NativeType("uiWindow")]
    public partial class Window : SingleContainer<Window, Control>
    {
        private Control child;
        private bool isMargined, fullscreen, borderless;
        private Size size;
        private string title;

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
            Handle = Libui.Call<Libui.uiNewWindow>()(title, width, height, hasMenu);

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
            get => title = Libui.Call<Libui.uiWindowTitle>()(this);
            set
            {
                if (title != value)
                {
                    Libui.Call<Libui.uiWindowSetTitle>()(this, value);
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
                Libui.Call<Libui.uiWindowContentSize>()(this, out int w, out int h);
                size = new Size(w, h);
                return size;
            }
            set
            {
                if (size != value)
                {
                    Libui.Call<Libui.uiWindowSetContentSize>()(this, value.Width, value.Height);
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
                fullscreen = Libui.Call<Libui.uiWindowFullscreen>()(this);
                return fullscreen;
            }
            set
            {
                if (fullscreen != value)
                {
                    Libui.Call<Libui.uiWindowSetFullscreen>()(this, value);
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
                borderless = Libui.Call<Libui.uiWindowBorderless>()(this);
                return borderless;
            }
            set
            {
                if (borderless != value)
                {
                    Libui.Call<Libui.uiWindowSetBorderless>()(this, value);
                    borderless = value;
                }
            }
        }

        /// <summary>
        /// Sets the child <see cref="Control"/> of this window.
        /// </summary>
        public override Control Child
        {
            set
            {
                if (Handle != IntPtr.Zero)
                {
                    if (value == null) throw new UIException("Cannot add a null Control to a Window.");
                    Libui.Call<Libui.uiWindowSetChild>()(this, value);
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
                isMargined = Libui.Call<Libui.uiWindowMargined>()(this);
                return isMargined;
            }
            set
            {
                if (isMargined != value)
                {
                    Libui.Call<Libui.uiWindowSetMargined>()(this, value);
                    isMargined = value;
                }
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

            Libui.Call<Libui.uiWindowOnClosing>()(this, (window, data) =>
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

            Libui.Call<Libui.uiWindowOnContentSizeChanged>()(this, (window, data) => { OnSizeChanged(EventArgs.Empty); }, IntPtr.Zero);
        }
    }
}