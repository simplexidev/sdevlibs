using System;
using LibUISharp.Internal;
using static LibUISharp.Internal.Libraries;

namespace LibUISharp.Drawing
{
    /// <summary>
    /// Represents a geometric path in a <see cref="Context"/>.
    /// </summary>
    [NativeType("uiDrawPath")]
    public class Path : UIComponent
    {
        private bool disposed = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="Path"/> class with the specified <see cref="FillMode"/>.
        /// </summary>
        /// <param name="mode">The <see cref="FillMode"/> specifying how the initialized <see cref="Path"/> should be filled.</param>
        public Path(FillMode mode) => Handle = Libui.Call<Libui.uiDrawNewPath>()(mode);

        /// <summary>
        /// Starts a new figure in this <see cref="Path"/> with the specified current x- and y-coordinates.
        /// </summary>
        /// <param name="x">The current x-coordinate.</param>
        /// <param name="y">The current y-coordinate.</param>
        public void NewFigure(double x, double y) => Libui.Call<Libui.uiDrawPathNewFigure>()(this, x, y);

        /// <summary>
        /// Starts a new figure in this <see cref="Path"/> with the specified current point.
        /// </summary>
        /// <param name="point"></param>
        public void NewFigure(PointD point) => NewFigure(point.X, point.Y);

        /// <summary>
        /// Starts a new figure in this <see cref="Path"/> and adds an arc.
        /// </summary>
        /// <param name="xCenter">The x-coordinate of the center <see cref="Point"/>.</param>
        /// <param name="yCenter">The y-coordinate of the center <see cref="Point"/>.</param>
        /// <param name="radius">The radius of the arc.</param>
        /// <param name="startAngle">The starting angle fpr the arc.</param>
        /// <param name="sweep">The sweep angle.</param>
        /// <param name="negative">Whether the sweep angle should go clockwise (<see langword="false"/>), or counterclockwise (<see langword="true"/>).</param>
        public void NewFigureWithArc(double xCenter, double yCenter, double radius, double startAngle, double sweep, bool negative = false) => Libui.Call<Libui.uiDrawPathNewFigureWithArc>()(this, xCenter, yCenter, radius, startAngle, sweep, negative);

        /// <summary>
        /// Starts a new figure in this <see cref="Path"/> and adds an arc.
        /// </summary>
        /// <param name="center">The center point of the arc.</param>
        /// <param name="radius">The radius of the arc.</param>
        /// <param name="startAngle">The starting angle fpr the arc.</param>
        /// <param name="sweep">The sweep angle.</param>
        /// <param name="negative">Whether the sweep angle should go clockwise (<see langword="false"/>), or counterclockwise (<see langword="true"/>).</param>
        public void NewFigureWithArc(PointD center, double radius, double startAngle, double sweep, bool negative) => NewFigureWithArc(center.X, center.Y, radius, startAngle, sweep, negative);

        /// <summary>
        /// Connects the last point in the subpath to the specified location with a straight line.
        /// </summary>
        /// <param name="x">The x-coordinate of the location.</param>
        /// <param name="y">The y-corrdinate of the location</param>
        public void LineTo(double x, double y) => Libui.Call<Libui.uiDrawPathLineTo>()(this, x, y);

        /// <summary>
        /// Connects the last point in the subpath to the specified location with a straight line.
        /// </summary>
        /// <param name="point">The location coordinates.</param>
        public void LineTo(PointD point) => LineTo(point.X, point.Y);

        /// <summary>
        /// Adds an arc to this <see cref="Path"/>.
        /// </summary>
        /// <param name="xCenter">The x-coordinate of the center <see cref="Point"/>.</param>
        /// <param name="yCenter">The y-coordinate of the center <see cref="Point"/>.</param>
        /// <param name="radius">The radius of the arc.</param>
        /// <param name="startAngle">The starting angle fpr the arc.</param>
        /// <param name="sweep">The sweep angle.</param>
        /// <param name="negative">Whether the sweep angle should go clockwise (<see langword="false"/>), or counterclockwise (<see langword="true"/>).</param>
        public void ArcTo(double xCenter, double yCenter, double radius, double startAngle, double sweep, bool negative) => Libui.Call<Libui.uiDrawPathArcTo>()(this, xCenter, yCenter, radius, startAngle, sweep, negative);

