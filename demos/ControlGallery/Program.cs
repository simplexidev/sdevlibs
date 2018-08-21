using System;
using LibUISharp;

namespace ControlGallery
{
    internal class Program
    {
        // This MUST be static, or dotnet itself will crash.
        private static Menu menu = new Menu("Demo");

        [STAThread]
        private static void Main()
        {
            // Initialize application.
            Application app = new Application();

            // Create the menu and add it's items.
            menu.Children.Add("MenuItem 1"/*, action => Window.ShowMessageBox(null, "TestMessage", null, false)*/);
            menu.Children.AddCheckable("CheckableMenuItem 1");
            menu.Children.AddSeparator();
            menu.Children.AddPreferences();
            menu.Children.AddAbout();
            menu.Children.AddSeparator();
            menu.Children.AddQuit();

            // Run the window.
            app.Run(new MainWindow());
        }
    }
}