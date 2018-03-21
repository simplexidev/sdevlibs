using LibUISharp.Internal;

namespace LibUISharp.Controls
{
    public class MessageBox
    {
        public static void Show(string title, string description = "LibUISharp", bool isError = false, Window owner = null) =>
            LibUI.MessageBox(owner.Handle ?? Application.MainWindow.Handle, title, description, isError);
    }
}