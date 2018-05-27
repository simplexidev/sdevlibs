using LibUISharp.Drawing;
using LibUISharp.SafeHandles;
using System;
using System.Runtime.InteropServices;
using System.Text;
using static LibUISharp.Internal.LibuiLibrary;

namespace LibUISharp.Internal
{
    internal static class LibuiConversionExtensions
    {
        // string => IntPtr
        /// <summary>
        /// You must call <see cref="Marshal.FreeHGlobal()"/> after using this or it will cause a memory leak.
        /// </summary>
        public static IntPtr ToLibuiString(this string str)
        {
            if (str == null)
                return IntPtr.Zero;

            byte[] bytes = Encoding.UTF8.GetBytes(str);
            Array.Resize(ref bytes, bytes.Length + 1);
            bytes[bytes.Length - 1] = 0;
            IntPtr ptr = Marshal.AllocHGlobal(bytes.Length);
            Marshal.Copy(bytes, 0, ptr, bytes.Length);
            return ptr;
        }

        // IntPtr => string
        // Suffixed with "Ex" since you can't overload methods using extensions (or I don't know how anyways)
        public static string ToStringEx(this IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
                return string.Empty;

            byte b = Marshal.ReadByte(ptr);
            int i = 0;
            while (b != 0)
                b = Marshal.ReadByte(ptr, ++i);

            byte[] bytes = new byte[i];
            Marshal.Copy(ptr, bytes, 0, bytes.Length);
            string s = Encoding.UTF8.GetString(bytes, 0, bytes.Length);
            uiFreeText(ptr);
            return s;
        }

        // bool => uiForEach
        public static uiForEach ToLibuiForEach(this bool b)
        {
            if (b)
                return uiForEach.uiForEachStop;
            else
                return uiForEach.uiForEachContinue;
        }

        // uiForEach => bool
        public static bool ToBool(this uiForEach forEach)
        {
            switch (forEach)
            {
                case uiForEach.uiForEachContinue:
                    return false;
                case uiForEach.uiForEachStop:
                    return true;
                default:
                    throw new ArgumentOutOfRangeException(nameof(forEach));
            }
        }

        // uiAreaDrawParams => DrawEventArgs
        public static DrawEventArgs ToDrawEventArgs(this uiAreaDrawParams p) => new DrawEventArgs(new Context(new SafeControlHandle(p.Context)), new RectangleD(p.ClipX, p.ClipY, p.ClipWidth, p.ClipHeight), new SizeD(p.AreaWidth, p.AreaHeight));

        // Matrix => uiDrawMatrix
        public static uiDrawMatrix ToLibuiDrawMatrix(this Matrix m) => new uiDrawMatrix()
        {
            M11 = m.M11,
            M12 = m.M12,
            M21 = m.M21,
            M22 = m.M22,
            M31 = m.M31,
            M32 = m.M32
        };

        // GradientStop => uiDrawBrushGradientStop
        public static uiDrawBrushGradientStop ToLibuiDrawBrushGradientStop(this GradientStop g) => new uiDrawBrushGradientStop()
        {
            Pos = g.Position,
            R = g.Color.R,
            G = g.Color.G,
            B = g.Color.B,
            A = g.Color.A
        };

        // Font => uiFontDescriptor
        public static uiFontDescriptor ToLibuiFontDescriptor(this Font f)
        {
            IntPtr strPtr = ToLibuiString(f.Family);
            try
            {
                return new uiFontDescriptor
                {
                    Family = strPtr,
                    Size = f.Size,
                    Weight = (uiTextWeight)f.Weight,
                    Italic = (uiTextItalic)f.Style,
                    Stretch = (uiTextStretch)f.Weight
                };
            }
            finally
            {
                Marshal.FreeHGlobal(strPtr);
            }
        }

        // uiFontDescriptor => Font
        public static Font ToFont(this uiFontDescriptor f) => new Font(f.Family.ToStringEx(), f.Size, (FontWeight)f.Weight, (FontStyle)f.Italic, (FontStretch)f.Stretch);

        // TextLayoutOptions => uiDrawTextLayoutParams
        public static uiDrawTextLayoutParams ToLibuiDrawTextLayoutParams(this TextLayoutOptions o) => new uiDrawTextLayoutParams()
        {
            String = o.Text.Handle.DangerousGetHandle(),
            DefaultFont = ToLibuiFontDescriptor(o.DefaultFont),
            Width = o.Width,
            Align = (uiDrawTextAlign)o.Alignment
        };
 
        // uiAreaMouseEvent => MouseEventArgs
        public static MouseEventArgs ToMouseEventArgs(this uiAreaMouseEvent e) => new MouseEventArgs(new PointD(e.X, e.Y), new SizeD(e.AreaWidth, e.AreaHeight), e.Up, e.Down, e.Count, (KeyModifierFlags)e.Modifiers, e.Held1To64);

        // uiAreaKeyEvent => KeyEventArgs
        public static KeyEventArgs ToKeyEventArgs(this uiAreaKeyEvent e)
        {
            KeyModifierFlags m = 0;
            if (e.Modifier.HasFlag(uiModifiers.uiModifierCtrl) || e.Modifiers.HasFlag(uiModifiers.uiModifierCtrl))
                m |= KeyModifierFlags.Ctrl;
            if (e.Modifier.HasFlag(uiModifiers.uiModifierAlt) || e.Modifiers.HasFlag(uiModifiers.uiModifierAlt))
                m |= KeyModifierFlags.Alt;
            if (e.Modifier.HasFlag(uiModifiers.uiModifierShift) || e.Modifiers.HasFlag(uiModifiers.uiModifierShift))
                m |= KeyModifierFlags.Shift;
            if (e.Modifier.HasFlag(uiModifiers.uiModifierSuper) || e.Modifiers.HasFlag(uiModifiers.uiModifierSuper))
                m |= KeyModifierFlags.Super;

            return new KeyEventArgs(e.Key, (KeyExtension)e.ExtKey, m, e.Up);
        }

