using LibUISharp;
using LibUISharp.Drawing;

namespace LibUISharpDemos.ControlGallery
{
    public sealed class BasicControlsTab : TabPage
    {
        private StackContainer vPanel = new StackContainer(Orientation.Vertical) { IsPadded = true };
        private StackContainer hPanel = new StackContainer(Orientation.Horizontal) { IsPadded = true };
        private Button button = new Button("Button");
        private CheckBox checkBox = new CheckBox("CheckBox");
        private Label label = new Label("This is a Label. Right now, labels can only span one line.");
        private Separator hSeparator = new Separator(Orientation.Horizontal);
        private GroupBox groupBox = new GroupBox("Entries") { IsMargined = true };
        private FormContainer form = new FormContainer { IsPadded = true };
        private TextBox textBox = new TextBox();
        private PasswordBox passwordBox = new PasswordBox();
        private SearchBox searchBox = new SearchBox();
        private TextBlock textBlock = new TextBlock();
        private TextBlock noWordWrapTextBlock = new TextBlock(false);

        public BasicControlsTab() : base("Basic Controls") => InitializeComponent();

        protected override void InitializeComponent()
        {
            IsMargined = true;
            Child = vPanel;

            vPanel.Items.Add(hPanel);
            hPanel.Items.Add(button);
            hPanel.Items.Add(checkBox);
            vPanel.Items.Add(label);
            vPanel.Items.Add(hSeparator);
            vPanel.Items.Add(groupBox, true);
            groupBox.Child = form;
            form.Items.Add("TextBox", textBox);
            form.Items.Add("PasswordBox", passwordBox);
            form.Items.Add("SearchBox", searchBox);
            form.Items.Add("Multiline TextBox", textBlock, true);
            form.Items.Add("Multiline TextBox No WordWrap", noWordWrapTextBlock, true);
        }
    }

    public sealed class NumbersTab : TabPage
    {
        private StackContainer hPanel = new StackContainer(Orientation.Horizontal) { IsPadded = true };
        private GroupBox groupBox = new GroupBox("Numbers") { IsMargined = true };
        private StackContainer vPanel = new StackContainer(Orientation.Vertical) { IsPadded = true };
        private SpinBox spinBox = new SpinBox(0, 100);
        private Slider slider = new Slider(0, 100);
        private ProgressBar progressBar = new ProgressBar();
        private ProgressBar iProgressBar = new ProgressBar() { Value = -1 };
        private GroupBox groupBox2 = new GroupBox("Lists") { IsMargined = true };
        private StackContainer vPanel2 = new StackContainer(Orientation.Vertical) { IsPadded = true };
        private ComboBox comboBox = new ComboBox();
        private EditableComboBox editableComboBox = new EditableComboBox();
        private RadioButtonList radioButtonList = new RadioButtonList();

        public NumbersTab() : base("Numbers and Lists") => InitializeComponent();

        protected override void InitializeComponent()
        {
            IsMargined = true;
            Child = hPanel;

            hPanel.Items.Add(groupBox, true);
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

            vPanel.Items.Add(spinBox);
            vPanel.Items.Add(slider);
            vPanel.Items.Add(progressBar);
            vPanel.Items.Add(iProgressBar);

            hPanel.Items.Add(groupBox2, true);

            groupBox2.Child = vPanel2;

            comboBox.Add("Combobox Item 1", "Combobox Item 2", "Combobox Item 3");
            editableComboBox.Add("Editable Item 1", "Editable Item 2", "Editable Item 3");
            radioButtonList.Add("Radio Button 1", "Radio Button 2", "Radio Button 3");

            vPanel2.Items.Add(comboBox);
            vPanel2.Items.Add(editableComboBox);
            vPanel2.Items.Add(radioButtonList);
        }
    }

    public sealed class DataChoosersTab : TabPage
    {
        private StackContainer hPanel = new StackContainer(Orientation.Horizontal) { IsPadded = true };
        private StackContainer vPanel = new StackContainer(Orientation.Vertical) { IsPadded = true };
        private DatePicker datePicker = new DatePicker();
        private TimePicker timePicker = new TimePicker();
        private DateTimePicker dateTimePicker = new DateTimePicker();
        private FontPicker fontPicker = new FontPicker();
        private ColorPicker colorPicker = new ColorPicker();
        private Separator hSeparator = new Separator(Orientation.Horizontal);

        private StackContainer vPanel2 = new StackContainer(Orientation.Vertical) { IsPadded = true };
        private GridContainer gridFile = new GridContainer() { IsPadded = true };
        private Button buttonOpenFile = new Button("Open File");
        private TextBox textboxOpenFile = new TextBox() { IsReadOnly = true };
        private Button buttonSaveFile = new Button("Save File");
        private TextBox textboxSaveFile = new TextBox() { IsReadOnly = true };

        private StackContainer hPanelMessages = new StackContainer(Orientation.Horizontal) { IsPadded = true };
        private Button buttonMessage = new Button("Message Box");
        private Button buttonMessageErr = new Button("Message Box (Error)");

        public DataChoosersTab() : base("Data Choosers") => InitializeComponent();

        protected override void InitializeComponent()
        {
            IsMargined = true;
            Child = hPanel;

            hPanel.Items.Add(vPanel);

            vPanel.Items.Add(datePicker);
            vPanel.Items.Add(timePicker);
            vPanel.Items.Add(dateTimePicker);
            vPanel.Items.Add(fontPicker);
            vPanel.Items.Add(colorPicker);

            hPanel.Items.Add(hSeparator);
            hPanel.Items.Add(vPanel2);

            vPanel2.Items.Add(gridFile);

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

            gridFile.Items.Add(buttonOpenFile, 0, 0, 1, 1, 0, 0, Alignment.Fill);
            gridFile.Items.Add(textboxOpenFile, 1, 0, 1, 1, 1, 0, Alignment.Fill);
            gridFile.Items.Add(buttonSaveFile, 0, 1, 1, 1, 0, 0, Alignment.Fill);
            gridFile.Items.Add(textboxSaveFile, 1, 1, 1, 1, 1, 0, Alignment.Fill);

            hPanelMessages.Items.Add(buttonMessage);
            hPanelMessages.Items.Add(buttonMessageErr);

            vPanel2.Items.Add(hPanelMessages);
        }
    }
}