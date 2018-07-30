using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using LibUISharp.Internal;

namespace LibUISharp.Drawing
{
    /// <summary>
    /// Represents a stroke to draw with.
    /// </summary>
    [NativeType("uiDrawBrush")]
    [Serializable]
    [StructLayout(Libraries.Libui.StructLayout)]
    public class StrokeOptions
    {
#pragma warning disable IDE0044 // Add readonly modifier
#pragma warning disable IDE0032 // Use auto property
        private LineCap cap;
        private LineJoin join;
        private double thickness, miterLimit;
        private IntPtr dashesPtr;
        private UIntPtr numDashes;
        private double dashPhase;
#pragma warning restore IDE0044 // Add readonly modifier
#pragma warning restore IDE0032 // Use auto property

        private List<double> dashes;

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
            get => cap;
            set => cap = value;
        }

        /// <summary>
        /// Gets or sets how two lines connecting at an angle should be joined.
        /// </summary>
        public LineJoin Join
        {
            get => join;
            set => join = value;
        }

        /// <summary>
        /// Gets or sets the thinkness of the stroke.
        /// </summary>
        public double Thickness
        {
            get => thickness;
            set => thickness = value;
        }

        /// <summary>
        /// Gets or sets how far to extend a line for the line join.
        /// </summary>
        public double MiterLimit
        {
            get => miterLimit;
            set => miterLimit = value;
        }

        /// <summary>
        /// Gets or sets the dashing style specified as an array of numbers.
        /// </summary>
        public List<double> Dashes
        {
            get => dashes;
            set
            {
                if (value != null && value.Count != 0)
                {
                    int length = value.Count;
                    dashesPtr = Marshal.UnsafeAddrOfPinnedArrayElement(value.ToArray(), 0);
                    numDashes = (UIntPtr)length;
                    dashes = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the offset to the dashes on the path.
        /// </summary>
        public double DashPhase
        {
            get => dashPhase;
            set => dashPhase = value;
        }
    }
}