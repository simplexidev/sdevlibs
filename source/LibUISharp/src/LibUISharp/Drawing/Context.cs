using LibUISharp.Native;
using LibUISharp.Native.Libraries;
using LibUISharp.Native.SafeHandles;

// uiDrawContext
namespace LibUISharp.Drawing
{
    public sealed class Context
    {
        public Context(Surface surface) : this(surface.Handle) { }
        internal Context(LibuiSafeHandle Handle) { }

        internal LibuiSafeHandle Handle { get; }

        public void Stroke(Path path, Brush brush, StrokeOptions stroke) => LibuiLibrary.uiDrawStroke(Handle.DangerousGetHandle(), path.Handle.DangerousGetHandle(), ref brush.Internal, ref stroke.Internal);

        public void Fill(Path path, Brush brush) => LibuiLibrary.uiDrawFill(Handle.DangerousGetHandle(), path.Handle.DangerousGetHandle(), ref brush.Internal);

        public void Clip(Path path) => LibuiLibrary.uiDrawClip(Handle.DangerousGetHandle(), path.Handle.DangerousGetHandle());

        public void Save() => LibuiLibrary.uiDrawSave(Handle.DangerousGetHandle());

        public void Restore() => LibuiLibrary.uiDrawRestore(Handle.DangerousGetHandle());

        public void Transform(Matrix matrix) => LibuiLibrary.uiDrawTransform(Handle.DangerousGetHandle(), LibuiConvert.ToLibuiDrawMatrix(matrix));

        public void DrawText(TextLayout layout, double x, double y) => LibuiLibrary.uiDrawText(Handle.DangerousGetHandle(), layout.Handle.DangerousGetHandle(), x, y);
    }
}