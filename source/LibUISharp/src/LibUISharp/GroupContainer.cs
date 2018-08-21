using LibUISharp.Internal;

namespace LibUISharp
{
    /// <summary>
    /// Represents a control that creates a container that has a border and a title for user-interface (UI) content.
    /// </summary>
    [NativeType("uiGroup")]
    public class GroupContainer : SingleContainer<GroupContainer, Control>
    {
        private Control child;
        private string title;
        private bool isMargined = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="GroupContainer"/> class with the specified title.
        /// </summary>
        /// <param name="title">The title of this <see cref="GroupContainer"/>.</param>
        public GroupContainer(string title, bool isMargined = false)
        {
            Handle = NativeCalls.NewGroup(title);
            this.title = title;
            IsMargined = isMargined;
        }


        /// <summary>
        /// Gets or sets the title for this <see cref="GroupContainer"/> control.
        /// </summary>
        public string Title
        {
            get
            {
                title = NativeCalls.GroupTitle(Handle);
                return title;
            }
            set
            {
                if (title != value)
                {
                    NativeCalls.GroupSetTitle(Handle, value);
                    title = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether or not this <see cref="TabPage"/> has outer margins.
        /// </summary>
        public bool IsMargined
        {
            get
            {
                isMargined = NativeCalls.GroupMargined(Handle);
                return isMargined;
            }
            set
            {
                if (isMargined != value)
                {
                    NativeCalls.GroupSetMargined(Handle, value);
                    isMargined = value;
                }
            }
        }

        /// <summary>
        /// Sets this <see cref="GroupContainer"/> object's child <see cref="Control"/>.
        /// </summary>
        public override Control Child
        {
            set
            {
                if (child != value)
                {
                    NativeCalls.GroupSetChild(Handle, value.Handle);
                    child = value;
                }
            }
        }
    }
}