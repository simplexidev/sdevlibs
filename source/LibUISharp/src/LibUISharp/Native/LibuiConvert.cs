using LibUISharp.Controls;
using LibUISharp.Drawing;
using LibUISharp.Native.Libraries;
using LibUISharp.Native.SafeHandles;
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace LibUISharp.Native
{
    internal static class LibuiConvert
    {
        #region IntPtr (UTF8) <=> string
        /// <summary>
        /// You must call System.Marshal.FreeHGlobal() after using this or it will cause a memory leak.
        /// </summary>
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
            LibuiLibrary.uiFreeText(ptr);
            return str;
        }
        #endregion

        #region uiForEach <=> bool
        public static LibuiLibrary.uiForEach ToLibuiForEach(bool forEach)
        {
            if (forEach)
                return LibuiLibrary.uiForEach.uiForEachStop;
            else
                return LibuiLibrary.uiForEach.uiForEachContinue;
        }

        public static bool ToBoolean(LibuiLibrary.uiForEach forEach)
        {
            switch (forEach)
            {
                case LibuiLibrary.uiForEach.uiForEachContinue:
                    return false;
                case LibuiLibrary.uiForEach.uiForEachStop:
                    return true;
                default:
                    throw new ArgumentOutOfRangeException("forEach");
            }
        }
        #endregion

        #region uiAreaDrawParams => DrawEventArgs
        public static LibuiLibrary.uiAreaDrawParams ToLibuiAreaDrawParams(DrawEventArgs args) => throw new NotSupportedException("This conversion is not supported.");

        public static DrawEventArgs ToDrawEventArgs(LibuiLibrary.uiAreaDrawParams p) => new DrawEventArgs(new Context(new SafeControlHandle(p.Context)), new RectangleD(p.ClipX, p.ClipY, p.ClipWidth, p.ClipHeight), new SizeD(p.AreaWidth, p.AreaHeight));
        #endregion

        #region uiDrawMatrix <= Matrix
        public static LibuiLibrary.uiDrawMatrix ToLibuiDrawMatrix(Matrix m) => new LibuiLibrary.uiDrawMatrix()
        {
            M11 = m.M11,
            M12 = m.M12,
            M21 = m.M21,
            M22 = m.M22,
            M31 = m.M31,
            M32 = m.M32
        };

        public static Matrix ToMatrix(LibuiLibrary.uiDrawMatrix m) => throw new NotSupportedException("This conversion is not supported.");
        #endregion

        #region uiDrawBrushGradientStop <= GradientStop
        public static LibuiLibrary.uiDrawBrushGradientStop ToLibuiDrawBrushGradientStop(GradientStop g) => new LibuiLibrary.uiDrawBrushGradientStop()
        {
            Pos = g.Position,
            R = g.Color.R,
            G = g.Color.G,
            B = g.Color.B,
            A = g.Color.A
        };

        public static GradientStop ToGradientStop(LibuiLibrary.uiDrawBrushGradientStop g) => throw new NotSupportedException("This conversion is not supported.");
        #endregion

        #region uiFontDescriptor <=> Font
        public static LibuiLibrary.uiFontDescriptor ToLibuiFontDescriptor(Font f)
        {
            IntPtr strPtr = ToLibuiString(f.Family);
            try
            {
                return new LibuiLibrary.uiFontDescriptor
                {
                    Family = strPtr,
                    Size = f.Size,
                    Weight = (LibuiLibrary.uiTextWeight)f.Weight,
                    Italic = (LibuiLibrary.uiTextItalic)f.Style,
                    Stretch = (LibuiLibrary.uiTextStretch)f.Weight
                };
            }
            finally
            {
                Marshal.FreeHGlobal(strPtr);
            }
        }

        public static Font ToFont(LibuiLibrary.uiFontDescriptor f) => new Font(ToString(f.Family), f.Size, (FontWeight)f.Weight, (FontStyle)f.Italic, (FontStretch)f.Stretch);
        #endregion

        #region uiDrawTextLayoutParams <= TextLayoutOptions
        public static LibuiLibrary.uiDrawTextLayoutParams ToLibuiDrawTextLayourParams(TextLayoutOptions o) => new LibuiLibrary.uiDrawTextLayoutParams()
        {
            String = o.Text.Handle.DangerousGetHandle(),
            DefaultFont = ToLibuiFontDescriptor(o.DefaultFont),
            Width = o.Width,
            Align = (LibuiLibrary.uiDrawTextAlign)o.Alignment
        };

        public static TextLayoutOptions ToTextLayoutOptions(LibuiLibrary.uiDrawTextLayoutParams p) => throw new NotSupportedException("This conversion is not supported.");
        #endregion

        #region uiAreaMouseEvent => MouseEventArgs
        public static LibuiLibrary.uiAreaMouseEvent ToLibuiAreaMouseEvent(MouseEventArgs e) => throw new NotSupportedException("This conversion is not supported.");

        public static MouseEventArgs ToMouseEventArgs(LibuiLibrary.uiAreaMouseEvent e) => new MouseEventArgs(new PointD(e.X, e.Y), new SizeD(e.AreaWidth, e.AreaHeight), e.Up, e.Down, e.Count, (KeyModifierFlags)e.Modifiers, e.Held1To64);
        #endregion

        #region uiAreaKeyEventArgs => KeyEventArgs
        public static LibuiLibrary.uiAreaKeyEvent ToLibuiAreaKeyEvent(KeyEventArgs args) => throw new NotSupportedException("This conversion is not supported.");

        public static KeyEventArgs ToKeyEventArgs(LibuiLibrary.uiAreaKeyEvent e)
        {
            KeyModifierFlags m = 0;
            if (e.Modifier.HasFlag(LibuiLibrary.uiModifiers.uiModifierCtrl) || e.Modifiers.HasFlag(LibuiLibrary.uiModifiers.uiModifierCtrl))
                m |= KeyModifierFlags.Ctrl;
            if (e.Modifier.HasFlag(LibuiLibrary.uiModifiers.uiModifierAlt) || e.Modifiers.HasFlag(LibuiLibrary.uiModifiers.uiModifierAlt))
                m |= KeyModifierFlags.Alt;
            if (e.Modifier.HasFlag(LibuiLibrary.uiModifiers.uiModifierShift) || e.Modifiers.HasFlag(LibuiLibrary.uiModifiers.uiModifierShift))
                m |= KeyModifierFlags.Shift;
            if (e.Modifier.HasFlag(LibuiLibrary.uiModifiers.uiModifierSuper) || e.Modifiers.HasFlag(LibuiLibrary.uiModifiers.uiModifierSuper))
                m |= KeyModifierFlags.Super;

            return new KeyEventArgs(e.Key, (KeyExtension)e.ExtKey, m, e.Up);
        }
        #endregion

        #region uiAlign <=> Alignment
        public static void ToLibuiAligns(Alignment a, out LibuiLibrary.uiAlign hAlign, out LibuiLibrary.uiAlign vAlign)
        {
            switch (a)
            {
                case Alignment.Fill:
                    vAlign = LibuiLibrary.uiAlign.uiAlignFill;
                    hAlign = LibuiLibrary.uiAlign.uiAlignFill;
                    break;
                case Alignment.Center:
                    vAlign = LibuiLibrary.uiAlign.uiAlignCenter;
                    hAlign = LibuiLibrary.uiAlign.uiAlignCenter;
                    break;
                case Alignment.Top:
                    vAlign = LibuiLibrary.uiAlign.uiAlignStart;
                    hAlign = LibuiLibrary.uiAlign.uiAlignFill;
                    break;
                case Alignment.TopLeft:
                    vAlign = LibuiLibrary.uiAlign.uiAlignStart;
                    hAlign = LibuiLibrary.uiAlign.uiAlignStart;
                    break;
                case Alignment.TopCenter:
                    vAlign = LibuiLibrary.uiAlign.uiAlignStart;
                    hAlign = LibuiLibrary.uiAlign.uiAlignCenter;
                    break;
                case Alignment.TopRight:
                    vAlign = LibuiLibrary.uiAlign.uiAlignStart;
                    hAlign = LibuiLibrary.uiAlign.uiAlignEnd;
                    break;
                case Alignment.Left:
                    vAlign = LibuiLibrary.uiAlign.uiAlignFill;
                    hAlign = LibuiLibrary.uiAlign.uiAlignStart;
                    break;
                case Alignment.LeftCenter:
                    vAlign = LibuiLibrary.uiAlign.uiAlignCenter;
                    hAlign = LibuiLibrary.uiAlign.uiAlignStart;
                    break;
                case Alignment.Right:
                    vAlign = LibuiLibrary.uiAlign.uiAlignFill;
                    hAlign = LibuiLibrary.uiAlign.uiAlignEnd;
                    break;
                case Alignment.RightCenter:
                    vAlign = LibuiLibrary.uiAlign.uiAlignCenter;
                    hAlign = LibuiLibrary.uiAlign.uiAlignEnd;
                    break;
                case Alignment.Bottom:
                    vAlign = LibuiLibrary.uiAlign.uiAlignEnd;
                    hAlign = LibuiLibrary.uiAlign.uiAlignFill;
                    break;
                case Alignment.BottomLeft:
                    vAlign = LibuiLibrary.uiAlign.uiAlignEnd;
                    hAlign = LibuiLibrary.uiAlign.uiAlignStart;
                    break;
                case Alignment.BottomCenter:
                    vAlign = LibuiLibrary.uiAlign.uiAlignEnd;
                    hAlign = LibuiLibrary.uiAlign.uiAlignCenter;
                    break;
                case Alignment.BottomRight:
                    vAlign = LibuiLibrary.uiAlign.uiAlignEnd;
                    hAlign = LibuiLibrary.uiAlign.uiAlignEnd;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("hAlign|vAlign");
            }
        }

        public static Alignment ToAlignment(LibuiLibrary.uiAlign hAlign, LibuiLibrary.uiAlign vAlign)
        {
            if (vAlign == LibuiLibrary.uiAlign.uiAlignFill && hAlign == LibuiLibrary.uiAlign.uiAlignFill)
                return Alignment.Fill;
            else if (vAlign == LibuiLibrary.uiAlign.uiAlignCenter && hAlign == LibuiLibrary.uiAlign.uiAlignCenter)
                return Alignment.Center;
            else if (vAlign == LibuiLibrary.uiAlign.uiAlignStart && hAlign == LibuiLibrary.uiAlign.uiAlignFill)
                return Alignment.Top;
            else if (vAlign == LibuiLibrary.uiAlign.uiAlignStart && hAlign == LibuiLibrary.uiAlign.uiAlignStart)
                return Alignment.TopLeft;
            else if (vAlign == LibuiLibrary.uiAlign.uiAlignStart && hAlign == LibuiLibrary.uiAlign.uiAlignCenter)
                return Alignment.TopCenter;
            else if (vAlign == LibuiLibrary.uiAlign.uiAlignStart && hAlign == LibuiLibrary.uiAlign.uiAlignEnd)
                return Alignment.TopRight;
            else if (vAlign == LibuiLibrary.uiAlign.uiAlignFill && hAlign == LibuiLibrary.uiAlign.uiAlignStart)
                return Alignment.Left;
            else if (vAlign == LibuiLibrary.uiAlign.uiAlignCenter && hAlign == LibuiLibrary.uiAlign.uiAlignStart)
                return Alignment.LeftCenter;
            else if (vAlign == LibuiLibrary.uiAlign.uiAlignFill && hAlign == LibuiLibrary.uiAlign.uiAlignEnd)
                return Alignment.Right;
            else if (vAlign == LibuiLibrary.uiAlign.uiAlignCenter && hAlign == LibuiLibrary.uiAlign.uiAlignEnd)
                return Alignment.RightCenter;
            else if (vAlign == LibuiLibrary.uiAlign.uiAlignEnd && hAlign == LibuiLibrary.uiAlign.uiAlignFill)
                return Alignment.Bottom;
            else if (vAlign == LibuiLibrary.uiAlign.uiAlignEnd && hAlign == LibuiLibrary.uiAlign.uiAlignStart)
                return Alignment.BottomLeft;
            else if (vAlign == LibuiLibrary.uiAlign.uiAlignEnd && hAlign == LibuiLibrary.uiAlign.uiAlignCenter)
                return Alignment.BottomCenter;
            else if (vAlign == LibuiLibrary.uiAlign.uiAlignEnd && hAlign == LibuiLibrary.uiAlign.uiAlignEnd)
                return Alignment.BottomRight;
            else
                throw new ArgumentOutOfRangeException("hAlign|vAlign");
        }
        #endregion
    }
}