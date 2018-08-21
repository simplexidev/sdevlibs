using LibUISharp;

namespace ControlGallery
{
    public sealed class BasicControlsTab : TabPage
    {
        private StackContainer vPanel = new StackContainer(Orientation.Vertical, true);
        private StackContainer hPanel = new StackContainer(Orientation.Horizontal, true);
        private Button button = new Button("Button");
        private CheckBox checkBox = new CheckBox("CheckBox", true);
        private Label label = new Label("This is a Label. Right now, labels can only span one line.");
        private Separator hSeparator = new Separator(Orientation.Horizontal);
        private GroupContainer groupContainer = new GroupContainer("Entries", true);
        private FormContainer form = new FormContainer(true);
        private TextBox textBox = new TextBox();
        private PasswordBox passwordBox = new PasswordBox();
        private SearchBox searchBox = new SearchBox();
        private TextBlock textBlock = new TextBlock();
        private TextBlock noWordWrapTextBlock = new TextBlock(null, false);

        public BasicControlsTab() : base("Basic Controls", true) => InitializeComponent();

        protected override void InitializeComponent()
        {
            Child = vPanel;

            vPanel.Children.Add(hPanel);
            hPanel.Children.Add(button);
            hPanel.Children.Add(checkBox);
            vPanel.Children.Add(label);
            vPanel.Children.Add(hSeparator);
            vPanel.Children.Add(groupContainer, true);
            groupContainer.Child = form;
            form.Children.Add("TextBox", textBox);
            form.Children.Add("PasswordBox", passwordBox);
            form.Children.Add("SearchBox", searchBox);
            form.Children.Add("Multiline TextBox", textBlock, true);
            form.Children.Add("Multiline TextBox No WordWrap", noWordWrapTextBlock, true);
        }
    }

    public sealed class NumbersTab : TabPage
    {
        private StackContainer hPanel = new StackContainer(Orientation.Horizontal, true);
        private GroupContainer groupContainer = new GroupContainer("Numbers", true);
        private StackContainer vPanel = new StackContainer(Orientation.Vertical, true);
        private SpinBox spinBox = new SpinBox(0, 100);
        private Slider slider = new Slider(0, 100);
        private ProgressBar progressBar = new ProgressBar();
        private ProgressBar iProgressBar = new ProgressBar(-1);
        private GroupContainer groupBox2 = new GroupContainer("Lists", true);
        private StackContainer vPanel2 = new StackContainer(Orientation.Vertical, true);
        private ComboBox comboBox = new ComboBox(new[] { "ComboBoxItem1", "ComboBoxItem2", "ComboBoxItem3" });
        private EditableComboBox editableComboBox = new EditableComboBox(new[] { "EditableItem1", "EditableItem2", "EditableItem3" });
        private RadioButtonList radioButtonList = new RadioButtonList(new[] {"RadioButton1", "RadioButton2", "RadioButton3"});

        public NumbersTab() : base("Numbers and Lists", true) => InitializeComponent();

        protected override void InitializeComponent()
        {
            Child = hPanel;

            hPanel.Children.Add(groupContainer, true);
            groupContainer.Child = vPanel;

            spinBox.ValueChanged += () =>
            {
                int value = spinBox.Value;
                slider.Value = value;
                progressBar.Value = value;
            };

            slider.ValueChanged += () =>
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

            vPanel2.Children.Add(comboBox);
            vPanel2.Children.Add(editableComboBox);
            vPanel2.Children.Add(radioButtonList);
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

        public DataChoosersTab() : base("Data Choosers", true) => InitializeComponent();

        protected override void InitializeComponent()
        {
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

            buttonOpenFile.Click += () =>
            {
                if (Window.ShowOpenFileDialog(null, out string path))
                    textboxOpenFile.Text = path;
                else
                    textboxOpenFile.Text = "(null)";
            };

            buttonSaveFile.Click += () =>
            {
                if (Window.ShowSaveFileDialog(null, out string path))
                    textboxSaveFile.Text = path;
                else
                    textboxSaveFile.Text = "(null)";
            };

            buttonMessage.Click += () => { Window.ShowMessageBox(null, "This is a normal message box.", "More detailed information can be shown here."); };
            buttonMessageErr.Click += () => { Window.ShowMessageBox(null, "This message box describes an error.", "More detailed information can be shown here.", true); };

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