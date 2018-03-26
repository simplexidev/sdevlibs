using System.IO;
using static LibUISharp.Internal.LibUI;

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
                Path = uiSaveFile(Parent.Handle);
            else if (this is OpenFileDialog)
                Path = uiOpenFile(Parent.Handle);

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