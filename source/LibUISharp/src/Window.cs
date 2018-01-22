using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using LibUISharp.Drawing;
using LibUISharp.Internal;

using static LibUISharp.Internal.UI;

namespace LibUISharp
{
    public class Window : Control
    {
        public Window(string title, bool hasMenuBar = false) : this(title, new Size(300, 300), hasMenuBar) { }

        public Window(string title, Size size, bool hasMenuBar = false) : this(title, size.Width, size.Height, hasMenuBar) { }

        public Window(string title, int width, int height, bool hasMenuBar = false)
        {
            if (string.IsNullOrEmpty(title)) title = "LibUISharp";
            size = new Size(width, height);
            HasMenuBar = hasMenuBar;
            IntPtr strPtr = MarshalHelper.StringToUTF8(title);
            Handle = new UIControlHandle(uiNewWindow(strPtr, width, height, hasMenuBar));
            Initialize();
            Marshal.FreeHGlobal(strPtr);
        }

        public EventHandler<CancelEventArgs> Closing;
        public EventHandler SizeChanged;

        public virtual bool HasMenuBar { get; private set; }

        private Control child;
        public Control Child
        {
            get => child;
            set
            {
                if (!value.Handle.IsInvalid) uiWindowSetChild(Handle.DangerousGetHandle(), value.Handle.DangerousGetHandle());
                else uiWindowSetChild(Handle.DangerousGetHandle(), IntPtr.Zero);
                child = value;
            }
        }

        private string title;
        public string Title
        {
            get => MarshalHelper.StringFromUTF8(uiWindowTitle(Handle.DangerousGetHandle()));
            set
            {
                title = value;
                if (string.IsNullOrEmpty(title)) title = "LibUISharp";
                IntPtr strPtr = MarshalHelper.StringToUTF8(title);
                uiWindowSetTitle(Handle.DangerousGetHandle(), strPtr);
                Marshal.FreeHGlobal(strPtr);
            }
        }

        private Size size = new Size();
        public Size Size
        {
            get
            {
                uiWindowContentSize(Handle.DangerousGetHandle(), out int w, out int h);
                return new Size(w, h);
            }
            set
            {
                size = value;
                uiWindowSetContentSize(Handle.DangerousGetHandle(), value.Width, value.Height);
            }
        }

        public bool HasMargins
        {
            get => uiWindowMargined(Handle.DangerousGetHandle());
            set => uiWindowSetMargined(Handle.DangerousGetHandle(), value);
        }

        public bool FullScreen
        {
            get => uiWindowFullscreen(Handle.DangerousGetHandle());
            set => uiWindowSetFullscreen(Handle.DangerousGetHandle(), value);
        }

        public bool Borderless
        {
            get => uiWindowBorderless(Handle.DangerousGetHandle());
            set => uiWindowSetBorderless(Handle.DangerousGetHandle(), value);
        }

        protected sealed override void Initialize()
        {
            if (Handle.IsInvalid) throw new TypeInitializationException(nameof(Window), new InvalidComObjectException());
            uiWindowOnClosing(Handle.DangerousGetHandle(), (window, data) =>
            {
                CancelEventArgs args = new CancelEventArgs();
                OnClosing(args);
                bool cancel = args.Cancel;
                if (!cancel)
                    if (this != Application.MainWindow)
                        Close();
                    else
                        Application.Current.Quit();
                return !cancel;
            }, IntPtr.Zero);
            uiWindowOnContentSizeChanged(Handle.DangerousGetHandle(), (window, data) => { OnSizeChanged(EventArgs.Empty); }, IntPtr.Zero);
        }

        protected virtual void OnSizeChanged(EventArgs e) => SizeChanged?.Invoke(this, e);
        protected virtual void OnClosing(CancelEventArgs e) => Closing?.Invoke(this, e);

        public override void Show() => base.Show();

        public void Close()
        {
            Hide();
            if (Child != null)
            {
                Child.Dispose(true);
                Child = null;
            }
            Handle.Close();
        }
    }
}