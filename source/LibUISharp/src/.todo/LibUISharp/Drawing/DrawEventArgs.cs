using System;

namespace LibUISharp.Drawing
{
    /// <summary>
    /// Provides drawing data for an event.
    /// </summary>
    public class DrawEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DrawEventArgs"/> class with the specified event data.
        /// </summary>
        /// <param name="context">The drawing context.</param>
        /// <param name="clip">The rectangle that has been requested to be redrawn.</param>
        /// <param name="surfaceSize">The current size of the surface.</param>
        public DrawEventArgs(Context context, RectangleD clip, SizeD surfaceSize)
        {
            Context = context;
            Clip = clip;
            SurfaceSize = surfaceSize;
        }

        /// <summary>
        /// Gets the drawing context.
        /// </summary>
        public Context Context { get; }

        /// <summary>
        /// Gets the clip to be redawn.
        /// </summary>
        public RectangleD Clip { get; }

        /// <summary>
        /// Gets the surface's current size.
        /// </summary>
        public SizeD SurfaceSize { get; }
    }
}