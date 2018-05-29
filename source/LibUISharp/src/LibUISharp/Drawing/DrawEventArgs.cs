using System;

// uiAreaDrawParams
namespace LibUISharp.Drawing
{
    public class DrawEventArgs : EventArgs
    {
        public DrawEventArgs(Context context, RectangleD clip, SizeD surfaceSize)
        {
            Context = context;
            Clip = clip;
            SurfaceSize = surfaceSize;
        }

        public Context Context { get; }
        public RectangleD Clip { get; }
        public SizeD SurfaceSize { get; }
    }
}