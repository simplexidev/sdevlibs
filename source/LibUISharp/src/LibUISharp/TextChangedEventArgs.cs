namespace LibUISharp
{
    /// <summary>
    /// Provides text data for an event.
    /// </summary>
    public class TextChangedEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TextChangedEventArgs"/> class.
        /// </summary>
        /// <param name="text">The text event data.</param>
        public TextChangedEventArgs(string text) => Text = text;

        /// <summary>
        /// The text event data.
        /// </summary>
        public string Text { get; }
    }
}