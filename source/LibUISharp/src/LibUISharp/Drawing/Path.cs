using LibUISharp.Internal;
using LibUISharp.SafeHandles;
using System;

// uiDrawPath
namespace LibUISharp.Drawing
{
    /// <summary>
    /// Represents a geometric path in a <see cref="Context"/>.
    /// </summary>
    public class Path : LibuiComponent<SafePathHandle>
    {
        private bool disposed = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="Path"/> class with the specified <see cref="FillMode"/>.
        /// </summary>
        /// <param name="mode">The <see cref="FillMode"/> specifying how the initialized <see cref="Path"/> should be filled.</param>
        public Path(FillMode mode) => Handle = new SafePathHandle(LibuiLibrary.uiDrawNewPath((LibuiLibrary.uiDrawFillMode)mode));

        /// <inheritdoc/>
        protected internal override SafePathHandle Handle { get; private protected set; }

        /// <summary>
        /// Starts a new figure in this <see cref="Path"/> with the specified current x- and y-coordinates.
        /// </summary>
        /// <param name="x">The current x-coordinate.</param>
        /// <param name="y">The current y-coordinate.</param>
        public void NewFigure(double x, double y) => LibuiLibrary.uiDrawPathNewFigure(Handle.DangerousGetHandle(), x, y);

        /// <summary>
        /// Starts a new figure in this <see cref="Path"/> with the specified current point.
        /// </summary>
        /// <param name="point"></param>
        public void NewFigure(PointD point) => NewFigure(point.X, point.Y);

        public void NewFigureWithArc(double xCenter, double yCenter, double radius, double startAngle, double sweep, bool negative) => LibuiLibrary.uiDrawPathNewFigureWithArc(Handle.DangerousGetHandle(), xCenter, yCenter, radius, startAngle, sweep, negative);
        public void NewFigureWithArc(PointD center, double radius, double startAngle, double sweep, bool negative) => NewFigureWithArc(center.X, center.Y, radius, startAngle, sweep, negative);

        public void LineTo(double x, double y) => LibuiLibrary.uiDrawPathLineTo(Handle.DangerousGetHandle(), x, y);
        public void LineTo(PointD point) => LineTo(point.X, point.Y);

        public void ArcTo(double xCenter, double yCenter, double radius, double startAngle, double sweep, bool negative) => LibuiLibrary.uiDrawPathArcTo(Handle.DangerousGetHandle(), xCenter, yCenter, radius, startAngle, sweep, negative);
        public void ArcTo(PointD center, double radius, double startAngle, double sweep, bool negative) => ArcTo(center.X, center.Y, radius, startAngle, sweep, negative);

        public void BezierTo(double c1x, double c1y, double c2x, double c2y, double endX, double endY) => LibuiLibrary.uiDrawPathBezierTo(Handle.DangerousGetHandle(), c1x, c1y, c2x, c2y, endX, endY);
        public void BezierTo(PointD c1, PointD c2, PointD end) => BezierTo(c1.X, c1.Y, c2.X, c2.Y, end.X, end.Y);

        public void CloseFigure() => LibuiLibrary.uiDrawPathCloseFigure(Handle.DangerousGetHandle());

        public void AddRectangle(double x, double y, double width, double height) => LibuiLibrary.uiDrawPathAddRectangle(Handle.DangerousGetHandle(), x, y, width, height);
        public void AddRectangle(PointD location, SizeD size) => AddRectangle(location.X, location.Y, size.Width, size.Height);
        public void AddRectangle(RectangleD rect) => AddRectangle(rect.Location, rect.Size);

        /// <summary>
        /// Ends this <see cref="Path"/>.
        /// </summary>
        public void End() => LibuiLibrary.uiDrawPathEnd(Handle.DangerousGetHandle());

        /// <inheritdoc/>
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

        /// <inheritdoc/>
        public override void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}