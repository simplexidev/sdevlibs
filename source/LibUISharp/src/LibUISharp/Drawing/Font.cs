namespace LibUISharp.Drawing
{
    // uiFontDescriptor
    public readonly struct Font
    {
        public Font(string family, double size, FontWeight weight = FontWeight.Normal, FontItalic italic = FontItalic.Normal, FontStretch stretch = FontStretch.Normal)
        {
            Family = family;
            Size = size;
            Weight = weight;
            Italic = italic;
            Stretch = stretch;
        }

        public string Family { get; }
        public double Size { get; }
        public FontWeight Weight { get; }
        public FontItalic Italic { get; }
        public FontStretch Stretch { get; }
    }
}