namespace LibUISharp
{
    /// <summary>
    /// Represents a base implemetation for a selection control with a drop-down list that can be shown or hidden by clicking the arrow on the control.
    /// </summary>
    public abstract class ComboBoxBase : Control
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ComboBoxBase"/> class.
        /// </summary>
        protected ComboBoxBase() { }

        /// <summary>
        /// Adds a drop-down item to this control.
        /// </summary>
        /// <param name="item">The item to add to this control.</param>
        public abstract void Add(string item);

        /// <summary>
        /// Adds drop-down items to this control.
        /// </summary>
        /// <param name="items">The items to add to this control</param>
        public void Add(params string[] items)
        {
            foreach (string s in items)
            {
                Add(s);
            }
        }
    }
}