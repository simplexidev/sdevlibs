using System.IO;
using LibUISharp.Internal;
using static LibUISharp.Internal.UI;

namespace LibUISharp
{
    public class SaveFileDialog
    {
        private Window parent;

        public string Path { get; private set; }

        public SaveFileDialog(Window parent = null) => this.parent = parent ?? Application.MainWindow;

        public bool Show()
        {
            Path = MarshalHelper.StringFromUTF8(uiSaveFile(parent.Handle.DangerousGetHandle()));
            if (string.IsNullOrEmpty(Path)) return false;
            return true;
        }

        public Stream OpenFile() => File.OpenWrite(Path);
    }
}