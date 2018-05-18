using System;

// uiAreaMouseEvent
namespace LibUISharp.Drawing
{
    public class MouseEventArgs : EventArgs
    {
        public MouseEventArgs(PointD point, SizeD areaSize, bool up, bool down, int count, KeyModifierFlags keyModifiers, ulong held1To64)
        {
            Point = point;
            AreaSize = areaSize;
            Up = up;
            Down = down;
            Count = count;
            KeyModifiers = keyModifiers;
            Held1To64 = held1To64;
        }

        public PointD Point { get; }
        public SizeD AreaSize { get; }
        public bool Up { get; }
        public bool Down { get; }
        public int Count { get; }
        public KeyModifierFlags KeyModifiers { get; }
        public ulong Held1To64 { get; }
    }
}