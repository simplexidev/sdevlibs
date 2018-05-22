using LibUISharp;

namespace SimpleWindowDemo
{
    class Program
    {
        static void Main()
        {
            Application app = new Application();
            Window w = new Window();
            app.Run(w);
        }
    }
}