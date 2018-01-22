using System;

namespace LibUISharp
{
    public class TextChangedEventArgs : EventArgs
    {
        public TextChangedEventArgs(string text) => Text = text;

        public string Text { get; internal set; }
    }
}