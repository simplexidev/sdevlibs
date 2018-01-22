using LibUISharp.Internal;
using static LibUISharp.Internal.UI;

namespace LibUISharp
{
    public class OpenFileDialog
    {
        public string Path { get; private set; }
        private Window parent;

        public OpenFileDialog(Window parent = null) => this.parent = parent ?? Application.MainWindow;

        public bool Show()
        {
            Path = MarshalHelper.StringFromUTF8(uiOpenFile(parent.Handle.DangerousGetHandle()));
            if (string.IsNullOrEmpty(Path)) return false;
            return true;
        }
    }
}