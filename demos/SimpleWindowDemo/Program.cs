using System;
using LibUISharp;

namespace SimpleWindowDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Application app = new Application();
            Window w = new Window();

            app.Run(w);
        }
    }
}
