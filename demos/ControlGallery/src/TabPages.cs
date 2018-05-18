using LibUISharp;
using LibUISharp.Drawing;

namespace ControlGallery
{
    public sealed class BasicControlsTab : TabPage
    {
        private StackPanel vPanel = new StackPanel(Orientation.Vertical) { Padding = true };
        private StackPanel hPanel = new StackPanel(Orientation.Horizontal) { Padding = true };
        private Button button = new Button("Button");
        private CheckBox checkBox = new CheckBox("CheckBox");
        private Label label = new Label("This is a Label. Right now, labels can only span one line.");
        private Separator hSeparator = new Separator(Orientation.Horizontal);
        private GroupBox groupBox = new GroupBox("Entries") { Margins = true };
        private Form form = new Form { Padding = true };
        private TextBox textBox = new TextBox();
        private PasswordBox passwordBox = new PasswordBox();
        private SearchBox searchBox = new SearchBox();
        private MultilineTextBox multilineTextBox = new MultilineTextBox();
        private MultilineTextBox noWordWrapMultilineTextBox = new MultilineTextBox(false);

        public BasicControlsTab() : base("Basic Controls") => InitializeComponent();

        protected override void InitializeComponent()
        {
            Margins = true;
            Child = vPanel;

            vPanel.Children.Add(hPanel);
            hPanel.Children.Add(button);
            hPanel.Children.Add(checkBox);
            vPanel.Children.Add(label);
            vPanel.Children.Add(hSeparator);
            vPanel.Children.Add(groupBox, true);
            groupBox.Child = form;
            form.Children.Add("TextBox", textBox);
            form.Children.Add("PasswordBox", passwordBox);
            form.Children.Add("SearchBox", searchBox);
            form.Children.Add("Multiline TextBox", multilineTextBox, true);
            form.Children.Add("Multiline TextBox No WordWrap", noWordWrapMultilineTextBox, true);
        }
    }

    public sealed class NumbersTab : TabPage
    {
        private StackPanel hPanel = new StackPanel(Orientation.Horizontal) { Padding = true };
        private GroupBox groupBox = new GroupBox("Numbers") { Margins = true };
        private StackPanel vPanel = new StackPanel(Orientation.Vertical) { Padding = true };
        private SpinBox spinBox = new SpinBox(0, 100);
        private Slider slider = new Slider(0, 100);
        private ProgressBar progressBar = new ProgressBar();
        private ProgressBar iProgressBar = new ProgressBar() { Value = -1 };
        private GroupBox groupBox2 = new GroupBox("Lists") { Margins = true };
        private StackPanel vPanel2 = new StackPanel(Orientation.Vertical) { Padding = true };
        private ComboBox comboBox = new ComboBox();
        private EditableComboBox editableComboBox = new EditableComboBox();
        private RadioButtonGroup radioButtonGroup = new RadioButtonGroup();

        public NumbersTab() : base("Numbers and Lists") => InitializeComponent();

        protected override void InitializeComponent()
        {
            Margins = true;
            Child = hPanel;

            hPanel.Children.Add(groupBox, true);
            groupBox.Child = vPanel;

            spinBox.ValueChanged += (sender, args) =>
            {
                int value = spinBox.Value;
                slider.Value = value;
                progressBar.Value = value;
            };

            slider.ValueChanged += (sender, args) =>
            {
                int value = slider.Value;
                spinBox.Value = value;
                progressBar.Value = value;
            };

            vPanel.Children.Add(spinBox);
            vPanel.Children.Add(slider);
            vPanel.Children.Add(progressBar);
            vPanel.Children.Add(iProgressBar);

            hPanel.Children.Add(groupBox2, true);

            groupBox2.Child = vPanel2;

            comboBox.Add("Combobox Item 1", "Combobox Item 2", "Combobox Item 3");
            editableComboBox.Add("Editable Item 1", "Editable Item 2", "Editable Item 3");
            radioButtonGroup.Add("Radio Button 1", "Radio Button 2", "Radio Button 3");

            vPanel.Children.Add(comboBox);
            vPanel.Children.Add(editableComboBox);
            vPanel.Children.Add(radioButtonGroup);
        }

    }

    public sealed class DataChoosersTab : TabPage
    {
        private StackPanel hPanel = new StackPanel(Orientation.Horizontal) { Padding = true };
        private StackPanel vPanel = new StackPanel(Orientation.Vertical) { Padding = true };
        private DatePicker datePicker = new DatePicker();
        private TimePicker timePicker = new TimePicker();
        private DateTimePicker dateTimePicker = new DateTimePicker();
        private FontPicker fontPicker = new FontPicker();
        private ColorPicker colorPicker = new ColorPicker();
        private Separator hSeparator = new Separator(Orientation.Horizontal);
        private StackPanel vPanel2 = new StackPanel(Orientation.Vertical) { Padding = true };
        private Grid grid = new Grid() { Padding = true };
        private Button button = new Button("Open File");
        private TextBox textBox = new TextBox() { ReadOnly = true };
        private Button button2 = new Button("Save File");
        private TextBox textBox2 = new TextBox() { ReadOnly = true };
        private Grid grid2 = new Grid() { Padding = true };
        private Button button3 = new Button("Message Box");
        private Button button4 = new Button("Message Box (Error)");

        public DataChoosersTab() : base("Data Choosers") => InitializeComponent();

        protected override void InitializeComponent()
        {
            Margins = true;
            Child = hPanel;

            hPanel.Children.Add(vPanel);

            vPanel.Children.Add(datePicker);
            vPanel.Children.Add(timePicker);
            vPanel.Children.Add(dateTimePicker);
            vPanel.Children.Add(fontPicker);
            vPanel.Children.Add(colorPicker);

            hPanel.Children.Add(hSeparator);
            hPanel.Children.Add(vPanel2);

            vPanel2.Children.Add(grid);

            button.Click += (sender, args) =>
            {
                OpenFileDialog dialog = new OpenFileDialog();
                if (!dialog.Show())
                {
                    textBox.Text = "(cancelled)";
                    return;
                };
                textBox.Text = dialog.Path;
            };

            button2.Click += (sender, args) =>
            {
                SaveFileDialog dialog = new SaveFileDialog();
                if (!dialog.Show())
                {
                    textBox2.Text = "(cancelled)";
                    return;
                };
                textBox2.Text = dialog.Path;
            };

            button3.Click += (sender, args) => { MessageBox.Show("This is a normal message box.", "More detailed information can be shown here."); };
            button4.Click += (sender, args) => { MessageBox.Show("This message box describes an error.", "More detailed information can be shown here.", true); };

            grid.Children.Add(button, 0, 0, 1, 1, 0, 0, Alignment.Fill);
            grid.Children.Add(textBox, 1, 0, 1, 1, 1, 0, Alignment.Fill);
            grid.Children.Add(button2, 0, 1, 1, 1, 0, 0, Alignment.Fill);
            grid.Children.Add(textBox2, 1, 1, 1, 1, 1, 0, Alignment.Fill);
            grid.Children.Add(grid2, 0, 2, 2, 1, 0, 0, Alignment.TopCenter);
            grid2.Children.Add(button3, 0, 0, 1, 1, 0, 0, Alignment.Fill);
            grid2.Children.Add(button4, 1, 0, 1, 1, 0, 0, Alignment.Fill);
        }
    }
}