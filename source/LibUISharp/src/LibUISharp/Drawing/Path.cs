using LibUISharp.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static LibUISharp.Internal.LibUI;

namespace LibUISharp.Drawing
{
    public class Path : IDisposable
    {
        private bool disposed = false;

        public Path(FillMode mode) => Handle = uiDrawNewPath(mode);

        internal PathSafeHandle Handle { get; set; }

        public void AddRectangle(double x, double y, double width, double height) => uiDrawPathAddRectangle(Handle, x, y, width, height);
        public void AddRectangle(PointD location, SizeD size) => AddRectangle(location.X, location.Y, size.Width, size.Height);
        public void AddRectangle(RectangleD rect) => AddRectangle(rect.Location, rect.Size);

        public void End() => uiDrawPathEnd(Handle);

        public void NewFigure(double x, double y) => uiDrawPathNewFigure(Handle, x, y);

        public void NewFigureWithArc(double xCenter, double yCenter, double radius, double startAngle, double sweep, bool negative) => uiDrawPathNewFigureWithArc(Handle, xCenter, yCenter, radius, startAngle, sweep, negative);

        public void CloseFigure() => uiDrawPathCloseFigure(Handle);

        public void LineTo(double x, double y) => uiDrawPathLineTo(Handle, x, y);

        public void ArcTo(double xCenter, double yCenter, double radius, double startAngle, double sweep, bool negative) => uiDrawPathArcTo(Handle, xCenter, yCenter, radius, startAngle, sweep, negative);

        public void BezierTo(double c1x, double c1y, double c2x, double c2y, double endX, double endY) => uiDrawPathBezierTo(Handle, c1x, c1y, c2x, c2y, endX, endY);
    }

    public enum FillMode : uint
    {
        Winding = 0,
        Alternate = 1
    }
}