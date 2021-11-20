using System.Collections.Generic;
using LibUISharp;
using LibUISharp.Drawing;

namespace LibUISharp.Demos.Histogram
{
    public class SurfaceHandler : ISurfaceHandler
    {
        private const int pointRadius = 5;
        private const int xoffLeft = 20;
        private const int yoffTop = 20;
        private const int xoffRight = 20;
        private const int yoffBottom = 20;

        private Path path;
        private SolidBrush brush;
        private StrokeOptions strokeOptions = new StrokeOptions()
        {
            Cap = LineCap.Flat,
            Join = LineJoin.Miter,
            Thickness = 2
        };

        private ColorPicker colorPicker;
        private List<SpinBox> spinBoxList;

        private int _currentPoint = -1;

        public SurfaceHandler(ColorPicker colorPicker, List<SpinBox> spinBoxes)
        {
            this.colorPicker = colorPicker;
            spinBoxList = spinBoxes;
        }

        public void Draw(Surface surface, ref DrawEventArgs e)
        {
            brush = Brushes.White;
            path = new Path(FillMode.Winding);
            path.AddRectangle(0.0, 0.0, e.SurfaceSize.Width, e.SurfaceSize.Height);
            path.End();
            e.Context.Fill(path, brush);
            path.Dispose();

            GraphSize(e.SurfaceSize.Width, e.SurfaceSize.Height, out double graphWidth, out double graphHeight);
            
            brush = Brushes.Black;
            path = new Path(FillMode.Winding);
            path.NewFigure(xoffLeft, yoffTop);
            path.LineTo(xoffLeft, yoffTop + graphHeight);
            path.LineTo(xoffLeft + graphWidth, yoffTop + graphHeight);
            path.End();
            e.Context.Stroke(path, brush, strokeOptions);
            path.Dispose();

            Matrix matrix = new Matrix();
            matrix.SetIdentity();
            matrix.Translate(xoffLeft, yoffTop);
            e.Context.Transform(matrix);

            brush = (SolidBrush)colorPicker.Color;
            double a = brush.Color.A;
            brush.Color = new Color(brush.Color.R, brush.Color.G, brush.Color.B, brush.Color.A / 2);
            path = ConstructGraph(graphWidth, graphHeight, true);
            e.Context.Fill(path, brush);
            path.Dispose();

            path = ConstructGraph(graphWidth, graphHeight, false);
            brush.Color = new Color(brush.Color.R, brush.Color.G, brush.Color.B, a);
            e.Context.Stroke(path, brush, strokeOptions);
            path.Dispose();

            if (_currentPoint != -1)
            {
                PointLocations(graphWidth, graphHeight, out double[] xs, out double[] ys);
                path = new Path(FillMode.Winding);
                path.NewFigureWithArc(xs[_currentPoint], ys[_currentPoint], 5, 0, 6.23, false);
                path.End();
                e.Context.Fill(path, brush);
                path.Dispose();
            }
        }

        private void GraphSize(double clientWidth, double clientHeight, out double graphWidth, out double graphHeight)
        {
            graphWidth = clientWidth - xoffLeft - xoffRight;
            graphHeight = clientHeight - yoffTop - yoffBottom;
        }

        private Path ConstructGraph(double width, double height, bool extend)
        {
            PointLocations(width, height, out double[] xs, out double[] ys);
            Path path = new Path(FillMode.Winding);
            path.NewFigure(xs[0], ys[0]);
            for (int i = 1; i < 10; i++)
            {
                path.LineTo(xs[i], ys[i]);
            }

            if (extend)
            {
                path.LineTo(width, height);
                path.LineTo(0, height);
                path.CloseFigure();
            }

            path.End();
            return path;
        }

        private void PointLocations(double width, double height, out double[] xs, out double[] ys)
        {
            double xincr = width / 9; // 10 - 1 to make the last point be at the end
            double yincr = height / 100;
            xs = new double[10];
            ys = new double[10];
            for (int i = 0; i < 10; i++)
            {
                int n = spinBoxList[i].Value;
                n = 100 - n;
                xs[i] = xincr * i;
                ys[i] = yincr * n;
            }
        }

        private bool InPoint(double x, double y, double xtest, double ytest)
        {
            Matrix m = new Matrix();
            m.SetIdentity();
            m.Translate(x -= xoffLeft, y -= yoffTop);
            return (x >= xtest - pointRadius) &&
                (x <= xtest + pointRadius) &&
                (y >= ytest - pointRadius) &&
                (y <= ytest + pointRadius);
        }

        public void MouseEvent(Surface surface, ref MouseEventArgs e)
        {
            GraphSize(e.SurfaceSize.Width, e.SurfaceSize.Height, out double graphWidth, out double graphHeight);
            PointLocations(graphWidth, graphHeight, out double[] xs, out double[] ys);

            int i;
            for (i = 0; i < 10; i++)
            {
                if (InPoint(e.Point.X, e.Point.Y, xs[i], ys[i]))
                    break;
            }
            if (i == 10)
                i = -1;
            _currentPoint = i;
            surface.QueueRedrawAll();
        }

        public bool KeyEvent(Surface surface, ref KeyEventArgs e) => false;
        public void MouseCrossed(Surface surface, MouseCrossedEventArgs e) { }
        public void DragBroken(Surface surface) { }
    }
}