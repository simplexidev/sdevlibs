namespace LibUISharp.Drawing
{
    public struct Rectangle
    {
        public Rectangle(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public Rectangle(Point location, Size size) : this(location.X, location.Y, size.Width, size.Height) { }

        public static readonly Rectangle Empty = new Rectangle();

        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Point Location
        {
            get => new Point(X, Y);
            set
            {
                if (X != value.X)
                    X = value.X;
                if (Y != value.Y)
                    Y = value.Y;
            }
        }
        public Size Size
        {
            get => new Size(Width, Height);
            set
            {
                if (Width != value.Width)
                    Width = value.Width;
                if (Height != value.Height)
                    Height = value.Height;
            }
        }

        public bool IsEmpty => this == Empty;

        public override bool Equals(object obj)
        {
            if (!(obj is Rectangle))
                return false;
            return Equals((Rectangle)obj);
        }

        public bool Equals(Rectangle rect) => X == rect.X && Y == rect.Y && Width == rect.Width && Height == rect.Height;
        public override int GetHashCode() => unchecked(this.GetHashCode(X, Y, Width, Height));

        public static bool operator ==(Rectangle rect1, Rectangle rect2) => rect1.Equals(rect2);
        public static bool operator !=(Rectangle rect1, Rectangle rect2) => !(rect1 == rect2);
    }

    public struct RectangleD
    {
        public RectangleD(double x, double y, double width, double height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public RectangleD(PointD location, SizeD size) : this(location.X, location.Y, size.Width, size.Height) { }

        public static readonly RectangleD Empty = new RectangleD();

        public double X { get; set; }
        public double Y { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }

        public PointD Location
        {
            get => new PointD(X, Y);
            set
            {
                if (X != value.X)
                    X = value.X;
                if (Y != value.Y)
                    Y = value.Y;
            }
        }
        public SizeD Size
        {
            get => new SizeD(Width, Height);
            set
            {
                if (Width != value.Width)
                    Width = value.Width;
                if (Height != value.Height)
                    Height = value.Height;
            }
        }

        public bool IsEmpty => this == Empty;

        public override bool Equals(object obj)
        {
            if (!(obj is RectangleD))
                return false;
            return Equals((RectangleD)obj);
        }

        public bool Equals(RectangleD rect) => X == rect.X && Y == rect.Y && Width == rect.Width && Height == rect.Height;
        public override int GetHashCode() => unchecked(this.GetHashCode(X, Y, Width, Height));

        public static bool operator ==(RectangleD rect1, RectangleD rect2) => rect1.Equals(rect2);
        public static bool operator !=(RectangleD rect1, RectangleD rect2) => !(rect1 == rect2);
    }
}