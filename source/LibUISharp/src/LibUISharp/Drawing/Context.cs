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

        public void Stroke(Path path, Brush brush, BrushStroke stroke)
        {
            uiDrawStrokeParams sp = (uiDrawStrokeParams)stroke;
            uiDrawStroke(Handle, path.Handle, ref brush.Internal, ref sp);
        }

        public void Fill(Path path, Brush brush) => uiDrawFill(Handle, path.Handle, ref brush.Internal);

        public void Clip(Path path) => uiDrawClip(Handle, path.Handle);

        public void Save() => uiDrawSave(Handle);

        public void ReStore() => uiDrawRestore(Handle);

        public void Transform(Matrix matrix) => uiDrawTransform(Handle, (uiDrawMatrix)matrix);

        public void DrawText(double x, double y, TextLayout layout) => uiDrawText(Handle, layout.Handle, x, y);
    }

    // uiDrawStrokeParams
    public struct BrushStroke
    {
        public BrushStroke(LineCap cap, LineJoin join, double thickness, double miterLimit, double[] dashes, double dashPhase)
        {
            Cap = cap;
            Join = join;
            Thickness = thickness;
            MiterLimit = miterLimit;
            Dashes = dashes;
            DashCount = (uint)Dashes.Length;
            DashPhase = dashPhase;
        }

        public LineCap Cap { get; }
        public LineJoin Join { get; }
        public double Thickness { get; }
        public double MiterLimit { get; }
        public double[] Dashes { get; }
        public uint DashCount { get; }
        public double DashPhase { get; }
    }
}