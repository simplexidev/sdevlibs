using LibUISharp.Internal;
using static LibUISharp.Internal.UI;

namespace LibUISharp.Drawing
{
    public class Path
    {
        public Path(FillMode mode) => Handle = new UIPathHandle(uiDrawNewPath(mode));

        protected internal UIPathHandle Handle { get; protected set; }

        public void AddRectangle(double x, double y, double width, double height) => uiDrawPathAddRectangle(Handle.DangerousGetHandle(), x, y, width, height);
        public void AddRectangle(PointD point, SizeD size) => AddRectangle(point.X, point.Y, size.Width, size.Height);
        public void AddRectangle(RectangleD rect) => AddRectangle(rect.Location, rect.Size);

        public void End() => uiDrawPathEnd(Handle.DangerousGetHandle());

        public void NewFigure(double x, double y) => uiDrawPathNewFigure(Handle.DangerousGetHandle(), x, y);
        public void NewFigure(PointD point) => NewFigure(point.X, point.Y);

        public void NewFigureWithArc(double xCenter, double yCenter, double radius, double startAngle, double sweep, bool negative) => uiDrawPathNewFigureWithArc(Handle.DangerousGetHandle(), xCenter, yCenter, radius, startAngle, sweep, negative);
        public void NewFigureWithArc(PointD center, double radius, double startAngle, double sweep, bool negative) => NewFigureWithArc(center.X, center.Y, radius, startAngle, sweep, negative);

        public void CloseFigure() =>  uiDrawPathCloseFigure(Handle.DangerousGetHandle());

        public void LineTo(double x, double y) => uiDrawPathLineTo(Handle.DangerousGetHandle(), x, y);
        public void LineTo(PointD point) => LineTo(point.X, point.Y);

        public void ArcTo(double xCenter, double yCenter, double radius, double startAngle, double sweep, bool negative) => uiDrawPathArcTo(Handle.DangerousGetHandle(), xCenter, yCenter, radius, startAngle, sweep, negative);
        public void ArcTo(PointD center, double radius, double startAngle, double sweep, bool negative) => ArcTo(center.X, center.Y, radius, startAngle, sweep, negative);

        public void BezierTo(double c1x, double c1y, double c2x, double c2y, double endX, double endY) => uiDrawPathBezierTo(Handle.DangerousGetHandle(), c1x, c1y, c2x, c2y, endX, endY);
        public void BexierTo(PointD curve1, PointD curve2, PointD endPoint) => BezierTo(curve1.X, curve1.Y, curve2.X, curve2.Y, endPoint.X, endPoint.Y);
    }
}