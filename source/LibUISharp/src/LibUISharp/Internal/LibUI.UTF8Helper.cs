using System;
using System.Runtime.InteropServices;
using System.Text;

namespace LibUISharp.Internal
{
    internal static partial class LibUI
    {
        public static class UTF8Helper
        {
            //! You MUST call System.Marshal.FreeHGlobal(IntPtr) after using this
            //! or it will cause a memory leak.
            public static IntPtr ToUTF8Ptr(string str)
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

            public static string ToUTF8Str(IntPtr ptr)
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
                LibUI.uiFreeText(ptr);
                return str;
            }
        }
    }
}