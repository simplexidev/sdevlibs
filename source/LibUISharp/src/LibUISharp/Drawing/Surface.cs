using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using LibUISharp.Internal;
using static LibUISharp.Internal.LibUI;

namespace LibUISharp.Drawing
{
    // uiArea
    public abstract class SurfaceBase : Control
    {
        protected private Dictionary<ControlSafeHandle, SurfaceBase> Surfaces = new Dictionary<ControlSafeHandle, SurfaceBase>();
        private Size size;

        protected SurfaceBase(ISurfaceEventHandler events)
        {
            SurfaceEventHandler surfaceEvents = new SurfaceEventHandler
            {
                Draw = (IntPtr surfaceHandler, IntPtr surface, ref uiAreaDrawParams args) =>
                {
                    ControlSafeHandle surfaceHandle = new ControlSafeHandle(surface); 
                    SurfaceBase realSurface = Surfaces[surfaceHandle];
                    DrawEventArgs a = (DrawEventArgs)args;
                    events.Draw(realSurface, ref a);
                },
                MouseEvent = (IntPtr surfaceHandler, IntPtr surface, ref uiAreaMouseEvent args) =>
                {
                    ControlSafeHandle surfaceHandle = new ControlSafeHandle(surface);
                    SurfaceBase realSurface = Surfaces[surfaceHandle];
                    MouseEventArgs a = (MouseEventArgs)args;
                    events.MouseEvent(realSurface, ref a);
                },
                MouseCrossed = (surfaceHandler, surface, left) =>
                {
                    ControlSafeHandle surfaceHandle = new ControlSafeHandle(surface);
                    SurfaceBase realSurface = Surfaces[surfaceHandle];
                    MouseCrossedEventArgs a = new MouseCrossedEventArgs(left);
                    events.MouseCrossed(realSurface, a);
                },
                DragBroken = (surfaceHandler, surface) =>
                {
                    ControlSafeHandle surfaceHandle = new ControlSafeHandle(surface);
                    SurfaceBase realSurface = Surfaces[surfaceHandle];
                    events.DragBroken(realSurface);
                },
                KeyEvent = (IntPtr surfaceHandler, IntPtr surface, ref uiAreaKeyEvent args) =>
                {
                    ControlSafeHandle surfaceHandle = new ControlSafeHandle(surface);
                    SurfaceBase realSurface = Surfaces[surfaceHandle];
                    KeyEventArgs a = (KeyEventArgs)args;
                    return events.KeyEvent(realSurface, ref a);
                }
            };

            EventHandler = new uiAreaHandler
            {
                DragBroken = Marshal.GetFunctionPointerForDelegate(surfaceEvents.DragBroken),
                Draw = Marshal.GetFunctionPointerForDelegate(surfaceEvents.Draw),
                KeyEvent = Marshal.GetFunctionPointerForDelegate(surfaceEvents.KeyEvent),
                MouseCrossed = Marshal.GetFunctionPointerForDelegate(surfaceEvents.MouseCrossed),
                MouseEvent = Marshal.GetFunctionPointerForDelegate(surfaceEvents.MouseEvent)
            };
        }

        internal uiAreaHandler EventHandler { get; }

        public Size Size
        {
            get => size;
            set
            {
                if (size != value)
                {
                    uiAreaSetSize(Handle, value.Width, value.Height);
                    size = value;
                }
            }
        }

        public int Width => size.Width;
        public int Height => size.Height;

        public void QueueReDrawAll() => uiAreaQueueReDrawAll(Handle);

        public void ScrollTo(double x, double y, double width, double height) => uiAreaScrollTo(Handle, x, y, width, height);

        public void BeginUserWindowMove() => uiAreaBeginUserWindowMove(Handle);

        public void BeginUserWindowResize(WindowEdge edge) => uiAreaBeginUserWindowResize(Handle, edge);
    }

    public class Surface : SurfaceBase
    {
        public Surface(ISurfaceEventHandler handler) : base(handler)
        {
            Handle = uiNewArea(EventHandler);
            Surfaces[Handle] = this;
        }
    }

    public class ScrollableSurface : Surface
    {
        public ScrollableSurface(ISurfaceEventHandler handler, int width, int height) : base(handler)
        {
            Handle = uiNewScrollingArea(EventHandler, width, height);
            Surfaces[Handle] = this;
        }

        public ScrollableSurface(ISurfaceEventHandler handler, Size size) : this(handler, size.Width, size.Height) { }
    }

    public interface ISurfaceEventHandler
    {
        void Draw(SurfaceBase surface, ref DrawEventArgs args);
        void MouseEvent(SurfaceBase surface, ref MouseEventArgs args);
        void MouseCrossed(SurfaceBase surface, MouseCrossedEventArgs args);
        void DragBroken(SurfaceBase surface);
        bool KeyEvent(SurfaceBase surface, ref KeyEventArgs args);
    }

    // uiAreaHandler
    [StructLayout(LayoutKind.Sequential)]
    internal class SurfaceEventHandler
    {
        [MarshalAs(UnmanagedType.FunctionPtr)]
        public uiDrawHandler Draw;
        [MarshalAs(UnmanagedType.FunctionPtr)]
        public uiMouseEventHandler MouseEvent;
        [MarshalAs(UnmanagedType.FunctionPtr)]
        public uiMouseCrossedHandler MouseCrossed;
        [MarshalAs(UnmanagedType.FunctionPtr)]
        public uiDragBrokenHandler DragBroken;
        [MarshalAs(UnmanagedType.FunctionPtr)]
        public uiKeyEventHandler KeyEvent;
    }
}