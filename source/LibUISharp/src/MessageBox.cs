using System;
using System.Runtime.InteropServices;
using LibUISharp.Internal;
using static LibUISharp.Internal.UI;

namespace LibUISharp
{
    public class MessageBox
    {
        public static void Show(Window parent, string title, string description, bool isError = false)
        {
            IntPtr titlePtr = MarshalHelper.StringToUTF8(title);
            IntPtr descPtr = MarshalHelper.StringToUTF8(description);
            if (isError)
                uiMsgBoxError(parent.Handle.DangerousGetHandle(), titlePtr, descPtr);
            else uiMsgBox(parent.Handle.DangerousGetHandle(), titlePtr, descPtr);
            Marshal.FreeHGlobal(titlePtr);
            Marshal.FreeHGlobal(descPtr);
        }
        public static void Show(string title, string description = "", bool isError = false) =>
            Show(Application.MainWindow, title, description, isError);
    }
}