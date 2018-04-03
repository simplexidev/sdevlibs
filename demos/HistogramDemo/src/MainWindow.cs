using System;
using System.Collections.Generic;
using LibUISharp;
using LibUISharp.Drawing;

namespace HistogramDemo
{
    public sealed class MainWindow : Window
    {
        private HPanel hPanel = new HPanel() { Padding = true };
        private VPanel vPanel = new VPanel() { Padding = true };
        private List<SpinBox> spinBoxes = new List<SpinBox>();
        private Surface surface;
        private ColorPicker colorPicker = new ColorPicker();

        public MainWindow() : base(new Size(640, 480), "LibUISharp Histogram Demo", true) => InitializeComponent();

        protected override void InitializeComponent()
        {
            Margins = true;
            Child = hPanel;
            
            hPanel.Children.Add(vPanel);
            
            for (int i = 0; i < 10; i++)
            {
                SpinBox spinBox = new SpinBox(0, 100) { Value = new Random(DateTime.Now.Millisecond).Next(0, 101) };
                spinBox.ValueChanged += SpinBoxOnValueChanged;
                vPanel.Children.Add(spinBox);
                spinBoxes.Add(spinBox);
            }

            colorPicker.Color = Colors.Blue;
            colorPicker.ColorChanged += (sender, args) => { surface.QueueRedrawAll(); };
            vPanel.Children.Add(colorPicker);

            surface = new Surface(new SurfaceHandler(colorPicker, spinBoxes));

            hPanel.Children.Add(surface, true);
        }

        private void SpinBoxOnValueChanged(object sender, EventArgs eventArgs) => surface.QueueRedrawAll();
    }
}