using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using LibUISharp.Internal;
using static LibUISharp.Internal.Libraries;

namespace LibUISharp.Drawing
{
    /// <summary>
    /// Represents a drawable surface.
    /// </summary>
    [NativeType("uiArea")]
    public class Surface
    {
        protected private Dictionary<IntPtr, Surface> Surfaces = new Dictionary<IntPtr, Surface>();
        private Size size;

        /// <summary>
        /// Initializes a new instance of the <see cref="Surface"/> class with the specified handler.
        /// </summary>
        /// <param name="events">The specified event handler.</param>
        /// <param name="scrollable">Whether this surface is scrollable or not.</param>
        /// <param name="width">The width of the scrollable surface.</param>
        /// <param name="height">The height of the scrollable surface.</param>
        public Surface(SurfaceEventHandler events, bool scrollable = false, int width = -1, int height = -1)
        {
            SurfaceHandler surfaceEvents = new SurfaceHandler
            {
                Draw = (IntPtr surfaceHandler, IntPtr surface, ref DrawEventArgs args) =>
                {
                    Surface realSurface = Surfaces[surface];
                    DrawEventArgs a = new DrawEventArgs(new Context(args.Context), new RectangleD(args.ClipX, args.ClipY, args.ClipWidth, args.ClipHeight), new SizeD(args.AreaWidth, args.AreaHeight));
                    events.Draw(realSurface, ref a);
                },
                MouseEvent = (IntPtr surfaceHandler, IntPtr surface, ref MouseEventArgs args) =>
                {
                    Surface realSurface = Surfaces[surface];
                    MouseEventArgs a = new MouseEventArgs(new PointD(args.X, args.Y), new SizeD(args.AreaWidth, args.AreaHeight), args.Up, args.Down, args.Count, args.Modifiers, args.Held1To64);
                    events.MouseEvent(realSurface, ref a);
                },
                MouseCrossed = (IntPtr surfaceHandler, IntPtr surface, bool left) =>
                {
                    Surface realSurface = Surfaces[surface];
                    MouseCrossedEventArgs a = new MouseCrossedEventArgs(left);
                    events.MouseCrossed(realSurface, a);
                },
                DragBroken = (IntPtr surfaceHandler, IntPtr surface) =>
                {
                    Surface realSurface = Surfaces[surface];
                    events.DragBroken(realSurface);
                },
                KeyEvent = (IntPtr surfaceHandler, IntPtr surface, ref KeyEventArgs args) =>
                {
                    Surface realSurface = Surfaces[surface];
                    KeyEventArgs a = new KeyEventArgs(args.Key, args.Extension, args.Modifier, args.Modifiers, args.Up);
                    return events.KeyEvent(realSurface, ref a);
                }
            };

            EventHandler = new NativeSurfaceHandler
            {
                DragBroken = Marshal.GetFunctionPointerForDelegate(surfaceEvents.DragBroken),
                Draw = Marshal.GetFunctionPointerForDelegate(surfaceEvents.Draw),
                KeyEvent = Marshal.GetFunctionPointerForDelegate(surfaceEvents.KeyEvent),
                MouseCrossed = Marshal.GetFunctionPointerForDelegate(surfaceEvents.MouseCrossed),
                MouseEvent = Marshal.GetFunctionPointerForDelegate(surfaceEvents.MouseEvent)
            };

            IsScrollable = scrollable;
            if (scrollable)
                Handle = Libui.Call<Libui.uiNewScrollingArea>()(EventHandler, width, height);
            else
                Handle = Libui.Call<Libui.uiNewArea>()(EventHandler);
            Surfaces[Handle] = this;
        }

        internal NativeSurfaceHandler EventHandler { get; }

        /// <summary>
        /// Gets a value whether this surface support scrolling or not.
        /// </summary>
        public bool IsScrollable { get; }

        /// <summary>
        /// Gets or sets the content size of this surface.
        /// </summary>
        public Size Size
        {
            get => size;
            set
            {
                if (size != value)
                {
                    Libui.Call<Libui.uiAreaSetSize>()(this, value.Width, value.Height);
                    size = value;
                }
            }
        }

        /// <summary>
        /// Gets the width of the content size.
        /// </summary>
        public int Width => size.Width;

        /// <summary>
        /// Gets the height of the content size.
        /// </summary>
        public int Height => size.Height;

        /// <summary>
        /// Queues a redraw of the surface.
        /// </summary>
        public void QueueRedrawAll()
        {
            Thread.Sleep(200);
            Libui.Call<Libui.uiAreaQueueRedrawAll>()(this);
        }

        /// <summary>
        /// Scrolls the surface view to the specified location and size.
        /// </summary>
        /// <param name="x">The x-coordinate.</param>
        /// <param name="y">The y-coordinate.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        public void ScrollTo(double x, double y, double width, double height) => Libui.Call<Libui.uiAreaScrollTo>()(this, x, y, width, height);

        public void BeginUserWindowMove() => Libui.Call<Libui.uiAreaBeginUserWindowMove>()(this);

        public void BeginUserWindowResize(WindowEdge edge) => Libui.Call<Libui.uiAreaBeginUserWindowResize>()(this, edge);
    }

    /// <summary>
    /// Defines the events for a drawable surface.
    /// </summary>
    public abstract class SurfaceEventHandler
    {
        /// <summary>
        /// Called when the surface is created or resized.
        /// </summary>
        /// <param name="surface">The surface.</param>
        /// <param name="args">The event data.</param>
        public virtual void Draw(Surface surface, ref DrawEventArgs args) { }

        /// <summary>
        /// Called when the mouse is moved or clicked over the surface.
        /// </summary>
        /// <param name="surface">The surface.</param>
        /// <param name="args">The event data.</param>
        public virtual void MouseEvent(Surface surface, ref MouseEventArgs args) { }

        /// <summary>
        /// Called when the mouse entered or left the surface.
        /// </summary>
        /// <param name="surface">The surface.</param>
        /// <param name="args">The event data.</param>
        public virtual void MouseCrossed(Surface surface, MouseCrossedEventArgs args) { }

        /// <summary>
        /// Called when a mouse drag is ended.
        /// </summary>
        /// <param name="surface">The surface.</param>
        public virtual void DragBroken(Surface surface) { }

        /// <summary>
        /// Called when a key is pressed.
        /// </summary>
        /// <param name="surface">The surface.</param>
        /// <param name="args">The event data.</param>
        public virtual bool KeyEvent(Surface surface, ref KeyEventArgs args) => false;
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void DrawHandler(IntPtr handler, IntPtr surface, [In, Out]ref DrawEventArgs param);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void MouseEventHandler(IntPtr handler, IntPtr surface, [In, Out]ref MouseEventArgs mouseEvent);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void MouseCrossedHandler(IntPtr handler, IntPtr surface, bool left);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void DragBrokenHandler(IntPtr handler, IntPtr surface);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate bool KeyEventHandler(IntPtr handler, IntPtr surface, [In, Out]ref KeyEventArgs keyEvent);

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

    [StructLayout(LayoutKind.Sequential)]
    [NativeType("uiAreaHandler")]
    internal class NativeSurfaceHandler
    {
        public IntPtr Draw;
        public IntPtr MouseEvent;
        public IntPtr MouseCrossed;
        public IntPtr DragBroken;
        public IntPtr KeyEvent;
    }
}