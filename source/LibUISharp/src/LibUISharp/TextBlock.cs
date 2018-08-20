using System;
using LibUISharp.Internal;

namespace LibUISharp
{
    /// <summary>
    /// Represents a control that can be used to display or edit multiple lines of text.
    /// </summary>
    [NativeType("uiMultilineEntry")]
    public class TextBlock : Control
    {
        private string text;
        private bool isReadOnly;

        /// <summary>
        /// Initializes a new instance of the <see cref="TextBlock"/> class.
        /// </summary>
        /// <param name="wordWrap">Whether or not the lines of text are wrapped to fit within the <see cref="TextBlock"/> sides.</param>
        public TextBlock(bool wordWrap = true)
        {
            if (wordWrap)
                Handle = NativeCalls.NewMultilineEntry();
            else
                Handle = NativeCalls.NewNonWrappingMultilineEntry();
            WordWrap = wordWrap;
            InitializeEvents();
        }

        /// <summary>
        /// Occurs when the <see cref="Text"/> property is changed.
        /// </summary>
        public event Action TextChanged;

        /// <summary>
        /// Gets whether or not this <see cref="TextBlock"/> wraps it's text to fit within it's sides.
        /// </summary>
        public bool WordWrap { get; }

        /// <summary>
        /// Adds the specified line of text to the end of the text currently contained in this <see cref="TextBlock"/>.
        /// </summary>
        /// <param name="line">The line to add.</param>
        public void Append(string line) => NativeCalls.MultilineEntryAppend(Handle, line);

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
        public string Text
        {
            get
            {
                text = NativeCalls.MultilineEntryText(Handle);
                return text;
            }
            set
            {
                if (text != value)
                {
                    NativeCalls.MultilineEntrySetText(Handle, value);
                    text = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets whether the text is read-only or not.
        /// </summary>
        public bool IsReadOnly
        {
            get
            {
                isReadOnly = NativeCalls.MultilineEntryReadOnly(Handle);
                return isReadOnly;
            }
            set
            {
                if (isReadOnly != value)
                {
                    NativeCalls.EntrySetReadOnly(Handle, value);
                    isReadOnly = value;
                }
            }
        }

        /// <summary>
        /// Initializes this UI component's events.
        /// </summary>
        protected override void InitializeEvents() => NativeCalls.MultilineEntryOnChanged(Handle, (entry, data) => { OnTextChanged(); }, IntPtr.Zero);

        /// <summary>
        /// Called when the <see cref="TextChanged"/> event is raised.
        /// </summary>
        protected virtual void OnTextChanged() => TextChanged?.Invoke();
    }
}