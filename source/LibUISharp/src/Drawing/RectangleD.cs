using System;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;
using LibUISharp.Internal;

namespace LibUISharp.Drawing
{
    [StructLayout(LayoutKind.Sequential)]
    public struct RectangleD : IEquatable<RectangleD>, IComparable, IComparable<RectangleD>
    {
        public static readonly RectangleD Empty = new RectangleD(0, 0, 0, 0);

        public RectangleD(double x, double y, double width, double height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public RectangleD(PointD location, SizeD size) : this(location.X, location.Y, size.Width, size.Height) { }

        public double X { get; set; }
        public double Y { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }

        public double Left => X;
        public double Top => Y;
        public double Right => X + Width;
        public double Bottom => Y + Height;
        public bool IsEmpty => this == Empty;

        public PointD Location
        {
            get => new PointD(X, Y);
            set
            {
                X = value.X;
                Y = value.Y;
            }
        }

        public SizeD Size
        {
            get => new SizeD(Width, Height);
            set
            {
                Width = value.Width;
                Height = value.Height;
            }
        }

        public void Inflate(double width, double height)
        {
                X -= width;
                Y -= height;

                Width += 2 * width;
                Height += 2 * height;
        }

        public void Inflate(SizeD size) => Inflate(size.Width, size.Height);

        public static RectangleD Inflate(RectangleD rectangle, double x, double y)
        {
            RectangleD r = rectangle;
            r.Inflate(x, y);
            return r;
        }

        public void Intersect(RectangleD rectangle)
        {
            RectangleD result = Intersect(rectangle, this);

            X = result.X;
            Y = result.Y;
            Width = result.Width;
            Height = result.Height;
        }

        public static RectangleD Intersect(RectangleD a, RectangleD b)
        {
            double x1 = Math.Max(a.X, b.X);
            double x2 = Math.Min(a.X + a.Width, b.X + b.Width);
            double y1 = Math.Max(a.Y, b.Y);
            double y2 = Math.Min(a.Y + a.Height, b.Y + b.Height);

            if (x2 >= x1 && y2 >= y1)
                return new RectangleD(x1, y1, x2 - x1, y2 - y1);

            return Empty;
        }

        [Pure]
        public bool IntersectsWith(RectangleD rectangle) => (rectangle.X < X + Width) && (X < rectangle.X + rectangle.Width) && (rectangle.Y < Y + Height) && (Y < rectangle.Y + rectangle.Height);

        [Pure]
        public static RectangleD Union(RectangleD a, RectangleD b)
        {
            double x1 = Math.Min(a.X, b.X);
            double x2 = Math.Max(a.X + a.Width, b.X + b.Width);
            double y1 = Math.Min(a.Y, b.Y);
            double y2 = Math.Max(a.Y + a.Height, b.Y + b.Height);

            return new RectangleD(x1, y1, x2 - x1, y2 - y1);
        }

        public void Offset(double x, double y)
        {
            unchecked
            {
                X += x;
                Y += y;
            }
        }

        public void Offset(PointD pos) => Offset(pos.X, pos.Y);

        [Pure]
        public bool Contains(double x, double y) => (X <= x) && (x < X + Width) && (Y <= y) && (y < Y + Height);

        [Pure]
        public bool Contains(PointD point) => Contains(point.X, point.Y);

        [Pure]
        public bool Contains(RectangleD rectangle) => (X <= rectangle.X) && (rectangle.X + rectangle.Width <= X + Width) && (Y <= rectangle.Y) && (rectangle.Y + rectangle.Height <= Y + Height);

        public override bool Equals(object obj) => (obj is RectangleD) && (Equals((RectangleD)obj));
        public override string ToString() => $"[{X}, {Y}, {Width}, {Height}]";
        public override int GetHashCode() => unchecked(HashHelpers.Combine((int)X, (int)Y, (int)Width, (int)Height));

        public static bool operator ==(RectangleD left, RectangleD right) => (left.X == right.X) && (left.Y == right.Y) && (left.Width == right.Width) && (left.Height == right.Height);
        public static bool operator !=(RectangleD left, RectangleD right) => !(left == right);
        public static explicit operator RectangleD(Rectangle rectangle) => new RectangleD(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);

        #region IEquatable<RectangleD>
        public bool Equals(RectangleD other) => this == other;
        #endregion
        #region IComparable, IComparable<RectangleD>
        public int CompareTo(object obj)
        {
            if (obj is RectangleD)
                return CompareTo((RectangleD)obj);
            else return -1;
        }

        public int CompareTo(RectangleD other)
        {
            int result = X.CompareTo(other.X);
            if (result == 0)
            {
                result = Y.CompareTo(other.Y);
                if (result == 0)
                {
                    result = Width.CompareTo(other.Width);
                    if (result == 0)
                    {
                        result = Height.CompareTo(other.Height);
                    }
                }
            }
            return result;
        }
        #endregion
    }
}