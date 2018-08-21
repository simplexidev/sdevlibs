using System.IO;
using LibUISharp.Internal;

namespace LibUISharp
{
    public partial class Window
    {
        /// <summary>
        /// Displays a dialog allowing a user to select a file to save to.
        /// </summary>
        /// <param name="path">The file's path selected by the user to save to.</param>
        /// <returns><see langword="true"/> if the file can be saved to, else <see langword="false"/>.</returns>
        public bool ShowSaveFileDialog(out string path) => ShowSaveFileDialog(this, out path);

        /// <summary>
        /// Displays a dialog allowing a user to select a file to save to.
        /// </summary>
        /// <param name="writeStream">The file selected by the user as a writable stream.</param>
        /// <returns><see langword="true"/> if the file can be saved to, else <see langword="false"/>.</returns>
        public bool ShowSaveFileDialog(out Stream writeStream) => ShowSaveFileDialog(this, out writeStream);

        /// <summary>
        /// Displays a dialog allowing a user to select a file to save to.
        /// </summary>
        /// <param name="path">The file's path selected by the user to save to.</param>
        /// <param name="w">The dialog's parent window.</param>
        /// <returns><see langword="true"/> if the file can be saved to, else <see langword="false"/>.</returns>
        public static bool ShowSaveFileDialog(Window w, out string path)
        {
            if (w == null) w = Application.MainWindow;

            path = NativeCalls.SaveFile(w.Handle);
            if (string.IsNullOrEmpty(path))
                return false;
            else
                return true;
        }

        /// <summary>
        /// Displays a dialog allowing a user to select a file to save to.
        /// </summary>
        /// <param name="writeStream">The file selected by the user as a writable stream.</param>
        /// <param name="w">The dialog's parent window.</param>
        /// <returns><see langword="true"/> if the file can be saved to, else <see langword="false"/>.</returns>
        public static bool ShowSaveFileDialog(Window w, out Stream writeStream)
        {
            if (ShowSaveFileDialog(w, out string path))
            {
                writeStream = File.OpenWrite(path);
                return true;
            }
            else
            {
                writeStream = null;
                return false;
            }
        }

        /// <summary>
        /// Displays a dialog allowing a user to select a file to open.
        /// </summary>
        /// <param name="path">The file's path selected by the user.</param>
        /// <returns><see langword="true"/> if the file exists, else <see langword="false"/>.</returns>
        public bool ShowOpenFileDialog(out string path) => ShowOpenFileDialog(this, out path);

        /// <summary>
        /// Displays a dialog allowing a user to select a file to open.
        /// </summary>
        /// <param name="readStream">The file selected by the user as a readable stream.</param>
        /// <returns><see langword="true"/> if the file exists, else <see langword="false"/>.</returns>
        public bool ShowOpenFileDialog(out Stream readStream) => ShowOpenFileDialog(this, out readStream);

        /// <summary>
        /// Displays a dialog allowing a user to select a file to open.
        /// </summary>
        /// <param name="path">The file's path selected by the user.</param>
        /// <param name="w">The dialog's parent window.</param>
        /// <returns><see langword="true"/> if the file exists, else <see langword="false"/>.</returns>
        public static bool ShowOpenFileDialog(Window w, out string path)
        {
            if (w == null) w = Application.MainWindow;

            path = NativeCalls.OpenFile(w.Handle);
            if (string.IsNullOrEmpty(path))
                return false;
            else
                return true;
        }

        /// <summary>
        /// Displays a dialog allowing a user to select a file to open.
        /// </summary>
        /// <param name="readStream">The file selected by the user as a readable stream.</param>
        /// <param name="w">The dialog's parent window.</param>
        /// <returns><see langword="true"/> if the file exists, else <see langword="false"/>.</returns>
        public static bool ShowOpenFileDialog(Window w, out Stream readStream)
        {
            if (ShowOpenFileDialog(w, out string path))
            {
                readStream = File.OpenRead(path);
                return true;
            }
            else
            {
                readStream = null;
                return false;
            }
        }

        /// <summary>
        /// Displays a dialog showing a message, or optionally, an error.
        /// </summary>
        /// <param name="title">The title of the message dialog.</param>
        /// <param name="description">The description of the message dialog.</param>
        /// <param name="isError">Whether the message is displayed as an error.</param>
        public void ShowMessageBox(string title, string description = null, bool isError = false) => ShowMessageBox(this, title, description, isError);

        /// <summary>
        /// Displays a dialog showing a message, or optionally, an error.
        /// </summary>
        /// <param name="w">The dialog's parent window.</param>
        /// <param name="title">The title of the message dialog.</param>
        /// <param name="description">The description of the message dialog.</param>
        /// <param name="isError">Whether the message is displayed as an error.</param>
        public static void ShowMessageBox(Window w, string title, string description = null, bool isError = false)
        {
            if (w == null) w = Application.MainWindow;

            if (isError)
                NativeCalls.MsgBoxError(w.Handle, title, description);
            else
                NativeCalls.MsgBox(w.Handle, title, description);
        }
    }
}