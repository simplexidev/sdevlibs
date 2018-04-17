using LibUISharp.Drawing;
using LibUISharp.Native.SafeHandles;
using System;
using System.Runtime.InteropServices;
using System.Text;
using static LibUISharp.Native.Libraries.LibuiLibrary;

namespace LibUISharp.Native
{
    internal static class LibuiConvert
    {
        #region IntPtr (UTF8) <=> string
        /// <summary>
        /// You must call System.Marshal.FreeHGlobal() after using this or it will cause a memory leak.
        /// </summary>summary
        public static IntPtr ToLibuiString(string str)
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

        public static string ToString(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
                return string.Empty;

            byte b = Marshal.ReadByte(ptr);
            int i = 0;
            while (b != 0)
                b = Marshal.ReadByte(ptr, ++i);

            byte[] bytes = new byte[i];
            Marshal.Copy(ptr, bytes, 0, bytes.Length);
            string str = Encoding.UTF8.GetString(bytes, 0, bytes.Length);
            uiFreeText(ptr);
            return str;
        }
        #endregion

        #region uiForEach <=> bool
        public static uiForEach ToLibuiForEach(bool forEach)
        {
            if (forEach)
                return uiForEach.uiForEachStop;
            else
                return uiForEach.uiForEachContinue;
        }

        public static bool ToBoolean(uiForEach forEach)
        {
            switch (forEach)
            {
                case uiForEach.uiForEachContinue:
                    return false;
                case uiForEach.uiForEachStop:
                    return true;
                default:
                    throw new ArgumentOutOfRangeException("forEach");
            }
        }
        #endregion

        #region uiAreaDrawParams => DrawEventArgs
        public static uiAreaDrawParams ToLibuiAreaDrawParams(DrawEventArgs args) => throw new NotSupportedException("This conversion is not supported.");

        public static DrawEventArgs ToDrawEventArgs(uiAreaDrawParams p) => new DrawEventArgs(new Context(new SafeControlHandle(p.Context)), new RectangleD(p.ClipX, p.ClipY, p.ClipWidth, p.ClipHeight), new SizeD(p.AreaWidth, p.AreaHeight));
        #endregion

        #region uiDrawMatrix <= Matrix
        public static uiDrawMatrix ToLibuiDrawMatrix(Matrix m) => new uiDrawMatrix()
        {
            M11 = m.M11,
            M12 = m.M12,
            M21 = m.M21,
            M22 = m.M22,
            M31 = m.M31,
            M32 = m.M32
        };

        public static Matrix ToMatrix(uiDrawMatrix m) => throw new NotSupportedException("This conversion is not supported.");
        #endregion

        #region uiDrawBrushGradientStop <= GradientStop
        public static uiDrawBrushGradientStop ToLibuiDrawBrushGradientStop(GradientStop g) => new uiDrawBrushGradientStop()
        {
            Pos = g.Position,
            R = g.Color.R,
            G = g.Color.G,
            B = g.Color.B,
            A = g.Color.A
        };

        public static GradientStop ToGradientStop(uiDrawBrushGradientStop g) => throw new NotSupportedException("This conversion is not supported.");
        #endregion

        #region uiFontDescriptor <=> Font
        public static uiFontDescriptor ToLibuiFontDescriptor(Font f)
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

        public static Font ToFont(uiFontDescriptor f) => new Font(ToString(f.Family), f.Size, (FontWeight)f.Weight, (FontStyle)f.Italic, (FontStretch)f.Stretch);
        #endregion

        #region uiDrawTextLayoutParams <= TextLayoutOptions
        public static uiDrawTextLayoutParams ToLibuiDrawTextLayourParams(TextLayoutOptions o) => new uiDrawTextLayoutParams()
        {
            String = o.Text.Handle.DangerousGetHandle(),
            DefaultFont = (uiFontDescriptor)o.DefaultFont,
            Width = o.Width,
            Align = (uiDrawTextAlign)o.Alignment
        };

        public static TextLayoutOptions ToTextLayoutOptions(uiDrawTextLayoutParams p) => throw new NotSupportedException("This conversion is not supported.");
        #endregion

        #region uiAreaMouseEvent => MouseEventArgs
        public static uiAreaMouseEvent ToLibuiAreaMouseEvent(MouseEventArgs e) => throw new NotSupportedException("This conversion is not supported.");

        public static MouseEventArgs ToMouseEventArgs(uiAreaMouseEvent e) => new MouseEventArgs(new PointD(e.X, e.Y), new SizeD(e.AreaWidth, e.AreaHeight), e.Up, e.Down, e.Count, (KeyModifierFlags)e.Modifiers, e.Held1To64);
        #endregion

        #region uiAreaKeyEventArgs => KeyEventArgs
        public static uiAreaKeyEvent ToLibuiAreaKeyEvent(KeyEventArgs args) => throw new NotSupportedException("This conversion is not supported.");

        public static KeyEventArgs ToKeyEventArgs(uiAreaKeyEvent e)
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
        #endregion

        #region uiAlign <=> Alignment
        public static void ToLibuiAligns(Alignment a, out uiAlign hAlign, out uiAlign vAlign)
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

        public static Alignment ToAlignment(uiAlign hAlign, uiAlign vAlign)
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
        #endregion
    }
}