using System;
using System.Runtime.InteropServices;
using LibUISharp.Drawing;
using LibUISharp.Internal;

namespace LibUISharp
{
    /// <summary>
    /// Represents a native window that makes up an application's user interface.
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
            Handle = NativeCalls.NewWindow(title, width, height, hasMenu);

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
        public event Func<bool, bool> Closing;

        /// <summary>
        /// Occurs when the <see cref="Size"/> property value changes.
        /// </summary>
        public event Action SizeChanged;

        /// <summary>
        /// Gets whether or not this window has a menu.
        /// </summary>
        public bool HasMenu { get; }

        /// <summary>
        /// Gets or sets the title of this window.
        /// </summary>
        public string Title
        {
            get => title = NativeCalls.WindowTitle(this);
            set
            {
                if (title != value)
                {
                    NativeCalls.WindowSetTitle(this, value);
                    title = value;
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
                NativeCalls.WindowContentSize(this, out int w, out int h);
                size = new Size(w, h);
                return size;
            }
            set
            {
                if (size != value)
                {
                    NativeCalls.WindowSetContentSize(this, value.Width, value.Height);
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
                fullscreen = NativeCalls.WindowFullscreen(this);
                return fullscreen;
            }
            set
            {
                if (fullscreen != value)
                {
                    NativeCalls.WindowSetFullscreen(this, value);
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
                borderless = NativeCalls.WindowBorderless(this);
                return borderless;
            }
            set
            {
                if (borderless != value)
                {
                    NativeCalls.WindowSetBorderless(this, value);
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
                    NativeCalls.WindowSetChild(this, value);
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
                isMargined = NativeCalls.WindowMargined(this);
                return isMargined;
            }
            set
            {
                if (isMargined != value)
                {
                    NativeCalls.WindowSetMargined(this, value);
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
        /// Raises the <see cref="Closing"/> event.
        /// </summary>
        /// <param name="cancel">A <see cref="bool"/> containing the event data.</param>
        protected virtual void OnClosing(bool cancel) => Closing?.Invoke(cancel);

        /// <summary>
        /// Raises the <see cref="SizeChanged"/> event.
        /// </summary>
        protected virtual void OnSizeChanged() => SizeChanged?.Invoke();

        /// <summary>
        /// Initializes this UI component's events.
        /// </summary>
        protected sealed override void InitializeEvents()
        {
            if (Handle == IntPtr.Zero)
                throw new TypeInitializationException(nameof(Window), new InvalidComObjectException());

            NativeCalls.WindowOnClosing(this, (window, data) =>
            {
                bool cancel = false;
                OnClosing(cancel);
                if (!cancel)
                {
                    if (this != Application.MainWindow)
                        Close();
                    else
                        Application.Current.Shutdown();
                }
                return !cancel;
            }, IntPtr.Zero);

            NativeCalls.WindowOnContentSizeChanged(this, (window, data) => { OnSizeChanged(); }, IntPtr.Zero);
        }
    }
}