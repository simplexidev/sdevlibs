using System;
using System.Runtime.InteropServices;
using LibUISharp.Internal;
using static LibUISharp.Internal.UI;

namespace LibUISharp.Drawing.Text
{
    public class TextLayout
    {
        public TextLayout(TextLayoutOptions options)
        {
            IntPtr strPtr = MarshalHelper.StringToUTF8(options.DefaultFont.Family);
            Handle = new UIAttributedTextHandle(uiDrawNewTextLayout(new uiDrawTextLayoutParams()
            {
                Text = options.Text.Handle.DangerousGetHandle(),
                DefaultFont = new uiDrawFontDescriptor()
                {
                    Family = strPtr,
                    Size = options.DefaultFont.Size,
                    Weight = options.DefaultFont.Weight,
                    Style = options.DefaultFont.Style,
                    Stretch = options.DefaultFont.Stretch
                },
                Width = options.Width,
                Align = options.Alignment
            }));
            Marshal.FreeHGlobal(strPtr);
        }

        protected internal UIAttributedTextHandle Handle { get; protected set; }

        public SizeD Extents
        {
            get
            {
                uiDrawTextLayoutExtents(Handle.DangerousGetHandle(), out double w, out double h);
                return new SizeD(w, h);
            }
        }

        public int LineCount => uiDrawTextLayoutNumLines(Handle.DangerousGetHandle());

        public virtual void LineByteRange(int line, out UIntPtr start, out UIntPtr end) => uiDrawTextLayoutLineByteRange(Handle.DangerousGetHandle(), line, out start, out end);

        public virtual LineMetrics GetMetrics(int line)
        {
            uiDrawTextLayoutLineGetMetrics(Handle.DangerousGetHandle(), line, out uiDrawTextLayoutLineMetrics m);
            return new LineMetrics(new RectangleD(m.X, m.Y, m.Width, m.Height), m.BaselineY, m.Ascent, m.Descent, m.Leading, m.ParagraphSpacingBefore, m.LineHeightSpace, m.LineSpacing, m.ParagraphSpacing);
        }

        public virtual void HitTest(PointD point, out UIntPtr pos, out int line) => uiDrawTextLayoutHitTest(Handle.DangerousGetHandle(), point.X, point.Y, out pos, out line);

        public virtual double ByteLocationInLine(UIntPtr pos, int line) => uiDrawTextLayoutByteLocationInLine(Handle.DangerousGetHandle(), pos, line);
    }

    public readonly struct TextLayoutOptions
    {
        public TextLayoutOptions(AttributedText text, Font font, double width, TextAlignment alignment)
        {
            Text = text;
            DefaultFont = font;
            Width = width;
            Alignment = alignment;
        }

        public AttributedText Text { get; }
        public Font DefaultFont { get; }
        public double Width { get; }
        public TextAlignment Alignment { get; }
    }

    public readonly struct LineMetrics
    {
        public LineMetrics(RectangleD bounds, double baselineY, double ascent, double descent, double leading, double paraSpaceBefore, double lineHeightSpace, double lineSpacing, double paraSpace)
        {
            Bounds = bounds;
            BaselineY = baselineY;
            Ascent = ascent;
            Descent = descent;
            Leading = leading;
            ParagraphSpacingBefore = paraSpaceBefore;
            LineHeightSpace = lineHeightSpace;
            LineSpacing = lineSpacing;
            ParagraphSpacing = paraSpace;
        }
        public RectangleD Bounds { get; }

        public double BaselineY { get; }
        public double Ascent { get; }
        public double Descent { get; }
        public double Leading { get; }

        public double ParagraphSpacingBefore { get; }
        public double LineHeightSpace { get; }
        public double LineSpacing { get; }
        public double ParagraphSpacing { get; }
    }
}