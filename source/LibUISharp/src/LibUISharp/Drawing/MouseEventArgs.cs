using System;

namespace LibUISharp.Drawing
{
    public class MouseEventArgs : EventArgs
    {
        public MouseEventArgs(PointD point, SizeD surfaceSize, bool up, bool down, int count, ModifierKey keyModifiers, long held1To64)
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
        public ModifierKey KeyModifiers { get; }
        public long Held1To64 { get; }
    }
}