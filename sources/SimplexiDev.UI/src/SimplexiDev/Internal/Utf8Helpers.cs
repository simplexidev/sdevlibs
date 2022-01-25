/***********************************************************************************************************************
 * FileName:            Utf8Helpers.cs
 * Copyright/License:   https://github.com/simplexidev/sdfx/blob/main/LICENSE.md
***********************************************************************************************************************/

using System;
using System.Runtime.InteropServices;
using System.Text;

using SimplexiDev.Native;

namespace SimplexiDev.Internal
{
    internal static unsafe class Utf8Helper
    {
        internal static byte* GetUtf8Pointer(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                byte emptyStr = 0;
                return &emptyStr;
            }
            byte[] bytes = Encoding.UTF8.GetBytes(str);
            byte[] retVal = new byte[bytes.Length + 1];
            bytes.CopyTo(retVal, 0);
            retVal[bytes.Length] = 0;
            fixed (byte* retValPtr = retVal) { return retValPtr; }
        }

        internal static string GetUtf16String(byte* ptr, bool isInitStr = true)
        {
            if (ptr is null || ptr == IntPtr.Zero.ToPointer()) return string.Empty;
            int len;
            byte[] rawBytes = Encoding.Unicode.GetBytes(Marshal.PtrToStringUni((IntPtr)ptr));
            for (len = 0; len < rawBytes.Length; len++)
                if (rawBytes[len] == 0) break;
            if (len == 0) return string.Empty;
            string retVal = Encoding.UTF8.GetString(rawBytes, 0, len);
            if (isInitStr && (ptr is not null && ptr != IntPtr.Zero.ToPointer()))
                Libui.uiFreeInitError(ptr);
            if (!isInitStr)
                Libui.uiFreeText(ptr);
            return retVal;
        }
    }
}