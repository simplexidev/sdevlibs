using LibUISharp.Internal;
using System.IO;

// uiSaveFile
// uiOpenFile
namespace LibUISharp
{
    public abstract class FileDialog
    {
        protected private readonly Window Parent;

        protected FileDialog(Window parent = null) => Parent = parent ?? Application.MainWindow;

        public string Path { get; private set; }

        public bool Show()
        {
            if (this is SaveFileDialog)
                Path = LibuiLibrary.uiSaveFile(Parent.Handle.DangerousGetHandle()).ToStringEx();
            else if (this is OpenFileDialog)
                Path = LibuiLibrary.uiOpenFile(Parent.Handle.DangerousGetHandle()).ToStringEx();

            if (string.IsNullOrEmpty(Path))
                return false;
            return true;
        }
    }

    public class SaveFileDialog : FileDialog
    {
        public SaveFileDialog(Window parent = null) : base(parent) { }

        public Stream OpenFile() => File.OpenWrite(Path);
    }
    public class OpenFileDialog : FileDialog
    {
        public OpenFileDialog(Window parent = null) : base(parent) { }
    }
}