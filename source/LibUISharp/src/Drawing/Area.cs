using System;
using System.Collections.Generic;
using LibUISharp.Internal;
using static LibUISharp.Internal.UI;

namespace LibUISharp.Drawing
{
    //TODO: uiAreaHander.KeyEvent should return a bool, but the way things are set up, I'm not sure how to do this...
    //TODO: Maybe move BeginUserWindowMove() and BeginUserWindowResize() into Window?
    internal class Area : Control
    {
        public Area()
        {
            Initialize();
            Handle = new UIControlHandle(uiNewArea(Handler));
            Areas[Handle.DangerousGetHandle()] = this;
            IsScrollable = false;
        }

        public Area(int width, int height)
        {
            Initialize();
            Handle = new UIControlHandle(uiNewScrollingArea(Handler, width, height));
            Areas[Handle.DangerousGetHandle()] = this;
            IsScrollable = true;
        }

        public Area(Size size) : this(size.Width, size.Height) { }

        private Size size;
        public Size Size
        {
            get => size;
            set
            {
                if (size != value)
                {
                    uiAreaSetSize(Handle.DangerousGetHandle(), value.Width, value.Height);
                    size = value;
                }
            }
        }

        public bool IsScrollable { get; private set; }

        internal uiAreaHandler Handler { get; private set; }
        internal Dictionary<IntPtr, Area> Areas = new Dictionary<IntPtr, Area>();

        public void QueueRedrawAll() => uiAreaQueueReDrawAll(Handle.DangerousGetHandle());
        public void ScrollTo(double x, double y, double width, double height) => uiAreaScrollTo(Handle.DangerousGetHandle(), x, y, width, height);
        public void ScrollTo(PointD point, SizeD size) => ScrollTo(point.X, point.Y, size.Width, size.Height);
        public void ScrollTo(RectangleD rectangle) => ScrollTo(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
        public void BeginUserWindowMove() => uiAreaBeginUserWindowMove(Handle.DangerousGetHandle());
        public void BeginUserWindowResize(WindowEdge edge) => uiAreaBeginUserWindowResize(Handle.DangerousGetHandle(), edge);

        protected sealed override void Initialize() => Handler = new uiAreaHandler
        {
            Draw = (IntPtr handler, IntPtr area, ref uiAreaDrawParams param) =>
            {
                Area a = Areas[area];
                DrawEventArgs args = new DrawEventArgs(new Context(new UIDrawHandle(param.Context)), new SizeD(param.AreaWidth, param.AreaHeight), new RectangleD(param.ClipX, param.ClipY, param.ClipWidth, param.ClipHeight));
                OnDraw(a, args);
            },
            MouseEvent = (IntPtr areaHandler, IntPtr area, ref uiAreaMouseEvent mouseEvent) =>
            {
                Area a = Areas[area];
                MouseEventArgs args = new MouseEventArgs(new PointD(mouseEvent.X, mouseEvent.Y), new SizeD(mouseEvent.AreaWidth, mouseEvent.AreaHeight), mouseEvent.Up, mouseEvent.Down, mouseEvent.Count, mouseEvent.Modifiers, mouseEvent.Held1To64);
                OnMouse(a, args);
            },
            MouseCrossed = (areaHandler, area, left) =>
            {
                Area a = Areas[area];
                MouseCrossedEventArgs args = new MouseCrossedEventArgs(left);
                OnMouseCrossed(a, args);
            },
            DragBroken = (IntPtr handler, IntPtr area) =>
            {
                Area a = Areas[area];
                OnDragBroken(a, EventArgs.Empty);
            },
            KeyEvent = (IntPtr handler, IntPtr area, ref uiAreaKeyEvent keyEvent) =>
            {
                Area a = Areas[area];
                KeyEventArgs args = new KeyEventArgs(Convert.ToChar(keyEvent.Key), keyEvent.ExtKey, keyEvent.Modifier, keyEvent.Modifiers, keyEvent.Up);
                OnKey(a, args);
                return true;
            },
        };

        public event EventHandler<DrawEventArgs> Draw;
        public event EventHandler<MouseEventArgs> Mouse;
        public event EventHandler<MouseCrossedEventArgs> MouseCrossed;
        public event EventHandler DragBroken;
        public event EventHandler<KeyEventArgs> Key;

        protected virtual void OnDraw(Area area, DrawEventArgs e) => Draw?.Invoke(area, e);
        protected virtual void OnMouse(Area area, MouseEventArgs e) => Mouse?.Invoke(area, e);
        protected virtual void OnMouseCrossed(Area area, MouseCrossedEventArgs e) => MouseCrossed?.Invoke(area, e);
        protected virtual void OnDragBroken(Area area, EventArgs e) => DragBroken?.Invoke(area, e);
        protected virtual void OnKey(Area area, KeyEventArgs e) => Key?.Invoke(area, e);
    }

    public sealed class DrawEventArgs : EventArgs
    {
        public DrawEventArgs(Context context, SizeD size, RectangleD clip)
        {
            Context = context;
            Size = size;
            Clip = clip;
        }

        public Context Context;
        public SizeD Size;
        public RectangleD Clip;
    }

    public sealed class MouseEventArgs
    {
        public MouseEventArgs(PointD point, SizeD size, bool up, bool down, int count, ModifierKeyFlags modifiers, ulong held)
        {
            Point = point;
            AreaSize = size;
            Up = up;
            Down = down;
            Count = count;
            Modifiers = modifiers;
            Held1To64 = held;
        }
        public PointD Point { get; }
        public SizeD AreaSize { get; }
        public bool Up { get; }
        public bool Down { get; }
        public int Count { get; }
        public ModifierKeyFlags Modifiers { get; }
        public ulong Held1To64 { get; }
    }

    public sealed class MouseCrossedEventArgs : EventArgs
    {
        public MouseCrossedEventArgs(bool left) => Left = left;

        public bool Left { get; }
    }

    public sealed class KeyEventArgs : EventArgs
    {
        public KeyEventArgs(char key, ExtensionKey extKey, ModifierKeyFlags modifier, ModifierKeyFlags modifiers, bool up)
        {
            Key = key;
            ExtensionKey = extKey;
            Modifier = modifier;
            Modifiers = modifiers;
            Up = up;
        }

        public char Key { get; }
        public ExtensionKey ExtensionKey { get; }
        public ModifierKeyFlags Modifier { get; }
        public ModifierKeyFlags Modifiers { get; }
        public bool Up { get; }
    }
}