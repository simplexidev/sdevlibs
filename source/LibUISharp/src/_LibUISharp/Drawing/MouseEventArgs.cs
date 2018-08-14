using System;
using System.Runtime.InteropServices;
using LibUISharp.Internal;

namespace LibUISharp.Drawing
{
    //TODO: This needs documentation.
    [NativeType("uiAreaMouseEvent")]
    [StructLayout(LayoutKind.Sequential)]
    public sealed class MouseEventArgs
    {
#pragma warning disable IDE0044 // Add readonly modifier
#pragma warning disable IDE0032 // Use auto property
        private double x, y, width, height;
        private bool up, down;
        private int count;
        private ModifierKey modifiers;
        private long held;
#pragma warning restore IDE0032 // Use auto property
#pragma warning restore IDE0044 // Add readonly modifier

        public MouseEventArgs(double x, double y, double surfaceWidth, double surfaceHeight, bool up, bool down, int count, ModifierKey modifiers, long held)
        {
            this.x = x;
            this.y = y;
            width = surfaceWidth;
            height = surfaceHeight;
            this.up = up;
            this.down = down;
            this.count = count;
            this.modifiers = modifiers;
            this.held = held;
        }

        public MouseEventArgs(PointD point, SizeD surfaceSize, bool up, bool down, int count, ModifierKey modifiers, long held) : this(point.X, point.Y, surfaceSize.Width, surfaceSize.Height, up, down, count, modifiers, held) { }

        public PointD Point => new PointD(x, y);
        public SizeD SurfaceSize => new SizeD(width, height);
        public bool Up => up;
        public bool Down => down;
        public int Count => count;
        public ModifierKey KeyModifiers => modifiers;
        public long Held1To64 => held;
    }
}