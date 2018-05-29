using LibUISharp.Internal;
using LibUISharp.SafeHandles;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

// uiArea
namespace LibUISharp.Drawing
{
    /// <summary>
    /// Represents the base of all types of <see cref="Surface"/>.
    /// </summary>
    public abstract class SurfaceBase : Control
    {
        protected private Dictionary<IntPtr, SurfaceBase> Surfaces = new Dictionary<IntPtr, SurfaceBase>();
        private Size size;

        protected SurfaceBase(ISurfaceHandler events)
        {
            SurfaceHandler surfaceEvents = new SurfaceHandler
            {
                Draw = (IntPtr surfaceHandler, IntPtr surface, ref LibuiLibrary.uiAreaDrawParams args) =>
                {
                    SurfaceBase realSurface = Surfaces[surface];
                    DrawEventArgs a = args.ToDrawEventArgs();
                    events.Draw(realSurface, ref a);
                },
                MouseEvent = (IntPtr surfaceHandler, IntPtr surface, ref LibuiLibrary.uiAreaMouseEvent args) =>
                {
                    SurfaceBase realSurface = Surfaces[surface];
                    MouseEventArgs a = args.ToMouseEventArgs();
                    events.MouseEvent(realSurface, ref a);
                },
                MouseCrossed = (surfaceHandler, surface, left) =>
                {
                    SurfaceBase realSurface = Surfaces[surface];
                    MouseCrossedEventArgs a = new MouseCrossedEventArgs(left);
                    events.MouseCrossed(realSurface, a);
                },
                DragBroken = (surfaceHandler, surface) =>
                {
                    SurfaceBase realSurface = Surfaces[surface];
                    events.DragBroken(realSurface);
                },
                KeyEvent = (IntPtr surfaceHandler, IntPtr surface, ref LibuiLibrary.uiAreaKeyEvent args) =>
                {
                    SurfaceBase realSurface = Surfaces[surface];
                    KeyEventArgs a = args.ToKeyEventArgs();
                    return events.KeyEvent(realSurface, ref a);
                }
            };

            EventHandler = new LibuiLibrary.uiAreaHandler
            {
                DragBroken = Marshal.GetFunctionPointerForDelegate(surfaceEvents.DragBroken),
                Draw = Marshal.GetFunctionPointerForDelegate(surfaceEvents.Draw),
                KeyEvent = Marshal.GetFunctionPointerForDelegate(surfaceEvents.KeyEvent),
                MouseCrossed = Marshal.GetFunctionPointerForDelegate(surfaceEvents.MouseCrossed),
                MouseEvent = Marshal.GetFunctionPointerForDelegate(surfaceEvents.MouseEvent)
            };
        }

        internal LibuiLibrary.uiAreaHandler EventHandler { get; }

        public Size Size
        {
            get => size;
            set
            {
                if (size != value)
                {
                    LibuiLibrary.uiAreaSetSize(Handle.DangerousGetHandle(), value.Width, value.Height);
                    size = value;
                }
            }
        }

        public int Width => size.Width;
        public int Height => size.Height;

        public void QueueRedrawAll() => LibuiLibrary.uiAreaQueueRedrawAll(Handle.DangerousGetHandle());

        public void ScrollTo(double x, double y, double width, double height) => LibuiLibrary.uiAreaScrollTo(Handle.DangerousGetHandle(), x, y, width, height);

        public void BeginUserWindowMove() => LibuiLibrary.uiAreaBeginUserWindowMove(Handle.DangerousGetHandle());

        public void BeginUserWindowResize(WindowEdge edge) => LibuiLibrary.uiAreaBeginUserWindowResize(Handle.DangerousGetHandle(), (LibuiLibrary.uiWindowResizeEdge)edge);
    }

    public class Surface : SurfaceBase
    {
        public Surface(ISurfaceHandler handler) : base(handler)
        {
            Handle = new SafeControlHandle(LibuiLibrary.uiNewArea(EventHandler));
            Surfaces[Handle.DangerousGetHandle()] = this;
        }
    }

    public class ScrollableSurface : SurfaceBase
    {
        public ScrollableSurface(ISurfaceHandler handler, int width, int height) : base(handler)
        {
            Handle = new SafeControlHandle(LibuiLibrary.uiNewScrollingArea(EventHandler, width, height));
            Surfaces[Handle.DangerousGetHandle()] = this;
        }

        public ScrollableSurface(ISurfaceHandler handler, Size size) : this(handler, size.Width, size.Height) { }
    }

    public interface ISurfaceHandler
    {
        void Draw(SurfaceBase surface, ref DrawEventArgs args);
        void MouseEvent(SurfaceBase surface, ref MouseEventArgs args);
        void MouseCrossed(SurfaceBase surface, MouseCrossedEventArgs args);
        void DragBroken(SurfaceBase surface);
        bool KeyEvent(SurfaceBase surface, ref KeyEventArgs args);
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void DrawHandler(IntPtr handler, IntPtr area, [In, Out]ref LibuiLibrary.uiAreaDrawParams param);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void MouseEventHandler(IntPtr handler, IntPtr area, [In, Out]ref LibuiLibrary.uiAreaMouseEvent mouseEvent);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void MouseCrossedHandler(IntPtr handler, IntPtr area, bool left);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void DragBrokenHandler(IntPtr handler, IntPtr area);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate bool KeyEventHandler(IntPtr handler, IntPtr area, [In, Out]ref LibuiLibrary.uiAreaKeyEvent keyEvent);

    // uiAreaHandler
    [StructLayout(LayoutKind.Sequential)]
    internal class SurfaceHandler
    {
        [MarshalAs(UnmanagedType.FunctionPtr)]
        public DrawHandler Draw;
        [MarshalAs(UnmanagedType.FunctionPtr)]
        public MouseEventHandler MouseEvent;
        [MarshalAs(UnmanagedType.FunctionPtr)]
        public MouseCrossedHandler MouseCrossed;
        [MarshalAs(UnmanagedType.FunctionPtr)]
        public DragBrokenHandler DragBroken;
        [MarshalAs(UnmanagedType.FunctionPtr)]
        public KeyEventHandler KeyEvent;
    }
}