using System;

namespace LibUISharp
{
    /// <summary>
    /// Provides data for a <c>TextChanged</c> event.
    /// </summary>
    public class TextChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TextChangedEventArgs"/> class.
        /// </summary>
        /// <param name="text"></param>
        public TextChangedEventArgs(string text) => Text = text;

        /// <summary>
        /// The text event data.
        /// </summary>
        public string Text { get; internal set; }
    }
}