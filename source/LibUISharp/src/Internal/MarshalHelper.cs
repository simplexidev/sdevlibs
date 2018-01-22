using System;
using System.Runtime.InteropServices;
using System.Text;

namespace LibUISharp.Internal
{
    internal static class MarshalHelper
    {
        // Marshal.FreeHGlobal must be called after using this function else
        // you will leak memory
        public static IntPtr StringToUTF8(string str)
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

        public static string StringFromUTF8(IntPtr ptr)
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
            UI.uiFreeText(ptr);
            return str;
        }
    }
}