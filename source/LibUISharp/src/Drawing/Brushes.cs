namespace LibUISharp.Drawing
{
    //TODO: Maybe add the "web colors" from corefx's System.Drawing.Primatives.
    public static class Brushes
    {
        public static SolidBrush Black => new SolidBrush(new Color(0xFF000000u));

        public static SolidBrush Blue => new SolidBrush(new Color(0xFF0000FFu));

        public static SolidBrush Cyan => new SolidBrush(new Color(0xFF00FFFFu));

        public static SolidBrush Grey => new SolidBrush(new Color(0xFF808080u));

        public static SolidBrush Green => new SolidBrush(new Color(0xFF008000u));

        public static SolidBrush Lime => new SolidBrush(new Color(0xFF00FF00u));

        public static SolidBrush Indigo => new SolidBrush(new Color(0xFF4B0082u));

        public static SolidBrush Magenta => new SolidBrush(new Color(0xFFFF00FFu));

        public static SolidBrush Maroon => new SolidBrush(new Color(0xFF800000u));

        public static SolidBrush Navy => new SolidBrush(new Color(0xFF000080u));

        public static SolidBrush Olive => new SolidBrush(new Color(0xFF808000u));

        public static SolidBrush Orange => new SolidBrush(new Color(0xFFFFA500u));

        public static SolidBrush Purple => new SolidBrush(new Color(0xFF800080u));

        public static SolidBrush Red => new SolidBrush(new Color(0xFFFF0000u));

        public static SolidBrush Silver => new SolidBrush(new Color(0xFFC0C0C0u));

        public static SolidBrush Teal => new SolidBrush(new Color(0xFF008080u));

        public static SolidBrush Yellow => new SolidBrush(new Color(0xFFFFFF00u));

        public static SolidBrush White => new SolidBrush(new Color(0xFFFFFFFFu));
    }
}