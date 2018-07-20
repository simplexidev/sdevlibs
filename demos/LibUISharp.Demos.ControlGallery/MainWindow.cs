using LibUISharp;
using LibUISharp.Drawing;

namespace LibUISharpDemos.ControlGallery
{
    public class MainWindow : Window
    {
        private TabContainer tabControl = new TabContainer();
        private readonly BasicControlsTab basicControlsTab = new BasicControlsTab();
        private readonly NumbersTab numbersTab = new NumbersTab();
        private readonly DataChoosersTab dataChoosersTab = new DataChoosersTab();

        public MainWindow() : base("LibUISharp Control Gallery", new Size(640, 480), true) => InitializeComponent();

        protected override void InitializeComponent()
        {
            IsMargined = true;
            Child = tabControl;

            tabControl.Children.Add(basicControlsTab);
            tabControl.Children.Add(numbersTab);
            tabControl.Children.Add(dataChoosersTab);
        }
    }
}