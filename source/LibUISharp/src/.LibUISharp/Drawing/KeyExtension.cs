namespace LibUISharp.Drawing
{
    // uiExtKey
    public enum KeyExtension : uint
    {
        Escape = 1,
        Insert = 2, // Equivalent to "Help" on Apple keyboards.
        Delete = 3,
        Home = 4,
        End = 5,
        PageUp = 6,
        PageDown = 7,
        Up = 8,
        Down = 9,
        Left = 10,
        Right = 11,
        // F1..F12 are guaranteed to be consecutive.
        F1 = 12, 
        F2 = 13,
        F3 = 14,
        F4 = 15,
        F5 = 16,
        F6 = 17,
        F7 = 18,
        F8 = 19,
        F9 = 20,
        F10 = 21,
        F11 = 22,
        F12 = 23,
        // Number pad keys are independent of number lock.
        // N0..N9 are guaranteed to be consecutive.
        N0 = 24,
        N1 = 25,
        N2 = 26,
        N3 = 27,
        N4 = 28,
        N5 = 29,
        N6 = 30,
        N7 = 31,
        N8 = 32,
        N9 = 33,
        NDot = 34,
        NEnter = 35,
        NAdd = 36,
        NSubtract = 37,
        NMultiply = 38,
        NDivide =39
    }
}