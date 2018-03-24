using System;

namespace LibUISharp.Controls
{
    public class TextChangedEventArgs : EventArgs
    {
        public TextChangedEventArgs(string text) => Text = text;
        public string Text { get; internal set; }
    }
}