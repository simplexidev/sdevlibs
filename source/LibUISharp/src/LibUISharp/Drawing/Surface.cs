using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using LibUISharp.Internal;

namespace LibUISharp.Drawing
{
    //TODO: Split into SurfaceBase, Surface, and ScrollableSurface.
    /// <summary>
    /// Represents a drawable surface.
    /// </summary>
    [NativeType("uiArea")]
    public class Surface : Control
    {
        protected private Dictionary<IntPtr, Surface> surfaceCache = new Dictionary<IntPtr, Surface>();
        private Size size;

        /// <summary>
        /// Initializes a new instance of the <see cref="Surface"/> class with the specified handler.
        /// </summary>
        /// <param name="events">The specified event handler.</param>
        /// <param name="scrollable">Whether this surface is scrollable or not.</param>
        /// <param name="width">The width of the scrollable surface.</param>
        /// <param name="height">The height of the scrollable surface.</param>
        public Surface(SurfaceHandler events, bool scrollable = false, int width = -1, int height = -1)
        {
            EventHandler = new NativeSurfaceHandler
            {
                Draw = (handler, surface, args) => events.Draw(surfaceCache[surface], ref args),
                MouseEvent = (handler, surface, args) => events.MouseEvent(surfaceCache[surface], ref args),
                MouseCrossed = (handler, surface, left) => events.MouseCrossed(surfaceCache[surface], left),
                DragBroken = (handler, surface) => events.DragBroken(surfaceCache[surface]),
                KeyEvent = (handler, surface, args) => events.KeyEvent(surfaceCache[surface], ref args)
            };

            IsScrollable = scrollable;
            if (scrollable)
                Handle = NativeCalls.NewScrollingArea(EventHandler, width, height);
            else
                Handle = NativeCalls.NewArea(EventHandler);
            surfaceCache[Handle] = this;
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
                    NativeCalls.AreaSetSize(Handle, value.Width, value.Height);
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
            NativeCalls.AreaQueueRedrawAll(Handle);
        }

        /// <summary>
        /// Scrolls the surface view to the specified location and size.
        /// </summary>
        /// <param name="x">The x-coordinate.</param>
        /// <param name="y">The y-coordinate.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        public void ScrollTo(double x, double y, double width, double height) => NativeCalls.AreaScrollTo(Handle, x, y, width, height);

        //TODO: Documentation.
        public void BeginUserWindowMove() => NativeCalls.AreaBeginUserWindowMove(Handle);

        //TODO: Documentation.
        public void BeginUserWindowResize(WindowEdge edge) => NativeCalls.AreaBeginUserWindowResize(Handle, edge);
    }

    /// <summary>
    /// Defines the events for a drawable surface.
    /// </summary>
    public abstract class SurfaceHandler
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
        /// <param name="left">The event data.</param>
        public virtual void MouseCrossed(Surface surface, bool left) { }

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

    [NativeType("uiAreaHandler")]
    [StructLayout(LayoutKind.Sequential)]
    internal struct NativeSurfaceHandler
    {
        private IntPtr draw;
        private IntPtr mouseEvent;
        private IntPtr mouseCrossed;
        private IntPtr dragBroken;
        private IntPtr keyEvent;

        public Action<IntPtr, IntPtr, DrawEventArgs> Draw
        {
            set => draw = Marshal.GetFunctionPointerForDelegate(value);
        }

        public Action<IntPtr, IntPtr, MouseEventArgs> MouseEvent
        {
            set => mouseEvent = Marshal.GetFunctionPointerForDelegate(value);
        }

        public Action< IntPtr, IntPtr, bool> MouseCrossed
        {
            set => mouseCrossed = Marshal.GetFunctionPointerForDelegate(value);
        }

        public Action<IntPtr, IntPtr> DragBroken
        {
            set => dragBroken = Marshal.GetFunctionPointerForDelegate(value);
        }

        public Func<IntPtr, IntPtr, KeyEventArgs, bool> KeyEvent
        {
            set => keyEvent = Marshal.GetFunctionPointerForDelegate(value);
        }
    }
}