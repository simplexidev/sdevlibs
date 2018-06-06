using System;
using System.Runtime.InteropServices;
using static LibUISharp.Native.NativeMethods;

namespace LibUISharp.Drawing
{
    /// <summary>
    /// Represents a stroke to draw with.
    /// </summary>
    public class StrokeOptions
    {
        internal Libui.uiDrawStrokeParams Native = new Libui.uiDrawStrokeParams();
        private double[] dashes;

        /// <summary>
        /// The default miter limit.
        /// </summary>
        public const double DefaultMiterLimit = 10.0;

        /// <summary>
        /// Initializes a new instance of the <see cref="StrokeOptions"/> class.
        /// </summary>
        public StrokeOptions() => MiterLimit = DefaultMiterLimit;

        /// <summary>
        /// Gets or sets the style of cap at line ends.
        /// </summary>
        public LineCap Cap
        {
            get => Native.Cap;
            set => Native.Cap = value;
        }

        /// <summary>
        /// Gets or sets how two lines commecting at an angle should be joined.
        /// </summary>
        public LineJoin Join
        {
            get => Native.Join;
            set => Native.Join = value;
        }

        /// <summary>
        /// Gets or sets the thinkness of the stroke.
        /// </summary>
        public double Thickness
        {
            get => Native.Thickness;
            set => Native.Thickness = value;
        }

        /// <summary>
        /// Gets or sets how far to extend a line for the line join.
        /// </summary>
        public double MiterLimit
        {
            get => Native.MiterLimit;
            set => Native.MiterLimit = value;
        }

        /// <summary>
        /// Gets or sets the dashing style specified as an array of numbers.
        /// </summary>
        public double[] Dashes
        {
            get => dashes;
            set
            {
                if (value != null && value.Length != 0)
                {
                    int length = value.Length;
                    Native.Dashes = Marshal.UnsafeAddrOfPinnedArrayElement(value, 0);
                    Native.NumDashes = (UIntPtr)length;
                    dashes = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the offset to the dashes on the path.
        /// </summary>
        public double DashPhase
        {
            get => Native.DashPhase;
            set => Native.DashPhase = value;
        }
    }
}