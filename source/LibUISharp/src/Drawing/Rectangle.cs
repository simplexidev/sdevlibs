using System;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;
using LibUISharp.Internal;

namespace LibUISharp.Drawing
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Rectangle : IEquatable<Rectangle>, IComparable, IComparable<Rectangle>
    {
        public static readonly Rectangle Empty = new Rectangle(0, 0, 0, 0);

        public Rectangle(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public Rectangle(Point location, Size size) : this(location.X, location.Y, size.Width, size.Height) { }

        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public int Left => X;
        public int Top => Y;
        public int Right => unchecked(X + Width);
        public int Bottom => unchecked(Y + Height);
        public bool IsEmpty => this == Empty;

        public Point Location
        {
            get => new Point(X, Y);
            set
            {
                X = value.X;
                Y = value.Y;
            }
        }

        public Size Size
        {
            get => new Size(Width, Height);
            set
            {
                Width = value.Width;
                Height = value.Height;
            }
        }

        public static Rectangle Ceiling(RectangleD value) => new Rectangle((int)Math.Ceiling(value.X), (int)Math.Ceiling(value.Y), (int)Math.Ceiling(value.Width), (int)Math.Ceiling(value.Height));
        public static Rectangle Truncate(RectangleD value) => new Rectangle((int)Math.Truncate(value.X), (int)Math.Truncate(value.Y), (int)Math.Truncate(value.Width), (int)Math.Truncate(value.Height));
        public static Rectangle Round(RectangleD value) => new Rectangle((int)Math.Round(value.X), (int)Math.Round(value.Y), (int)Math.Round(value.Width), (int)Math.Round(value.Height));

        public void Inflate(int width, int height)
        {
            unchecked
            {
                X -= width;
                Y -= height;

                Width += 2 * width;
                Height += 2 * height;
            }
        }

        public void Inflate(Size size) => Inflate(size.Width, size.Height);

        public static Rectangle Inflate(Rectangle rectangle, int x, int y)
        {
            Rectangle r = rectangle;
            r.Inflate(x, y);
            return r;
        }

        public void Intersect(Rectangle rectangle)
        {
            Rectangle result = Intersect(rectangle, this);

            X = result.X;
            Y = result.Y;
            Width = result.Width;
            Height = result.Height;
        }

        public static Rectangle Intersect(Rectangle a, Rectangle b)
        {
            int x1 = Math.Max(a.X, b.X);
            int x2 = Math.Min(a.X + a.Width, b.X + b.Width);
            int y1 = Math.Max(a.Y, b.Y);
            int y2 = Math.Min(a.Y + a.Height, b.Y + b.Height);

            if (x2 >= x1 && y2 >= y1)
                return new Rectangle(x1, y1, x2 - x1, y2 - y1);

            return Empty;
        }

        [Pure]
        public bool IntersectsWith(Rectangle rectangle) => (rectangle.X < X + Width) && (X < rectangle.X + rectangle.Width) && (rectangle.Y < Y + Height) && (Y < rectangle.Y + rectangle.Height);

        [Pure]
        public static Rectangle Union(Rectangle a, Rectangle b)
        {
            int x1 = Math.Min(a.X, b.X);
            int x2 = Math.Max(a.X + a.Width, b.X + b.Width);
            int y1 = Math.Min(a.Y, b.Y);
            int y2 = Math.Max(a.Y + a.Height, b.Y + b.Height);

            return new Rectangle(x1, y1, x2 - x1, y2 - y1);
        }

        public void Offset(int x, int y)
        {
            unchecked
            {
                X += x;
                Y += y;
            }
        }

        public void Offset(Point pos) => Offset(pos.X, pos.Y);

        [Pure]
        public bool Contains(int x, int y) => (X <= x) && (x < X + Width) && (Y <= y) && (y < Y + Height);

        [Pure]
        public bool Contains(Point point) => Contains(point.X, point.Y);

        [Pure]
        public bool Contains(Rectangle rectangle) => (X <= rectangle.X) && (rectangle.X + rectangle.Width <= X + Width) && (Y <= rectangle.Y) && (rectangle.Y + rectangle.Height <= Y + Height);

        public override bool Equals(object obj) => (obj is Rectangle) && (Equals((Rectangle)obj));
        public override string ToString() => $"[{X}, {Y}, {Width}, {Height}]";
        public override int GetHashCode() => unchecked(HashHelpers.Combine(X, Y, Width, Height));

        public static bool operator ==(Rectangle left, Rectangle right) => (left.X == right.X) && (left.Y == right.Y) && (left.Width == right.Width) && (left.Height == right.Height);
        public static bool operator !=(Rectangle left, Rectangle right) => !(left == right);

        #region IEquatable<Rectangle>
        public bool Equals(Rectangle other) => this == other;
        #endregion
        #region IComparable, IComparable<Rectangle>
        public int CompareTo(object obj)
        {
            if (obj is Rectangle)
                return CompareTo((Rectangle)obj);
            else return -1;
        }

        public int CompareTo(Rectangle other)
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