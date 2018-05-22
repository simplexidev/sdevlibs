using LibUISharp;

namespace ControlGallery
{
    class Program
    {
        static void Main()
        {
            Application app = new Application();
            Window w = new MainWindow();

            app.Run(w);
        }
    }
}