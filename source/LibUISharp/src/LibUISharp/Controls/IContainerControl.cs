namespace LibUISharp.Controls
{
    internal interface IContainerControl<TContainer, out TCollection>
        where TContainer : ContainerControl
        where TCollection : ControlCollection<TContainer>
    {
        TCollection Children { get; }
    }
}