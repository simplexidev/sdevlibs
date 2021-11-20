using System;
using static LibUISharp.Native.NativeMethods;

namespace LibUISharp
{
    /// <summary>
    /// Represents a control that can be used to display or edit multiple lines of text.
    /// </summary>
    public class TextBlock : TextBoxBase
    {
        private string text;
        private bool isReadOnly;
        private TextBlock() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TextBlock"/> class.
        /// </summary>
        /// <param name="wordWrap">Whether or not the lines of text are wrapped to fit within the <see cref="TextBlock"/> sides.</param>
        public TextBlock(bool wordWrap = true)
        {
            if (wordWrap)
                Handle = Libui.uiNewMultilineEntry();
            else
                Handle = Libui.uiNewNonWrappingMultilineEntry();
            WordWrap = wordWrap;
            InitializeEvents();
        }

        /// <summary>
        /// Gets whether or not this <see cref="TextBlock"/> wraps it's text to fit within it's sides.
        /// </summary>
        public bool WordWrap { get; }

        /// <summary>
        /// Adds the specified line of text to the end of the text currently contained in this <see cref="TextBlock"/>.
        /// </summary>
        /// <param name="line">The line to add.</param>
        public void Append(string line) => Libui.uiMultilineEntryAppend(this, line);

        /// <summary>
        /// Adds the specified lines of text to the end of the text currently contained in this <see cref="EditableComboBox"/>.
        /// </summary>
        /// <param name="lines">The lines to add.</param>
        public void Append(params string[] lines)
        {
            foreach (string line in lines)
            {
                Append(line);
            }
        }

        /// <summary>
        /// Gets or sets the displayed text.
        /// </summary>
        public override string Text
        {
            get
            {
                text = Libui.uiMultilineEntryText(this);
                return text;
            }
            set
            {
                if (text != value)
                {
                    Libui.uiMultilineEntrySetText(this, value);
                    text = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets whether the text is read-only or not.
        /// </summary>
        public override bool IsReadOnly
        {
            get
            {
                isReadOnly = Libui.uiMultilineEntryReadOnly(this);
                return isReadOnly;
            }
            set
            {
                if (isReadOnly != value)
                {
                    Libui.uiEntrySetReadOnly(this, value);
                    isReadOnly = value;
                }
            }
        }

        /// <summary>
        /// Initializes this UI component's events.
        /// </summary>
        protected override void InitializeEvents() => Libui.uiMultilineEntryOnChanged(this, (entry, data) => { OnTextChanged(EventArgs.Empty); }, IntPtr.Zero);
    }
}