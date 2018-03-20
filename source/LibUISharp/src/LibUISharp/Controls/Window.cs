using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using LibUISharp.Drawing;
using LibUISharp.Internal;

namespace LibUISharp.Controls
{
    public class Window : Control
    {
        private Control child;
        private Size size;
        private string title;
        private static readonly Dictionary<ControlSafeHandle, Window> WindowCache = new Dictionary<ControlSafeHandle, Window>();

        public Window(int width = 500, int height = 300, string title = null, bool hasMenuBar = false)
        { 
            if (string.IsNullOrEmpty(title))
                title = "LibUI";
            Handle = LibUI.NewWindow(title, width, height, hasMenuBar);
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
                title = LibUI.WindowGetTitle(Handle);
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
                    LibUI.WindowSetTitle(Handle, title);
                }
            }
        }

        public Size Size
        {
            get => LibUI.WindowGetSize(Handle);
            set => LibUI.WindowSetSize(Handle, value);
        }

        public int Width => Size.Width;
        public int Height => Size.Height;

        public bool Margins
        {
            get => LibUI.WindowGetMargins(Handle);
            set => LibUI.WindowSetMargins(Handle, value);
        }

        public bool Fullscreen
        {
            get => LibUI.WindowGetFullscreen(Handle);
            set => LibUI.WindowSetFullscreen(Handle, value);
        }

        public bool Borderless
        {
            get => LibUI.WindowGetBorderless(Handle);
            set => LibUI.WindowSetBorderless(Handle, value);
        }
  
        public Control Child
        {
            get => child;
            set
            {
                if (!Handle.IsInvalid)
                {
                    if (value == null)
                        LibUI.WindowSetChild(Handle, new ControlSafeHandle());
                    LibUI.WindowSetChild(Handle, value.Handle);
                }
                child = value;
            }
        }

        protected sealed override void InitializeEvents()
        {
            if (Handle.IsInvalid)
                throw new TypeInitializationException(nameof(Window), new InvalidComObjectException());

            LibUI.WindowOnClosing(Handle, (window, data) =>
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

            LibUI.WindowOnSizeChanged(Handle, (window, data) => { OnResize(EventArgs.Empty); });
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