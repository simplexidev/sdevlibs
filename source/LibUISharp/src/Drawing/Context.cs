using System;
using System.Runtime.InteropServices;
using LibUISharp.Drawing.Text;
using LibUISharp.Internal;
using static LibUISharp.Internal.UI;

namespace LibUISharp.Drawing
{
    public class Context
    {
        public Context(UIHandle handle) => Handle = new UIDrawHandle(handle);

        protected internal UIDrawHandle Handle { get; protected set; }

        public void Fill(Path path, Brush brush) => uiDrawFill(Handle.DangerousGetHandle(), path.Handle.DangerousGetHandle(), ref brush.Internal);

        public void Stroke(Path path, Brush brush, StrokeOptions param) => uiDrawStroke(Handle.DangerousGetHandle(), path.Handle.DangerousGetHandle(), ref brush.Internal, ref param.Internal);

        public void Clip(Path path) => uiDrawClip(Handle.DangerousGetHandle(), path.Handle.DangerousGetHandle());

        public void Save() => uiDrawSave(Handle.DangerousGetHandle());

        public void Restore() => uiDrawRestore(Handle.DangerousGetHandle());

        public void Transform(Matrix matrix) => uiDrawTransform(Handle.DangerousGetHandle(), matrix.Internal);

        public void DrawText(TextLayout layout, double x, double y) => uiDrawText(Handle.DangerousGetHandle(), layout.Handle.DangerousGetHandle(), x, y);
    }

    public class StrokeOptions
    {
        public const double DefaultMiterLimit = 10.0;

        public StrokeOptions() => MiterLimit = DefaultMiterLimit;

        internal uiDrawStrokeParams Internal = new uiDrawStrokeParams();

        public double[] Dashes
        {
            set
            {
                if (value != null && value.Length != 0)
                {
                    int length = value.Length;
                    Internal.Dashes = Marshal.UnsafeAddrOfPinnedArrayElement(value, 0);
                    Internal.NumDashes = (UIntPtr)length;
                }
            }
        }

        public LineCap LineCap
        {
            get => Internal.LineCap;
            set => Internal.LineCap = value;
        }

        public LineJoin LineJoin
        {
            get => Internal.LineJoin;
            set => Internal.LineJoin = value;
        }

        public double Thickness
        {
            get => Internal.Thickness;
            set => Internal.Thickness = value;
        }

        public double MiterLimit
        {
            get => Internal.MiterLimit;
            set => Internal.MiterLimit = value;
        }

        public double DashPhase
        {
            get => Internal.DashPhase;
            set => Internal.DashPhase = value;
        }
    }
}