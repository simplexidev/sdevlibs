using LibUISharp;
using LibUISharp.Drawing;

namespace LibUISharpDemos.SimpleWindowWithMenu
{
    internal class Program
    {
        // This MUST be static, or dotnet itself will crash.
        private static Menu menu;

        public static void Main()
        {
            // Initialize application.
            Application app = new Application();

            // Create the menu and it's items.
            menu = new Menu("Demo");

            // The next line unfourtunately doesn't work, but it's not possible since we need a Window reference.
            // menu.AddAboutItem(click => Window.ShowMessageBox(w, "Demo", "Demo"));

            menu.AddAboutItem();
            menu.AddSeparator();
            menu.AddQuitItem();

            // Initialize the window.
            Window w = new MainWindow();
            app.Run(w);
        }
    }

    public class MainWindow : Window
    {
        // You MUST specify the hasMenu parameter of the base Window class to have a visible menu at the top of the Window.
        public MainWindow() : base("LibUISharp Control Gallery", new Size(640, 480), true) => InitializeComponent();

        protected sealed override void InitializeComponent()
        {
            IsMargined = true;
        }
    }
}