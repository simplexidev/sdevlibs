using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using LibUISharp.Drawing;
using LibUISharp.Internal;
using static LibUISharp.Internal.LibUI;

namespace LibUISharp
{
    // uiWindow
    public class Window : Control
    {
        private Control child;
        private bool margins, fullscreen, borderless;
        private Size size;
        private string title;
        private static readonly Dictionary<ControlSafeHandle, Window> WindowCache = new Dictionary<ControlSafeHandle, Window>();

        public Window(int width = 500, int height = 300, string title = null, bool hasMenuBar = false)
        {
            if (string.IsNullOrEmpty(title))
                title = "LibUI";
            Handle = uiNewWindow(title, width, height, hasMenuBar);
            WindowCache.Add(Handle, this);
            this.title = title;
            InitializeEvents();
            InitializeComponent();
        }

        public Window(Size size, string title = null, bool hasMenuBar = false) : this(size.Width, size.Height, title, hasMenuBar) { }

        public EventHandler<CancelEventArgs> Closing;
        public EventHandler SizeChanged;

        public string Title
        {
            get
            {
                title = uiWindowTitle(Handle);
                return title;
            }
            set
            {
                if (title != value)
                {
                    if (string.IsNullOrEmpty(value))
                        title = "LibUI";
                    else
                        title = value;
                    uiWindowSetTitle(Handle, title);
                }
            }
        }

        public Size Size
        {
            get
            {
                uiWindowContentSize(Handle, out int w, out int h);
                return new Size(w, h);
            }
            set => uiWindowSetContentSize(Handle, value.Width, value.Height);
        }

        public int Width => Size.Width;
        public int Height => Size.Height;

        public bool Margins
        {
            get
            {
                margins = uiWindowMargined(Handle);
                return margins;
            }
            set
            {
                if (margins != value)
                {
                    uiWindowSetMargined(Handle, value);
                    margins = value;
                }
            }
        }

        public bool Fullscreen
        {
            get
            {
                fullscreen = uiWindowFullscreen(Handle);
                return fullscreen;
            }
            set
            {
                if (fullscreen != value)
                {
                    uiWindowSetFullscreen(Handle, value);
                    fullscreen = value;
                }
            }
        }

        public bool Borderless
        {
            get
            {
                borderless = uiWindowBorderless(Handle);
                return borderless;
            }
            set
            {
                if (borderless != value)
                {
                    uiWindowSetBorderless(Handle, value);
                    borderless = value;
                }
            }
        }

        public Control Child
        {
            get => child;
            set
            {
                if (!Handle.IsInvalid)
                {
                    if (value == null)
                        uiWindowSetChild(Handle, new ControlSafeHandle());
                    uiWindowSetChild(Handle, value.Handle);
                }
                child = value;
            }
        }

        protected sealed override void InitializeEvents()
        {
            if (Handle.IsInvalid)
                throw new TypeInitializationException(nameof(Window), new InvalidComObjectException());

            uiWindowOnClosing(Handle, (window, data) =>
            {
                CancelEventArgs args = new CancelEventArgs();
                OnClosing(args);
                bool cancel = args.Cancel;
                if (!cancel)
                {
                    if (WindowCache.Count > 1 && this != Application.MainWindow)
                        Close();
                    else
                        Application.Current.Exit();
                }
                return !cancel;
            });

            uiWindowOnContentSizeChanged(Handle, (window, data) => { OnResize(EventArgs.Empty); });
        }

        protected sealed override void InitializeComponent() { }

        protected virtual void OnClosing(CancelEventArgs e) => Closing?.Invoke(this, e);
        protected virtual void OnSizeChanged(EventArgs e) => SizeChanged?.Invoke(this, e);

        public void Close()
        {
            Hide();
            if (Child != null)
            {
                Child.Dispose();
                Child = null;
            }
            WindowCache.Remove(Handle);
            Dispose();
        }
    }
}