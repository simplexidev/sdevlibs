using System.Collections.Generic;
using LibUISharp;
using LibUISharp.Drawing;

namespace HistogramDemo
{
    public sealed class SurfaceHandler : ISurfaceHandler
    {
        private readonly int ptRadius = 5;
        private readonly int xOffLeft, xOffRight, yOffTop, yOffBottom = 20;
        private Path path;
        private SolidBrush brush;
        private StrokeOptions strokeOptions = new StrokeOptions()
        {
            Cap = LineCap.Flat,
            Join = LineJoin.Miter,
            Thickness = 2,
            MiterLimit = 10.0
        };
        private ColorPicker colorPicker;
        private List<SpinBox> spinBoxes;
        private int curPt = -1;

        public SurfaceHandler(ColorPicker colorpicker, List<SpinBox> spinboxes)
        {
            colorPicker = colorpicker;
            spinBoxes = spinboxes;
        }

        public void Draw(SurfaceBase area, ref DrawEventArgs args)
        {
            brush = Brushes.White;
            path = new Path(FillMode.Winding);
            path.AddRectangle(new PointD(0.0, 0.0), args.AreaSize);
            path.End();
            args.Context.Fill(path, brush);
            path.Dispose();

            SizeD graphSize = GraphSize(args.AreaSize);
            
            brush = Brushes.Black;
            path = new Path(FillMode.Winding);
            path.NewFigure(xOffLeft, yOffTop);
            path.LineTo(xOffLeft, yOffTop + graphSize.Height);
            path.LineTo(xOffLeft + graphSize.Width, yOffTop + graphSize.Height);
            path.End();
            args.Context.Stroke(path, brush, strokeOptions);
            path.Dispose();

            Matrix matrix = Matrix.SetIdentity();
            matrix.Translate(xOffLeft, yOffTop);
            args.Context.Transform(matrix);
            
            brush = (SolidBrush)colorPicker.Color;
            double a = brush.Color.A;
            brush = new SolidBrush(new Color(brush.Color.R, brush.Color.G, brush.Color.B, brush.Color.A / 2.0));
            path = ConstructGraph(graphSize, true);
            args.Context.Fill(path, brush);
            path.Dispose();
            
            path = ConstructGraph(graphSize, false);
            brush = new SolidBrush(new Color(brush.Color.R, brush.Color.G, brush.Color.B, a));
            args.Context.Stroke(path, brush, strokeOptions);
            path.Dispose();

            if (curPt != -1)
            {
                PointD[] pts = PointLocations(graphSize);

                path = new Path(FillMode.Winding);
                path.NewFigureWithArc(pts[curPt], 5, 0, 6.23, false);
                path.End();
                args.Context.Fill(path, brush);

                path.Dispose();
            }
        }

        public void MouseEvent(SurfaceBase area, ref MouseEventArgs args)
        {
            SizeD graphSize = GraphSize(args.AreaSize);
            PointD[] pts = PointLocations(graphSize);

            int i;
            for (i = 0; i < 10; i++)
            {
                if (InPoint(args.Point, pts[i]))
                    break;
            }

            if (i == 10)
                i = -1;

            curPt = i;
            area.QueueRedrawAll();
        }

        public void MouseCrossed(SurfaceBase surface, MouseCrossedEventArgs args) { }
        public void DragBroken(SurfaceBase surface) { }
        public bool KeyEvent(SurfaceBase surface, ref KeyEventArgs args) => false;

        private SizeD GraphSize(SizeD clientSize) => new SizeD((clientSize.Width - xOffLeft - xOffRight), (clientSize.Height - yOffTop - yOffBottom));

        private Path ConstructGraph(SizeD size, bool extend)
        {
            PointD[] pts = PointLocations(size);

            Path path = new Path(FillMode.Winding);
            path.NewFigure(pts[0]);

            for (int i = 1; i < 10; i++)
            {
                path.LineTo(pts[i]);
            }

            if (extend)
            {
                path.LineTo(size.Width, size.Height);
                path.LineTo(0, size.Height);
                path.CloseFigure();
            }

            path.End();
            return path;
        }

        private PointD[] PointLocations(SizeD area)
        {
            PointD[] pts = new PointD[10];

            double xincr = area.Width / 9; // 10 - 1 to make the last point be at the end
            double yincr = area.Height / 100;

            for (int i = 0; i < 10; i++)
            {
                int n = spinBoxes[i].Value;
                n = 100 - n;
                pts[i] = new PointD((xincr * i), (yincr * n));
            }
            return pts;
        }

        private bool InPoint(PointD pt, PointD testPt)
        {
            pt.X -= xOffLeft;
            pt.Y -= xOffRight;
            return (pt.X >= testPt.X - ptRadius) && (pt.Y >= testPt.Y - ptRadius) && (pt.X <= testPt.X + ptRadius) && (pt.Y <= testPt.Y + ptRadius);
        }
    }
}