namespace LibUISharp.Demos.Histogram
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Application app = new Application();
            HistogramWindow w = new HistogramWindow();
            app.Run(w);
        }
    }
}