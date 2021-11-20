using LibUISharp;

namespace LibUISharpDemos.ControlGallery
{
    internal class Program
    {
        private static void Main()
        {
            Application app = new Application();
            Window w = new MainWindow();
            app.Run(w);
        }
    }
}