using LibUISharp;

namespace HistogramDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Application app = new Application();
            Window window = new MainWindow();
            app.Run(window);
        }
    }
}