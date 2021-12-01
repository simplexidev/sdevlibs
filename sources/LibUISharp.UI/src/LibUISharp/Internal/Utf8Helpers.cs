using System;
using System.Runtime.InteropServices;
using System.Text;

using LibUISharp.Native;

namespace LibUISharp.Internal
{
    public static unsafe class Utf8Helper
    {
        internal static sbyte* GetUtf8Pointer(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                sbyte emptyStr = 0;
                return &emptyStr;
            }
            sbyte[] bytes = (sbyte[])(Array)Encoding.UTF8.GetBytes(str);
            sbyte[] retVal = new sbyte[bytes.Length + 1];
            bytes.CopyTo(retVal, 0);
            retVal[bytes.Length] = 0;
            fixed (sbyte* retValPtr = retVal) { return retValPtr; }
        }

        internal static string GetUtf16String(sbyte* ptr)
        {
            if (ptr is null || ptr == IntPtr.Zero.ToPointer()) return string.Empty;
            int len;
            byte[] rawBytes = Encoding.Unicode.GetBytes(Marshal.PtrToStringUni((IntPtr)ptr));
            for (len = 0; len < rawBytes.Length; len++)
                if (rawBytes[len] == 0) break;
            if (len == 0) return string.Empty;
            string retVal = Encoding.UTF8.GetString(rawBytes, 0, len);
            Libui.uiFreeText(ptr);
            return retVal;
        }
    }
}