        /// <summary>
        /// Adds an arc to this <see cref="Path"/>.
        /// </summary>
        /// <param name="center">The center point of the arc.</param>
        /// <param name="radius">The radius of the arc.</param>
        /// <param name="startAngle">The starting angle fpr the arc.</param>
        /// <param name="sweep">The sweep angle.</param>
        /// <param name="negative">Whether the sweep angle should go clockwise (<see langword="false"/>), or counterclockwise (<see langword="true"/>).</param>
        public void ArcTo(PointD center, double radius, double startAngle, double sweep, bool negative) => ArcTo(center.X, center.Y, radius, startAngle, sweep, negative);

        /// <summary>
        /// Adds a cubic bezier curve to this <see cref="Path"/>, with the starting point being the last point in the <see cref="Path"/>.
        /// </summary>
        /// <param name="c1x">The x-coordinate of the first control point.</param>
        /// <param name="c1y">The y-coordinate of the first control point.</param>
        /// <param name="c2x">The x-coordinate of the second control point.</param>
        /// <param name="c2y">The y-coordinate of the second control point.</param>
        /// <param name="endX">The x-coordinate of the end point.</param>
        /// <param name="endY">The y-coordinate of the end point.</param>
        public void BezierTo(double c1x, double c1y, double c2x, double c2y, double endX, double endY) => Libui.Call<Libui.uiDrawPathBezierTo>()(this, c1x, c1y, c2x, c2y, endX, endY);

        /// <summary>
        /// Adds a cubic bezier curve to this <see cref="Path"/>, with the starting point being the last point in the <see cref="Path"/>.
        /// </summary>
        /// <param name="c1">The first control point.</param>
        /// <param name="c2">The second control point.</param>
        /// <param name="end">The end point.</param>
        public void BezierTo(PointD c1, PointD c2, PointD end) => BezierTo(c1.X, c1.Y, c2.X, c2.Y, end.X, end.Y);

        /// <summary>
        /// Causes the point of the pen to move back to the start of the current subpath, trying to fraw a straight line from the current point to the start.
        /// </summary>
        public void CloseFigure() => Libui.Call<Libui.uiDrawPathCloseFigure>()(this);

        /// <summary>
        /// Creates a <see cref="Path"/> for a rectangle at the specified location with the specified size.
        /// </summary>
        /// <param name="x">The x-coordinate of the rectangle.</param>
        /// <param name="y">The y-coordinate of the rectangle.</param>
        /// <param name="width">The width of the rectangle.</param>
        /// <param name="height">The height of the rectangle.</param>
        public void AddRectangle(double x, double y, double width, double height) => Libui.Call<Libui.uiDrawPathAddRectangle>()(this, x, y, width, height);

        /// <summary>
        /// Creates a <see cref="Path"/> for a rectangle at the specified location with the specified size.
        /// </summary>
        /// <param name="location">The location of the rectangle.</param>
        /// <param name="size">The size of the rectangle.</param>
        public void AddRectangle(PointD location, SizeD size) => AddRectangle(location.X, location.Y, size.Width, size.Height);

        /// <summary>
        /// Creates a <see cref="Path"/> for a rectangle at the specified location with the specified size.
        /// </summary>
        /// <param name="rect">The rectangle to create.</param>
        public void AddRectangle(RectangleD rect) => AddRectangle(rect.Location, rect.Size);

        /// <summary>
        /// Ends this <see cref="Path"/>, leaving the figure open.
        /// </summary>
        public void End() => Libui.Call<Libui.uiDrawPathEnd>()(this);

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <param name="disposing">Whether or not this control is disposing.</param>
        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing && Handle != IntPtr.Zero)
                    Libui.Call<Libui.uiDrawFreePath>()(this);
                disposed = true;
                base.Dispose(disposing);
            }
        }
    }
}