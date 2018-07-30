using LibUISharp;
using LibUISharp.Drawing;

namespace SimpleWindow
{
    internal class Program
    {
        public static void Main() => new Application().Run(new Window("SimpleWindow", new Size(300, 300)));
    }
}