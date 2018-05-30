using System;

// uiAreaMouseEvent
namespace LibUISharp.Drawing
{
    public class MouseEventArgs : EventArgs
    {
        public MouseEventArgs(PointD point, SizeD surfaceSize, bool up, bool down, int count, KeyModifierFlags keyModifiers, long held1To64)
        {
            Point = point;
            SurfaceSize = surfaceSize;
            Up = up;
            Down = down;
            Count = count;
            KeyModifiers = keyModifiers;
            Held1To64 = held1To64;
        }

        public PointD Point { get; }
        public SizeD SurfaceSize { get; }
        public bool Up { get; }
        public bool Down { get; }
        public int Count { get; }
        public KeyModifierFlags KeyModifiers { get; }
        public long Held1To64 { get; }
    }
}