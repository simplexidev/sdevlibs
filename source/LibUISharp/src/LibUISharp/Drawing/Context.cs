using LibUISharp.Drawing.Text;
using LibUISharp.Internal;
using static LibUISharp.Internal.LibUI;

namespace LibUISharp.Drawing
{
    // uiDraw*
    public class Context
    {
        public Context(Surface surface) : this(surface.Handle) { }
        internal Context(LibUISafeHandle Handle) { }

        internal LibUISafeHandle Handle { get; }

        public void Stroke(Path path, Brush brush, StrokeOptions stroke) => uiDrawStroke(Handle, path.Handle, ref brush.Internal, ref stroke.Internal);

        public void Fill(Path path, Brush brush) => uiDrawFill(Handle, path.Handle, ref brush.Internal);

        public void Clip(Path path) => uiDrawClip(Handle, path.Handle);

        public void Save() => uiDrawSave(Handle);

        public void ReStore() => uiDrawRestore(Handle);

        public void Transform(Matrix matrix) => uiDrawTransform(Handle, (uiDrawMatrix)matrix);

        public void DrawText(double x, double y, TextLayout layout) => uiDrawText(Handle, layout.Handle, x, y);
    }
}