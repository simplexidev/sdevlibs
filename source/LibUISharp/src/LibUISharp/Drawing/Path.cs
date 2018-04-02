using System;
using LibUISharp.Internal;
using static LibUISharp.Internal.LibUI;

namespace LibUISharp.Drawing
{
    // uiDrawPath
    public class Path : UIComponent
    {
        private bool disposed = false;

        public Path(FillMode mode) => Handle = uiDrawNewPath(mode);

        internal PathSafeHandle Handle { get; set; }

        public void NewFigure(double x, double y) => uiDrawPathNewFigure(Handle, x, y);
        public void NewFigure(PointD point) => NewFigure(point.X, point.Y);

        public void NewFigureWithArc(double xCenter, double yCenter, double radius, double startAngle, double sweep, bool negative) => uiDrawPathNewFigureWithArc(Handle, xCenter, yCenter, radius, startAngle, sweep, negative);
        public void NewFigureWithArc(PointD center, double radius, double startAngle, double sweep, bool negative) => NewFigureWithArc(center.X, center.Y, radius, startAngle, sweep, negative);

        public void LineTo(double x, double y) => uiDrawPathLineTo(Handle, x, y);
        public void LineTo(Point point) => LineTo(point.X, point.Y);

        public void ArcTo(double xCenter, double yCenter, double radius, double startAngle, double sweep, bool negative) => uiDrawPathArcTo(Handle, xCenter, yCenter, radius, startAngle, sweep, negative);
        public void ArcTo(PointD center, double radius, double startAngle, double sweep, bool negative) => ArcTo(center.X, center.Y, radius, startAngle, sweep, negative);

        public void BezierTo(double c1x, double c1y, double c2x, double c2y, double endX, double endY) => uiDrawPathBezierTo(Handle, c1x, c1y, c2x, c2y, endX, endY);
        public void BezierTo(PointD c1, PointD c2, PointD end) => BezierTo(c1.X, c1.Y, c2.X, c2.Y, end.X, end.Y);

        public void CloseFigure() => uiDrawPathCloseFigure(Handle);

        public void AddRectangle(double x, double y, double width, double height) => uiDrawPathAddRectangle(Handle, x, y, width, height);
        public void AddRectangle(PointD location, SizeD size) => AddRectangle(location.X, location.Y, size.Width, size.Height);
        public void AddRectangle(RectangleD rect) => AddRectangle(rect.Location, rect.Size);

        public void End() => uiDrawPathEnd(Handle);

        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                    if (!Handle.IsInvalid)
                        Handle.Dispose();
                disposed = true;
            }
        }

        public override void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}