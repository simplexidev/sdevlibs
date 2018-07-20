using static LibUISharp.Native.NativeMethods;

namespace LibUISharp.Drawing
{
    /// <summary>
    /// Defines objects used to paint graphical objects. Classes that derive from <see cref="Brush"/> describe how the area is painted.
    /// </summary>
    public abstract class Brush
    {
        internal Libui.uiDrawBrush Native = new Libui.uiDrawBrush();

        internal Libui.uiDrawBrushType BrushType
        {
            get => Native.Type;
            protected private set => Native.Type = value;
        }
    }
}