using System.IO;
using LibUISharp.Internal;

namespace LibUISharp.Controls
{
    public abstract class FileDialog
    {
        protected private readonly Window Parent;

        protected FileDialog(Window parent = null) => Parent = parent ?? Application.MainWindow;

        public string Path { get; private set; }

        public bool Show()
        {
            if (this is SaveFileDialog)
                Path = LibUI.SaveFile(Parent.Handle);
            else if (this is OpenFileDialog)
                Path = LibUI.OpenFile(Parent.Handle);

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