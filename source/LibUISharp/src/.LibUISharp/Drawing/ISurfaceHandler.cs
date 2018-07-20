using System;
using System.Runtime.InteropServices;
using static LibUISharp.Native.NativeMethods;

namespace LibUISharp.Drawing
{
    public class SurfaceHandler_
    {
        public virtual void Draw(Surface surface, ref DrawEventArgs args) { }
    }
    /// <summary>
    /// Defines the events for a drawable surface.
    /// </summary>
    public interface ISurfaceHandler
    {
        /// <summary>
        /// Called when the surface is created or resized.
        /// </summary>
        /// <param name="surface">The surface.</param>
        /// <param name="args">The event data.</param>
        void Draw(Surface surface, ref DrawEventArgs args);

        /// <summary>
        /// Called when the mouse is moved or clicked over the surface.
        /// </summary>
        /// <param name="surface">The surface.</param>
        /// <param name="args">The event data.</param>
        void MouseEvent(Surface surface, ref MouseEventArgs args);

        /// <summary>
        /// Called when the mouse entered or left the surface.
        /// </summary>
        /// <param name="surface">The surface.</param>
        /// <param name="args">The event data.</param>
        void MouseCrossed(Surface surface, MouseCrossedEventArgs args);

        /// <summary>
        /// Called when a mouse drag is ended. (Windows only)
        /// </summary>
        /// <param name="surface">The surface.</param>
        void DragBroken(Surface surface);

        /// <summary>
        /// Called when a key is pressed.
        /// </summary>
        /// <param name="surface">The surface.</param>
        /// <param name="args">The event data.</param>
        bool KeyEvent(Surface surface, ref KeyEventArgs args);
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void DrawHandler(IntPtr handler, IntPtr surface, [In, Out]ref Libui.uiAreaDrawParams param);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void MouseEventHandler(IntPtr handler, IntPtr surface, [In, Out]ref Libui.uiAreaMouseEvent mouseEvent);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void MouseCrossedHandler(IntPtr handler, IntPtr surface, bool left);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void DragBrokenHandler(IntPtr handler, IntPtr surface);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate bool KeyEventHandler(IntPtr handler, IntPtr surface, [In, Out]ref Libui.uiAreaKeyEvent keyEvent);

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