        public static void ToLibuiAligns(this Alignment a, out uiAlign hAlign, out uiAlign vAlign)
        {
            switch (a)
            {
                case Alignment.Fill:
                    vAlign = uiAlign.uiAlignFill;
                    hAlign = uiAlign.uiAlignFill;
                    break;
                case Alignment.Center:
                    vAlign = uiAlign.uiAlignCenter;
                    hAlign = uiAlign.uiAlignCenter;
                    break;
                case Alignment.Top:
                    vAlign = uiAlign.uiAlignStart;
                    hAlign = uiAlign.uiAlignFill;
                    break;
                case Alignment.TopLeft:
                    vAlign = uiAlign.uiAlignStart;
                    hAlign = uiAlign.uiAlignStart;
                    break;
                case Alignment.TopCenter:
                    vAlign = uiAlign.uiAlignStart;
                    hAlign = uiAlign.uiAlignCenter;
                    break;
                case Alignment.TopRight:
                    vAlign = uiAlign.uiAlignStart;
                    hAlign = uiAlign.uiAlignEnd;
                    break;
                case Alignment.Left:
                    vAlign = uiAlign.uiAlignFill;
                    hAlign = uiAlign.uiAlignStart;
                    break;
                case Alignment.LeftCenter:
                    vAlign = uiAlign.uiAlignCenter;
                    hAlign = uiAlign.uiAlignStart;
                    break;
                case Alignment.Right:
                    vAlign = uiAlign.uiAlignFill;
                    hAlign = uiAlign.uiAlignEnd;
                    break;
                case Alignment.RightCenter:
                    vAlign = uiAlign.uiAlignCenter;
                    hAlign = uiAlign.uiAlignEnd;
                    break;
                case Alignment.Bottom:
                    vAlign = uiAlign.uiAlignEnd;
                    hAlign = uiAlign.uiAlignFill;
                    break;
                case Alignment.BottomLeft:
                    vAlign = uiAlign.uiAlignEnd;
                    hAlign = uiAlign.uiAlignStart;
                    break;
                case Alignment.BottomCenter:
                    vAlign = uiAlign.uiAlignEnd;
                    hAlign = uiAlign.uiAlignCenter;
                    break;
                case Alignment.BottomRight:
                    vAlign = uiAlign.uiAlignEnd;
                    hAlign = uiAlign.uiAlignEnd;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("hAlign|vAlign");
            }
        }

        public static Alignment FromLibuiAligns(this Alignment a, uiAlign hAlign, uiAlign vAlign)
        {
            if (vAlign == uiAlign.uiAlignFill && hAlign == uiAlign.uiAlignFill)
                return Alignment.Fill;
            else if (vAlign == uiAlign.uiAlignCenter && hAlign == uiAlign.uiAlignCenter)
                return Alignment.Center;
            else if (vAlign == uiAlign.uiAlignStart && hAlign == uiAlign.uiAlignFill)
                return Alignment.Top;
            else if (vAlign == uiAlign.uiAlignStart && hAlign == uiAlign.uiAlignStart)
                return Alignment.TopLeft;
            else if (vAlign == uiAlign.uiAlignStart && hAlign == uiAlign.uiAlignCenter)
                return Alignment.TopCenter;
            else if (vAlign == uiAlign.uiAlignStart && hAlign == uiAlign.uiAlignEnd)
                return Alignment.TopRight;
            else if (vAlign == uiAlign.uiAlignFill && hAlign == uiAlign.uiAlignStart)
                return Alignment.Left;
            else if (vAlign == uiAlign.uiAlignCenter && hAlign == uiAlign.uiAlignStart)
                return Alignment.LeftCenter;
            else if (vAlign == uiAlign.uiAlignFill && hAlign == uiAlign.uiAlignEnd)
                return Alignment.Right;
            else if (vAlign == uiAlign.uiAlignCenter && hAlign == uiAlign.uiAlignEnd)
                return Alignment.RightCenter;
            else if (vAlign == uiAlign.uiAlignEnd && hAlign == uiAlign.uiAlignFill)
                return Alignment.Bottom;
            else if (vAlign == uiAlign.uiAlignEnd && hAlign == uiAlign.uiAlignStart)
                return Alignment.BottomLeft;
            else if (vAlign == uiAlign.uiAlignEnd && hAlign == uiAlign.uiAlignCenter)
                return Alignment.BottomCenter;
            else if (vAlign == uiAlign.uiAlignEnd && hAlign == uiAlign.uiAlignEnd)
                return Alignment.BottomRight;
            else
                throw new ArgumentOutOfRangeException("hAlign|vAlign");
        }

#if LIBUI_4_0
        public static tm ToLibuiDateTime(this DateTime dt) => new tm()
        {
            tm_isdst = -1,
            tm_hour = dt.Hour,
            tm_min = dt.Minute,
            tm_sec = dt.Second,
            tm_mday = dt.Day,
            tm_mon = dt.Month,
            tm_year = dt.Year
        };

        public static DateTime ToDateTime(this tm dt) => new DateTime(dt.tm_year, dt.tm_mon, dt.tm_mday, dt.tm_hour, dt.tm_min, dt.tm_sec);
#endif
    }
}