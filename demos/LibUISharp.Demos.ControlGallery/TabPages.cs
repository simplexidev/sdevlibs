using LibUISharp;
using LibUISharp.Drawing;

namespace LibUISharpDemos.ControlGallery
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
        private TextBlock textBlock = new TextBlock();
        private TextBlock noWordWrapTextBlock = new TextBlock(false);

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
            form.Children.Add("Multiline TextBox", textBlock, true);
            form.Children.Add("Multiline TextBox No WordWrap", noWordWrapTextBlock, true);
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
        private RadioButtonList radioButtonList = new RadioButtonList();

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
            radioButtonList.Add("Radio Button 1", "Radio Button 2", "Radio Button 3");

            vPanel2.Children.Add(comboBox);
            vPanel2.Children.Add(editableComboBox);
            vPanel2.Children.Add(radioButtonList);
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
        private Grid gridFile = new Grid() { Padding = true };
        private Button buttonOpenFile = new Button("Open File");
        private TextBox textboxOpenFile = new TextBox() { ReadOnly = true };
        private Button buttonSaveFile = new Button("Save File");
        private TextBox textboxSaveFile = new TextBox() { ReadOnly = true };

        private StackPanel hPanelMessages = new StackPanel(Orientation.Horizontal) { Padding = true };
        private Button buttonMessage = new Button("Message Box");
        private Button buttonMessageErr = new Button("Message Box (Error)");

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

            vPanel2.Children.Add(gridFile);

            buttonOpenFile.Click += (sender, args) =>
            {
                if (Window.ShowOpenFileDialog(out string path, null))
                    textboxOpenFile.Text = path;
                else
                    textboxOpenFile.Text = "(null)";
            };

            buttonSaveFile.Click += (sender, args) =>
            {
                if (Window.ShowSaveFileDialog(out string path, null))
                    textboxSaveFile.Text = path;
                else
                    textboxSaveFile.Text = "(null)";
            };

            buttonMessage.Click += (sender, args) => { Window.ShowMessageBox(null, "This is a normal message box.", "More detailed information can be shown here."); };
            buttonMessageErr.Click += (sender, args) => { Window.ShowMessageBox(null, "This message box describes an error.", "More detailed information can be shown here.", true); };

            gridFile.Children.Add(buttonOpenFile, 0, 0, 1, 1, 0, 0, Alignment.Fill);
            gridFile.Children.Add(textboxOpenFile, 1, 0, 1, 1, 1, 0, Alignment.Fill);
            gridFile.Children.Add(buttonSaveFile, 0, 1, 1, 1, 0, 0, Alignment.Fill);
            gridFile.Children.Add(textboxSaveFile, 1, 1, 1, 1, 1, 0, Alignment.Fill);

            hPanelMessages.Children.Add(buttonMessage);
            hPanelMessages.Children.Add(buttonMessageErr);

            vPanel2.Children.Add(hPanelMessages);
        }
    }
}