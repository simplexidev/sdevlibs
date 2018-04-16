using System;
using LibUISharp;

namespace ControlGallery
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Initializing Application...");
            Application app = new Application();
            Console.WriteLine("Initializing Application Window...");
            Window window = new MainWindow();
            Console.WriteLine("Running Window via Application...");
            app.Run(window);
        }
    }
}