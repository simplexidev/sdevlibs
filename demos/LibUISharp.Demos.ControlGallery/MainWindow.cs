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

        public MainWindow() : base(new Size(640, 480), "LibUISharp Control Gallery", true) => InitializeComponent();

        protected override void InitializeComponent()
        {
            Margins = true;
            Child = tabControl;

            tabControl.Items.Add(basicControlsTab);
            tabControl.Items.Add(numbersTab);
            tabControl.Items.Add(dataChoosersTab);
        }
    }
}