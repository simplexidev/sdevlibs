using LibUISharp;

namespace LibUISharpDemos.SimpleWindow
{
    internal class Program
    {
        public static void Main()
        {
            Application app = new Application();
            Window w = new Window();
            app.Run(w);
        }
    }
}