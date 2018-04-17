using System;

namespace LibUISharp.Drawing
{
    public class MouseCrossedEventArgs : EventArgs
    {
        public MouseCrossedEventArgs(bool left) => Left = left;

        public bool Left { get; }
    }
}