using LibUISharp;
using LibUISharp.Drawing;

namespace ControlGallery
{
    public class MainWindow : Window
    {
        private TabControl tabControl = new TabControl();
        private BasicControlsTab basicControlsTab = new BasicControlsTab();
        private NumbersTab numbersTab = new NumbersTab();
        private DataChoosersTab dataChoosersTab = new DataChoosersTab();

        public MainWindow() : base(new Size(640, 480), "LibUISharp Control Gallery", true) => InitializeComponent();

        protected override void InitializeComponent()
        {
            Margins = true;
            Child = tabControl;

            tabControl.Children.Add(basicControlsTab);
            tabControl.Children.Add(numbersTab);
            tabControl.Children.Add(dataChoosersTab);
        }
    }
}