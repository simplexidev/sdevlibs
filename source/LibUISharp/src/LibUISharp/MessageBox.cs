using LibUISharp.Internal;
using System;
using System.Runtime.InteropServices;

namespace LibUISharp
{
    // uiMsgBox
    public class MessageBox
    {
        public static void Show(string title, string description = "LibUISharp", bool isError = false, Window owner = null)
        {
            IntPtr titlePtr = title.ToLibuiString();
            IntPtr descriptionPtr = description.ToLibuiString();
            Window o = owner ?? Application.MainWindow;
            if (isError)
                LibuiLibrary.uiMsgBoxError(o.Handle.DangerousGetHandle(), titlePtr, descriptionPtr);
            else
                LibuiLibrary.uiMsgBox(o.Handle.DangerousGetHandle(), titlePtr, descriptionPtr);
            Marshal.FreeHGlobal(titlePtr);
            Marshal.FreeHGlobal(descriptionPtr);
        }
    }
}