using System;
using System.Runtime.InteropServices;
using LibUISharp.Internal;
using LibUISharp.SafeHandles;

namespace LibUISharp
{
    /// <summary>
    /// Represents a base implementation of controls that can be used to display and edit text.
    /// </summary>
    public abstract class TextBoxBase : Control
    {
        private string text;
        private bool readOnly;

        /// <summary>
        /// Initializes a new instance of the <see cref="TextBoxBase"/> class.
        /// </summary>
        protected TextBoxBase()
        {
            if (!(this is TextBlock))
            {
                if (this is PasswordBox)
                    Handle = new SafeControlHandle(LibuiLibrary.uiNewPasswordEntry());
                else if (this is SearchBox)
                    Handle = new SafeControlHandle(LibuiLibrary.uiNewSearchEntry());
                else
                    Handle = new SafeControlHandle(LibuiLibrary.uiNewEntry());
            }
        }

        /// <summary>
        /// Occurs when the <see cref="Text"/> property is changed.
        /// </summary>
        public event EventHandler<TextChangedEventArgs> TextChanged;

        /// <summary>
        /// Gets or sets the displayed text.
        /// </summary>
        public virtual string Text
        {
            get
            {
                if (this is TextBlock)
                    text = LibuiLibrary.uiMultilineEntryText(Handle.DangerousGetHandle()).ToStringEx();
                else
                    text = LibuiLibrary.uiEntryText(Handle.DangerousGetHandle()).ToStringEx();
                return text;
            }
            set
            {
                if (text != value)
                {
                    IntPtr strPtr = value.ToLibuiString();
                    if (this is TextBlock)
                        LibuiLibrary.uiMultilineEntrySetText(Handle.DangerousGetHandle(), strPtr);
                    else
                        LibuiLibrary.uiEntrySetText(Handle.DangerousGetHandle(), strPtr);
                    Marshal.FreeHGlobal(strPtr);
                    text = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets whether the text is read-only or not.
        /// </summary>
        public virtual bool ReadOnly
        {
            get
            {
                if (this is TextBlock)
                    readOnly = LibuiLibrary.uiMultilineEntryReadOnly(Handle.DangerousGetHandle());
                else
                    readOnly = LibuiLibrary.uiEntryReadOnly(Handle.DangerousGetHandle());
                return readOnly;
            }
            set
            {
                if (readOnly != value)
                {
                    if (this is TextBlock)
                        LibuiLibrary.uiMultilineEntrySetReadOnly(Handle.DangerousGetHandle(), value);
                    else
                        LibuiLibrary.uiEntrySetReadOnly(Handle.DangerousGetHandle(), value);
                    readOnly = value;
                }
            }
        }

        /// <summary>
        /// Initializes this UI component's events.
        /// </summary>
        protected override void InitializeEvents()
        {
            if (this is TextBlock)
                LibuiLibrary.uiMultilineEntryOnChanged(Handle.DangerousGetHandle(), (entry, data) => { OnTextChanged(EventArgs.Empty); }, IntPtr.Zero);
            else
                LibuiLibrary.uiEntryOnChanged(Handle.DangerousGetHandle(), (entry, data) => { OnTextChanged(EventArgs.Empty); }, IntPtr.Zero);
        }

        /// <summary>
        /// Called when the <see cref="TextChanged"/> event is raised.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> containing the event data.</param>
        protected virtual void OnTextChanged(EventArgs e) => TextChanged?.Invoke(this, new TextChangedEventArgs(Text));
    }

    /// <summary>
    /// Represents a control that can be used to display or edit text.
    /// </summary>
    public class TextBox : TextBoxBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TextBox"/> class.
        /// </summary>
        public TextBox() : base() => InitializeEvents();
    }

    /// <summary>
    /// Represents a <see cref="TextBox"/> that displays it's text as password characters.
    /// </summary>
    public class PasswordBox : TextBox
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PasswordBox"/> class.
        /// </summary>
        public PasswordBox() : base() { }
    }

    /// <summary>
    /// Represents a <see cref="TextBox"/> that displays a search icon.
    /// </summary>
    public class SearchBox : TextBox
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchBox"/> class.
        /// </summary>
        public SearchBox() : base() { }
    }

    /// <summary>
    /// Represents a control that can be used to display or edit multiple lines of text.
    /// </summary>
    public class TextBlock : TextBoxBase
    {
        private TextBlock() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="EditableComboBox"/> class.
        /// </summary>
        /// <param name="wordWrap">Whether or not the lines of text are wrapped to fit within the <see cref="EditableComboBox"/> sides.</param>
        public TextBlock(bool wordWrap = true)
        {
            if (wordWrap)
                Handle = new SafeControlHandle(LibuiLibrary.uiNewMultilineEntry());
            else
                Handle = new SafeControlHandle(LibuiLibrary.uiNewNonWrappingMultilineEntry());
            WordWrap = wordWrap;
            InitializeEvents();
        }

        /// <summary>
        /// Gets whether or not this <see cref="EditableComboBox"/> wraps it's text to fit within it's sides.
        /// </summary>
        public bool WordWrap { get; }

        /// <summary>
        /// Adds the specified line of text to the end of the text currently contained in this <see cref="EditableComboBox"/>.
        /// </summary>
        /// <param name="line">The line to add.</param>
        public void Append(string line)
        {
            if (line == null) throw new ArgumentNullException(nameof(line));
            
            IntPtr strPtr = line.ToLibuiString();
            LibuiLibrary.uiMultilineEntryAppend(Handle.DangerousGetHandle(), strPtr);
            Marshal.FreeHGlobal(strPtr);
        }

        /// <summary>
        /// Adds the specified lines of text to the end of the text currently contained in this <see cref="EditableComboBox"/>.
        /// </summary>
        /// <param name="lines">The lines to add.</param>
        public void Append(params string[] lines)
        {
            if (lines == null || lines.Length < 1) throw new ArgumentNullException(nameof(lines));

            foreach (string line in lines)
            {
                Append(line);
            }
        }
    }
}