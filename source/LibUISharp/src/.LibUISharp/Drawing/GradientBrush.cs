using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using static LibUISharp.Native.NativeMethods;

namespace LibUISharp.Drawing
{
    /// <summary>
    /// An abstract class that describes a gradient, composed of gradient stops. Classes that inherit from <see cref="GradientBrush"/> describe different ways of interpreting gradient stops.
    /// </summary>
    public abstract class GradientBrush : Brush
    {
        // linear: start X
        // radial: start X
        private protected double X0
        {
            get => Native.X0;
            set => Native.X0 = value;
        }

        // linear: start Y
        // radial: start Y
        private protected double Y0
        {
            get => Native.Y0;
            set => Native.Y0 = value;
        }

        // linear: end X
        // radial: outer circle center X
        private protected double X1
        {
            get => Native.X1;
            set => Native.X1 = value;
        }

        // linear: end Y
        // radial: outer circle center Y
        private protected double Y1
        {
            get => Native.Y1;
            set => Native.Y1 = value;
        }

        /// <summary>
        /// Gets or sets the brush's gradient stops.
        /// </summary>
        public IList<GradientStop> GradientStops
        {
            set
            {
                if (value != null && value.Count != 0)
                {
                    Libui.uiDrawBrushGradientStop[] stops = new Libui.uiDrawBrushGradientStop[value.Count];
                    for (int i = 0; i < value.Count - 1; i++)
                    {
                        stops[i] = value[i].ToUIGradientBrush();
                    }
                    Native.NumStops = (UIntPtr)value.Count;
                    Native.Stops = Marshal.UnsafeAddrOfPinnedArrayElement(stops, 0);
                }
            }
        }
    }
}