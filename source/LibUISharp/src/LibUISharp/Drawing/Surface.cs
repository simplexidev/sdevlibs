using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using static LibUISharp.Native.NativeMethods;

namespace LibUISharp.Drawing
{
    /// <summary>
    /// Represents the base of all types of drawable surfaces.
    /// </summary>
    public class Surface : Control
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
        public Surface(ISurfaceHandler events, bool scrollable = false, int width = -1, int height = -1)
        {
            SurfaceHandler surfaceEvents = new SurfaceHandler
            {
                Draw = (IntPtr surfaceHandler, IntPtr surface, ref Libui.uiAreaDrawParams args) =>
                {
                    Surface realSurface = Surfaces[surface];
                    DrawEventArgs a = new DrawEventArgs(new Context(args.Context), new RectangleD(args.ClipX, args.ClipY, args.ClipWidth, args.ClipHeight), new SizeD(args.AreaWidth, args.AreaHeight));
                    events.Draw(realSurface, ref a);
                },
                MouseEvent = (IntPtr surfaceHandler, IntPtr surface, ref Libui.uiAreaMouseEvent args) =>
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
                KeyEvent = (IntPtr surfaceHandler, IntPtr surface, ref Libui.uiAreaKeyEvent args) =>
                {
                    Surface realSurface = Surfaces[surface];
                    KeyEventArgs a = new KeyEventArgs(args.Key, args.ExtKey, args.Modifier, args.Modifiers, args.Up);
                    return events.KeyEvent(realSurface, ref a);
                }
            };

            EventHandler = new Libui.uiAreaHandler
            {
                DragBroken = Marshal.GetFunctionPointerForDelegate(surfaceEvents.DragBroken),
                Draw = Marshal.GetFunctionPointerForDelegate(surfaceEvents.Draw),
                KeyEvent = Marshal.GetFunctionPointerForDelegate(surfaceEvents.KeyEvent),
                MouseCrossed = Marshal.GetFunctionPointerForDelegate(surfaceEvents.MouseCrossed),
                MouseEvent = Marshal.GetFunctionPointerForDelegate(surfaceEvents.MouseEvent)
            };

            IsScrollable = scrollable;
            if (scrollable)
                Handle = Libui.uiNewScrollingArea(EventHandler, width, height);
            else
                Handle = Libui.uiNewArea(EventHandler);
            Surfaces[Handle] = this;
        }

        internal Libui.uiAreaHandler EventHandler { get; }

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
                    Libui.uiAreaSetSize(this, value.Width, value.Height);
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
        public void QueueRedrawAll() => Libui.uiAreaQueueRedrawAll(this);

        /// <summary>
        /// Scrolls the surface view to the specified location and size.
        /// </summary>
        /// <param name="x">The x-coordinate.</param>
        /// <param name="y">The y-coordinate.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        public void ScrollTo(double x, double y, double width, double height) => Libui.uiAreaScrollTo(this, x, y, width, height);
        
        public void BeginUserWindowMove() => Libui.uiAreaBeginUserWindowMove(this);

        public void BeginUserWindowResize(WindowEdge edge) => Libui.uiAreaBeginUserWindowResize(this, edge);
    }
}