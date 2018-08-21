using LibUISharp;
using LibUISharp.Drawing;

namespace ControlGallery
{
    public class MainWindow : Window
    {
        private TabContainer tabControl = new TabContainer();
        private BasicControlsTab controlsTab = new BasicControlsTab();
        private NumbersTab numbersTab = new NumbersTab();
        private DataChoosersTab dataTab = new DataChoosersTab();

        public MainWindow() : base("LibUISharp Control Gallery", new Size(640, 480), true) => InitializeComponent();

        protected override void InitializeComponent()
        {
            IsMargined = true;
            Child = tabControl;

            tabControl.Children.Add(controlsTab);
            tabControl.Children.Add(numbersTab);
            tabControl.Children.Add(dataTab);
        }
    }
}